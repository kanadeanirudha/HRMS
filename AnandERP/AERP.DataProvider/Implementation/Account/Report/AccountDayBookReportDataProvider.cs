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
    public class AccountDayBookReportDataProvider : DBInteractionBase, IAccountDayBookReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public AccountDayBookReportDataProvider() { }
        public AccountDayBookReportDataProvider(ILogger logException) 
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountDayBookReport> GetAccountDayBookReportBySearch(AccountDayBookReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<AccountDayBookReport> baseEntityCollection = new BaseEntityCollectionResponse<AccountDayBookReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountTransactionDayBook_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtStartDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtEndDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAccountIds", SqlDbType.VarChar,4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(searchRequest.AccountIDsXmlString)?searchRequest.AccountIDsXmlString:string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstIds", SqlDbType.VarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetIDsXmlString));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccountSessionID", SqlDbType.SmallInt, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTransactionTypes", SqlDbType.VarChar, 250, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(searchRequest.TransactionTypeXmlString) ? searchRequest.TransactionTypeXmlString : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode ", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(searchRequest.ModeCode) ? searchRequest.ModeCode : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Pattern));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPatternOn", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,!string.IsNullOrEmpty(searchRequest.PatternType)? searchRequest.PatternType:"ALL"));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mAmountFilterFrom", SqlDbType.Money, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mAmountFilterTo", SqlDbType.Money, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

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

                    baseEntityCollection.CollectionResponse = new List<AccountDayBookReport>();
                    while (sqlDataReader.Read())
                    {
                        AccountDayBookReport item = new AccountDayBookReport();

                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["VoucherNumber"]) == false)
                        {
                            item.VoucherNumber = Convert.ToString(sqlDataReader["VoucherNumber"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["NarrationDescription"]) == false)
                        {
                            item.NarrationDescription = Convert.ToString(sqlDataReader["NarrationDescription"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AccountName"]) == false)
                        {
                            item.AccountName = Convert.ToString(sqlDataReader["AccountName"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["TransactionAmount"]) == false)
                        {
                            item.TransactionAmount = Convert.ToDecimal(sqlDataReader["TransactionAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DebitTransactionAmount"]) == false)
                        {
                            item.DebitTransactionAmount = Convert.ToDecimal(sqlDataReader["DebitTransactionAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreditTransactionAmount"]) == false)
                        {
                            item.CreditTransactionAmount = Convert.ToDecimal(sqlDataReader["CreditTransactionAmount"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ModeCode"]) == false)
                        {
                            item.ModeCode = Convert.ToString(sqlDataReader["ModeCode"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["DebitCreditFlag"]) == false)
                        {
                            item.DebitCreditFlag = Convert.ToString(sqlDataReader["DebitCreditFlag"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["OuterReceiptAmount"]) == false)
                        {
                            item.OuterReceiptAmount = Convert.ToDecimal(sqlDataReader["OuterReceiptAmount"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["OuterPaymentAmount"]) == false)
                        {
                            item.OuterPaymentAmount = Convert.ToDecimal(sqlDataReader["OuterPaymentAmount"]);
                        }

                        item.Pattern = searchRequest.Pattern;
                        item.SessionFromDate = searchRequest.SessionFromDate;
                        item.SessionUptoDate = searchRequest.SessionUptoDate;
                       

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
