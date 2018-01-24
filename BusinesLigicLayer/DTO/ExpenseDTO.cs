using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public string Comment { get; set; }
        public DateTime OperationTime { get; set; }

        public int WalletID { get; set; }
        public int ExpenseCategoryID { get; set; }
    }
}
