using Application.Moq.Domain.Exceptions;

namespace Application.Moq.Domain.Emailing
{
    public class StandardMail : IMail
    {
        public string Body { get; private set; }
        public string From { get; private set; }
        public string Subject { get; private set; }
        public string To { get; private set; }

        public StandardMail(string to, string from, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(to) || string.IsNullOrWhiteSpace(from))
            {
                throw new CannotBeNullException("email to or from");
            }
            Body = body;
            Subject = subject;
            To = to;
            From = from;
        }
    }
}
