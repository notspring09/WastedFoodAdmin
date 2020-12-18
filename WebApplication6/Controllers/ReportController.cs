using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WastedFoodSystemAdmin.wasted_food_data;

namespace WebApplication6.Controllers
{
    [AuthorizedAction]
    public class ReportController : Controller
    {
        wasted_food_databaseContext _context;

        public ReportController(wasted_food_databaseContext context)
        {
            _context = context;
        }

        public IActionResult Index(String searchString)
        {
            var viewModels = _context.Report.OrderByDescending(a => a.CreatedDate).ToList();
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                viewModels = viewModels.Where(s => s.Id.ToString().Equals(searchString)).ToList(); //lọc theo chuỗi tìm kiếm
            }
            return View(viewModels);
        }
    }
}
