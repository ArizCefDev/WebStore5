using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.FrozenFoods
{
    public class FrozenSnackList : ViewComponent
    {
        private readonly IFrozenSnacksService _frozenSnacksService;

        public FrozenSnackList(IFrozenSnacksService frozenSnacksService)
        {
            _frozenSnacksService = frozenSnacksService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _frozenSnacksService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
