using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class Advertisement_Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AdvertisementServiceId { get; set; }

        public AdvertisementPlan AdvertisementPlan { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
