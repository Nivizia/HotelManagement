using BusinessObjects.Models;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public List<RoomType> GetRoomTypes() => RoomTypeDAO.GetRoomTypes();

        public bool UpdateRoomTypes(RoomType roomType) => RoomTypeDAO.UpdateRoomTypes(roomType);

        public bool DeleteRoomType(int RoomTypeId) => RoomTypeDAO.DeleteRoomType(RoomTypeId);
    }
}
