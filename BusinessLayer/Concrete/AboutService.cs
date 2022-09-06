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
    public class AboutService : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutService(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Delete(About t)
        {
            _aboutDal.Remove(t);
        }

        public About GetById(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public List<About> GetList()
        {
            return _aboutDal.GetList();
        }

        public void Insert(About t)
        {
            _aboutDal.Add(t);
        }

        public void Update(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
