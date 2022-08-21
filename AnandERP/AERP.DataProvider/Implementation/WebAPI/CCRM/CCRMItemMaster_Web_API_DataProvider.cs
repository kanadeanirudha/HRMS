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
    public class CCRMItemMaster_Web_API_DataProvider : DBInteractionBase,ICCRMItemMaster_Web_API_DataProvider
    {
        public IBaseEntityCollectionResponse<GeneralItemMaster> getItemOnSearchApi(GeneralItemMaster item)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> response = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_GetItemOnSearch";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nSyncType", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SyncType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
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
                    response.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _GeneralItemMaster = new GeneralItemMaster();

                        _GeneralItemMaster.ItemCode = sqlDataReader["ItemCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCode"]);
                        _GeneralItemMaster.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        _GeneralItemMaster.ItemCategoryCode = sqlDataReader["ItemCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                        _GeneralItemMaster.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        _GeneralItemMaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _GeneralItemMaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);

                        response.CollectionResponse.Add(_GeneralItemMaster);

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
                        throw new Exception("Stored Procedure 'USP_WEB_API_GetItemOnSearch' reported the ErrorCode: " + _errorCode);
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
