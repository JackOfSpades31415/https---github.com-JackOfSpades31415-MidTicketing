public class Ticket
{
    public string type {get; set;}
    public UInt64 ticketID {get; set;}
    public string summary {get; set;}
    public string status {get; set;}
    public string priority {get; set;}
    public string submitter {get; set;}
    public string assigned {get; set;}
    public string watching {get; set;}


    public string Display()
    {

      return $"{ticketID}, {summary}, {status}, {priority}, {submitter}, {assigned}, {watching}";
    }

}