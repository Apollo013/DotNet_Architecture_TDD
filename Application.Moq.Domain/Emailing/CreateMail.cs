using Application.Moq.Domain.Customers;
using Application.Moq.Domain.Exceptions;
using System;

namespace Application.Moq.Domain.Emailing
{
    public class CreateMail : ICreateMail
    {
        public IMail Create(ICustomer customer)
        {
            Console.WriteLine("create mail error");
            if (customer == null)
            {
                throw new CannotBeNullException("create mail error");
            }
            return new StandardMail(customer.Email, "info@mightyco.com", "Welcome", "Thanks for registering");
        }
    }
}
