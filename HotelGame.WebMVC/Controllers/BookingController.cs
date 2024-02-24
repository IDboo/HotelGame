using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HotelGame.Business.Abstract;
using HotelGame.Entities.DTOs.Bookings;


namespace HotelGame.WebMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookingService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var result = await _bookingService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] BookingAddDto bookingDto)
        {
            var result = await _bookingService.AddAsync(bookingDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingUpdateDto bookingDto)
        {
            var result = await _bookingService.UpdateAsync(bookingDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteAsync(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
