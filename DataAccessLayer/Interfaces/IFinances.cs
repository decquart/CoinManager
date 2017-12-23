using System;

namespace DataAccessLayer.Interfaces
{
    interface IFinances <TICategory> where TICategory: ICategory
    {
        double Sum { get; }
        string Comment { get; set; }
        TICategory category { get; set; }
        DateTime OperationTime { get; set; }
    }
}
