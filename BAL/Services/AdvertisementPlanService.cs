using System.Collections.Generic;
using BAL.Interfaces;
using DAL.Entites;
using DAL.Repository;

namespace BAL.Services
{
   public class AdvertisementPlanService: IAdvertisementPlanService
   {
       private readonly IAdvertisementPlanRepository _advertisementPlanRepository;
        public AdvertisementPlanService(IAdvertisementPlanRepository advertisementPlanRepository)
        {
            _advertisementPlanRepository = advertisementPlanRepository;
        }

       public AdvertisementPlan GetAdvertisementService(int id)
       {
           return _advertisementPlanRepository.Get(id);
       }

       public IEnumerable<AdvertisementPlan> GetAll()
       {
           return _advertisementPlanRepository.GetList();
       }

       public bool Delete(int id)
       {
           return _advertisementPlanRepository.Delete(id);
       }
    }
}
