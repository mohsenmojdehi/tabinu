using Microsoft.AspNetCore.Mvc;
using AddBuzz.Models.Account;
using BAL.Interfaces;
using AddBuzz.Helpers;
using Microsoft.AspNetCore.Http;
using AddBuzz.CustomeAuthorizeAttribute;

namespace AddBuzz.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private IHttpContextAccessor _httpContextAccessor;

        public AccountController(IUserService userService, ITokenHelper tokenHelper, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _httpContextAccessor= httpContextAccessor;
        }

        //[CustomAuthorize("CanReadResource")]
       
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login");
            }
            if(_httpContextAccessor.HttpContext.Session.GetString("Captcha_register") !=model.Captcha)
            {
                _httpContextAccessor.HttpContext.Session.Remove("Captcha_register");
                ModelState.AddModelError("Captcha", "کد امنیتی نادرست میباشد");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string message = "";
            var result= _userService.Register(RegisterViewModel.GetUserFromRegisterViewModel(model),out message);
            if(result)
            {
                return RedirectToAction("login");
            }
            _httpContextAccessor.HttpContext.Session.Remove("Captcha_register");
            ModelState.AddModelError("", message);
            return View(model);
        }

        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
           

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_httpContextAccessor.HttpContext.Session.GetString("Captcha_login") != model.Captcha)
            {
                _httpContextAccessor.HttpContext.Session.Remove("Captcha_login");
                ModelState.AddModelError("Captcha", "کد امنیتی نادرست میباشد");
                return View(model);
            }
            var _user= _userService.Authenticate(model.Username, model.Password);
            if(_user == null)
            {
                ModelState.AddModelError("","مشخصات نامعتبر");
                _httpContextAccessor.HttpContext.Session.Remove("Captcha_login");
                return View(model);
            }
            else
            {
                _httpContextAccessor.HttpContext.Session.Remove("Captcha_login");
                var _token = _tokenHelper.CreateUserToken(_user).Token;
                _tokenHelper.SetCookie("_authorization", _token);
                return RedirectToAction(actionName: "BaseMenu", controllerName:"home");
            }
        }


        public IActionResult NotPermitedPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CompleteAccountInformation()
        {
            return View();
        }

        [AuthorizeFilter()]
        public IActionResult CompleteAccountInformation(CompleteAccountViewModel model)
        {
            return View();
        }
    }
}