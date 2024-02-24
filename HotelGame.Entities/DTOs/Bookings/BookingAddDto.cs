using System;

namespace HotelGame.Entities.DTOs.Bookings
{
    public class BookingAddDto
    {
        // Yeni rezervasyon ekleme için gerekli özellikler
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        // Diğer gerekli özellikler eklenebilir
    }
}
