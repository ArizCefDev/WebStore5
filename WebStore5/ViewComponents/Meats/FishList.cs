using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Meats
{
    public class FishList : ViewComponent
    {
        private readonly IFishService _fishService;

        public FishList(IFishService fishService)
        {
            _fishService = fishService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _fishService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
