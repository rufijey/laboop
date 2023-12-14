
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.BLL.GameAccounts
{
    public class BotAccount : GameAccount
    {
        public BotAccount(int gamesAccountType = 0) :base()
        {
            UserName = "Bot";
            GamesAccountType = gamesAccountType;
        }
        public override int CalculateRatingChange(int rating)
        {
            return 0;
        }
        public new void WinGame(string opponentName, int rating)
        {
        }
        public new void LoseGame(string opponentName, int rating)
        {
        }
        public new string GetStats()
        {
            return "";
        }

    }
}
