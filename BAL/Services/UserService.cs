using BAL.Helpers;
using BAL.Interfaces;
using DAL.Entites;
using DAL.Repository;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace BAL.Services
{
   public class UserService: IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly IList<User> _users;
        public UserService(IOptions<AppSettings> appSettings,IUserRepository userRepository)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
            _users = _userRepository.GetList();
        }

        public bool Register(User user,out string Message)
        {
            if(_userRepository.GetList().Any(x=>x.Email==user.Email.Trim() || x.Username==user.Username))
            {
                Message = "این نام کاربری یا ایمیل از قبل در سیستم وجود دارد";
                return false;
            }
            Message = "";
            return _userRepository.Insert(user);
        }
    

        public User Authenticate(string username, string password)
        {
            var user = _users.FirstOrDefault(x => (x.Username == username || x.Email==username) && x.Password == password);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }
    }
}
