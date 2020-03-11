using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entites;

namespace BAL.Interfaces
{
    public interface ICommentService
    {
        List<Comment> AdvertisementComments(int adsId);

        List<Comment> AccountComments(int accountId);

        List<Comment> GraphicDesigningPlanComments(int grId);
    }
}
