using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Meats
{
    public class ChickenList : ViewComponent
    {
        private readonly IChickenService _chickenService;

        public ChickenList(IChickenService chickenService)
        {
            _chickenService = chickenService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _chickenService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
