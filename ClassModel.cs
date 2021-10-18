using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Festo_BackEnd_Task
{
    public static class ConnectionString
    {
        internal static string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
    }
    public class ClassModal
    {
        internal List<Course> lstCourse;
        internal List<CourseType> lstcourseTypes;
    }

    public class Course
    {
        public long CourseID { get; set; }
        public string CourseTitle { get; set; }
        public long CourseTypeID { get; set; }
    }
    public class CourseType
    {
        public long ID { get; set; }
        public string Name { get; set; }

    }

}
