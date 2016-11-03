using Application.Moq.Domain.Customers;
using Application.Moq.Domain.Emailing;
using Application.Moq.Domain.Exceptions;
using Application.Moq.Domain.Repository;

namespace Application.Moq.Domain.Services
{
    class CustomerService : ICustomerService
    {
        private IRepository _repo;
        private IMailClient _mailClient;
        private ICreateMail _createMailService;
        public CustomerService(IRepository repo, IMailClient mailClient, ICreateMail createMailService)
        {
            if (repo == null)
            {
                throw new CannotBeNullException("repo");
            }
            if (mailClient == null)
            {
                throw new CannotBeNullException("mail client");
            }
            if (createMailService == null)
            {
                throw new CannotBeNullException("mail create service");
            }
            _repo = repo;
            _mailClient = mailClient;
            _createMailService = createMailService;
        }

        public bool Save(ICustomer customer)
        {
            if (_repo.Save(customer))
            {
                var mail = _createMailService.Create(customer);
                return _mailClient.SendMail(mail);// new StandardMail() { To = customer.Email, Body = "HOWYA MARY !!", Subject = "Welcome" });
            }
            return false;
        }
    }
}
