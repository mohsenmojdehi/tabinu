using System.Linq;
using System.Net;
using AddBuzz.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AddBuzz.CustomeAuthorizeAttribute
{
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorizeFilter : ActionFilterAttribute
    {
        private  ITokenHelper _tokenHelper;
        private  IHttpContextAccessor _httpContextAccessor;

        private readonly string[] _roles;

        //public AuthorizeFilter(IHttpContextAccessor httpContextAccessor, ITokenHelper tokenHelper)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //    _tokenHelper = tokenHelper;
        //}

        public AuthorizeFilter()
        {

        }
        public AuthorizeFilter(string Role)
        {
            _roles = Role.Split(",");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _tokenHelper= (ITokenHelper)context.HttpContext.RequestServices.GetService(typeof(ITokenHelper));
            _httpContextAccessor = (IHttpContextAccessor)context.HttpContext.RequestServices.GetService(typeof(IHttpContextAccessor));
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            bool FromWeb = false;
            if (string.IsNullOrWhiteSpace(token))
            {
                token = _httpContextAccessor.HttpContext.Request.Cookies["_authorization"];
                FromWeb = true;
            }

            if(_roles!=null && _roles.Any())
            {
                if (token != null)
                {
                    if (string.IsNullOrWhiteSpace(token))
                    {
                        context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                        if (FromWeb)
                        {
                            context.Result = new RedirectToActionResult("login", "account", new { });
                        }
                    }

                    else if (!_tokenHelper.IsTokenValid(token) || !_roles.Any(x=>x== _tokenHelper.GetUserInfo().Role))
                    {
                        context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                        if (FromWeb)
                        {
                            context.Result =new RedirectToActionResult("NotPermitedPage", "account",new {});
                        }
                    }
                }
                else
                {
                    context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                    if (FromWeb)
                    {
                        context.Result = new RedirectToActionResult("login", "account", new { });
                    }
                }
            }
            else
            {
                if (token != null)
                {
                    if (string.IsNullOrWhiteSpace(token))
                    {
                        context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                        if (FromWeb)
                        {
                            context.Result = new RedirectToActionResult("login", "account", new { });
                        }
                    }

                    else if (!_tokenHelper.IsTokenValid(token))
                    {
                        context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                        if (FromWeb)
                        {
                            context.Result = new RedirectToActionResult("login", "account", new { });
                        }
                    }
                }
                else
                {
                    context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                    if (FromWeb)
                    {
                        context.Result = new RedirectToActionResult("login", "account", new { });
                    }
                }
            }

           
        }
    }

    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(string Role) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { Role };
        }
        public CustomAuthorizeAttribute() : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { };
        }
    }

    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly bool RoleBase;
        private string _role;

        public ClaimRequirementFilter(string Role)
        {
            RoleBase = true;
            _role = Role;
        }

        public ClaimRequirementFilter()
        {
            RoleBase = false;
        }

        private ClaimRequirementFilter(IHttpContextAccessor httpContextAccessor, ITokenHelper tokenHelper)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenHelper = tokenHelper;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
           context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
        }
    }


}