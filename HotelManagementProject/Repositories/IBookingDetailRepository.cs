using DAOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingDetailRepository
    {
        public List<BookDetailDTO> GetBookingDetailsByBookingId(int BookingReservationID);
    }
}
