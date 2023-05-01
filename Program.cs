
using NLog;

string path = Directory.GetCurrentDirectory() + "\\nlog.config";

var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();

string ticketFilePath = Directory.GetCurrentDirectory() + "\\Ticket.csv";
string prompt = "";
logger.Info("Program on");
ticketFile ticketFile = new ticketFile(ticketFilePath);
do{
Console.WriteLine("[1] Display ticket list and information");
Console.WriteLine("[2] Create new ticket.");
Console.WriteLine("Enter other keys to exit.");

prompt = Console.ReadLine();

if (prompt == "1"){

    Console.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");
     foreach(Ticket t in ticketFile.Tickets)
    {
      Console.WriteLine(t.Display());
    }
  }


else if (prompt == "2"){

    Ticket ticket = new Ticket();
    Console.WriteLine("Summary?");
    ticket.summary = Console.ReadLine();
    Console.WriteLine("Current Status?");
    ticket.status = Console.ReadLine();
    Console.WriteLine("What's the Priority?");
    ticket.priority = Console.ReadLine();
    Console.WriteLine("Who is the Submitter?");
    ticket.submitter = Console.ReadLine();
    Console.WriteLine("Who is Assigned?");
    ticket.assigned = Console.ReadLine();
    Console.WriteLine("Who is watching?");
    ticket.watching = Console.ReadLine();
    ticketFile.AddTicket(ticket);

 }
}while(prompt == "1" || prompt == "2");
 logger.Info("Program over.");
 

    


