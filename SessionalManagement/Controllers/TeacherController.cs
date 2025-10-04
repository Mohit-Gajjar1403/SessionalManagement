using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionalManagement.Models;
using SessionalManagement.Repositories;

namespace SessionalManagement.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            Teacher t = _unitOfWork.TeacherDetails.Teacher.GetTeacherByEmail(HttpContext.Session.GetString("Username"));

            return View(t);
        }
    }
}
