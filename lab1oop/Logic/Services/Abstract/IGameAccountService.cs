using laboop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laboop.BLL;
using laboop.BLL.GameAccounts;

namespace laboop.Logic.Services.Abstract
{
    public interface IGameAccountService
    {
        public void Create(GameAccount entity);
        public List<GameAccount> GetAll();
        public GameAccount GetById(int id);
        public void Update(GameAccount entity);
        public List<GameResult> GetHistory(int id);
        public void AddGameResult(GameResult gameResult);
    }
}
