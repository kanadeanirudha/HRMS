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
    public class CCRMBrokenCallReasonMaster_Web_API_DataProvider : DBInteractionBase,ICCRMBrokenCallReasonMaster_Web_API_DataProvider
    {
        public IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> getBrokenCallReasonOnSearchApi(CCRMBrokenCallReasonMaster item)
        {
            IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> response = new BaseEntityCollectionResponse<CCRMBrokenCallReasonMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_GetBrokenCallReasonMasterOnSearch";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nSyncType", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SyncType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLastSyncDate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LastSyncDate));
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
                    response.CollectionResponse = new List<CCRMBrokenCallReasonMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMBrokenCallReasonMaster _BrokenCallReasonMaster = new CCRMBrokenCallReasonMaster();

                        _BrokenCallReasonMaster.ReasonCode = sqlDataReader["ReasonCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ReasonCode"]);
                        _BrokenCallReasonMaster.ReasonDescription = sqlDataReader["ReasonDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ReasonDescription"]);
                        _BrokenCallReasonMaster.ID = sqlDataReader["ID"] is DBNull ? new Byte() : Convert.ToByte(sqlDataReader["ID"]);
                        _BrokenCallReasonMaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _BrokenCallReasonMaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);

                        response.CollectionResponse.Add(_BrokenCallReasonMaster);

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
                        throw new Exception("Stored Procedure 'USP_WEB_API_GetBrokenCallReasonMasterOnSearch' reported the ErrorCode: " + _errorCode);
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
