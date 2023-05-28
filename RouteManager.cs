using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlink_WAP_Project
{
    class RouteManager
    {
        private static int currentRouteNumber;
        private int maxRoutes;
        private int numRoutes;
        private Route[] routeList;

        public RouteManager(int ccn, int max)
        {
            currentRouteNumber = ccn;
            maxRoutes = max;
            numRoutes = 0;
            routeList = new Route[maxRoutes];
        }

        //add route to route list
        public bool addRoute(string origin, string destination, int maxSeats)
        {
            if (numRoutes >= maxRoutes) { return false; }
            Route r = new Route(currentRouteNumber, origin, destination, maxSeats);
            currentRouteNumber++;
            routeList[numRoutes] = r;
            numRoutes++;
            return true;
        }

        //add passenger to route
        public bool addPasseng(int rid, Company cid)
        {
            return routeList[findRoute(rid)].addPassenger(cid);
        }

        public int findRoute(int rid)
        {
            for (int x = 0; x < numRoutes; x++)
            {
                if (routeList[x].getRouteNumber() == rid)
                    return x;
            }
            return -1;
        }

        public bool routeExists(int rid)
        {
            int loc = findRoute(rid);
            if (loc == -1) { return false; }
            return true;
        }

        public Route getRoute(int rid)
        {
            int loc = findRoute(rid);
            if (loc == -1) { return null; }
            return routeList[loc];
        }

        public bool deleteRoute(int rid)
        {
            int loc = findRoute(rid);
            if (loc == -1) { return false; }
            routeList[loc] = routeList[numRoutes - 1];
            numRoutes--;
            return true;
        }

        public int getAvailableSeats(int rid)
        {
            return routeList[findRoute(rid)].getAvailablSeats();
        }

        public int getMaxRoute()
        {
            return maxRoutes;
        }

        //print information about particular route
        public string getParticularRoute(int rid)
        {
            string s = "Route:";
            s += routeList[findRoute(rid)].getRouteNumber() + ", from " + routeList[findRoute(rid)].getOrigin() + " to " + routeList[findRoute(rid)].getDestination();
            s += " " + routeList[findRoute(rid)].getPassengerList();
            return s;
        }

        //print route list one by one row (in purposes to use dataGridView in Forms)
        public string getRouteList(int rid)
        {
            string s = "id: ";
            s = s + routeList[findRoute(rid)].getRouteNumber() + ", from " + routeList[findRoute(rid)].getOrigin() + " to " + routeList[findRoute(rid)].getDestination();
            return s;
        }

        internal string getASpecificRoute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
