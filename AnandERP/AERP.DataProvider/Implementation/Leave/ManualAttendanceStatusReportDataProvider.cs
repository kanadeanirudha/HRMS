using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public class ManualAttendanceStatusReportDataProvider : DBInteractionBase,IManualAttendanceStatusReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        public ManualAttendanceStatusReportDataProvider()
        {
          
        }
        public ManualAttendanceStatusReportDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        public IBaseEntityCollectionResponse<ManualAttendanceStatusReport> GetLeaveEmployeeApplicationStatusReportBySearch(ManualAttendanceStatusReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ManualAttendanceStatusReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ManualAttendanceStatusReport>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(searchRequest.ConnectionString))
                {
                    baseEntityCollection.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_ManualAttendanceStatusReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDepartmentIDs", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentIds));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.FromDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.UptoDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsApprovalStatus", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ApprovalStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));

                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    baseEntityCollection.CollectionResponse = new List<ManualAttendanceStatusReport>();
                    while (sqlDataReader.Read())
                    {
                        ManualAttendanceStatusReport item = new ManualAttendanceStatusReport();

                        if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        {
                            item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFullName"]) == false)
                        {
                            item.EmployeeFullName = sqlDataReader["EmployeeFullName"].ToString();
                        }
                       
                        if (DBNull.Value.Equals(sqlDataReader["ApplicationDate"]) == false)
                        {
                            item.ApplicationDate = Convert.ToString(sqlDataReader["ApplicationDate"]);
                        }
                       
                        if (DBNull.Value.Equals(sqlDataReader["ApprovalStatus"]) == false)
                        {
                            item.ApprovalStatus = sqlDataReader["ApprovalStatus"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CheckInTime"]) == false)
                        {
                            item.CheckInTime = sqlDataReader["CheckInTime"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CheckOutTime"]) == false)
                        {
                            item.CheckOutTime = sqlDataReader["CheckOutTime"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Reason"]) == false)
                        {
                            item.Reason = sqlDataReader["Reason"].ToString();
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
                        baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ManualAttendanceStatusReport_SelectAll' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                baseEntityCollection.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

    }
}
