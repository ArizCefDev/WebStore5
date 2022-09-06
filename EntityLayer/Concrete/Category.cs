using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<HouseHold> HouseHolds { get; set; }
        public List<Fruit> Fruits { get; set; }
        public List<Vegatable> Vegatables { get; set; }
        public List<Cereal> Cereals { get; set; }
        public List<Meat> Meats { get; set; }
        public List<Chicken> Chickens { get; set; }
        public List<Fish> Fish { get; set; }
        public List<SoftDrink> SoftDrinks { get; set; }
        public List<JuiceDrink> JuiceDrinks { get; set; }
        public List<FrozenSnacks> FrozenSnacks { get; set; }
        public List<FrozenNonveg> FrozenNonvegs { get; set; }
        public List<Bread> Breads { get; set; }
        public List<Sweet> Sweets { get; set; }
        public List<PetFood> PetFoods { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<DiscountLitre> DiscountLitres { get; set; }
        public List<Product> Products { get; set; }
        public List<ClearProduct> ClearProducts { get; set; }
    }
}
