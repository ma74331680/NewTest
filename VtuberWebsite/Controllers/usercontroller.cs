using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace VtuberWebsite.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Favorite()
        {
            return View();
        }

        // 登入頁面
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        // 登入提交
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // 登入帳密驗證
            if (username == "user" || password == "password") // 驗證邏輯
            {
                // 登入成功
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // 登入失敗
                ViewBag.ErrorMessage = "登入失敗，請檢查用戶名或密碼。";
                return View();
            }
        }
        /*
        // 註冊提交
        [HttpPost]
        public ActionResult Register(string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.ErrorMessage = "密碼不一致。";
                return View();
            }

            // 註冊邏輯，例如新增至資料庫等

            return RedirectToAction("Login");
        }
        */
        /*
        // 登出
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        */
    }
}