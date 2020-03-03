using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entites
{
   public class GraphicDesigningPlan_Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GraphicDesigningServiceId { get; set; }

        public GraphicDesigningPlan GraphicDesigningPlan { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
