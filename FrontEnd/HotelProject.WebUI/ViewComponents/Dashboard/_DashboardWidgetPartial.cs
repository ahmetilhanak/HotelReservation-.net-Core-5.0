using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("http://localhost:46611/api/DashboardWidgets/StaffCount");
            var responseMessage2 = await client.GetAsync("http://localhost:46611/api/DashboardWidgets/BookingCount");
            var responseMessage3 = await client.GetAsync("http://localhost:46611/api/DashboardWidgets/AppUserCount");
            var responseMessage4 = await client.GetAsync("http://localhost:46611/api/DashboardWidgets/RoomCount");

            if (responseMessage1.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode && responseMessage3.IsSuccessStatusCode && responseMessage4.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                // var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);

                ViewBag.staffCount = jsonData1;
                ViewBag.bookingCount = jsonData2;
                ViewBag.appUserCount = jsonData3;
                ViewBag.roomCount = jsonData4;

                return View();
            }
            return View();
        }

       
    }
}
