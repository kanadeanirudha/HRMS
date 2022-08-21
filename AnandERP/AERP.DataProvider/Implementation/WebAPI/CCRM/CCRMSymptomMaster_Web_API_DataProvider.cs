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
    public class CCRMSymptomMaster_Web_API_DataProvider : DBInteractionBase,ICCRMSymptomMaster_Web_API_DataProvider
    {
        public IBaseEntityCollectionResponse<CCRMSymptomMaster> getSymptom_SelectAll(CCRMSymptomMaster item)
        {
            IBaseEntityCollectionResponse<CCRMSymptomMaster> response = new BaseEntityCollectionResponse<CCRMSymptomMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_GetSymptoms";
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
                    response.CollectionResponse = new List<CCRMSymptomMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMSymptomMaster _CCRMSymptomMaster = new CCRMSymptomMaster();

                        _CCRMSymptomMaster.CCRMSymptomMasterID = sqlDataReader["CCRMSymptomTypeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CCRMSymptomTypeID"]);
                        _CCRMSymptomMaster.SymptomCode = sqlDataReader["SymptomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SymptomCode"]);
                        _CCRMSymptomMaster.SymptomDescription = sqlDataReader["SymptomDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SymptomDescription"]);
                        _CCRMSymptomMaster.SymptomTitle = sqlDataReader["SymptomTitle"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SymptomTitle"]);
                        _CCRMSymptomMaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _CCRMSymptomMaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);

                        response.CollectionResponse.Add(_CCRMSymptomMaster);
                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        // response.CollectionResponse[0].ErrorCode = (int)_errorCode;
                        response.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode
                        });
                    }

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
    }
}
