using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Entites
{
  public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        public int Amount { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<OrderOption> AdvertisementServices { get; set; }
    }
}
