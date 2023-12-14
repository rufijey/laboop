using laboop.DAL.Repositories.Abstract;
using laboop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laboop.DAL;

namespace OopLab.DAL.Repositories
{
    public class GameRepository : IGameRepository
    {
        private DbContext context;
        public GameRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(GameModel entity)
        {
            context.Games.Add(entity);
        }
        public void Delete(GameModel entity)
        {
            context.Games.RemoveAt(entity.Id);
            int ID = 1;
            foreach (var game in context.Games) {context.Games[ID].Id = ID;ID++;}
        }
        public List<GameModel> Get()
        {
            return context.Games;
        }
        public GameModel Get(int Id)
        {
            return context.Games[Id];
        }
        public void Update(GameModel entity)
        {
            context.Games[entity.Id] = entity;
        }
    }
}
