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
    public class SaleContractWisePNLReportDataProvider : DBInteractionBase, ISaleContractWisePNLReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SaleContractWisePNLReportDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SaleContractWisePNLReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<SaleContractWisePNLReport> GetSaleContractWisePNLReportDataList(SaleContractWisePNLReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractWisePNLReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractWisePNLReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractWisePNLReport";
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractWisePNLReport>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractWisePNLReport item = new SaleContractWisePNLReport();

                        item.NetAmount = sqlDataReader["NetAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetAmount"]);
                        item.TaxAmount = sqlDataReader["TaxAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxAmount"]);
                        item.TotalIInvoiceAmount = sqlDataReader["TotalIInvoiceAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalIInvoiceAmount"]);
                        item.NetPayable = sqlDataReader["NetPayable"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetPayable"]);
                        item.PFAmount = sqlDataReader["PFAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PFAmount"]);
                        item.ESICAmount = sqlDataReader["ESICAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ESICAmount"]);
                        item.PTAmount = sqlDataReader["PTAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PTAmount"]);
                        item.TotalPayable = sqlDataReader["TotalPayable"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalPayable"]);
                        item.Profit = sqlDataReader["Profit"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Profit"]);
                        item.TotalPosting = sqlDataReader["TotalPosting"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalPosting"]);
                        item.TDSAmount = sqlDataReader["TDSAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TDSAmount"]);
                        item.NetProfit = sqlDataReader["NetProfit"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetProfit"]);
                        item.FOODAmount = sqlDataReader["FOODAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FOODAmount"]);
                        item.NonReimAmount = sqlDataReader["NonReimAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NonReimAmount"]); 

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
                        throw new Exception("Stored Procedure 'USP_SaleContractWisePNLReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
