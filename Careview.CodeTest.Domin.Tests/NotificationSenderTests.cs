using Careview.CodeTest.Domain.Exceptions;

namespace Careview.CodeTest.Domain.Tests;

public class NotificationSenderTests
{
    // These tests ensure the notification types hit the correct branch.
    // Once the sending services are selected, these tests can be modified
    // to test the appropriate service is being called. 

    private NotificationSender _sender = new NotificationSender();
    
    [Fact]
    public void Send_CanSendEmail()
    {
        var email = new Email(
            toClient: new Client { FirstName = "First", LastName = "Name", EmailAddress = "test@user.com" },
            ccClient: new Client { FirstName = "Careview", LastName = "Administrator", EmailAddress = "admin@careview.com" },
            bodyTemplate: "Welcome to the tests"
        );
        
        Should.Throw<NotImplementedException>(() =>
        {
            _sender.Send(email);
        }).Message.ShouldBe("Email Sending not implemented");
    }
    
    [Fact]
    public void Send_CanSendSms()
    {
        var sms = Sms.CreateForClient(
            client: new Client { FirstName = "First", LastName = "Name", EmailAddress = "test@user.com", MobilePhoneNumber = "0400 000 000" },
            notificationMessage: "This is a test sms"
        );
        
        Should.Throw<NotImplementedException>(() =>
        {
            _sender.Send(sms);
        }).Message.ShouldBe("SMS sending not implemented");
    }

    [Fact]
    public void Send_CanSendMobileApp()
    {
        var appNotification = new MobileAppNotification(
            client: new Client { FirstName = "First", LastName = "Name", EmailAddress = "test@user.com", AppPushToken = "123457890" },
            body: "Test notification")
        {
            Preview = "Test!"
        };
        
        Should.Throw<NotImplementedException>(() =>
        {
            _sender.Send(appNotification);
        }).Message.ShouldBe("App notification sending not implemented");
    }

    [Fact]
    public void Send_UnknownNotification_ThrowsError()
    {
        var unknownNotification = new SomeNotification() { Body = "This is an unkown/unhandled notification type" };
        
        Should.Throw<ArgumentException>(() =>
        {
            _sender.Send(unknownNotification);
        }).Message.ShouldBe($"Unknown notification type.  Cannot handle {unknownNotification.GetType().FullName}");
    }

    [Fact]
    public void MobileAppNotification_CreateWithClientWithNoPushToken_ThrowsValidationError()
    {
        Should.Throw<ValidationException>(() =>
        {
            var appNotification = new MobileAppNotification(
                client: new Client { FirstName = "First", LastName = "Name", EmailAddress = "test@user.com", MobilePhoneNumber = "0400 000 000" },
                body: "Test notification")
            {
                Preview = "Test!"
            };
        });
    }

    private class SomeNotification : INotification
    {
        public string Body { get; set; }
    }
}