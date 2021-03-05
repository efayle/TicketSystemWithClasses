using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketSystemWithClasses
{
    public class TicketFile
    {
        public string filePath { get; set; }
        public List<Ticket> Tickets { get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TicketFile (string ticketFilePath)
        {
            filePath = ticketFilePath;
            Tickets = new List<Ticket>();

            try 
            {
                StreamReader sr = new StreamReader(filePath);
                    while (!sr.EndOfStream) {
                        string line = sr.ReadLine();
                        string[] array = line.Split(',');
                        // create ticket from line of data
                        Ticket ticket = new Ticket();
                        ticket.ticketID = Convert.ToInt32(array[0]);
                        ticket.ticketSummary = array[1];
                        ticket.ticketStatus = array[2];
                        ticket.ticketPriority = array[3];
                        ticket.ticketSubmitter = array[4];
                        ticket.ticketAssigner = array[5];
                        ticket.ticketWatchers = array[6].Split('|').ToList();
                        // save ticket to List
                        Tickets.Add(ticket);
                    }
                    sr.Close();  
            }
            catch (Exception ex) 
            {
                logger.Error(ex.Message);
            }
        
        }

        public void AddTicket(Ticket ticket)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, append: true);
                sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticket.ticketID, ticket.ticketSummary, ticket.ticketStatus, ticket.ticketPriority, ticket.ticketSubmitter, ticket.ticketAssigner, string.Join("|", ticket.ticketWatchers));
                sw.Close();

                Tickets.Add(ticket);
            }
            catch (Exception ex) 
            {
                logger.Error(ex.Message);
            }
        }
    }
}