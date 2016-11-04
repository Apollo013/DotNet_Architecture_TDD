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
                System.Console.WriteLine("email error");
                throw new CannotBeNullException("email");
            }
            if (string.IsNullOrWhiteSpace(Port))
            {
                System.Console.WriteLine("Port error");
                throw new CannotBeNullException("Port");
            }
            if (string.IsNullOrWhiteSpace(Server))
            {
                System.Console.WriteLine("Server error");
                throw new CannotBeNullException("Server");
            }
            return true;
        }
    }
}
