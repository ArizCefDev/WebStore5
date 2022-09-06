using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebStore5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BreadsController : Controller
    {
        private readonly IBreadService _breadService;
        private readonly ICategoryService _categoryService;

        public BreadsController(IBreadService breadService, ICategoryService categoryService)
        {
            _breadService = breadService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _breadService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _breadService.BreadSearch(s);
            }
            return View(values.OrderByDescending(x => x.ID));
        }

        [HttpGet]
        public IActionResult BreadAdd()
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
        public IActionResult BreadAdd(BreadDTO p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;

            Bread b = new Bread();
            if(p.ImageURL != null)
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newImage = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory()
                    , "wwwroot/ProductImages/", newImage);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                b.Image = newImage;
            }
            p.Status = true;
            b.Name = p.Name;
            b.Description = p.Description;
            b.Kilogram = p.Kilogram;
            b.OldPrice = p.OldPrice;
            b.NewPrice = p.NewPrice;
            b.CategoryID = p.CategoryID;
            _breadService.Insert(b);
            return RedirectToAction("Index", "Breads");
        }

        [HttpGet]
        public IActionResult BreadUpdate(int id)
        {
            var values = _breadService.GetById(id);
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
        public IActionResult BreadUpdate(Bread p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _breadService.Update(p);
            return RedirectToAction("Index", "Breads");
        }

        [HttpGet]
        public IActionResult BreadDetails(int id)
        {
            var values = _breadService.GetById(id);
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            return View(values);
        }

        public IActionResult BreadDelete(int id)
        {
            var values = _breadService.GetById(id);
            _breadService.Delete(values);
            return RedirectToAction("Index", "Breads");
        }
    }
}
