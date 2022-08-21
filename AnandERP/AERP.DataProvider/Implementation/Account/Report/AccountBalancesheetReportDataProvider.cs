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
    public class AccountBalancesheetReportDataProvider : DBInteractionBase, IAccountBalancesheetReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
     public AccountBalancesheetReportDataProvider() {}
        public AccountBalancesheetReportDataProvider(ILogger logException) 
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
        public IBaseEntityCollectionResponse<AccountBalancesheetReport> GetAccountBalancesheetReportBySearch(AccountBalancesheetReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<AccountBalancesheetReport> baseEntityCollection = new BaseEntityCollectionResponse<AccountBalancesheetReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountBalancsheet_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtStartDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtEndDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountSessionID));
                    if (searchRequest.CentreCode != string.Empty )
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsZeroBalance", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.IsZeroBalance));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cGroupBy", SqlDbType.Char, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GroupBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsSubLedger", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.IsSubLedger));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cAssetLiabilityFlag", SqlDbType.Char, 5, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AssetLiabilityFlag));
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

                    baseEntityCollection.CollectionResponse = new List<AccountBalancesheetReport>();
                    while (sqlDataReader.Read())
                    {
                        AccountBalancesheetReport item = new AccountBalancesheetReport();
                        if (DBNull.Value.Equals(sqlDataReader["HeadCode"]) == false)
                        {
                            item.HeadCode = Convert.ToString(sqlDataReader["HeadCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["HeadName"]) == false)
                        {
                            item.HeadName = Convert.ToString(sqlDataReader["HeadName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["HeadSeq"]) == false)
                        {
                            item.HeadSeq = Convert.ToString(sqlDataReader["HeadSeq"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CategoryDescription"]) == false)
                        {
                            item.CategoryDescription = Convert.ToString(sqlDataReader["CategoryDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CategorySeq"]) == false)
                        {
                            item.CategorySeq = Convert.ToString(sqlDataReader["CategorySeq"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GroupDescription"]) == false)
                        {
                            item.GroupDescription = Convert.ToString(sqlDataReader["GroupDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GroupSeq"]) == false)
                        {
                            item.GroupSeq = Convert.ToString(sqlDataReader["GroupSeq"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"]) == false)
                        {
                            item.AccountName = Convert.ToString(sqlDataReader["AccountName"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AccountSeq"]) == false)
                        {
                            item.AccountSeq = Convert.ToString(sqlDataReader["AccountSeq"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["OpeningBalance"]) == false)
                        {
                            item.OpeningBalance = Convert.ToDecimal(sqlDataReader["OpeningBalance"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ClosingBalance"]) == false)
                        {
                            item.ClosingBalance = Convert.ToDecimal(sqlDataReader["ClosingBalance"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["CreditTransactionAmount"]) == false)
                        //{
                        //    item.CreditTransactionAmount = Convert.ToDecimal(sqlDataReader["CreditTransactionAmount"]);
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["ModeCode"]) == false)
                        //{
                        //    item.ModeCode = Convert.ToString(sqlDataReader["ModeCode"]);
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["DebitCreditFlag"]) == false)
                        //{
                        //    item.DebitCreditFlag = Convert.ToString(sqlDataReader["DebitCreditFlag"]);
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["OuterReceiptAmount"]) == false)
                        //{
                        //    item.OuterReceiptAmount = Convert.ToDecimal(sqlDataReader["OuterReceiptAmount"]);
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["OuterPaymentAmount"]) == false)
                        //{
                        //    item.OuterPaymentAmount = Convert.ToDecimal(sqlDataReader["OuterPaymentAmount"]);
                        //}

                        //item.Pattern = searchRequest.Pattern;

                        switch (searchRequest.GroupBy)
                        {
                            case "A":
                                item.GroupBy = "Account Wise";
                                break;
                            case "G":
                                item.GroupBy = "Group Wise";
                                break;
                            case "C":
                                item.GroupBy = "Category Wise";
                                break;
                        }
                        item.AccBalsheetName = searchRequest.AccBalsheetName;
                        item.SessionFromDate = searchRequest.SessionFromDate;
                        item.SessionUptoDate =searchRequest.SessionUptoDate;
                       

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
