using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.About
{
    public class EmployeeList : ViewComponent
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeList(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _employeeService.GetList();
            return View(values.OrderByDescending(x=>x.ID));
        }
    }
}
