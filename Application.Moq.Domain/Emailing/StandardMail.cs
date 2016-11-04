using Application.Moq.Domain.Exceptions;

namespace Application.Moq.Domain.Emailing
{
    public class StandardMail : IMail
    {
        public string Body { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }

        public StandardMail(string to, string from, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(to) || string.IsNullOrWhiteSpace(from))
            {
                System.Console.WriteLine("email to or from");
                throw new CannotBeNullException("email to or from");
            }
            Body = body;
            Subject = subject;
            To = to;
            From = from;
        }
    }
}
