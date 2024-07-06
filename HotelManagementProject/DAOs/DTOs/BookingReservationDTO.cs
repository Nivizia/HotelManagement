using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.DTOs
{
    public class BookingReservationDTO
    {
        public int BookingReservationId { get; set; }

        public DateOnly? BookingDate { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? CustomerFullName { get; set; }

        public byte? BookingStatus { get; set; }
    }
}
