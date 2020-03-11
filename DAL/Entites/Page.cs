using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public Account Account { get; set; }

        public string PageName { get; set; }

        public string PageAddress { get; set; }

        public string PageCategory { get; set; }

        public int FollowersNumber { get; set; }

        public bool? IsBasePage { get; set; }

        [MaxLength(1000)]
        public string Description { get;set; }

        public string Logo { get; set; }

        public int? AreaId { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
