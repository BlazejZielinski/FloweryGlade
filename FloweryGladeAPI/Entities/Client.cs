namespace FloweryGladeAPI.Entities
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public int FlowerShopID { get; set; }
        public virtual FlowerShop FlowerShop { get; set; }

    }
}
