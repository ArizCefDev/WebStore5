using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IClearProductService : IGenericService<ClearProduct>
    {
        public List<ClearProduct> GetClearProductID(int id);
        public List<ClearProduct> CleanProductSearch(string s);
    }
}
