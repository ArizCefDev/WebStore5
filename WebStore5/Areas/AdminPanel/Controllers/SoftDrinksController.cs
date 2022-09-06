using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace WebStore5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SoftDrinksController : Controller
    {
        private readonly ISoftDrinkService _softDrinkService;
        private readonly ICategoryService _categoryService;

        public SoftDrinksController(ISoftDrinkService softDrinkService, ICategoryService categoryService)
        {
            _softDrinkService = softDrinkService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = _softDrinkService.GetList();
            if (!string.IsNullOrEmpty(s))
            {
                values = _softDrinkService.SearchSoftDrink(s);
            }
            return View(values.OrderByDescending(x=>x.ID));
        }

        [HttpGet]
        public IActionResult SoftDrinkAdd()
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
        public IActionResult SoftDrinkAdd(SoftDrink p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _softDrinkService.Insert(p);
            return RedirectToAction("Index", "SoftDrinks");
        }

        [HttpGet] 
        public IActionResult SoftDrinkUpdate(int id)
        {
            var values = _softDrinkService.GetById(id);
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
        public IActionResult SoftDrinkUpdate(SoftDrink p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _softDrinkService.Update(p);
            return RedirectToAction("Index", "SoftDrinks");
        }

        [HttpGet]
        public IActionResult SoftDrinkDetails(int id)
        {
            var values = _softDrinkService.GetById(id);
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        public IActionResult SoftDrinkDelete(int id)
        {
            var values = _softDrinkService.GetById(id);
            _softDrinkService.Delete(values);
            return RedirectToAction("Index", "SoftDrinks");
        }

        
    }
}
