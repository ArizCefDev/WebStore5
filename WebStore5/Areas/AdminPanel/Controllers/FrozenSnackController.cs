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
    public class FrozenSnackController : Controller
    {
        private readonly IFrozenSnacksService _frozenSnacksService;
        private readonly ICategoryService _categoryService;

        public FrozenSnackController(IFrozenSnacksService frozenSnacksService, ICategoryService categoryService)
        {
            _frozenSnacksService = frozenSnacksService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _frozenSnacksService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _frozenSnacksService.FrozenSnackSearch(s);
            }
            return View(values.OrderByDescending(x=>x.ID));
        }

        [HttpGet]
        public IActionResult FrozenSnackAdd()
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
        public IActionResult FrozenSnackAdd(FrozenSnacks p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _frozenSnacksService.Insert(p);
            return RedirectToAction("Index", "FrozenSnack");
        }

        [HttpGet]
        public IActionResult FrozenSnackUpdate(int id)
        {
            var values = _frozenSnacksService.GetById(id);
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
        public IActionResult FrozenSnackUpdate(FrozenSnacks p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _frozenSnacksService.Update(p);
            return RedirectToAction("Index", "FrozenSnack");
        }

        [HttpGet]
        public IActionResult FrozenSnackDetails(int id)
        {
            var values = _frozenSnacksService.GetById(id);
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        public IActionResult FrozenSnackDelete(int id)
        {
            var values = _frozenSnacksService.GetById(id);
            _frozenSnacksService.Delete(values);
            return RedirectToAction("Index", "FrozenSnack");
        }
    }
}
