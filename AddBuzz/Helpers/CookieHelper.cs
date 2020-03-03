using Microsoft.AspNetCore.Http;
using System;

namespace AddBuzz.Helpers
{
    public class CookieHelper: ICookieHelper
    {
        private IHttpContextAccessor _httpContextAccessor;
        public CookieHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void SetCookie(string key, object value, int expireDays)
        {
           _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value.ToString(), new CookieOptions { Expires = DateTime.Now.AddDays(expireDays),IsEssential=true });
        }
        public void DeleteCookie(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }

        public object GetCookie(string key)
        {
            var res= _httpContextAccessor.HttpContext.Request.Cookies[key];
            if (string.IsNullOrWhiteSpace(res))
            {
                return null;
            }
            return  res;
        }
    }
}
