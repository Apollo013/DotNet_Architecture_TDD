using Application.Moq.Domain.Exceptions;

namespace Application.Moq.Domain.Emailing
{
    public class GMailClient : IMailClient
    {
        public string Port { get; set; }

        public string Server { get; set; }

        public bool SendMail(IMail email)
        {
            if (email == null)
            {
                throw new CannotBeNullException("email");
            }
            return true;
        }
    }
}
