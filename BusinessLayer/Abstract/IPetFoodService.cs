using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPetFoodService : IGenericService<PetFood>
    {
        public List<PetFood> GetPetFoodID(int id);
        public List<PetFood> PetFoodSearch(string s);
    }
}
