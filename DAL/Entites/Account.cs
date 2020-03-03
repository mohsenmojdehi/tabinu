using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public string FullName { get; set; }
        [MaxLength(14)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string OtherContact { get; set; }
        public int Wallet { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Enable { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }

        public string ProfilePicture { get; set; }

        public virtual ICollection<Account_Tag> Account_Tag { get; set; }

        public virtual ICollection<AdvertisementPlan> AdvertisementServices { get; set; }

        public virtual ICollection<GraphicDesigningPlan> GraphicDesigningServices { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
