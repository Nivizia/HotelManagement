using DAOs;
using DAOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        public List<RoomInfoDTO> GetAll() => RoomInformationDAO.GetRoomInformations();

        public bool UpdateRoomInfo(RoomInfoDTO updatedRoomInfo) => RoomInformationDAO.UpdateRoomInformation(updatedRoomInfo);

        public bool DeleteRoomInfo(int roomId) => RoomInformationDAO.DeleteRoomInformation(roomId);
    }
}
