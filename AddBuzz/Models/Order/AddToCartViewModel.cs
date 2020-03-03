using BAL.Enums;

namespace AddBuzz.Models.Order
{
    public class AddToCartViewModel
    {
        public int Id { get; set; }
        public TypeOfServiceEnum TypeOfService { get; set; }
    }
}
