using laboop.BLL.Factory;
using laboop.BLL.GameAccounts;
using laboop.DAL;
using laboop.Logic.Services;
using laboop.Logic.Services.Abstract;
using laboop.UI.Abstract;

namespace laboop.UI
{
    public class StartGame : IUI
    {
        IGameService _gameService;
        IGameAccountService _accountService;
        GameAccountFactory _accountFactory;
        GameFactory _gameFactory;
        public StartGame(DbContext context)
        {
            _gameService = new GameService(context);
            _accountService = new GameAccountService(context);
            _accountFactory = new GameAccountFactory();
            _gameFactory = new GameFactory();
        }
        public void Action()
        {
            Console.WriteLine("\nChoose game 1.Standart 2.WithBot 3.WithoutRating");
            int temp = Convert.ToInt32(Console.ReadLine());

            _gameService.Create(_gameFactory.CreateGame(temp));
            var id = _gameService.GetAll().Count();
            var game = _gameService.GetAll()[id - 1];

            game.player1 = ChoosePlayer();
            if (game.GameType != 2) game.player2 = ChoosePlayer();
            else
            {
                var player = _accountService.GetById(0);
                _accountService.Create(player);
                player.Id = _accountService.GetAll().Count()-1;
                game.player2 = player;

            }
            _gameService.Update(game);
            Console.Write(game.Show1());
            game.EnterPlayer1(_accountService, _gameService);
            Console.Write(game.Show2());
            game.EnterPlayer2(_accountService, _gameService);
            for (int i =1; i < 4; i++) 
            {
                Console.WriteLine($"\nRound {i}");
                Console.WriteLine(game.Play(_accountService, _gameService));
            }

        }
        public GameAccount ChoosePlayer()
        {
            Console.WriteLine("\nChoose player account 1.Standart 2.Double rating 3.Random rating");
            int temp = Convert.ToInt32(Console.ReadLine());
            var player = _accountFactory.CreateGameAccount(temp);
            _accountService.Create(player);
            player.Id = _accountService.GetAll().Count - 1;
            return player;
        }
        public string Show()
        {
            return "start game";
        }
    }
}
