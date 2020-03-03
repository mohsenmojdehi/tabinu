using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class RefereeRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        public int? AdvertisementServiceId { get; set; }

        public int? GraphicDesigningServiceId { get; set; }

        [MaxLength(4000)]
        public string UserDescription { get; set; }

        [MaxLength(4000)]
        public string AdminDescription { get; set; }

        [MaxLength(4000)]
        public string ServiceProvidersDescription { get; set; }

        public int Status { get; set; }
    }
}
