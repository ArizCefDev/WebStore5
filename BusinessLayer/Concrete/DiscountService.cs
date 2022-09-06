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
    public class DiscountService : IDiscountService
    {
        IDiscountDal _discountDal;

        public DiscountService(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void Delete(Discount t)
        {
            _discountDal.Remove(t);
        }

        public Discount GetById(int id)
        {
            return _discountDal.GetByID(id);
        }

        public List<Discount> GetList()
        {
            return _discountDal.GetList();
        }

        public void Insert(Discount t)
        {
            _discountDal.Add(t);
        }

        public void Update(Discount t)
        {
            _discountDal.Update(t);
        }

        public List<Discount> GetDiscountID(int id)
        {
            return _discountDal.GetListByFilter(x => x.ID == id);
        }

        public List<Discount> GetCateDiscountID(int id)
        {
            return _discountDal.GetListByFilter(x => x.CategoryID == id);
        }
    }
}
