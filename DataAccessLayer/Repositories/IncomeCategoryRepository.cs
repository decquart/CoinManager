using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    public class IncomeCategoryRepository : IRepository<IncomeCategory>
    {
        ApplicationContext db;

        public IncomeCategoryRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(IncomeCategory incCat)
        {
            db.IncomeCategories.Add(incCat);
        }

        public void Delete(int id)
        {
            IncomeCategory incCat = db.IncomeCategories.Find(id);
            if (incCat != null)
                db.IncomeCategories.Remove(incCat);
        }

        public IEnumerable<IncomeCategory> Find(Func<IncomeCategory, bool> predicate)
        {
            return db.IncomeCategories.Where(predicate).ToList();
        }

        public IncomeCategory Get(int id)
        {
            return db.IncomeCategories.Find(id);
        }

        public IEnumerable<IncomeCategory> GetAll()
        {
            return db.IncomeCategories;
        }

        public void Update(IncomeCategory incCat)
        {
            db.Entry(incCat).State = EntityState.Modified;
        }
    }
}
