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
    public class SaleContractSalaryWageSheetReportDataProvider : DBInteractionBase, ISaleContractSalaryWageSheetReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SaleContractSalaryWageSheetReportDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SaleContractSalaryWageSheetReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<SaleContractSalaryWageSheetReport> GetSaleContractSalaryWageSheetReportDataList(SaleContractSalaryWageSheetReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractSalaryWageSheetReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractSalaryWageSheetReport>();
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
                    if (searchRequest.ReportType == 1)
                    {
                        cmdToExecute.CommandText = "dbo.USP_SaleContractSalaryTransactionSalaryReport_WageSheet";
                    }
                    else
                    {
                        cmdToExecute.CommandText = "dbo.USP_SaleContractSalaryTransactionSalaryReport_Save_WageSheet";
                    }
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractBillingSpanID));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractSalaryWageSheetReport>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractSalaryWageSheetReport item = new SaleContractSalaryWageSheetReport();

                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.ActualBasicAmount = sqlDataReader["ActualBasicAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ActualBasicAmount"]);
                        item.ActualDA = sqlDataReader["ActualDA"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ActualDA"]);
                        item.ActualHRA = sqlDataReader["ActualHRA"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ActualHRA"]);
                        item.ActualConveyance = sqlDataReader["ActualConveyance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ActualConveyance"]);
                        item.ActualEducation = sqlDataReader["ActualEducation"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ActualEducation"]);
                        item.ActualWashing = sqlDataReader["ActualWashing"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ActualWashing"]);
                        item.ActualGrossAmount = sqlDataReader["ActualGrossAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ActualGrossAmount"]);
                        item.DaysInMonth = sqlDataReader["DaysInMonth"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DaysInMonth"]);
                        item.TotalWeeklyOffDays = sqlDataReader["TotalWeeklyOffDays"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalWeeklyOffDays"]);
                        item.AbsentDays = sqlDataReader["AbsentDays"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["AbsentDays"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.AdjustedBasicAmount = sqlDataReader["AdjustedBasicAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["AdjustedBasicAmount"]);
                        item.EDA = sqlDataReader["EDA"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["EDA"]);
                        item.EHRA = sqlDataReader["EHRA"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["EHRA"]);
                        item.EConveyance = sqlDataReader["EConveyance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["EConveyance"]);
                        item.EEducation = sqlDataReader["EEducation"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["EEducation"]);
                        item.ESICGrossAmount = sqlDataReader["ESICGrossAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ESICGrossAmount"]);
                        item.EWashing = sqlDataReader["EWashing"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["EWashing"]);
                        item.Bonus = sqlDataReader["Bonus"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Bonus"]);
                        item.LWW = sqlDataReader["LWW"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["LWW"]);
                        item.GrossForESICCal = sqlDataReader["GrossForESICCal"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["GrossForESICCal"]);
                        item.EPF = sqlDataReader["EPF"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["EPF"]);
                        item.EESIC = sqlDataReader["EESIC"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["EESIC"]);
                        item.Canteen = sqlDataReader["Canteen"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Canteen"]);
                        item.PT = sqlDataReader["PT"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PT"]);
                        item.TotalDeduction = sqlDataReader["TotalDeduction"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalDeduction"]);
                        item.NetAmount = sqlDataReader["NetAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetAmount"]);
                        item.OTRate = sqlDataReader["OTRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["OTRate"]);
                        item.SingleOvertimeHours = sqlDataReader["SingleOvertimeHours"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SingleOvertimeHours"]);
                        item.DoubleOvertimeHours = sqlDataReader["DoubleOvertimeHours"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DoubleOvertimeHours"]);
                        item.GrossOTWages = sqlDataReader["GrossOTWages"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["GrossOTWages"]);
                        item.NetOTWagesPayable = sqlDataReader["NetOTWagesPayable"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetOTWagesPayable"]);
                        item.TotalWagesPaybleBeforeDeduction = sqlDataReader["TotalWagesPaybleBeforeDeduction"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalWagesPaybleBeforeDeduction"]);
                        item.EmployerPF = sqlDataReader["EmployerPF"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["EmployerPF"]);
                        item.EmployerESIC = sqlDataReader["EmployerESIC"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["EmployerESIC"]);
                        item.Insurance = sqlDataReader["Insurance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Insurance"]);
                        item.MLWF = sqlDataReader["MLWF"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["MLWF"]);
                        item.UAS = sqlDataReader["UAS"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["UAS"]);
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalSalary"]);
                        item.ManagementFees = sqlDataReader["ManagementFees"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ManagementFees"]);
                        item.ServiceCharges = sqlDataReader["ServiceCharges"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ServiceCharges"]);
                        item.MobileCharges = sqlDataReader["MobileCharges"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["MobileCharges"]);
                        item.GrandTotal = sqlDataReader["GrandTotal"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["GrandTotal"]);

                        item.ContractNumber = searchRequest.ContractNumber;
                        item.SaleContractBillingSpanName = searchRequest.SaleContractBillingSpanName;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractSalaryWageSheetReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
