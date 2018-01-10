using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Context;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    public class WalletRepository : IRepository<Wallet>
    {
        private ApplicationContext db;

        public WalletRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Wallet> GetAll()
        {
            return db.Wallets;
        }

        public Wallet Get(int id)
        {
           return db.Wallets.Find(id);
        }

        public void Create(Wallet wallet)
        {
            db.Wallets.Add(wallet);
        }

        public void Delete(int id)
        {
            Wallet w = db.Wallets.Find(id);
            if(w != null)
                db.Wallets.Remove(w);
        }

        public IEnumerable<Wallet> Find(Func<Wallet, bool> predicate)
        {
            return db.Wallets.Where(predicate).ToList();
        }
        
        public void Update(Wallet wallet)
        {
            db.Entry(wallet).State = EntityState.Modified;
        }
    }
}
