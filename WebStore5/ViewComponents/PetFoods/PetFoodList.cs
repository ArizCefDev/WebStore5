using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.PetFoods
{
    public class PetFoodList : ViewComponent
    {
        private readonly IPetFoodService _petFoodService;

        public PetFoodList(IPetFoodService petFoodService)
        {
            _petFoodService = petFoodService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _petFoodService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
