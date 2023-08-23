using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbcontext _dbContext;

        public StudentController(StudentDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Getstudents()
        {
            var student = _dbContext.collegeStudents.ToList();
            return Ok(student);
        }
        [HttpPost]
        public IActionResult RegisterStudent(studentlist student)
        {
            var lastStudent = _dbContext.collegeStudents.OrderByDescending(s => s.Id).FirstOrDefault();
            int sequenceNumber = 1;

            if (lastStudent != null)
            {
                var lastRegNo = lastStudent.RegNo;
                var lastSequencePart = lastRegNo.Substring(6); // Get the sequence part of the last regno

                if (int.TryParse(lastSequencePart, out int lastSequenceNumber))
                {
                    sequenceNumber = lastSequenceNumber + 1;
                }
            }

            student.RegNo = $"20pca{sequenceNumber:D3}";

            // Set Created and Updated dates
            student.CreatedDate = DateTime.Now;
            student.UpdatedDate = DateTime.Now;

            _dbContext.collegeStudents.Add(student);
            _dbContext.SaveChanges();

            return Ok(student);
        }


    }
}
