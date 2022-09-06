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
    public class ContactService : IContactService
    {
        IContactDal _contactDal;

        public ContactService(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public List<Contact> ContactSearch(string s)
        {
            return _contactDal.GetListByFilter(x=>x.Name.Contains(s));
        }

        public void Delete(Contact t)
        {
            _contactDal.Remove(t);
        }

        public Contact GetById(int id)
        {
            return _contactDal.GetByID(id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.GetList();
        }

        public void Insert(Contact t)
        {
            _contactDal.Add(t);
        }

        public void Update(Contact t)
        {
            _contactDal.Update(t);
        }
    }
}
