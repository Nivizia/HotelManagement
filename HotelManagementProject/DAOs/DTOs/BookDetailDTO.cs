using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.DTOs
{
    public class BookDetailDTO
    {
        public int BookingReservationId { get; set; }

        public string? RoomNumber { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public decimal? ActualPrice { get; set; }
    }
}
