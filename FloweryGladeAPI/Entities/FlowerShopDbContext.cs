using Microsoft.EntityFrameworkCore;

namespace FloweryGladeAPI.Entities
{
    public class FlowerShopDbContext : DbContext
    {
        private string _conString = "Server=BLASIUS2086\\SQLEXPRESS;Database=FloweryGlade;" +
            "User ID=sa;Password=admin!@#;TrustServerCertificate=true";

        //private string envConString = Environment.GetEnvironmentVariable("DotNet_ConnectionString",
        //    EnvironmentVariableTarget.User) + "TrustServerCertificate=true";

        public DbSet<FlowerShop> FlowerShops { get; set; }
        public DbSet<Flowers> Flowers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresss { get; set; }

        // setting requirements for columns in database for indicated
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlowerShop>()
                //.Property(f => f.FlowerShopID)
                .HasOne(f => f.Address)
                .WithOne(f => f.FlowerShop)
                .HasForeignKey<Address>(a => a.FlowerShopID)
                .IsRequired();
                //.HasMaxLength(200);
            modelBuilder.Entity<Address>()
                //.Property(f => f.FlowerShopID)
                .HasOne(a => a.FlowerShop)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(a => a.FlowerShopID)
                .IsRequired();
                //.HasMaxLength(200);
            //modelBuilder.Entity<FlowerShop>()
            //    .Property(f => f.FlowerShopID)
            //    .HasMaxLength(200);

            modelBuilder.Entity<Flowers>()
                .Property(f => f.FlowerName)
                .IsRequired();
            
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_conString);
        }

    }
}
