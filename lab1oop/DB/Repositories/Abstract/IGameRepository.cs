
using laboop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.DAL.Repositories.Abstract
{
    public interface IGameRepository
    {
        public void Create(GameModel entity);
        public List<GameModel> Get();
        public GameModel Get(int Id);
        public void Update(GameModel entity);
        public void Delete(GameModel entity);
    }
}
