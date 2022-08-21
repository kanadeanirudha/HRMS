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
    public class CCRMMIFMaster_Web_API_DataProvider : DBInteractionBase,ICCRMMIFMaster_Web_API_DataProvider
    {
        public IBaseEntityCollectionResponse<MIFMaster> getMIFMaster(MIFMaster item)
        {
            IBaseEntityCollectionResponse<MIFMaster> response = new BaseEntityCollectionResponse<MIFMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_MIFMaster_Sync";
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
                    response.CollectionResponse = new List<MIFMaster>();
                    while (sqlDataReader.Read())
                    {
                        MIFMaster _MIFMaster = new MIFMaster();

                        _MIFMaster.MIFNumber = sqlDataReader["MIFNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["MIFNumber"]);
                        _MIFMaster.SerialNumber = sqlDataReader["SerialNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SerialNumber"]);
                        _MIFMaster.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        _MIFMaster.InstallationAddress = sqlDataReader["InstallationAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["InstallationAddress"]);
                        _MIFMaster.ContractType = sqlDataReader["ContractType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractType"]);
                        _MIFMaster.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);
                        _MIFMaster.KeyOperator = sqlDataReader["KeyOperator"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["KeyOperator"]);
                        _MIFMaster.ModelNumber = sqlDataReader["ModelNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EngineerName"]);
                        _MIFMaster.EngineerName = sqlDataReader["EngineerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EngineerName"]);
                        _MIFMaster.PhoneNumber = sqlDataReader["PhoneNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PhoneNumber"]);
                        _MIFMaster.MobileNumber = sqlDataReader["MobileNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MobileNumber"]);
                        _MIFMaster.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        _MIFMaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _MIFMaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);

                        response.CollectionResponse.Add(_MIFMaster);
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
                        throw new Exception("Stored Procedure 'USP_WEB_API_MIFMaster_Sync' reported the ErrorCode: " + _errorCode);
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
