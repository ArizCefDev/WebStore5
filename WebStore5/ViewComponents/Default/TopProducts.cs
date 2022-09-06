using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Default
{
    public class TopProducts : ViewComponent
    {
        PosterService ps = new PosterService(new EfPosterRepository());
        public IViewComponentResult Invoke()
        {
            var values = ps.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
