namespace Careview.CodeTest.Domain;

// Assumed all clients have first names, last names, email address, and mobile phone numbers. 

public record Client
{
    public string FirstName { get; set; }
    public string? MiddleInitial { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string MobilePhoneNumber { get; set; }
}