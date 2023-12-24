using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminImageFileController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PostAsync("http://localhost:46611/api/FileImage", multipartFormDataContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return View("Index");
            }
            return View();
        }
    }
}
