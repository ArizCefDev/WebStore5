using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IChickenService : IGenericService<Chicken>
    {
        public List<Chicken> GetChickenID(int id);
        public List<Chicken> ChickenSearch(string s);
    }
}
