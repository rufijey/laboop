
using laboop.BLL.GameAccounts;
using laboop.BLL.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laboop.BLL.Factory
{
    public class GameAccountFactory
    {
        public GameAccount CreateGameAccount(int accountType)
        {
            switch (accountType)
            {
                case 0:
                    return CreateBotAccount();
                case 1:
                    return CreateStandartAccount();
                case 2:
                    return CreateGameAccountDoubleRating();
                case 3:
                    return CreateGameAccountRandomRating();
                default:
                    throw new ArgumentException("Invalid account type");
            }
        }
        public GameAccount CreateStandartAccount()
        {
            return new GameAccount();
        }
        public GameAccount CreateBotAccount()
        {
            return new BotAccount();
        }
        public GameAccount CreateGameAccountDoubleRating()
        {
            return new GameAccountWithDoubleRating();
        }
        public GameAccount CreateGameAccountRandomRating()
        {
            return new GameAccountWithRandomRating();
        }
    }
}
