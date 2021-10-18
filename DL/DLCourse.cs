using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Festo_BackEnd_Task.DL
{
    class DLCourse
    {
        public DataSet CourseInformation_Get()
        {
            return Main_DbCall();
        }
        private DataSet Main_DbCall()
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString.conString))
                {
                    if (con != null)
                    {
                        using (SqlCommand command = new SqlCommand("SP_Festo_UserInformation_Get", con))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            using (SqlDataAdapter ad = new SqlDataAdapter(command))
                            {
                                ad.Fill(dataSet);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dataSet;
        }

        public DataSet FilterData_Get(string input)
        {
            return Type_Filter(input);
        }
        private DataSet Type_Filter(string typename)
        {
            DataSet dbset = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString.conString))
                {
                    if (con != null)
                    {
                        using (SqlCommand command = new SqlCommand("SP_TypeFilter_Get", con))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@name", typename);
                            using (SqlDataAdapter ad = new SqlDataAdapter(command))
                            {
                                ad.Fill(dbset);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dbset;
        }
    }
}
