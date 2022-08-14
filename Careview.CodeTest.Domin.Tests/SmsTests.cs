using Careview.CodeTest.Domain.Exceptions;

namespace Careview.CodeTest.Domain.Tests;

public class SmsTests
{
    [Fact]
    public void Body_ThrowsValidationException_WhenMaximimSizeExceeded()
    {
        Should.Throw<ValidationException>(() =>
        {
            var tooLargeBody = new string('X', Sms.MaximumBodyLength + 1);
            Sms.CreateForClient(new Client { FirstName = "Test", LastName = "User", EmailAddress = "test@user.com", MobilePhoneNumber = "0400 000 000"}, tooLargeBody);
        }).Message.ShouldBe($"Message too large. Maximum length is {Sms.MaximumBodyLength} characters");
    }

    [Fact]
    public void Body_ShouldNotThrowException_WhenSizeIsWithinRange()
    {
        Should.NotThrow(() =>
        {
            var okBody = new string('X', Sms.MaximumBodyLength);
            Sms.CreateForClient(new Client { FirstName = "Test", LastName = "User", EmailAddress = "test@user.com", MobilePhoneNumber = "0400 000 000"}, okBody);
        });
    }

    [Fact]
    public void Sms_CreateWithClientWithNoMobilePhone_ThrowsException()
    {
        Should.Throw<ValidationException>(() =>
        {
            Sms.CreateForClient(new Client { FirstName = "Test", LastName = "User", EmailAddress = "test@user.com" }, "Test Message");
        });
    }
}