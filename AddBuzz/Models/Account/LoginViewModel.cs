using System.ComponentModel.DataAnnotations;

namespace AddBuzz.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "نام کاربری")]
        [MinLength(5, ErrorMessage = "حداقل پنج حرف")]
        public string Username { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public bool Remember { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(10, ErrorMessage = "حداکثر 10 حرف")]
        [Display(Name = "کد امنیتی")]
        public string Captcha { get; set; }
    }
}
