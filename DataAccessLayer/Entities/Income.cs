using DataAccessLayer.Interfaces;
using System;

namespace DataAccessLayer.Entities
{
    public class Income : IFinances<IncomeCategory>
    {
        public double Sum { get; set; }
        public string Comment { get; set; }
        public IncomeCategory category { get; set; }
        public DateTime OperationTime { get; set; }

        public int WalletID { get; set; }
    }
}
