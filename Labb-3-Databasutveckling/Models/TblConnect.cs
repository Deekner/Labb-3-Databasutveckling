using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3_Databasutveckling.Models
{
    public partial class TblConnect
    {
        public int TblConnect1 { get; set; }
        public int? CourseId { get; set; }
        public int? EmployeeId { get; set; }
        public int? GradeId { get; set; }
        public int? StudentId { get; set; }

        public virtual TblCourse Course { get; set; }
        public virtual TblEmployee Employee { get; set; }
        public virtual TblGrade Grade { get; set; }
        public virtual TblStudent Student { get; set; }
    }
}
