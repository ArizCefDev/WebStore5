using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Areas.AdminPanel.ViewComponents.BottomStatistics
{
    public class BottomStatisticList3 : ViewComponent
    {
        private readonly IEmployeeService _employeeService;

        public BottomStatisticList3(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _employeeService.GetList();
            return View(values);
        }
    }
}
