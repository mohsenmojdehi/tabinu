using System.Collections.Generic;
using AddBuzz.Helpers;
using AddBuzz.Models;
using AddBuzz.Models.Order;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BAL.Enums;
using BAL.Interfaces;

namespace AddBuzz.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICookieHelper _cookieHelper;
        private readonly IAdvertisementPlanService _advertisementPlanService;
        private readonly IGraphicDesigningPlanService _graphicDesigningPlanService;

        public OrderController(ICookieHelper cookieHelper,
            IAdvertisementPlanService advertisementPlanService,
            IGraphicDesigningPlanService graphicDesigningPlanService)
        {
            _cookieHelper = cookieHelper;
            _advertisementPlanService = advertisementPlanService;
            _graphicDesigningPlanService = graphicDesigningPlanService;
        }

        [HttpGet]
        public IActionResult Cart()
        {
            CartViewModel model = new CartViewModel();
            List<CartServiceViewModel> cartServiceViewModels = new List<CartServiceViewModel>();
            var cartCookie = _cookieHelper.GetCookie("_cart");
            if (cartCookie != null)
            {
                cartServiceViewModels = (List<CartServiceViewModel>)cartCookie;
            }
            model.cartServiceViewModels = cartServiceViewModels;
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddToCart(AddToCartViewModel model)
        {
            List<CartServiceViewModel> cartServiceViewModels=new List<CartServiceViewModel>();
            var cartCookie= _cookieHelper.GetCookie("_cart");
            if (cartCookie!=null)
            {
                cartServiceViewModels = (List<CartServiceViewModel>) cartCookie;
            }
            if (cartServiceViewModels.Count > 100)
            {
                return new JsonResult(new ApiResultViewModel { Data = null, Message = "سبد بیش از حد مجاز پر شده است",Status = false});
            }
            if (cartServiceViewModels.Any(x => x.Id == model.Id && x.TypeOfService == model.TypeOfService))
            {
                cartServiceViewModels.Where(x => x.Id == model.Id && x.TypeOfService == model.TypeOfService).Select(x => { x.Count= x.Count+1 ; return x; }).ToList();
            }
            else
            {
                dynamic service = null;
                if (model.TypeOfService==TypeOfServiceEnum.AdvertisementService)
                {
                    service = _advertisementPlanService.GetAdvertisementService(model.Id);
                }
                if (model.TypeOfService == TypeOfServiceEnum.GraphicService)
                {
                    service = _graphicDesigningPlanService.GetGraphicDesigningPlan(model.Id);
                }
                if (service!=null)
                {
                    cartServiceViewModels.Add(new CartServiceViewModel() { Count = 1, Id = model.Id, TypeOfService = model.TypeOfService, Title = service.Title,Price = service.Price.ToString() });
                }
            }
            _cookieHelper.SetCookie("_cart", cartServiceViewModels,7);
            return new JsonResult(new ApiResultViewModel{Data =null,Message = "سبد خرید بروزرسانی شد",Status = true});
        }
    }
}