using System;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Wallet> Wallets { get; }
        IRepository<Income> Incomes { get; }
        IRepository<Expense> Expenses { get; }
        IRepository<ExpenseCategory> ExpenseCategories{ get; }
        IRepository<IncomeCategory> IncomeCategories{ get; }

        void Save();
    }
}
