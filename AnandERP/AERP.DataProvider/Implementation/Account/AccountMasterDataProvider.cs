using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AERP.DataProvider
{
    public class AccountMasterDataProvider : DBInteractionBase, IAccountMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public AccountMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public AccountMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation

        /// <summary>
        /// Select all record from account master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetAccountMasterBySearch(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalancesheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy.Trim(' ')));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));

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

                    baseEntityCollection.CollectionResponse = new List<AccountMaster>();
                    while (sqlDataReader.Read())
                    {
                        AccountMaster item = new AccountMaster();

                        if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                        {
                            item.ID = Convert.ToInt16(sqlDataReader["AccountID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActBalsheetHeadDesc"]) == false)
                        {
                            item.AccBalsheetHeadDesc = Convert.ToString(sqlDataReader["ActBalsheetHeadDesc"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankAccountNumber"]) == false)
                        {
                            item.BankAccountNumber = (sqlDataReader["BankAccountNumber"].ToString());
                        }
                        else
                        {
                            item.BankAccountNumber = "";
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"]) == false && item.BankAccountNumber != string.Empty)
                        {
                            item.AccountName = sqlDataReader["AccountName"].ToString() + "      [" + item.BankAccountNumber + "]";
                        }
                        else
                        {
                            item.AccountName = sqlDataReader["AccountName"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AccountCode"]) == false)
                        {
                            item.AccountCode = sqlDataReader["AccountCode"].ToString();
                        }
                        else
                        {
                            item.AccountCode = "";
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GroupDescription"]) == false)
                        {
                            item.GroupDescription = Convert.ToString(sqlDataReader["GroupDescription"] + "  [" + sqlDataReader["HeadCode"]+"]");
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GroupID"]) == false)
                        {
                            item.GroupID = Convert.ToInt16(sqlDataReader["GroupID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonType"]) == false)
                        {
                            item.PersonType = sqlDataReader["PersonType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActBalsheetMstID"]) == false)
                        {
                            item.AccBalsheetMstID = Convert.ToInt16(sqlDataReader["ActBalsheetMstID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccCenterwiseID"]) == false)
                        {
                            item.AccCenterwiseID = Convert.ToInt32(sqlDataReader["AccCenterwiseID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankDetailsID"]) == false)
                        {
                            item.BankDetailsID = Convert.ToInt32(sqlDataReader["BankDetailsID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AccountInNameOf"]) == false)
                        {
                            item.AccountInNameOf = sqlDataReader["AccountInNameOf"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankBranchName"]) == false)
                        {
                            item.BankBranchName = sqlDataReader["BankBranchName"].ToString();
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                        baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccAccountMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from account master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetAccountList(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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

                    baseEntityCollection.CollectionResponse = new List<AccountMaster>();
                    while (sqlDataReader.Read())
                    {
                        AccountMaster item = new AccountMaster();
                        item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.AccountCode = sqlDataReader["AccountCode"].ToString();
                        item.AccountName = sqlDataReader["AccountName"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from account master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetAccountListForReport(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountMaster_GetAccountListForReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@cCashBankFlag", SqlDbType.Char, 2, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CashBankFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPersonType", SqlDbType.Char, 2, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.PersonType));
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

                    baseEntityCollection.CollectionResponse = new List<AccountMaster>();
                    while (sqlDataReader.Read())
                    {
                        AccountMaster item = new AccountMaster();
                        item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.AccountName = sqlDataReader["AccountName"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select List of Surplus Deficit Flag from table AccAccountMaster
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetSurplusDeficitList(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountMaster_SurplusDeficitList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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

                    baseEntityCollection.CollectionResponse = new List<AccountMaster>();
                    while (sqlDataReader.Read())
                    {
                        AccountMaster item = new AccountMaster();
                        item.SurpDifiFlag = sqlDataReader["SurpDifiFlag"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountMaster_SurplusDeficitList' reported the ErrorCode: " + _errorCode);
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
        /// Select List of Surplus Deficit Flag from table AccAccountMaster
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetAlternateGroupList(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountMaster_GetAlternateGroupList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GroupID));
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

                    baseEntityCollection.CollectionResponse = new List<AccountMaster>();
                    while (sqlDataReader.Read())
                    {
                        AccountMaster item = new AccountMaster();
                        item.GroupID =Convert.ToInt16(sqlDataReader["ID"]);
                        item.GroupDescription =Convert.ToString(sqlDataReader["GroupDescription"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountMaster_SurplusDeficitList' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from account master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> GetAccountMasterByID(AccountMaster item)
        {
            IBaseEntityResponse<AccountMaster> response = new BaseEntityResponse<AccountMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccAccountMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        AccountMaster _item = new AccountMaster();
                        _item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["AccountCode"]) == false)
                        {
                            _item.AccountCode = sqlDataReader["AccountCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"]) == false)
                        {
                            _item.AccountName = sqlDataReader["AccountName"].ToString();
                        }
                        _item.GroupID = Convert.ToInt16(sqlDataReader["GroupID"]);
                        _item.DebitCreditFlag = Convert.ToString(sqlDataReader["DebitCreditFlag"]);
                        _item.CashBankFlag = sqlDataReader["CashBankFlag"].ToString();
                        if (sqlDataReader["BackDatetimedEntries"].ToString() == "Y")
                        {
                            _item.BackDatetimedEntries = true;
                        }
                        else if (sqlDataReader["BackDatetimedEntries"].ToString() == "N")
                        {
                            _item.BackDatetimedEntries = false;
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccBankDetailsID"]) == false)
                        {
                            _item.AccBankDetailsID = Convert.ToInt16(sqlDataReader["AccBankDetailsID"].ToString());
                        }

                        _item.PersonType = Convert.ToString(sqlDataReader["PersonType"]);
                        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);

                        if (DBNull.Value.Equals(sqlDataReader["ExclusivelyForCentre"]) == false)
                        {
                            _item.ExclusivelyForCentre = Convert.ToBoolean(sqlDataReader["ExclusivelyForCentre"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TrialBalSubledger"]) == false)
                        {
                            _item.TrialBalSubledger = Convert.ToBoolean(sqlDataReader["TrialBalSubledger"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SurpDifiFlag"]) == false)
                        {
                            _item.SurpDifiFlag = sqlDataReader["SurpDifiFlag"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["BankAccountNumber"]) == false)
                        {
                            _item.BankAccountNumber = Convert.ToString(sqlDataReader["BankAccountNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankLimitAmount"]) == false)
                        {
                            _item.BankLimitAmount = Convert.ToDecimal(sqlDataReader["BankLimitAmount"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["OpenDatetime"]) == false)
                        {
                            _item.OpenDatetime = sqlDataReader["OpenDatetime"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DueDatetime"]) == false)
                        {
                            _item.DueDatetime = sqlDataReader["DueDatetime"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountInNameOf"]) == false)
                        {
                            _item.AccountInNameOf = Convert.ToString(sqlDataReader["AccountInNameOf"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankBranchName"]) == false)
                        {
                            _item.BankBranchName = Convert.ToString(sqlDataReader["BankBranchName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InterestMode"]) == false)
                        {
                            _item.InterestMode = Convert.ToString(sqlDataReader["InterestMode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InterestType"]) == false)
                        {
                            _item.InterestType = Convert.ToString(sqlDataReader["InterestType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RateOfInterest"]) == false)
                        {
                            _item.RateOfInterest = Convert.ToDecimal(sqlDataReader["RateOfInterest"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AltGroupID"]) == false)
                        {
                            _item.AltGroupID = Convert.ToInt16(sqlDataReader["AltGroupID"]);
                        }
                        
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountBalancesheetTypeMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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

        /// <summary>
        /// Create new record of Account Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> InsertAccountMaster(AccountMaster item)
        {
            IBaseEntityResponse<AccountMaster> response = new BaseEntityResponse<AccountMaster>();
            SqlCommand cmdToExecute = new SqlCommand();

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
                    cmdToExecute.CommandText = "dbo.USP_AccountMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.SmallInt, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGroupID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GroupID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAltGroupID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AltGroupID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAccountCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.AccountCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAccountName", SqlDbType.NVarChar, 60, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.AccountName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cCashBankFlag", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CashBankFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPersonType", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.PersonType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSurpDifiFlag", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.SurpDifiFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bExclusivelyForCentre", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ExclusivelyForCentre));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sBankAccountNumber", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BankAccountNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBankLimitAmount", SqlDbType.Money, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.BankLimitAmount));
                    if (item.OpenDatetime == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daOpenDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daOpenDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.OpenDatetime));
                    }

                    if (item.DueDatetime == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDueDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDueDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.DueDatetime));
                    }


                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAccountInNameOf", SqlDbType.NVarChar, 60, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.AccountInNameOf.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBankBranchName", SqlDbType.NVarChar, 60, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.BankBranchName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cInterestMode", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.InterestMode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cInterestType", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.InterestType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRateOfInterest", SqlDbType.Money, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.RateOfInterest));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cDebitCreditFlag", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.DebitCreditFlag));
                    if (item.BackDatetimedEntries == true)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cBackDatetimedEntries", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "Y"));
                    }
                    else if (item.BackDatetimedEntries == false)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cBackDatetimedEntries", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "N"));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccCenterwiseStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccCenterwiseErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBankDetailsErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectedXml", SqlDbType.VarChar, 4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.SelectedXml));

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

                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                    {
                        item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountBalancesheetTypeMaster_Insert' reported the ErrorCode: " +
                                            _errorCode);
                    }

                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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

        /// <summary>
        /// Update a specific record of Account Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> UpdateAccountMaster(AccountMaster item)
        {
            IBaseEntityResponse<AccountMaster> response = new BaseEntityResponse<AccountMaster>();
            SqlCommand cmdToExecute = new SqlCommand();

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
                    cmdToExecute.CommandText = "dbo.USP_AccAccountMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBankDetailsID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccBankDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAltGroupID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AltGroupID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cDebitCreditFlag", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.DebitCreditFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cCashBankFlag", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CashBankFlag));
                    if (item.BackDatetimedEntries == true)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cBackDatetimedEntries", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "Y"));
                    }
                    else if (item.BackDatetimedEntries == false)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cBackDatetimedEntries", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "N"));
                    }
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAccountInNameOf", SqlDbType.NVarChar, 60, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,!string.IsNullOrEmpty(item.AccountInNameOf)? item.AccountInNameOf :string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBankBranchName", SqlDbType.NVarChar, 60, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.BankBranchName) ? item.BankBranchName : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cInterestMode", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.InterestMode) ? item.InterestMode : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cInterestType", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.InterestType) ? item.InterestType : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRateOfInterest", SqlDbType.Money, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.RateOfInterest));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    if (item.BankLimitAmount == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iBankLimitAmount", SqlDbType.Money, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iBankLimitAmount", SqlDbType.Money, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.BankLimitAmount));
                    }
                    if (item.DueDatetime == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDueDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDueDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.DueDatetime));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccCenterwiseErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBankDetailsErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectedXml", SqlDbType.VarChar, 4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.SelectedXml));
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

                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountMaster_Update' reported the ErrorCode: " + _errorCode);
                    }

                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Update failed"
                    //    });
                    //}
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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

        /// <summary>
        /// Delete a selected record from Account Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> DeleteAccountMaster(AccountMaster item)
        {
            IBaseEntityResponse<AccountMaster> response = new BaseEntityResponse<AccountMaster>();
            SqlCommand cmdToExecute = new SqlCommand();

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
                    cmdToExecute.CommandText = "dbo.USP_AccountMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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

                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountMaster_Delete' reported the ErrorCode: " + _errorCode);
                    }

                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Delete failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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

        public IBaseEntityCollectionResponse<AccountMaster> GetAccountMasterSearchList(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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

                    baseEntityCollection.CollectionResponse = new List<AccountMaster>();
                    while (sqlDataReader.Read())
                    {
                        AccountMaster item = new AccountMaster();
                        item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.AccountCode = sqlDataReader["AccountCode"].ToString();
                        item.AccountName = sqlDataReader["AccountName"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
