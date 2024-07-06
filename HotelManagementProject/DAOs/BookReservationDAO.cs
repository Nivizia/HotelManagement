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
    public class BookReservationDAO
    {

        public static List<BookingReservation> GetBookingReservations()
        {
            try
            {
                using FuminiHotelManagementContext _context = new FuminiHotelManagementContext();
                var bookingReservations = _context.BookingReservations.ToList();
                return bookingReservations ?? new List<BookingReservation>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error in DAOs/BookReservationDAO.cs -> GetBookingReservations(): {ex.Message}");
                return new List<BookingReservation>();
            }

        }

        public static List<BookingReservation> GetBookingReservationsByCustomerId(int customerId)
        {
            try
            {
                using FuminiHotelManagementContext _context = new FuminiHotelManagementContext();
                var bookingReservations = _context.BookingReservations
                    .Where(b => b.CustomerId.Equals(customerId))
                    .ToList();
                return bookingReservations ?? new List<BookingReservation>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error in DAOs/BookReservationDAO.cs -> GetBookingReservationsByCustomerId(string customerId): {ex.Message}");
                return new List<BookingReservation>();
            }

        }

        public static List<BookingReservationDTO> GetBookingReservationDTOs()
        {
            try
            {
                using FuminiHotelManagementContext _context = new FuminiHotelManagementContext();
                var bookingReservations = _context.BookingReservations.Include(b => b.Customer).ToList();
                var bookingReservationDTOs = bookingReservations.Select(b => new BookingReservationDTO
                {
                    BookingReservationId = b.BookingReservationId,
                    BookingDate = b.BookingDate,
                    TotalPrice = b.TotalPrice,
                    CustomerFullName = b.Customer.CustomerFullName,
                    BookingStatus = b.BookingStatus
                }).ToList();
                return bookingReservationDTOs ?? new List<BookingReservationDTO>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error in DAOs/BookReservationDAO.cs -> GetBookingReservationDTOs(): {ex.Message}");
                return new List<BookingReservationDTO>();
            }

        }
    }
}
