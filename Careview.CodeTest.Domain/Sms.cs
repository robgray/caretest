namespace Careview.CodeTest.Domain;

public class Sms : INotification
{
    public static Sms CreateForClient(Client client, string notificationMessage)
    {
        return new Sms
        {
            MobileNumber = client.MobilePhoneNumber ?? throw new ValidationException("Client does not have a mobile phone number.  Cannot send an Sms"),
            Body = notificationMessage
        };
    }

    protected Sms()
    {
    } 

    public const int MaximumBodyLength = 240;
    
    public string MobileNumber { get; init; }
    
    private string? _body; 
    public string? Body
    {
        get => _body;
        set
        {
            if (value is { Length: > MaximumBodyLength })
                throw new ValidationException($"Message too large. Maximum length is {MaximumBodyLength} characters");

            _body = value;
        }
    }
}