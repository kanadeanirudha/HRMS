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
    public class AccountMasterReportDataProvider : DBInteractionBase, IAccountMasterReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public AccountMasterReportDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public AccountMasterReportDataProvider(ILogger logException)
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
        public IBaseEntityCollectionResponse<AccountMasterReport> GetAccountMasterBySearch(AccountMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMasterReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AccountMasterReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountNameList_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //   cmdToExecute.Parameters.Add(new SqlParameter("@iBalShhetMstid", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccMstBalsheetID));
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

                    baseEntityCollection.CollectionResponse = new List<AccountMasterReport>();
                    while (sqlDataReader.Read())
                    {
                        AccountMasterReport item = new AccountMasterReport();


                        if (DBNull.Value.Equals(sqlDataReader["HeadName"]) == false)
                        {
                            item.HeadName = Convert.ToString(sqlDataReader["HeadName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CategoryCode"]) == false)
                        {
                            item.CategoryCode = Convert.ToString(sqlDataReader["CategoryCode"]);
                        }
                        else 
                        {
                            item.CategoryCode = "";

                        }
                        if (DBNull.Value.Equals(sqlDataReader["CategoryDescription"]) == false && item.CategoryCode != string.Empty)
                        {
                            item.CategoryDescription = Convert.ToString(sqlDataReader["CategoryDescription"]) + "[" + item.CategoryCode + "]"; 
                        }
                        else
                        {
                            item.CategoryDescription = Convert.ToString(sqlDataReader["CategoryDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GroupCode"]) == false)
                        {
                            item.GroupCode = Convert.ToString(sqlDataReader["GroupCode"]);
                        }
                        else
                        {
                            item.GroupCode = "";

                        }
                        if (DBNull.Value.Equals(sqlDataReader["GroupDescription"]) == false && item.GroupCode != string.Empty)
                        {
                            item.GroupDescription = Convert.ToString(sqlDataReader["GroupDescription"]) + "[" + item.GroupCode + "]"; ; ;
                        }
                        else
                        {
                            item.GroupDescription = Convert.ToString(sqlDataReader["GroupDescription"]);
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
                            item.AccountName = sqlDataReader["AccountName"].ToString() + " [ A/C No :" + item.BankAccountNumber + "]";
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
                        if (DBNull.Value.Equals(sqlDataReader["ActBalsheetHeadDesc"]) == false)
                        {
                            item.AccBalsheetHeadDesc = sqlDataReader["ActBalsheetHeadDesc"].ToString();
                        }

                        //if (DBNull.Value.Equals(sqlDataReader["AccountInNameOf"]) == false)
                        //{
                        //    item.AccountInNameOf = sqlDataReader["AccountInNameOf"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["BankBranchName"]) == false)
                        //{
                        //    item.BankBranchName = sqlDataReader["BankBranchName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["RateOfInterest"]) == false)
                        //{
                        //    item.RateOfInterest =Convert.ToDecimal(sqlDataReader["RateOfInterest"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["InterestMode"]) == false)
                        //{
                        //    item.InterestMode = sqlDataReader["InterestMode"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["InterestType"]) == false)
                        //{
                        //    item.InterestType = sqlDataReader["InterestType"].ToString();
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["DebitCreditFlag"]) == false)
                        {
                            item.DebitCreditFlag = sqlDataReader["DebitCreditFlag"].ToString();
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

        #endregion
    }



}
