using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISweetService : IGenericService<Sweet>
    {
        public List<Sweet> GetSweetID(int id);
        public List<Sweet> SweetSearch(string s);
    }
}
