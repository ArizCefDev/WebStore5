using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Products
{
    public class ProductList : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductList(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _productService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
