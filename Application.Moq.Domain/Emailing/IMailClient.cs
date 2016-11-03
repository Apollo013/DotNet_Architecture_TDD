namespace Application.Moq.Domain.Emailing
{
    public interface IMailClient
    {
        string Server { get; set; }
        string Port { get; set; }

        bool SendMail(IMail email);
    }
}
