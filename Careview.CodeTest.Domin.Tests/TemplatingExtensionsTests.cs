namespace Careview.CodeTest.Domain.Tests;

public class TemplatingExtensionTests
{
    private Client GetTestClient() =>
        new Client
        {
            FirstName = "Lewis", LastName = "Hamilton", EmailAddress = "goat@formula1.com", MobilePhoneNumber = "4444 444 444", AppPushToken = "123457890"
        };
    
    [Fact]
    public void WhenAllTemplateFieldsArePopulatedOnMergeObject_ThenTemplateIsSuccessfullyMerged()
    {
        var template = "Name: {{FirstName}} {{LastName}}, Email: {{EmailAddress}}, Mobile: {{MobilePhoneNumber}}";

        var merged = template.MergeTemplateWith(GetTestClient());

        merged.ShouldBe("Name: Lewis Hamilton, Email: goat@formula1.com, Mobile: 4444 444 444");
    }

    [Fact]
    public void WhenTemplateFieldDoesNotExistOnMergeObject_ThenTemplateFieldWillNotBeMerged()
    {

        var template = "Middle Name: {{MissingProperty}}";
        
        var merged = template.MergeTemplateWith(GetTestClient());

        merged.ShouldBe("Middle Name: {{MissingProperty}}");
    }

    [Fact]
    public void WhenMergePropertyIsNull_ThenTemplateFieldWillBeBlank()
    {
        var template = "Name: {{FirstName}} {{MiddleInitial}} {{LastName}}, Email: {{EmailAddress}}, Mobile: {{MobilePhoneNumber}}";

        var client = GetTestClient();
        client.MiddleInitial = null;
        
        var merged = template.MergeTemplateWith(GetTestClient(), removeExtraWhitespace: true);

        merged.ShouldBe("Name: Lewis Hamilton, Email: goat@formula1.com, Mobile: 4444 444 444");
    }
}