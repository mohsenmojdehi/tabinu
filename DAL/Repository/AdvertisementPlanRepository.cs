using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DataBase;
using DAL.Entites;

namespace DAL.Repository
{
   public class AdvertisementPlanRepository: IAdvertisementPlanRepository
    {
        private DataBaseContext _context;

        public AdvertisementPlanRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public IList<AdvertisementPlan> GetList()
        {
            return _context.AdvertisementPlans.ToList();
        }

        public bool Insert(AdvertisementPlan Entity)
        {
            _context.AdvertisementPlans.Add(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Update(AdvertisementPlan Entity)
        {
            _context.Attach(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public bool Delete(int Id)
        {
            var Entity = _context.AdvertisementPlans.FirstOrDefault(x => x.Id == Id);
            _context.AdvertisementPlans.Remove(Entity);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public AdvertisementPlan Get(int Id)
        {
            return _context.AdvertisementPlans.FirstOrDefault(x => x.UserId == Id);
        }
    }
}
