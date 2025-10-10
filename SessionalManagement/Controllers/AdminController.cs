using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionalManagement.Models;
using SessionalManagement.Repositories;
using System.Linq;

namespace SessionalManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeacher(Teacher t)
        {
            unitOfWork.TeacherDetails.Teacher.Insert(t);
            return View();
        }
        [HttpGet]
        public IActionResult EditTeacher()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditTeacher(int id)
        {
            var teacher = unitOfWork.TeacherDetails.Teacher.GetTeacherById(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        [HttpPost]
        public IActionResult EditTeacher(Teacher t)
        {
            var teacher = unitOfWork.TeacherDetails.Teacher.GetTeacherById(t.Id);
            var existingSubjects = teacher.TeacherSubjects.Select(x=> x.Subject).ToList();
            var selectedSubjects = t.TeacherSubjects.ToList();
            //var ToAdd = selectedSubjects.Except(existingSubjects).ToList();
            return View(teacher);
        }
        public IActionResult Details()
        {
            var vm = new TeacherSubjectViewModel
            {
                Teachers = unitOfWork.TeacherDetails.Teacher.GetAllTeachers().ToList(),
                Subjects = unitOfWork.TeacherDetails.Subject.GetAllSubjects().ToList()
            };
            return View(vm);
        }
        public IActionResult StudentDetails(string searchQuery)
        {
            var s = unitOfWork.Marks.Student.GetAllStudents();

            if(searchQuery != null)
            {
                searchQuery = searchQuery.ToLower();
                s = s.Where(s => s.Name.ToLower().Contains(searchQuery) || s.Email.ToLower().Contains(searchQuery));
            }
            return View(s);
        }

        
    }
}
