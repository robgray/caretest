using Careview.CodeTest.Domain.Exceptions;

namespace Careview.CodeTest.Domain;

public class Sms : INotification
{
    private Client _client;
    
    public static Sms CreateForClient(Client client, string notificationMessage)
    {
        _ = client.MobilePhoneNumber ?? throw new ValidationException("Client must hav a valid mobile phone number");
        
        return new Sms(client)
        {
            Body = notificationMessage
        };
    }

    protected Sms(Client client)
    {
        _client = client;
    } 

    public const int MaximumBodyLength = 240;

    public string MobileNumber => _client.MobilePhoneNumber;
    
    private string _body; 
    public string Body
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