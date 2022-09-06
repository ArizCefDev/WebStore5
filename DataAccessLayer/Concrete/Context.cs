using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=WIN-V45TJ7IL2H4; database=WebStoreDB; integrated security=true;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Bread> Breads { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cereal> Cereals { get; set; }
        public DbSet<Chicken> Chickens { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountLitre> DiscountLitres { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<FrozenNonveg> FrozenNonvegs { get; set; }
        public DbSet<FrozenSnacks> FrozenSnacks { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<HouseHold> HouseHolds { get; set; }
        public DbSet<JuiceDrink> JuiceDrinks { get; set; }
        public DbSet<Meat> Meats { get; set; }
        public DbSet<PetFood> PetFoods { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SoftDrink> SoftDrinks { get; set; }
        public DbSet<Sweet> Sweets { get; set; }
        public DbSet<Vegatable> Vegatables { get; set; }
    }
}
