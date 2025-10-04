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
                if(email=="admin123"&&password=="password123")
                {
                    HttpContext.Session.SetString("Username", email);
                    HttpContext.Session.SetString("Role", Role.Admin.ToString());
                    return RedirectToAction("Index", "Admin");
                }
                User u = _unitOfWork.User.GetUserByEmail(email);
                Console.WriteLine(u);
                if (u == null)
                {
                    ViewBag.Error = "Email Not Found";
                    return View();
                }
                
                if (BCrypt.Net.BCrypt.Verify(password, u.Password))
                {
                    HttpContext.Session.SetString("Username", email);
                    HttpContext.Session.SetString("Role", (u.Role).ToString());
                    HttpContext.Session.SetString("Name", u.Name);
                    if (u.Role == Role.Admin)
                        return RedirectToAction("Index", "Admin");
                    else if (u.Role == Role.Teacher)
                        return RedirectToAction("Index", "Teacher");
                    else if (u.Role == Role.Student)
                        return RedirectToAction("Index", "Student");
                    else
                    {
                        ViewBag.Error = "Invalid user role.Server Error";
                        return View();
                    }
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
