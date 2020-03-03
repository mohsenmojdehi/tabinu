using System.Collections.Generic;
using BAL.Interfaces;
using DAL.Entites;
using DAL.Repository;

namespace BAL.Services
{
   public class GraphicDesigningPlanService: IGraphicDesigningPlanService
    {
        private readonly IGraphicDesigningPlanRepository _graphicDesigningPlanRepository;
        public GraphicDesigningPlanService(IGraphicDesigningPlanRepository graphicDesigningPlanRepository)
        {
            _graphicDesigningPlanRepository = graphicDesigningPlanRepository;
        }

        public GraphicDesigningPlan GetGraphicDesigningPlan(int id)
        {
            return _graphicDesigningPlanRepository.Get(id);
        }

        public IEnumerable<GraphicDesigningPlan> GetAll()
        {
            return _graphicDesigningPlanRepository.GetList();
        }

        public bool Delete(int id)
        {
            return _graphicDesigningPlanRepository.Delete(id);
        }
    }
}
