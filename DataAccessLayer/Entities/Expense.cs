using DataAccessLayer.Interfaces;
using System;

namespace DataAccessLayer.Entities
{
    public class Expense : ITransaction
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public string Comment { get; set; }
        public DateTime OperationTime { get; set; }

        public int WalletID { get; set; }
        public Wallet Wallet { get; set; }

        public int ExpenseCategoryID { get; set; }
        public ExpenseCategory category { get; set; }
    }
}
