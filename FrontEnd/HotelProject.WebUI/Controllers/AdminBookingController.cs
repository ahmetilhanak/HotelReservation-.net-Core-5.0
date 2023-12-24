using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class AdminBookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:46611/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }



        #region ApproveReservation Way-1

        //public async Task<IActionResult> ApprovedReservation2(int id)
        //{
            
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync($"http://localhost:46611/api/Booking/{id}");
        //    var values = new ApprovedBookingDto();

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        values = JsonConvert.DeserializeObject<ApprovedBookingDto>(jsonData);
        //        values.Status = "Onaylandı";
        //    }


        //    var jsonData2 = JsonConvert.SerializeObject(values);
        //    StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
        //    var responseMessage2 = await client.PutAsync("http://localhost:46611/api/Booking", stringContent);
        //    if (responseMessage2.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
            
        //}

        #endregion

        #region ApproveReservation Way-2
        public async Task<IActionResult> ApprovedReservation(int id)
        {
            
            var client = _httpClientFactory.CreateClient();
            
            var responseMessage2 = await client.GetAsync($"http://localhost:46611/api/Booking/BookingApproved/{id}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
           
        }
        #endregion

        public async Task<IActionResult> CancelledReservation(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage2 = await client.GetAsync($"http://localhost:46611/api/Booking/BookingCancelled/{id}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> HoldReservation(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage2 = await client.GetAsync($"http://localhost:46611/api/Booking/BookingHold/{id}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:46611/api/Booking/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:46611/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
