using BusinessObjects.Models;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookReservationRepository : IBookReservationRepository
    {
        public List<BookingReservation> GetBookingReservations() => BookReservationDAO.GetBookingReservations();

        public List<BookingReservation> GetBookingReservationsByCustomerId(int customerId) => BookReservationDAO.GetBookingReservationsByCustomerId(customerId);
    }
}
