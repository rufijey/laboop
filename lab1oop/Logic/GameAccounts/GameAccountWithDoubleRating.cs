using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.BLL.GameAccounts
{
    public class GameAccountWithDoubleRating : GameAccount
    {
        public GameAccountWithDoubleRating(int gamesAccountType = 2) : base()
        {
            GameHistory = new List<GameResult>();
            GamesAccountType = gamesAccountType;
        }
        public override int CalculateRatingChange(int rating)
        {
            return 2*rating;
        }
    }
}