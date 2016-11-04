namespace Application.Moq.Domain.Customers
{
    public class Customer : ICustomer
    {
        public string Email { get; private set; }

        public string Name { get; private set; }
    }
}
