namespace Careview.CodeTest.Domain;

// Assumed all clients have first names, last names, email address
// MobilePhoneNumber and AppPushToken are optional here.  
// If these don't exist the user won't get Sms or App notifications.
// Check with BA/SME as these notifications may be a critical part of the workflow.
// Perhaps Emails are the fallback.  It is assumed everyone has an email address
// and it is used for their username and account validation / 2FA.

public record Client
{
    public string FirstName { get; set; }
    public string? MiddleInitial { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string? MobilePhoneNumber { get; set; }
    public string? AppPushToken { get; set; }
}