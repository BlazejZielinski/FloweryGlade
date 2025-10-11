using System.ComponentModel.DataAnnotations;

namespace FloweryGladeAPI.Models
{
    public class UpdateFlowerShopDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
}
