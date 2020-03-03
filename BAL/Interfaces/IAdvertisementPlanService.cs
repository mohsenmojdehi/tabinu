using System.Collections.Generic;
using DAL.Entites;
namespace BAL.Interfaces
{
    public interface IAdvertisementPlanService
    {
        AdvertisementPlan GetAdvertisementService(int id);
        IEnumerable<AdvertisementPlan> GetAll();
        bool Delete(int id);
    }
}
