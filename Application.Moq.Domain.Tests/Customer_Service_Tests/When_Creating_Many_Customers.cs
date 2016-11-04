using Application.Moq.Domain.Customers;
using Application.Moq.Domain.Emailing;
using Application.Moq.Domain.Repository;
using Application.Moq.Domain.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Application.Moq.Domain.Tests.Customer_Service_Tests
{
    [TestFixture]
    public class When_Creating_Many_Customers
    {
        [Test]
        public void The_Customer_Repository_Should_Be_Called_4_Times()
        {
            // Arrange
            List<ICustomer> dbcustomers = new List<ICustomer>(); // Simulates database
            List<ICustomer> customers = new List<ICustomer>() {
                new Customer(),
                new Customer(),
                new Customer(),
                new Customer()
            };

            var mockRepository = new Mock<IRepository>();
            var mailClient = new Mock<IMailClient>();
            var mailCreator = new Mock<ICreateMail>();

            mockRepository.Setup(r => r.Save(It.IsAny<ICustomer>())).Callback<ICustomer>(dbcustomers.Add); // Add to dblist instead of
            mailClient.Setup(c => c.SendMail(It.IsAny<IMail>())).Returns(true);
            CustomerService service = new CustomerService(mockRepository.Object, mailClient.Object, mailCreator.Object);

            // Act
            service.SaveMany(customers);

            // Assert
            mockRepository.Verify(r => r.Save(It.IsAny<ICustomer>()), Times.Exactly(customers.Count));
        }
    }
}
