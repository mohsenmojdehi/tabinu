using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class Account_Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
