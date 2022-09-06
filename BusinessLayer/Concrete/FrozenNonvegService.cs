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
    public class FrozenNonvegService : IFrozenNonvegService
    {
        IFrozenNonvegDal _frozenNonvegDal;

        public FrozenNonvegService(IFrozenNonvegDal frozenNonvegDal)
        {
            _frozenNonvegDal = frozenNonvegDal;
        }

        public void Delete(FrozenNonveg t)
        {
            _frozenNonvegDal.Remove(t);
        }

        public FrozenNonveg GetById(int id)
        {
            return _frozenNonvegDal.GetByID(id);
        }

        public List<FrozenNonveg> GetList()
        {
            return _frozenNonvegDal.GetList();
        }

        public void Insert(FrozenNonveg t)
        {
            _frozenNonvegDal.Add(t);
        }

        public void Update(FrozenNonveg t)
        {
            _frozenNonvegDal.Update(t);
        }

        public List<FrozenNonveg> GetFrozenNonvegID(int id)
        {
            return _frozenNonvegDal.GetListByFilter(x => x.ID == id);
        }

        public List<FrozenNonveg> FrozenNonvegSearch(string s)
        {
            return _frozenNonvegDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
