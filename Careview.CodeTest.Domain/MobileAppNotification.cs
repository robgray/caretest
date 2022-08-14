namespace Careview.CodeTest.Domain;

// I've interpreted Previews for mobile app notifications as optional, rather than them being mandatory 
// and optionally shown in the mobile apps.  I'd clarify this interpretation with BA's / SME's

public class MobileAppNotification : INotification, IPreviewable
{
    private Client _client;
    
    public MobileAppNotification(Client client, string body)
    {
        _client = client;
        Body = body;
    }
    
    public string Body { get; set; }

    public string? Preview { get; set; }
}