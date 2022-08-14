namespace Careview.CodeTest.Domain;

public class NotificationSender
{
    // We could add a wrapper around the various sending services (eg. Send Grid) but I don't see much point in that.
    // Instead I'd inject the services provided by those API's and consume in the appropriate branch below
    // Extensibility of notification types would involve adding a new type and implementing the sending logic below.
    
    // Not shown here but I'd also add logging.
    
    public void Send<T>(T notification)
        where T : INotification
    {
        if (notification is Email emailNotification)
        {
            throw new NotImplementedException("Email Sending not implemented");
        } 
        
        if (notification is Sms smsNotification)
        {
            throw new NotImplementedException("SMS sending not implemented");
        }
        
        if (notification is MobileAppNotification mobileAppNotification)
        {
            throw new NotImplementedException("App notification sending not implemented");
        }
        
        throw new ArgumentException($"Unknown notification type.  Cannot handle {notification.GetType().FullName}");
    }
}