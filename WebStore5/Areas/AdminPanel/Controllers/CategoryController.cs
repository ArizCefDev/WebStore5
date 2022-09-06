using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    //[Route("AdminPanel/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _categoryService.GetList() select a;

            if (!string.IsNullOrEmpty(s))
            {
                values = _categoryService.CategorySearch(s);
            }
            return View(values.OrderByDescending(x=>x.ID));
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            p.Status = true;
            _categoryService.Insert(p);
            return RedirectToAction("Index","Category");
        }

        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var values = _categoryService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            p.Status = true;
            _categoryService.Update(p);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult CategoryDetails(int id)
        {
            var values = _categoryService.GetById(id);
            return View(values);
        }

        public IActionResult CategoryDelete(int id)
        {
            var values = _categoryService.GetById(id);
            _categoryService.Delete(values);
            return RedirectToAction("Index", "Category");
        }
    }
}
