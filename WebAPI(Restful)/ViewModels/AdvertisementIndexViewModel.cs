using System.ComponentModel.DataAnnotations;

namespace WebAPI_Restful_.ViewModels
{
    public class AdvertisementIndexViewModel
    {
        public List<AdvertisementIndexItemViewModel> Advertisements { get; set; } 
        
        public class AdvertisementIndexItemViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string CreateDate { get; set; }

            [MaxLength(100)]
            public string Description { get; set; }
        }
    }
}
