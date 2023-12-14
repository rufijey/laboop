using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.BLL
{
    public class GameResult
    {
        public string OpponentName { get; set; }
        public bool Result { get; set; }
        public int RatingChange { get; set; }
        public int GameAccountId { get; set; }

        public GameResult(string opponentName, bool result, int ratingChange, int accountId)
        {
            OpponentName = opponentName;
            Result = result;
            RatingChange = ratingChange;
            GameAccountId = accountId;
        }
    }
}
