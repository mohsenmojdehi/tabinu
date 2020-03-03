using BAL.Enums;

namespace AddBuzz.Models.Order
{
    public class CartServiceViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Count { get; set; }

        public string Price { get; set; }

        public TypeOfServiceEnum TypeOfService { get; set; }

        public string Picture { get; set; }
    }
}
