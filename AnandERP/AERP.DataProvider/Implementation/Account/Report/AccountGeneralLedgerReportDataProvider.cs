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
    public class AccountGeneralLedgerReportDataProvider : DBInteractionBase, IAccountGeneralLedgerReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public AccountGeneralLedgerReportDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public AccountGeneralLedgerReportDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from AccountGeneralLedgerReport table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetAccountGeneralLedgerReportBySearch(AccountGeneralLedgerReportSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountGeneralLedgerReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountGeneralLedger_Report";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtStartDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtEndDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountId", SqlDbType.Int, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,  searchRequest.AccountID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTransactionType", SqlDbType.NVarChar, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TransactionType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sConsolidiateType", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ConsolidiateType.Split('~')[0]));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

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
					baseEntityCollection.CollectionResponse = new List<AccountGeneralLedgerReport>();
					while (sqlDataReader.Read())
					{
						AccountGeneralLedgerReport item = new AccountGeneralLedgerReport();
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DebitCreditFlag"]) == false)
                        {
                            item.DebitCreditFlag = Convert.ToString(sqlDataReader["DebitCreditFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReverseAccount"]) == false)
                        {
                            item.ReverseAccount = Convert.ToString(sqlDataReader["ReverseAccount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChequeDate"]) == false)
                        {
                            item.ChequeDatetime = Convert.ToString(sqlDataReader["ChequeDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChequeNo"]) == false)
                        {
                            item.ChequeNo = Convert.ToString(sqlDataReader["ChequeNo"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChequeDetails"]) == false)
                        {
                            item.ChequeDetails = Convert.ToString(sqlDataReader["ChequeDetails"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VoucherNoWithTranType"]) == false)
                        {
                            item.VoucherNoWithTranType = Convert.ToString(sqlDataReader["VoucherNoWithTranType"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["NarrationDescription"]) == false)
                        {
                            item.NarrationDescription = Convert.ToString(sqlDataReader["NarrationDescription"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["PersonName"]) == false)
                        //{
                        //    item.PersonName = Convert.ToString(sqlDataReader["PersonName"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["TransactionAmount"]) == false)
                        {
                            item.TransactionAmount = Convert.ToString(sqlDataReader["TransactionAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DebitTransactionAmount"]) == false)
                        {
                            item.DebitTransactionAmount = Convert.ToDecimal(sqlDataReader["DebitTransactionAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreditTransactionAmount"]) == false)
                        {
                            item.CreditTransactionAmount = Convert.ToDecimal(sqlDataReader["CreditTransactionAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RunningTotal"]) == false)
                        {
                            item.RunningTotal = Convert.ToDecimal(sqlDataReader["RunningTotal"]);
                        }
                        item.ConsolidiateType = searchRequest.ConsolidiateType.Split('~')[1];
                        item.AccountName = searchRequest.AccountName;
                        item.FromDate = searchRequest.SessionFromDate;
                        item.ToDate= searchRequest.SessionUptoDate;

						baseEntityCollection.CollectionResponse.Add(item);
						
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_AccountGeneralLedgerReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from AccountGeneralLedgerReport table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetOtherLedgerBySearch(AccountGeneralLedgerReportSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountGeneralLedgerReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountSubLedger_Report";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtStartDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtEndDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountId", SqlDbType.Int, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,  searchRequest.AccountID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPersonType", SqlDbType.Char, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
					baseEntityCollection.CollectionResponse = new List<AccountGeneralLedgerReport>();
					while (sqlDataReader.Read())
					{
						AccountGeneralLedgerReport item = new AccountGeneralLedgerReport();
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DebitCreditFlag"]) == false)
                        {
                            item.DebitCreditFlag = Convert.ToString(sqlDataReader["DebitCreditFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReverseAccount"]) == false)
                        {
                            item.ReverseAccount = Convert.ToString(sqlDataReader["ReverseAccount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChequeDate"]) == false)
                        {
                            item.ChequeDatetime = Convert.ToString(sqlDataReader["ChequeDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChequeNo"]) == false)
                        {
                            item.ChequeNo = Convert.ToString(sqlDataReader["ChequeNo"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChequeDetails"]) == false)
                        {
                            item.ChequeDetails = Convert.ToString(sqlDataReader["ChequeDetails"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VoucherNoWithTranType"]) == false)
                        {
                            item.VoucherNoWithTranType = Convert.ToString(sqlDataReader["VoucherNoWithTranType"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["NarrationDescription"]) == false)
                        {
                            item.NarrationDescription = Convert.ToString(sqlDataReader["NarrationDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonName"]) == false)
                        {
                            item.PersonName = Convert.ToString(sqlDataReader["PersonName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionAmount"]) == false)
                        {
                            item.TransactionAmount = Convert.ToString(sqlDataReader["TransactionAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DebitTransactionAmount"]) == false)
                        {
                            item.DebitTransactionAmount = Convert.ToDecimal(sqlDataReader["DebitTransactionAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreditTransactionAmount"]) == false)
                        {
                            item.CreditTransactionAmount = Convert.ToDecimal(sqlDataReader["CreditTransactionAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RunningTotal"]) == false)
                        {
                            item.RunningTotal = Convert.ToDecimal(sqlDataReader["RunningTotal"]);
                        }

                        item.AccountName = searchRequest.AccountName;
                        item.PersonName = searchRequest.PersonName;
                        item.FromDate = searchRequest.SessionFromDate;
                        item.ToDate= searchRequest.SessionUptoDate;

						baseEntityCollection.CollectionResponse.Add(item);
						
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_AccountGeneralLedgerReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<AccountGeneralLedgerReport> GetAccountGeneralLedgerReportByID(AccountGeneralLedgerReport item)
		{
			IBaseEntityResponse<AccountGeneralLedgerReport> response = new BaseEntityResponse<AccountGeneralLedgerReport>();
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
					cmdToExecute.CommandText = "dbo.USP_AccountGeneralLedgerReport_SelectOne";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
				//	cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
						AccountGeneralLedgerReport _item = new AccountGeneralLedgerReport();
						_item.ChequeDetails = sqlDataReader["ChequeDetails"].ToString();
						_item.VoucherNumber = sqlDataReader["VoucherNumber"].ToString();
						_item.TransactionType = sqlDataReader["TransactionType"].ToString();
						_item.NarrationDescription = sqlDataReader["NarrationDescription"].ToString();
						_item.PersonName = sqlDataReader["PersonName"].ToString();
						_item.AccountSessionID = Convert.ToInt32(sqlDataReader["AccountSessionID"]);
						_item.BalanceSheetName = sqlDataReader["BalanceSheetName"].ToString();
                        //_Not
                        //_Not
                        //_Not
                        //_item.AccountType = sqlDataReader["AccountType"].ToString();
                        //_item.AccountID = Convert.ToInt32(sqlDataReader["AccountID"]);
                        //_item.AccountName = sqlDataReader["AccountName"].ToString();
                        //_item.ReportParameter = sqlDataReader["ReportParameter"].ToString();
                        //_item.FromDate = Convert.ToDateTime(sqlDataReader["FromDate"]);
                        //_item.ToDate = Convert.ToDateTime(sqlDataReader["ToDate"]);

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

        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetPersonNameListByPersonTypeAndAccountId(AccountGeneralLedgerReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountGeneralLedgerReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountIndividualAccountListBy_PersonTypeAndAccountID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPersonType", SqlDbType.Char, 2, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.PersonType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountID));
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
                    baseEntityCollection.CollectionResponse = new List<AccountGeneralLedgerReport>();
                    while (sqlDataReader.Read())
                    {
                        AccountGeneralLedgerReport item = new AccountGeneralLedgerReport();

                        item.PersonName = sqlDataReader["PersonName"].ToString();

                        item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"]);
                      
                        baseEntityCollection.CollectionResponse.Add(item);
                       // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountIndividualAccountListBy_PersonTypeAndAccountID' reported the ErrorCode: " + _errorCode);
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



        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetByIndividualBalanceReportSearch(AccountGeneralLedgerReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountGeneralLedgerReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountGroupLedger_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtStartDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtEndDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountId", SqlDbType.Int, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AccountID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPersonType", SqlDbType.Char, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonType));
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
                    baseEntityCollection.CollectionResponse = new List<AccountGeneralLedgerReport>();
                    while (sqlDataReader.Read())
                    {
                        AccountGeneralLedgerReport item = new AccountGeneralLedgerReport();
                        if (DBNull.Value.Equals(sqlDataReader["PersonName"]) == false)
                        {
                            item.PersonName = Convert.ToString(sqlDataReader["PersonName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonCode"]) == false)
                        {
                            item.PersonCode = Convert.ToString(sqlDataReader["PersonCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccSessionId"]) == false)
                        {
                            item.AccountSessionID = Convert.ToInt32(sqlDataReader["AccSessionId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountId"]) == false)
                        {
                            item.AccountID = Convert.ToInt32(sqlDataReader["AccountId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonType"]) == false)
                        {
                            item.PersonType = Convert.ToString(sqlDataReader["PersonType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OpeningBalance"]) == false)
                        {
                            item.OpeningBalance = Convert.ToDecimal(sqlDataReader["OpeningBalance"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OpendingBalanceCredit"]) == false)
                        {
                            item.OpendingBalanceCredit = Convert.ToDecimal(sqlDataReader["OpendingBalanceCredit"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["OpendingBalanceDebit"]) == false)
                        {
                            item.OpendingBalanceDebit = Convert.ToDecimal(sqlDataReader["OpendingBalanceDebit"]);
                        }
                      
                        //if (DBNull.Value.Equals(sqlDataReader["TransactionAmount"]) == false)
                        //{
                        //    item.TransactionAmount = Convert.ToString(sqlDataReader["TransactionAmount"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["TotalDebitTransactionAmount"]) == false)
                        {
                            item.TotalDebitTransactionAmount = Convert.ToDecimal(sqlDataReader["TotalDebitTransactionAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalCreditTransactionAmount"]) == false)
                        {
                            item.TotalCreditTransactionAmount = Convert.ToDecimal(sqlDataReader["TotalCreditTransactionAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CloseingBalance"]) == false)
                        {
                            item.CloseingBalance = Convert.ToDecimal(sqlDataReader["CloseingBalance"]);
                        }
                        item.AccountName = searchRequest.AccountName;
                        item.PersonTypeName = searchRequest.PersonTypeName;
                        item.ToDate = searchRequest.SessionUptoDate;
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountGroupLedger_Report' reported the ErrorCode: " + _errorCode);
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
        #endregion
    }
}
