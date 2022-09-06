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
    public class VegatableService : IVegaTableService
    {
        IVegatableDal _vegatableDal;

        public VegatableService(IVegatableDal vegatableDal)
        {
            _vegatableDal = vegatableDal;
        }

        public void Delete(Vegatable t)
        {
            _vegatableDal.Remove(t);
        }

        public Vegatable GetById(int id)
        {
            return _vegatableDal.GetByID(id);
        }

        public List<Vegatable> GetList()
        {
            return _vegatableDal.GetList();
        }

        public void Insert(Vegatable t)
        {
            _vegatableDal.Add(t);
        }

        public void Update(Vegatable t)
        {
            _vegatableDal.Update(t);
        }

        public List<Vegatable> GetVegatablesID(int id)
        {
            return _vegatableDal.GetListByFilter(x => x.ID == id);
        }

        public List<Vegatable> VegatableSearch(string s)
        {
            return _vegatableDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
