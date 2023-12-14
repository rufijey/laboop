using laboop.BLL.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.Logic.Services.Abstract
{
    public interface IGameService
    {
        public void Create(Game entity);
        public List<Game> GetAll();
        public void Update(Game entity);
    }
}
