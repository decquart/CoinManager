using System;

namespace DataAccessLayer.Interfaces
{
    public interface ITransaction 
    {
        double Sum { get; }
        string Comment { get; set; }
        DateTime OperationTime { get; set; }
    }
}
