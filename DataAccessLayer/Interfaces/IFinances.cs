using System;

namespace DataAccessLayer.Interfaces
{
    public interface IFinances <TICategory> where TICategory: ICategory
    {
        double Sum { get; }
        string Comment { get; set; }
        TICategory category { get; set; }
        DateTime OperationTime { get; set; }
    }
}
