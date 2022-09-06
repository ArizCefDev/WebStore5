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
    public class BeefController : Controller
    {
        private readonly IBeeftService _beeftService;
        private readonly ICategoryService _categoryService;

        public BeefController(IBeeftService beeftService, ICategoryService categoryService)
        {
            _beeftService = beeftService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _beeftService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _beeftService.BeefSearch(s);
            }
            return View(values.OrderByDescending(x => x.ID));
        }

        [HttpGet]
        public IActionResult BeefAdd()
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
        public IActionResult BeefAdd(Meat p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _beeftService.Insert(p);
            return RedirectToAction("Index", "Beef");
        }

        [HttpGet]
        public IActionResult BeefUpdate(int id)
        {
            var values = _beeftService.GetById(id);
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
        public IActionResult BeefUpdate(Meat p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _beeftService.Update(p);
            return RedirectToAction("Index", "Beef");
        }

        [HttpGet]
        public IActionResult BeefDetails(int id)
        {
            var values = _beeftService.GetById(id);
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        public IActionResult BeefDelete(int id)
        {
            var values = _beeftService.GetById(id);
            _beeftService.Delete(values);
            return RedirectToAction("Index", "Beef");
        }
    }
}
