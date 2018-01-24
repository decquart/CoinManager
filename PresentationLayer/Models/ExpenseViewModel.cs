using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class ExpenseViewModel
    {
        public double Sum { get; set; }
        public string Comment { get; set; }
        public DateTime Time { get; set; }

        public int WalletId { get; set; }
        public int ExpenseCategoryID { get; set; }
    }
}