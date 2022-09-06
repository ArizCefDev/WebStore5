using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Areas.AdminPanel.ViewComponents.DashboardStatistics
{
    public class AdminDashboard : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
