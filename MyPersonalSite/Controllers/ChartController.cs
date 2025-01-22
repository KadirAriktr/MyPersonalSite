using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MyPersonalSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ChartController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            var roleCounts = c.Users
            .Join(c.UserRoles, user => user.Id, userRole => userRole.UserId, (user, userRole) => new { user, userRole })
            .Join(c.Roles, userUserRole => userUserRole.userRole.RoleId, role => role.Id, (userUserRole, role) => new { userUserRole.user, role })
            .GroupBy(r => r.role.Name)  // Role göre gruplama
            .Select(g => new { Role = g.Key, Count = g.Count() })
            .ToList();

            
            foreach (var roleCount in roleCounts)
            {
                if (roleCount.Role == "Admin")
                {
                    ViewBag.Admin = roleCount.Count;
                }
                else if (roleCount.Role == "Writer")
                {
                    ViewBag.Writer = roleCount.Count;
                }
                else if (roleCount.Role == "Moderator")
                {
                    ViewBag.Moderator = roleCount.Count;
                }
                else if (roleCount.Role == "Visiter")
                {
                    ViewBag.Visiter = roleCount.Count;
                }
                
            }

            return View();
        }
    }
}
