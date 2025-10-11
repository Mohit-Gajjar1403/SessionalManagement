using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using SessionalManagement.Models;
using SessionalManagement.Repositories;
using System;
using System.Collections.Generic;
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
            var Subjects = unitOfWork.TeacherDetails.Subject.GetAllSubjects();
            ViewBag.Subjects = Subjects.Select(s=>new SelectListItem
            {
                Text=s.Name,
                Value=s.Id.ToString()
            }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddTeacher(string Name,string Email,string Password,string[] subjectIds)
        {
            ViewBag.Subjects = unitOfWork.TeacherDetails.Subject.GetAllSubjects();
            if (ModelState.IsValid)
            {
                Console.WriteLine("correct model");
                if(Password == "password123" && Email == "admin123")
                {
                    ViewBag.ConsoleMessage = "in admin of admin controller";
                    ViewBag.Error = "Invalid Credentials";
                    return View();
                }
                Teacher t  = new Teacher();
                //t.Id = unitOfWork.TeacherDetails.Teacher.GetId();
                t.Name = Name;
                t.Email = Email;
                t.Password = Password;
                t.TeacherSubjects=new List<TeacherSubjects>();
                if (subjectIds != null)
                {
                    foreach (var id in subjectIds)
                    {
                        if (int.TryParse(id, out int subjectId))
                        {
                            Console.WriteLine(subjectId);

                            t.TeacherSubjects.Add(new TeacherSubjects { SubjectId = subjectId });
                        }
                    }
                }
                unitOfWork.TeacherDetails.Teacher.Insert(t);
                unitOfWork.TeacherDetails.Save();
                return RedirectToAction("Details");
            }
            ViewBag.ConsoleMessage = "Not redirected";
            return View();
        }
        [HttpGet]
        public IActionResult EditTeacher()
        {
            return View();
        }
        [HttpPost]
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
<<<<<<< HEAD
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.User.Insert(student);
            }
            return View();
        }
        public IActionResult StudentDetails()
=======
        public IActionResult StudentDetails(string searchQuery)
>>>>>>> 0befa77974a55197b5037df1838f710d73417039
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
