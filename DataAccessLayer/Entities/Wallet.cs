using System.Collections.Generic;


namespace DataAccessLayer.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
