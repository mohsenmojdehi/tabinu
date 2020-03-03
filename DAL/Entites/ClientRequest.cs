using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class ClientRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        public int AdvertisementServiceId { get; set; }

        public DateTime CreateTime { get; set; }

        public bool Enable { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public string Status { get; set; }
    }
}
