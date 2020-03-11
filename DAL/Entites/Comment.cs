using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int? AccountId { get; set; }

        public int? AdvertisementPlanId { get; set; }

        public int? GraphicDesigningPlanId { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }
        
        public int? Point { get; set; }

        public int ParentId { get; set; }
    }
}
