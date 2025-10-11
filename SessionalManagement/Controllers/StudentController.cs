using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SessionalManagement.Models;
using SessionalManagement.Repositories;
using System.Linq;

namespace SessionalManagement.Controllers
{
    public class StudentController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            Student student = _unitOfWork.Marks.Student.GetStudentByEmail(HttpContext.Session.GetString("Username"));

            return View(student);
        }

        public IActionResult MyMarks()
        {
            Student student = _unitOfWork.Marks.Student.GetStudentByEmail(HttpContext.Session.GetString("Username"));
            
            ViewBag.subjects=_unitOfWork.Marks.GetMarksByStudent(student.Id).Select(m=>m.Subject).Distinct().OrderBy(s=>s.Name).ToList();
            ViewBag.exams = _unitOfWork.Marks.GetMarksByStudent(student.Id).Select(m => m.Exam).Distinct().OrderBy(e=>e.Name).ToList();

            return View(student);
        }
        public IActionResult MarksGraph()
        {
            var exams = _unitOfWork.Marks.Exam.GetAllExams().OrderBy(e => e.Name).ToList();
            var subjects = _unitOfWork.Marks.Subject.GetAllSubjects().OrderBy(s => s.Name).ToList();

            ViewBag.Exams = new SelectList(exams, "Id", "Name");
            ViewBag.Subjects = new SelectList(subjects, "Id", "Name");

            return View();
        }

        [HttpGet]
        public IActionResult GetMarksData(int examId, int subjectId)
        {
            var studentId = (_unitOfWork.Marks.Student
                .GetStudentByEmail(HttpContext.Session.GetString("Username"))).Id;

            var allMarksWithStudent = _unitOfWork.Marks.GetAllMarks()
                .Where(m => m.ExamId == examId && m.SubjectId == subjectId)
                .Select(m => new { m.MarksObtained, m.Student.Name })
                .ToList();

            var allMarks = allMarksWithStudent.Select(m => m.MarksObtained).ToList();

            var studentMark = allMarksWithStudent
                .FirstOrDefault(m => m.Name == HttpContext.Session.GetString("Username"))
                ?.MarksObtained ?? 0;

            // Group marks 0-36 for all students
            var grouped = Enumerable.Range(0, 37) // 0 to 36
                .Select(mark => new {
                    marks = mark,
                    count = allMarks.Count(m => m == mark)
                })
                .ToList();

            // Get highest scorer(s)
            var maxMark = allMarks.Any() ? allMarks.Max() : 0;
            var topStudents = allMarksWithStudent
                .Where(m => m.MarksObtained == maxMark)
                .Select(m => m.Name)
                .ToList();

            return Json(new { data = grouped, studentMark, topStudents });
        }


    }
}
