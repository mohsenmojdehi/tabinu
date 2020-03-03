using AddBuzz.Models.Account;
namespace AddBuzz.Helpers.CustomeAuthorizeAttribute
{
   public interface IAuthorizeHelper
    {
        bool IsAuthenticated();
        bool IsAuthorized(string role);
        bool IsAuthorized(string[] roles);
        CurrentUserInfo GetCurrentUser();
    }
}
