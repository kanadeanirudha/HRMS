using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public class RetailReportsDataProvider : DBInteractionBase, IRetailReportsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public RetailReportsDataProvider() { }
        public RetailReportsDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<RetailReports> GetRetailReportsBySearch(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandText = "dbo.USP_SaleAnalysisReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.Granularity) ? new short() : Convert.ToInt16(searchRequest.Granularity)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();
                        if (searchRequest.Granularity == "1")
                        {
                            item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                            item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                            item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                            item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                            item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                            item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                            item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                            item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                            item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                            item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                            item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                            item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                            item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                            item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                            item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                            item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                            item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                            item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);
                        }
                        else if (searchRequest.Granularity == "2")
                        {
                            item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                            item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                            item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                            item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                            item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                            item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                            item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                            item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                            item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                            item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                            item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                            item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                            item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                            item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                            item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                            item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                            item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                            item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);
                        }
                        else if (searchRequest.Granularity == "3")
                        {
                            item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                            item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                            item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                            item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                            item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                            item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                            item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                            item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                            item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                            item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                            item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                            item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                            item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                            item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                            item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                            item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                            item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                            item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);
                        }
                        else if (searchRequest.Granularity == "4")
                        {
                            item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                            item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                            item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                            item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                            item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                            item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                            item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                            item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                            item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                            item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                            item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                            item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                            item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                            item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                            item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                            item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                            item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                            item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);
                        }
                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.CentreName = searchRequest.CentreName;
                        item.GranularityName = searchRequest.GranularityName;

                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryDaysOfCoverReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandText = "dbo.USP_DaysOfCoverReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.CentreCode) ? string.Empty : searchRequest.CentreCode));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();
                        item.GeneralUnitKey = sqlDataReader["GeneralUnitKey"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralUnitKey"]);
                        item.GeneralItemMasterKey = sqlDataReader["GeneralItemMasterKey"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemMasterKey"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.BaseUomCode = sqlDataReader["BaseUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUomCode"]);
                        item.ItemDisplayFromDate = sqlDataReader["ItemDisplayFromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDisplayFromDate"]);
                        item.TransactionFromDate = sqlDataReader["TransactionFromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionFromDate"]);
                        item.TotalSalesQuantity = sqlDataReader["TotalSalesQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalSalesQuantity"]);
                        item.ItemCategoryCode = sqlDataReader["ItemCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        item.UnitRelatedWith = sqlDataReader["UnitRelatedWith"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitRelatedWith"]);
                        item.currentstockqty = sqlDataReader["currentstockqty"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["currentstockqty"]);
                        item.AverageDailySale = sqlDataReader["AverageDailySale"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["AverageDailySale"]);
                        item.DaysOfCover = sqlDataReader["DaysOfCover"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DaysOfCover"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryBillDetailReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandText = "dbo.USP_InventoryBillReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    // cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.CentreCode) ? string.Empty : searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPaymentMode", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToByte(searchRequest.PaymentMode)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiIsBillRelevantTo", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));

                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();
                        //item.GeneralUnitKey = sqlDataReader["GeneralUnitKey"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralUnitKey"]);
                        item.SRNo = sqlDataReader["SRNo"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SRNo"]);
                        item.Date = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                        item.Amount = sqlDataReader["BillAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillAmount"]);
                        item.Store = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        item.BillNo = sqlDataReader["BillNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BillNo"]);

                        item.ModeOfPayment = sqlDataReader["paymentmode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["paymentmode"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }


        public IBaseEntityCollectionResponse<RetailReports> GetInventoryCounterDetailReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandText = "dbo.USP_InventoryCounterReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.CentreCode) ? string.Empty : searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();
                        item.Date = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                        item.CounterName = sqlDataReader["CounterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CounterName"]);
                        item.card = sqlDataReader["CardBillAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CardBillAmount"]);
                        item.cash = sqlDataReader["CashBillAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CashBillAmount"]);
                        item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);
                        item.TotalCard = sqlDataReader["TotalCardBillAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCardBillAmount"]);
                        item.TotalCash = sqlDataReader["TotalCashBillAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCashBillAmount"]);
                        item.TotalSaleReturn = sqlDataReader["TotalSaleReturn"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalSaleReturn"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAmount"]);
                        item.CentreName = searchRequest.CentreName;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<RetailReports> GetRetailSalesAndMarginReportsBySearch(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandText = "dbo.USP_SaleAnalysisReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.Granularity) ? new short() : Convert.ToInt16(searchRequest.Granularity)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();
                        if (searchRequest.Granularity == "1")
                        {
                            item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                            item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                            item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                            item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                            item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                            item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                            item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                            item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                            item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                            item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                            item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                            item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                            item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                            item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                            item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                            item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                            item.Margin = sqlDataReader["Margin"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Margin"]);
                            item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                            item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                            item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);
                        }
                        else if (searchRequest.Granularity == "2")
                        {
                            item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                            item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                            item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                            item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                            item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                            item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                            item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                            item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                            item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                            item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                            item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                            item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                            item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                            item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                            item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                            item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                            item.Margin = sqlDataReader["Margin"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Margin"]);
                            item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                            item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                            item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);
                        }
                        else if (searchRequest.Granularity == "3")
                        {
                            item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                            item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                            item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                            item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                            item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                            item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                            item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                            item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                            item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                            item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                            item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                            item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                            item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                            item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                            item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                            item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                            item.Margin = sqlDataReader["Margin"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Margin"]);
                            item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                            item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                            item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);
                        }
                        else if (searchRequest.Granularity == "4")
                        {
                            item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                            item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                            item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                            item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                            item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                            item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                            item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                            item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                            item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                            item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                            item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                            item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                            item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                            item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                            item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                            item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                            item.Margin = sqlDataReader["Margin"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Margin"]);
                            item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                            item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                            item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);
                        }

                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.CentreName = searchRequest.CentreName;
                        item.GranularityName = searchRequest.GranularityName;

                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<RetailReports> GetVendorServiceLevelBySearch(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandText = "dbo.USP_VendorServiceLevelReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    // cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.CentreCode) ? string.Empty : searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();
                        item.ID = sqlDataReader["ID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["ID"]);
                        item.VendorNo = sqlDataReader["VendorNo"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["VendorNo"]);
                        item.VendorDescription = sqlDataReader["VendorDescription"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["VendorDescription"]);
                        item.NoOfItemsOrderedInPO = sqlDataReader["NoOfItemsOrderedInPO"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["NoOfItemsOrderedInPO"]);
                        item.NoOfItemsDelivered = sqlDataReader["NoOfItemsDelivered"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["NoOfItemsDelivered"]);
                        item.ServiceLevel = sqlDataReader["ServiceLevel"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ServiceLevel"]);

                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<RetailReports> GetInventoryDiscountReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandText = "dbo.USP_InventoryDiscountReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.CentreCode) ? string.Empty : searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dDiscountInPercent", SqlDbType.Decimal, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DiscountInPercent));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsPercentage", SqlDbType.Bit, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.IsPercentage));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();
                        item.PromotionName = sqlDataReader["PromotionActivityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PromotionActivityName"]);
                        item.DiscountInPercent = sqlDataReader["DiscountInPercent"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DiscountInPercent"]);
                        // item.DiscountInPercent = sqlDataReader["DiscountInPercent"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DiscountInPercent"]);
                        item.Discount = sqlDataReader["Discount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Discount"]);
                        item.NetAmount = sqlDataReader["NetAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["NetAmount"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalAmount"]);

                        item.DateFrom = searchRequest.DateFrom;
                        item.DateTo = searchRequest.DateTo;
                        item.DiscountType = searchRequest.DiscountType;
                        item.CentreName = searchRequest.CentreName;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryStockGapAnalysisReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_StockGapAnalysisReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();

                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.BaseUomCode = sqlDataReader["BaseUomCode"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["BaseUomCode"]);
                        item.GRNQuantity = sqlDataReader["GRNQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["GRNQuantity"]);
                        item.SalesQuantity = sqlDataReader["SalesQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SalesQuantity"]);
                        item.GRNSalesQuantity = sqlDataReader["GRNSalesQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["GRNSalesQuantity"]);
                        item.CurrentStock = sqlDataReader["CurrentStock"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CurrentStock"]);
                        item.StatusFlag = sqlDataReader["StatusFlag"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        item.SalesReturn = sqlDataReader["SalesReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SalesReturnQuantity"]);
                        item.PurchaseReturn = sqlDataReader["PurchaseReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchaseReturnQuantity"]);
                        item.PIPositive = sqlDataReader["GRPhysicalInventoryQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["GRPhysicalInventoryQuantity"]);
                        item.PINegative = sqlDataReader["GIPhysicalInventoryFilter"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["GIPhysicalInventoryFilter"]);
                        item.Damaged = sqlDataReader["DamagedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DamagedQuantity"]);
                        item.Sample = sqlDataReader["SampleQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SampleQuantity"]);
                        item.BlockedForInspection = sqlDataReader["BlockedforInspectionQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BlockedforInspectionQuantity"]);
                        item.Wastage = sqlDataReader["WastageQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.Shrinkage = sqlDataReader["ShrinkageQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ShrinkageQuantity"]);
                        item.FreeBie = sqlDataReader["FreebieQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["FreebieQuantity"]);
                        item.Consumption = sqlDataReader["ConsumptionQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ConsumptionQuantity"]);
                        item.STOOutward = sqlDataReader["STOOutwardQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["STOOutwardQuantity"]);
                        item.TotalStockAdjustment = sqlDataReader["TotalStockAdjustment"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalStockAdjustment"]);
                        item.AdjustedStock = sqlDataReader["AdjustedStock"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["AdjustedStock"]);
                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;

                        //DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        //DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        //item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        //item.DateTo = DateTo.ToString("d MMMM yyyy");

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_StockGapAnalysisReport' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        //For TakeAwayVsFineDiningReport
        public IBaseEntityCollectionResponse<RetailReports> GetRetailReportsBySearch_GetDinningReportList(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_TakeAwayVsFineDineReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();

                        item.Date = sqlDataReader["Date"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Date"]);
                        item.TakeAwaySaleAmount = sqlDataReader["TakeAwaySale"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TakeAwaySale"]);
                        item.TakeAwayNumberOfOrder = sqlDataReader["TakeAwayTotalOrder"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["TakeAwayTotalOrder"]);
                        item.FineDiningSaleAmount = sqlDataReader["FineDineSale"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FineDineSale"]);
                        item.FineDiningNumberOfOrder = sqlDataReader["FineDineTotalOrder"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["FineDineTotalOrder"]);
                        item.TotalNumberOfSale = sqlDataReader["TotalOrder"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["TotalOrder"]);
                        item.TotalSale = sqlDataReader["TotalSale"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalSale"]);
                        item.SalesReturnAmount = sqlDataReader["SalesReturnAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SalesReturnAmount"]);
                        item.SalesReturnOrder = sqlDataReader["SalesReturnOrder"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalesReturnOrder"]);

                        item.CentreName = searchRequest.CentreName;
                        item.GranularityName = searchRequest.GranularityName;

                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<RetailReports> GetConsumptionDetailReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;

                    cmdToExecute.CommandText = "dbo.USP_InventoryConsumptionDetailReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();
                        item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                        item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                        item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                        item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                        item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                        item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                        item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                        item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                        item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                        item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.ConsumptionQuantity = sqlDataReader["ConsumptionQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionQuantity"]);
                        item.ConsumptionAmount = sqlDataReader["ConsumptionAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);

                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleSummeryReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();

                        item.Date = sqlDataReader["Date"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Date"]);
                        item.CashToday = sqlDataReader["CashToday"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CashToday"]);
                        item.CashTillLast = sqlDataReader["CashTillLast"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CashTillLast"]);
                        item.TotalCashSale = sqlDataReader["TotalCashSale"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCashSale"]);
                        item.CardToday = sqlDataReader["CardToday"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CardToday"]);
                        item.CardTillLast = sqlDataReader["CardTillLast"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CardTillLast"]);
                        item.TotalCardSale = sqlDataReader["TotalCardSale"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCardSale"]);
                        item.TotalSale = sqlDataReader["TotalSale"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalSale"]);

                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");
                        item.CentreName = searchRequest.CentreName;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleSummeryReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch_DateWise(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleSummeryReport_DateWise_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Date));

                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();

                        item.BillNumber = sqlDataReader["BillNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BillNumber"]);
                        item.BillAmount = sqlDataReader["BillAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BillAmount"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.Date = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                        item.PaymentMode = sqlDataReader["PaymentMode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PaymentMode"]);
                        item.GeneralUnitKey = sqlDataReader["GeneralUnitKey"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralUnitKey"]);
                        item.TotalBillAmount = sqlDataReader["TotalBillAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalBillAmount"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleSummeryReport_DateWise_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch_OrderNoWise(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleSummeryReport_OrderWise_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBillNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.BillNumber));

                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();

                        item.GlobalInvoiceNumber = sqlDataReader["GlobalInvoiceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GlobalInvoiceNumber"]);
                        item.LocalInvoiceNumber = sqlDataReader["LocalInvoiceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocalInvoiceNumber"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.Date = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                        item.PaymentMode = sqlDataReader["PaymentMode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PaymentMode"]);
                        item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.TotalPrice = sqlDataReader["TotalPrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalPrice"]);
                        item.Discount = sqlDataReader["DiscountAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DiscountAmount"]);
                        item.Item = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.TotalBillAmount = sqlDataReader["NetAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetAmount"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleSummeryReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }


        //public IBaseEntityCollectionResponse<RetailReports> GetInventoryCurrentStockAmount(RetailReportsSearchRequest searchRequest)
        //{
        //    //throw new NotImplementedException();
        //    IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    SqlDataReader sqlDataReader = null;

        //    try
        //    {
        //        if (string.IsNullOrEmpty(searchRequest.ConnectionString))
        //        {
        //            baseEntityCollection.Message.Add(new MessageDTO()
        //            {
        //                ErrorMessage = "Connection string is empty.",
        //                MessageType = MessageTypeEnum.Error
        //            });
        //        }
        //        else
        //        {
        //            // Use base class' connection object
        //            _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

        //            cmdToExecute.Connection = _wareHouseDbConnection;
        //            cmdToExecute.CommandText = "dbo.USP_InventoryCurrentStockAmount_SelectAll";
        //            cmdToExecute.CommandType = CommandType.StoredProcedure;
        //            // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
        //            cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.CentreCode) ? string.Empty : searchRequest.CentreCode));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@siGeneralUnitsId", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
        //            //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
        //            if (_wareHouseDbConnectionIsCreatedLocal)
        //            {
        //                // Open connection.
        //                _wareHouseDbConnection.Open();
        //            }
        //            else
        //            {
        //                if (_wareHouseDbConnectionProvider.IsTransactionPending)
        //                {
        //                    cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
        //                }
        //            }

        //            sqlDataReader = cmdToExecute.ExecuteReader();

        //            baseEntityCollection.CollectionResponse = new List<RetailReports>();
        //            while (sqlDataReader.Read())
        //            {
        //                RetailReports item = new RetailReports();

        //                item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
        //                item.BaseUomCode = sqlDataReader["BaseUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUomCode"]);
        //                item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
        //                item.CurrentStock = sqlDataReader["CurrentStock"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CurrentStock"]);
        //                item.Amount = sqlDataReader["StockAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["StockAmount"]);

        //                baseEntityCollection.CollectionResponse.Add(item);
        //            }

        //            if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
        //            {
        //                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
        //            }

        //            if (_errorCode != (int)ErrorEnum.AllOk)
        //            {
        //                // Throw error.
        //                throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        baseEntityCollection.Message.Add(new MessageDTO()
        //        {
        //            ErrorMessage = ex.InnerException.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        // _logException.Error(ex.Message);
        //    }
        //    finally
        //    {
        //        if (_wareHouseDbConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _wareHouseDbConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //    return baseEntityCollection;
        //}

        public IBaseEntityCollectionResponse<RetailReports> GetVendorWiseSaleAndPurchaseReport(RetailReportsSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailReports> baseEntityCollection = new BaseEntityCollectionResponse<RetailReports>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_InventoryVendorwiseSaleAndPurchaseReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.CentreCode) ? string.Empty : searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<RetailReports>();
                    while (sqlDataReader.Read())
                    {
                        RetailReports item = new RetailReports();

                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.VendorName = sqlDataReader["Vender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
                        item.PurchaseQuantity = sqlDataReader["PurchaseQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchaseQuantity"]);
                        item.PurchaseAmount = sqlDataReader["PurchaseAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchaseAmount"]);
                        item.SaleQuantity = sqlDataReader["SaleQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleQuantity"]);
                        item.SaleAmount = sqlDataReader["SaleAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleAmount"]);
                        item.CurrentStock = sqlDataReader["CurrentStockQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CurrentStockQuantity"]);
                        item.CurrentStockAmount = sqlDataReader["CurrentStockAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CurrentStockAmount"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleSummeryReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
    }
}
