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
    public class ClearProductService : IClearProductService
    {
        IClearProductDal _clearProductDal;

        public ClearProductService(IClearProductDal clearProductDal)
        {
            _clearProductDal = clearProductDal;
        }

        public void Delete(ClearProduct t)
        {
            _clearProductDal.Remove(t);
        }

        public ClearProduct GetById(int id)
        {
            return _clearProductDal.GetByID(id);
        }

        public List<ClearProduct> GetList()
        {
            return _clearProductDal.GetList();
        }

        public void Insert(ClearProduct t)
        {
            _clearProductDal.Add(t);
        }

        public void Update(ClearProduct t)
        {
            _clearProductDal.Update(t);
        }

        public List<ClearProduct> GetClearProductID(int id)
        {
            return _clearProductDal.GetListByFilter(x => x.ID == id);
        }

        public List<ClearProduct> CleanProductSearch(string s)
        {
            return _clearProductDal.GetListByFilter(x => x.Name.Contains(s));
        } 
    }
}
