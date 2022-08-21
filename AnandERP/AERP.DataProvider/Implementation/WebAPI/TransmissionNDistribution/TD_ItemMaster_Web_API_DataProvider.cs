using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
using System.Data.SqlClient;
using System.Data;

namespace AERP.DataProvider
{
    public class TD_ItemMaster_Web_API_DataProvider : DBInteractionBase,ITD_ItemMaster_Web_API_DataProvider
    {
        public IBaseEntityCollectionResponse<ItemMaster> getItems(ItemMaster item)
        {
            IBaseEntityCollectionResponse<ItemMaster> response = new BaseEntityCollectionResponse<ItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TD_GetItems";
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
                    response.CollectionResponse = new List<ItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        ItemMaster _ItemMaster = new ItemMaster();

                        _ItemMaster.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        _ItemMaster.Item = sqlDataReader["Item"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Item"]);
                        _ItemMaster.Size = sqlDataReader["Size"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Size"]);
                        _ItemMaster.Quantity = sqlDataReader["Quantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        _ItemMaster.Unit = sqlDataReader["Unit"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Unit"]);
                        _ItemMaster.Weight_In_KG = sqlDataReader["Weight_In_KG"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["Weight_In_KG"]);
                        _ItemMaster.CategoryID = sqlDataReader["CategoryID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CategoryID"]);
                        _ItemMaster.Category = sqlDataReader["Category"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Category"]);
                        _ItemMaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _ItemMaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);

                        response.CollectionResponse.Add(_ItemMaster);
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
                        throw new Exception("Stored Procedure 'USP_WEB_API_TD_GetItems' reported the ErrorCode: " + _errorCode);
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
