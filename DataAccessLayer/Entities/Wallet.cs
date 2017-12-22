using System.Collections.Generic;


namespace DataAccessLayer.Entities
{
    public class Wallet
    {
        ICollection<Income> Incomes { get; set; }
        ICollection<Expense> Expenses { get; set; }
    }
}
