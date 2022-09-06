using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.CleanProducts
{
    public class CleanProductList : ViewComponent
    {
        private readonly IClearProductService _clearProductService;

        public CleanProductList(IClearProductService clearProductService)
        {
            _clearProductService = clearProductService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _clearProductService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
