using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.DTO;
using AutoMapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;


//Injection of dependency IMapper into parameter mapper of constructor of type WalletService
namespace BusinessLogicLayer.Services
{
    public class WalletService : IWalletService
    {
        private IUnitOfWork db;
        private IMapper mapper;

        public WalletService(IUnitOfWork uow, IMapper _mapper)
        {           
            db = uow;
            mapper = _mapper;
        }

        #region create
       public void CreateWallet(string name, double balance)
        {
            var wallet = new Wallet { Name = name, Balance = balance };
            db.Wallets.Create(wallet);
            db.Save();
        }

        public void CreateExpense(double sum, string comment, DateTime time, int walletId, int expCatId)
        {
            var exp = new Expense
            {
                Sum = sum,
                Comment = comment,
                OperationTime = time,
                WalletID = walletId,
                ExpenseCategoryID = expCatId
            };
            db.Expenses.Create(exp);
            AddExpenseToWallet(exp.WalletID, exp.Id);
            db.Save();
        }

        public void CreateIncome(double sum, string comment, DateTime time, int walletId, int incCatId)
        {
            var inc = new Income
            {
                Sum = sum,
                Comment = comment,
                OperationTime = time,
                WalletID = walletId,
                IncomeCategoryID = incCatId
            };
            db.Incomes.Create(inc);
            AddIncomeToWallet(inc.WalletID, inc.Id);
            db.Save();
        }

        #endregion

        #region read

        public IEnumerable<WalletDTO> GetWallets()
        {
            return mapper.Map<IEnumerable<Wallet>, List<WalletDTO>>(db.Wallets
                .GetAll());
        }

        public WalletDTO GetWallet(int walletId)
        {
            var wallet = db.Wallets.Get(walletId);
            if (wallet == null)
                throw new ValidationException("Wallet not found");

            return mapper.Map<Wallet, WalletDTO>(wallet);
        }

        public IEnumerable<ExpenseDTO> GetExpenses(int walletId)
        {
            var wallet = db.Wallets.Get(walletId);
            if (wallet == null)
                throw new ValidationException("Wallet not found");

            return mapper.Map<IEnumerable<Expense>, List<ExpenseDTO>>(db.Expenses
                .Find(t => t.WalletID.Equals(walletId)));
        }

        public IEnumerable<IncomeDTO> GetIncomes(int walletId)
        {
            var wallet = db.Wallets.Get(walletId);
            if (wallet == null)
                throw new ValidationException("Wallet not found");

            return mapper.Map<IEnumerable<Income>, List<IncomeDTO>>(db.Incomes
                .Find(t => t.WalletID.Equals(walletId)));
        }

        public IEnumerable<ITransaction> GetTransactions()
        {
            var exp = db.Expenses.GetAll().ToList();
            var inc = db.Incomes.GetAll().ToList();
            List<ITransaction> transaction = new List<ITransaction>();

            foreach (var e in exp)
            {
                transaction.Add(e);
            }

            foreach (var i in inc)
            {
                transaction.Add(i);
            }
            return transaction;
        }

        public double GetCurrentBalance()
        {
            double balance = 0;
            var wallets = db.Wallets.GetAll();

            foreach (var w in wallets)
                balance += w.Balance;
            
            return balance;
        }


        #endregion

        #region update     

        public void AddIncomeToWallet(int walletId, int incomeId)
        {
            var wallet = db.Wallets.Get(walletId);
            var income = db.Incomes.Get(incomeId);

            if (!wallet.Incomes.Contains(income))
            {
                wallet.Incomes.Add(income);
                db.Wallets.Update(wallet);
                db.Save();
            }
        }

        public void AddExpenseToWallet(int walletId, int expenseId)
        {
            var wallet = db.Wallets.Get(walletId);
            var expense = db.Expenses.Get(expenseId);

            if (!wallet.Expenses.Contains(expense));
            {
                wallet.Expenses.Add(expense);
                db.Wallets.Update(wallet);
                db.Save();
            }
        }

        public void ChangeExpense(int expId, double sum, string comment, DateTime time, int categoryId)
        {
            var expense = db.Expenses.Get(expId);
            var _category = db.ExpenseCategories.Get(categoryId);
            if (expense != null)
            {
                expense.Sum = sum;
                expense.Comment = comment;
                expense.OperationTime = time;

                if (_category == null)
                    throw new ValidationException("Category not found");

                expense.category = _category;
                db.Expenses.Update(expense);
                db.Save();
            }
        }

        public void ChangeIncome(int incId, double sum, string comment, DateTime time, int categoryId)
        {
            var income = db.Incomes.Get(incId);
            var _category = db.IncomeCategories.Get(categoryId);

            if (income != null)
            {
                income.Sum = sum;
                income.Comment = comment;
                income.OperationTime = time;

                if (_category == null)
                    throw new ValidationException("Category not found");

                income.category = _category;
                db.Incomes.Update(income);
                db.Save();
            }
        }

        public void ChangeWalletName(int walletId, string name)
        {
            var wallet = db.Wallets.Get(walletId);

            if (wallet != null)
            {
                wallet.Name = name;
                db.Wallets.Update(wallet);
                db.Save();
            }
        }

        #endregion

        #region delete

        public void RemoveWallet(int walletId)
        {
            var wallet = db.Wallets.Get(walletId);
            if (wallet == null)
                throw new ValidationException("Wallet not found");

            //////////////// TODO //////////////////////

            //////////////////////////////////////

            db.Wallets.Delete(walletId);            
            db.Save();
        }

        #endregion

        public void Dispose()
        {
            db.Dispose();
        }

       
    }
}
