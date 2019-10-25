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

    public class SubjectController : ControllerBase
    {
        public static List<Subject> SubjectData = new List<Subject>
        {
            new Subject { SubjectId = "120111" , SubjectName = "AIProgramming"},
            new Subject { SubjectId = "120112" , SubjectName = "ComProgramming"},
            new Subject { SubjectId = "120113" , SubjectName = "MobileApplication"}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Subject>> GetSubjectAll()
        {
            return SubjectData.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Subject> GetSubjectById(string id)
        {
            return SubjectData.FirstOrDefault(it => it.SubjectId == id.ToString());
        }

        [HttpPost]
        public Subject AddSubject([FromBody] Subject data)
        {
            var id = Guid.NewGuid().ToString();
            var item = new Subject
            {
                SubjectId = id,
                SubjectName = data.SubjectName
            };
            SubjectData.Add(item);
            return item;
        }

        [HttpPut("{id}")]
        public Subject EditSubject(string id, [FromBody] Subject data)
        {
            var findId = SubjectData.FirstOrDefault(it => it.SubjectId == id.ToString());
             var item = new Subject
            {
                SubjectId = id,
                SubjectName = data.SubjectName
            };
            SubjectData.Remove(findId);
            SubjectData.Add(item);
            return item;
        }

        [HttpDelete("{id}")]
        public void DeletedSubject(string id)
        {
            var deleted = SubjectData.FirstOrDefault(it => it.SubjectId == id.ToString());
            SubjectData.Remove(deleted);
        }


    }
}