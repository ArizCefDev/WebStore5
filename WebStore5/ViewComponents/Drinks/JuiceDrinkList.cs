using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Drinks
{
    public class JuiceDrinkList : ViewComponent
    {
        private readonly IJuiceDrinkService _juiceDrinkService;

        public JuiceDrinkList(IJuiceDrinkService juiceDrinkService)
        {
            _juiceDrinkService = juiceDrinkService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _juiceDrinkService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
