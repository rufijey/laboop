using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using laboop.BLL.GameAccounts;
using laboop.Logic.Services;
using laboop.Logic.Services.Abstract;

namespace laboop.BLL.Games
{
    public class Game
    {
        public int Id { get; set; }    
        public GameAccount? player1 { get; set; }
        public GameAccount? player2 { get; set; }
        public int Rating { get; set; }
        public int GameType { get; set; }
        public Game(GameAccount player1, GameAccount player2, int rating = 10, int gameType = 1)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.Rating = rating;
            GameType = gameType;
        }
        public Game(int rating = 10, int gameType = 1)
        {
            this.Rating = rating;
            GameType = gameType;
        }
        public virtual string Show1() 
        {
            return "Enter name of first player: \n";
        }
        public virtual string Show2()
        {
            return "Enter name of second player: \n";
        }
        public virtual void EnterPlayer1(IGameAccountService accountService, IGameService gameService)
        {
            player1.UserName = Console.ReadLine().Trim();
            accountService.Update(player1);
            gameService.Update(this);
        }
        public virtual void EnterPlayer2(IGameAccountService accountService, IGameService gameService)
        {
            player2.UserName = Console.ReadLine().Trim();
            accountService.Update(player2);
            gameService.Update(this);
        }
        public string Play(IGameAccountService accountService, IGameService gameService)
        {
            Random random = new Random();
            int roll = random.Next(1, 3);
            string result ="";
            if (roll == 1)
            {
                result += $"{player1.UserName} Win!\n";
                player1.WinGame(player2.UserName, Rating, accountService);
                player2.LoseGame(player1.UserName, Rating, accountService);

                accountService.Update(player1);
                accountService.Update(player2);
                gameService.Update(this);

            }
            else if (roll == 2)
            {
                result += $"{player2.UserName} Win!\n";
                player2.WinGame(player1.UserName, Rating, accountService);
                player1.LoseGame(player2.UserName, Rating, accountService);

                accountService.Update(player1);
                accountService.Update(player2);
                gameService.Update(this);
            }
            return result;
        }


    }
}
