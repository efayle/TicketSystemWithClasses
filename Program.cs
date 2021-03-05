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
                if (choice == "1") {
                    foreach(Ticket t in ticketFile.Tickets)
                    {
                        Console.WriteLine(t.Display());
                    }
                } else if (choice == "2") {
                    Ticket ticket = new Ticket();
                    
                    for (int i = 0; i < 10; i++) {
                        
                        Console.WriteLine("Do you want to create a ticket? (y or n) ");
                        string response = Console.ReadLine().ToUpper();
                        if (response != "Y"){
                            break;
                        }

                        Console.WriteLine("Enter ticket ID");
                        ticket.ticketID = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter ticket summary");
                        ticket.ticketSummary = Console.ReadLine();

                        Console.WriteLine("Enter ticket status");
                        ticket.ticketStatus = Console.ReadLine();

                        Console.WriteLine("Enter ticket priority");
                        ticket.ticketPriority = Console.ReadLine();
                        
                        Console.WriteLine("Enter ticket submitter");
                        ticket.ticketSubmitter = Console.ReadLine();

                        Console.WriteLine("Enter who is assigned for this ticket");
                        ticket.ticketAssigner = Console.ReadLine();

                        
                        int totalTicketWatched = 0;
                        Console.WriteLine("How many people are watching this ticket");
                        totalTicketWatched = Convert.ToInt32(Console.ReadLine());
                        if (totalTicketWatched != 0) {
                            for (int j = 0; j < totalTicketWatched; j++) {
                                Console.WriteLine("Who is watching this ticket");
                                ticket.ticketWatchers.Add(Console.ReadLine());
                            }
                       }
                    }

                    ticketFile.AddTicket(ticket);
                }

            } while (choice == "1" || choice == "2");

            logger.Info("Program ended");
        }
    }
}
