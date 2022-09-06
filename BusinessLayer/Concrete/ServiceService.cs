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
    public class ServiceService : IServicesService
    {
        IServiceDal _serviceDal;

        public ServiceService(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Delete(Service t)
        {
            _serviceDal.Remove(t);
        }

        public Service GetById(int id)
        {
            return _serviceDal.GetByID(id);
        }

        public List<Service> GetList()
        {
            return _serviceDal.GetList();
        }

        public void Insert(Service t)
        {
            _serviceDal.Add(t);
        }

        public void Update(Service t)
        {
            _serviceDal.Update(t);
        }
    }
}
