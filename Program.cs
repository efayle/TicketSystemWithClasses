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
            logger.Info("Program started");

            string choice;

            do {
                Console.WriteLine("1.) Display tickets\n2.) Create tickets\n3.) Exit");
                choice = Console.ReadLine();

            } while (choice == "1" || choice == "2");

            logger.Info("Program ended");
        }
    }
}
