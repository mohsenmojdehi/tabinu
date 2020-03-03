using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class Tag
    {
        public Tag()
        {
            this.Advertisement_Tags = new HashSet<Advertisement_Tag>();
            this.GraphicDesigningService_Tags = new HashSet<GraphicDesigningPlan_Tag>();
            this.Account_Tags = new HashSet<Account_Tag>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? CreateTime { get; set; }

        public virtual ICollection<Advertisement_Tag> Advertisement_Tags { get; set; }

        public virtual ICollection<GraphicDesigningPlan_Tag> GraphicDesigningService_Tags { get; set; }

        public virtual ICollection<Account_Tag> Account_Tags { get; set; }
    }
}
