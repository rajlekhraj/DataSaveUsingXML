using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataSaveUsingXML
{
    public static class DatabaseOperation
    {
        public static string ConnectionString
        {
            get;
            set;
        }
        public static string InsertIntoDatabase(string InputParameter, string ProcedureName)
        {            
            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();                                       
                    SqlCommand sql_cmnd = new SqlCommand(ProcedureName, sqlConnection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@XMLData", SqlDbType.Xml).Value = InputParameter;
                    sql_cmnd.ExecuteNonQuery();                    
                    return "Success";
                }
            }
            catch (Exception ex)
            {               
                return "Error : " + ex.Message;
            }          
        }
    }
}
