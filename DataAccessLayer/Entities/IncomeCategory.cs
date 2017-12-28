using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class IncomeCategory : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Income> Incomes { get; set; }
    }
}
