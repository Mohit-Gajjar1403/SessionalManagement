using Microsoft.AspNetCore.Mvc;

namespace SessionalManagement.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
