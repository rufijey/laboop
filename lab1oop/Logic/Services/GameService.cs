
using laboop.BLL.GameAccounts;
using laboop.BLL.Games;
using laboop.DAL;
using laboop.DAL.Models;
using OopLab.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laboop.Logic.Services.Abstract;

namespace laboop.Logic.Services
{
    public class GameService : IGameService
    {
        GameRepository repository;
        GameAccountService _accountService;
        Game _game;
        public GameService(DbContext context)
        {
            repository = new GameRepository(context);
            _accountService = new GameAccountService(context);
        }
        public void Create(Game entity)
        {
            entity.Id = repository.Get().Count();
            repository.Create(Map(entity));
            _game = entity;
        }
        public void Update(Game entity)
        {
            repository.Update(Map(entity));
        }

        public List<Game> GetAll()
        {
            var list = Map(repository.Get());
            return list;
        }

        private GameModel Map(Game game)
        {
            return new GameModel
            {
                Id = game.Id,
                Player1 = _accountService.Map(game.player1),
                Player2 = _accountService.Map(game.player2),
                Rating = game.Rating,
                GameType = game.GameType,
            };

        }
        private Game Map(GameModel game)
        {

            if (game.GameType == 1)
            {
                return new Game(_accountService.Map(game.Player1), _accountService.Map(game.Player2))
                {
                    Id = game.Id,
                    player1 = _accountService.Map(game.Player1),
                    player2 = _accountService.Map(game.Player2),
                    Rating = game.Rating,

                };
            }
            else if (game.GameType == 2)
            {
                return new GameWithBot(_accountService.GetById(0), _accountService.Map(game.Player1))
                {
                    Id = game.Id,
                    player1 = _accountService.Map(game.Player1),
                    Rating = game.Rating,
                    GameType = game.GameType,
                };
            }
            else
            {
                return new GameWithoutRating(_accountService.Map(game.Player1), _accountService.Map(game.Player2))
                {
                    Id = game.Id,
                    player1 = _accountService.Map(game.Player1),
                    player2 = _accountService.Map(game.Player2),
                    Rating = game.Rating,
                    GameType = game.GameType,
                };
            }
        }
        public List<Game> Map(List<GameModel> entities)
        {
            List<Game> gameAccounts = new List<Game>();

            foreach (var game in entities)
            {
                gameAccounts.Add(Map(game));
            }
            return gameAccounts;
        }
        public List<GameModel> Map(List<Game> games)
        {
            List<GameModel> gameModels = new List<GameModel>();

            foreach (var game in games)
            {
                gameModels.Add(Map(game));
            }
            return gameModels;
        }
    }
}
