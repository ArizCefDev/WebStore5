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
    public class FruitService : IFruitService
    {
        IFruitDal _fruitDal;

        public FruitService(IFruitDal fruitDal)
        {
            _fruitDal = fruitDal;
        }

        public void Delete(Fruit t)
        {
            _fruitDal.Remove(t);
        }

        public Fruit GetById(int id)
        {
            return _fruitDal.GetByID(id);
        }

        public List<Fruit> GetList()
        {
            return _fruitDal.GetList();
        }

        public void Insert(Fruit t)
        {
            _fruitDal.Add(t);
        }

        public void Update(Fruit t)
        {
            _fruitDal.Update(t);
        }

        public List<Fruit> GetFruitID(int id)
        {
            return _fruitDal.GetListByFilter(x => x.ID == id);
        }

        public List<Fruit> FruitSearch(string s)
        {
            return _fruitDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
