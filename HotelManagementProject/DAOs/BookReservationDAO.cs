﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class BookReservationDAO
    {
        public static List<BookingReservation> GetBookingReservationsByCustomerId(string customerId)
        {
            try
            {
                using FuminiHotelManagementContext _context = new FuminiHotelManagementContext();
                var bookingReservations = _context.BookingReservations
                    .Where(b => b.CustomerId.Equals(customerId))
                    .ToList();
                return bookingReservations ?? new List<BookingReservation>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error in DAOs/BookReservationDAO.cs -> GetBookingReservationsByCustomerId(string customerId): {ex.Message}");
                return new List<BookingReservation>();
            }
            
        }

        public static List<BookingReservation> GetBookingReservationsByCustomerId(int customerId)
        {
            using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            return context.BookingReservations.Where(x => x.CustomerId == customerId).ToList();
        }
    }
}
