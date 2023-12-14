using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.DAL.Models
{
    public class GameAccountModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public int GamesCount { get; set; } = 0; // Кількість ігор гравця
        public int GamesAccountType { get; set; }
    }
}
