namespace Application.Moq.Domain.Emailing
{
    public interface IMail
    {
        string From { get; set; }
        string To { get; set; }
        string Subject { get; }
        string Body { get; }
    }
}
