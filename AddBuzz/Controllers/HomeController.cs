using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AddBuzz.Models;
using AddBuzz.CustomeAuthorizeAttribute;
using AddBuzz.Helpers;
using Microsoft.AspNetCore.Http;

namespace AddBuzz.Controllers
{
    public class HomeController : Controller
    {
        private ITokenHelper _tokenHelper;
        private IHttpContextAccessor _httpContextAccessor;

        public HomeController(ITokenHelper tokenHelper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenHelper = tokenHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AuthorizeFilter()]
        public IActionResult BaseMenu()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult AdvertisementService()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
