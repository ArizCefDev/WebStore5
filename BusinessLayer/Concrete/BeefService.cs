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
    public class BeefService : IBeeftService
    {
        IBeefDal _beefDal;

        public BeefService(IBeefDal beefDal)
        {
            _beefDal = beefDal;
        }

        public void Delete(Meat t)
        {
            _beefDal.Remove(t);
        }

        public Meat GetById(int id)
        {
            return _beefDal.GetByID(id);
        }

        public List<Meat> GetList()
        {
            return _beefDal.GetList();
        }

        public void Insert(Meat t)
        {
            _beefDal.Add(t);
        }

        public void Update(Meat t)
        {
            _beefDal.Update(t);
        }

        public List<Meat> GetBeefID(int id)
        {
            return _beefDal.GetListByFilter(x => x.ID == id);
        }

        public List<Meat> BeefSearch(string s)
        {
            return _beefDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
