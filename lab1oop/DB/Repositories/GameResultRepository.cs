using laboop.DAL.Models;
using laboop.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.DAL.Repositories
{
    public class GameResultRepository : IGameResultRepository
    {
        DbContext context;
        public GameResultRepository(DbContext context) 
        { 
            this.context = context; 
        }
        public void Create(GameResultModel entity)
        {
           context.GameHistory.Add(entity);
        }

        public List<GameResultModel> Get()
        {
            return context.GameHistory;
        }

    }
}
