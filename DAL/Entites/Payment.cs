using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        public int Amount { get; set; }

        public DateTime CreateTime { get; set; }

        public int Status { get; set; }

        public string BankId { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public string TrackingCode { get; set; }
    }
}
