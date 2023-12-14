using laboop.Logic.Services;
using laboop.DAL;
using laboop.UI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laboop.Logic.Services.Abstract;

namespace laboop.UI
{
    public class ShowGames : IUI
    {
        IGameService _gameService;
        public ShowGames(DbContext context)
        {
            _gameService = new GameService(context);
        }
        public void Action()
        {
            var listGames = _gameService.GetAll();
            foreach (var game in listGames)
            {
                if (game != null && game.GameType != 2)
                {
                    Console.WriteLine($"Game ID:{game.Id} Player: {game.player1.UserName} PLayer: {game.player2.UserName}");
                }
                else if (game != null)
                {
                    Console.WriteLine($"Game ID:{game.Id} Player: {game.player1.UserName}");
                }
            }
        }

        public string Show()
        {
            return "show all games";
        }
    }
}
