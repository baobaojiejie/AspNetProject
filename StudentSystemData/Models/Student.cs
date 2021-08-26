using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystemData.Models
{
    public class Student
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int numOfCourses { get; set; }
        public string graduateDate { get; set; }

    }
}