using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AddBuzz.Models;
using AddBuzz.CustomeAuthorizeAttribute;
using AddBuzz.Helpers;
using Microsoft.AspNetCore.Http;
using AddBuzz.Helpers.CustomeAuthorizeAttribute;
using BAL.Interfaces;
using AddBuzz.Models.Account;
using DAL.Entites;
using System;
namespace AddBuzz.Controllers
{
    public class HomeController : Controller
    {
        private ITokenHelper _tokenHelper;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizeHelper _authorizeHelper;
        private readonly IAccountService _accountService;
        private readonly CurrentUserInfo user;
        public HomeController(ITokenHelper tokenHelper, IHttpContextAccessor httpContextAccessor, IAuthorizeHelper authorizeHelper, IAccountService accountService)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenHelper = tokenHelper;
            _authorizeHelper = authorizeHelper;
            _accountService = accountService;
            if(_authorizeHelper.IsAuthenticated())
            {
                this.user = _authorizeHelper.GetCurrentUser();
            }
             
        }

        public IActionResult Index()
        {
            return View();
        }

        [AuthorizeFilter()]
        public IActionResult BaseMenu()
        {
            
            var current_user_account = _accountService.GetAccount(user.Id);
            if(current_user_account==null)
            {
                return RedirectToAction("CompleteAccount");
            }
            return View();
        }

        [HttpGet]
        [AuthorizeFilter()]
        public IActionResult CompleteAccount()
        {
            CompleteAccountViewModel model = new CompleteAccountViewModel();
            var current_user_account = _accountService.GetAccount(user.Id);
            if (current_user_account!=null)
            {
                model.Description = current_user_account.Description;
                model.FullName = current_user_account.FullName;
                model.OtherContact = current_user_account.OtherContact;
                model.Phone = current_user_account.Phone;
                model.ProfilePicture = current_user_account.ProfilePicture;
            }
            return View(model);
        }

        [HttpPost]
        [AuthorizeFilter()]
        public IActionResult CompleteAccount(CompleteAccountViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            Account account = new Account
            {
                CreateTime = DateTime.Now,
                Description=model.Description,
                Enable=true,
                FullName=model.FullName,
                OtherContact=model.OtherContact,
                Phone=model.Phone,
                Status="",
                ProfilePicture=model.ProfilePicture
            };
            var res= _accountService.AddAccount(account, user.Id);
            if (res)
            {
                return RedirectToAction("BaseMenu");
            }

            return View(model);
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
