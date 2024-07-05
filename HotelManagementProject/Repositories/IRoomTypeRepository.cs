using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomTypeRepository
    {
        public List<RoomType> GetRoomTypes();

        public bool UpdateRoomTypes(RoomType roomType);

        public bool DeleteRoomType(int RoomTypeId);
    }
}
