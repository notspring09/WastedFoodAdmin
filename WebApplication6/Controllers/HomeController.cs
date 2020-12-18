using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WastedFoodSystemAdmin.wasted_food_data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [AuthorizedAction]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly wasted_food_databaseContext _context;

        public HomeController(ILogger<HomeController> logger , wasted_food_databaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RegisterSeller()
        {

            return View();
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-info";
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterSeller([Bind("ID,userName,pass,phone,locationX,locationY,active")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seller);
                await _context.SaveChangesAsync();
                SetAlert("Tạo tài khoản thành công vui lòng đợi xét duyệt cho tài khoản của bạn", "success");
                //return RedirectToAction(nameof(Index));
            }
            return View(seller);
        }
    }
}
