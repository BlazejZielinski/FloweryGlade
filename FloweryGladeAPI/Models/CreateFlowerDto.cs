using System.ComponentModel.DataAnnotations;

namespace FloweryGladeAPI.Models
{
    public class CreateFlowerDto
    {
        [Required]
        public string FlowerName { get; set; }
        public double FlowerPrice { get; set; }
        public int FlowerShopID { get; set; }
    }
}
