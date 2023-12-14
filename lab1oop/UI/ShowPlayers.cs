
using laboop.DAL;
using laboop.Logic.Services;
using laboop.Logic.Services.Abstract;
using laboop.UI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.UI
{
    public class ShowPlayers : IUI
    {
        IGameAccountService _accountService;
        public ShowPlayers(DbContext context)
        {
            _accountService = new GameAccountService(context);
        }
        public void Action()
        {
            var listAccounts = _accountService.GetAll();
            foreach (var account in listAccounts)
            {
                if (account != null && account.GamesAccountType != 0)
                {
                    Console.WriteLine(account.GetStats());
                }
            }
        }

        public string Show()
        {
            return "show all players";
        }
    }
}
