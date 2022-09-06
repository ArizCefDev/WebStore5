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
    public class FrozenSnackService : IFrozenSnacksService
    {
        IFrozenSnacksDal _frozenNonvegDal;

        public FrozenSnackService(IFrozenSnacksDal frozenNonvegDal)
        {
            _frozenNonvegDal = frozenNonvegDal;
        }

        public void Delete(FrozenSnacks t)
        {
            _frozenNonvegDal.Remove(t);
        }

        public FrozenSnacks GetById(int id)
        {
            return _frozenNonvegDal.GetByID(id);
        }

        public List<FrozenSnacks> GetList()
        {
            return _frozenNonvegDal.GetList();
        }

        public void Insert(FrozenSnacks t)
        {
            _frozenNonvegDal.Add(t);
        }

        public void Update(FrozenSnacks t)
        {
            _frozenNonvegDal.Update(t);
        }

        public List<FrozenSnacks> GetFrozenSnackID(int id)
        {
            return _frozenNonvegDal.GetListByFilter(x => x.ID == id);
        }

        public List<FrozenSnacks> FrozenSnackSearch(string s)
        {
            return _frozenNonvegDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
