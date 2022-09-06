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
    public class FishService : IFishService
    {
        IFishDal _fishDal;

        public FishService(IFishDal fishDal)
        {
            _fishDal = fishDal;
        }

        public void Delete(Fish t)
        {
            _fishDal.Remove(t);
        }

        public Fish GetById(int id)
        {
            return _fishDal.GetByID(id);
        }

        public List<Fish> GetList()
        {
            return _fishDal.GetList();
        }

        public void Insert(Fish t)
        {
            _fishDal.Add(t);
        }

        public void Update(Fish t)
        {
            _fishDal.Update(t);
        }

        public List<Fish> GetFishID(int id)
        {
            return _fishDal.GetListByFilter(x => x.ID == id);
        }

        public List<Fish> FishSearch(string s)
        {
            return _fishDal.GetListByFilter(x => x.Name.Contains(s)); ;
        }
    }
}
