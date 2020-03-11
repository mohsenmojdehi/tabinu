using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DataBase;
using DAL.Entites;

namespace DAL.Repository
{
   public class PageRepository : IPageRepository
    {
        private DataBaseContext _context;

        public PageRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public IList<Page> GetList()
        {
            return _context.Pages.ToList();
        }

        public bool Insert(Page Entity)
        {
            _context.Pages.Add(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Update(Page Entity)
        {
            _context.Attach(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Delete(int Id)
        {
            var Entity = _context.Pages.FirstOrDefault(x => x.Id == Id);
            _context.Pages.Remove(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public Page Get(int Id)
        {
            return _context.Pages.FirstOrDefault(x => x.Id == Id);
        }
    }
}
