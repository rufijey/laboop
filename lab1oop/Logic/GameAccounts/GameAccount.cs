using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laboop.Logic.Services;
using laboop.Logic.Services.Abstract;
using laboop.UI;

namespace laboop.BLL.GameAccounts
{
    public class GameAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; } = 0;
        public List<GameResult> GameHistory;
        public int GamesCount { get; set; } = 0;
        public int GamesAccountType { get; set; }
        public GameAccount(int gamesAccountType =1)
        {
            GameHistory = new List<GameResult>();
            GamesAccountType = gamesAccountType;
        }

        public void WinGame(string opponentName, int rating, IGameAccountService gameAccountService)
        {
            GamesCount++;
            Rating += CalculateRatingChange(rating);
            var gameResult = new GameResult(opponentName, true, rating, Id);
            GameHistory.Add(gameResult);
            gameAccountService.AddGameResult(gameResult);
        }

        public void LoseGame(string opponentName, int rating, IGameAccountService gameAccountService)
        {
            int temp = Rating;
            GamesCount++;
            if (Rating > rating)
            {
                Rating -= rating;
                var gameResult = new GameResult(opponentName, false, rating, Id);
                GameHistory.Add(gameResult);
                gameAccountService.AddGameResult(gameResult);
            }
            else 
            { 
                Rating = 0;
                var gameResult = new GameResult(opponentName, false, temp - Rating, Id);
                GameHistory.Add(gameResult);
                gameAccountService.AddGameResult(gameResult);
            }
        }

        public string GetStats()
        {
            var stats = $"Game history User name :{UserName}, Id :{Id} \n";
            for (int i = 0; i < GameHistory.Count; i++)
            {
                var result = GameHistory[i];
                string matchResult;

                stats += $"Game {i + 1}: Opponent: {result.OpponentName}, " +
                                  $"Result: {(result.Result ? "Win" : "Lose")}, " +
                                  $"Rating change: {result.RatingChange},\n";
            }
            stats += $"Current rating: {Rating}\n" +
                              $"Games count: {GamesCount}\n";
            return stats;
        }
        public virtual int CalculateRatingChange(int rating)
        {
            return rating;
        }
    }
}
