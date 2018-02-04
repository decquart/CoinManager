using DataAccessLayer.Interfaces;
using System;

namespace DataAccessLayer.Entities
{
    public class Income : ITransaction
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public string Comment { get; set; }
        public DateTime OperationTime { get; set; }

        public int WalletID { get; set; }
        public Wallet Wallet { get; set; }

        public int IncomeCategoryID { get; set; }
        public IncomeCategory category { get; set; }
    }
}
