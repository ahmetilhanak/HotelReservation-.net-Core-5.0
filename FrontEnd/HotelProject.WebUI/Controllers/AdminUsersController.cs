using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Without API Using
        //private readonly UserManager<AppUser> _userManager;

        //public AdminUsersController(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //public IActionResult Index()
        //{
        //    var values = _userManager.Users.Include(z=>z.WorkLocation).ToList();
        //    return View(values);
        //}


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:46611/api/AppUser/AppUserListWithLocation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        //    [HttpGet]
        //    public IActionResult AddStaff()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        //    {
        //        var client = _httpClientFactory.CreateClient();
        //        var jsonData = JsonConvert.SerializeObject(model);
        //        StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
        //        var responseMessage = await client.PostAsync("http://localhost:46611/api/Staff", stringContent);
        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        return View();
        //    }

        //    public async Task<IActionResult> DeleteStaff(int id)
        //    {
        //        var client = _httpClientFactory.CreateClient();
        //        var responseMessage = await client.DeleteAsync($"http://localhost:46611/api/Staff/{id}");

        //        if(responseMessage.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        return RedirectToAction("Index");


        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> UpdateStaff(int id)
        //    {
        //        var client = _httpClientFactory.CreateClient();
        //        var responseMessage = await client.GetAsync($"http://localhost:46611/api/Staff/{id}");

        //        if(responseMessage.IsSuccessStatusCode)
        //        {
        //            var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //            var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
        //            return View(values);
        //        }
        //        return View();
        //    }

        //    [HttpPost]

        //    public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        //    {
        //        var client = _httpClientFactory.CreateClient();
        //        var jsonData = JsonConvert.SerializeObject(model);
        //        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //        var responseMessage = await client.PutAsync("http://localhost:46611/api/Staff", stringContent);
        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        return View();

        //    }
        //}
    }
}
