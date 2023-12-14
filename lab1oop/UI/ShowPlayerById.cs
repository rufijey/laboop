using laboop.BLL.GameAccounts;
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
    public class ShowPlayerById : IUI
    {
        IGameAccountService _accountService;
        public ShowPlayerById(DbContext context)
        {
            _accountService = new GameAccountService(context);
        }

        public void Action()
        {
            Console.Write("\nID:");
            int id = Convert.ToInt32(Console.ReadLine());
            GameAccount acc = _accountService.GetById(id);
            Console.WriteLine(acc.GetStats()); 
        }

        public string Show()
        {
            return "show player by id";
        }
    }
}
