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
    public class HouseHoldController : Controller
    {
        private readonly IHouseHoldService _houseHoldService;
        private readonly ICategoryService _categoryService;

        public HouseHoldController(IHouseHoldService houseHoldService, ICategoryService categoryService)
        {
            _houseHoldService = houseHoldService;
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _houseHoldService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _houseHoldService.HouseHoldSearch(s);
            }
            return View(values.OrderByDescending(x => x.ID));
        }

        [HttpGet]
        public IActionResult HouseHoldAdd()
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
        public IActionResult HouseHoldAdd(HouseHold p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _houseHoldService.Insert(p);
            return RedirectToAction("Index", "HouseHold");
        }

        public IActionResult HouseHoldDelete(int id)
        {
            var values = _houseHoldService.GetById(id);
            _houseHoldService.Delete(values);
            return RedirectToAction("Index", "HouseHold");
        }

        [HttpGet]
        public IActionResult HouseHoldUpdate(int id)
        {
            var values = _houseHoldService.GetById(id);
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
        public IActionResult HouseHoldUpdate(HouseHold p)
        {
            List<SelectListItem> valueGet = (from x in _categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.c = valueGet;
            p.Status = true;
            _houseHoldService.Update(p);
            return RedirectToAction("Index","HouseHold");
        }

        public IActionResult HouseHoldDetails(int id)
        {            
            var values = _houseHoldService.GetById(id);

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
