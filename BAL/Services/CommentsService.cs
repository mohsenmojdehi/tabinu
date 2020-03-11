
using System.Collections.Generic;
using System.Linq;
using BAL.Interfaces;
using DAL.Entites;
using DAL.Repository;

namespace BAL.Services
{
    public class CommentsService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentsService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public List<Comment> AdvertisementComments(int adsId)
        {
            return _commentRepository.GetList().Where(x => x.AdvertisementPlanId == adsId).ToList();
        }

        public List<Comment> AccountComments(int accountId)
        {
            return _commentRepository.GetList().Where(x => x.AccountId == accountId).ToList();
        }

        public List<Comment> GraphicDesigningPlanComments(int grId)
        {
            return _commentRepository.GetList().Where(x => x.GraphicDesigningPlanId == grId).ToList();
        }
    }
}
