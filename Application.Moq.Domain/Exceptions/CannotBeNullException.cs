using System;

namespace Application.Moq.Domain.Exceptions
{
    public class CannotBeNullException : Exception
    {
        public CannotBeNullException(string message) : base(message)
        { }
    }
}
