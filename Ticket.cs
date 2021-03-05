using System;
using System.Collections.Generic;

namespace TicketSystemWithClasses
{
    public class Ticket 
    {
         public int ticketID { get; set; }
        public string ticketSummary { get; set; }
        public string ticketStatus { get; set; }
        public string ticketPriority { get; set; }
        public string ticketSubmitter { get; set; }
        public string ticketAssigner { get; set; }
        public List<string> ticketWatchers { get; set; }
    }
}