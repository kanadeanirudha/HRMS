using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace AERP.DataProvider
{
    public class AttendenceMonitoringSystemDataProvider : DBInteractionBase, IAttendenceMonitoringSystemDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public AttendenceMonitoringSystemDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public AttendenceMonitoringSystemDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from AttendenceMonitoringSystem table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetAttendenceMonitoringSystemBySearch(AttendenceMonitoringSystemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AttendenceMonitoringSystem> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AttendenceMonitoringSystem>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeAttendancePerformanceMonitoringReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLevelOUTPUT", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLevelInput", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Level));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, new DateTime(2015, 01, 01)));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, new DateTime(2015, 12, 31)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Level != 0 ? 0: searchRequest.RoleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Level != 0 ? 0 : searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode != null ? searchRequest.CentreCode : DBNull.Value.ToString()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID ));
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
                    baseEntityCollection.CollectionResponse = new List<AttendenceMonitoringSystem>();
                    while (sqlDataReader.Read())
                    {
                        AttendenceMonitoringSystem item = new AttendenceMonitoringSystem();
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentCount"]) == false)
                        {
                            item.DepartmentCount = Convert.ToInt32(sqlDataReader["DepartmentCount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalEmployeeInCentre"]) == false)
                        {
                            item.TotalEmployeeInCentre = Convert.ToInt32(sqlDataReader["TotalEmployeeInCentre"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentId"]) == false)
                        {
                            item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        {
                            item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        }                        
                        if (DBNull.Value.Equals(sqlDataReader["DeptShortCode"]) == false)
                        {
                            item.DeptShortCode = sqlDataReader["DeptShortCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalEmployeeInDepartment"]) == false)
                        {
                            item.TotalEmployeeInDepartment = Convert.ToInt32(sqlDataReader["TotalEmployeeInDepartment"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFullName"]) == false)
                        {
                            item.EmployeeFullName = sqlDataReader["EmployeeFullName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AttendencePercentage"]) == false)
                        {
                            item.AverageRanking = Convert.ToDecimal(sqlDataReader["AttendencePercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalDaysCount"]) == false)
                        {
                            item.TotalDaysCount =Convert.ToInt32(sqlDataReader["TotalDaysCount"]);
                        }                        
                        if (DBNull.Value.Equals(sqlDataReader["PresentDaysCount"]) == false)
                        {
                            item.PresentDaysCount = Convert.ToInt32(sqlDataReader["PresentDaysCount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AbsentDaysCount"]) == false)
                        {
                            item.AbsentDaysCount = Convert.ToInt32(sqlDataReader["AbsentDaysCount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["HolidaysCount"]) == false)
                        {
                            item.HolidaysCount = Convert.ToInt32(sqlDataReader["HolidaysCount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WeeklyoffCount"]) == false)
                        {
                            item.WeeklyoffCount = Convert.ToInt32(sqlDataReader["WeeklyoffCount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnInformedDaysCount"]) == false)
                        {
                            item.UnInformedDaysCount = Convert.ToInt32(sqlDataReader["UnInformedDaysCount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LWPCount"]) == false)
                        {
                            item.LWPCount = Convert.ToInt32(sqlDataReader["LWPCount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnInformedDaysCount"]) == false)
                        {
                            item.InformedLeavesCount = Convert.ToInt32(Convert.ToInt32(sqlDataReader["AbsentDaysCount"]) - Convert.ToInt32(sqlDataReader["LWPCount"]));
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
                       
                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (searchRequest.Level == 0)
                    {
                        if (cmdToExecute.Parameters["@iLevelOUTPUT"].Value != null)
                        {
                            baseEntityCollection.AccessLevel = (Int32)cmdToExecute.Parameters["@iLevelOUTPUT"].Value;
                        }
                    }
                    else
                    {
                        baseEntityCollection.AccessLevel = searchRequest.Level;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AttendenceMonitoringSystem_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// <summary>
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AttendenceMonitoringSystem> GetAttendenceMonitoringSystemByCentreCode(AttendenceMonitoringSystem item)
        {
            IBaseEntityResponse<AttendenceMonitoringSystem> response = new BaseEntityResponse<AttendenceMonitoringSystem>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_AttendenceMonitoringSystem_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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

                    while (sqlDataReader.Read())
                    {
                        AttendenceMonitoringSystem _item = new AttendenceMonitoringSystem();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeCode"]) == false)
                        {
                            _item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        }                       
                       
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            _item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        } 
                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
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
            return response;
        }      
        
        /// <summary>
        /// Select all record from AttendenceMonitoringSystem table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetEmployeeList(AttendenceMonitoringSystemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AttendenceMonitoringSystem> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AttendenceMonitoringSystem>();
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
                    cmdToExecute.CommandText = "dbo.USP_AttendenceMonitoringSystem_GetEmployeeList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                  //  cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<AttendenceMonitoringSystem>();
                    while (sqlDataReader.Read())
                    {
                        AttendenceMonitoringSystem item = new AttendenceMonitoringSystem();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                            //item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                          //  item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_AttendenceMonitoringSystem_SelectAll' reported the ErrorCode: " + _errorCode);
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


        /// <summary>
        /// Select all record from AttendenceMonitoringSystem table with search parameters for employee list ByCentreCodeAndDeptID
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetAttendenceDetailsByEmployeeID(AttendenceMonitoringSystemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AttendenceMonitoringSystem> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AttendenceMonitoringSystem>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeAttendanceSpanWiseReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
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
                    baseEntityCollection.CollectionResponse = new List<AttendenceMonitoringSystem>();
                    while (sqlDataReader.Read())
                    {
                        AttendenceMonitoringSystem item = new AttendenceMonitoringSystem();
                        if (DBNull.Value.Equals(sqlDataReader["HolidayDescription"]) == false)
                        {
                            item.HolidayDescription = Convert.ToString(sqlDataReader["HolidayDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AttendanceDate"]) == false)
                        {
                            item.AttendanceDate = Convert.ToDateTime(sqlDataReader["AttendanceDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AttendanceDescription"]) == false)
                        {
                            item.AttendanceDescription = Convert.ToString(sqlDataReader["AttendanceDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AttendanceStatus"]) == false)
                        {
                            item.AttendanceStatus = Convert.ToString(sqlDataReader["AttendanceStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WeeklyOffStatus"]) == false)
                        {
                            item.WeeklyOffStatus =Convert.ToBoolean( sqlDataReader["WeeklyOffStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApplicationDate"]) == false)
                        {
                           item.ApplicationDate =Convert.ToDateTime( sqlDataReader["ApplicationDate"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["ApplicationStatus"]) == false)
                        //{
                        //    item.ApplicationStatus = Convert.ToBoolean(sqlDataReader["ApplicationStatus"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["FullDayHalfDayFlag"]) == false)
                        {
                            item.FullDayHalfDayFlag = Convert.ToBoolean(sqlDataReader["FullDayHalfDayFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["HalfLeaveStatus"]) == false)
                        {
                            item.HalfLeaveStatus = Convert.ToString(sqlDataReader["HalfLeaveStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveCode"]) == false)
                        {
                            item.LeaveCode = Convert.ToString("(" + sqlDataReader["LeaveCode"]+")");
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CheckInTime"]) == false)
                        {
                            item.CheckInTime = Convert.ToString(sqlDataReader["CheckInTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CheckOutTime"]) == false)
                        {
                            item.CheckOutTime = Convert.ToString(sqlDataReader["CheckOutTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WorkingHour"]) == false)
                        {
                            item.WorkingHour = Convert.ToString(sqlDataReader["WorkingHour"]);
                        }                        
                        if (DBNull.Value.Equals(sqlDataReader["LeaveCode"]) == false)
                        {
                            item.LeaveCode = Convert.ToString("(" + sqlDataReader["LeaveCode"] + ")");
                        }
                        else
                        {
                            item.LeaveCode = Convert.ToString("(LWP)");
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["ApprovalStatus"]) == false)
                        //{
                        //    item.ApprovalStatus = Convert.ToBoolean(sqlDataReader["ApprovalStatus"]);
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
                        throw new Exception("Stored Procedure 'USP_AttendenceMonitoringSystem_GetByCenterCodeAndDepartmentWise' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetAttendenceDetailsByEmployeeID_WebAPI(AttendenceMonitoringSystemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AttendenceMonitoringSystem> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AttendenceMonitoringSystem>();
            SqlCommand cmdToExecute = new SqlCommand();
            string URl = "";
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeAttendanceSpanWiseReport_WebAPI";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, URl));
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
                    baseEntityCollection.CollectionResponse = new List<AttendenceMonitoringSystem>();
                    while (sqlDataReader.Read())
                    {
                        AttendenceMonitoringSystem item = new AttendenceMonitoringSystem();
                        if (DBNull.Value.Equals(sqlDataReader["HolidayDescription"]) == false)
                        {
                            item.HolidayDescription = Convert.ToString(sqlDataReader["HolidayDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AttendanceDate"]) == false)
                        {
                            item.AttendanceDate = Convert.ToDateTime(sqlDataReader["AttendanceDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AttendanceDescription"]) == false)
                        {
                            item.AttendanceDescription = Convert.ToString(sqlDataReader["AttendanceDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AttendanceStatus"]) == false)
                        {
                            item.AttendanceStatus = Convert.ToString(sqlDataReader["AttendanceStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WeeklyOffStatus"]) == false)
                        {
                            item.WeeklyOffStatus = Convert.ToBoolean(sqlDataReader["WeeklyOffStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApplicationDate"]) == false)
                        {
                            item.ApplicationDate = Convert.ToDateTime(sqlDataReader["ApplicationDate"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["ApplicationStatus"]) == false)
                        //{
                        //    item.ApplicationStatus = Convert.ToBoolean(sqlDataReader["ApplicationStatus"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["FullDayHalfDayFlag"]) == false)
                        {
                            item.FullDayHalfDayFlag = Convert.ToBoolean(sqlDataReader["FullDayHalfDayFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["HalfLeaveStatus"]) == false)
                        {
                            item.HalfLeaveStatus = Convert.ToString(sqlDataReader["HalfLeaveStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveCode"]) == false)
                        {
                            item.LeaveCode = Convert.ToString("(" + sqlDataReader["LeaveCode"] + ")");
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CheckInTime"]) == false)
                        {
                            item.CheckInTime = Convert.ToString(sqlDataReader["CheckInTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CheckOutTime"]) == false)
                        {
                            item.CheckOutTime = Convert.ToString(sqlDataReader["CheckOutTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WorkingHour"]) == false)
                        {
                            item.WorkingHour = Convert.ToString(sqlDataReader["WorkingHour"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveCode"]) == false)
                        {
                            item.LeaveCode = Convert.ToString("(" + sqlDataReader["LeaveCode"] + ")");
                        }
                        else
                        {
                            item.LeaveCode = Convert.ToString("(LWP)");
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["ApprovalStatus"]) == false)
                        //{
                        //    item.ApprovalStatus = Convert.ToBoolean(sqlDataReader["ApprovalStatus"]);
                        //}
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        System.Data.SqlTypes.SqlString _title = (System.Data.SqlTypes.SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                        baseEntityCollection.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode,
                            Title = (string)_title
                        });
                    }
                   
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AttendenceMonitoringSystem_GetByCenterCodeAndDepartmentWise' reported the ErrorCode: " + _errorCode);
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

        #endregion
    }
}
