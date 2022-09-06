using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFrozenNonvegService : IGenericService<FrozenNonveg>
    {
        public List<FrozenNonveg> GetFrozenNonvegID(int id);
        public List<FrozenNonveg> FrozenNonvegSearch(string s);
    }
}
