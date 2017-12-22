using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Entities
{
    public class Income : IFinances
    {
        public double Sum { get; set; }
        public string Comment { get; set; }
        ICategory IFinances.category { get; set; }
    }
}
