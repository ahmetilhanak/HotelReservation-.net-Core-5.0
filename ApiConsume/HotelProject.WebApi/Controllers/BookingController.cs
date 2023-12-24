using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {

            var values = _bookingService.TGetList();
            return Ok(values);

        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("Last6Bookings")]       // or    [HttpGet("action")]
        public IActionResult Last6Bookings()
        {
            var values = _bookingService.TLast6Bookings();
            return Ok(values);

        }

        [HttpGet("BookingApproved/{id}")]       // or    [HttpPut("action")]
        public IActionResult BookingApproved(int id)
        {
            var bookingToApprove = _bookingService.TGetByID(id);
            _bookingService.TBookingStatusChangeToApproved(bookingToApprove);
            return Ok(bookingToApprove);

        }

        [HttpGet("BookingCancelled/{id}")]       // or    [HttpPut("action")]
        public IActionResult BookingCancelled(int id)
        {
            var bookingToCancel = _bookingService.TGetByID(id);
            _bookingService.TBookingStatusChangeToCancel(bookingToCancel);
            return Ok(bookingToCancel);

        }

        [HttpGet("BookingHold/{id}")]       // or    [HttpPut("action")]
        public IActionResult BookingHold(int id)
        {
            var bookingHold = _bookingService.TGetByID(id);
            _bookingService.TBookingStatusChangeToHold(bookingHold);
            return Ok(bookingHold);

        }
    }
}
