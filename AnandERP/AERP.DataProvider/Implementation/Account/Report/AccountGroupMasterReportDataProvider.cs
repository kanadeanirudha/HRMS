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
    public class AccountGroupMasterReportDataProvider : DBInteractionBase, IAccountGroupMasterReportDataProvider
    {
         #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

         #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public AccountGroupMasterReportDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public AccountGroupMasterReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        /// <summary>
        /// Select all record from Account Group Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGroupMasterReport> GetAccountGroupMasterBySearch(AccountGroupMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountGroupMasterReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountGroupMasterReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountGroupMaster_REPORT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGroupId", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CategoryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iHeadId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.HeadID));

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

                    baseEntityCollection.CollectionResponse = new List<AccountGroupMasterReport>();
                    while (sqlDataReader.Read())
                    {
                        AccountGroupMasterReport item = new AccountGroupMasterReport();
                        item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.GroupCode = sqlDataReader["GroupCode"].ToString();
                        item.HeadName = sqlDataReader["HeadName"].ToString();
                        item.GroupDescription = sqlDataReader["GroupDescription"].ToString();
                        item.GroupDescriptionCategory = sqlDataReader["GroupDescriptionCategory"].ToString();
                        item.CategoryID = Convert.ToInt16(sqlDataReader["CategoryID"]);
                        item.BackDatedEntriesFlag = sqlDataReader["BackDatedEntriesFlag"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["PrintingSequence"]) == false)
                        {
                            item.PrintingSequence = Convert.ToInt16(sqlDataReader["PrintingSequence"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CategoryDescription"]) == false)
                        {
                            item.CategoryDescription = sqlDataReader["CategoryDescription"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_AccountGroupMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from Account Group Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGroupMasterReport> GetGroupList(AccountGroupMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountGroupMasterReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountGroupMasterReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountGroupMasterReport_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CategoryID));


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

                    baseEntityCollection.CollectionResponse = new List<AccountGroupMasterReport>();
                    while (sqlDataReader.Read())
                    {
                        AccountGroupMasterReport item = new AccountGroupMasterReport();
                        item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.GroupCode = sqlDataReader["GroupCode"].ToString();
                        item.GroupDescription = sqlDataReader["GroupDescription"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
  
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountGroupMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
