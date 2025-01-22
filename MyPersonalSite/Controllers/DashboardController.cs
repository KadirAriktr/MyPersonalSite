using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {     
            return View();
        }
    }
}
