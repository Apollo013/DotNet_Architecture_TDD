using Application.Moq.Domain.Customers;
using Application.Moq.Domain.Emailing;
using Application.Moq.Domain.Exceptions;
using Application.Moq.Domain.Repository;
using System.Collections.Generic;

namespace Application.Moq.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private IRepository _repo;
        private IMailClient _mailClient;
        private ICreateMail _createMailService;
        public CustomerService(IRepository repo, IMailClient mailClient, ICreateMail createMailService)
        {
            if (repo == null)
            {
                System.Console.WriteLine("null repo");
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
            System.Console.WriteLine("save a single customer");
            try
            {
                if (customer == null)
                {
                    throw new CannotBeNullException("cust null");
                }

                _repo.Save(customer);

                var mail = _createMailService.Create(customer); //new StandardMail(customer.Email, "From Me", "HOWYA MARY !!", "Welcome"); ;//

                var rv = _mailClient.SendMail(mail);// new StandardMail() { To = customer.Email, Body = "HOWYA MARY !!", Subject = "Welcome" });

                return rv;
            }
            catch (CannotBeNullException ex)
            {
                throw;
            }
            /*
            if (_repo.Save(customer))
            {
                var mail = _createMailService.Create(customer);
                return _mailClient.SendMail(mail);// new StandardMail() { To = customer.Email, Body = "HOWYA MARY !!", Subject = "Welcome" });
            }
            */
            //return false;
        }

        public void SaveMany(List<ICustomer> customers)
        {
            System.Console.WriteLine("save many customers");
            if (customers == null)
            {
                throw new CannotBeNullException("customers null");
            }
            foreach (var cust in customers)
            {
                _repo.Save(cust);
            }
        }
    }
}
