using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFruitService : IGenericService<Fruit>
    {
        public List<Fruit> GetFruitID(int id);
        public List<Fruit> FruitSearch(string s);
    }
}
