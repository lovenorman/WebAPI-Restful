using System.ComponentModel.DataAnnotations;

namespace WebAPI_Restful_.Data
{
    public class Advertisement
    {
        public int Id { get; set; }

        [MaxLength(15)]
        public string Title { get; set; }
        public string Author { get; set; }
        public string CreateDate { get; set; }
        
        [MaxLength(100)]
        public string Description { get; set; } 
    }
}
