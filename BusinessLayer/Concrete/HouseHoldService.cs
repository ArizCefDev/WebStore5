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
    public class HouseHoldService : IHouseHoldService
    {
        IHouseHoldDal _houseHoldDal;

        public HouseHoldService(IHouseHoldDal houseHoldDal)
        {
            _houseHoldDal = houseHoldDal;
        }

        public void Delete(HouseHold t)
        {
            _houseHoldDal.Remove(t);
        }

        public HouseHold GetById(int id)
        {
            return _houseHoldDal.GetByID(id);
        }

        public List<HouseHold> GetList()
        {
            return _houseHoldDal.GetList();
        }

        public void Insert(HouseHold t)
        {
            _houseHoldDal.Add(t);
        }

        public void Update(HouseHold t)
        {
            _houseHoldDal.Update(t);
        }

        public List<HouseHold> GetHouseHoldID(int id)
        {
            return _houseHoldDal.GetListByFilter(x=>x.ID==id);
        }

        public List<HouseHold> HouseHoldSearch(string s)
        {
            return _houseHoldDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
