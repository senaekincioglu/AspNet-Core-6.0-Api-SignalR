using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;
using System.Reflection.Metadata.Ecma335;

namespace SignalRApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService; //booking servide field örneklenir o tabloya ait olması için. 

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet] //Listeleme
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }
        [HttpPost] //Ekleme
        public IActionResult CreateBooking(CreateBookingDto createBookingDto) //Normalde Booking Manager yani service de entity alması lazım. burda dto alıyor ama entity e çeviriyor. 
        {
            Booking booking = new Booking()
            {
                Name= createBookingDto.Name,
                Phone= createBookingDto.Phone,
                Mail= createBookingDto.Mail,
                Date= createBookingDto.Date,
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon Yapıldı");
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
          var value=  _bookingService.TGetByID(id); //İd yi buluyor
            _bookingService.TDelete(value);//Bulduğu Id yi siliyor 
            return Ok("Rezervasyon Silindi");
        }

       [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                Id= updateBookingDto.Id,
                Name= updateBookingDto.Name,    
                Phone= updateBookingDto.Phone,
                Mail= updateBookingDto.Mail,
                Date= updateBookingDto.Date
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Güncellendi");

        }
        [HttpGet("GetBooking")] //Id ye göre getiriyor.
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
           return Ok(value);
        }
       
    }
}
