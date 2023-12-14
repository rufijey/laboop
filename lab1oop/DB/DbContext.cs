using laboop.BLL.GameAccounts;
using laboop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.DAL
{
    public class DbContext
    {
        public List<GameModel> Games { get; set; }
        public List<GameAccountModel> Accounts { get; set; }
        public List<GameResultModel> GameHistory { get; set; }

        public DbContext()
        {
            Games = new List<GameModel>();
            Accounts = new List<GameAccountModel>() { new GameAccountModel() {UserName = "Bot", GamesAccountType =0, Id = 0 } };
            GameHistory = new List<GameResultModel>();
        }
    }
}