namespace FloweryGladeAPI.Models
{
    public class CreateFlowerShopDto
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }

        // Address
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
}
