using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.ViewComponents.Services
{
    public class ServiceList : ViewComponent
    {
        private readonly IServicesService _servicesService;

        public ServiceList(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _servicesService.GetList();
            return View(values);
        }
    }
}
