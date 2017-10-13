using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viagogo
{
    /*
     * Class for location
     * Has properties for ID, X and Y coordinates
     * Every location can have a list of one or more events
     */ 
    class Location
    {
        private long id;
        private int positionX;
        private int positionY;
        List<Event> events = new List<Event>();

        public int PositionX { get => positionX; set => positionX = value; }
        public int PositionY { get => positionY; set => positionY = value; }
        internal List<Event> Events { get => events; set => events = value; }
        public long Id { get => id; set => id = value; }

        // Constructor for creating Location object
        public Location(long id, int posX, int posY, List<Event> events)
        {
            this.Id = id;
            this.PositionX = posX;
            this.PositionY = posY;
            this.Events = events;
        }
        
        // Overloaded constructor for creating Location object with just X and Y coordinates  
        public Location(int posX, int posY)
        {
            this.PositionX = posX;
            this.PositionY = posY;
        }

        // Method to calculate distance between the current location object and passed X and Y coordinates
        public int calculateDistace(int x, int y)
        {
            return Math.Abs(x - this.PositionX) + Math.Abs(y - this.PositionY);
        }

        // Overloaded Method to calculate distance between the current location object and passed passed location object
        public int calculateDistace(Location l)
        {
            return Math.Abs(l.PositionX - this.PositionX) + Math.Abs(l.PositionY - this.PositionY);
        }
    }
}
