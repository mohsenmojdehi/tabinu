﻿using System;
namespace AddBuzz.Models.Account
{
    public class TokenInformationViewModel
    {
        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }

        public UserInformationViewModel UserInformationViewModel { get; set; }
    }
}
