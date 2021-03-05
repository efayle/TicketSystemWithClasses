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

        public TicketFile (string ticketFilePath)
        {
            filePath = ticketFilePath;
        }
    }
}