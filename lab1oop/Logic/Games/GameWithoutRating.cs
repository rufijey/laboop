
using laboop.BLL.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.BLL.Games
{
    public class GameWithoutRating : Game
    {
        public GameWithoutRating(GameAccount player1, GameAccount player2, int rating = 0, int gameType =3) : base(player1, player2, rating, gameType)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.Rating = rating;
            GameType= gameType;
        }
        public GameWithoutRating(int rating = 0, int gameType = 3) : base()
        {
            this.Rating = rating;
            GameType = gameType;
        }
    }
}
