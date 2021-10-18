using Festo_BackEnd_Task.DL;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Festo_BackEnd_Task.BL
{
    public class BlCouse
    {
        public ClassModal Get_CourseInformation()
        {
            try
            {
                DLCourse objCourse = new DLCourse();
                DataSet resultSet = objCourse.CourseInformation_Get();
                return Map_Records(resultSet);
            }
            catch (Exception ex) { return null; }

        }
        public ClassModal Get_CourseWithFilter(string input)
        {
            DLCourse objdlCourse = new DLCourse();
            DataSet dset = objdlCourse.FilterData_Get(input);
            return Map_Records(dset);
        }
        private ClassModal Map_Records(DataSet resultSet)
        {
            ClassModal modal = new ClassModal();
            try
            {
                if (Convert.ToInt64(resultSet.Tables[0].Rows[0]["ID"]) > 0)
                {
                    DataTable courseTable = resultSet.Tables[0];
                    DataTable typeTable = resultSet.Tables[1];
                    modal.lstCourse = new List<Course>(
                        courseTable.AsEnumerable().Select(e =>
                        {
                            return new Course()
                            {
                                CourseID = e.Field<long>("ID"),
                                CourseTitle = e.Field<string>("Title"),
                                CourseTypeID = e.Field<long>("CourseTypeID")
                            };
                        }).ToList()
                     );
                    modal.lstcourseTypes = new List<CourseType>(
                        typeTable.AsEnumerable().Select(row =>
                        {
                            return new CourseType()
                            {
                                ID = row.Field<long>("ID"),
                                Name = row.Field<string>("Name")
                            };
                        }).ToList()
                        );
                }
                else
                {
                    Console.WriteLine("ErrorCode: {0} ErrorMessage: {1}", resultSet.Tables[0].Rows[0]["ID"].ToString(), resultSet.Tables[0].Rows[0]["Title"].ToString());
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return modal;
        }
    }
}
