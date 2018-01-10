using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    public class ExpenseRepository : IRepository<Expense>
    {
        ApplicationContext db;

        public ExpenseRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(Expense exp)
        {
            db.Expenses.Add(exp);
        }

        public void Delete(int id)
        {
            Expense exp = db.Expenses.Find(id);
            if (exp != null)
                db.Expenses.Remove(exp);
        }

        public IEnumerable<Expense> Find(Func<Expense, bool> predicate)
        {
            return db.Expenses.Where(predicate).ToList();
        }

        public Expense Get(int id)
        {
            return db.Expenses.Find(id);
        }

        public IEnumerable<Expense> GetAll()
        {
            return db.Expenses;
        }

        public void Update(Expense expense)
        {
            db.Entry(expense).State = EntityState.Modified;
        }
    }
}
