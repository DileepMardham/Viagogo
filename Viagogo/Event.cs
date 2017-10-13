using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viagogo
{
    /* Class for Events
     * Has an ID property to track events
     * Has a list of tickets for the event 
     */
    class Event
    {
        private int id;
        private List<Ticket> tickets = new List<Ticket>();

        internal List<Ticket> Tickets { get => tickets; set => tickets = value; }
        public int Id { get => id; set => id = value; }

        // Constructor for creating Event object
        public Event(int id, List<Ticket> tickets)
        {
            this.Id = id;
            this.Tickets = tickets;
        }

        // Method to check if the event has any tickets
        public bool hasTickets()
        {
            return Tickets.Count > 0;
        }

        // Method to retrieve the cheapest ticket price for the event
        public double getCheapestTicketPrice()
        {
            var ticketWithMinValue = Tickets.OrderByDescending(t => t.Price).LastOrDefault();
            return ticketWithMinValue.Price;
        }
    }
}
