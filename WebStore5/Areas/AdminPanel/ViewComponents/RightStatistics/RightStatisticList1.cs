using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.Areas.AdminPanel.ViewComponents.RightStatistics
{
    public class RightStatisticList1 : ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.household = context.HouseHolds.Count();
            ViewBag.petfood = context.PetFoods.Count();
            return View();
        }
    }
}
