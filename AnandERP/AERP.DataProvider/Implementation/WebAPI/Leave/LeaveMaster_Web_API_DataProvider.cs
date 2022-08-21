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
    public class LeaveMaster_Web_API_DataProvider : DBInteractionBase, ILeaveMaster_Web_API_DataProvider
    {
        private readonly ILogger _logException;
        public IBaseEntityCollectionResponse<LeaveMaster> getLeaves(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> response = new BaseEntityCollectionResponse<LeaveMaster>();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TD_GetLeaves";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nSyncType", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SyncType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLastSyncDate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LastSyncDate));
                    if (_mainConnectionIsCreatedLocal)
                    {
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
                    response.CollectionResponse = new List<LeaveMaster>();
                    while (sqlDataReader.Read())
                    {
                        LeaveMaster _LeaveMaster = new LeaveMaster();

                        _LeaveMaster.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        _LeaveMaster.LeaveCode = sqlDataReader["LeaveCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LeaveCode"]);
                        _LeaveMaster.LeaveDescription = sqlDataReader["LeaveDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LeaveDescription"]);
                        _LeaveMaster.NumberOfLeaves = sqlDataReader["NumberOfLeaves"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["NumberOfLeaves"]);
                        _LeaveMaster.MaxLeaveAtTime = sqlDataReader["MaxLeaveAtTime"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["MaxLeaveAtTime"]);
                        _LeaveMaster.DaysBeforeApplicationSubmitted = sqlDataReader["DaysBeforeApplicationSubmitted"] is DBNull ? new  Int16() : Convert.ToInt16(sqlDataReader["DaysBeforeApplicationSubmitted"]);
                        _LeaveMaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _LeaveMaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);

                        response.CollectionResponse.Add(_LeaveMaster);
                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null && cmdToExecute.Parameters["@sURL"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        System.Data.SqlTypes.SqlString _title = (System.Data.SqlTypes.SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                        response.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode,
                            Title = (string)_title
                        });
                    }
                   

                    //response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_WEB_API_TD_GetLeaves' reported the ErrorCode: " + _errorCode);
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
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }

        public IBaseEntityCollectionResponse<LeaveMaster> getVersionNumber(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> response = new BaseEntityCollectionResponse<LeaveMaster>();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TD_GetVersions";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));

                    if (_mainConnectionIsCreatedLocal)
                    {
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
                    response.CollectionResponse = new List<LeaveMaster>();
                    while (sqlDataReader.Read())
                    {
                        LeaveMaster _LeaveMaster = new LeaveMaster();

                       
                        _LeaveMaster.VersionNumber = sqlDataReader["VersionNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VersionNumber"]);
                        _LeaveMaster.URL = sqlDataReader["BuildURL"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BuildURL"]);

                        response.CollectionResponse.Add(_LeaveMaster);
                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        System.Data.SqlTypes.SqlString _title = (System.Data.SqlTypes.SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                        response.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode,
                            Title = (string)_title
                        });
                    }

                    //response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_WEB_API_TD_GetLeaves' reported the ErrorCode: " + _errorCode);
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
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }

        public IBaseEntityResponse<LeaveMaster> InsertLeaveApplicationCancel(LeaveMaster item)
        {
            IBaseEntityResponse<LeaveMaster> response = new BaseEntityResponse<LeaveMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_LeaveApplicationCancel_Insert_WEBAPI";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));

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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    if (_rowsAffected > 1)
                    {
                        //item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    System.Data.SqlTypes.SqlString _title = (System.Data.SqlTypes.SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                    item.URL = (string)_title;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.NotExist && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveManualAttendance_Insert_Web_API' reported the ErrorCode: " +
                                            _errorCode);
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
        public IBaseEntityResponse<LeaveManualAttendance> InsertLeaveManualAttendance(LeaveManualAttendance item)
        {
            IBaseEntityResponse<LeaveManualAttendance> response = new BaseEntityResponse<LeaveManualAttendance>();
            SqlCommand cmdToExecute = new SqlCommand();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_LeaveManualAttendance_Insert_Web_API";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtAttendanceDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.AttendanceDate)));
                    if (item.AttendenceFor == "B")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tsCheckInTime", SqlDbType.Time, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CheckInTime));
                        cmdToExecute.Parameters.Add(new SqlParameter("@tsCheckOutTime", SqlDbType.Time, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CheckOutTime));
                    }
                    else if (item.AttendenceFor == "COT")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tsCheckOutTime", SqlDbType.Time, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CheckOutTime));
                        cmdToExecute.Parameters.Add(new SqlParameter("@tsCheckInTime", SqlDbType.Time, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.AttendenceFor == "CIT")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tsCheckInTime", SqlDbType.Time, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CheckInTime));
                        cmdToExecute.Parameters.Add(new SqlParameter("@tsCheckOutTime", SqlDbType.Time, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsReason", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Reason));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@nsStatus", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Status));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@iApprovedByUSerID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApprovedByUSerID));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@bIsWorkFlow", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsWorkFlow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));

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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    if (_rowsAffected > 1)
                    {
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    System.Data.SqlTypes.SqlString _title = (System.Data.SqlTypes.SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                    item.URL = (string)_title;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.NotExist && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveManualAttendance_Insert_Web_API' reported the ErrorCode: " +
                                            _errorCode);
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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

        public IBaseEntityResponse<AddAttendance> AddAttendance(AddAttendance item)
        {
            IBaseEntityResponse<AddAttendance> response = new BaseEntityResponse<AddAttendance>();
            SqlCommand cmdToExecute = new SqlCommand();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_EmployeeBulkAttendences_InsertXML_WebAPI";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                  //  cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForBulkAttendance", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));

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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                  /*  if (_rowsAffected > 1)
                    {
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }*/
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    System.Data.SqlTypes.SqlString _title = (System.Data.SqlTypes.SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                    item.URL = (string)_title;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.NotExist && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeBulkAttendences_InsertXML_WebAPI' reported the ErrorCode: " +
                                            _errorCode);
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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

        public IBaseEntityCollectionResponse<LeaveMaster> GetLeaveDetails(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> response = new BaseEntityCollectionResponse<LeaveMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveDetails_ByEmployee_LeaveMaster_LeaveSessionID_WebAPI";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveSessionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LeaveSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));
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
                    response.CollectionResponse = new List<LeaveMaster>();
                    while (sqlDataReader.Read())
                    {
                        LeaveMaster _item = new LeaveMaster();
                        if (DBNull.Value.Equals(sqlDataReader["LeaveRuleMasterID"]) == false)
                        {
                            _item.ID = Convert.ToInt16(sqlDataReader["LeaveRuleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfLeaves"]) == false)
                        {
                            _item.NumberOfLeaves = Convert.ToInt16(sqlDataReader["NumberOfLeaves"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaxLeaveAtTime"]) == false)
                        {
                            _item.MaxLeaveAtTime = Convert.ToInt16(sqlDataReader["MaxLeaveAtTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BalanceLeave"]) == false)
                        {
                            _item.BalanceLeave = Convert.ToDouble(sqlDataReader["BalanceLeave"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DaysBeforeApplicationSubmitted"]) == false)
                        {
                            _item.DaysBeforeApplicationSubmitted = Convert.ToInt16(sqlDataReader["DaysBeforeApplicationSubmitted"]);
                        }
                        /*if (DBNull.Value.Equals(sqlDataReader["IsCompensatory"]) == false)
                        {
                            _item.IsCompensatory = Convert.ToDouble(sqlDataReader["IsCompensatory"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DocumentCompulsaryFlag"]) == false)
                        {
                            _item.DocumentCompulsaryFlag = Convert.ToBoolean(sqlDataReader["DocumentCompulsaryFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DocumentRequiredFlag"]) == false)
                        {
                            _item.DocumentRequiredFlag = Convert.ToBoolean(sqlDataReader["DocumentRequiredFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DocumentRequiredID"]) == false)
                        {
                            _item.DocumentRequiredID = Convert.ToInt32(sqlDataReader["DocumentRequiredID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DaysBeforeApplicationSubmitted"]) == false)
                        {
                            _item.DaysBeforeApplicationSubmitted = Convert.ToInt16(sqlDataReader["DaysBeforeApplicationSubmitted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveApplicationSubmittedUptoDays"]) == false)
                        {
                            _item.LeaveApplicationSubmittedUptoDays = Convert.ToInt16(sqlDataReader["LeaveApplicationSubmittedUptoDays"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SpanFromDayDiffecrence"]) == false)
                        {
                            _item.LeaveAttendanceSpanFromDayDiffecrence = Convert.ToInt16(sqlDataReader["SpanFromDayDiffecrence"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PermitedDaysAfterLeaveCan"]) == false)
                        {
                            _item.PermitedDaysAfterLeaveCan = Convert.ToInt16(sqlDataReader["PermitedDaysAfterLeaveCan"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaxDaysUpto"]) == false)
                        {
                            _item.MaxDaysUpto = Convert.ToInt16(sqlDataReader["MaxDaysUpto"]);
                        }*/

                        response.CollectionResponse.Add(_item);
                        
                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        System.Data.SqlTypes.SqlString _title = (System.Data.SqlTypes.SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                        response.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode,
                            Title = (string)_title
                        });
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.NotExist && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveDetails_ByEmployee_LeaveMaster_LeaveSessionID_Web_API' reported the ErrorCode: " +
                                            _errorCode);
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

        public IBaseEntityResponse<LeaveAttendanceSpecialRequest> InsertSpecialLeaveAttendance(LeaveAttendanceSpecialRequest item)
        {
            IBaseEntityResponse<LeaveAttendanceSpecialRequest> response = new BaseEntityResponse<LeaveAttendanceSpecialRequest>();
            SqlCommand cmdToExecute = new SqlCommand();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_LeaveAttendanceSpecialRequest_Insert_Web_API";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daRequestedDate", SqlDbType.Date, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RequestedDate));
                    if (item.StatusFlag == "Early")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tLeavingTime", SqlDbType.Time, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LeavingTime));
                        cmdToExecute.Parameters.Add(new SqlParameter("@tCommingTime", SqlDbType.Time, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tCommingTime", SqlDbType.Time, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CommingTime));
                        cmdToExecute.Parameters.Add(new SqlParameter("@tLeavingTime", SqlDbType.Time, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@sStatusFlag", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StatusFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sReason", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Reason));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,15,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed,!string.IsNullOrEmpty(item.CentreCode)?item.CentreCode:string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));

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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    if (_rowsAffected > 1)
                    {
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    System.Data.SqlTypes.SqlString _title = (System.Data.SqlTypes.SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                    item.URL = (string)_title;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.NotExist && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveAttendanceSpecialRequest_Insert_Web_API' reported the ErrorCode: " +
                                            _errorCode);
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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

        public IBaseEntityCollectionResponse<LeaveMaster> GetManualAttendance(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> response = new BaseEntityCollectionResponse<LeaveMaster>();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_LeaveManualAttendance_SelectAll_Web_API";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));

                    if (_mainConnectionIsCreatedLocal)
                    {
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
                    response.CollectionResponse = new List<LeaveMaster>();
                    while (sqlDataReader.Read())
                    {
                        LeaveMaster _LeaveMaster = new LeaveMaster();

                        _LeaveMaster.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        _LeaveMaster.AttendanceDate = sqlDataReader["AttendanceDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AttendanceDate"]);
                        if (DBNull.Value.Equals(sqlDataReader["CheckInTime"]) == false)
                        {
                            _LeaveMaster.CheckInTime = sqlDataReader.GetTimeSpan(4);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CheckOutTime"]) == false)
                        {
                            _LeaveMaster.CheckOutTime = sqlDataReader.GetTimeSpan(5);
                        }
                        _LeaveMaster.Reason = sqlDataReader["Reason"].ToString();
                        _LeaveMaster.Status = sqlDataReader["Status"].ToString();

                        response.CollectionResponse.Add(_LeaveMaster);
                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        System.Data.SqlTypes.SqlString _title = (System.Data.SqlTypes.SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                        response.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode,
                            Title = (string)_title
                        });
                    }

                    //response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_LeaveManualAttendance_SelectAll_Web_API' reported the ErrorCode: " + _errorCode);
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
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }

        public IBaseEntityCollectionResponse<LeaveMaster> GetSpecialLeave(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> response = new BaseEntityCollectionResponse<LeaveMaster>();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_LeaveAttendanceSpecialRequest_SelectAll_Web_API";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));

                    if (_mainConnectionIsCreatedLocal)
                    {
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
                    response.CollectionResponse = new List<LeaveMaster>();
                    while (sqlDataReader.Read())
                    {
                        LeaveMaster _LeaveMaster = new LeaveMaster();

                        _LeaveMaster.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        _LeaveMaster.AttendanceDate = sqlDataReader["RequestedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RequestedDate"]);
                        if (DBNull.Value.Equals(sqlDataReader["CommingTime"]) == false)
                        {
                            _LeaveMaster.CommingTime = sqlDataReader.GetTimeSpan(4);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeavingTime"]) == false)
                        {
                            _LeaveMaster.LeavingTime = sqlDataReader.GetTimeSpan(5);
                        }
                        _LeaveMaster.Reason = sqlDataReader["Reason"].ToString();
                        _LeaveMaster.Status = sqlDataReader["ApprovalStatus"].ToString();

                        response.CollectionResponse.Add(_LeaveMaster);
                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        System.Data.SqlTypes.SqlString _title = (System.Data.SqlTypes.SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                        response.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode,
                            Title = (string)_title
                        });
                    }

                    //response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_LeaveAttendanceSpecialRequest_SelectAll_Web_API' reported the ErrorCode: " + _errorCode);
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
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }

        public IBaseEntityCollectionResponse<LeaveMaster> GetLeaveApplicationApprocedPendingStatus_SearchList(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<LeaveMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_LeaveApplicationApprocedPendingStatus_SearchList_WEB_API";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));

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
                    baseEntityCollection.CollectionResponse = new List<LeaveMaster>();
                    while (sqlDataReader.Read())
                    {
                        LeaveMaster _item = new LeaveMaster();
                        _item.LeaveApplicationID = Convert.ToInt32(sqlDataReader["LeaveApplicationID"]);
                        _item.ApplicationCode = sqlDataReader["ApplicationCode"].ToString();
                        _item.LeaveApplicationTransactionID = Convert.ToInt32(sqlDataReader["LeaveApplicationTransactionID"]);
                        _item.ID = Convert.ToInt32(sqlDataReader["LeaveMasterID"]);
                        _item.ApplicationDate = Convert.ToString(sqlDataReader["ApplicationDate"]);
                        _item.LeaveDate = sqlDataReader["Dates"].ToString();
                        _item.FullDayHalfDayDetails = sqlDataReader["FullDayHalfDayDetails"].ToString();
                        _item.LeaveApprovalStatus = sqlDataReader["ApprovalStatus"].ToString();
                        _item.LeaveDescription = sqlDataReader["LeaveDescription"].ToString();
                        _item.LeaveCode = sqlDataReader["LeaveCode"].ToString();
                        _item.LeaveSessionID = Convert.ToInt32(sqlDataReader["LeaveSessionId"]);


                        //  item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);

                        baseEntityCollection.CollectionResponse.Add(_item);

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

                    //response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_LeaveAttendanceSpecialRequest_SelectAll_Web_API' reported the ErrorCode: " + _errorCode);
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
