using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IJuiceDrinkService : IGenericService<JuiceDrink>
    {
        public List<JuiceDrink> GetJuiceDrinkID(int id);
        public List<JuiceDrink> JuiceDrinkSearch(string s);

    }
}
