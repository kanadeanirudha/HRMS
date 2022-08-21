using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace AERP.DataProvider
{
    public class AccountTrialBalanceReportDataProvider : DBInteractionBase, IAccountTrialBalanceReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public AccountTrialBalanceReportDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public AccountTrialBalanceReportDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from AccountTrialBalanceReport table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTrialBalanceReport> GetAccountTrialBalanceReportBySearch(AccountTrialBalanceReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountTrialBalanceReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountTrialBalanceReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountTrialBalance_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtStartDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtEndDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountId", SqlDbType.Int, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AccountId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountSessionID));
                    if (searchRequest.CentreCode != string.Empty && searchRequest.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@cGroupBy", SqlDbType.Char, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GroupBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsZeroBalance", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.IsZeroBalance));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsSubLedger", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.IsSubLedger));
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<AccountTrialBalanceReport>();
                    while (sqlDataReader.Read())
                    {
                        AccountTrialBalanceReport item = new AccountTrialBalanceReport();
                        if (DBNull.Value.Equals(sqlDataReader["HeadName"]) == false)
                        {
                            item.HeadName = sqlDataReader["HeadName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["HeadCode"]) == false)
                        {
                            item.HeadCode = sqlDataReader["HeadCode"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CategoryDescription"]) == false)
                        {
                            item.CategoryDescription = sqlDataReader["CategoryDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CategoryCode"]) == false)
                        {
                            item.CategoryCode = sqlDataReader["CategoryCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CategoryID"]) == false)
                        {
                            item.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GroupDescription"]) == false)
                        {
                            item.GroupDescription = sqlDataReader["GroupDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GroupID"]) == false)
                        {
                            item.GroupID = Convert.ToInt32(sqlDataReader["GroupID"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AltGroupDescription"]) == false)
                        {
                            item.AltGroupDescription = sqlDataReader["AltGroupDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AltGroupID"]) == false)
                        {
                            item.AltGroupID = Convert.ToInt32(sqlDataReader["AltGroupID"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                        {
                            item.AccountID = Convert.ToInt32(sqlDataReader["AccountID"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"]) == false)
                        {
                            item.AccountName = sqlDataReader["AccountName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccBalsheetCode"]) == false)
                        {
                            item.AccBalsheetCode = sqlDataReader["AccBalsheetCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccBalsheetTypeDesc"]) == false)
                        {
                            item.AccBalsheetTypeDesc = sqlDataReader["AccBalsheetTypeDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccBalsheetTypeID"]) == false)
                        {
                            item.AccBalsheetTypeID = Convert.ToInt32(sqlDataReader["AccBalsheetTypeID"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BalanceSheetMstID"]) == false)
                        {
                            item.BalanceSheetMstID = Convert.ToInt32(sqlDataReader["BalanceSheetMstID"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OpeningBalanceDebit"]) == false)
                        {
                            item.OpeningBalanceDebit = Convert.ToDecimal(sqlDataReader["OpeningBalanceDebit"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OpeningBalanceCerdit"]) == false)
                        {
                            item.OpeningBalanceCerdit = Convert.ToDecimal(sqlDataReader["OpeningBalanceCerdit"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentDebitTransactionAmount"]) == false)
                        {
                            item.CurrentDebitTransactionAmount = Convert.ToDecimal(sqlDataReader["CurrentDebitTransactionAmount"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentCreditTransactionAmount"]) == false)
                        {
                            item.CurrentCreditTransactionAmount = Convert.ToDecimal(sqlDataReader["CurrentCreditTransactionAmount"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ClosingBalanceDebitAsPerCal"]) == false)
                        {
                            item.ClosingBalanceDebitAsPerCal = Convert.ToDecimal(sqlDataReader["ClosingBalanceDebitAsPerCal"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ClosingBalanceCreditAsPerCal"]) == false)
                        {
                            item.ClosingBalanceCreditAsPerCal = Convert.ToDecimal(sqlDataReader["ClosingBalanceCreditAsPerCal"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActualClosingDebitBalance"]) == false)
                        {
                            item.ActualClosingDebitBalance = Convert.ToDecimal(sqlDataReader["ActualClosingDebitBalance"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActualClosingCreditBalance"]) == false)
                        {
                            item.ActualClosingCreditBalance = Convert.ToDecimal(sqlDataReader["ActualClosingCreditBalance"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ClosingBalance"]) == false)
                        {
                            item.ClosingBalance = Convert.ToDecimal(sqlDataReader["ClosingBalance"]);
                        }
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
                        //if (DBNull.Value.Equals(sqlDataReader["HeadPrintingSeq"]) == false)
                        //{
                        //    item.HeadPrintingSeq = Convert.ToInt32(sqlDataReader["HeadPrintingSeq"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CategoryPrintingSeq"]) == false)
                        //{
                        //    item.CategoryPrintingSeq = Convert.ToInt32(sqlDataReader["CategoryPrintingSeq"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["GroupPrintingSeq"]) == false)
                        //{
                        //    item.GroupPrintingSeq = Convert.ToInt32(sqlDataReader["GroupPrintingSeq"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTrialBalance_Report' reported the ErrorCode: " + _errorCode);
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
        /// <summary>
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTrialBalanceReport> GetAccountTrialBalanceReportByID(AccountTrialBalanceReport item)
        {
            IBaseEntityResponse<AccountTrialBalanceReport> response = new BaseEntityResponse<AccountTrialBalanceReport>();
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
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_AccountTrialBalanceReport_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                    while (sqlDataReader.Read())
                    {
                        AccountTrialBalanceReport _item = new AccountTrialBalanceReport();
                        //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.SessionStartDatetime = Convert.ToDateTime(sqlDataReader["SessionStartDatetime"]);
                        //_item.SessionEndDatetime = Convert.ToDateTime(sqlDataReader["SessionEndDatetime"]);
                        //_item.DefaultFlag = Convert.ToBoolean(sqlDataReader["DefaultFlag"]);
                        //_item.Account_System = sqlDataReader["Account_System"].ToString();
                        //_item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        //_item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
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
            return response;
        }

        #endregion
    }
}
