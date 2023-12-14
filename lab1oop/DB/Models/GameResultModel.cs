using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.DAL.Models
{
    public class GameResultModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string OpponentName { get; set; }
        public bool Result { get; set; }
        public int RatingChange { get; set; }
        public int GameId { get; set; }
    }
}
