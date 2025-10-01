namespace FloweryGladeAPI.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public int FlowerShopID { get; set; }
        public virtual FlowerShop FlowerShop { get; set; }
    }
}
