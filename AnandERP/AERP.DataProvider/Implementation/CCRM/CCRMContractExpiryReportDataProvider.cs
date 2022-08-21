using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
   public class CCRMContractExpiryReportDataProvider :DBInteractionBase ,ICCRMContractExpiryReportDataProvider
    {
         #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public CCRMContractExpiryReportDataProvider() { }
        public CCRMContractExpiryReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        public IBaseEntityCollectionResponse<CCRMContractExpiryReport> GetCCRMContractExpiryReportBySearch_AllContractExpiry(CCRMContractExpiryReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<CCRMContractExpiryReport> baseEntityCollection = new BaseEntityCollectionResponse<CCRMContractExpiryReport>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;

            try
            {
                if (string.IsNullOrEmpty(searchRequest.ConnectionString))
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
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractExpiryReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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

                    baseEntityCollection.CollectionResponse = new List<CCRMContractExpiryReport>();
                    while (sqlDataReader.Read())
                    {
                        CCRMContractExpiryReport item = new CCRMContractExpiryReport();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.MIFName = sqlDataReader["MIFName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFName"]);
                        item.SerialNo = sqlDataReader["SerialNo"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["SerialNo"]);
                        item.ContractTypeId = Convert.ToInt32(sqlDataReader["ContractTypeId"]);
                        item.ExpiryDate = sqlDataReader["ExpiryDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExpiryDate"]);
                        item.Contarct = sqlDataReader["Contarct"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Contarct"]);
                        //item.Close = Convert.ToBoolean(sqlDataReader["Close"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
