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
    public class EmployeePFReportForm9DataProvider : DBInteractionBase, IEmployeePFReportForm9DataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeePFReportForm9DataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeePFReportForm9DataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<EmployeePFReportForm9> GetEmployeePFReportForm9DataList(EmployeePFReportForm9SearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePFReportForm9> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeePFReportForm9>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeesProvidentFundsForm9Monthly";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMonth", SqlDbType.TinyInt,4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MonthName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsyear", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MonthYear));

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

                    baseEntityCollection.CollectionResponse = new List<EmployeePFReportForm9>();
                    while (sqlDataReader.Read())
                    {
                        EmployeePFReportForm9 item = new EmployeePFReportForm9();


                        item.TotalAmountOfWages = sqlDataReader["TotalAmountOfWages"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAmountOfWages"]);
                        item.TotalWorkersShareEPF = sqlDataReader["TotalWorkersShareEPF"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalWorkersShareEPF"]);
                        item.TotalEmployersShareEPF = sqlDataReader["TotalEmployersShareEPF"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalEmployersShareEPF"]);
                        item.TotalEmployersShareEPS = sqlDataReader["TotalEmployersShareEPS"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalEmployersShareEPS"]);
                        item.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        item.EmployeeFathersFullName = sqlDataReader["EmployeeFathersFullName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeFathersFullName"]);
                        item.PFAccountNmber = sqlDataReader["PFAccountNmber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PFAccountNmber"]);
                        item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);
                        item.CentreAdress = sqlDataReader["CentreAdress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreAdress"]);
                        item.RateOfContribution = sqlDataReader["RateOfContribution"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["RateOfContribution"]);

                        item.TotalAdmCharges = sqlDataReader["TotalAdmCharges"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAdmCharges"]);
                        item.TotalIFChagres = sqlDataReader["TotalIFChagres"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalIFChagres"]);
                        item.ToatalAdmChargesTowardsIF = sqlDataReader["ToatalAdmChargesTowardsIF"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ToatalAdmChargesTowardsIF"]);

                        item.MonthName = searchRequest.MonthName;
                        item.MonthYear = searchRequest.MonthYear;
                        item.MonthFullName = searchRequest.MonthFullName;
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeePFReportForm9_SelectAll' reported the ErrorCode: " + _errorCode);
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
