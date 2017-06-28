using Lary.Models;
using Lary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lary.Controllers
{
    public class HomeController : BaseController
    {
        LaryDbContext _db = new LaryDbContext();
        public ActionResult Index()
        {
            return RedirectToAction("Index","Product");
        }


        #region Authentication

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var user =
                    _db.User.SingleOrDefault(
                        p => p.UserName.Trim() == model.Username.Trim() && p.Password.Trim() == model.Password.Trim());
                if (user == null)
                {
                    ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
                    return View(model);
                }
                else
                {
                    Session["username"] = user.UserName;
                    Session["role"] = user.RoleId;
                    return RedirectToAction("Index");
                }

            }

        }

        public ActionResult Logout()
        {
            Session["username"] = null;
            Session["role"] = null;
            return RedirectToAction("Login");
        }

        #endregion
    }
}