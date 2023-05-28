using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlink_WAP_Project
{
    internal class Company
    { 
        private int companyId;
        private string name;
        private string location;
        private string phone;
        private int bookings;

    //constructor
        public Company(int cId, string nm, string loc, string ph)
        {
            bookings = 0;
            companyId = cId;
            name = nm;
            location = loc;
            phone = ph;
        }

        //getters
        public int getId() { return companyId; }
        public string getName() { return name; }
        public string getLocation() { return location; }
        public string getPhone() { return phone; }
        public void setNumBookings(int numBookings) { bookings += numBookings; }
        public int getNumBookings() { return bookings; }

        //print information about a customer
        public string toString()
        {
            string s = " id: " + companyId;
            s = s + " Name: " + name + " " + location;
            s = s + " Phone: " + phone;
            s = s + " Bookings: " + bookings;

            return s;
        }
    }
}
