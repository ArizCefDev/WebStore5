using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class PetFoodController : Controller
    {
        private readonly IPetFoodService _petFoodService;

        public PetFoodController(IPetFoodService petFoodService)
        {
            _petFoodService = petFoodService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PetFoodDetails(int id)
        {
            ViewBag.i = id;
            var values = _petFoodService.GetPetFoodID(id);
            return View(values);
        } 
    }
}
