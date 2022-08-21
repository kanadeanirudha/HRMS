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
    public class EmployeePFReportForm12ADataProvider : DBInteractionBase, IEmployeePFReportForm12ADataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeePFReportForm12ADataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeePFReportForm12ADataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<EmployeePFReportForm12A> GetEmployeePFReportForm12ADataList(EmployeePFReportForm12ASearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePFReportForm12A> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeePFReportForm12A>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeesProvidentFundsForm10MonthlyAndYearly";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMonth", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MonthName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsYear", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MonthYear));

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

                    baseEntityCollection.CollectionResponse = new List<EmployeePFReportForm12A>();
                    while (sqlDataReader.Read())
                    {
                        EmployeePFReportForm12A item = new EmployeePFReportForm12A();
                        item.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        item.EmployeeFathersFullName = sqlDataReader["EmployeeFathersFullName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeFathersFullName"]);
                        item.PFAccountNmber = sqlDataReader["PFAccountNmber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PFAccountNmber"]);
                        item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);
                        item.CentreAdress = sqlDataReader["CentreAdress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreAdress"]);
                        item.ReasonOfLeaving = sqlDataReader["ReasonOfLeaving"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ReasonOfLeaving"]);
                        item.LastLeftDate = sqlDataReader["LastLeftDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LastLeftDate"]);
                        item.GenderCode = sqlDataReader["GenderCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GenderCode"]);
                        item.MonthYear = searchRequest.MonthYear;
                        item.MonthName = searchRequest.MonthName;
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeePFReportForm12A_SelectAll' reported the ErrorCode: " + _errorCode);
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
