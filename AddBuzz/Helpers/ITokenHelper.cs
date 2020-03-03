using AddBuzz.Models.Account;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;

namespace AddBuzz.Helpers
{
   public interface ITokenHelper
    {
        bool IsTokenValid(string token);

        bool IsTokenValid(string token, string role);

        void SetCookie(string key, string token);

        CurrentUserInfo GetUserInfo();
        TokenInformationViewModel CreateUserToken(User userData);
    }
}
