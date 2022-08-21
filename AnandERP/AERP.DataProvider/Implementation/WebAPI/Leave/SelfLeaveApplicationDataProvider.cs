using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace AERP.DataProvider
{
    public class SelfLeaveApplicationDataProvider : DBInteractionBase, ISelfLeaveApplicationDataProvider
    {
        public IBaseEntityResponse<SelfLeaveApplication> InsertSelfLeave(SelfLeaveApplication item)
        {
            IBaseEntityResponse<SelfLeaveApplication> response = new BaseEntityResponse<SelfLeaveApplication>();

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
                    cmdToExecute.CommandText = "dbo.USP_LeaveApplication_Insert_WEB_API";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LeaveMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daFromDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.FromDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daUptoDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.UptoDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siTotalfullDaysLeave", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalfullDaysLeave));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siTotalHalfDayLeave", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalHalfDayLeave));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@cHalfLeaveStatus", SqlDbType.Char, 2,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.HalfLeaveStatus != null ? item.HalfLeaveStatus.Trim() : string.Empty));                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsFirstHalf", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsFirstHalf));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsSecondHalf", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsSecondHalf));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sLeaveReason", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LeaveReason != null ? item.LeaveReason.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sApplicationStatus", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ApplicationStatus != null ? item.ApplicationStatus.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPendingAtApprovalLevel", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PendingAtApprovalLevel));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveSessionId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LeaveSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode != null ? item.CentreCode.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveRuleMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LeaveRuleMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskApproverNotificationStatus", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskApproverNotificationStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskApproverNotification_InsertError", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskApproverNotification_InsertError));
                    if (item.SelectedIDs != string.Empty && item.SelectedIDs != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSelectedIDs", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SelectedIDs));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSelectedIDs", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDocumentRequiredID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DocumentRequiredID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFileName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FileName != null ? item.FileName.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20,
                                          ParameterDirection.Input, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.VersionNumber));
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
                        throw new Exception("Stored Procedure 'USP_LeaveApplication_Insert_WEB_API' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<SelfLeaveApplication> getSelfLeaves(SelfLeaveApplication item)
        {
            IBaseEntityCollectionResponse<SelfLeaveApplication> response = new BaseEntityCollectionResponse<SelfLeaveApplication>();
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
                    cmdToExecute.CommandText = "USP_LeaveEmployeeAttendanceSpanWiseReport_Web_API";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LeaveSessionFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LeaveSessionUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveSessionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LeaveSessionID));
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
                    response.CollectionResponse = new List<SelfLeaveApplication>();
                    while (sqlDataReader.Read())
                    {
                        SelfLeaveApplication _SelfLeaveApplication = new SelfLeaveApplication();

                        _SelfLeaveApplication.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        _SelfLeaveApplication.AttendanceDate = sqlDataReader["AttendanceDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["AttendanceDate"]);
                        _SelfLeaveApplication.AttendanceDescription = sqlDataReader["AttendanceDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AttendanceDescription"]);
                        _SelfLeaveApplication.workingHour = sqlDataReader["workingHour"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["workingHour"]);

                        _SelfLeaveApplication.LeaveSessionFromDate = sqlDataReader["LeaveSessionFromDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LeaveSessionFromDate"]);
                        _SelfLeaveApplication.LeaveSessionUptoDate = sqlDataReader["LeaveSessionUptoDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LeaveSessionUptoDate"]);

                        response.CollectionResponse.Add(_SelfLeaveApplication);
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

                 //   response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_LeaveEmployeeAttendanceSpanWiseReport_Web_API' reported the ErrorCode: " + _errorCode);
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

    }
}


