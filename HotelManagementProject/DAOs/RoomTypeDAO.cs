using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class RoomTypeDAO
    {
        public static List<RoomType> GetRoomTypes()
        {
            using (var context = new FuminiHotelManagementContext())
            {
                return context.RoomTypes.ToList();
            }
        }

        public static bool UpdateRoomTypes(RoomType roomType)
        {

            using (var context = new FuminiHotelManagementContext())
            {
                var roomTypeToUpdate = context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeId == roomType.RoomTypeId);
                if (roomTypeToUpdate == null)
                {
                    return false;
                }
                roomTypeToUpdate.RoomTypeName = roomType.RoomTypeName;
                roomTypeToUpdate.TypeDescription = roomType.TypeDescription;
                roomTypeToUpdate.TypeNote = roomType.TypeNote;
                context.SaveChanges();
                return true;
            }
        }

        public static bool DeleteRoomType(int RoomTypeId)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var roomType = context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeId == RoomTypeId);
                if (roomType == null)
                {
                    return false;
                }
                context.RoomTypes.Remove(roomType);
                context.SaveChanges();
                return true;
            }
        }
    }
}
