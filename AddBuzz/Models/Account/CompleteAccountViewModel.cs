using System.ComponentModel.DataAnnotations;

namespace AddBuzz.Models.Account
{
    public class CompleteAccountViewModel
    {
        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(50,ErrorMessage ="حداکثر 50 حرف")]
        public string FullName { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000, ErrorMessage = "حداکثر 1000 حرف")]
        public string Description { get; set; }
        //public IFormFile ProfilePictureFile { get; set; }

        public string ProfilePicture { get; set; }
        [Display(Name = "تلفن تماس")]
        [MaxLength(14, ErrorMessage = "حداکثر 14 حرف")]
        public string Phone { get; set; }

        [Display(Name = "سایر راههای ارتباطی")]
        [MaxLength(50,ErrorMessage ="حداکثر 50 حرف")]
        public string OtherContact { get; set; }
    }
}
