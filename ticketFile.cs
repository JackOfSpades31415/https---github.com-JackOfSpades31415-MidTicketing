using NLog;
public class ticketFile {

    public string filePath { get; set;}
    public List<Ticket> Tickets {get; set;}
    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

    public ticketFile(string ticketFilePath){
        filePath = ticketFilePath;


        Tickets = new List<Ticket>();
        try{
        StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                Ticket ticket = new Ticket();
                string line = sr.ReadLine();
                    string[] ticketInfo = line.Split(',');
                    ticket.ticketID = UInt64.Parse(ticketInfo[0]);
                    ticket.summary = ticketInfo[1];
                    ticket.status = ticketInfo[2];
                    ticket.priority = ticketInfo[3];
                    ticket.submitter = ticketInfo[4];
                    ticket.assigned = ticketInfo[5];
                    ticket.watching = ticketInfo[6];
                    Tickets.Add(ticket);
            }
            sr.Close();

            logger.Info("Tickets in file: {Count}", Tickets.Count);
        }
        catch (Exception e){
            logger.Error(e.Message);
        }
            
    }
        public void AddTicket(Ticket ticket){
            try{
            StreamWriter sw = new StreamWriter(filePath, true);
            ticket.ticketID = Tickets.Max(t => t.ticketID) + 1;
            sw.WriteLine($"{ticket.ticketID},{ticket.summary},{ticket.status},{ticket.submitter},{ticket.assigned},{ticket.watching}");
            sw.Close();
            Tickets.Add(ticket);
            logger.Info("Ticket #{Id} added", ticket.ticketID);
            }
            catch(Exception e){
                logger.Error(e.Message);
            }
            
        }


}