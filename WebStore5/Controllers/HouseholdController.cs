using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class HouseholdController : Controller
    {
        private readonly IHouseHoldService _houseHoldService;

        public HouseholdController(IHouseHoldService houseHoldService)
        {
            _houseHoldService = houseHoldService;
        }

        public IActionResult Index()
        {
            var values = _houseHoldService.GetList();
            return View(values);
        }

        public IActionResult HouseHoldDetails(int id)
        {
            var values = _houseHoldService.GetHouseHoldID(id);
            return View(values);
        }
    }
}
