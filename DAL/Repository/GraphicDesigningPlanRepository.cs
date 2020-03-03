using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DataBase;
using DAL.Entites;

namespace DAL.Repository
{
   public class GraphicDesigningPlanRepository: IGraphicDesigningPlanRepository
    {
        private DataBaseContext _context;

        public GraphicDesigningPlanRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public IList<GraphicDesigningPlan> GetList()
        {
            return _context.GraphicDesigningPlans.ToList();
        }

        public bool Insert(GraphicDesigningPlan Entity)
        {
            _context.GraphicDesigningPlans.Add(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Update(GraphicDesigningPlan Entity)
        {
            _context.Attach(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Delete(int Id)
        {
            var Entity = _context.GraphicDesigningPlans.FirstOrDefault(x => x.Id == Id);
            _context.GraphicDesigningPlans.Remove(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public GraphicDesigningPlan Get(int Id)
        {
            return _context.GraphicDesigningPlans.FirstOrDefault(x => x.Id == Id);
        }
    }
}
