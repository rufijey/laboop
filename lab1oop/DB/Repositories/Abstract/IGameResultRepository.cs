
using laboop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.DAL.Repositories.Abstract
{
    public interface IGameResultRepository
    {
        public void Create(GameResultModel entity);
        public List<GameResultModel> Get();
    }
}
