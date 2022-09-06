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
    public class JuiceDrinkService : IJuiceDrinkService
    {
        IJuiceDrinkDal _juiceDrinkDal;

        public JuiceDrinkService(IJuiceDrinkDal juiceDrinkDal)
        {
            _juiceDrinkDal = juiceDrinkDal;
        }

        public void Delete(JuiceDrink t)
        {
            _juiceDrinkDal.Remove(t);
        }

        public JuiceDrink GetById(int id)
        {
            return _juiceDrinkDal.GetByID(id);
        }

        public List<JuiceDrink> GetList()
        {
            return _juiceDrinkDal.GetList();
        }

        public void Insert(JuiceDrink t)
        {
            _juiceDrinkDal.Add(t);
        }

        public void Update(JuiceDrink t)
        {
            _juiceDrinkDal.Update(t);
        }

        public List<JuiceDrink> GetJuiceDrinkID(int id)
        {
            return _juiceDrinkDal.GetListByFilter(x => x.ID == id);
        }

        public List<JuiceDrink> JuiceDrinkSearch(string s)
        {
            return _juiceDrinkDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
