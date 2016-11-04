using Application.Moq.Domain.Customers;
using Application.Moq.Domain.Emailing;
using Application.Moq.Domain.Repository;
using Application.Moq.Domain.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Application.Moq.Domain.Tests.Customer_Service_Tests
{
    [Category("Customer.Service.Tests")]
    [TestFixture]
    public class When_Creating_A_Single_Customer
    {
        [Test]
        public void The_Customer_Repository_Should_Only_Be_Called_Once()
        {
            // Arrange
            List<ICustomer> customers = new List<ICustomer>();

            var mockCustomer = new Mock<ICustomer>();
            var mockRepository = new Mock<IRepository>();
            var mailClient = new Mock<IMailClient>();
            var mailCreator = new Mock<ICreateMail>();

            mockCustomer.Setup(c => c.Email).Returns("test@gmail.com");
            mockCustomer.Setup(c => c.Name).Returns("Jimmy");
            mockRepository.Setup(r => r.Save(It.IsAny<ICustomer>())).Callback<ICustomer>(customers.Add); // Add to list instead of
            mailClient.Setup(c => c.SendMail(It.IsAny<IMail>())).Returns(true);

            CustomerService service = new CustomerService(mockRepository.Object, mailClient.Object, mailCreator.Object);

            // Act
            service.Save(mockCustomer.Object);

            // Assert
            mockRepository.Verify(r => r.Save(It.IsAny<ICustomer>()), Times.Exactly(1));
        }

        [Test]
        public void The_Customer_Database_Table_Should_Have_One_More_Customer()
        {
            // Arrange
            List<ICustomer> dbcustomers = new List<ICustomer>(); // Simulates database
            List<ICustomer> customers = new List<ICustomer>();

            var mockCustomer = new Mock<ICustomer>();
            var mockRepository = new Mock<IRepository>();
            var mailClient = new Mock<IMailClient>();
            var mailCreator = new Mock<ICreateMail>();

            mockCustomer.Setup(c => c.Email).Returns("test@gmail.com");
            mockCustomer.Setup(c => c.Name).Returns("Jimmy");
            mockRepository.Setup(r => r.Save(It.IsAny<ICustomer>())).Callback<ICustomer>(dbcustomers.Add); // Add to list instead of
            mailClient.Setup(c => c.SendMail(It.IsAny<IMail>())).Returns(true);

            CustomerService service = new CustomerService(mockRepository.Object, mailClient.Object, mailCreator.Object);

            // Act
            service.Save(mockCustomer.Object);

            // Assert
            Assert.AreEqual(1, dbcustomers.Count);
        }
    }
}
