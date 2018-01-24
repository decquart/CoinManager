using System;
using System.Collections.Generic;
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Interfaces
{
    public interface IWalletService
    {
        //create
        void CreateWallet(string name, double balance);

        //read
        IEnumerable<WalletDTO> GetWallets();
        WalletDTO GetWallet(int walletId);
        IEnumerable<ExpenseDTO> GetExpenses(int walletId);
        IEnumerable<IncomeDTO> GetIncomes(int walletId);
        double GetCurrentBalance();

        //update
        void AddIncomeToWallet(int walletId, int incomeId);
        void AddExpenseToWallet(int walletId, int expenseId);
        void ChangeExpense(int expId, double sum, string comment, DateTime time, int categoryId);
        void ChangeIncome(int incId, double sum, string comment, DateTime time, int categoryId);
        void ChangeWalletName(int walletId, string name);

        //delete
        void RemoveWallet(int walletId);
        void Dispose();
    }
}
