using BusinessObjects.Models;
using DAOs.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class RoomInformationDAO
    {
        public static List<RoomInfoDTO> GetRoomInformations()
        {
            using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            var roominfos = context.RoomInformations.Include(r => r.RoomType).ToList();
            var roominfosDTO = roominfos.Select(r => new RoomInfoDTO
            {
                RoomId = r.RoomId,
                RoomNumber = r.RoomNumber,
                RoomDetailDescription = r.RoomDetailDescription,
                RoomMaxCapacity = r.RoomMaxCapacity,
                RoomType = r.RoomType.RoomTypeName,
                RoomStatus = r.RoomStatus,
                RoomPricePerDay = r.RoomPricePerDay
            }).ToList();
            return roominfosDTO;
        }

        public static bool UpdateRoomInformation(RoomInfoDTO RoomInfoDTO)
        {
            using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            var roomType = context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeName == RoomInfoDTO.RoomType);

            if (roomType == null)
            {
                return false;
            }

            var roomtypeid = roomType.RoomTypeId;

            var roominfo = new RoomInformation
            {
                RoomId = RoomInfoDTO.RoomId,
                RoomNumber = RoomInfoDTO.RoomNumber,
                RoomDetailDescription = RoomInfoDTO.RoomDetailDescription,
                RoomMaxCapacity = RoomInfoDTO.RoomMaxCapacity,
                RoomTypeId = roomtypeid,
                RoomStatus = RoomInfoDTO.RoomStatus,
                RoomPricePerDay = RoomInfoDTO.RoomPricePerDay
            };
            context.SaveChanges();
            return true;
        }

        public static bool DeleteRoomInformation(int RoomId)
        {
            using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            var roominfo = context.RoomInformations.FirstOrDefault(r => r.RoomId == RoomId);
            if (roominfo == null)
            {
                return false;
            }
            context.RoomInformations.Remove(roominfo);
            context.SaveChanges();
            return true;
        }
    }
}
