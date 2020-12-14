
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WastedFoodSystemAdmin.wasted_food_data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class AdminController : Controller
    {

        wasted_food_databaseContext _context;

        public AdminController(wasted_food_databaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }

        

        public async Task<IActionResult> Login()
        {
            return await Task.FromResult(View());
        }
        public async Task<IActionResult> Validate(Account account)
        { 
            var _admin = _context.Account.Where(s => s.Username == account.Username && s.RoleId == 1).FirstOrDefault();
            if (_admin != null)
            {
                if (_admin.Password == account.Password)
                {
                    HttpContext.Session.SetString("username", _admin.Username);
                    return await Task.FromResult(Json(new { status = true, message = "Login Successfull!" }));
                }
                else
                {
                    return await Task.FromResult(Json(new { status = false, message = "Invalid Password!" }));
                }
            }
            else
            {
                return await Task.FromResult(Json(new { status = false, message = "Invalid UserName!" }));
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Admin");
        }
    }
}
