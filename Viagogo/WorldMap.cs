using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Viagogo
{
    /* Class for the world
     * Has a map property which is a list of Location 
     */
    class WorldMap
    {
        private static List<Location> map = new List<Location>();

        public static List<Location> Map { get => map; set => map = value; }
        

        // This is a static method which will be called to generate the world with random seed data
        public static void generateMap()
        {
            // create an object for the random number generator
            Random rand = new Random();

            //read all the configuration values from the App.Config
            int minRangeX = Convert.ToInt32(ConfigurationManager.AppSettings["minRangeX"]);
            int minRangeY = Convert.ToInt32(ConfigurationManager.AppSettings["minRangeY"]);
            int maxRangeX = Convert.ToInt32(ConfigurationManager.AppSettings["maxRangeX"]);
            int maxRangeY = Convert.ToInt32(ConfigurationManager.AppSettings["maxRangeY"]);
            int minNumEvents = Convert.ToInt32(ConfigurationManager.AppSettings["minNumEvents"]);
            int maxNumEvents = Convert.ToInt32(ConfigurationManager.AppSettings["maxNumEvents"]);
            int minTicketPrice = Convert.ToInt32(ConfigurationManager.AppSettings["minTicketPrice"]);
            int maxTicketPrice = Convert.ToInt32(ConfigurationManager.AppSettings["maxTicketPrice"]);
            int minNumTickets = Convert.ToInt32(ConfigurationManager.AppSettings["minNumTickets"]);
            int maxNumTickets = Convert.ToInt32(ConfigurationManager.AppSettings["maxNumTickets"]);
            int numLocations = (maxRangeX - minRangeX + 1) * (maxRangeY - minRangeY + 1);

            // Generate world based on the configuration values and random data
            for (int i = 0; i < numLocations; i++)
            {
                int Lid = i + 1;
                int numEvents = rand.Next(minNumEvents, maxNumEvents+1);
                List<Event> events = new List<Event>();
                int positionX = minRangeX + i % ((maxRangeX - minRangeX + 1));
                int positionY = minRangeY + i / ((maxRangeY - minRangeY + 1));

                if (numEvents > 0)
                {
                    for (int j = 0; j < numEvents; j++)
                    {
                        long Eid = Convert.ToInt64(Lid.ToString("D3") + (j + 1).ToString("D3"));
                        int numTickets = rand.Next(minNumTickets, maxNumTickets + 1);
                        List<Ticket> tickets = new List<Ticket>();
                        for (int k = 0; k < numTickets; k++)
                        {
                            int Tid = k + 1;
                            double price = rand.NextDouble() + rand.Next(minTicketPrice, maxTicketPrice + 1);
                            tickets.Add(new Ticket(Tid, price));
                        }
                        events.Add(new Event(Eid, tickets));
                    }
                    
                }
                else
                    events = null;
                Map.Add(new Location(Lid, positionX, positionY, events));
            }
        }
    }
}
