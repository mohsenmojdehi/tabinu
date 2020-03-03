using AddBuzz.Models.Account;
using BAL.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AddBuzz.Helpers.CustomeAuthorizeAttribute
{
    public class AuthorizeHelper : IAuthorizeHelper
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly string token;
        public AuthorizeHelper(ITokenHelper tokenHelper, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _tokenHelper = tokenHelper;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrWhiteSpace(token))
            {
                token = _httpContextAccessor.HttpContext.Request.Cookies["_authorization"];
            }
        }
        public bool IsAuthenticated()
        {
            if (!string.IsNullOrEmpty(token))
            {
                var res = _tokenHelper.IsTokenValid(token);
                var currentUser = _tokenHelper.GetUserInfo();
                if (res)
                {
                    var auth = _userService.Authenticate(currentUser.Username, currentUser.Password);
                    if (auth != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsAuthorized(string role)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var res = _tokenHelper.IsTokenValid(token);
                var currentUser = _tokenHelper.GetUserInfo();
                if (res)
                {
                    var auth = _userService.Authenticate(currentUser.Username, currentUser.Password);
                    if (auth != null && auth.Role == role.Trim())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsAuthorized(string[] roles)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var res = _tokenHelper.IsTokenValid(token);
                var currentUser = _tokenHelper.GetUserInfo();
                if (res)
                {
                    var auth = _userService.Authenticate(currentUser.Username, currentUser.Password);
                    if (auth != null && roles.Contains(auth.Role))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public CurrentUserInfo GetCurrentUser()
        {
            if (!string.IsNullOrEmpty(token))
            {
                var res = _tokenHelper.IsTokenValid(token);
                var currentUser = _tokenHelper.GetUserInfo();
                if (res)
                {
                    var authUser = _userService.Authenticate(currentUser.Username, currentUser.Password);
                    if (authUser != null)
                    {
                        return currentUser;
                    }
                }
            }
            return null;
        }
    }
}
