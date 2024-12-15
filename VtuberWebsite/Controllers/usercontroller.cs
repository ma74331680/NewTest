using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace VtuberWebsite.Controllers
{
    public class UserController : Controller
    {
        // 模擬用戶資料庫（可改為實際資料庫）
        private static Dictionary<string, string> users = new Dictionary<string, string>();

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

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        // 註冊提交
        [HttpPost]
        public ActionResult Register(string username, string password, string confirmPassword)
        {
            // 驗證用戶輸入
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.ErrorMessage = "帳號與密碼不得為空。";
                return View("SignUp");
            }

            if (password != confirmPassword)
            {
                ViewBag.ErrorMessage = "密碼與確認密碼不一致。";
                return View("SignUp");
            }

            // 檢查用戶名是否已存在
            if (users.ContainsKey(username))
            {
                ViewBag.ErrorMessage = "帳號已存在，請使用其他帳號。";
                return View("SignUp");
            }

            // 密碼加密存儲
            string hashedPassword = HashPassword(password);
            users.Add(username, hashedPassword);

            ViewBag.SuccessMessage = "註冊成功，請登入。";
            return RedirectToAction("Login");
        }

        // 登入提交
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // 檢查用戶是否存在
            if (!users.ContainsKey(username) || !VerifyPassword(users[username], password))
            {
                ViewBag.ErrorMessage = "帳號或密碼錯誤。";
                return View();
            }

            // 登入成功
            FormsAuthentication.SetAuthCookie(username, false);
            return RedirectToAction("Index", "Home");
        }

        // 登出
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // 密碼加密
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // 驗證密碼
        private bool VerifyPassword(string storedPassword, string enteredPassword)
        {
            string hashedEnteredPassword = HashPassword(enteredPassword);
            return storedPassword == hashedEnteredPassword;
        }
    }
}
