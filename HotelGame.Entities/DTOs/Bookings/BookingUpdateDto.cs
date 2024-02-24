using System;

namespace HotelGame.Entities.DTOs.Bookings
{
    public class BookingUpdateDto
    {
        // Mevcut rezervasyonu güncelleme için gerekli özellikler
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        // Diğer gerekli özellikler eklenebilir
    }
}
