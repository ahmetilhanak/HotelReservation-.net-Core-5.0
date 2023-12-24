using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<string> deneme = new List<string>();
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:46611/api/MessageCategory");
            //if (responseMessage.IsSuccessStatusCode)
            //{
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);
                
                List<SelectListItem> categorySelection = (from x in values
                                                          select new SelectListItem
                                                          {
                                                              Text = x.MessageCategoryName,
                                                              Value= x.MessageCategoryID.ToString()
                                                          }).ToList();
                ViewBag.dataGet = categorySelection;
                return View();
            //}
            //return View();

            
            
        }

        public PartialViewResult _ContactPartial()
        {
            return PartialView();
        }

        [HttpPost]

        public async Task<IActionResult> _ContactPartial(CreateContactDto createContactDto)
        {
            createContactDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:46611/api/Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
