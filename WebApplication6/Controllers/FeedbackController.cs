using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WastedFoodSystemAdmin.wasted_food_data;

namespace WebApplication6.Controllers
{
    public class FeedbackController : Controller
    {
        wasted_food_databaseContext _context;

        public FeedbackController(wasted_food_databaseContext context)
        {
            _context = context;
        }
        public IActionResult Index(String searchString)
        {
            var viewModels = _context.Feedback.OrderByDescending(a => a.CreatedDate).ToList();
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                viewModels = viewModels.Where(s => s.Title.Contains(searchString)).ToList(); //lọc theo chuỗi tìm kiếm
            }
            return View(viewModels);
        }
    }
}
