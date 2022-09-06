using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Meats
{
    public class BeefList : ViewComponent
    {
        private readonly IBeeftService _beeftService;

        public BeefList(IBeeftService beeftService)
        {
            _beeftService = beeftService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _beeftService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
