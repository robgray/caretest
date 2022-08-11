namespace Careview.CodeTest.Domain;

public class Email : INotification
{
    private string _body;
    public Email(string bodyTemplate)
    {
        _body = bodyTemplate;
    }
    
    public ICollection<Client> To = new List<Client>();
    public ICollection<Client> CarbonCopies = new List<Client>();

    public string Body
    {
        get => _body.MergeTemplateWith(To.First());
        set => _body = value;
    }
}