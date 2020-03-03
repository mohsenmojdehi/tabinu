using DAL.DataBase;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
   public class AccountRepository:IAccountRepository
    {
        private DataBaseContext _context;

        public AccountRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public IList<Account> GetList()
        {
            return _context.Accounts.ToList();
        }

        public bool Insert(Account Entity)
        {
            _context.Accounts.Add(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Update(Account Entity)
        {
            _context.Attach(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Delete(int Id)
        {
            var Entity = _context.Accounts.FirstOrDefault(x => x.UserId == Id);
            _context.Accounts.Remove(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public Account Get(int Id)
        {
            return _context.Accounts.FirstOrDefault(x => x.UserId == Id);
        }
    }
}
