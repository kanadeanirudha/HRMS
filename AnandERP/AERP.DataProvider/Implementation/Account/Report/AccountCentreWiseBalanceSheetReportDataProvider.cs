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
    public class AccountCentreWiseBalanceSheetReportDataProvider : DBInteractionBase, IAccountCentreWiseBalanceSheetReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public AccountCentreWiseBalanceSheetReportDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public AccountCentreWiseBalanceSheetReportDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from AccountCentreWiseBalanceSheetReport table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCentreWiseBalanceSheetReport> GetAccountCentreWiseBalanceSheetReportBySearch(AccountCentreWiseBalanceSheetReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountCentreWiseBalanceSheetReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountCentreWiseBalanceSheetReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountCentreWiseBalanceSheetList_Report";
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
                    baseEntityCollection.CollectionResponse = new List<AccountCentreWiseBalanceSheetReport>();
                    while (sqlDataReader.Read())
                    {
                        AccountCentreWiseBalanceSheetReport item = new AccountCentreWiseBalanceSheetReport();

                        //  item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CentreName = sqlDataReader["CentreName"].ToString();
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["CentreSpecialization"]) == false)
                        {
                            item.CentreSpecialization = sqlDataReader["CentreSpecialization"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActBalsheetCode"]) == false)
                        {
                            item.AccBalsheetCode = sqlDataReader["ActBalsheetCode"].ToString();
                        }
                        else
                        {
                            item.AccBalsheetCode = "";

                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActBalsheetHeadDesc"]) == false && item.AccBalsheetCode != string.Empty)
                        {
                            item.AccBalsheetHeadDesc = sqlDataReader["ActBalsheetHeadDesc"].ToString() + "[" + item.AccBalsheetCode + "]"; ;
                        }
                        else
                        {
                            item.AccBalsheetHeadDesc = sqlDataReader["ActBalsheetHeadDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActBalsheetTypeCode"]) == false)
                        {
                            item.AccBalsheetTypeCode = sqlDataReader["ActBalsheetTypeCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActBalsheetTypeDesc"]) == false)
                        {
                            item.AccBalsheetTypeDesc = sqlDataReader["ActBalsheetTypeDesc"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_AccountCentreWiseBalanceSheetList_Report' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<AccountCentreWiseBalanceSheetReport> GetAccountCentreWiseBalanceSheetReportByID(AccountCentreWiseBalanceSheetReport item)
        {
            IBaseEntityResponse<AccountCentreWiseBalanceSheetReport> response = new BaseEntityResponse<AccountCentreWiseBalanceSheetReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountCentreWiseBalanceSheetReport_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                  //  cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        AccountCentreWiseBalanceSheetReport _item = new AccountCentreWiseBalanceSheetReport();
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
