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
    public class SweetService : ISweetService
    {
        ISweetDal _sweetDal;

        public SweetService(ISweetDal sweetDal)
        {
            _sweetDal = sweetDal;
        }

        public void Delete(Sweet t)
        {
            _sweetDal.Remove(t);
        }

        public Sweet GetById(int id)
        {
            return _sweetDal.GetByID(id);
        }

        public List<Sweet> GetList()
        {
            return _sweetDal.GetList();
        }

        public void Insert(Sweet t)
        {
            _sweetDal.Add(t);
        }

        public void Update(Sweet t)
        {
            _sweetDal.Update(t);
        }

        public List<Sweet> GetSweetID(int id)
        {
            return _sweetDal.GetListByFilter(x => x.ID == id);
        }

        public List<Sweet> SweetSearch(string s)
        {
            return _sweetDal.GetListByFilter(x=>x.Name.Contains(s));
        }
    }
}
