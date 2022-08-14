using Careview.CodeTest.Domain.Exceptions;

namespace Careview.CodeTest.Domain;

// I've interpreted Previews for mobile app notifications as optional, rather than them being mandatory 
// and optionally shown in the mobile apps.  I'd clarify this interpretation with BA's / SME's

public class MobileAppNotification : INotification, IPreviewable
{
    private readonly Client _client;
    
    public MobileAppNotification(Client client, string body)
    {
        _ = client.AppPushToken ?? throw new ValidationException("Client does not have a valid push token");
        
        _client = client;
        Body = body;
    }

    public string PushToken => _client.AppPushToken;
    
    public string Body { get; set; }

    public string? Preview { get; set; }
}