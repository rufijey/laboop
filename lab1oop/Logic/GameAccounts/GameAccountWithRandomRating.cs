using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.BLL.GameAccounts
{
    public class GameAccountWithRandomRating : GameAccount
    {
        public GameAccountWithRandomRating(int gamesAccountType = 3) : base()
        {
            GameHistory = new List<GameResult>();
            GamesAccountType = gamesAccountType;
        }
        public override int CalculateRatingChange(int rating)
        {
            var random = new Random();
            return rating + random.Next(-9,9);
        }
    }
}
