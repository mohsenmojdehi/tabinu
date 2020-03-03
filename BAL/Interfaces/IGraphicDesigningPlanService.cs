using System.Collections.Generic;
using DAL.Entites;

namespace BAL.Interfaces
{
   public interface IGraphicDesigningPlanService
    {
        GraphicDesigningPlan GetGraphicDesigningPlan(int id);
        IEnumerable<GraphicDesigningPlan> GetAll();
        bool Delete(int id);
    }
}
