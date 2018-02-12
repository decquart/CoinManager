using System;
using System.Collections.Generic;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces
{
    public interface IWalletService
    {
        //create
        void CreateWallet(WalletDTO wallet);
        void CreateExpense(double sum, string comment, DateTime time, int walletId, int expCatId);
        void CreateIncome(double sum, string comment, DateTime time, int walletId, int incCatId);

        //read
        IEnumerable<WalletDTO> GetWallets();
        WalletDTO GetWallet(int walletId);
        IEnumerable<ExpenseDTO> GetExpenses(int walletId);
        IEnumerable<IncomeDTO> GetIncomes(int walletId);
        IEnumerable<ITransaction>  GetTransactions();        
        double GetCurrentBalance();

        //update
        void AddIncomeToWallet(int walletId, int incomeId);
        void AddExpenseToWallet(int walletId, int expenseId);
        void ChangeExpense(int expId, double sum, string comment, DateTime time, int categoryId);
        void ChangeIncome(int incId, double sum, string comment, DateTime time, int categoryId);
        void ChangeWalletName(WalletDTO walletDTO);

        //delete
        void RemoveWallet(int walletId);
        void Dispose();
    }
}
