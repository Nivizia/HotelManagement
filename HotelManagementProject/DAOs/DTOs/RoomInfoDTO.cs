using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.DTOs
{
    public class RoomInfoDTO
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; } = null!;

        public string? RoomDetailDescription { get; set; }

        public int? RoomMaxCapacity { get; set; }

        public string? RoomType { get; set; }

        public byte? RoomStatus { get; set; }

        public decimal? RoomPricePerDay { get; set; }
    }
}
