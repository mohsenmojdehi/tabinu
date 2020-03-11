using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(60)]
        public string Username { get; set; }

        [MaxLength(60)]
        public string Password { get; set; }

        [MaxLength(60)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Role { get; set; }
       
        public Account Account { get; set; }

        public string Token { get; set; }
    }
}
