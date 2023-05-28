using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlink_WAP_Project
{
    class Route
    {
        private int routeNumber;
        private string origin;
        private string destination;
        private int maxSeats;
        private int numPassengers;
        private Company[] passengers;

        //constructor
        public Route(int rn, string or, string dest, int mSeats)
        {
            maxSeats = mSeats;
            routeNumber = rn;
            origin = or;
            destination = dest;
            numPassengers = 0;
            passengers = new Company[maxSeats];
        }

        //getters
        public int getRouteNumber() { return routeNumber; }
        public string getOrigin() { return origin; }
        public string getDestination() { return destination; }
        public int getMaxSeats() { return maxSeats; }
        public int getNumPassengers() { return numPassengers; }

        public bool addPassenger(Company c)
        {
            if (numPassengers >= maxSeats) { return false; }
            passengers[numPassengers] = c;
            passengers[numPassengers].setNumBookings(1);
            numPassengers++;
            maxSeats--;
            return true;
        }

        public int findPassenger(int compId)
        {
            for (int x = 0; x < maxSeats; x++)
            {
                if (passengers[x].getId() == compId)
                    return x;
            }
            return -1;
        }

        public bool removePassenger(int compId)
        {
            int loc = findPassenger(compId);
            if (loc == -1) return false;
            passengers[loc] = passengers[numPassengers - 1];
            numPassengers--;
            maxSeats++;
            return true;
        }

        public int getAvailablSeats()
        {
            int places = getMaxSeats() - getNumPassengers();
            return places;
        }

        //print passenger list
        public string getPassengerList()
        {
            string s = "Passengers on route: ";
            for (int x = 0; x < numPassengers; x++)
            {
                s = s + " " + passengers[x].toString();
            }
            if (numPassengers == 0)
            {
                s += "There are no passengers.";
            }
            return s;
        }

        //print information about a route
        public string toString()
        {
            string s = " Route Number: " + routeNumber;
            s = s + " Origin: " + origin;
            s = s + " Destination: " + destination;
            s = s + " Number of Passengers: " + numPassengers;
            s = s + " Available seats: " + maxSeats;
            s = s + getPassengerList();
            return s;
        }
    }
}
