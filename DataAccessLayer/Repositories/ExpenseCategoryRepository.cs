using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    public class ExpenseCategoryRepository : IRepository<ExpenseCategory>
    {
        ApplicationContext db;

        public ExpenseCategoryRepository(ApplicationContext context)    
        {
            this.db = context;
        }

        public void Create(ExpenseCategory expCat)
        {
            db.ExpenseCategories.Add(expCat);
        }

        public void Delete(int id)
        {
            ExpenseCategory expCat = db.ExpenseCategories.Find(id);
            if (expCat != null)
                db.ExpenseCategories.Remove(expCat);
        }

        public IEnumerable<ExpenseCategory> Find(Func<ExpenseCategory, bool> predicate)
        {
           return db.ExpenseCategories.Where(predicate).ToList();
        }

        public ExpenseCategory Get(int id)
        {
            return db.ExpenseCategories.Find(id);
        }

        public IEnumerable<ExpenseCategory> GetAll()
        {
            return db.ExpenseCategories;
        }

        public void Update(ExpenseCategory expCat)
        {
            db.Entry(expCat).State = EntityState.Modified;
        }
    }
}
