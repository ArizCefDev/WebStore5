using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFishService : IGenericService<Fish>
    {
        public List<Fish> GetFishID(int id);
        public List<Fish> FishSearch(string s);
    }
}
