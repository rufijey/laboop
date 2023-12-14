using laboop.BLL.GameAccounts;
using laboop.DAL.Repositories;
using laboop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laboop.DAL.Models;
using laboop.Logic.Services.Abstract;
using laboop.BLL;

namespace laboop.Logic.Services
{
    public class GameAccountService : IGameAccountService
    {
        GameAccountRepository repository;
        GameResultRepository _historyRepository;
        public GameAccountService(DbContext context)
        {
            repository = new GameAccountRepository(context);
            _historyRepository= new GameResultRepository(context);
        }
        public void Create(GameAccount entity)
        {
            entity.Id = repository.Get().Count();
            repository.Create(Map(entity));
        }
        public List<GameAccount> GetAll()
        {
            var list = Map(repository.Get());
            return list;
        }
        public GameAccount GetById(int id)
        {
            GameAccount acc = Map(repository.Get(id));
            return acc;
        }
        public void Update(GameAccount entity)
        {
            repository.Update(Map(entity));
        }
        public GameAccount Map(GameAccountModel gameAccount)
        {
            if (gameAccount.GamesAccountType == 0)
            {
                return new BotAccount()
                {
                    Id = gameAccount.Id,
                    UserName = gameAccount.UserName,
                    GamesAccountType = gameAccount.GamesAccountType,
                };
            }
            else if (gameAccount.GamesAccountType == 1)
            {
                return new GameAccount()
                {
                    Id = gameAccount.Id,
                    UserName = gameAccount.UserName,
                    Rating = gameAccount.Rating,
                    GamesCount = gameAccount.GamesCount,
                    GamesAccountType = gameAccount.GamesAccountType,
                    GameHistory = MapGameResults(_historyRepository.Get()?.Where(x => x.AccountId == gameAccount.Id).ToList() ?? new List<GameResultModel>()),
                };
            }
            else if (gameAccount.GamesAccountType == 2)
            {
                return new GameAccountWithDoubleRating()
                {

                    Id = gameAccount.Id,
                    UserName = gameAccount.UserName,
                    Rating = gameAccount.Rating,
                    GamesCount = gameAccount.GamesCount,
                    GamesAccountType = gameAccount.GamesAccountType,
                    GameHistory = MapGameResults(_historyRepository.Get()?.Where(x => x.AccountId == gameAccount.Id).ToList() ?? new List<GameResultModel>()),
                };
            }
            else
            {
                return new GameAccountWithRandomRating()
                {
                    Id = gameAccount.Id,
                    UserName = gameAccount.UserName,
                    Rating = gameAccount.Rating,
                    GamesCount = gameAccount.GamesCount,
                    GamesAccountType = gameAccount.GamesAccountType,
                    GameHistory = MapGameResults(_historyRepository.Get()?.Where(x => x.AccountId == gameAccount.Id).ToList() ?? new List<GameResultModel>()),
                };
            }
        }

        public GameAccountModel Map(GameAccount gameAccount)
        {

            return new GameAccountModel
            {
                Id = gameAccount.Id,
                UserName = gameAccount.UserName,
                Rating = gameAccount.Rating,
                GamesCount = gameAccount.GamesCount,
                GamesAccountType = gameAccount.GamesAccountType,
            };
        }

        public List<GameAccount> Map(List<GameAccountModel> entities)
        {
            List<GameAccount> gameAccounts = new List<GameAccount>();

            foreach (var gameAccount in entities)
            {
                gameAccounts.Add(Map(gameAccount));
            }
            return gameAccounts;
        }
        public List<GameAccountModel> Map(List<GameAccount> gameAccounts)
        {
            List<GameAccountModel> gameAccountModels = new List<GameAccountModel>();

            foreach (var gameAccount in gameAccounts)
            {
                gameAccountModels.Add(Map(gameAccount));
            }
            return gameAccountModels;
        }
        public GameResultModel MapGameResult(GameResult result)
        {
            return new GameResultModel
            {
                OpponentName = result.OpponentName,
                Result = result.Result,
                RatingChange = result.RatingChange,
                AccountId = result.GameAccountId
            };
        }
        public GameResult MapGameResult(GameResultModel entity)
        {
            return new GameResult(entity.OpponentName, entity.Result, entity.RatingChange, entity.AccountId);
        }
        public List<GameResult> MapGameResults(List<GameResultModel> entities)
        {
            List<GameResult> gameResults = new List<GameResult>();

            foreach (var entity in entities)
            {
                gameResults.Add(MapGameResult(entity));
            }

            return gameResults;
        }
        public List<GameResultModel> MapGameResults(List<GameResult> results)
        {

            List<GameResultModel> gameResultModels = new List<GameResultModel>();

            foreach (var gameResult in results)
            {
                gameResultModels.Add(MapGameResult(gameResult));
            }

            return gameResultModels;
        }

        public List<GameResult> GetHistory(int Id)
        {
            return MapGameResults(_historyRepository.Get()?.Where(x => x.AccountId == Id).ToList() ?? new List<GameResultModel>());
        }

        public void AddGameResult(GameResult gameResult)
        {
            _historyRepository.Create(MapGameResult(gameResult));
        }
    }
}