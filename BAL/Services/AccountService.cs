using BAL.Interfaces;
using DAL.Entites;
using DAL.Repository;
using System.Linq;

namespace BAL.Services
{
   public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserService _userService;

        public AccountService(IAccountRepository accountRepository, IUserService userService)
        {
            _accountRepository = accountRepository;
            _userService = userService;
        }

        public Account GetAccount(int UserId)
        {
            return _accountRepository.GetList().FirstOrDefault(x=>x.User.Id==UserId);
        }
        public bool DeleteAccount(int UserId)
        {
            var obj = _accountRepository.GetList().FirstOrDefault(x => x.User.Id == UserId);
            return _accountRepository.Delete(obj.UserId);
        }

        public bool AddAccount(Account account, int UserId)
        {
            account.User = _userService.GetAll().FirstOrDefault(x => x.Id == UserId);
            return _accountRepository.Insert(account);
        }

        public bool UpdateAccount(Account account)
        {
            return _accountRepository.Update(account);
        }

    }
}
