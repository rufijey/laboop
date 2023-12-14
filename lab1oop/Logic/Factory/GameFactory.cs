using laboop.BLL.GameAccounts;
using laboop.BLL.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.BLL.Factory
{
    public class GameFactory
    {
        public Game CreateGame(int gameType)
        {
            switch (gameType)
            {
                case 1:
                    return CreateStandartGame();
                case 2:
                    return CreateGameWithBot();
                case 3:
                    return CreateGameWithoutRating();
                default:
                    throw new ArgumentException("Invalid game type");
            }
        }

        public Game CreateStandartGame()
        {
            return new Game() {player1 =new GameAccount(), player2=new GameAccount() };
        }

        public Game CreateGameWithoutRating()
        {
            return new GameWithoutRating() { player1 = new GameAccount(), player2 = new GameAccount() };
        }

        public Game CreateGameWithBot()
        {
            return new GameWithBot() { player1 = new GameAccount(), player2 = new GameAccount() };
        }
    }
}
