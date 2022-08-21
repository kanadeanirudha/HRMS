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
    public class MISReportDataProvider : DBInteractionBase, IMISReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public MISReportDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public MISReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<MISReport> GetMISReportDataList(MISReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<MISReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<MISReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeesProvidentFundsForm6A";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));

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

                    baseEntityCollection.CollectionResponse = new List<MISReport>();
                    while (sqlDataReader.Read())
                    {
                        MISReport item = new MISReport();


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
                        //item.FromDate = searchRequest.FromDate;
                        //item.UptoDate = searchRequest.UptoDate;
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_MISReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
