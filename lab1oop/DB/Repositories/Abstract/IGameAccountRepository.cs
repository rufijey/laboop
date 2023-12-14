using laboop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.DAL.Repositories.Abstract
{
    public interface IGameAccountRepository
    {
        public void Create(GameAccountModel entity);
        public List<GameAccountModel> Get();
        public GameAccountModel Get(int id);
        public void Update(GameAccountModel entity);
        public void Delete(GameAccountModel entity);
    }
}
