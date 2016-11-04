using Application.Moq.Domain.Customers;
using Application.Moq.Domain.Emailing;
using Application.Moq.Domain.Exceptions;
using Application.Moq.Domain.Repository;
using Application.Moq.Domain.Services;
using Moq;
using NUnit.Framework;

namespace Application.Moq.Domain.Tests.Emailing_Tests
{
    [Category("Email_Tests")]
    [TestFixture]
    public class When_Sending_Mail
    {
        [Test]
        public void Should_Throw_An_Error_When_Port_Not_Specified()
        {
            var customer = new Mock<ICustomer>();
            //customer.SetupProperty(c => c.Name, "lkjkj").SetupProperty(c => c.Email, "lkjkj@gmail.cpom");

            var mail = new Mock<IMail>();
            //mail.SetupProperty(m => m.To, "lkjkj@gmail.cpom").SetupProperty(m => m.From, "from me");

            var mailCreate = new Mock<ICreateMail>();
            //mailCreate.Setup(c => c.Create(customer.Object)).Returns(() => mail.Object);

            var mailClient = new Mock<IMailClient>();
            //mailClient.SetupProperty(c => c.Server, "smtp.gmail.com").SetupProperty(c => c.Port, "6589");
            //mailClient.Setup(mc => mc.SendMail(mail.Object)).Returns(true);

            var repo = new Mock<IRepository>();



            //mailClient.Setup(c => c.SendMail(mail.Object)).Throws<CannotBeNullException>();//.Verifiable();


            CustomerService service;// new CustomerService(null, mailClient.Object, mailCreate.Object);
            Assert.Throws<CannotBeNullException>(() => service = new CustomerService(null, mailClient.Object, mailCreate.Object));
            //service.Save(customer.Object);
            //Assert.Throws<CannotBeNullException>(() => service.Save(null)); //customer.Object
        }
    }
}
