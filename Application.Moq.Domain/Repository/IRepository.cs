using Application.Moq.Domain.Customers;

namespace Application.Moq.Domain.Repository
{
    public interface IRepository
    {
        bool Save(ICustomer customer);
    }
}
