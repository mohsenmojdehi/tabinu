using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class GraphicDesigningPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int? Price { get; set; }

        public string Sample1 { get; set; }

        public string Sample2 { get; set; }

        public string Sample3 { get; set; }

        public bool Enable { get; set; }

        public virtual ICollection<OrderOption> OrderOptions { get; set; }

        public virtual ICollection<GraphicDesigningPlan_Tag> GraphicDesigningService_Tags { get; set; }
    }
}
