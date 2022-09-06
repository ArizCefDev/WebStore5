using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace WebStore5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class FrozenNonvegsController : Controller
    {
        private readonly IFrozenNonvegService _frozenNonvegService;
        private readonly ICategoryService _categoryService;

        public FrozenNonvegsController(IFrozenNonvegService frozenNonvegService, ICategoryService categoryService)
        {
            _frozenNonvegService = frozenNonvegService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _frozenNonvegService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _frozenNonvegService.FrozenNonvegSearch(s);
            }
            return View(values.OrderByDescending(x => x.ID));
        }

        [HttpGet]
        public IActionResult FrozenNonvegAdd()
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
        public IActionResult FrozenNonvegAdd(FrozenNonveg p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _frozenNonvegService.Insert(p);
            return RedirectToAction("Index", "FrozenNonvegs");
        }

        [HttpGet]
        public IActionResult FrozenNonvegUpdate(int id)
        {
            var values = _frozenNonvegService.GetById(id);
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
        public IActionResult FrozenNonvegUpdate(FrozenNonveg p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _frozenNonvegService.Update(p);
            return RedirectToAction("Index", "FrozenNonvegs");
        }

        [HttpGet]
        public IActionResult FrozenNonvegDetails(int id)
        {
            var values = _frozenNonvegService.GetById(id);
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        public IActionResult FrozenNonvegDelete(int id)
        {
            var values = _frozenNonvegService.GetById(id);
            _frozenNonvegService.Delete(values);
            return RedirectToAction("Index", "FrozenNonvegs");
        }
    }
}
