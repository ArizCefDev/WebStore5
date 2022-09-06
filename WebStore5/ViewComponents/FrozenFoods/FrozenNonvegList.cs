using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.FrozenFoods
{
    public class FrozenNonvegList : ViewComponent
    {
        private readonly IFrozenNonvegService _frozenNonvegService;

        public FrozenNonvegList(IFrozenNonvegService frozenNonvegService)
        {
            _frozenNonvegService = frozenNonvegService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _frozenNonvegService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
