
using laboop.BLL.GameAccounts;
using laboop.Logic.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.BLL.Games
{
    public class GameWithBot : Game
    {
        public GameWithBot(GameAccount player1, GameAccount player2, int rating =10, int gameType=2) : base(player1, new BotAccount(), rating, gameType)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.Rating = rating;
            GameType= gameType;
            player1.Id = 0;
        }
        public GameWithBot(int rating = 10, int gameType = 2) : base(rating, gameType)
        {
            this.Rating = rating;
            GameType = gameType;
        }
        public override string Show1() 
        {
            return "Enter name of player: \n";
        }
        public override string Show2()
        {
            return "";
        }
        public override void EnterPlayer2(IGameAccountService accountService, IGameService gameService)
        {
            player2= accountService.GetAll()[^1];
            accountService.Update(player2);
            gameService.Update(this);
        }
    }
}
