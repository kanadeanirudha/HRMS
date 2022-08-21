using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AMS.DataProvider
{
    public class EmployeeAttendanceReportDataProvider : DBInteractionBase, IEmployeeAttendanceReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        public EmployeeAttendanceReportDataProvider()
        {
        }

        public EmployeeAttendanceReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        /// Select all record from Employee Attendance Report table with search parameters.
        public IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeAttendanceReportSelectAll(EmployeeAttendanceReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeAttendanceReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeAttendanceReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeAttendance_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.FromDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.UptoDate)));


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
                    baseEntityCollection.CollectionResponse = new List<EmployeeAttendanceReport>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeAttendanceReport item = new EmployeeAttendanceReport();
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        
                        baseEntityCollection.CollectionResponse.Add(item);                        
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeAttendance_Report' reported the ErrorCode: " + _errorCode);
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



        //Get Employee Form Center And Department       
        public IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeCentreAndDepartmentWise(EmployeeAttendanceReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeAttendanceReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeAttendanceReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetEmployeeFromCenterAndDepartment_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentIDs", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));
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
                    baseEntityCollection.CollectionResponse = new List<EmployeeAttendanceReport>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeAttendanceReport item = new EmployeeAttendanceReport();
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeName"]) == false)
                        {
                            item.EmployeeName = sqlDataReader["EmployeeName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeCode"]) == false)
                        {
                            item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_GetEmployeeFromCenterAndDepartment_SelectAll' reported the ErrorCode: " + _errorCode);
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


        //GetEmployeeAttendanceReportData
        //Get Employee Attendance Record       
        public IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeAttendanceReportData(EmployeeAttendanceReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeAttendanceReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeAttendanceReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeAttendanceDetails_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeptmentIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToString(searchRequest.DepartmentID)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                    baseEntityCollection.CollectionResponse = new List<EmployeeAttendanceReport>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeAttendanceReport item = new EmployeeAttendanceReport();
                        if (DBNull.Value.Equals(sqlDataReader["AttendanceDate"]) == false)
                        {
                            item.AttendanceDate = sqlDataReader["AttendanceDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        {
                            item.DepatmentName = sqlDataReader["DepartmentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFullName"]) == false)
                        {
                            item.EmployeeName = sqlDataReader["EmployeeFullName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CheckInTime"]) == false)
                        {
                            item.CheckInTime = sqlDataReader["CheckInTime"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CheckOutTime"]) == false)
                        {
                            item.CheckOutTime = sqlDataReader["CheckOutTime"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WorkingHour"]) == false)
                        {
                            item.WorkingHour = sqlDataReader["WorkingHour"].ToString();
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["IsConsiderForLateMark"]) == false)
                        //{
                        item.IsConsiderForLateMark = Convert.ToBoolean(sqlDataReader["IsConsiderForLateMark"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_LeaveEmployeeAttendanceDetails_Report' reported the ErrorCode: " + _errorCode);
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


        #endregion

    }
}
