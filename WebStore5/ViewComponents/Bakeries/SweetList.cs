using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Bakeries
{
    public class SweetList : ViewComponent
    {
        private readonly ISweetService _sweetService;

        public SweetList(ISweetService sweetService)
        {
            _sweetService = sweetService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _sweetService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
