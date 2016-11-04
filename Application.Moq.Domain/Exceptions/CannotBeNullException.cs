using System;

namespace Application.Moq.Domain.Exceptions
{
    public class CannotBeNullException : Exception
    {
        public CannotBeNullException()
        {

        }
        public CannotBeNullException(string message) : base(message)
        { }
    }
}
