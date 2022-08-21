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
    public class GrossOperatingProfitReportDataProvider : DBInteractionBase, IGrossOperatingProfitReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public GrossOperatingProfitReportDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public GrossOperatingProfitReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<GrossOperatingProfitReport> GetGrossOperatingProfitReportDataList(GrossOperatingProfitReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GrossOperatingProfitReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GrossOperatingProfitReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_GrossOperatingProfitReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerBranchMasterID));

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

                    baseEntityCollection.CollectionResponse = new List<GrossOperatingProfitReport>();
                    while (sqlDataReader.Read())
                    {
                        GrossOperatingProfitReport item = new GrossOperatingProfitReport();

                        item.FixedSale = sqlDataReader["FixedSale"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FixedSale"]);
                        item.VariableSale = sqlDataReader["VariableSale"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["VariableSale"]);
                        item.ArrearsBonusSale = sqlDataReader["ArrearsBonusSale"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ArrearsBonusSale"]);
                        item.SubTotalSale = sqlDataReader["SubTotalSale"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SubTotalSale"]);
                        item.FoodCost = sqlDataReader["FoodCost"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FoodCost"]);
                        item.Chemicals = sqlDataReader["Chemicals"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Chemicals"]);
                        item.ConsumablesReim = sqlDataReader["ConsumablesReim"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ConsumablesReim"]);
                        item.ConsumableNonReim = sqlDataReader["ConsumableNonReim"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ConsumableNonReim"]);
                        item.MaintainanceCost = sqlDataReader["MaintainanceCost"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["MaintainanceCost"]);
                        item.UniformStationaryExps = sqlDataReader["UniformStationaryExps"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["UniformStationaryExps"]);
                        item.PettyCashExps = sqlDataReader["PettyCashExps"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PettyCashExps"]);
                        item.FuelDieselTravellingExps = sqlDataReader["FuelDieselTravellingExps"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FuelDieselTravellingExps"]);
                        item.MiscExps = sqlDataReader["MiscExps"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["MiscExps"]);
                        item.SubTotalExps = sqlDataReader["SubTotalExps"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SubTotalExps"]);
                        item.Payroll = sqlDataReader["Payroll"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Payroll"]);
                        item.PFContribution = sqlDataReader["PFContribution"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PFContribution"]);
                        item.ESICContribution = sqlDataReader["ESICContribution"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ESICContribution"]);
                        item.PTAmount = sqlDataReader["PTAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PTAmount"]);
                        item.Bonus = sqlDataReader["Bonus"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Bonus"]);
                        item.Depreciation = sqlDataReader["Depreciation"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Depreciation"]);
                        item.SubTotalAllExps = sqlDataReader["SubTotalAllExps"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SubTotalAllExps"]);
                        item.TotalCost = sqlDataReader["TotalCost"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalCost"]);
                        item.BadDebts = sqlDataReader["BadDebts"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BadDebts"]);
                        item.TDSAmount = sqlDataReader["TDSAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TDSAmount"]);
                        item.NetProfit = sqlDataReader["NetProfit"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetProfit"]);
                        item.Profit = sqlDataReader["Profit"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Profit"]);
                        item.Granularity = sqlDataReader["Granularity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Granularity"]);

                        item.CustomerMasterName = searchRequest.CustomerMasterName;
                        item.CustomerBranchMasterName = searchRequest.CustomerBranchMasterName;
                        item.CustomerMasterID = searchRequest.CustomerMasterID;
                        item.CustomerBranchMasterID = searchRequest.CustomerBranchMasterID;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GrossOperatingProfitReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
