using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AddBuzz.Models.Account
{
    public class CompleteAccountViewModel
    {
        public string FullName { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
        public string ProfilePicture { get; set; }
    }
}
