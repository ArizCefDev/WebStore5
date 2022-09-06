using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.HouseHolds
{
    public class HouseHoldsList : ViewComponent
    {
        private readonly IHouseHoldService _houseHoldService;

        public HouseHoldsList(IHouseHoldService houseHoldService)
        {
            _houseHoldService = houseHoldService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _houseHoldService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
