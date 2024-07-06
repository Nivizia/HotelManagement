using BusinessObjects.Models;
using DAOs.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class BookingDetailDAO
    {
        public static List<BookDetailDTO> GetBookDetailDTOs(int BookingReservationID)
        {
            try
            {
                using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
                var bookingDetails = context.BookingDetails.Include(b => b.Room).Where(b => b.BookingReservationId == BookingReservationID).ToList();
                var bookingDetailDTOs = bookingDetails.Select(b => new BookDetailDTO
                {
                    BookingReservationId = b.BookingReservationId,
                    RoomNumber = b.Room.RoomNumber,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    ActualPrice = b.ActualPrice
                }).ToList();
                return bookingDetailDTOs ?? new List<BookDetailDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DAOs/BookingDetailDAO.cs -> GetBookDetailDTOs(): {ex.Message}");
                return new List<BookDetailDTO>();
            }
        }

        public static List<BookDetailDTO> GetBookingDetails()
        {
            try
            {
                using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
                var bookingDetails = context.BookingDetails.Include(b => b.Room).ToList();
                var bookingDetailDTOs = bookingDetails.Select(b => new BookDetailDTO
                {
                    BookingReservationId = b.BookingReservationId,
                    RoomNumber = b.Room.RoomNumber,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    ActualPrice = b.ActualPrice
                }).ToList();
                return bookingDetailDTOs ?? new List<BookDetailDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DAOs/BookingDetailDAO.cs -> GetBookingDetails(): {ex.Message}");
                return new List<BookDetailDTO>();
            }
        }
    }
}
