using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHouseHoldService : IGenericService<HouseHold>
    {
        public List<HouseHold> GetHouseHoldID(int id);
        public List<HouseHold> HouseHoldSearch(string s);
    }
}
