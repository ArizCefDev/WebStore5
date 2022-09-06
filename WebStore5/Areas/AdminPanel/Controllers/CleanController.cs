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
    public class CleanController : Controller
    {
        private readonly IClearProductService _clearProductService;
        private readonly ICategoryService _categoryService;

        public CleanController(IClearProductService clearProductService, ICategoryService categoryService)
        {
            _clearProductService = clearProductService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _clearProductService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _clearProductService.CleanProductSearch(s);
            }
            return View(values.OrderByDescending(x => x.ID));
        }

        [HttpGet]
        public IActionResult CleanProductAdd()
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
        public IActionResult CleanProductAdd(ClearProduct p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _clearProductService.Insert(p);
            return RedirectToAction("Index", "Clean");
        }

        public IActionResult CleanProductDelete(int id)
        {
            var values = _clearProductService.GetById(id);
            _clearProductService.Delete(values);
            return RedirectToAction("Index","Clean");
        }

        [HttpGet]
        public IActionResult CleanProductUpdate(int id)
        {
            var values = _clearProductService.GetById(id);
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
        public IActionResult CleanProductUpdate(ClearProduct p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _clearProductService.Update(p);
            return RedirectToAction("Index", "Clean");
        }

        public IActionResult CleanProductDetails(int id)
        {
            var values = _clearProductService.GetById(id);

            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

    }
}
