using AddBuzz.Models.Account;
using DAL.Entites;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AddBuzz.Helpers
{
    public class TokenHelper : ITokenHelper
    {
        //az header ya cookie data ro migire
       

        private readonly IHttpContextAccessor _httpContextAccessor;

        private const string Secret = "VGhpcyBpcyBMaW5rZXJQYYQgc2VjcmVjdCBjb2Rl";

        public TokenHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private string UserToken()
        {
            string temp = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrWhiteSpace(temp))
            {
                temp = _httpContextAccessor.HttpContext.Request.Cookies["_authorization"];
            }
            return temp;
        }

        //barresi mikone bebine token valid hastesh ya na
        public bool IsTokenValid(string token)
        {
            try
            {
                new JwtBuilder()
                    .WithSecret(Secret)
                    .MustVerifySignature()
                    .Decode(token);
                return true;
            }
            catch (TokenExpiredException)
            {
                return false;
            }
            catch (SignatureVerificationException)
            {
                return false;
            }
        }

        public bool IsTokenValid(string token, string role)
        {
            try
            {
                var tk = new JwtBuilder()
                      .WithSecret(Secret)
                      .MustVerifySignature()
                      .Decode<UserInformationViewModel>(token);
                if (tk.Role == role)
                    return true;
                else
                    return false;
            }
            catch (TokenExpiredException)
            {
                return false;
            }
            catch (SignatureVerificationException)
            {
                return false;
            }
        }

        //token feali ro tabdil mikone be data
        public CurrentUserInfo GetUserInfo()
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                IDictionary<string, string> userDataDictionary = decoder.DecodeToObject<IDictionary<string, string>>(UserToken(), Secret, true);

                return new CurrentUserInfo
                {
                    Id = int.Parse(userDataDictionary["Id"]),
                    Username = userDataDictionary["UserName"],
                    Password = userDataDictionary["Email"],
                    Role = userDataDictionary["Role"]
                };
            }
            catch (TokenExpiredException)
            {
                //igonre exception 
                return null;
            }
            catch (SignatureVerificationException)
            {
                //igonre exception 
                return null;
            }
        }

        /// <summary>
        /// برای بعد از لاگین کردن لازمه
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        public void SetCookie(string key, string token)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, token, new CookieOptions { Expires = DateTime.Now.AddDays(10),IsEssential=true });
        }

        //token ro dakhel ye ghaleb mirize
        public TokenInformationViewModel CreateUserToken(User userData)
        {
            return new TokenInformationViewModel
            {
                Token = CreateToken(userData),
                ExpirationDate = DateTime.Now.AddMonths(1),
                UserInformationViewModel = UserInformationViewModel.GetUserInformationViewModel(userData)
            };
        }

        //az data user mored nazar token misaze
        private string CreateToken(User userData)
        {
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(Secret)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddMonths(6).ToUnixTimeSeconds())
                .AddClaim("Id", userData.Id)
                .AddClaim("UserName", userData.Username)
                .AddClaim("Email", userData.Email)
                .AddClaim("Role", userData.Role)
                .Build();
        }


    }
}
