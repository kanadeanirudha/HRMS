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
    public class TD_ActivityMaster_Web_API_DataProvider :DBInteractionBase,ITD_ActivityMaster_Web_API_DataProvider
    {
        public IBaseEntityCollectionResponse<ActivityMaster> getActivities(ActivityMaster item)
        {
            IBaseEntityCollectionResponse<ActivityMaster> response = new BaseEntityCollectionResponse<ActivityMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TD_GetActivities";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
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
                    response.CollectionResponse = new List<ActivityMaster>();
                    while (sqlDataReader.Read())
                    {
                        ActivityMaster _ActivityMaster = new ActivityMaster();

                        _ActivityMaster.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        _ActivityMaster.Activity = sqlDataReader["Activity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Activity"]);
                        _ActivityMaster.ActivityCode = sqlDataReader["ActivityCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ActivityCode"]);
                        _ActivityMaster.ActivityDescription = sqlDataReader["ActivityDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ActivityDescription"]);
                        _ActivityMaster.Category = sqlDataReader["Category"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Category"]);
                        _ActivityMaster.CategoryID = sqlDataReader["CategoryID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CategoryID"]);

                        _ActivityMaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _ActivityMaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);

                        response.CollectionResponse.Add(_ActivityMaster);
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
                        throw new Exception("Stored Procedure 'USP_WEB_API_TD_GetActivities' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SubActivitymaster> getSubActivities(SubActivitymaster item)
        {
            IBaseEntityCollectionResponse<SubActivitymaster> response = new BaseEntityCollectionResponse<SubActivitymaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TD_GetSubActivities";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
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
                    response.CollectionResponse = new List<SubActivitymaster>();
                    while (sqlDataReader.Read())
                    {
                        SubActivitymaster _SubActivitymaster = new SubActivitymaster();

                        _SubActivitymaster.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        _SubActivitymaster.SubActivity = sqlDataReader["SubActivity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubActivity"]);
                        _SubActivitymaster.SubActivityCode = sqlDataReader["SubActivityCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubActivityCode"]);
                        _SubActivitymaster.SubActivityDescription = sqlDataReader["SubActivityDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubActivityDescription"]);

                        _SubActivitymaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _SubActivitymaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);

                        response.CollectionResponse.Add(_SubActivitymaster);
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
                        throw new Exception("Stored Procedure 'USP_WEB_API_TD_GetSubActivities' reported the ErrorCode: " + _errorCode);
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
