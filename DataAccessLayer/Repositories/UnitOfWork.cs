using System;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
        private WalletRepository walletRepository;
        private IncomeRepository incomeRepository;
        private ExpenseRepository expenseRepository;
        private IncomeCategoryRepository incomeCategoryRepository;
        private ExpenseCategoryRepository expenseCategoryRepository;

        public IRepository<Wallet> Wallets
        {
            get
            {
                if (walletRepository == null)
                    walletRepository = new WalletRepository(db);
                return walletRepository;
            }
        }

        public IRepository<Income> Incomes
        {
            get
            {
                if (incomeRepository == null)
                    incomeRepository = new IncomeRepository(db);
                return incomeRepository;
            }

        }

        public IRepository<Expense> Expenses
        {
            get
            {
                if (expenseRepository == null)
                    expenseRepository = new ExpenseRepository(db);
                return expenseRepository;
            }
        }

        public IRepository<ExpenseCategory> ExpenseCategories
        {
            get
            {
                if (expenseCategoryRepository == null)
                    expenseCategoryRepository = new ExpenseCategoryRepository(db);
                return expenseCategoryRepository;
            }
        }

        public IRepository<IncomeCategory> IncomeCategories
        {
            get
            {
                if (incomeCategoryRepository == null)
                    incomeCategoryRepository = new IncomeCategoryRepository(db);
                return incomeCategoryRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
