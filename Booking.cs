using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Airlink_WAP_Project
{
    class Booking
    {
        private int bookingId;
        private string date;
        private Route r;
        private Company c;

        //constructor
        public Booking(int bn, Route rid, Company cid)
        {
            bookingId = bn;
            date = DateTime.Now.ToString(@"dd\/MM\/yyyy");
            this.r = rid;
            this.c = cid;
        }

        //getters
        public int getBookingId() { return bookingId; }
        public string getDate() { return date; }

        //print information about a booking
        public string toString()
        {
            string s = bookingId + ", date " + date + " " + r.toString();
            return s;
        }
    }
}

