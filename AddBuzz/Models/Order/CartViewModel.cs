using System.Collections.Generic;
namespace AddBuzz.Models.Order
{
    public class CartViewModel
    {
        public string Price { get; set; }
        public List<CartServiceViewModel> cartServiceViewModels { get; set; }
        public string Discount { get; set; }
    }
}
