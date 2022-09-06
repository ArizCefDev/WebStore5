using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        public List<Product> GetProductID(int id);
        public List<Product> ProductSearch(string s);
    }
}
