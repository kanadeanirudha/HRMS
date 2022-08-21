using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public class InventoryReportDataProvider : DBInteractionBase, IInventoryReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public InventoryReportDataProvider() { }
        public InventoryReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_PriceList(InventoryReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryReport>();
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
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.GeneralItemMasterMissingException_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsReportFor", SqlDbType.NVarChar, 25, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ReportFor));

                    if (searchRequest.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtEndDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionUptoDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstId));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountSessionID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsSubLedger", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.IsSubLedger));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@cAssetLiabilityFlag", SqlDbType.Char, 5, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AssetLiabilityFlag));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
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

                    baseEntityCollection.CollectionResponse = new List<InventoryReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryReport item = new InventoryReport();
                        if (searchRequest.ReportFor == "All")
                        {

                            if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                            {
                                item.ItemNumber = Convert.ToString(sqlDataReader["ItemNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                            {
                                item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemCategoryCode"]) == false)
                            {
                                item.ItemCategoryCode = Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["IsBaseUom"]) == false)
                            {
                                item.IsBaseUom = Convert.ToString(sqlDataReader["IsBaseUom"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["IsOrderingUnit"]) == false)
                            {
                                item.IsOrderingUnit = Convert.ToBoolean(sqlDataReader["IsOrderingUnit"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["IsSaleUnit"]) == false)
                            {
                                item.IsSaleUnit = Convert.ToString(sqlDataReader["IsSaleUnit"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["GeneralVendorID"]) == false)
                            {
                                item.Vendor = Convert.ToString(sqlDataReader["GeneralVendorID"]);
                            }

                            if (DBNull.Value.Equals(sqlDataReader["PurchaseUomCode"]) == false)
                            {
                                item.PurchaseUomCode = Convert.ToString(sqlDataReader["PurchaseUomCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["GeneralPurchaseGroupMasterID"]) == false)
                            {
                                item.PurchaseGroup = Convert.ToString(sqlDataReader["GeneralPurchaseGroupMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LeadTime"]) == false)
                            {
                                item.LeadTime = Convert.ToString(sqlDataReader["LeadTime"]);
                            }

                            if (DBNull.Value.Equals(sqlDataReader["ShelfExpiryLife"]) == false)
                            {
                                item.ShelfExpiryLife = Convert.ToString(sqlDataReader["ShelfExpiryLife"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["RemainingShelfLife"]) == false)
                            {
                                item.RemainingShelfLife = Convert.ToString(sqlDataReader["RemainingShelfLife"]);
                            }

                            if (DBNull.Value.Equals(sqlDataReader["Price"]) == false)
                            {
                                item.Price = Convert.ToDecimal(sqlDataReader["Price"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["GeneralUnitsID"]) == false)
                            {
                                item.Store = Convert.ToString(sqlDataReader["GeneralUnitsID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["OrderingDay"]) == false)
                            {
                                item.OrderingDay = Convert.ToString(sqlDataReader["OrderingDay"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["DeliveryDay"]) == false)
                            {
                                item.DeliveryDay = Convert.ToString(sqlDataReader["DeliveryDay"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["SalesPrice"]) == false)
                            {
                                item.SalesPrice = Convert.ToDecimal(sqlDataReader["SalesPrice"]);
                            }
                        }
                        else if (searchRequest.ReportFor == "CategoryDetails")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                            {
                                item.ItemNumber = Convert.ToString(sqlDataReader["ItemNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                            {
                                item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemCategoryCode"]) == false)
                            {
                                item.ItemCategoryCode = Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                            }
                        }
                        else if (searchRequest.ReportFor == "UOMDetails")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                            {
                                item.ItemNumber = Convert.ToString(sqlDataReader["ItemNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                            {
                                item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                            }
                            //if (DBNull.Value.Equals(sqlDataReader["ItemCategoryCode"]) == false)
                            //{
                            //    item.ItemCategoryCode = Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                            //}
                            if (DBNull.Value.Equals(sqlDataReader["IsBaseUom"]) == false)
                            {
                                item.IsBaseUom = Convert.ToString(sqlDataReader["IsBaseUom"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["IsOrderingUnit"]) == false)
                            {
                                item.IsOrderingUnit = Convert.ToBoolean(sqlDataReader["IsOrderingUnit"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["IsSaleUnit"]) == false)
                            {
                                item.IsSaleUnit = Convert.ToString(sqlDataReader["IsSaleUnit"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["BarCode"]) == false)
                            {
                                item.BarCode = Convert.ToString(sqlDataReader["BarCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UomCode"]) == false)
                            {
                                item.UomCode = Convert.ToString(sqlDataReader["UomCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ConversionFactor"]) == false)
                            {
                                item.ConversionFactor = Convert.ToDecimal(sqlDataReader["ConversionFactor"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LowerLevelUomCode"]) == false)
                            {
                                item.LowerLevelUomCode = Convert.ToString(sqlDataReader["LowerLevelUomCode"]);
                            }

                        }
                        else if (searchRequest.ReportFor == "VendorDetails")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                            {
                                item.ItemNumber = Convert.ToString(sqlDataReader["ItemNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                            {
                                item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Vender"]) == false)
                            {
                                item.Vender = Convert.ToString(sqlDataReader["Vender"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["PurchaseUoMCode"]) == false)
                            {
                                item.PurchaseUoMCode = Convert.ToString(sqlDataReader["PurchaseUoMCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TaxGroupName"]) == false)
                            {
                                item.TaxGroupName = Convert.ToString(sqlDataReader["TaxGroupName"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["PurchaseGroupCode"]) == false)
                            {
                                item.PurchaseGroupCode = Convert.ToString(sqlDataReader["PurchaseGroupCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["MinOrderQuantity"]) == false)
                            {
                                item.MinimumOrderQuantity = Convert.ToDouble(sqlDataReader["MinOrderQuantity"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LeadTime"]) == false)
                            {
                                item.LeadTime = Convert.ToString(sqlDataReader["LeadTime"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ShelfExpiryLife"]) == false)
                            {
                                item.ShelfExpiryLife = Convert.ToString(sqlDataReader["ShelfExpiryLife"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["RemainingShelfLife"]) == false)
                            {
                                item.RemainingShelfLife = Convert.ToString(sqlDataReader["RemainingShelfLife"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LastPurchasePrice"]) == false)
                            {
                                item.LastPurchasePrice = Convert.ToDouble(sqlDataReader["LastPurchasePrice"]);
                            }
                        }
                        else if (searchRequest.ReportFor == "SaleDetails")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                            {
                                item.ItemNumber = Convert.ToString(sqlDataReader["ItemNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                            {
                                item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UnitName"]) == false)
                            {
                                item.UnitName = Convert.ToString(sqlDataReader["UnitName"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UomCode"]) == false)
                            {
                                item.UomCode = Convert.ToString(sqlDataReader["UomCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Price"]) == false)
                            {
                                item.Price = Convert.ToDecimal(sqlDataReader["Price"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["BarCode"]) == false)
                            {
                                item.BarCode = Convert.ToString(sqlDataReader["BarCode"]);
                            }
                        }
                        else if (searchRequest.ReportFor == "StoreDetails")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                            {
                                item.ItemNumber = Convert.ToString(sqlDataReader["ItemNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                            {
                                item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UnitName"]) == false)
                            {
                                item.UnitName = Convert.ToString(sqlDataReader["UnitName"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Orderingday"]) == false)
                            {
                                item.OrderingDay = Convert.ToString(sqlDataReader["Orderingday"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["delivaryDay"]) == false)
                            {
                                item.delivaryDay = Convert.ToString(sqlDataReader["delivaryDay"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ReorderPoint"]) == false)
                            {
                                item.ReorderPoint = Convert.ToByte(sqlDataReader["ReorderPoint"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["SafetyStockDriven"]) == false)
                            {
                                item.SafetyStockDriven = Convert.ToByte(sqlDataReader["SafetyStockDriven"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemDisplayFromDate"]) == false)
                            {
                                item.ItemDisplayFromDate = Convert.ToString(sqlDataReader["ItemDisplayFromDate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["itemDisplayUpto"]) == false)
                            {
                                item.itemDisplayUpto = Convert.ToString(sqlDataReader["itemDisplayUpto"]);
                            }
                        }
                        else if (searchRequest.ReportFor == "RestaurantDetails")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["MainMenuItemName"]) == false)
                            {
                                item.MainMenuItemName = Convert.ToString(sqlDataReader["MainMenuItemName"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ArabicTransalation"]) == false)
                            {
                                item.ArabicTransalation = Convert.ToString(sqlDataReader["ArabicTransalation"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["MenuCategory"]) == false)
                            {
                                item.MenuCategory = Convert.ToString(sqlDataReader["MenuCategory"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["BillingItemName"]) == false)
                            {
                                item.BillingItemName = Convert.ToString(sqlDataReader["BillingItemName"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["RecipeVariationTitle"]) == false)
                            {
                                item.RecipeVariationTitle = Convert.ToString(sqlDataReader["RecipeVariationTitle"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Definevariants"]) == false)
                            {
                                item.Definevariants = Convert.ToString(sqlDataReader["Definevariants"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["MainMenuItemNamePrice"]) == false)
                            {
                                item.MainMenuItemPrice = Convert.ToDecimal(sqlDataReader["MainMenuItemNamePrice"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["VariationPrice"]) == false)
                            {
                                item.VariationPrice = Convert.ToDecimal(sqlDataReader["VariationPrice"]);
                            }
                        }
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
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        //Item Master Missing Rxception report
        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ItemList(InventoryReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_PriceReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryReport item = new InventoryReport();

                        item.ItemName = sqlDataReader["ItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemNumber"]);
                        item.OrderUoM = sqlDataReader["OrderUoM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUoM"]);
                        item.SalesPrice = sqlDataReader["SalesPrice"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SalesPrice"]);
                        item.SalesUoM = sqlDataReader["SalesUoM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesUoM"]);
                        item.CostperOrderUnit = sqlDataReader["CostPerOrderUnit"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CostPerOrderUnit"]);
                        item.Site = sqlDataReader["Site"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Site"]);
                        item.HSNCode = sqlDataReader["HSNCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSNCode"]);
                        item.ItemCategoryCode = sqlDataReader["ItemCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryCode"]);
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
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        //For Article Expiry Report

        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ArticleList(InventoryReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_ArticleExpiry_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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

                    baseEntityCollection.CollectionResponse = new List<InventoryReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryReport item = new InventoryReport();

                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.BatchNumber = sqlDataReader["BatchNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BatchNumber"]);
                        item.ExpiryDate = sqlDataReader["ExpiryDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExpiryDate"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemNumber"]);
                        item.Vender = sqlDataReader["Vender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
                        item.VendorNumber = sqlDataReader["VendorNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorNumber"]);
                        item.RemainingShelfLife = sqlDataReader["RemainingShelfLife"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RemainingShelfLife"]);
                        item.StatusFlag = sqlDataReader["StatusFlag"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        item.BalanceDays = sqlDataReader["BalanceDays"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["BalanceDays"]);
                        item.RemainingDays = sqlDataReader["RemainingDays"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RemainingDays"]);
                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
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
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<InventoryReport> GetItemRequirementReportList(InventoryReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_ItemRequirement_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralItemMasterID));
                    if (searchRequest.FromDate != null && searchRequest.FromDate != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFromDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFromDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (searchRequest.UptoDate != null && searchRequest.UptoDate != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUptoDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUptoDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

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

                    baseEntityCollection.CollectionResponse = new List<InventoryReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryReport item = new InventoryReport();

                        item.SalesOrderNumber = sqlDataReader["SalesOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderNumber"]);
                        item.RequiredQuantity = sqlDataReader["RequiredQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["RequiredQuantity"]);
                        item.DispatchedQuantity = sqlDataReader["DispatchedQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DispatchedQuantity"]);
                        item.RemainingQuantity = sqlDataReader["RemainingQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["RemainingQuantity"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        item.UomCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);

                        item.ItemDescription = searchRequest.ItemDescription;
                        item.CentreName = searchRequest.CentreName;
                        item.FromDate = searchRequest.FromDate;
                        item.UptoDate = searchRequest.UptoDate;

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
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<InventoryReport> GetItemHistoryReportList(InventoryReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_ItemHistory_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralItemMasterID));
                    if (searchRequest.FromDate != null && searchRequest.FromDate != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFromDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFromDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (searchRequest.UptoDate != null && searchRequest.UptoDate != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUptoDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUptoDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

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

                    baseEntityCollection.CollectionResponse = new List<InventoryReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryReport item = new InventoryReport();

                        item.TransDate = sqlDataReader["TransDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransDate"]);
                        item.BaseQuantity = sqlDataReader["Quantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.BaseUoM= sqlDataReader["BaseUOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUOM"]);
                        item.SalesUoM= sqlDataReader["TransactionUOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionUOM"]);
                        item.DispatchedQuantity = sqlDataReader["TransactionQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TransactionQuantity"]);
                        item.LocationName = sqlDataReader["LocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.TransactionTypeId = sqlDataReader["TransactionTypeId"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TransactionTypeId"]);
                        item.TransactionNumber = sqlDataReader["TransactionNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionNumber"]);
                        item.VendorAndCustomer = sqlDataReader["VendorAndCustomer"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorAndCustomer"]);
                        item.Price = sqlDataReader["Rate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Rate"]);

                        item.ItemDescription = searchRequest.ItemDescription;
                        item.CentreName = searchRequest.CentreName;
                        item.FromDate = searchRequest.FromDate;
                        item.UptoDate = searchRequest.UptoDate;

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
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
    }
}
