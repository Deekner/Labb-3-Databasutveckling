using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3_Databasutveckling.Models
{
    public partial class TblStudent
    {
        public TblStudent()
        {
            TblConnect = new HashSet<TblConnect>();
            TblCourse = new HashSet<TblCourse>();
            TblGrade = new HashSet<TblGrade>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

        public virtual ICollection<TblConnect> TblConnect { get; set; }
        public virtual ICollection<TblCourse> TblCourse { get; set; }
        public virtual ICollection<TblGrade> TblGrade { get; set; }
    }
}
