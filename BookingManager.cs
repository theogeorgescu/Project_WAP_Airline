﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlink_WAP_Project
{
    class BookingManager
    {
        private static int currentBookingNumber;
        private int maxBookings;
        private int numBookings;
        private Booking[] bookingList;

        //constructor
        public BookingManager(int ccn, int max)
        {
            currentBookingNumber = ccn;
            maxBookings = max;
            numBookings = 0;
            bookingList = new Booking[maxBookings];
        }

        //add booking to booking list
        public bool addBooking(Route rid, Company cid)
        {
            if (numBookings >= maxBookings) { return false; }
            Booking b = new Booking(currentBookingNumber, rid, cid);
            currentBookingNumber++;
            bookingList[numBookings] = b;
            numBookings++;
            return true;
        }

        public int findBooking(int rid)
        {
            for (int x = 0; x < numBookings; x++)
            {
                if (bookingList[x].getBookingId() == rid)
                    return x;
            }
            return -1;
        }

        public bool bookingExists(int rid)
        {
            int loc = findBooking(rid);
            if (loc == -1) { return false; }
            return true;
        }

        public Booking getBooking(int rid)
        {
            int loc = findBooking(rid);
            if (loc == -1) { return null; }
            return bookingList[loc];
        }

        public bool deleteBooking(int rid)
        {
            int loc = findBooking(rid);
            if (loc == -1) { return false; }
            bookingList[loc] = bookingList[numBookings - 1];
            numBookings--;
            return true;
        }

        public int getMaxBooking()
        {
            return maxBookings;
        }

        //print booking list one by one row (in purposes to use dataGridView in Forms)
        public string getBookingList(int id)
        {
            string s = "";
            s = s + " id: ";
            s += bookingList[findBooking(id)].toString();
            return s;
        }
    }
}
