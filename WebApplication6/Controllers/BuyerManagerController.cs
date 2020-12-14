using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WastedFoodSystemAdmin.wasted_food_data;
using WebApplication6.Models;
using WebApplication6.Utils;

namespace WebApplication6.Controllers
{
    public class BuyerManagerController : Controller
    {
        wasted_food_databaseContext _context;

        public BuyerManagerController(wasted_food_databaseContext context)
        {
            _context = context;
        }

        public IActionResult Account(String searchString)
        {

            try
            {
                var account = _context.Account.ToList();
                var seller = _context.Buyer.ToList();
                var viewModels = (from m in _context.Account.ToList()
                                  join r in _context.Buyer.ToList() on m.Id equals r.AccountId
                                  where m.RoleId == 1 && m.IsActive == 1
                                  select new AccountBuyerViewModel()
                                  {
                                      Id = m.Id,
                                      Username = m.Username,
                                      Phone = m.Phone,
                                      Email = m.Email,
                                      CreatedDate = m.CreatedDate,
                                      name = r.Name
                                  }).ToList();
                if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
                {
                    viewModels = viewModels.Where(s => s.Username.Contains(searchString)).ToList(); //lọc theo chuỗi tìm kiếm
                }
                return View(viewModels);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public IActionResult Blocked(String searchString)
        {

            try
            {
                var account = _context.Account.ToList();
                var seller = _context.Buyer.ToList();
                var viewModels = (from m in _context.Account.ToList()
                                  join r in _context.Buyer.ToList() on m.Id equals r.AccountId
                                  where m.RoleId == 1 && m.IsActive == 0
                                  select new AccountBuyerViewModel()
                                  {
                                      Id = m.Id,
                                      Username = m.Username,
                                      Phone = m.Phone,
                                      Email = m.Email,
                                      CreatedDate = m.CreatedDate,
                                      name = r.Name
                                  }).ToList();
                if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
                {
                    viewModels = viewModels.Where(s => s.Username.Contains(searchString)).ToList(); //lọc theo chuỗi tìm kiếm
                }
                return View(viewModels);
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<IActionResult> ActiveAccount(int? id)
        {

            var buyerAccount = await _context.Account.FindAsync(id);


           
            if (buyerAccount.IsActive == 1)
            {
                buyerAccount.IsActive = 0;
                _context.Account.Attach(buyerAccount).Property(x => x.IsActive).IsModified = true;
                await MailUtils.SendMailGoogleSmtp("WastedFoodSystem@gmail.com", buyerAccount.Email, "Wasted Food thông báo", "Tài khoản của bạn đã bị khóa, vui lòng liên hệ lại với admin thông qua địa chỉ email này: WastedFoodSystem@gmail.com để được hỗ trợ ",
                                              "WastedFoodSystem@gmail.com", "fall2020@WastedFoodSystem");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Account));
            }
            else if (buyerAccount.IsActive == 0)
            {
                buyerAccount.IsActive = 1;
                _context.Account.Attach(buyerAccount).Property(x => x.IsActive).IsModified = true;
                await MailUtils.SendMailGoogleSmtp("WastedFoodSystem@gmail.com", buyerAccount.Email, "Wasted Food thông báo", "Tài khoản của bạn đã được mở khóa, vui lòng liên hệ lại với admin thông qua địa chỉ email này: WastedFoodSystem@gmail.com để được hỗ trợ ",
                                              "WastedFoodSystem@gmail.com", "fall2020@WastedFoodSystem");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Account));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
