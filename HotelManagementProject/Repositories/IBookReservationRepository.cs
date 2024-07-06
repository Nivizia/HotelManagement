using BusinessObjects.Models;
using DAOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookReservationRepository
    {
        public List<BookingReservation> GetBookingReservations();

        public List<BookingReservation> GetBookingReservationsByCustomerId(int customerId);

        public List<BookingReservationDTO> GetBookingReservationDTOs();
    }
}
