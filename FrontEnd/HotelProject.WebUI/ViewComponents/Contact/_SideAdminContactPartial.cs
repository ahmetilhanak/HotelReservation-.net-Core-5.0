using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Contact
{
    public class _SideAdminContactPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _SideAdminContactPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:46611/api/Contact/GetContactCount");

            //var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("http://localhost:46611/api/SendMessage/GetSendMessagesCount");

            if (responseMessage.IsSuccessStatusCode || responseMessage2.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage.Content.ReadAsStringAsync();

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                ViewBag.ContactCount = jsonData1;

                ViewBag.SendMessageCount = jsonData2;
            }
            return View();
        }
    }
}
