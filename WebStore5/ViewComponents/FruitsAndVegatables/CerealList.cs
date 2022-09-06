using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.FruitsAndVegatables
{
    public class CerealList : ViewComponent
    {
        private readonly ICerealService _cerealService;

        public CerealList(ICerealService cerealService)
        {
            _cerealService = cerealService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _cerealService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
