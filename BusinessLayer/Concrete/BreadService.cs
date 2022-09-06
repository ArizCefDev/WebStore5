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
    public class BreadService : IBreadService
    {
        IBreadDal _breadDal;

        public BreadService(IBreadDal breadDal)
        {
            _breadDal = breadDal;
        }

        public void Delete(Bread t)
        {
            _breadDal.Remove(t);
        }

        public Bread GetById(int id)
        {
            return _breadDal.GetByID(id);
        }

        public List<Bread> GetList()
        {
            return _breadDal.GetList();
        }

        public void Insert(Bread t)
        {
            _breadDal.Add(t);
        }

        public void Update(Bread t)
        {
            _breadDal.Update(t);
        }

        public List<Bread> GetBreadID(int id)
        {
            return _breadDal.GetListByFilter(x => x.ID == id);
        }

        public List<Bread> BreadSearch(string s)
        {
            return _breadDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
