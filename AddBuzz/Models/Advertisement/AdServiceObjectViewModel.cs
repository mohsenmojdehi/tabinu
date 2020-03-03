using System.ComponentModel.DataAnnotations;
namespace AddBuzz.Models.Advertisement
{
    public class AdServiceObjectViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Price { get; set; }

        public string PageId { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public bool? Garanty { get; set; }

        public string Picture { get; set; }
    }
}
