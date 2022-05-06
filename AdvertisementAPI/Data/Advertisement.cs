using System.ComponentModel.DataAnnotations;

namespace AdvertisementAPI.Data
{
    public class Advertisement
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string NewsPaper { get; set; }
        public decimal Price { get; set; }

    }
}
