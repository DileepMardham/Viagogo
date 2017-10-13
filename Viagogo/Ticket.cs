using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viagogo
{
    /* Class for Tickets
    * Has ID and Price properties
    */
    class Ticket
    {
        private int id;
        private double price;
        public double Price { get => price; set => price = value; }
        public int Id { get => id; set => id = value; }

        // Constructor for creating Ticket object
        public Ticket(int id, double price)
        {
            this.Id = id;
            this.price = price;
        }
    }
}
