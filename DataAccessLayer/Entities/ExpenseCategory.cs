using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Entities
{
    public class ExpenseCategory : ICategory
    {
        public string Name { get; set; }
    }
}
