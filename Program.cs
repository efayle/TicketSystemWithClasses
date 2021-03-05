using System;
using NLog.Web;
using System.IO;

namespace TicketSystemWithClasses
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string ticketFilePath = Directory.GetCurrentDirectory() + "\\Tickets.csv";
            logger.Info("Program started");

            TicketFile ticketFile = new TicketFile(ticketFilePath);
            
            string choice;

            do {
                Console.WriteLine("1.) Display tickets\n2.) Create tickets\n3.) Exit");
                choice = Console.ReadLine();

            } while (choice == "1" || choice == "2");

            logger.Info("Program ended");
        }
    }
}
