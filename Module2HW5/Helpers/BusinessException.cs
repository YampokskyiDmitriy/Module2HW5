using System;

namespace Module2HW5.Helpers
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
