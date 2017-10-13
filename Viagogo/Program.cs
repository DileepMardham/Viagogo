using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Viagogo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a map using random seed data
            WorldMap.generateMap();
            // Get configuration from app.config file
            int numClosestLocations = Convert.ToInt32(ConfigurationManager.AppSettings["numClosestLocations"]);
            int minRangeX = Convert.ToInt32(ConfigurationManager.AppSettings["minRangeX"]);
            int minRangeY = Convert.ToInt32(ConfigurationManager.AppSettings["minRangeY"]);
            int maxRangeX = Convert.ToInt32(ConfigurationManager.AppSettings["maxRangeX"]);
            int maxRangeY = Convert.ToInt32(ConfigurationManager.AppSettings["maxRangeY"]);
            char ans;
            do
            {
                // Promt for input
                Console.WriteLine("Please Input Coordinates:");
                string coordinates = Console.ReadLine();
                //Validate input and reprompt if necessary
                Regex r = new Regex(@"(\d+,?)+");
                Match m = r.Match(coordinates);
                while (coordinates.Split(',').Length != 2 || !m.Success)
                {
                    Console.WriteLine("Wrong input format! Please enter again:");
                    coordinates = Console.ReadLine();
                    m = r.Match(coordinates);
                }
                //Split the input to retrieve x and y coordinates
                int X = Convert.ToInt32(coordinates.Split(',')[0]);
                int Y = Convert.ToInt32(coordinates.Split(',')[1]);
                // Show an error message if the coordinates are out of range
                if (X > maxRangeX || X < minRangeX || Y > maxRangeY || Y < minRangeY)
                {
                    Console.WriteLine("Input out of range! Please try again");
                }
                else
                {
                    // Get the closest events to the entered location
                    var closestEvents = WorldMap.Map.Where(Loc => (Loc.Events != null))
                                            .OrderBy(Loc => Loc.calculateDistace(new Location(X, Y)))
                                            .Take(numClosestLocations);

                    // Display the retrieved details for the closest events
                    Console.WriteLine("\nEvents you can attend in " + numClosestLocations + " closest locations to ({0}):", coordinates);
                    int i = 0;
                    foreach (var loc in closestEvents)
                    {
                        foreach (var eve in loc.Events)
                        {
                            double minTicketPrice = eve.getCheapestTicketPrice();
                            Console.WriteLine("\n\t" + (i + 1) + ". Event {0}  at ({1}, {2}) with minimum ticket price of ${3}, Distance {4}", eve.Id.ToString("D3"), loc.PositionX, loc.PositionY, Math.Round(minTicketPrice, 2), loc.calculateDistace(X, Y));
                            i++;
                        }
                    }
                }
                Console.WriteLine();
                Console.Write("Do You want to search again (Y/N): ");
                ans = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (ans == 'Y' || ans == 'y');
            Console.ReadLine();
        }
    }
}
