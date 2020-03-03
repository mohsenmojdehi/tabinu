
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class OrderOption
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrederId { get; set; }

        public Order Order { get; set; }

        [ForeignKey("AdvertisementPlan")]
        public int? AdvertisementServiceId { get; set; }

        public virtual AdvertisementPlan AdvertisementPlan { get; set; }

        [ForeignKey("GraphicDesigningPlan")]
        public int? GraphicDesigningServiceId { get; set; }
        public GraphicDesigningPlan GraphicDesigningPlan { get; set; }
        public int Count { get; set; }

        public int Amount { get; set; }
    }
}
