using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public class AccountTransactionDetailsDataProvider: DBInteractionBase, IAccountTransactionDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public AccountTransactionDetailsDataProvider() { }
        public AccountTransactionDetailsDataProvider(ILogger logException) 
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        #region Method Implementation
        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTransactionDetails> GetAccountTransactionDetailsBySearch(AccountTransactionDetailsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<AccountTransactionDetails> baseEntityCollection = new BaseEntityCollectionResponse<AccountTransactionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountTransactionDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeleted", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.IsDeleted));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sSortOrder", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortOrder));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));

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

                    baseEntityCollection.CollectionResponse = new List<AccountTransactionDetails>();
                    while (sqlDataReader.Read())
                    {
                        AccountTransactionDetails item = new AccountTransactionDetails();
                        item.id = Convert.ToInt32(sqlDataReader["id"]);
                        item.TransactionMainID = Convert.ToInt32(sqlDataReader["TransactionMainID"]);
                        item.AccountID = Convert.ToInt32(sqlDataReader["AccountID"]);
                        item.TransactionAmount = Convert.ToDecimal(sqlDataReader["TransactionAmount"]);
                        item.DebitCreditFlag = Convert.ToString(sqlDataReader["DebitCreditFlag"]);
                        item.ChequeNo = Convert.ToString(sqlDataReader["ChequeNo"]);
                        if (DBNull.Value.Equals(sqlDataReader["ChequeDatetime"]) == false)
                        {
                            item.ChequeDatetime = Convert.ToDateTime(sqlDataReader["ChequeDatetime"]);
                        }
                        item.NarrationDescription = Convert.ToString(sqlDataReader["NarrationDescription"]);
                        item.BankName = Convert.ToString(sqlDataReader["BankName"]);
                        item.BranchName = Convert.ToString(sqlDataReader["BranchName"]);
                        if (DBNull.Value.Equals(sqlDataReader["BankClearingDatetime"]) == false)
                        {
                            item.BankClearingDatetime = Convert.ToDateTime(sqlDataReader["BankClearingDatetime"]);
                        }
                        item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"]);
                        item.ModeCode = Convert.ToString(sqlDataReader["ModeCode"]);
                        item.PersonType = Convert.ToString(sqlDataReader["PersonType"]);
                        item.AccSessionID = Convert.ToInt32(sqlDataReader["AccSessionID"]);
                        item.VoucherNumber = Convert.ToInt32(sqlDataReader["VoucherNumber"]);
                        item.SubmitSlipNo = Convert.ToString(sqlDataReader["SubmitSlipNo"]);
                        if (DBNull.Value.Equals(sqlDataReader["SubmitDatetime"]) == false)
                        {
                            item.SubmitDatetime = Convert.ToDateTime(sqlDataReader["SubmitDatetime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReconcilationDatetime"]) == false)
                        {
                            item.ReconcilationDatetime = Convert.ToDateTime(sqlDataReader["ReconcilationDatetime"]);
                        }
                        item.AccBalsheetMstID = Convert.ToInt32(sqlDataReader["AccBalsheetMstID"]);
                        item.BankTransferFlag = Convert.ToString(sqlDataReader["BankTransferFlag"]);
                        item.ChqDepositSlipNo = Convert.ToString(sqlDataReader["ChqDepositSlipNo"]);
                        if (DBNull.Value.Equals(sqlDataReader["ChqDepositDatetime"]) == false)
                        {
                            item.ChqDepositDatetime = Convert.ToDateTime(sqlDataReader["ChqDepositDatetime"]);
                        }
                        item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
                        {
                            item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedBy"]) == false)
                        {
                            item.DeletedBy = Convert.ToInt32(sqlDataReader["DeletedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedDate"]) == false)
                        {
                            item.DeletedDate = Convert.ToDateTime(sqlDataReader["DeletedDate"]);
                        }
                        item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from Account transaction details master by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionDetails> GetAccountTransactionDetailsByID(AccountTransactionDetails item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountTransactionDetails> response = new BaseEntityResponse<AccountTransactionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountTransactionDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.id));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeleted", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsDeleted));
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
                        AccountTransactionDetails _item = new AccountTransactionDetails();
                        _item.id = Convert.ToInt32(sqlDataReader["id"]);
                        _item.TransactionMainID = Convert.ToInt32(sqlDataReader["TransactionMainID"]);
                        _item.AccountID = Convert.ToInt32(sqlDataReader["AccountID"]);
                        _item.TransactionAmount = Convert.ToDecimal(sqlDataReader["TransactionAmount"]);
                        _item.DebitCreditFlag = Convert.ToString(sqlDataReader["DebitCreditFlag"]);
                        _item.ChequeNo = Convert.ToString(sqlDataReader["ChequeNo"]);
                        if (DBNull.Value.Equals(sqlDataReader["ChequeDatetime"]) == false)
                        {
                            _item.ChequeDatetime = Convert.ToDateTime(sqlDataReader["ChequeDatetime"]);
                        }
                        _item.NarrationDescription = Convert.ToString(sqlDataReader["NarrationDescription"]);
                        _item.BankName = Convert.ToString(sqlDataReader["BankName"]);
                        _item.BranchName = Convert.ToString(sqlDataReader["BranchName"]);
                        if (DBNull.Value.Equals(sqlDataReader["BankClearingDatetime"]) == false)
                        {
                            _item.BankClearingDatetime = Convert.ToDateTime(sqlDataReader["BankClearingDatetime"]);
                        }
                        _item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"]);
                        _item.ModeCode = Convert.ToString(sqlDataReader["ModeCode"]);
                        _item.PersonType = Convert.ToString(sqlDataReader["PersonType"]);
                        _item.AccSessionID = Convert.ToInt32(sqlDataReader["AccSessionID"]);
                        _item.VoucherNumber = Convert.ToInt32(sqlDataReader["VoucherNumber"]);
                        _item.SubmitSlipNo = Convert.ToString(sqlDataReader["SubmitSlipNo"]);
                        if (DBNull.Value.Equals(sqlDataReader["SubmitDatetime"]) == false)
                        {
                            _item.SubmitDatetime = Convert.ToDateTime(sqlDataReader["SubmitDatetime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReconcilationDatetime"]) == false)
                        {
                            _item.ReconcilationDatetime = Convert.ToDateTime(sqlDataReader["ReconcilationDatetime"]);
                        }
                        _item.AccBalsheetMstID = Convert.ToInt32(sqlDataReader["AccBalsheetMstID"]);
                        _item.BankTransferFlag = Convert.ToString(sqlDataReader["BankTransferFlag"]);
                        _item.ChqDepositSlipNo = Convert.ToString(sqlDataReader["ChqDepositSlipNo"]);
                        if (DBNull.Value.Equals(sqlDataReader["ChqDepositDatetime"]) == false)
                        {
                            _item.ChqDepositDatetime = Convert.ToDateTime(sqlDataReader["ChqDepositDatetime"]);
                        }
                        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        _item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        _item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
                        {
                            _item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            _item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedBy"]) == false)
                        {
                            _item.DeletedBy = Convert.ToInt32(sqlDataReader["DeletedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedDate"]) == false)
                        {
                            _item.DeletedDate = Convert.ToDateTime(sqlDataReader["DeletedDate"]);
                        }
                        _item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionDetails_SelectOne' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of Account bank transaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionDetails> InsertAccountTransactionDetails(AccountTransactionDetails item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountTransactionDetails> response = new BaseEntityResponse<AccountTransactionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountTransactionDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.id));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTransactionMainID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TransactionMainID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccountID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTransactionAmount", SqlDbType.Money, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TransactionAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDebitCreditFlag", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.DebitCreditFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sChequeNo", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ChequeNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daChequeDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ChequeDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sNarrationDescription", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.NarrationDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sBankName", SqlDbType.VarChar, 120, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.BankName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sBranchName", SqlDbType.VarChar, 120, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.BranchName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daBankClearingDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.BankClearingDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sModeCode", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ModeCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPersonType", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.PersonType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVoucherNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VoucherNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSubmitSlipNo", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.SubmitSlipNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daSubmitDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.SubmitDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daReconcilationDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ReconcilationDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sBankTransferFlag", SqlDbType.VarChar, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.BankTransferFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sChqDepositSlipNo", SqlDbType.VarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ChqDepositSlipNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daChqDepositDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ChqDepositDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daCreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CreatedDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daDeletedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeleted", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsDeleted));
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
                    item.id = (Int32)cmdToExecute.Parameters["@iid"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionDetails_Insert' reported the ErrorCode: " +
                                            _errorCode);
                    }

                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
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


        /// <summary>
        /// Update a specific record of Account bank transaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionDetails> UpdateAccountTransactionDetails(AccountTransactionDetails item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountTransactionDetails> response = new BaseEntityResponse<AccountTransactionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountTransactionDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.id));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTransactionMainID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TransactionMainID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccountID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTransactionAmount", SqlDbType.Money, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TransactionAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDebitCreditFlag", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.DebitCreditFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sChequeNo", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ChequeNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daChequeDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ChequeDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sNarrationDescription", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.NarrationDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sBankName", SqlDbType.VarChar, 120, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.BankName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sBranchName", SqlDbType.VarChar, 120, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.BranchName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daBankClearingDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.BankClearingDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sModeCode", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ModeCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPersonType", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.PersonType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVoucherNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VoucherNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSubmitSlipNo", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.SubmitSlipNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daSubmitDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.SubmitDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daReconcilationDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ReconcilationDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sBankTransferFlag", SqlDbType.VarChar, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.BankTransferFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sChqDepositSlipNo", SqlDbType.VarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ChqDepositSlipNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daChqDepositDatetime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ChqDepositDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daCreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CreatedDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daDeletedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeleted", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsDeleted));
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
                        throw new Exception("Stored Procedure 'USP_AccountTransactionDetails_Update' reported the ErrorCode: " + _errorCode);
                    }

                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Update failed"
                        });
                    }
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
        /// Delete a selected record from Account bank transection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionDetails> DeleteAccountTransactionDetails(AccountTransactionDetails item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountTransactionDetails> response = new BaseEntityResponse<AccountTransactionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountTransactionDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.id));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));
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
                        throw new Exception("Stored Procedure 'USP_AccountTransactionDetails_Delete' reported the ErrorCode: " + _errorCode);
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



        #endregion

    }
}
