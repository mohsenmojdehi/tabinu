using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Entites
{
   public class AdvertisementPlan
    {
        public AdvertisementPlan()
        {
            this.OrderOptions = new HashSet<OrderOption>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(70)]
        public string Title { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        public int? Price { get; set; }

        public string PageId { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public bool? Garanty { get; set; }
       
        public string Picture { get; set; }

        public virtual ICollection<OrderOption> OrderOptions { get; set; }

        public virtual ICollection<Advertisement_Tag> Advertisement_Tags { get; set; }
    }
}
