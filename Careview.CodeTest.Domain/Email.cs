using Careview.CodeTest.Domain.Exceptions;

namespace Careview.CodeTest.Domain;

// Email must be sent to at least one Client. (As opposed to the described "could be sent to one or more Clients")
// Email must be CC'd to at least one Client. (As opposed to the described "could be cc'd to one or more Clients.")

// I'd amend this second requirement to not require a CC'd client, as typically many emails don't require Carbon Copies.
// I'd assume that if there is a requirement to CC every email to some email address, then that would be a separate 
// requirement, and something I'd clarify with BA's / SME's.  Possibly request a new requirement be added to 
// include the compulsory cc email address.

// Template emails may not make any sense when there are multiple To recipients.  I'd clarify this behaviour
// Possibly the desired action is, when a template is used, send  a new separate email to each To.
// In that case I would need to clarify how the CC emails are to be treated.

public class Email : INotification
{
    private string _body;
    public Email(Client toClient, Client ccClient, string bodyTemplate)
    {
        _to.Add(toClient);
        _carbonCopies.Add(ccClient);
        _body = bodyTemplate;
    }
    
    private readonly ICollection<Client> _to = new List<Client>();
    private readonly ICollection<Client> _carbonCopies = new List<Client>();

    public IEnumerable<Client> To => _to;
    public IEnumerable<Client> CarbonCopies => _carbonCopies;

    public void AddTo(Client client)
    {
        if (_to.Any(to => to.EmailAddress == client.EmailAddress))
        {
            // Do not add client if client with same email already exists.
            // We'll make the assumption that no two clients have the same Email Address.
            // Although in reality sometimes couples might share an email address, or a child
            // may use their parents email address.
            return;
        }
        
        _to.Add(client);
    }

    public void RemoveTo(Client client)
    {
        if (_to.Count == 1)
        {
            throw new BusinessRuleException("Cannot remove To Client. Email must always have at least one To recipient");
        }
        _to.Remove(client);
    }
    
    public void AddCarbonCopy(Client client)
    {
        if (_carbonCopies.Any(to => to.EmailAddress == client.EmailAddress))
        {
            // Do not add client if client with same email already exists.
            // We'll make the assumption that no two clients have the same Email Address.
            // Although in reality sometimes couples might share an email address, or a child
            // may use their parents email address.
            return;
        }
        
        _carbonCopies.Add(client);
    }

    public void RemoveCarbonCopy(Client client)
    {
        if (_carbonCopies.Count == 1)
        {
            throw new BusinessRuleException("Cannot remove carbon copy Client. Email must always have at least one Carbon Copy recipient");
        }
        _carbonCopies.Remove(client);
    }

    public string Body
    {
        get => _body.MergeTemplateWith(_to.First());
        set => _body = value;
    }
}