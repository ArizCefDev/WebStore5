using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductService : IProductService
    {
        IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Delete(Product t)
        {
            _productDal.Remove(t);
        }

        public Product GetById(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetList();
        }

        public void Insert(Product t)
        {
            _productDal.Add(t);
        }

        public void Update(Product t)
        {
            _productDal.Update(t);
        }

        public List<Product> GetProductID(int id)
        {
            return _productDal.GetListByFilter(x => x.ID == id);
        }

        public List<Product> ProductSearch(string s)
        {
            return _productDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
