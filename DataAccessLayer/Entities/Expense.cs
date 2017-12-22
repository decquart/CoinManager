using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Expense : IFinances
    {
        public double Sum { get; set; }
        public string Comment { get; set; }
        ICategory IFinances.category { get; set; }
    }
}
