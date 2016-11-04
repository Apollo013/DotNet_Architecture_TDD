using Application.Moq.Domain.Emailing;
using Application.Moq.Domain.Exceptions;
using Application.Moq.Domain.Repository;
using Application.Moq.Domain.Services;
using NUnit.Framework;

namespace Application.Moq.Domain.Tests.Customer_Service_Tests
{
    // These tests demonstrate a situation when you do NOT need to use Moq

    [Category("Customer.Service.Tests")]
    [TestFixture]
    public class When_Creating_A_New_Customer_Service
    {
        private IRepository _repo;
        private IMailClient _mailClient;
        private ICreateMail _mailCreate;

        [Test]
        public void Should_Throw_Exception_When_No_Repository_Provided()
        {
            // Arrange
            _mailClient = new GMailClient();
            _mailCreate = new CreateMail();

            // Act & Assert
            Assert.Throws<CannotBeNullException>(() => new CustomerService(null, _mailClient, _mailCreate));
        }

        [Test]
        public void Should_Throw_Exception_When_No_MailClient_Provided()
        {
            // Arrange
            _repo = new CustomerRepository();
            _mailCreate = new CreateMail();

            // Act & Assert
            Assert.Throws<CannotBeNullException>(() => new CustomerService(_repo, null, _mailCreate));
        }

        [Test]
        public void Should_Throw_Exception_When_No_MailCreator_Provided()
        {
            // Arrange
            _repo = new CustomerRepository();
            _mailClient = new GMailClient();

            // Act & Assert
            Assert.Throws<CannotBeNullException>(() => new CustomerService(_repo, _mailClient, null));
        }

        [Test]
        public void Should_Not_Throw_Exception()
        {
            // Arrange
            _repo = new CustomerRepository();
            _mailClient = new GMailClient();
            _mailCreate = new CreateMail();

            // Act
            var service = new CustomerService(_repo, _mailClient, _mailCreate);

            // Assert
            Assert.IsNotNull(service);
        }
    }
}
