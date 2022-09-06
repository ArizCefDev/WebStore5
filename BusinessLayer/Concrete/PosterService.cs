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
    public class PosterService : IPosterService
    {
        IPosterDal _posterDal;

        public PosterService(IPosterDal posterDal)
        {
            _posterDal = posterDal;
        }

        public void Delete(Poster t)
        {
            _posterDal.Remove(t);
        }

        public Poster GetById(int id)
        {
            return _posterDal.GetByID(id);
        }

        public List<Poster> GetList()
        {
            return _posterDal.GetList();
        }

        public void Insert(Poster t)
        {
            _posterDal.Add(t);
        }

        public void Update(Poster t)
        {
            _posterDal.Update(t);
        }
    }
}
