using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _employeeService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _employeeService.EmployeeSearch(s);
            }
            return View(values.OrderByDescending(x => x.ID));
        }

        [HttpGet]
        public IActionResult EmployeeAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee p)
        {
            p.Status = true;
            _employeeService.Insert(p);
            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public IActionResult EmployeeUpdate(int id)
        {
            var values = _employeeService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EmployeeUpdate(Employee p)
        {
            p.Status = true;
            _employeeService.Update(p);
            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public IActionResult EmployeeDetails(int id)
        {
            var values = _employeeService.GetById(id);
            return View(values);
        }

        public IActionResult EmployeeDelete(int id)
        {
            var values = _employeeService.GetById(id);
            _employeeService.Delete(values);
            return RedirectToAction("Index", "Employee");
        }
    }
}
