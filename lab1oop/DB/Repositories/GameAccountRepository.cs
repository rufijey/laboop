using laboop.DAL.Models;
using laboop.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop.DAL.Repositories
{
    public class GameAccountRepository : IGameAccountRepository
    {
        DbContext context;
        public GameAccountRepository(DbContext context) 
        { 
            this.context = context; 
        }
        public void Create(GameAccountModel entity)
        {
            context.Accounts.Add(entity);
        }
        public void Delete(GameAccountModel entity)
        {
            context.Accounts.RemoveAt(entity.Id);
            int ID = 1;
            foreach (var gameAccount in context.Accounts) { context.Accounts[ID].Id = ID; ID++; }
        }
        public List<GameAccountModel> Get()
        {
            return context.Accounts;
        }
        public GameAccountModel Get(int id)
        {
            return context.Accounts[id];
        }
        public void Update(GameAccountModel entity)
        {
            context.Accounts[entity.Id] = entity;
        }
    }
}
