using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Drinks
{
    public class SoftDrinkList : ViewComponent
    {
        private readonly ISoftDrinkService _softDrinkService;

        public SoftDrinkList(ISoftDrinkService softDrinkService)
        {
            _softDrinkService = softDrinkService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _softDrinkService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
