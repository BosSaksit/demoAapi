using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoAapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace demoAapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        public static List<Student> StudentData = new List<Student>
        {
            new Student { StudentId = "501210" , StudentName = "hte5hwrthrhgre"},
            new Student { StudentId = "501211" , StudentName = "hterherthrtherth"},
            new Student { StudentId = "501212" , StudentName = "retgehtyjtyurtyj"}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudentAll()
        {
            return StudentData.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(string id)
        {
            return StudentData.FirstOrDefault(it => it.StudentId == id.ToString());
        }

        [HttpPost]
        public Student AddStudent([FromBody] Student data)
        {
            var id = Guid.NewGuid().ToString();
            var item = new Student
            {
                StudentId = id,
                StudentName = data.StudentName
            };
            StudentData.Add(item);
            return item;
        }

        [HttpPut("{id}")]
        public Student EditStudent(string id, [FromBody] Student data)
        {
            var findId = StudentData.FirstOrDefault(it => it.StudentId == id.ToString());
            var item = new Student
            {
               StudentId = id,
               StudentName = data.StudentName
            };
            StudentData.Remove(findId);
            StudentData.Add(item);
            return item;
        }

        [HttpDelete("{id}")]
        public void DeletedStudent(string id)
        {
            var deleted = StudentData.FirstOrDefault(it => it.StudentId == id.ToString());
            StudentData.Remove(deleted);
        }


    }
}