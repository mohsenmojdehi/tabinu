using DAL.Entites;
using System.Collections.Generic;

namespace BAL.Interfaces
{
   public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        bool Register(User user,out string Message);
    }
}
