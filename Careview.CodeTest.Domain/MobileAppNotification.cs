namespace Careview.CodeTest.Domain;

public class MobileAppNotification : INotification, IPreviewable
{
    public MobileAppNotification(string body)
    {
        Body = body;
    }
    
    public string Body { get; set; }

    public string? Preview { get; set; }
}