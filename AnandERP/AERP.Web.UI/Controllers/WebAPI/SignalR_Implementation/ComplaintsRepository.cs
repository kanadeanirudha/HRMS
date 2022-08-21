using AERP.DTO;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AERP.Web.UI
{
    public class ComplaintsRepository
    {
        public static int getComplaintsCount()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString))
            {
                connection.Open();
                int isSuccess = 0;
                using (SqlCommand cmd = new SqlCommand("USP_WEB_API_GetComplaintCount", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Notification = null;
                    SqlDependency.Start(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);

                    SqlDependency dependancy = new SqlDependency(cmd);

                    dependancy.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            isSuccess = reader["IsSuccess"] is DBNull ? new Int32() : Convert.ToInt32(reader["IsSuccess"]);
                        }
                    }
                }
                return isSuccess;
            }
        }

        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            NotificationHub.show();
        }
    }
}