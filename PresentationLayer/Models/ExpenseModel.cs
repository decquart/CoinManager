using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public string Comment { get; set; }
        public DateTime OperationTime { get; set; }

        public int WalletID { get; set; }
        public int ExpenseCategoryID { get; set; }
    }
}