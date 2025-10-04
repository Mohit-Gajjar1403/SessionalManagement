using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SessionalManagement.Models;
using SessionalManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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
        [HttpGet]
        public IActionResult UploadMarks()
        {
            var exams = _unitOfWork.Marks.Exam.GetAllExams();
            ViewBag.Exams = exams.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();

            var semesters = Enum.GetValues(typeof(Semester))
                .Cast<Semester>()
                .Select(s => new SelectListItem
                {
                    Value = ((int)s).ToString(),
                    Text = s.ToString()
                }).ToList();
            ViewBag.Semesters = semesters;

            return View();
        }
        [HttpGet]
        public IActionResult GetSubjects(int semester)
        {
            string temail = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(temail))
                return Json(new List<object>());

            var subjectls = _unitOfWork.TeacherDetails.Subject.GetAllSubjects()
             .Where(s => s.Semester == (Semester)semester)
             .ToList();


            var subjects = subjectls
                .Where(s => s.TeacherSubjects.Any(ts => ts.Teacher != null && ts.Teacher.Email == temail))
                .Select(s => new { s.Id, s.Name })
                .ToList();

            return Json(subjects);

        }

        [HttpGet]
        public IActionResult GetStudentsForMarks(int subjectId, int examId)
        {
            var subject = _unitOfWork.TeacherDetails.Subject.GetSubjectById(subjectId);

            var students = _unitOfWork.Marks.Student.GetAllStudents().ToList();

            if (subject != null)
                students = students.Where(s => s.Semester == subject.Semester).ToList();

            var marks = _unitOfWork.Marks.GetAllMarks()
                .Where(m => m.SubjectId == subjectId && m.ExamId == examId)
                .ToList();

            var model = students.Select(s => new StudentMarksViewModel
            {
                StudentId= s.Id,
                StudentEmail = s.Email,
                Name = s.Name,
                Marks = marks.FirstOrDefault(m => m.StudentId == s.Id)?.MarksObtained ?? 0
            }).ToList();

            ViewBag.ExamId = examId;
            ViewBag.SubjectId = subjectId;

            return PartialView("_StudentMarksTable", model);
        }
        [HttpPost]
        public IActionResult UploadMarks(List<StudentMarksViewModel> model, int examId, int subjectId)
        {
            foreach (var item in model)
            {
                var existing = _unitOfWork.Marks.GetAllMarks()
                    .FirstOrDefault(m => m.StudentId == item.StudentId
                                      && m.SubjectId == subjectId
                                      && m.ExamId == examId);

                if (existing == null)
                {
                    _unitOfWork.Marks.Insert(new Marks
                    {
                        StudentId = item.StudentId,
                        SubjectId = subjectId,
                        ExamId = examId,
                        MarksObtained = item.Marks
                    });
                }
                else
                {
                    existing.MarksObtained = item.Marks;
                }
            }

            _unitOfWork.Save(); 
            return RedirectToAction("UploadMarks");
        }

    }

}
