namespace Careview.CodeTest.Domain;

public class Client
{
    public Client(string firstName, string lastName, string emailAddress, string mobilePhoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        MobilePhoneNumber = mobilePhoneNumber;
    }
    
    public string FirstName { get; set; }
    public string? MiddleInitial { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string MobilePhoneNumber { get; set; }
}