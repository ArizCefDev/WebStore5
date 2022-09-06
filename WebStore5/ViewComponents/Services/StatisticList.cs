using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Services
{
    public class StatisticList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            ViewBag.discount = c.Discounts.Count().ToString();
            ViewBag.employee = c.Employees.Count().ToString();
            return View();
        }
    }
}
