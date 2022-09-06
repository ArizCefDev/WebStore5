using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISoftDrinkService : IGenericService<SoftDrink>
    {
        public List<SoftDrink> GetSoftDrinkID(int id);
        public List<SoftDrink> SearchSoftDrink(string s);
    }
}
