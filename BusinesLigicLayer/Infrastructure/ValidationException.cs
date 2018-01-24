using System;


namespace BusinessLogicLayer.Infrastructure
{
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string prop)
        {
            Property = prop;
        }
    }
}
