using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Default
{
    public class Posters : ViewComponent
    {
        private readonly IPosterService _posterService;

        public Posters(IPosterService posterService)
        {
            _posterService = posterService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _posterService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
