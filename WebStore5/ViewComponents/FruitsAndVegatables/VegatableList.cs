using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.FruitsAndVegatables
{
    public class VegatableList : ViewComponent
    {
        private readonly IVegaTableService _vegaTableService;

        public VegatableList(IVegaTableService vegaTableService)
        {
            _vegaTableService = vegaTableService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _vegaTableService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
