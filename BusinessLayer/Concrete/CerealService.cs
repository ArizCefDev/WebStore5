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
    public class CerealService : ICerealService
    {
        ICerealDal _cerealDal;

        public CerealService(ICerealDal cerealDal)
        {
            _cerealDal = cerealDal;
        }

        public void Delete(Cereal t)
        {
            _cerealDal.Remove(t);
        }

        public Cereal GetById(int id)
        {
            return _cerealDal.GetByID(id);
        }

        public List<Cereal> GetList()
        {
            return _cerealDal.GetList();
        }

        public void Insert(Cereal t)
        {
            _cerealDal.Add(t);
        }

        public void Update(Cereal t)
        {
            _cerealDal.Update(t);
        }

        public List<Cereal> GetCerealID(int id)
        {
            return _cerealDal.GetListByFilter(x => x.ID == id);
        }

        public List<Cereal> CerealSearch(string s)
        {
            return _cerealDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
