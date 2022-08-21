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
    public class AccountCentreOpeningBalanceDataProvider: DBInteractionBase, IAccountCentreOpeningBalanceDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        string _personType;
        #endregion

        #region Constructor
        public AccountCentreOpeningBalanceDataProvider(){}
        public AccountCentreOpeningBalanceDataProvider(ILogger logException) 
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
        public IBaseEntityCollectionResponse<AccountCentreOpeningBalance> GetAccountCentreOpeningBalanceBySearch(AccountCentreOpeningBalanceSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<AccountCentreOpeningBalance> baseEntityCollection = new BaseEntityCollectionResponse<AccountCentreOpeningBalance>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccCentreOpeningBalance_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,searchRequest.AccSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountType", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountType));
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

                    baseEntityCollection.CollectionResponse = new List<AccountCentreOpeningBalance>();
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    while (sqlDataReader.Read())
                    {
                        AccountCentreOpeningBalance item = new AccountCentreOpeningBalance();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OpeningBalance"]) == false)
                        {
                            item.OpeningBalance = Convert.ToDecimal(sqlDataReader["OpeningBalance"]);
                        }
                        else
                        {
                            item.OpeningBalance = Convert.ToDecimal(0.00);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalDebitAmount"]) == false)
                        {
                            item.TotalDebitAmount = Convert.ToDecimal(sqlDataReader["TotalDebitAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalCreditAmount"]) == false)
                        {
                            item.TotalCreditAmount = Convert.ToDecimal(sqlDataReader["TotalCreditAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActSessionID"]) == false)
                        {
                            item.AccSessionID = Convert.ToInt16(sqlDataReader["ActSessionID"]);
                        }
                        if (sqlDataReader["HeadCode"].ToString() == "A")
                        {
                            item.HeadCode = "Assets";
                        }
                        if (sqlDataReader["HeadCode"].ToString() == "L")
                        {
                            item.HeadCode = "Liability";
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonType"]) == false)
                        {
                            item.PersonType = Convert.ToString(sqlDataReader["PersonType"]);
                        }
                        
                      //  item.AccBalsheetMstID = Convert.ToInt16(sqlDataReader["AccBalsheetMstID"]);                        
                        item.AccountName = sqlDataReader["AccountName"].ToString();
                        item.AccountCode = sqlDataReader["AccountCode"].ToString();
                        item.AccountID = Convert.ToInt16(sqlDataReader["AccountID"]);

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
                        throw new Exception("Stored Procedure 'USP_AccountCentreOpeningBalance_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<AccountCentreOpeningBalance> GetBySearchIndividualAccount(AccountCentreOpeningBalanceSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<AccountCentreOpeningBalance> baseEntityCollection = new BaseEntityCollectionResponse<AccountCentreOpeningBalance>();
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
                    _personType =searchRequest.PersonType;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_AccIndividualOpeningBalance_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalancesheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPersonType", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.PersonType));
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

                    baseEntityCollection.CollectionResponse = new List<AccountCentreOpeningBalance>();
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    while (sqlDataReader.Read())
                    {
                        AccountCentreOpeningBalance item = new AccountCentreOpeningBalance();

                        if (DBNull.Value.Equals(sqlDataReader["AccIndividualOpeningBalID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["AccIndividualOpeningBalID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OpeningBalance"]) == true)
                        {
                            item.OpeningBalance = 0;
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OpeningBalance"]) == false)
                        {
                            item.OpeningBalance = Convert.ToDecimal(sqlDataReader["OpeningBalance"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalDebitAmount"]) == false)
                        {
                            item.TotalDebitAmount = Convert.ToDecimal(sqlDataReader["TotalDebitAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalCreditAmount"]) == false)
                        {
                            item.TotalCreditAmount = Convert.ToDecimal(sqlDataReader["TotalCreditAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActSessionID"]) == false)
                        {
                            item.AccSessionID = Convert.ToInt16(sqlDataReader["ActSessionID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                        {
                            item.AccountID = Convert.ToInt16(sqlDataReader["AccountID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActBalsheetMstID"]) == false)
                        {
                            item.AccBalsheetMstID = Convert.ToInt16(sqlDataReader["ActBalsheetMstID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonType"]) == false)
                        {
                            item.PersonType = Convert.ToString(sqlDataReader["PersonType"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["PersonID"]) == false)
                        //{
                        //    item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"]);
                        //}
                        if (_personType == "S")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["StudentID"]) == false)
                            {
                                item.PersonID = Convert.ToInt32(sqlDataReader["StudentID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                            {
                                item.PersonName = Convert.ToString(sqlDataReader["StudentName"]);
                            }
                        }
                        else if (_personType == "E")
                        {
                             if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                            {
                                item.PersonID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["EmployeeName"]) == false)
                            {
                                item.PersonName = Convert.ToString(sqlDataReader["EmployeeName"]);
                            }
                        }
                        else if (_personType == "U")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["SupplierID"]) == false)
                            {
                                item.PersonID = Convert.ToInt32(sqlDataReader["SupplierID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["SupplierName"]) == false)
                            {
                                item.PersonName = Convert.ToString(sqlDataReader["SupplierName"]);
                            }
                        }
                        else if (_personType == "F")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["FishermenID"]) == false)
                            {
                                item.PersonID = Convert.ToInt32(sqlDataReader["FishermenID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FishermenName"]) == false)
                            {
                                item.PersonName = Convert.ToString(sqlDataReader["FishermenName"]);
                            }
                        }
                        else if (_personType == "D")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["DirectorID"]) == false)
                            {
                                item.PersonID = Convert.ToInt32(sqlDataReader["DirectorID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["DirectorName"]) == false)
                            {
                                item.PersonName = Convert.ToString(sqlDataReader["DirectorName"]);
                            }
                        }
                        else if (_personType == "M")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["MemberID"]) == false)
                            {
                                item.PersonID = Convert.ToInt32(sqlDataReader["MemberID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["MemberName"]) == false)
                            {
                                item.PersonName = Convert.ToString(sqlDataReader["MemberName"]);
                            }
                        }
                        else if (_personType == "C")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["CustomerMasterID"]) == false)
                            {
                                item.PersonID = Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                            {
                                item.PersonName = Convert.ToString(sqlDataReader["CustomerName"]);
                            }
                        }
                        else if (_personType == "T")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["SaleContractEmployeeMasterID"]) == false)
                            {
                                item.PersonID = Convert.ToInt32(sqlDataReader["SaleContractEmployeeMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ContractEmployeeName"]) == false)
                            {
                                item.PersonName = Convert.ToString(sqlDataReader["ContractEmployeeName"]);
                            }
                        }
                        else if (_personType == "B")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["CustomerBranchMasterID"]) == false)
                            {
                                item.PersonID = Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["BranchName"]) == false)
                            {
                                item.PersonName = Convert.ToString(sqlDataReader["BranchName"]);
                            }
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
                        throw new Exception("Stored Procedure 'USP_AccountCentreOpeningBalance_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from Account centre opening balance transection by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCentreOpeningBalance> GetAccountCentreOpeningBalanceByID(AccountCentreOpeningBalance item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountCentreOpeningBalance> response = new BaseEntityResponse<AccountCentreOpeningBalance>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountCentreOpeningBalance_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        AccountCentreOpeningBalance _item = new AccountCentreOpeningBalance();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.AccSessionID = Convert.ToInt16(sqlDataReader["AccSessionID"]);
                        _item.AccountID = Convert.ToInt16(sqlDataReader["AccountID"]);
                        if (DBNull.Value.Equals(sqlDataReader["OpeningDatetime"]) == false)
                        {
                            _item.OpeningDatetime = Convert.ToDateTime(sqlDataReader["OpeningDatetime"]);
                        }
                        _item.OpeningBalance = Convert.ToDecimal(sqlDataReader["OpeningBalance"]);
                        _item.TotalDebitAmount = Convert.ToDecimal(sqlDataReader["TotalDebitAmount"]);
                        _item.TotalCreditAmount = Convert.ToDecimal(sqlDataReader["TotalCreditAmount"]);
                        _item.ClosingBalance = Convert.ToDecimal(sqlDataReader["ClosingBalance"]);
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
                        throw new Exception("Stored Procedure 'USP_AccountCentreOpeningBalance_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<AccountCentreOpeningBalance> InsertAccountCentreOpeningBalance(AccountCentreOpeningBalance item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountCentreOpeningBalance> response = new BaseEntityResponse<AccountCentreOpeningBalance>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountCentreOpeningBalance_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.VarChar, 4000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SelectedXmlData));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,item.AccSessionID)); //item.AccSessionID
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                    //item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountCentreOpeningBalance_InsertXML' reported the ErrorCode: " +
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
        public IBaseEntityResponse<AccountCentreOpeningBalance> UpdateAccountCentreOpeningBalance(AccountCentreOpeningBalance item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountCentreOpeningBalance> response = new BaseEntityResponse<AccountCentreOpeningBalance>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountIndividualOpeningBalance_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.VarChar, 4000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SelectedXmlDataForIndividualBalance));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccSessionID)); 
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccountID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPersonType", SqlDbType.Char, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PersonType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountCentreOpeningBalance_Update' reported the ErrorCode: " + _errorCode);
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
        /// Delete a selected record from Account bank transection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCentreOpeningBalance> DeleteAccountCentreOpeningBalance(AccountCentreOpeningBalance item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<AccountCentreOpeningBalance> response = new BaseEntityResponse<AccountCentreOpeningBalance>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountCentreOpeningBalance_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        throw new Exception("Stored Procedure 'USP_AccountCentreOpeningBalance_Delete' reported the ErrorCode: " + _errorCode);
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
