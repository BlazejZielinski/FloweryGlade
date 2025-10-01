namespace FloweryGladeAPI.Entities
{
    public class FlowerShop
    {
        public int FlowerShopID { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
        public List<Flowers>? Flower { get; set; }
        public int UserID { get; set; }
        public virtual List<User> Users { get; set; }
        public int ClientID { get; set; }
        public virtual List<Client> Clients { get; set; }
    }
}
