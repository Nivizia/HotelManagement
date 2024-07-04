using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class RoomInformationDAO
    {
        public static List<RoomInformation> GetRoomInformations()
        {
            using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            return context.RoomInformations.ToList();
        }
    }
}
