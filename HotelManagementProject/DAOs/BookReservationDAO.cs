using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class BookReservationDAO
    {
        public static List<BookingReservation> GetBookingReservations()
        {
            using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            return context.BookingReservations.ToList();
        }

        public static List<BookingReservation> GetBookingReservationsByCustomerId(int customerId)
        {
            using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            return context.BookingReservations.Where(x => x.CustomerId == customerId).ToList();
        }
    }
}
