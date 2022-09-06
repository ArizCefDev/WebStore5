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
    public class FishController : Controller
    {
        private readonly IFishService _fishService;
        private readonly ICategoryService _categoryService;

        public FishController(IFishService fishService, ICategoryService categoryService)
        {
            _fishService = fishService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _fishService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _fishService.FishSearch(s);
            }
            return View(values.OrderByDescending(x=>x.ID));
        }

        [HttpGet]
        public IActionResult FishAdd()
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
        public IActionResult FishAdd(Fish p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _fishService.Insert(p);
            return RedirectToAction("Index", "Fish");
        }

        [HttpGet]
        public IActionResult FishUpdate(int id)
        {
            var values = _fishService.GetById(id);
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
        public IActionResult FishUpdate(Fish p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _fishService.Update(p);
            return RedirectToAction("Index", "Fish");
        }

        [HttpGet]
        public IActionResult FishDetails(int id)
        {
            var values = _fishService.GetById(id);
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        public IActionResult  FishDelete(int id)
        {
            var values = _fishService.GetById(id);
            _fishService.Delete(values);
            return RedirectToAction("Index","Fish");
        }
    }
}
