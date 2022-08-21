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
    public class AccountCategoryMasterReportDataProvider : DBInteractionBase, IAccountCategoryMasterReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion
        
        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public AccountCategoryMasterReportDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public AccountCategoryMasterReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        /// <summary>
        /// Select all record from account category master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCategoryMasterReport> GetAccountCategoryMasterReportBySearch(AccountCategoryMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountCategoryMasterReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountCategoryMasterReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountCategoryMaster_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCategoryMasterid", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iHeadID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.HeadID));
                   
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

                    baseEntityCollection.CollectionResponse = new List<AccountCategoryMasterReport>();
                    while (sqlDataReader.Read())
                    {
                        AccountCategoryMasterReport item = new AccountCategoryMasterReport();
                        item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.CategoryCode = sqlDataReader["CategoryCode"].ToString();
                        item.CategoryDescription = sqlDataReader["CategoryDescription"].ToString();
                        item.CategoryDescriptionHead = sqlDataReader["CategoryDescriptionHead"].ToString();
                        item.HeadID = Convert.ToByte(sqlDataReader["HeadID"]);
                        item.HeadName = Convert.ToString(sqlDataReader["HeadName"]);
                        if (DBNull.Value.Equals(sqlDataReader["PrintingSequence"]) == false)
                        {
                            item.PrintingSequence = Convert.ToInt16(sqlDataReader["PrintingSequence"]);
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
                        throw new Exception("Stored Procedure 'USP_AccountCategoryMasterReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all category names list from account category master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCategoryMasterReport> GetAccountCategoryNameList(AccountCategoryMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountCategoryMasterReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountCategoryMasterReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountCategoryMasterReport_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iHeadID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.HeadID));
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

                    baseEntityCollection.CollectionResponse = new List<AccountCategoryMasterReport>();
                    while (sqlDataReader.Read())
                    {
                        AccountCategoryMasterReport item = new AccountCategoryMasterReport();
                        item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.CategoryDescription = sqlDataReader["CategoryDescription"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountCategoryMasterReport_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from account category master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCategoryMasterReport> GetAccountCategoryMasterReportByID(AccountCategoryMasterReport item)
        {
            IBaseEntityResponse<AccountCategoryMasterReport> response = new BaseEntityResponse<AccountCategoryMasterReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountCategoryMasterReport_SelectOne";
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
                        AccountCategoryMasterReport _item = new AccountCategoryMasterReport();
                        _item.ID = Convert.ToInt16(sqlDataReader["ID"]);

                        _item.CategoryCode = sqlDataReader["CategoryCode"].ToString();
                        _item.CategoryDescription = sqlDataReader["CategoryDescription"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["PrintingSequence"]) == false)
                        {
                            _item.PrintingSequence = Convert.ToInt16(sqlDataReader["PrintingSequence"]);
                        }
                        _item.HeadID = Convert.ToByte(sqlDataReader["HeadID"]);
                        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        _item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        if (DBNull.Value.Equals(sqlDataReader["CreatedBy"]) == false)
                        {
                            _item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            _item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }
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
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountCategoryMasterReport_SelectOne' reported the ErrorCode: " + _errorCode);
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
