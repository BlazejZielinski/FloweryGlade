using FloweryGladeAPI.Entities;
using FloweryGladeAPI.Models;

namespace FloweryGladeAPI
{
    public class FloweryGladeSeeder
    {
        private FlowerShopDbContext _dbContext;

        public FloweryGladeSeeder(FlowerShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.FlowerShops.Any())
                {
                    var flowerShops = GetFlowerShops();
                    _dbContext.FlowerShops.AddRange(flowerShops);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<FlowerShop> GetFlowerShops()
        {
           
            var flowerShops = new List<FlowerShop>()
            {
                new FlowerShop()
                {
                    //FlowerShopID = 1,
                    Name = "Goździkowo",
                    PhoneNo = "896462031",
                    //AddressID = 01,0
                    Address =new Address()
                    {
                        City = "Warszawa",
                        ZipCode = "01-002",
                        Street = "Bukowa",
                        HouseNo = "13",
                        //FlowerShopID = 1
                    },
                    Flower = new List<Flowers>()
                    {
                        new Flowers()
                        {
                            FlowerName = "goździk",
                            FlowerPrice = 8,
                        },
                        new Flowers()
                        {
                            FlowerName = "Tulipan",
                            FlowerPrice = 13,
                        }
                    },
                    //UserID = 001,
                    Users = new List<User>()
                    {
                        new User()
                        {
                            UserName = "Karolina",
                            UserLastName = "Busz"
                        }
                    },
                    //ClientID = 1369,
                    Clients = new List<Client>()
                    {
                        new Client()
                        {
                            Name = "Stanisław",
                            Surname = "Dziąsło",
                            FullName = "",
                            //FlowerShopID = 1
                            
                        }
                    }
                },
                new FlowerShop()
                {
                    //FlowerShopID = 1,
                    Name = "Goździkowo",
                    PhoneNo = "896462031",
                    //AddressID = 01,
                    Address =new Address()
                    {
                        City = "Gdańsk",
                        ZipCode = "80-002",
                        Street = "Portowa",
                        HouseNo = "19",
                        //FlowerShopID = 1
                    },
                    Flower = new List<Flowers>()
                    {
                        new Flowers()
                        {
                            FlowerName = "Stokrotka",
                            FlowerPrice = 4,
                        },
                        new Flowers()
                        {
                            FlowerName = "Lilia",
                            FlowerPrice = 13,
                        }
                    },
                    //UserID = 001,
                    Users = new List<User>()
                    {
                        new User()
                        {
                            UserName = "Sebastian",
                            UserLastName = "Szujawiec"
                        }
                    },
                    //ClientID = 1369,
                    Clients = new List<Client>()
                    {
                        new Client()
                        {
                            Name = "Anna",
                            Surname = "Dziegieć",
                            FullName = "Watching You",
                            //FlowerShopID = 1
                            
                        }
                    }
                }

            };
            return flowerShops;
        }

        
    }
}
