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
    public class RetailSalesAndMarginDrillDownReportDataProvider : DBInteractionBase, IRetailSalesAndMarginDrillDownReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public RetailSalesAndMarginDrillDownReportDataProvider() { }
        public RetailSalesAndMarginDrillDownReportDataProvider(ILogger logException)
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
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> GetRetailSalesAndMarginDrillDownReportBySearch(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
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
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.Granularity)? new short() : Convert.ToInt16(searchRequest.Granularity) ));
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

                    baseEntityCollection.CollectionResponse = new List<RetailSalesAndMarginDrillDownReport>();
                    while (sqlDataReader.Read())
                    {
                        RetailSalesAndMarginDrillDownReport item = new RetailSalesAndMarginDrillDownReport();
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
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_GroupDescriptionList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleAnalysisReportGroupDescription_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.Granularity)? new short() : Convert.ToInt16(searchRequest.Granularity) ));
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

                    baseEntityCollection.CollectionResponse = new List<RetailSalesAndMarginDrillDownReport>();
                    while (sqlDataReader.Read())
                    {
                        RetailSalesAndMarginDrillDownReport item = new RetailSalesAndMarginDrillDownReport();
                        item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                        item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                        item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                        item.Margin = sqlDataReader["Margin"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Margin"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                        item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);

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

        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseDepartmentList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleAnalysisReportMerchantiseDepartment_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.Granularity)? new short() : Convert.ToInt16(searchRequest.Granularity) ));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMarchandiseGroupCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MarchandiseGroupCode));
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

                    baseEntityCollection.CollectionResponse = new List<RetailSalesAndMarginDrillDownReport>();
                    while (sqlDataReader.Read())
                    {
                        RetailSalesAndMarginDrillDownReport item = new RetailSalesAndMarginDrillDownReport();
                        item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                        item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                        item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                        item.Margin = sqlDataReader["Margin"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Margin"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                        item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);

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
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleAnalysisReportMerchantiseCategory_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.Granularity)? new short() : Convert.ToInt16(searchRequest.Granularity) ));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMarchandiseDepartmentCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MerchantiseDepartmentCode));
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

                    baseEntityCollection.CollectionResponse = new List<RetailSalesAndMarginDrillDownReport>();
                    while (sqlDataReader.Read())
                    {
                        RetailSalesAndMarginDrillDownReport item = new RetailSalesAndMarginDrillDownReport();
                        item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                        item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                        item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                        item.Margin = sqlDataReader["Margin"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Margin"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                        item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);

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
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseSubCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleAnalysisReportMerchantiseSubCategory_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.Granularity)? new short() : Convert.ToInt16(searchRequest.Granularity) ));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMarchandiseCategoryCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MerchantiseCategoryCode));
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

                    baseEntityCollection.CollectionResponse = new List<RetailSalesAndMarginDrillDownReport>();
                    while (sqlDataReader.Read())
                    {
                        RetailSalesAndMarginDrillDownReport item = new RetailSalesAndMarginDrillDownReport();
                        item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                        item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                        item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                        item.Margin = sqlDataReader["Margin"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Margin"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                        item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);

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
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseBaseCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleAnalysisReportMerchantiseBaseCategory_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.Granularity)? new short() : Convert.ToInt16(searchRequest.Granularity) ));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMarchandiseSubCategoryCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MarchandiseSubCatgoryCode));
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

                    baseEntityCollection.CollectionResponse = new List<RetailSalesAndMarginDrillDownReport>();
                    while (sqlDataReader.Read())
                    {
                        RetailSalesAndMarginDrillDownReport item = new RetailSalesAndMarginDrillDownReport();
                        item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                        item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                        item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                        item.Margin = sqlDataReader["Margin"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Margin"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                        item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);

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
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_ItemDescriptionList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleAnalysisReportItemDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.Granularity)? new short() : Convert.ToInt16(searchRequest.Granularity) ));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMarchandiseBaseCategoryCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MarchandiseBaseCatgoryCode));
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

                    baseEntityCollection.CollectionResponse = new List<RetailSalesAndMarginDrillDownReport>();
                    while (sqlDataReader.Read())
                    {
                        RetailSalesAndMarginDrillDownReport item = new RetailSalesAndMarginDrillDownReport();
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                        item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                        item.Margin = sqlDataReader["Margin"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Margin"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                        item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);

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

        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_StoreList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleAnalysisReportStores_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(searchRequest.Granularity) ? new short() : Convert.ToInt16(searchRequest.Granularity)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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

                    baseEntityCollection.CollectionResponse = new List<RetailSalesAndMarginDrillDownReport>();
                    while (sqlDataReader.Read())
                    {
                        RetailSalesAndMarginDrillDownReport item = new RetailSalesAndMarginDrillDownReport();
                      
                        item.GeneralUnitsId = sqlDataReader["GeneralUnitsId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralUnitsId"]);
                        item.GeneralUnitsName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                        item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                        item.Margin = sqlDataReader["Margin"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Margin"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.SaleReturnQuantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                        item.SaleReturnAmount = sqlDataReader["SaleReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnAmount"]);

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
    }
}
