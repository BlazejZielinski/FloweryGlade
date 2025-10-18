using FloweryGladeAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace FloweryGladeAPI.Models
{
    public class FlowerShopDTO
    {
        // FlowerShop
        public int FlowerShopID { get; set; }

        [Required]
        [MaxLength(25)]
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }

        // Address
        public string City { get; set; }
        public string? ZipCode { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }

        // Flowers
        public List<Flowers>? Flower { get; set; }
    }
}
