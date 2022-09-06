using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Bakeries
{
    public class BreadList : ViewComponent
    {
        private readonly IBreadService _breadService;

        public BreadList(IBreadService breadService)
        {
            _breadService = breadService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _breadService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
