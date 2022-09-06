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
    public class SoftDrinkService : ISoftDrinkService
    {
        ISoftDrinkDal _softDrinkDal;

        public SoftDrinkService(ISoftDrinkDal softDrinkDal)
        {
            _softDrinkDal = softDrinkDal;
        }

        public void Delete(SoftDrink t)
        {
            _softDrinkDal.Remove(t);
        }

        public SoftDrink GetById(int id)
        {
            return _softDrinkDal.GetByID(id);
        }

        public List<SoftDrink> GetList()
        {
            return _softDrinkDal.GetList();
        }

        public void Insert(SoftDrink t)
        {
            _softDrinkDal.Add(t);
        }

        public void Update(SoftDrink t)
        {
            _softDrinkDal.Update(t);
        }

        public List<SoftDrink> GetSoftDrinkID(int id)
        {
            return _softDrinkDal.GetListByFilter(x => x.ID == id);
        }

        public List<SoftDrink> SearchSoftDrink(string s)
        {
            return _softDrinkDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
