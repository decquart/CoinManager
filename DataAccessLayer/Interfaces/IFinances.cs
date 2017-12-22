namespace DataAccessLayer.Interfaces
{
    interface IFinances
    {
        double Sum { get; }
        string Comment { get; set; }
        ICategory category { get; set; }
    }
}
