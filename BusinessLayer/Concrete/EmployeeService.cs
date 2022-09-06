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
    public class EmployeeService : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeService(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void Delete(Employee t)
        {
            _employeeDal.Remove(t);
        }

        public List<Employee> EmployeeSearch(string s)
        {
            return _employeeDal.GetListByFilter(x=>x.Name.Contains(s));
        }

        public Employee GetById(int id)
        {
            return _employeeDal.GetByID(id);
        }

        public List<Employee> GetList()
        {
            return _employeeDal.GetList();
        }

        public void Insert(Employee t)
        {
            _employeeDal.Add(t);
        }

        public void Update(Employee t)
        {
            _employeeDal.Update(t);
        }
    }
}
