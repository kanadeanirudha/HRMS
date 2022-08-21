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
    public class Admin_DataProvider_Web_API : DBInteractionBase,IAdmin_DataProvider_Web_API
    {
        public IBaseEntityCollectionResponse<AdminRoleMenuDetails> getAdminMenu(AdminRoleMenuDetails item)
        {
            IBaseEntityCollectionResponse<AdminRoleMenuDetails> response = new BaseEntityCollectionResponse<AdminRoleMenuDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TD_GetRoleApplicableMenu";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nSyncType", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SyncType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLastSyncDate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LastSyncDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
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
                    response.CollectionResponse = new List<AdminRoleMenuDetails>();
                    while (sqlDataReader.Read())
                    {
                        AdminRoleMenuDetails _AdminRoleMenuDetails = new AdminRoleMenuDetails();

                        _AdminRoleMenuDetails.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        _AdminRoleMenuDetails.AdminRoleMasterID = sqlDataReader["AdminRoleMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        _AdminRoleMenuDetails.MenuCode = sqlDataReader["MenuCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MenuCode"]);
                        _AdminRoleMenuDetails.MenuName = sqlDataReader["MenuName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MenuName"]);

                        _AdminRoleMenuDetails.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _AdminRoleMenuDetails.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);

                        response.CollectionResponse.Add(_AdminRoleMenuDetails);
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
                        throw new Exception("Stored Procedure 'USP_WEB_API_TD_GetRoleApplicableMenu' reported the ErrorCode: " + _errorCode);
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
