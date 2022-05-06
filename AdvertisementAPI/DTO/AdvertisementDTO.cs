using System.ComponentModel.DataAnnotations;
using AdvertisementAPI.Data;

namespace AdvertisementAPI.DTO
{
    public class AdvertisementDTO
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string NewsPaper { get; set; }
        public decimal Price { get; set; }

        
    }
}
