using DAL.DataBase;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
   public class UserRepository: IUserRepository
    {
        private DataBaseContext _context;

        public UserRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public IList<User> GetList()
        {
            return _context.Users.ToList();
        }

        public bool Insert(User Entity)
        {
            _context.Users.Add(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Update(User Entity)
        {
            _context.Attach(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Delete(int Id)
        {
            var Entity = _context.Users.FirstOrDefault(x=>x.Id==Id);
            _context.Users.Remove(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }
        
        public User Get(int Id)
        {
          return  _context.Users.FirstOrDefault(x => x.Id == Id);
        }
    }
}
