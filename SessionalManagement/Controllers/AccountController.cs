using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionalManagement.Models;
using SessionalManagement.Repositories;
using System;

namespace SessionalManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email !=null && password!=null)
            {
                User u = _unitOfWork.User.GetUserByEmail(email);
                Console.WriteLine(u);
                if (u == null)
                {
                    ViewBag.Error = "Email Not Found";
                    return View();
                }

                if (u.Password == password)
                {
                    HttpContext.Session.SetString("Username", email);
                    HttpContext.Session.SetString("Role", (u.Role).ToString());
                    HttpContext.Session.SetString("Name", u.Name); 
                    return RedirectToAction("Index", "Home");
                }
                else {                     
                    ViewBag.Error = "Invalid username or password";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
