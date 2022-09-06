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
    public class ChickenService : IChickenService
    {
        IChickenDal _chickenDal;

        public ChickenService(IChickenDal chickenDal)
        {
            _chickenDal = chickenDal;
        }

        public void Delete(Chicken t)
        {
            _chickenDal.Remove(t);
        }

        public Chicken GetById(int id)
        {
            return _chickenDal.GetByID(id);
        }

        public List<Chicken> GetList()
        {
            return _chickenDal.GetList();
        }

        public void Insert(Chicken t)
        {
            _chickenDal.Add(t);
        }

        public void Update(Chicken t)
        {
            _chickenDal.Update(t);
        }

        public List<Chicken> GetChickenID(int id)
        {
            return _chickenDal.GetListByFilter(x => x.ID == id);
        }

        public List<Chicken> ChickenSearch(string s)
        {
            return _chickenDal.GetListByFilter(x=>x.Name.Contains(s));
        }
    }
}
