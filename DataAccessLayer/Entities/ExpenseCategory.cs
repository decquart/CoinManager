using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class ExpenseCategory : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Expense> Expenses { get; set; }

        public ExpenseCategory()
        {
            Expenses = new List<Expense>();
        }
    }
}
