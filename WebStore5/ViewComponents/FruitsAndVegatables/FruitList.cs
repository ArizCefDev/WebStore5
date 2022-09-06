using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.FruitsAndVegatables
{
    public class FruitList : ViewComponent
    {
        private readonly IFruitService _fruitService;

        public FruitList(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _fruitService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
