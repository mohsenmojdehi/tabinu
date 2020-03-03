using DAL.Entites;
using Microsoft.AspNetCore.Mvc;

namespace AddBuzz.Models.Account
{
    public class UserInformationViewModel
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Role { get; set; }


        public static UserInformationViewModel GetUserInformationViewModel(User userData)
        {
            return new UserInformationViewModel
            {
                UserId = userData.Id,
                Username = userData.Username,
                Email = userData.Email,
                //Phone = userData.Phone,
                Role = userData.Role
            };
        }

    }
}
