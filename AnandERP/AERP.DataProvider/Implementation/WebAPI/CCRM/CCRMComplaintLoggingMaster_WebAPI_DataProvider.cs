using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{ 
    public class CCRMComplaintLoggingMaster_WebAPI_DataProvider : DBInteractionBase,ICCRMComplaintLoggingMaster_WebAPI_DataProvider
    {
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getComplaintLogsApi(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> response = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_GetComplaintLogs";
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EngineerID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nSyncType", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SyncType));
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
                    response.CollectionResponse = new List<CCRMComplaintLoggingMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMComplaintLoggingMaster _CCRMComplaintLoggingMaster = new CCRMComplaintLoggingMaster();

                        _CCRMComplaintLoggingMaster.CallTktNo = sqlDataReader["CallTicketNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallTicketNumber"]);
                        _CCRMComplaintLoggingMaster.CallCharges = sqlDataReader["CallCharges"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CallCharges"]);
                        _CCRMComplaintLoggingMaster.SerialNo = sqlDataReader["SerialNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SerialNo"]);
                        _CCRMComplaintLoggingMaster.MIFName = sqlDataReader["MIFName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFName"]);
                        _CCRMComplaintLoggingMaster.ModelNo = sqlDataReader["ModelNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModelNo"]);
                        _CCRMComplaintLoggingMaster.AreaPatchName = sqlDataReader["AreaPatchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AreaPatchName"]);
                        _CCRMComplaintLoggingMaster.CallDate = sqlDataReader["CallDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallDate"]);
                        _CCRMComplaintLoggingMaster.SymptomTitle = sqlDataReader["SymptomTitle"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SymptomTitle"]);
                        _CCRMComplaintLoggingMaster.ContractType = sqlDataReader["ContractType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractType"]);
                        _CCRMComplaintLoggingMaster.Phoneno = sqlDataReader["CustomerContact"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerContact"]);
                        _CCRMComplaintLoggingMaster.MCAddress = sqlDataReader["MachineLocation"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MachineLocation"]);
                        _CCRMComplaintLoggingMaster.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        _CCRMComplaintLoggingMaster.CallTypeName = sqlDataReader["CallTypeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallTypeName"]);
                        _CCRMComplaintLoggingMaster.CallTypeID = sqlDataReader["ServiceCallTypeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ServiceCallTypeID"]);
                        _CCRMComplaintLoggingMaster.Allotment = sqlDataReader["Allotment"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["Allotment"]);
                        _CCRMComplaintLoggingMaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _CCRMComplaintLoggingMaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);
                        _CCRMComplaintLoggingMaster.TrackType = sqlDataReader["TrackType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TrackType"]);
                        _CCRMComplaintLoggingMaster.CallStatus = sqlDataReader["CallStatus"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CallStatus"]);
                        _CCRMComplaintLoggingMaster.ComplaintNumberString = sqlDataReader["ComplaintNumberString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ComplaintNumberString"]);
                        _CCRMComplaintLoggingMaster.A4Mono = sqlDataReader["MtrReadA4Mono"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["MtrReadA4Mono"]);
                        _CCRMComplaintLoggingMaster.A4Col = sqlDataReader["MtrReadA4Col"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["MtrReadA4Col"]);
                        _CCRMComplaintLoggingMaster.A3Mono = sqlDataReader["MtrReadA3Mono"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["MtrReadA3Mono"]);
                        _CCRMComplaintLoggingMaster.A3Col = sqlDataReader["MtrReadA3Col"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["MtrReadA3Col"]);
                        _CCRMComplaintLoggingMaster.ContractClosingDate = sqlDataReader["ContClDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContClDate"]);

                        response.CollectionResponse.Add(_CCRMComplaintLoggingMaster);

                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        response.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode
                        });
                    }

                    //response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_WEB_API_GetComplaintLogs' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getComplaints(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> response = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_GetComplaintUnAllotedAndAlloted";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAlloted", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Allotment ? 1 : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                   
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
                    response.CollectionResponse = new List<CCRMComplaintLoggingMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMComplaintLoggingMaster _CCRMComplaintLoggingMaster = new CCRMComplaintLoggingMaster();
			
                        _CCRMComplaintLoggingMaster.CallTktNo = sqlDataReader["CallTicketNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallTicketNumber"]);
                        _CCRMComplaintLoggingMaster.SerialNo = sqlDataReader["SerialNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SerialNo"]);
                        _CCRMComplaintLoggingMaster.MIFName = sqlDataReader["MIFName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFName"]);
                        _CCRMComplaintLoggingMaster.ModelNo = sqlDataReader["ModelNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModelNo"]);
                        _CCRMComplaintLoggingMaster.CallDate = sqlDataReader["CallDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallDate"]);
                        _CCRMComplaintLoggingMaster.ContractType = sqlDataReader["ContractType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractType"]);
                        _CCRMComplaintLoggingMaster.Phoneno = sqlDataReader["CustomerContact"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerContact"]);
                        _CCRMComplaintLoggingMaster.MCAddress = sqlDataReader["MachineLocation"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MachineLocation"]);
                        _CCRMComplaintLoggingMaster.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        _CCRMComplaintLoggingMaster.Allotment = sqlDataReader["Allotment"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["Allotment"]);
                        _CCRMComplaintLoggingMaster.TrackType = sqlDataReader["TrackType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TrackType"]);
                        _CCRMComplaintLoggingMaster.CallStatus = sqlDataReader["CallStatus"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CallStatus"]);
                        _CCRMComplaintLoggingMaster.EngineerID = sqlDataReader["EngineerID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EngineerID"]);
                        _CCRMComplaintLoggingMaster.SerEnggName = sqlDataReader["AllotEnggName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AllotEnggName"]);

                        response.CollectionResponse.Add(_CCRMComplaintLoggingMaster);

                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        response.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode
                        });
                    }

                    //response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_WEB_API_GetComplaintLogs' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getAllComplaints(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> response = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_GetAllComplaints";
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nSyncType", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SyncType));
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
                    response.CollectionResponse = new List<CCRMComplaintLoggingMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMComplaintLoggingMaster _CCRMComplaintLoggingMaster = new CCRMComplaintLoggingMaster();

                        _CCRMComplaintLoggingMaster.CallTktNo = sqlDataReader["CallTicketNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallTicketNumber"]);
                        _CCRMComplaintLoggingMaster.CallCharges = sqlDataReader["CallCharges"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CallCharges"]);
                        _CCRMComplaintLoggingMaster.SerialNo = sqlDataReader["SerialNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SerialNo"]);
                        _CCRMComplaintLoggingMaster.MIFName = sqlDataReader["MIFName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFName"]);
                        _CCRMComplaintLoggingMaster.ModelNo = sqlDataReader["ModelNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModelNo"]);
                        _CCRMComplaintLoggingMaster.AreaPatchName = sqlDataReader["AreaPatchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AreaPatchName"]);
                        _CCRMComplaintLoggingMaster.CallDate = sqlDataReader["CallDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallDate"]);
                        _CCRMComplaintLoggingMaster.SymptomTitle = sqlDataReader["SymptomTitle"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SymptomTitle"]);
                        _CCRMComplaintLoggingMaster.ContractType = sqlDataReader["ContractType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractType"]);
                        _CCRMComplaintLoggingMaster.Phoneno = sqlDataReader["CustomerContact"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerContact"]);
                        _CCRMComplaintLoggingMaster.MCAddress = sqlDataReader["MachineLocation"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MachineLocation"]);
                        _CCRMComplaintLoggingMaster.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        _CCRMComplaintLoggingMaster.CallTypeName = sqlDataReader["CallTypeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallTypeName"]);
                        _CCRMComplaintLoggingMaster.CallTypeID = sqlDataReader["ServiceCallTypeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ServiceCallTypeID"]);
                        _CCRMComplaintLoggingMaster.Allotment = sqlDataReader["Allotment"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["Allotment"]);
                        _CCRMComplaintLoggingMaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _CCRMComplaintLoggingMaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);
                        _CCRMComplaintLoggingMaster.TrackType = sqlDataReader["TrackType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TrackType"]);
                        _CCRMComplaintLoggingMaster.CallStatus = sqlDataReader["CallStatus"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CallStatus"]);
                        //_CCRMComplaintLoggingMaster.ComplaintNumberString = sqlDataReader["ComplaintNumberString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ComplaintNumberString"]);
                        _CCRMComplaintLoggingMaster.A4Mono = sqlDataReader["MtrReadA4Mono"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["MtrReadA4Mono"]);
                        _CCRMComplaintLoggingMaster.A4Col = sqlDataReader["MtrReadA4Col"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["MtrReadA4Col"]);
                        _CCRMComplaintLoggingMaster.A3Mono = sqlDataReader["MtrReadA3Mono"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["MtrReadA3Mono"]);
                        _CCRMComplaintLoggingMaster.A3Col = sqlDataReader["MtrReadA3Col"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["MtrReadA3Col"]);
                        _CCRMComplaintLoggingMaster.JSON = sqlDataReader["JSON"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["JSON"]);
                        _CCRMComplaintLoggingMaster.EngineerID = sqlDataReader["AllotEnggId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["AllotEnggId"]);
                        _CCRMComplaintLoggingMaster.BrokenReason = sqlDataReader["BrokenReason"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BrokenReason"]);

                        response.CollectionResponse.Add(_CCRMComplaintLoggingMaster);

                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        response.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode
                        });
                    }

                    //response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_WEB_API_GetAllComplaints' reported the ErrorCode: " + _errorCode);
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
