using Application.Moq.Domain.Customers;

namespace Application.Moq.Domain.Emailing
{
    public interface ICreateMail
    {
        IMail Create(ICustomer customer);
    }
}
