namespace FloweryGladeAPI.Entities
{
    public class Address
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string HouseNo { get; set; }
        public int FlowerShopID { get; set; }
        public FlowerShop FlowerShop { get; set; }
    }
}
