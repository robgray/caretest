using Careview.CodeTest.Domain.Exceptions;

namespace Careview.CodeTest.Domain.Tests;

public class EmailTests
{
    [Fact]
    public void AddTo_WhenAddingClientWithExistingEmail_ClientIsNotAdded()
    {
        var client = new Client
        {
            FirstName = "First", LastName = "Client", EmailAddress = "first@client.com"
        };
        var email = new Email(client, CreateAdminClient(), "This is a test");

        var clientWithSameEmailAddress = new Client
        {
            FirstName = "First Son", LastName = "Client", EmailAddress = "first@client.com"
        };
        
        email.AddTo(clientWithSameEmailAddress);

        client.EmailAddress.ShouldBe(clientWithSameEmailAddress.EmailAddress);
        email.To.Count(x => x.EmailAddress == client.EmailAddress).ShouldBe(1);
    }
    
    [Fact]
    public void RemoveTo_WhenOnlyOneClient_ClientCannotBeRemoved()
    {
        var client = new Client
        {
            FirstName = "First", LastName = "Client", EmailAddress = "first@client.com"
        };
        var email = new Email(client, CreateAdminClient(), "This is a test");

        Should.Throw<BusinessRuleException>(() =>
        {
            email.RemoveTo(client);
        }).Message.ShouldBe("Cannot remove To Client. Email must always have at least one To recipient");
    }

    [Fact]
    public void RemoveTo_WhenTwoClients_AClientCanBeRemoved()
    {
        var client = new Client
        {
            FirstName = "First", LastName = "Client", EmailAddress = "first@client.com"
        };
        var client2 = new Client
        {
            FirstName = "Second", LastName = "Client", EmailAddress = "second@client.com"
        };
        var email = new Email(client, CreateAdminClient(), "This is a test");
        email.AddTo(client2);
        
        email.RemoveTo(client);

        email.To.All(to => to == client2).ShouldBeTrue();
    }
    
    [Fact]
    public void AddCarbonCopy_WhenAddingClientWithExistingEmail_ClientIsNotAdded()
    {
        var client = new Client
        {
            FirstName = "First", LastName = "Client", EmailAddress = "first@client.com"
        };
        var email = new Email(client, CreateAdminClient(), "This is a test");

        var clientWithSameEmailAddress = new Client
        {
            FirstName = "First Son", LastName = "Client", EmailAddress = "first@client.com"
        };
        
        email.AddCarbonCopy(clientWithSameEmailAddress);

        client.EmailAddress.ShouldBe(clientWithSameEmailAddress.EmailAddress);
        email.CarbonCopies.Count(cc => cc.EmailAddress == client.EmailAddress).ShouldBe(1);
    }
    
    [Fact]
    public void RemoveCarbonCopy_WhenOnlyOneClient_ClientCannotBeRemoved()
    {
        var client = new Client
        {
            FirstName = "First", LastName = "Client", EmailAddress = "first@client.com"
        };
        var adminClient = CreateAdminClient();
        var email = new Email(client, adminClient, "This is a test");

        Should.Throw<BusinessRuleException>(() =>
        {
            email.RemoveCarbonCopy(adminClient);
        }).Message.ShouldBe("Cannot remove carbon copy Client. Email must always have at least one Carbon Copy recipient");
    }

    [Fact]
    public void RemoveCarbonCopy_WhenTwoClients_AClientCanBeRemoved()
    {
        var client = new Client
        {
            FirstName = "First", LastName = "Client", EmailAddress = "first@client.com"
        };
        var client2 = new Client
        {
            FirstName = "Second", LastName = "Client", EmailAddress = "second@client.com"
        };
        var admin = CreateAdminClient();
        var email = new Email(client, admin, "This is a test");
        email.AddCarbonCopy(client2);
        
        email.RemoveCarbonCopy(admin);

        email.CarbonCopies.All(cc => cc == client2).ShouldBeTrue();
    }

    [Fact]
    public void Body_WhenThereAreMultipleToClients_OnlyTheFirstToClientIsAppliedToTemplate()
    {
        var client = new Client
        {
            FirstName = "First", LastName = "Client", EmailAddress = "first@client.com"
        };
        var client2 = new Client
        {
            FirstName = "Second", LastName = "Client", EmailAddress = "second@client.com"
        };
        var admin = CreateAdminClient();
        
        var email = new Email(client, admin, "This is a test. {{FirstName}} with email of {{EmailAddress}}");
        email.AddTo(client2);
        
        email.Body.ShouldBe("This is a test. First with email of first@client.com");
    }

    private Client CreateAdminClient() =>
        new Client
        {
            FirstName = "Careview",
            LastName = "Admin",
            EmailAddress = "admin@careview.com",
            MobilePhoneNumber = "0000 000 000",
            AppPushToken = "123457890"
        };
}