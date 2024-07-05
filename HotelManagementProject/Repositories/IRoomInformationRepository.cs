using DAOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomInformationRepository
    {
        public List<RoomInfoDTO> GetAll();

        public bool UpdateRoomInfo(RoomInfoDTO updatedRoomInfo);

        public bool DeleteRoomInfo(int roomId);
    }
}
