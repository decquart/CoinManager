using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    public class IncomeRepository : IRepository<Income>
    {
        ApplicationContext db;

        public IncomeRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(Income income)
        {
            db.Incomes.Add(income);
        }

        public void Delete(int id)
        {
            var inc = db.Incomes.Find(id);
            if (inc != null)
                db.Incomes.Remove(inc);
        }

        public IEnumerable<Income> Find(Func<Income, bool> predicate)
        {
            return db.Incomes.Where(predicate).ToList();
        }

        public Income Get(int id)
        {
            return db.Incomes.Find(id);
        }

        public IEnumerable<Income> GetAll()
        {
           return db.Incomes;
        }

        public void Update(Income inc)
        {
            db.Entry(inc).State = EntityState.Modified;
        }
    }
}
