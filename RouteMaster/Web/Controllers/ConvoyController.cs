using Microsoft.AspNetCore.Mvc;
using RouteMaster.DomainLayer.Entities;

namespace RouteMaster.Web.Controllers
{
    public class ConvoyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
