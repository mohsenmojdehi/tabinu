using DAL.Entites;

namespace BAL.Interfaces
{
   public interface IAccountService
    {
        Account GetAccount(int UserId);
        bool DeleteAccount(int UserId);

        bool AddAccount(Account account, int UserId);

        bool UpdateAccount(Account account);
    }
}
