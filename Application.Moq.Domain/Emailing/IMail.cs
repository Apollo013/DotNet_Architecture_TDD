namespace Application.Moq.Domain.Emailing
{
    public interface IMail
    {
        string From { get; }
        string To { get; }
        string Subject { get; }
        string Body { get; }
    }
}
