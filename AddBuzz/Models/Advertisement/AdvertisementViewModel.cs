using System.Collections.Generic;
using DAL.Entites;

namespace AddBuzz.Models.Advertisement
{
    public class AdvertisementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string PageAddress { get; set; }

        public int Viewer { get; set; }

        public string Picture { get; set; }

        public int UserId { get; set; }

        public List<Page> OtherPages { get; set; }

        public List<Advertisement_Tag> Tages { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
