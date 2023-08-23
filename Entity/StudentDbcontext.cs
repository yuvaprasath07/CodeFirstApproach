using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class StudentDbcontext: DbContext
    {
        public DbSet<studentlist> collegeStudents { get; set; }
        public StudentDbcontext(DbContextOptions<StudentDbcontext> options) : base(options) { }

       

     

    }
}
