using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WastedFoodSystemAdmin.wasted_food_data;
using WebApplication6.Models;
using WebApplication6.Utils;

namespace WebApplication6.Controllers
{
    //[AuthorizedAction]
    public class SellerManagerController : Controller
    {
        wasted_food_databaseContext _context;

        public SellerManagerController(wasted_food_databaseContext context)
        {
            _context = context;
        }
        public IActionResult WaitForActive(string searchString)
        {
            var viewModels = (from m in _context.Account.ToList()
                              join r in _context.Seller.ToList() on m.Id equals r.AccountId
                              where m.RoleId == 2 && m.IsActive == 2
                              select new AccountSellerViewModel()
                              {
                                  Id = m.Id,
                                  Username = m.Username,
                                  Password = m.Password,
                                  Phone = m.Phone,
                                  ThirdPartyId = m.ThirdPartyId,
                                  Email = m.Email,
                                  CreatedDate = m.CreatedDate,
                                  IsActive = m.IsActive,
                                  FirebaseUid = m.FirebaseUid,
                                  Name = r.Name,
                                  Image = r.Image,
                                  Address = r.Address,
                                  Latitude = r.Latitude,
                                  Longitude = r.Longitude,
                                  Description = r.Description,
                                  ModifiedDate = m.ModifiedDate
                              }).ToList();
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                viewModels = viewModels.Where(s => s.Username.Contains(searchString)).ToList(); //lọc theo chuỗi tìm kiếm
            }
            return View(viewModels);

        }

        public IActionResult Account(String searchString)
        {
            var viewModels = (from m in _context.Account.ToList()
                              join r in _context.Seller.ToList() on m.Id equals r.AccountId
                              where m.RoleId == 2 && m.IsActive == 1
                              select new AccountSellerViewModel()
                              {
                                  Id = m.Id,
                                  Username = m.Username,
                                  Password = m.Password,
                                  Phone = m.Phone,
                                  ThirdPartyId = m.ThirdPartyId,
                                  Email = m.Email,
                                  CreatedDate = m.CreatedDate,
                                  IsActive = m.IsActive,
                                  FirebaseUid = m.FirebaseUid,
                                  Name = r.Name,
                                  Image = r.Image,
                                  Address = r.Address,
                                  Latitude = r.Latitude,
                                  Longitude = r.Longitude,
                                  Description = r.Description,
                                  ModifiedDate = m.ModifiedDate
                              }).ToList();
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                viewModels = viewModels.Where(s => s.Username.Contains(searchString)).ToList(); //lọc theo chuỗi tìm kiếm
            }
            return View(viewModels);
        }

        public IActionResult Blocked(String searchString)
        {
            var viewModels = (from m in _context.Account.ToList()
                              join r in _context.Seller.ToList() on m.Id equals r.AccountId
                              where m.RoleId == 2 && m.IsActive == 3
                              select new AccountSellerViewModel()
                              {
                                  Id = m.Id,
                                  Username = m.Username,
                                  Password = m.Password,
                                  Phone = m.Phone,
                                  ThirdPartyId = m.ThirdPartyId,
                                  Email = m.Email,
                                  CreatedDate = m.CreatedDate,
                                  IsActive = m.IsActive,
                                  FirebaseUid = m.FirebaseUid,
                                  Name = r.Name,
                                  Image = r.Image,
                                  Address = r.Address,
                                  Latitude = r.Latitude,
                                  Longitude = r.Longitude,
                                  Description = r.Description,
                                  ModifiedDate = m.ModifiedDate
                              }).ToList();
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                viewModels = viewModels.Where(s => s.Username.Contains(searchString)).ToList(); //lọc theo chuỗi tìm kiếm
            }
            return View(viewModels);
        }

        public async Task<IActionResult> ActiveAccount(int? id)
        {

            var sellerAccount = await _context.Account.FindAsync(id);
           
           
            if (sellerAccount.IsActive == 2)
            {
                sellerAccount.IsActive = 1;
                _context.Account.Attach(sellerAccount).Property(x => x.IsActive).IsModified = true;
                await MailUtils.SendMailGoogleSmtp("WastedFoodSystem@gmail.com", sellerAccount.Email, "Chào mừng bạn đến với Wasted Food", "Tài khoản của bạn đã được thông qua xét duyệt và trở thành thành viên của chúng tôi",
                                              "WastedFoodSystem@gmail.com", "fall2020@WastedFoodSystem");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(WaitForActive));
            }
            else if (sellerAccount.IsActive == 1)
            {
                sellerAccount.IsActive = 3;
                _context.Account.Attach(sellerAccount).Property(x => x.IsActive).IsModified = true;
                await MailUtils.SendMailGoogleSmtp("WastedFoodSystem@gmail.com", sellerAccount.Email, "Wasted Food thông báo", "Tài khoản của bạn đã bị khóa, vui lòng liên hệ lại với admin thông qua địa chỉ email này: WastedFoodSystem@gmail.com để được hỗ trợ ",
                                              "WastedFoodSystem@gmail.com", "fall2020@WastedFoodSystem");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Account));
            }
            else if (sellerAccount.IsActive == 3)
            {
                sellerAccount.IsActive = 1;
                _context.Account.Attach(sellerAccount).Property(x => x.IsActive).IsModified = true;
                await MailUtils.SendMailGoogleSmtp("WastedFoodSystem@gmail.com", sellerAccount.Email, "Wasted Food thông báo", "Tài khoản của bạn đã được mở khóa, vui lòng liên hệ lại với admin thông qua địa chỉ email này: WastedFoodSystem@gmail.com để được hỗ trợ ",
                                              "WastedFoodSystem@gmail.com", "fall2020@WastedFoodSystem");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Account));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
