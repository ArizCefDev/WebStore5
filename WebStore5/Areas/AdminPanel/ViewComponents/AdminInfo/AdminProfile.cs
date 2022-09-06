using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Areas.AdminPanel.ViewComponents.AdminInfo
{
    public class AdminProfile : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
