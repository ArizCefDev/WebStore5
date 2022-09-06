using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBreadService : IGenericService<Bread>
    {
        public List<Bread> GetBreadID(int id);
        public List<Bread> BreadSearch(string s);
    }
}
