using Application.Moq.Domain.Customers;
using Application.Moq.Domain.Exceptions;

namespace Application.Moq.Domain.Repository
{
    public class CustomerRepository : IRepository
    {
        public bool Save(ICustomer customer)
        {
            if (customer == null)
            {
                throw new CannotBeNullException("customer null");
            }

            return true;
        }
    }
}
