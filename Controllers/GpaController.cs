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

    public class GpaController : ControllerBase
    {
        public static List<Gpa> GpaData = new List<Gpa>
        {
            new Gpa { GpaId = "1414", StudentId = "501210" , StudentName = "hte5hwrthrhgre",SubjectId = "120111" , SubjectName = "AIProgramming" , Score = 65 , GPA = "C"},
            new Gpa { GpaId = "1415", StudentId = "501211" , StudentName = "gregrehrthtser",SubjectId = "120112" , SubjectName = "Programming" , Score = 70 , GPA = "B"},
            new Gpa { GpaId = "1416", StudentId = "501212" , StudentName = "nhgfnfghnhnhgfn",SubjectId = "120113" , SubjectName = "ComProgramming" , Score = 40 , GPA = "F"}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Gpa>> GetGpaAll()
        {
            return GpaData.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Gpa> GetGpaById(string id)
        {
            return GpaData.FirstOrDefault(it => it.StudentId == id.ToString());
        }

        [HttpPost]
        public Gpa StudentAddSubject([FromBody] Gpa data)
        {
            var id = Guid.NewGuid().ToString();
            var item = new Gpa
            {
                GpaId = id,
                StudentId = data.StudentId,
                StudentName = data.StudentName,
                SubjectId = data.SubjectId,
                SubjectName = data.SubjectName,

            };
            GpaData.Add(item);
            return item;
        }

        [HttpPut("{id}")]
        public Gpa StudentEditSubject(string id, [FromBody] Gpa data)
        {
            var findId = GpaData.FirstOrDefault(it => it.StudentId == id.ToString());
            var item = new Gpa
            {
                GpaId = data.GpaId,
                StudentId = id,
                StudentName = data.StudentName,
                SubjectId = data.SubjectId,
                SubjectName = data.SubjectName,
            };
            GpaData.Remove(findId);
            GpaData.Add(item);
            return item;
        }

        [HttpPut("{id}")]
        public Gpa StudentCalculateGpa(string id, [FromBody] Gpa data)
        {
            var findId = GpaData.FirstOrDefault(it => it.StudentId == id.ToString());
            if (data.Score >= 80)
            {
                data.GPA = "A";
            }
            else if (data.Score >= 75)
            {
                data.GPA = "B+";
            }
            else if (data.Score >= 70)
            {
                data.GPA = "B";
            }
            else if (data.Score >= 65)
            {
                data.GPA = "C+";
            }
            else if (data.Score >= 60)
            {
                data.GPA = "C";
            }
            else if (data.Score >= 55)
            {
                data.GPA = "D+";
            }
            else if (data.Score >= 50)
            {
                data.GPA = "D";
            }
            else
            {
                data.GPA = "F";    
            }

            var item = new Gpa
            {
                GpaId = data.GpaId,
                StudentId = id,
                StudentName = data.StudentName,
                SubjectId = data.SubjectId,
                SubjectName = data.SubjectName,
                Score = data.Score,
                GPA = data.GPA
            };
            GpaData.Remove(findId);
            GpaData.Add(item);
            return item;
        }

        [HttpDelete("{id}")]
        public void StudentSubjectDelete(string id)
        {
            var deleted = GpaData.FirstOrDefault(it => it.StudentId == id.ToString());
            GpaData.Remove(deleted);
        }


    }
}
