using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3_Databasutveckling.Models
{
    public partial class TblCourse
    {
        public TblCourse()
        {
            TblConnect = new HashSet<TblConnect>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int EmployeeId { get; set; }
        public int? StudentId { get; set; }

        public virtual TblEmployee Employee { get; set; }
        public virtual TblStudent Student { get; set; }
        public virtual ICollection<TblConnect> TblConnect { get; set; }
    }
}
