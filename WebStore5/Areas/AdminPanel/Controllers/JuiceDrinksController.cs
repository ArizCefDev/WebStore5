using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace WebStore5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class JuiceDrinksController : Controller
    {
        private readonly IJuiceDrinkService _juiceDrinkService;
        private readonly ICategoryService _categoryService;

        public JuiceDrinksController(IJuiceDrinkService juiceDrinkService, ICategoryService categoryService)
        {
            _juiceDrinkService = juiceDrinkService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _juiceDrinkService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _juiceDrinkService.JuiceDrinkSearch(s);
            }
            return View(values.OrderByDescending(x=>x.ID));
        }

        [HttpGet]
        public IActionResult JuiceDrinkAdd()
        {
            IEnumerable<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.c = valueGet;
            return View();
        }

        [HttpPost]
        public IActionResult JuiceDrinkAdd(JuiceDrink p)
        {
            IEnumerable<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _juiceDrinkService.Insert(p);
            return RedirectToAction("Index", "JuiceDrinks");
        }

        [HttpGet]
        public IActionResult JuiceDrinkUpdate(int id)
        {
            var values = _juiceDrinkService.GetById(id);
            IEnumerable<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        [HttpPost]
        public IActionResult JuiceDrinkUpdate(JuiceDrink p)
        {
            IEnumerable<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _juiceDrinkService.Update(p);
            return RedirectToAction("Index", "JuiceDrinks");
        }

        [HttpGet]
        public IActionResult JuiceDrinkDetails(int id)
        {
            var values = _juiceDrinkService.GetById(id);

            IEnumerable<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        public IActionResult JuiceDrinkDelete(int id)
        {
            var values = _juiceDrinkService.GetById(id);
            _juiceDrinkService.Delete(values);
            return RedirectToAction("Index", "JuiceDrinks");
        }
    }
}
