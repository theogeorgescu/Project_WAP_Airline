using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlink_WAP_Project
{
    public class AirlinkCoordinator
    {
        RouteManager rManager;
        CompanyManager compManager;
        BookingManager bkManager;

        public AirlinkCoordinator(int cIdSeed, int rIdSeed, int bkId, int maxComp, int maxRoute, int maxBooking)
        {
            rManager = new RouteManager(cIdSeed, maxRoute);
            compManager = new CompanyManager(cIdSeed, maxComp);
            bkManager = new BookingManager(bkId, maxBooking);
        }
        public bool addRoute(string origin, string destination, int maxSeats)
        {
            return rManager.addRoute(origin, destination, maxSeats);
        }

        public bool addCompany(string name, string location, string phone)
        {
            return compManager.addCompany(name, location, phone);
        }

        public bool addBooking(int rid, int cid)
        {
            return bkManager.addBooking(rManager.getRoute(rid), compManager.getCompany(cid));
        }

        public bool addPassenger(int rid, int cid)
        {
            return rManager.addPasseng(rid, compManager.getCompany(cid));
        }

        public string routeList(int id)
        {
            return rManager.getRouteList(id);
        }

        public string companyList(int id)
        {
            return compManager.getCompanyList(id);
        }

        public string bookingList(int id)
        {
            return bkManager.getBookingList(id);
        }

        public bool deleteCompany(int id)
        {
            return compManager.deleteCompany(id);
        }

        public bool deleteRoute(int fid)
        {
            return rManager.deleteRoute(fid);
        }

        public bool deleteBooking(int fid)
        {
            return bkManager.deleteBooking(fid);
        }

        public bool companyExistCheck(int id)
        {
            return compManager.companyExist(id);
        }

        public bool routeExistCheck(int id)
        {
            return rManager.routeExists(id);
        }

        public bool bookingExistCheck(int id)
        {
            return bkManager.bookingExists(id);
        }

        public string viewARoute(int id)
        {
            return rManager.getASpecificRoute(id);
        }

        public int getEmptySeats(int fid)
        {
            return rManager.getAvailableSeats(fid);
        }

        public int getMaxRoute()
        {
            return rManager.getMaxRoute();
        }

        public int getMaxCompanies()
        {
            return compManager.getMaxCompanies();
        }

        public int getMaxBookings()
        {
            return bkManager.getMaxBooking();
        }
    }
}
