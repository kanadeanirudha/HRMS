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
    public class AccountTransactionMasterDataProvider: DBInteractionBase, IAccountTransactionMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public AccountTransactionMasterDataProvider() { }
        public AccountTransactionMasterDataProvider(ILogger logException) 
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        #region Method Implementation
        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetAccountTransactionMasterBySearch(AccountTransactionMasterSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<AccountTransactionMaster> baseEntityCollection = new BaseEntityCollectionResponse<AccountTransactionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccTransactionMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccountSessionID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cTransactionType", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.TransactionType.Trim()));

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

                    baseEntityCollection.CollectionResponse = new List<AccountTransactionMaster>();
                    while (sqlDataReader.Read())
                    {
                        AccountTransactionMaster item = new AccountTransactionMaster();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["TransactionType"]) == false)
                        {
                            item.TransactionType = Convert.ToChar(Convert.ToString(sqlDataReader["TransactionType"]).Trim());
                        }

                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["NarrationDescription"]) == false)
                        {
                            item.NarrationDescription = Convert.ToString(sqlDataReader["NarrationDescription"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ModeCode"]) == false)
                        {
                            item.ModeCode = Convert.ToString(sqlDataReader["ModeCode"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ActSessionID"]) == false)
                        {
                            item.AccSessionID = Convert.ToInt16(sqlDataReader["ActSessionID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["VoucherNumber"]) == false)
                        {
                            item.VoucherNumber = Convert.ToInt64(sqlDataReader["VoucherNumber"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ActBalsheetMstID"]) == false)
                        {
                            item.AccBalsheetMstID = Convert.ToInt16(sqlDataReader["ActBalsheetMstID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["IsPosted"]) == false)
                        {
                            item.IsPosted = Convert.ToInt16(sqlDataReader["IsPosted"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["PostedDate"]) == false)
                        {
                            item.PostedDate = Convert.ToString(sqlDataReader["PostedDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["PostedBy"]) == false)
                        {
                            item.PostedBy = Convert.ToInt32(sqlDataReader["PostedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionAmount"]) == false)
                        {
                            item.TransactionAmount = Convert.ToInt32(sqlDataReader["TransactionAmount"]);
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
        
        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetBySearchForEditView(AccountTransactionMasterSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<AccountTransactionMaster> baseEntityCollection = new BaseEntityCollectionResponse<AccountTransactionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccTransactionMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                   
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

                    baseEntityCollection.CollectionResponse = new List<AccountTransactionMaster>();
                    while (sqlDataReader.Read())
                    {
                        AccountTransactionMaster item = new AccountTransactionMaster();

                        if (DBNull.Value.Equals(sqlDataReader["TransactionSubID"]) == false)
                        {
                            item.AccTransDetailsID = Convert.ToInt32(sqlDataReader["TransactionSubID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionMainID"]) == false)
                        {
                            item.ID = Convert.ToInt64(sqlDataReader["TransactionMainID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                        {
                            item.AccountID = Convert.ToInt16(sqlDataReader["AccountID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DebitCreditFlag"]) == false)
                        {
                            item.DebitCreditFlag = Convert.ToString(sqlDataReader["DebitCreditFlag"]);
                        }
                        if (item.DebitCreditFlag == "D")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["TransactionAmount"]) == false)
                            {
                                item.TransactionAmount = Convert.ToDecimal(sqlDataReader["TransactionAmount"]);
                            }
                        }
                        if (item.DebitCreditFlag == "C")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["TransactionAmount"]) == false)
                            {
                                item.TransactionAmount = Math.Abs(Convert.ToDecimal(sqlDataReader["TransactionAmount"]));
                            }
                        }

                       
                        if (DBNull.Value.Equals(sqlDataReader["ChequeNo"]) == false)
                        {
                            item.ChequeNo = Convert.ToString(sqlDataReader["ChequeNo"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChequeDatetime"]) == false)
                        {
                            item.ChequeDatetime = Convert.ToString(sqlDataReader["ChequeDatetime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankName"]) == false)
                        {
                            item.BankName = Convert.ToString(sqlDataReader["BankName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BranchName"]) == false)
                        {
                            item.BranchName = Convert.ToString(sqlDataReader["BranchName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonID"]) == false)
                        {
                            item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonType"]) == false)
                        {
                            item.PersonType = Convert.ToString(sqlDataReader["PersonType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionMasterNarration"]) == false)
                        {
                            item.TransactionMasterNarration = Convert.ToString(sqlDataReader["TransactionMasterNarration"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt64(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"]) == false)
                        {
                            item.AccountName = Convert.ToString(sqlDataReader["AccountName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CashBankFlag"]) == false)
                        {
                            item.CashBankFlag = Convert.ToString(sqlDataReader["CashBankFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["NarrationDescription"]) == false)
                        {
                            item.NarrationDescription = Convert.ToString(sqlDataReader["NarrationDescription"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ModeCode"]) == false)
                        {
                            item.ModeCode = Convert.ToString(sqlDataReader["ModeCode"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AccSessionID"]) == false)
                        {
                            item.AccSessionID = Convert.ToInt16(sqlDataReader["AccSessionID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["VoucherNumber"]) == false)
                        {
                            item.VoucherNumber = Convert.ToInt64(sqlDataReader["VoucherNumber"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AccBalsheetMstID"]) == false)
                        {
                            item.AccBalsheetMstID = Convert.ToInt16(sqlDataReader["AccBalsheetMstID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReferencePersonID"]) == false)
                        {
                            item.ReferencePersonID = Convert.ToInt16(sqlDataReader["ReferencePersonID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReferencePersonType"]) == false)
                        {
                            item.ReferencePersonType = Convert.ToString(sqlDataReader["ReferencePersonType"]);
                        }
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

        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetAccountList(AccountTransactionMasterSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<AccountTransactionMaster> baseEntityCollection = new BaseEntityCollectionResponse<AccountTransactionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccTransactionMaster_GetAccountList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPersonType", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.PersonType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTransactionTypeCode", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.TransactionTypeCode));
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

                    baseEntityCollection.CollectionResponse = new List<AccountTransactionMaster>();
                    while (sqlDataReader.Read())
                    {
                        AccountTransactionMaster item = new AccountTransactionMaster();
                        if (searchRequest.AccountId == 0)
                        {
                            if (DBNull.Value.Equals(sqlDataReader["id"]) == false)
                            {
                                item.AccountID = Convert.ToInt16(sqlDataReader["id"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["AccountName"]) == false)
                            {
                                item.AccountName = Convert.ToString(sqlDataReader["AccountName"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["CashBankFlag"]) == false)
                            {
                                item.CashBankFlag = sqlDataReader["CashBankFlag"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["PersonType"]) == false)
                            {
                                item.PersonType = (sqlDataReader["PersonType"].ToString());
                            }                            
                        }
                        else if (searchRequest.AccountId > 0 )
                        {
                            if (DBNull.Value.Equals(sqlDataReader["PersonID"]) == false)
                            {
                                item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"].ToString());
                            }
                            if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                            {
                                item.AccountID = Convert.ToInt16(sqlDataReader["AccountID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["PersonType"]) == false)
                            {
                                item.PersonType = (sqlDataReader["PersonType"].ToString());
                            }

                            if (searchRequest.PersonType == "U")
                            {
                                item.SubLedgerName = Convert.ToString(sqlDataReader["SupplierName"]);
                            }
                            if (searchRequest.PersonType == "E")
                            {
                             item.SubLedgerName =    Convert.ToString(sqlDataReader["EmployeeName"]);
                            }
                            if (searchRequest.PersonType == "S")
                            {
                                item.SubLedgerName = Convert.ToString(sqlDataReader["StudentName"] + " (" + sqlDataReader["CourseYearCode"] + "[" + sqlDataReader["AcademicYear"]+"])");   
                            }
                            if (searchRequest.PersonType == "F")
                            {
                                item.SubLedgerName = Convert.ToString(sqlDataReader["FishermenName"]);
                            }
                            if (searchRequest.PersonType == "M")
                            {
                                item.SubLedgerName = Convert.ToString(sqlDataReader["MemberName"]);
                            }
                            if (searchRequest.PersonType == "D")
                            {
                                item.SubLedgerName = Convert.ToString(sqlDataReader["DirectorName"]);
                            }
                            if (searchRequest.PersonType == "C")
                            {
                                item.SubLedgerName = Convert.ToString(sqlDataReader["CustomerName"]);
                            }
                            if (searchRequest.PersonType == "B")
                            {
                                item.SubLedgerName = Convert.ToString(sqlDataReader["CustomerName"]);
                            }
                            if (searchRequest.PersonType == "T")
                            {
                                item.SubLedgerName = Convert.ToString(sqlDataReader["ContractEmployeeName"]);
                            }
                        }

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

        /// <summary>
        /// Select a record from Account transaction master master by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionMaster> GetAccountTransactionMasterByID(AccountTransactionMaster item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountTransactionMaster> response = new BaseEntityResponse<AccountTransactionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountTransactionMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.id));
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
                        AccountTransactionMaster _item = new AccountTransactionMaster();
                        //_item.id = Convert.ToInt32(sqlDataReader["id"]);
                        _item.TransactionType = Convert.ToChar(sqlDataReader["TransactionType"]);
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            _item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        _item.NarrationDescription = Convert.ToString(sqlDataReader["NarrationDescription"]);
                        _item.ModeCode = Convert.ToString(sqlDataReader["ModeCode"]);
                        _item.AccSessionID = Convert.ToInt16(sqlDataReader["AccSessionID"]);
                        _item.VoucherNumber = Convert.ToInt64(sqlDataReader["VoucherNumber"]);
                        _item.AccBalsheetMstID = Convert.ToInt16(sqlDataReader["AccBalsheetMstID"]);
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
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<AccountTransactionMaster> InsertAccountTransactionMaster(AccountTransactionMaster item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountTransactionMaster> response = new BaseEntityResponse<AccountTransactionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountVoucher_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    
                    //-------------------------------------------------------Output Parameters----------------------------------------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, null));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, null));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    //------------------------------------------------------ Input Parameters -----------------------------------------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTransactionXmlString", SqlDbType.Xml, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.SelectedXmlData));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biTransactionMainID", SqlDbType.BigInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccountSessionID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cTransactionType", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.TransactionTypeCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sNarrationDescription", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.NarrationDescription)? item.NarrationDescription : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daTransactionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.TransactionDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPolicyType", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "Auto")); //Auto or Approval
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAuthorityLevel", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "ApprovalLevel"));//ApprovalLevel or EntryLevel
                    cmdToExecute.Parameters.Add(new SqlParameter("@sModeCode", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ModeCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dVoucherAmount", SqlDbType.Decimal, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.VoucherAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));

                    
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
                    item.Status = (Int32)cmdToExecute.Parameters["@iStatus"].Value;
                    item.ErrorMessage =Convert.ToString( cmdToExecute.Parameters["@nsErrorMessage"].Value);
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of Account bank transaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionMaster> UpdateAccountTransactionMaster(AccountTransactionMaster item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountTransactionMaster> response = new BaseEntityResponse<AccountTransactionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountTransactionMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                   // cmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.id));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cTransactionType", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.TransactionType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daTransactionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.TransactionDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sNarrationDescription", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.NarrationDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sModeCode", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ModeCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVoucherNumber", SqlDbType.BigInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VoucherNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccBalsheetMstID));
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
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_Update' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<AccountTransactionMaster> DeleteAccountTransactionMaster(AccountTransactionMaster item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountTransactionMaster> response = new BaseEntityResponse<AccountTransactionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountTransactionMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.id));
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
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_Delete' reported the ErrorCode: " + _errorCode);
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

        /// <summary>
        /// Create new record of Account bank transaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionMaster> InsertAccountVoucherRequest(AccountTransactionMaster item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountTransactionMaster> response = new BaseEntityResponse<AccountTransactionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountVoucherRequestApproval_InsertXml";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //-------------------------------------------------------Output Parameters----------------------------------------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, null));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, null));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    //------------------------------------------------------ Input Parameters -----------------------------------------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTransactionXmlString", SqlDbType.Xml, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biTransactionMainID", SqlDbType.BigInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TransactionMainID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccountSessionID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cTransactionType", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.TransactionType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sNarrationDescription", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.NarrationDescription) ? item.NarrationDescription : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daTransactionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.TransactionDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sModeCode", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.ModeCode) ? item.ModeCode : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dVoucherAmount", SqlDbType.Decimal, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.VoucherAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bRequestApprovedStatus", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RequestApprovedStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StageSequenceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskReportingDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskReportingDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsLastRecord));

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
                    item.Status = (Int32)cmdToExecute.Parameters["@iStatus"].Value;
                    item.ErrorMessage = Convert.ToString(cmdToExecute.Parameters["@nsErrorMessage"].Value);
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_Insert' reported the ErrorCode: " +
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
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetVoucherDetailsForApproval(AccountTransactionMasterSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<AccountTransactionMaster> baseEntityCollection = new BaseEntityCollectionResponse<AccountTransactionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountTransactionMaster_GetVoucherRequestForApproval";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
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

                    baseEntityCollection.CollectionResponse = new List<AccountTransactionMaster>();
                    while (sqlDataReader.Read())
                    {
                        AccountTransactionMaster item = new AccountTransactionMaster();
                        item.TransactionMainID = sqlDataReader["TransactionMainID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["TransactionMainID"]);
                        item.NarrationDescription = sqlDataReader["NarrationDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["NarrationDescription"]);
                        item.AccountSpecificNarration = sqlDataReader["AccountSpecificNarration"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AccountSpecificNarration"]);
                        item.TransactionType = sqlDataReader["TransactionType"] is DBNull ? new char() : Convert.ToChar(Convert.ToString(sqlDataReader["TransactionType"]).Trim());
                        item.VoucherNumber = sqlDataReader["VoucherNumber"] is DBNull ? 0 : Convert.ToInt64(sqlDataReader["VoucherNumber"]);
                        item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                        item.AccSessionID = sqlDataReader["AccSessionID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["AccSessionID"]);
                        item.AccBalsheetName = sqlDataReader["AccBalsheetHeadDesc"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AccBalsheetHeadDesc"]);
                        item.AccTransDetailsID = sqlDataReader["TransactionSubID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["TransactionSubID"]);
                        item.TransactionMainID = sqlDataReader["TransactionMainID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["TransactionMainID"]);
                        item.AccountID = sqlDataReader["AccountID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["AccountID"]);
                        item.TransactionAmount = sqlDataReader["TransactionAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TransactionAmount"]);
                        item.DebitCreditFlag = sqlDataReader["DebitCreditFlag"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DebitCreditFlag"]);
                        item.ChequeNo = sqlDataReader["ChequeNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ChequeNo"]);
                        item.ChequeDatetime = sqlDataReader["ChequeDatetime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ChequeDatetime"]);
                        item.NarrationDescription = sqlDataReader["NarrationDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["NarrationDescription"]);
                        item.BankName = sqlDataReader["BankName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankName"]);
                        item.BranchName = sqlDataReader["BranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchName"]);
                        item.BankClearingDatetime = sqlDataReader["BankClearingDatetime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankClearingDatetime"]);
                        item.PersonID = sqlDataReader["PersonID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PersonID"]);
                        item.ModeCode = sqlDataReader["ModeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModeCode"]);
                        item.PersonType = sqlDataReader["PersonType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PersonType"]);
                        item.AccSessionID = sqlDataReader["AccSessionID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["AccSessionID"]);                        
                        item.SubmitSlipNo = sqlDataReader["SubmitSlipNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubmitSlipNo"]);
                        item.SubmitDatetime = sqlDataReader["SubmitDatetime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubmitDatetime"]);
                        item.ReconcilationDatetime = sqlDataReader["ReconcilationDatetime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ReconcilationDatetime"]);
                        item.AccBalsheetMstID = sqlDataReader["AccBalsheetMstID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["AccBalsheetMstID"]);
                        item.BankTransferFlag = sqlDataReader["BankTransferFlag"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankTransferFlag"]);
                        item.ChqDepositSlipNo = sqlDataReader["ChqDepositSlipNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ChqDepositSlipNo"]);
                        item.ChqDepositDatetime = sqlDataReader["ChqDepositDatetime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ChqDepositDatetime"]); 
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
        #endregion


    }
}
