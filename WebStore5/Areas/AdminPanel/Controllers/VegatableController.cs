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
    public class VegatableController : Controller
    {
        private readonly IVegaTableService _vegaTableService;
        private readonly ICategoryService _categoryService;

        public VegatableController(IVegaTableService vegaTableService, ICategoryService categoryService)
        {
            _vegaTableService = vegaTableService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _vegaTableService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _vegaTableService.VegatableSearch(s);
            }
            return View(values.OrderByDescending(x => x.ID));
        }

        [HttpGet]
        public IActionResult VegatableAdd()
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
        public IActionResult VegatableAdd(Vegatable p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _vegaTableService.Update(p);
            return RedirectToAction("Index", "Vegatable");
        }

        [HttpGet]
        public IActionResult VegatableUpdate(int id)
        {
            var values = _vegaTableService.GetById(id);
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
        public IActionResult VegatableUpdate(Vegatable p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _vegaTableService.Update(p);
            return RedirectToAction("Index", "Vegatable");
        }

        [HttpGet]
        public IActionResult VegatableDetails(int id)
        {
            var values = _vegaTableService.GetById(id);
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        //[HttpDelete]
        public IActionResult VegatableDelete(int id)
        {
            var values = _vegaTableService.GetById(id);
            _vegaTableService.Delete(values);
            return RedirectToAction("Index", "Vegatable");
        }
    }
}
