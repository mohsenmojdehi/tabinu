using DAL.DataBase;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
   public class CommentRepository: ICommentRepository
    {
        private DataBaseContext _context;

        public CommentRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public IList<Comment> GetList()
        {
            return _context.Comments.ToList();
        }

        public bool Insert(Comment Entity)
        {
            _context.Comments.Add(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Update(Comment Entity)
        {
            _context.Attach(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Delete(int Id)
        {
            var Entity = _context.Comments.FirstOrDefault(x => x.Id == Id);
            _context.Comments.Remove(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public Comment Get(int Id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == Id);
        }
    }
}
