using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.DAL.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public GameAccountModel Player1 { get; set; }
        public GameAccountModel Player2 { get; set; }
        public int Rating { get; set; }
        public int GameType { get; set; }
    }
}
