using System;

namespace demoAapi.Models
{
    public class Gpa
    {
        public string GpaId { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Score { get; set; }
        public string GPA { get; set; }
    }
}