using DAL.Entites;
using System.ComponentModel.DataAnnotations;

namespace AddBuzz.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name ="نام کاربری")]
        [MinLength(5,ErrorMessage ="حداقل پنج حرف")]
        public string Username { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "رمز عبور")]
        [MinLength(8, ErrorMessage = "حداقل 8 حرف")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{7,}$",ErrorMessage ="حداقل شامل یک حرف و یک عدد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password",ErrorMessage ="تکرار رمز عبور نادرست")]
        public string RetypePassword { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "ایمیل")]
        [RegularExpression(@"^.+@[^\.].*\.[a-z]{2,}$|", ErrorMessage ="ورودی نامعتبر")]
        [MaxLength(60,ErrorMessage ="حداکثر 50 حرف")]
        public string Email { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(10, ErrorMessage = "حداکثر 10 حرف")]
        [Display(Name = "کد امنیتی")]
        public string Captcha { get; set; }

        //[MinLength(11, ErrorMessage = "حداقل 11 عدد")]
        //public string Phone { get; set; }

        public static User GetUserFromRegisterViewModel(RegisterViewModel model)
        {
            return new User()
            {
                Username=model.Username.Trim(),
                Email=model.Email.Trim(),
                Password=model.Password.Trim(),
                //Phone=model.Phone
            };
        }
    }
}
