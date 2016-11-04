using Application.Moq.Domain.Customers;
using Application.Moq.Domain.Exceptions;

namespace Application.Moq.Domain.Repository
{
    public class CustomerRepository : IRepository
    {
        public bool Save(ICustomer customer)
        {
            System.Console.WriteLine("persisting a single customer");
            if (customer == null)
            {
                System.Console.WriteLine("repo save error");
                throw new CannotBeNullException("customer null");
            }

            return true;
        }
    }
}
