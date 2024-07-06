using BusinessObjects.Models;
using DAOs;
using DAOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public List<BookDetailDTO> GetBookingDetailsByBookingId(int BookingReservationID) => BookingDetailDAO.GetBookDetailDTOs(BookingReservationID);

        public List<BookDetailDTO> GetBookingDetails() => BookingDetailDAO.GetBookingDetails();
    }
}
