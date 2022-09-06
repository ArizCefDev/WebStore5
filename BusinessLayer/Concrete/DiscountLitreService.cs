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
    public class DiscountLitreService : IDiscountLitreService
    {
        IDiscountLitreDal _discountLitreDal;

        public DiscountLitreService(IDiscountLitreDal discountLitreDal)
        {
            _discountLitreDal = discountLitreDal;
        }

        public void Delete(DiscountLitre t)
        {
            _discountLitreDal.Remove(t);
        }

        public DiscountLitre GetById(int id)
        {
            return _discountLitreDal.GetByID(id);
        }

        public List<DiscountLitre> GetList()
        {
            return _discountLitreDal.GetList();
        }

        public void Insert(DiscountLitre t)
        {
            _discountLitreDal.Add(t);
        }

        public void Update(DiscountLitre t)
        {
            _discountLitreDal.Update(t);
        }

        public List<DiscountLitre> GetDiscountLitresID(int id)
        {
            return _discountLitreDal.GetListByFilter(x => x.ID == id);
        }
    }
}
