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
    public class FruitController : Controller
    {
        private readonly IFruitService _fruitService;
        private readonly ICategoryService _categoryService;

        public FruitController(IFruitService fruitService, ICategoryService categoryService)
        {
            _fruitService = fruitService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _fruitService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _fruitService.FruitSearch(s);
            }
            return View(values.OrderByDescending(x => x.ID));
        }

        [HttpGet]
        public IActionResult FruitAdd()
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
        public IActionResult FruitAdd(Fruit p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _fruitService.Insert(p);
            return RedirectToAction("Index", "Fruit");
        }

        [HttpGet]
        public IActionResult FruitUpdate(int id)
        {
            var values = _fruitService.GetById(id);
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
        public IActionResult FruitUpdate(Fruit p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _fruitService.Update(p);
            return RedirectToAction("Index", "Fruit");
        }

        [HttpGet]
        public IActionResult FruitDetails(int id)
        {
            var values = _fruitService.GetById(id);
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        public IActionResult FruitDelete(int id)
        {
            var values = _fruitService.GetById(id);
            _fruitService.Delete(values);
            return RedirectToAction("Index", "Fruit");
        }
    }
}
