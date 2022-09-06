using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace WebStore5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class PetFoodsController : Controller
    {
        private readonly IPetFoodService _petFoodService;
        private readonly ICategoryService _categoryService;

        public PetFoodsController(IPetFoodService petFoodService, ICategoryService categoryService)
        {
            _petFoodService = petFoodService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _petFoodService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _petFoodService.PetFoodSearch(s);
            }
            return View(values.OrderByDescending(x => x.ID));
        }

        [HttpGet]
        public IActionResult PetFoodAdd()
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View();
        }

        [HttpPost]
        public IActionResult PetFoodAdd(PetFood p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _petFoodService.Insert(p);
            return RedirectToAction("Index", "PetFoods");
        }

        [HttpGet]
        public IActionResult PetFoodUpdate(int id)
        {
            var values = _petFoodService.GetById(id);
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        [HttpPost]
        public IActionResult PetFoodUpdate(PetFood p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _petFoodService.Update(p);
            return RedirectToAction("Index", "PetFoods");
        }

        [HttpGet]
        public IActionResult PetFoodDetails(int id)
        {
            var values = _petFoodService.GetById(id);
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        public IActionResult PetFoodDelete(int id)
        {
            var values = _petFoodService.GetById(id);
            _petFoodService.Delete(values);
            return RedirectToAction("Index", "PetFoods");
        }
    }
}
