using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.ViewComponents.Services
{
    //Catdirilma
    public class DeliveryList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
