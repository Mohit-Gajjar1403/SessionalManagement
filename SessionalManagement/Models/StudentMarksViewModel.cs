using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SessionalManagement.Models
{
    public class StudentMarksViewModel
    {
        public int StudentId { get; set; }  
        public string StudentEmail { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
    }
}
