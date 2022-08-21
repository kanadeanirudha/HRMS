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
    public class SaleContractWiseComplianceReportDataProvider : DBInteractionBase, ISaleContractWiseComplianceReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SaleContractWiseComplianceReportDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SaleContractWiseComplianceReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<SaleContractWiseComplianceReport> GetSaleContractWiseComplianceReportDataList(SaleContractWiseComplianceReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractWiseComplianceReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractWiseComplianceReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractWiseComplianceReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSalaryMonth", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalaryMonth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSalaryYear", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalaryYear));
                    
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractWiseComplianceReport>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractWiseComplianceReport item = new SaleContractWiseComplianceReport();

                        item.SiteName = sqlDataReader["SiteName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SiteName"]);
                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);
                        item.PFWages = sqlDataReader["PFWages"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PFWages"]);
                        item.PFWorkersShare = sqlDataReader["PFWorkersShare"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PFWorkersShare"]);
                        item.EmployersShareEPF01 = sqlDataReader["EmployersShareEPF01"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["EmployersShareEPF01"]);
                        item.EmployersShareEPS10 = sqlDataReader["EmployersShareEPS10"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["EmployersShareEPS10"]);
                        item.PFAdminCharges02 = sqlDataReader["PFAdminCharges02"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PFAdminCharges02"]);
                        item.PFIFchagres21 = sqlDataReader["PFIFchagres21"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PFIFchagres21"]);
                        item.PFAdminIFCharges22 = sqlDataReader["PFAdminIFCharges22"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PFAdminIFCharges22"]);
                        item.ESICWages = sqlDataReader["ESICWages"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ESICWages"]);
                        item.ESICWorkersShare = sqlDataReader["ESICWorkersShare"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ESICWorkersShare"]);
                        item.ESICEmployersShare = sqlDataReader["ESICEmployersShare"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ESICEmployersShare"]);
                        item.PTWages = sqlDataReader["PTWages"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PTWages"]);
                        item.PTShare = sqlDataReader["PTShare"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PTShare"]); 

                        item.SalaryMonthDisplay = searchRequest.SalaryMonthDisplay;
                        item.SalaryMonth = searchRequest.SalaryMonth;
                        item.SalaryYear = searchRequest.SalaryYear;
                        item.ReportType = searchRequest.ReportType;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractWiseComplianceReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
