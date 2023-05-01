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
        public void AddBug(BugDefect bugdef){
            try{
            StreamWriter sw = new StreamWriter(filePath, true);
            bugdef.ticketID = Tickets.Max(t => t.ticketID) + 1;
            sw.WriteLine($"{bugdef.ticketID},{bugdef.summary},{bugdef.status},{bugdef.submitter},{bugdef.assigned},{bugdef.watching},{bugdef.severity}");
            sw.Close();
            Tickets.Add(bugdef);
            logger.Info("Ticket #{Id} added", bugdef.ticketID);
            }
            catch(Exception e){
                logger.Error(e.Message);
            }
            
        }
        public void AddEnhance(Enhancement enhance){
            try{
            StreamWriter sw = new StreamWriter(filePath, true);
            enhance.ticketID = Tickets.Max(t => t.ticketID) + 1;
            sw.WriteLine($"{enhance.ticketID},{enhance.summary},{enhance.status},{enhance.submitter},{enhance.assigned},{enhance.watching},{enhance.software},{enhance.cost},{enhance.reason},{enhance.estimate}");
            sw.Close();
            Tickets.Add(enhance);
            logger.Info("Ticket #{Id} added", enhance.ticketID);
            }
            catch(Exception e){
                logger.Error(e.Message);
            }
            
        }
        public void AddTask(Task task){
            try{
            StreamWriter sw = new StreamWriter(filePath, true);
            task.ticketID = Tickets.Max(t => t.ticketID) + 1;
            sw.WriteLine($"{task.ticketID},{task.summary},{task.status},{task.submitter},{task.assigned},{task.watching}");
            sw.Close();
            Tickets.Add(task);
            logger.Info("Ticket #{Id} added", task.ticketID);
            }
            catch(Exception e){
                logger.Error(e.Message);
            }
            
        }


}