using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace WebStore5.Areas.AdminPanel.Controllers
{
    [Area("adminPanel")]
    public class SweetsController : Controller
    {
        private readonly ISweetService _sweetService;
        private readonly ICategoryService _categoryService;

        public SweetsController(ISweetService sweetService, ICategoryService categoryService)
        {
            _sweetService = sweetService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _sweetService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _sweetService.SweetSearch(s);
            }
            return View(values.OrderByDescending(x => x.ID));
        }

        [HttpGet]
        public IActionResult SweetAdd()
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
        public IActionResult SweetAdd(Sweet p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _sweetService.Insert(p);
            return RedirectToAction("Index", "Sweets");
        }

        [HttpGet]
        public IActionResult SweetUpdate(int id)
        {
            var values = _sweetService.GetById(id);
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
        public IActionResult SweetUpdate(Sweet p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _sweetService.Update(p);
            return RedirectToAction("Index", "Sweets");
        }

        [HttpGet]
        public IActionResult SweetDetails(int id)
        {
            var values = _sweetService.GetById(id);
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        public IActionResult SweetDelete(int id)
        {
            var values = _sweetService.GetById(id);
            _sweetService.Delete(values);
            return RedirectToAction("Index", "Sweets");
        }
    }
}
