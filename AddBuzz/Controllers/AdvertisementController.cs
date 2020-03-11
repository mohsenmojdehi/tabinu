using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddBuzz.Models.Advertisement;
using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddBuzz.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementPlanService _advertisementPlanService;
        private readonly ICommentService _commentService;
        private readonly IPageService _pageService;

        public AdvertisementController(IAdvertisementPlanService advertisementPlanService,ICommentService commentService,IPageService pageService)
        {
            _advertisementPlanService = advertisementPlanService;
            _commentService = commentService;
            _pageService = pageService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Paln(int id)
        {
            var currentAdv = _advertisementPlanService.GetAdvertisementService(id);
            var currentPage = _pageService.GetPage(currentAdv.PageId);
            AdvertisementViewModel model=new AdvertisementViewModel();
            model.Title = currentAdv.User.Account.FullName;
            model.Picture = currentPage.Logo;
            model.Tages = currentAdv.Advertisement_Tags.ToList();
            model.Viewer = currentAdv.MinViewerInDay;
            model.Description = currentAdv.Description;
            model.Id = currentAdv.Id;
            model.Comments = _commentService.AdvertisementComments(id);
            model.Tages = currentAdv.Advertisement_Tags.ToList();
            return View(model);
        }
    }
}