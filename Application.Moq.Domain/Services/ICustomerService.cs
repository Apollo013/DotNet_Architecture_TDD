using Application.Moq.Domain.Customers;

namespace Application.Moq.Domain.Services
{
    public interface ICustomerService
    {
        bool Save(ICustomer customer);
    }
}
