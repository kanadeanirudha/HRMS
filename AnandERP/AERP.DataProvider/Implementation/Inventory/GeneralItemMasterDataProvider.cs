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
    public class GeneralItemMasterDataProvider : DBInteractionBase, IGeneralItemMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public GeneralItemMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public GeneralItemMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from GeneralItemMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterBySearch(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();

                        //item.ID = sqlDataReader["GeneralItemMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralItemMasterID"]);
                        //item.MarchantiseSubCategoryName = sqlDataReader["MerchantiseSubCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseSubCategoryName"]);
                        //item.MarchantiseSubCategoryCode = sqlDataReader["MerchantiseSubCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseSubCategoryCode"]);




                        baseEntityCollection.CollectionResponse.Add(item);
                        baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterSearchList(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();
                        item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.ItemCode = sqlDataReader["ItemCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCode"]);
                        item.ItemCategoryCode = sqlDataReader["ItemCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                        item.BaseUoMcode = sqlDataReader["BaseUoMcode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUoMcode"]);
                        //item.LastPurchasePrice = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDouble(sqlDataReader["Price"]);
                        // item.CurrencyCode = sqlDataReader["CurrencyCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CurrencyCode"]);
                        //item.BaseBarCode = sqlDataReader["BaseBarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseBarCode"]);
                        //item.BasePriceListID = sqlDataReader["BasePriceListID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["BasePriceListID"]);
                        //  item.InventoryPurchaseGroupMasterId = sqlDataReader["InventoryPurchaseGroupMasterId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["InventoryPurchaseGroupMasterId"]);
                        //item.IsInventoryItem                 = Convert.ToBoolean(sqlDataReader["IsInventoryItem"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsInventoryItem"]) == false)
                        {
                            item.IsInventoryItem = Convert.ToBoolean(sqlDataReader["IsInventoryItem"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsSalesItem"]) == false)
                        {
                            item.IsSalesItem = Convert.ToBoolean(sqlDataReader["IsSalesItem"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsPurchaseItem"]) == false)
                        {
                            item.IsPurchaseItem = Convert.ToBoolean(sqlDataReader["IsPurchaseItem"]);
                        }
                         if (DBNull.Value.Equals(sqlDataReader["IsFixedAssetItem"]) == false)
                        {
                            item.IsFixedAssetItem = Convert.ToBoolean(sqlDataReader["IsFixedAssetItem"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RetailSale"]) == false)
                        {
                            item.RetailSale = Convert.ToBoolean(sqlDataReader["RetailSale"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BOM"]) == false)
                        {
                            item.BOM = Convert.ToBoolean(sqlDataReader["BOM"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsRestaurant"]) == false)
                        {
                            item.Restaurant = Convert.ToBoolean(sqlDataReader["IsRestaurant"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsMultipleVendor"]) == false)
                        {
                            item.IsMultipleVendor = Convert.ToBoolean(sqlDataReader["IsMultipleVendor"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEComItem"]) == false)
                        {
                            item.IsEComItem = Convert.ToBoolean(sqlDataReader["IsEComItem"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsServiceItem"]) == false)
                        {
                            item.IsServiceItem = Convert.ToBoolean(sqlDataReader["IsServiceItem"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsConsumable"]) == false)
                        {
                            item.IsConsumable = Convert.ToBoolean(sqlDataReader["IsConsumable"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsMachine"]) == false)
                        {
                            item.IsMachine = Convert.ToBoolean(sqlDataReader["IsMachine"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsToner"]) == false)
                        {
                            item.IsToner = Convert.ToBoolean(sqlDataReader["IsToner"]);
                        }
                        item.UoMGroupCode = sqlDataReader["UoMGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UoMGroupCode"]);
                        item.ItemType = sqlDataReader["ItemType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ItemType"]);
                        //item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        //item.UomCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.Temprature = sqlDataReader["Temprature"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Temprature"]);
                        //item.TempratureUpto = sqlDataReader["TempratureUpto"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TempratureUpto"]);
                        item.GeneralItemGeneralDataID = sqlDataReader["GeneralItemGeneralDataID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemGeneralDataID"]);


                        //data from GeneralItemSuppliermaster 
                        //item.GeneralItemSupliersDataID = sqlDataReader["GeneralItemSupliersDataID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemSupliersDataID"]);
                        //item.ManufacturCatalogNumber = sqlDataReader["ManufacturCatalogNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ManufacturCatalogNumber"]);
                        item.GenTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterId"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GenTaxGroupMasterId"]);
                        item.VendorName = sqlDataReader["Vender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
                        item.GeneralVendorID = sqlDataReader["GeneralVendorID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralVendorID"]);
                        //item.PurchaseUoMCode = sqlDataReader["PurchaseUoMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseUoMCode"]);
                        //item.GeneralPurchaseGroupMasterID = sqlDataReader["GeneralPurchaseGroupMasterID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["GeneralPurchaseGroupMasterID"]);
                        //item.PackageType = sqlDataReader["PackageType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PackageType"]);

                        //data from GeneralItemGeneralData
                        // item.ManufacturerID = sqlDataReader["ManufacturerID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ManufacturerID"]);
                        //item.ShippingTypeId = sqlDataReader["ShippingTypeId"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ShippingTypeId"]);
                        item.SerialAndBatchManagedBy = sqlDataReader["SerialAndBatchManagedBy"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SerialAndBatchManagedBy"]);
                        item.ManagementMethod = sqlDataReader["ManagementMethod"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ManagementMethod"]);

                        item.NetContentPerPiece = sqlDataReader["NetContentPerPiece"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetContentPerPiece"]);
                        item.NetWeightPerPiece = sqlDataReader["NetWeightPerPiece"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetWeightPerPiece"]);

                        item.NetContentUOM = sqlDataReader["NetContentUOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["NetContentUOM"]);
                        item.SpecialFeature = sqlDataReader["SpecialFeature"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SpecialFeature"]);
                        item.ShortDescription = sqlDataReader["ShortDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ShortDescription"]);
                        item.ArabicTransalation = sqlDataReader["ArabicTransalation"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ArabicTransalation"]);
                        item.BrandName = sqlDataReader["BrandName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BrandName"]);
                        // item.IssueMethod = sqlDataReader["IssueMethod"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["IssueMethod"]);

                        //data from GeneralItemSalesData
                        //item.SaleUoMCode = sqlDataReader["SaleUoMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleUoMCode"]);
                        //item.ItemPerSaleUnit = sqlDataReader["ItemPerSaleUnit"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ItemPerSaleUnit"]);
                        //item.PackingUnitSale = sqlDataReader["PackingUnitSale"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PackingUnitSale"]);
                        //item.QuantityPerPackingUnitSale = sqlDataReader["QuantityPerPackingUnitSale"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["QuantityPerPackingUnitSale"]);

                        // data from GeneralItemStockData
                        //item.GLAccountBy = sqlDataReader["GLAccountBy"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["GLAccountBy"]);
                        //item.StockUoMCode = sqlDataReader["StockUoMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StockUoMCode"]);
                        //item.ValuationMethod = sqlDataReader["ValuationMethod"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ValuationMethod"]);
                        item.HSNCode = sqlDataReader["HSNCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSNCode"]);
                        //item.MinStock = sqlDataReader["MinStock"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MinStock"]);
                        //item.MaxStock = sqlDataReader["MaxStock"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MaxStock"]);



                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        /// <summary>
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemMasterByID(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _item = new GeneralItemMaster();
                        ////_item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        //_item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        //_item.GeneralUnitTypeID = sqlDataReader["GeneralUnitTypeID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralUnitTypeID"].ToString());
                        //_item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        //_item.DepartmentID = sqlDataReader["DepartmentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        //_item.LocationAddress = sqlDataReader["LocationAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationAddress"]);
                        //_item.CityId = sqlDataReader["CityId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CityId"]);
                        //_item.UnitType = sqlDataReader["UnitType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitType"]);
                        //_item.Relatedwith = sqlDataReader["RelatedWith"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["RelatedWith"]);
                        //if (_item.Relatedwith == 1)
                        //{
                        //    _item.RelatedwithUnitType = "Manufacturing";
                        //}
                        //else if (_item.Relatedwith == 2)
                        //{
                        //    _item.RelatedwithUnitType = "Sales";
                        //}
                        //else if (_item.Relatedwith == 3)
                        //{
                        //    _item.RelatedwithUnitType = "Purchase";
                        //}
                        //else if (_item.Relatedwith == 4)
                        //{
                        //    _item.RelatedwithUnitType = "Warehouse";
                        //}
                        //else if (_item.Relatedwith == 5)
                        //{
                        //    _item.RelatedwithUnitType = "Processing";
                        //}
                        //_item.CentreName = sqlDataReader["CentreName"].ToString();
                        //_item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        //_item.CityName = sqlDataReader["CityName"].ToString();
                        //response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
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
            return response;
        }
        /// <summary>
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemMaster(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;

                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_Insert";

                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //************************GeneralItemmaster************************//
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemMasterID", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralItemMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemDescription", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemDescription));
                    if (item.ItemCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.ItemCategoryCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCategoryCode", SqlDbType.NVarChar, 20, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, item.ItemCategoryCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCategoryCode", SqlDbType.NVarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.TaskCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTaskcode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TaskCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTaskcode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@siGenTaxGroupMasterId", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GenTaxGroupMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsFixedAssetItem", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsFixedAssetItem));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bBom", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BOM));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bRetailSale", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RetailSale));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bRestaurant", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Restaurant));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsMultipleVendor", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsMultipleVendor));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsEComItem", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsEComItem));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsServiceItem", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsServiceItem));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsConsumable", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsConsumable));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsMachine", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsMachine));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsToner", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsToner));


                    //************************GeneralItemGeneralData************************//
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemGeneralDataID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralItemGeneralDataID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fTemprature", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Temprature));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@fTempratureUpto", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TempratureUpto));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiSerialAndBatchManagedBy", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SerialAndBatchManagedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fNetContentPerPiece", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.NetContentPerPiece));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fNetWeightPerPiece", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.NetWeightPerPiece));

                    if (item.NetContentUOM != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNetContentUOM", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.NetContentUOM));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNetContentUOM", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.ShortDescription != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsShortDescription", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ShortDescription));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsShortDescription", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.ArabicTransalation != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsArabicTranslation", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ArabicTransalation));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsArabicTranslation", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.SpecialFeature != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSpecialFeature", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SpecialFeature));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSpecialFeature", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BrandName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBrandname", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BrandName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBrandname", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    //************************GeneralItemSupplierData************************//
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemSupliersDataID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralItemSupliersDataID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralVendorID", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralVendorID));
                    if (item.ManufacturCatalogNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsManufacturCatalogNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ManufacturCatalogNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsManufacturCatalogNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PurchaseUoMCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseUoMCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PurchaseUoMCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseUoMCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGeneralPurchaseGroupMasterID", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralPurchaseGroupMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fLastPurchasePrice", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastPurchasePrice));
                    if (item.PurchaseOrganization != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPuchaseOrganisation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PurchaseOrganization));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPuchaseOrganisation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@fMinOrderQuantity", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MinimumOrderquantity));
                    if (item.ShelfLife != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsShelfExpiryLife", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ShelfLife));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsShelfExpiryLife", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CountryOfOrigin != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siCountryOfOrigin", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CountryOfOrigin));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siCountryOfOrigin", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.HSCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsHSCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.HSCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsHSCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@fPrice", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastPurchasePrice));
                    if (item.LeadTime != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiLeadTime", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LeadTime));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiLeadTime", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0));
                    }


                    if (item.leadTimeUom != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLeadTimeUom", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLeadTimeUom", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CurrencyCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sCurrencyCodeForPurchase", SqlDbType.VarChar, 3, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CurrencyCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sCurrencyCodeForPurchase", SqlDbType.VarChar, 3, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ManufacturerName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsManufacturerName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ManufacturerName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsManufacturerName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.RemainingShelfLife != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemainingShelfLife", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RemainingShelfLife));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemainingShelfLife", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorNumber", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.VendorNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDefaultVendor", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsDefaultVendor));
                    //************************GeneralItemCode * ***********************//
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemCodeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralItemCodeID));

                    if (item.XMLstring != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xGeneralItemMasterUoMDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xGeneralItemMasterUoMDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }


                    //************************GeneralItemSaleData************************//
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemSaleDataID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralItemSalesDataID));
                    if (item.XMLstringForSaleUomcode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xGeneralItemMasterSaleDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForSaleUomcode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xGeneralItemMasterSaleDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }


                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));



                    //************************GeneralItemStoreData************************//

                    if (item.GeneralItemStoreSpecificDetailsXml != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xGeneralItemStoreSpecificDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralItemStoreSpecificDetailsXml));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xGeneralItemStoreSpecificDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryItemStoreSpecificInfoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.InventoryItemStoreSpecificInfoID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryItemCodeCentreLevelSpecificInfoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.InventoryItemCodeCentreLevelSpecificInfoID));

                    //************************GeneralItemAttributeData************************//

                    if (item.XMLstringForAttribute != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xGeneralItemMasterAttributeDataXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForAttribute));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xGeneralItemMasterAttributeDataXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemAttributeDataID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralItemAttributeDataID));

                    //************************GeneralItemRestaurantData************************//

                    cmdToExecute.Parameters.Add(new SqlParameter("@siInventoryRecipeMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InventoryRecipeMasterID));

                    if (item.InventoryRecipeMasterTitle != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InventoryRecipeMasterTitle));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Description != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDescription", SqlDbType.NVarChar, 250, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Description));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDescription", SqlDbType.NVarChar, 250, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.ArabicTransalationForMainMenu != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsArabicTranslationForMainMenu", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ArabicTransalationForMainMenu));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsArabicTranslationForMainMenu", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iPrimaryItemOutputId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralItemMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsVersionCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, "V1"));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOldRecipeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));

                    if (item.DefineVariants != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDefinevariants", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DefineVariants));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDefinevariants", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BOMRelevant != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIsBOMrelevant", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BOMRelevant));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIsBOMrelevant", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.XMLstringForRestuarent != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xInventoryVariationMasterDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForRestuarent));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xInventoryVariationMasterDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BillingItemName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBillingItemName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BillingItemName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBillingItemName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@mPriceForRecipe", SqlDbType.Decimal, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PriceForRecipe));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siInventoryRecipeMenuMasterID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InventoryRecipeMenuMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMenuCategoryID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RecipeMenuCategoryID));
                    if (item.IsRelatedWithCafe != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiIsRelatedWithCafe", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsRelatedWithCafe));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiIsRelatedWithCafe", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0));
                    }
                    if (item.CroppedImagePath != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRecipeMenuImage", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CroppedImagePath));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRecipeMenuImage", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.DisplayName != null)
                     {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEComDisplayName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.DisplayName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEComDisplayName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    //************************GeneralItemEcommerceData************************//
                    if (item.XMLstringForMultipleImageUpload != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xEComMultipleImageUploadXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForMultipleImageUpload));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xEComMultipleImageUploadXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.HSNCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsHSNCode", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.HSNCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsHSNCode", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iGeneralItemMasterID"].Value;

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ItemNumber = (Int32)cmdToExecute.Parameters["@iItemNumber"].Value;
                    item.ID = Convert.ToInt32(cmdToExecute.Parameters["@iGeneralItemMasterID"].Value);
                    item.GeneralVendorID = Convert.ToInt32(cmdToExecute.Parameters["@iGeneralVendorID"].Value);
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_GeneralItemMaster_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != 18 && _errorCode != 19)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_Insert' reported the ErrorCode: " +
                                            _errorCode);
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
            return response;
        }
        /// <summary>
        /// Update a specific record of GeneralItemMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMaster> UpdateGeneralItemMaster(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_ActiveVarient";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryVariationMasterID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    // item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_GeneralItemMaster_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
            return response;
        }
        /// <summary>
        /// Delete a specific record of GeneralItemMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemMaster(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.errorMessage));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.errorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry && _errorCode != 77)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_Delete' reported the ErrorCode: " + _errorCode);
                    }

                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
            return response;
        }


        public IBaseEntityCollectionResponse<GeneralItemMaster> SearchListForGeneralPackingTypeInfo(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_SearchListforGeneralPackingTypeInfo";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();
                        item.GeneralItemCodeID = Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.ItemNumber = Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemSupliersDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetGeneralItemSupliersDataByItemNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
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
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _item = new GeneralItemMaster();
                        ////_item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        _item.GeneralItemSupliersDataID = sqlDataReader["GeneralItemSupliersDataID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemSupliersDataID"]);
                        _item.ManufacturCatalogNumber = sqlDataReader["ManufacturCatalogNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ManufacturCatalogNumber"]);
                        _item.GenTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GenTaxGroupMasterID"]);
                        _item.GeneralVendorID = sqlDataReader["GeneralVendorID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralVendorID"]);
                        _item.VendorName = sqlDataReader["Vender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
                        _item.PurchaseUoMCode = sqlDataReader["PurchaseUoMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseUoMCode"]);
                        _item.GeneralPurchaseGroupMasterID = sqlDataReader["GeneralPurchaseGroupMasterID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["GeneralPurchaseGroupMasterID"]);
                        _item.PackageType = sqlDataReader["PackageType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PackageType"]);
                        _item.PurchaseOrganization = sqlDataReader["PuchaseOrganisation"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PuchaseOrganisation"]);
                        _item.MinimumOrderquantity = sqlDataReader["MinOrderQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["MinOrderQuantity"]);
                        _item.CountryOfOrigin = sqlDataReader["CountryOfOrigin"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CountryOfOrigin"]);
                        _item.LeadTime = sqlDataReader["LeadTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LeadTime"]);
                        _item.HSCode = sqlDataReader["HSCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSCode"]);
                        _item.ShelfLife = sqlDataReader["ShelfExpiryLife"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ShelfExpiryLife"]);
                        _item.LastPurchasePrice = Math.Round(sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDouble(sqlDataReader["Price"]),2);
                        _item.CurrencyCode = sqlDataReader["CurrencyCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CurrencyCode"]);

                        _item.ManufacturerName = sqlDataReader["ManufacturerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ManufacturerName"]);
                        //_item.ShelfLife = sqlDataReader["ShelfExpiryLife"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ShelfExpiryLife"]);
                        _item.VendorNumber = sqlDataReader["VendorNumber"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["VendorNumber"]);
                        _item.RemainingShelfLife = sqlDataReader["RemainingShelfLife"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RemainingShelfLife"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                   


                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
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
            return response;
        }


        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemSalesDataByItemNumber(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetGeneralItemSalesDataByItemNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml,0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreListXML));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralunitsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();



                        item.InventoryItemCodeUnitLevelSpecificInfoID = sqlDataReader["InventoryItemCodeUnitLevelSpecificInfoID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["InventoryItemCodeUnitLevelSpecificInfoID"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralItemCodeId"]);
                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["GeneralUnitsID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.LastPurchasePrice = Math.Round(sqlDataReader["Price"] is DBNull ? new double() : Convert.ToDouble(sqlDataReader["Price"]),2);
                        if (DBNull.Value.Equals(sqlDataReader["IsBaseUom"]) == false)
                        {
                            item.IsBaseUom = Convert.ToBoolean(sqlDataReader["IsBaseUom"]);
                        }
                        item.UomCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.LowerLevelUomCode = sqlDataReader["LowerLevelUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LowerLevelUomCode"]);
                        item.ConvertionFactor = sqlDataReader["ConversionFactor"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConversionFactor"]);

                        item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        item.CentreCode = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemGeneralDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetGeneralItemGeneralDataByItemNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
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
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _item = new GeneralItemMaster();
                        _item.GeneralItemGeneralDataID = sqlDataReader["GeneralItemGeneralDataID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemGeneralDataID"]);
                        _item.ManufacturerID = sqlDataReader["ManufacturerID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ManufacturerID"]);
                        _item.ShippingTypeId = sqlDataReader["ShippingTypeId"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ShippingTypeId"]);
                        _item.SerialAndBatchManagedBy = sqlDataReader["SerialAndBatchManagedBy"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SerialAndBatchManagedBy"]);
                        _item.ManagementMethod = sqlDataReader["ManagementMethod"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ManagementMethod"]);
                        _item.IssueMethod = sqlDataReader["IssueMethod"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["IssueMethod"]);
                        _item.Temprature = sqlDataReader["Temprature"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Temprature"]);
                        //_item.TempratureUpto = sqlDataReader["TempratureUpto"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TempratureUpto"]);
                        _item.ItemCategoryCode = sqlDataReader["ItemCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                        _item.GenTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GenTaxGroupMasterID"]);
                        _item.NetContentPerPiece = sqlDataReader["NetContentPerPiece"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetContentPerPiece"]);
                        _item.NetWeightPerPiece = sqlDataReader["NetWeightPerPiece"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetWeightPerPiece"]);
                        _item.NetContentUOM = sqlDataReader["NetContentUOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["NetContentUOM"]);
                        _item.SpecialFeature = sqlDataReader["SpecialFeature"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SpecialFeature"]);
                        _item.ShortDescription = sqlDataReader["ShortDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ShortDescription"]);
                        _item.ArabicTransalation = sqlDataReader["ArabicTransalation"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ArabicTransalation"]);
                        _item.BrandName = sqlDataReader["BrandName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BrandName"]);
                        _item.HSNCode = sqlDataReader["HSNCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSNCode"]);
                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
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
            return response;
        }

        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemServiceDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetGeneralItemServiceDataByItemNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
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
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _item = new GeneralItemMaster();
                        _item.HSNCode = sqlDataReader["HSNCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSNCode"]);
                        _item.GenTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GenTaxGroupMasterID"]);
                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
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
            return response;
        }
        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemStockDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetGeneralItemStockDataByItemNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
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
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _item = new GeneralItemMaster();
                        _item.GeneralItemStockDataID = sqlDataReader["GeneralItemStockDataID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemStockDataID"]);
                        _item.GLAccountBy = sqlDataReader["GLAccountBy"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["GLAccountBy"]);
                        _item.StockUoMCode = sqlDataReader["StockUoMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StockUoMCode"]);
                        _item.ValuationMethod = sqlDataReader["ValuationMethod"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ValuationMethod"]);
                        _item.UoMCode = sqlDataReader["GeneralItemCodeUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GeneralItemCodeUomCode"]);
                        _item.MinStock = sqlDataReader["MinStock"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MinStock"]);
                        _item.MaxStock = sqlDataReader["MaxStock"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MaxStock"]);


                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
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
            return response;
        }


        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemDetailsForSupliersDataSearchList(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_SearchListforSupliersData";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();


                        item.BarCode = Convert.ToString(sqlDataReader["BarCode"]);
                        item.UomCode = Convert.ToString(sqlDataReader["UomCode"]);
                        item.PurchaseUoMCode = Convert.ToString(sqlDataReader["PurchaseUoMCode"]);
                        item.LastPurchasePrice =Math.Round(Convert.ToDouble(sqlDataReader["LastPurchasePrice"]),2);
                        item.GenTaxGroupMasterID = Convert.ToInt16(sqlDataReader["GenTaxGroupMasterID"]);
                        item.ItemNumber = Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.GeneralItemCodeID = Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.GeneralItemMasterID = Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        item.OrderUomCode = Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.BaseUOMQuantity = Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.BaseUOMCode = Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.TaxRate = Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.GeneralPurchaseGroupMasterID = Convert.ToByte(sqlDataReader["GeneralPurchaseGroupMasterID"]);
                        item.PurchaseGroupCode = Convert.ToString(sqlDataReader["PurchaseGroupCode"]);
                        item.MinimumOrderquantity = Convert.ToDecimal(sqlDataReader["MinOrderQuantity"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetUomDetailsForGeneralItemMaster(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemmaster_GetDataForUoMDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));


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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();


                        //_item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemcodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemcodeID"]);
                        item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.LastPurchasePrice =Math.Round(Convert.ToDouble(sqlDataReader["Price"]),2);
                        if (DBNull.Value.Equals(sqlDataReader["IsBaseUom"]) == false)
                        {
                            item.IsBaseUom = Convert.ToBoolean(sqlDataReader["IsBaseUom"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsOrderingUnit"]) == false)
                        {
                            item.IsOrderingUnit = Convert.ToBoolean(sqlDataReader["IsOrderingUnit"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsIssueUnit"]) == false)
                        {
                            item.IsIssueUnit = Convert.ToBoolean(sqlDataReader["IsIssueUnit"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsSaleUnit"]) == false)
                        {
                            item.IsSaleUnit = Convert.ToBoolean(sqlDataReader["IsSaleUnit"]);
                        }
                        item.UomCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.LowerLevelUomCode = sqlDataReader["LowerLevelUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LowerLevelUomCode"]);
                        item.BaseQty = sqlDataReader["ConversionFactor"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ConversionFactor"]);
                        item.Length = sqlDataReader["Length"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Length"]);
                        item.WidthOfItem = sqlDataReader["Width"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Width"]);
                        item.HeightOfItem = sqlDataReader["Height"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Height"]);
                        item.Volume = sqlDataReader["Volume"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Volume"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        //***************************************************************

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetBarcodesBySearch(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemCode_Barcode_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();

                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralItemCodeID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new int() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.UomCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsDefault"]) == false)
                        {

                            item.IsDefault = Convert.ToBoolean(sqlDataReader["IsDefault"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                        baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemCode_Barcode_SelectAll' reported the ErrorCode: " + _errorCode);
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



        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemBarcodes(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemCode_InsertBarCode";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemCodeID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.GeneralItemCodeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.GeneralItemMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemDescription", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ItemDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsGroupCode", SqlDbType.NVarChar, 30,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.UoMGroupCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sBaseBarCode", SqlDbType.VarChar, 11,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.BarCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBaseUoMcode", SqlDbType.NVarChar, 20,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.UomCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mPrice", SqlDbType.Money, 20,
                                         ParameterDirection.Input, false, 10, 0, "",
                                         DataRowVersion.Proposed, item.LastPurchasePrice));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDefault", SqlDbType.Bit, 1,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.IsDefault));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsBaseUom", SqlDbType.Bit, 1,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsBaseUom));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUomCode", SqlDbType.NVarChar, 20,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.UomCode));


                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iGeneralPriceGroupID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_GeneralPriceGroup_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemCode_InsertBarCode' reported the ErrorCode: " +
                                            _errorCode);
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
            return response;
        }

        public IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemBarcodes(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemCode_DeleteBarCode";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.GeneralItemCodeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemCode_DeleteBarCode' reported the ErrorCode: " + _errorCode);
                    }

                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
            return response;
        }

        public IBaseEntityResponse<GeneralItemMaster> InsertInventoryStoreSpecificInformation(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_InventoryItemStoreLevelSpecificInfo";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryItemStoreLevelSpecificInfoID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.InventoryItemCodeCentreLevelSpecificInfoID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.GeneralItemMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiRPType", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.RPType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fQuantity", SqlDbType.Float, 5, ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.MaxStock));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fRoundingProfile", SqlDbType.Float, 5,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.RoundingProfile));
                    if (item.PlannerCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPlannerCode", SqlDbType.NVarChar, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PlannerCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPlannerCode", SqlDbType.NVarChar, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iOrderingDay", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "",
                                         DataRowVersion.Proposed, item.OrderingDay));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fLeadTime", SqlDbType.Float, 5, ParameterDirection.Input, false, 10, 0, "",
                                         DataRowVersion.Proposed, item.LeadTimeForStore));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeliveryDay", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "",
                                         DataRowVersion.Proposed, item.DeliveryDay));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSupplySource", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "",
                                         DataRowVersion.Proposed, item.SupplySource));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bBlockforProcurutment", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, item.BlockforProcurutment));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fGRProccessingTime", SqlDbType.Float, 5, ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, item.GRProccessingTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiReorderPoint", SqlDbType.TinyInt, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ReorderPoint));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiSafetyStockDriven", SqlDbType.TinyInt, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SafetyStockDriven));

                    if (item.ShelfNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsShelfNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ShelfNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsShelfNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@ifacing", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "",
                                         DataRowVersion.Proposed, item.Facing));


                    //if (item.ReorderPoint != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiReorderPoint", SqlDbType.TinyInt, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ReorderPoint));
                    //}
                    //else
                    //{ 
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiReorderPoint", SqlDbType.TinyInt, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0));
                    //}
                    //if (item.SafetyStockDriven != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiSafetyStockDriven", SqlDbType.TinyInt, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SafetyStockDriven));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiSafetyStockDriven", SqlDbType.TinyInt, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0));
                    //}
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iGeneralPriceGroupID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_GeneralPriceGroup_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemCode_InsertBarCode' reported the ErrorCode: " +
                                            _errorCode);
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
            return response;
        }

        public IBaseEntityResponse<GeneralItemMaster> SelectOneInventoryStoreSpecificInformation(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_StoreSpecificInfoSelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralItemMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralVendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCategoryCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemCategoryCode_Param));
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
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _item = new GeneralItemMaster();

                        _item.InventoryItemCodeCentreLevelSpecificInfoID = sqlDataReader["InventoryItemStoreLevelSpecificInfoID"] is DBNull ? new Int32() : Convert.ToInt16(sqlDataReader["InventoryItemStoreLevelSpecificInfoID"]);
                        _item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? new Int32() : Convert.ToInt16(sqlDataReader["GeneralItemMasterID"]);
                        _item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["GeneralUnitsID"]);
                        _item.RPType = sqlDataReader["RPType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["RPType"].ToString());
                        _item.MaxStock = sqlDataReader["Quantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        _item.RoundingProfile = sqlDataReader["RoundingProfile"] is DBNull ? new double() : Convert.ToDouble(sqlDataReader["RoundingProfile"]);
                        _item.ReorderPoint = sqlDataReader["ReorderPoint"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ReorderPoint"].ToString());
                        _item.SafetyStockDriven = sqlDataReader["SafetyStockDriven"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SafetyStockDriven"].ToString());
                        _item.PlannerCode = sqlDataReader["PlannerCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlannerCode"]);
                        _item.OrderingDay = sqlDataReader["OrderingDay"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["OrderingDay"]);
                        _item.LeadTimeForStore = sqlDataReader["LeadTime"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["LeadTime"]);
                        _item.leadTimeUom = sqlDataReader["leadTimeUom"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["leadTimeUom"]);

                        _item.DeliveryDay = sqlDataReader["DeliveryDay"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["DeliveryDay"].ToString());
                        _item.Facing = sqlDataReader["Facing"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["Facing"].ToString());
                        _item.ShelfNumber = sqlDataReader["ShelfNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ShelfNumber"]);

                        _item.SupplySource = sqlDataReader["SupplySource"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["BlockforProcurutment"]) == false)
                        {

                            _item.BlockforProcurutment = Convert.ToBoolean(sqlDataReader["BlockforProcurutment"]);
                        }
                        _item.GRProccessingTime = sqlDataReader["GRProccessingTime"] is DBNull ? new double() : Convert.ToDouble(sqlDataReader["GRProccessingTime"]);
                        _item.GRPUomCode = sqlDataReader["GRPUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GRPUomCode"]);
                       
                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select  Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
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
            return response;
        }


        public IBaseEntityResponse<GeneralItemMaster> CheckFocusOnAction(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_CheckFocusOnAction";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBarCode", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BarCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bExists", SqlDbType.Bit, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.IsExists));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode)); if (_mainConnectionIsCreatedLocal)
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
                    sqlDataReader.Close();
                    GeneralItemMaster _item = new GeneralItemMaster();
                    response.Entity = item;
                    if (cmdToExecute.Parameters["@bExists"].Value != DBNull.Value)
                    {
                        item.IsExists = Convert.ToBoolean(cmdToExecute.Parameters["@bExists"].Value);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
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
            return response;
        }



        public IBaseEntityResponse<GeneralItemMaster> GetRestaurantDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetRestaurantDataByItemNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralItemMasterID));
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
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _item = new GeneralItemMaster();
                        _item.InventoryRecipeMasterID = sqlDataReader["InventoryRecipeMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["InventoryRecipeMasterID"]);
                        _item.InventoryRecipeMasterTitle = sqlDataReader["Title"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Title"]);
                        _item.Description = sqlDataReader["Description"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Description"]);
                        _item.ArabicTransalationForMainMenu = sqlDataReader["ArabicTransalation"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ArabicTransalation"]);
                        _item.BOMRelevant = sqlDataReader["BOMRelevant"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BOMRelevant"]);
                        _item.DefineVariants = sqlDataReader["DefineVariants"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DefineVariants"]);
                        _item.BillingItemName = sqlDataReader["BillingItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BillingItemName"]);
                        _item.PriceForRecipe = sqlDataReader["Price"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Price"]);
                        _item.RecipeMenuCategoryID = sqlDataReader["MenuCategoryID"] is DBNull ? new int() : Convert.ToInt16(sqlDataReader["MenuCategoryID"]);
                        _item.InventoryRecipeMenuMasterID = sqlDataReader["InventoryRecipeMenuMasterID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["InventoryRecipeMenuMasterID"]);
                        _item.IsRelatedWithCafe = sqlDataReader["RelatedWithCafe"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["RelatedWithCafe"]);
                        _item.CroppedImagePath = sqlDataReader["RecipeMenuImage"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RecipeMenuImage"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
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
            return response;
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetVariantDetailsForGeneralItemMasters(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemmaster_GetVarientsDetailsByItemNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();

                        item.InventoryRecipeMasterID = sqlDataReader["InventoryRecipeMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["InventoryRecipeMasterID"]);
                        item.RecipeVariationTitle = sqlDataReader["RecipeVariationTitle"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RecipeVariationTitle"]);
                        item.Description = sqlDataReader["Description"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Description"]);
                        item.VersionCode = sqlDataReader["VersionCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VersionCode"]);
                        item.RecipeVariationDescription = sqlDataReader["RecipeVariationDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RecipeVariationDescription"]);
                        item.InventoryVariationMasterID = sqlDataReader["InventoryVariationMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["InventoryVariationMasterID"]);
                        item.PrimaryItemOutputId = sqlDataReader["PrimaryItemOutputId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["PrimaryItemOutputId"]);
                        item.PriceForVariation = sqlDataReader["Price"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Price"]);
                        item.BillingItemName = sqlDataReader["BillingItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BillingItemName"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
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
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemStoreData(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetGeneralItemStoreData";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreListXML));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _item = new GeneralItemMaster();
                        _item.InventoryItemStoreSpecificInfoID = sqlDataReader["InventoryItemStoreSpecificInfoID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["InventoryItemStoreSpecificInfoID"]);
                        _item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralUnitsID"]);
                        _item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        _item.ListingDate = sqlDataReader["ItemDisplayFromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDisplayFromDate"]);
                        _item.DeListingDate = sqlDataReader["itemDisplayUpto"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["itemDisplayUpto"]);
                        _item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        _item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);

                        if (DBNull.Value.Equals(sqlDataReader["StatusFlag"]) == false)
                        {
                            _item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(_item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralitemMasterExcel(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMasterExcelUpload_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemCodeID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Input, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.GeneralItemCodeID));
                    if (item.XMLstring != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xItemmasterGeneralAndPurchaseInformationXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xItemmasterGeneralAndPurchaseInformationXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.UomDetailsParameterXML1 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xUomMaster1XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UomDetailsParameterXML1));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xUomMaster1XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.UomDetailsParameterXML2 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xUomMaster2XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UomDetailsParameterXML2));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xUomMaster2XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UomDetailsParameterXML3 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xUomMaster3XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UomDetailsParameterXML3));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xUomMaster3XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UomDetailsParameterXML4 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xUomMaster4XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UomDetailsParameterXML4));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xUomMaster4XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sErrorMessage", SqlDbType.NVarChar, 50, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.errorMessage));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.errorMessage = (string)cmdToExecute.Parameters["@sErrorMessage"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry && _errorCode != 18 && _errorCode != 19 && _errorCode != 77)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMasterExcelUpload_InsertXML' reported the ErrorCode: " + _errorCode);
                    }

                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _errorCode = 18;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
                //_logException.Error(ex.Message);
                
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _errorCode = 18;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
                //_logException.Error(ex.Message);
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
            return response;
        }

        public IBaseEntityResponse<GeneralItemMaster> GetDataValidationListsForExcel(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_ItemMaster_GetDataValidationListsForExcel";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;                   

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
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
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _item = new GeneralItemMaster();
                        _item.CountryList = sqlDataReader["CountryList"].ToString();
                        _item.TemperatureList = sqlDataReader["TemperatureList"].ToString();
                        _item.CurrencyList = sqlDataReader["CurrencyList"].ToString();
                        _item.UnitList = sqlDataReader["UnitList"].ToString();
                        _item.TaxGroupList = sqlDataReader["TaxList"].ToString();
                        _item.VendorNumberList = sqlDataReader["VendorNumberList"].ToString();
                        _item.PurchaseGrouplist = sqlDataReader["PurchaseGrouplist"].ToString();
                        _item.CategoryCodeList = sqlDataReader["CategoryCodeList"].ToString();

                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemCode_InsertBarCode' reported the ErrorCode: " +
                                            _errorCode);
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
            return response;
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemAttributeData(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetGeneralItemAttributeData";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _item = new GeneralItemMaster();
                        _item.InventoryItemStoreSpecificInfoID = sqlDataReader["InventoryItemStoreSpecificInfoID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["InventoryItemStoreSpecificInfoID"]);
                        _item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralUnitsID"]);
                        _item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        _item.ListingDate = sqlDataReader["ItemDisplayFromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDisplayFromDate"]);
                        _item.DeListingDate = sqlDataReader["itemDisplayUpto"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["itemDisplayUpto"]);
                        _item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        if (DBNull.Value.Equals(sqlDataReader["StatusFlag"]) == false)
                        {
                            _item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(_item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemAttributeDataByItemNumber(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetAttributeDataByItemNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
                    
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();


                        item.GeneralItemAttributeDataID = sqlDataReader["GeneralItemAttributeDataID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemAttributeDataID"]);
                        item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.AttributeName = sqlDataReader["AttributeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AttributeName"]);
                        item.InventoryAttributeMasterID = sqlDataReader["InventoryAttributeMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["InventoryAttributeMasterID"]);
                       
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_GetAttributeDataByItemNumber' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetItemSearchListForVarientsMenu(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_SearchListforReatilAndVariationItem";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();
                        item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.BaseUOMCode = sqlDataReader["BaseUoMcode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUoMcode"]);
                        item.MenuDescription = sqlDataReader["MenuDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MenuDescription"]);
                        item.InventoryVariationMasterID = sqlDataReader["VariationMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["VariationMasterID"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterSearchListForReport(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_SearchListforReports";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    if (searchRequest.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                   
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();
                        
                        item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.BaseUOMCode = sqlDataReader["BaseUoMcode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUoMcode"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.UomCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.OrderUomCode = sqlDataReader["OrderUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                     
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<GeneralItemMaster> GetVendorWiseItemSearchListForRequisition(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_VendorSpecificSearchListforSupliersData";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralVendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPurchaseRequisitionType", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseRequisitionType));

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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();

                        
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.UomCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.PurchaseUoMCode = sqlDataReader["PurchaseUoMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseUoMCode"]);
                        item.LastPurchasePrice = sqlDataReader["LastPurchasePrice"] is DBNull ? new double() : Math.Round(Convert.ToDouble(sqlDataReader["LastPurchasePrice"]), 2);
                        item.GenTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GenTaxGroupMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        item.OrderUomCode = sqlDataReader["OrderUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.GeneralPurchaseGroupMasterID = sqlDataReader["GeneralPurchaseGroupMasterID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["GeneralPurchaseGroupMasterID"]);
                        item.PurchaseGroupCode = sqlDataReader["PurchaseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseGroupCode"]);
                        item.MinimumOrderquantity = sqlDataReader["MinOrderQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["MinOrderQuantity"]);
                        item.SerialAndBatchManagedBy = sqlDataReader["SerialAndBatchmanagedBy"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SerialAndBatchmanagedBy"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        
        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemSupplierDataForVendorDetails(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemSupliersData_InsertVendorData";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralItemSupliersDataID", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.GeneralItemSupliersDataID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralVendorID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.GeneralVendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorNumber", SqlDbType.Int, 4,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.VendorNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDefaultVendor", SqlDbType.Bit, 0,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.IsDefaultVendor));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100,
                                               ParameterDirection.Output, true, 10, 0, "",
                                               DataRowVersion.Proposed, item.errorMessage));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.errorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry && _errorCode != 15 && _errorCode != 16)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralCounterMaster_Insert' reported the ErrorCode: " +
                                            _errorCode);
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _errorCode = 18;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
                //_logException.Error(ex.Message);

            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _errorCode = 18;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
                //_logException.Error(ex.Message);
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
            return response;
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetMultipleVendorListItemWise(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_MutipleVendorByItemNumber_GetListForDropDown";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();
                        
                        item.VendorNumber = sqlDataReader["VendorNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["VendorNumber"]);
                        item.GeneralVendorID = sqlDataReader["GeneralVendorID"] is DBNull ? new int (): Convert.ToInt32(sqlDataReader["GeneralVendorID"]);
                        item.VendorName = sqlDataReader["Vender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
                        
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemSupliersDataByItemNumberandVendorID(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetSupliersDataByItemNumberandVendorNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralVendorID));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();

                        item.GeneralItemSupliersDataID = sqlDataReader["GeneralItemSupliersDataID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemSupliersDataID"]);
                        item.ManufacturCatalogNumber = sqlDataReader["ManufacturCatalogNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ManufacturCatalogNumber"]);
                        item.GenTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GenTaxGroupMasterID"]);
                        item.GeneralVendorID = sqlDataReader["GeneralVendorID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralVendorID"]);
                        item.PurchaseUoMCode = sqlDataReader["PurchaseUoMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseUoMCode"]);
                        item.GeneralPurchaseGroupMasterID = sqlDataReader["GeneralPurchaseGroupMasterID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["GeneralPurchaseGroupMasterID"]);
                        item.PackageType = sqlDataReader["PackageType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PackageType"]);
                        item.PurchaseOrganization = sqlDataReader["PuchaseOrganisation"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PuchaseOrganisation"]);
                        item.MinimumOrderquantity = sqlDataReader["MinOrderQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["MinOrderQuantity"]);
                        item.CountryOfOrigin = sqlDataReader["CountryOfOrigin"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CountryOfOrigin"]);
                        item.LeadTime = sqlDataReader["LeadTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LeadTime"]);
                        item.HSCode = sqlDataReader["HSCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSCode"]);
                        item.ShelfLife = sqlDataReader["ShelfExpiryLife"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ShelfExpiryLife"]);
                        item.LastPurchasePrice = Math.Round(sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDouble(sqlDataReader["Price"]), 2);
                        item.CurrencyCode = sqlDataReader["CurrencyCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CurrencyCode"]);

                        item.ManufacturerName = sqlDataReader["ManufacturerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ManufacturerName"]);
                        item.ShelfLife = sqlDataReader["ShelfExpiryLife"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ShelfExpiryLife"]);
                        item.VendorNumber = sqlDataReader["VendorNumber"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["VendorNumber"]);
                        item.RemainingShelfLife = sqlDataReader["RemainingShelfLife"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RemainingShelfLife"]);
                        item.VendorName = sqlDataReader["VendorName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorName"]);
                        item.IsDefaultVendor = sqlDataReader["IsDefaultVendor"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsDefaultVendor"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemEcommerceDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetECommerceDataByItemNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCategoryCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemCategoryCode_Param));
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
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster _item = new GeneralItemMaster();
                        ////_item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                       
                        _item.ItemCategoryDescription = sqlDataReader["ItemCategoryDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryDescription"]);
                        _item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                        _item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                        _item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                        _item.MerchantiseSubCategoryName = sqlDataReader["MerchantiseSubCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseSubCategoryName"]);
                        _item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                        _item.DisplayName = sqlDataReader["EComDisplayName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EComDisplayName"]);
                        _item.ImageNameString = sqlDataReader["ImageNameString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ImageNameString"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }



                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
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
            return response;
        }

        public IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemMasterEComImages(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> response = new BaseEntityResponse<GeneralItemMaster>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemImages_DeleteEComImage";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemImages_DeleteEComImage' reported the ErrorCode: " + _errorCode);
                    }

                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
            return response;
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralServiceItemList(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_ServiceItemSearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();

                        item.ItemNumber= sqlDataReader["ItemNumber"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemDescription= sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterForSaleUOMBySearchWord(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_SaleItemSearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();

                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetVendorWiseItemSearchListWithCompoundTax(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_VendorSpecificSearchListforSupliersDataWithTax";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralVendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPurchaseRequisitionType", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseRequisitionType));

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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();


                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.UomCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.PurchaseUoMCode = sqlDataReader["PurchaseUoMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseUoMCode"]);
                        item.LastPurchasePrice = sqlDataReader["LastPurchasePrice"] is DBNull ? new double() : Math.Round(Convert.ToDouble(sqlDataReader["LastPurchasePrice"]), 2);
                        item.GenTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GenTaxGroupMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        item.OrderUomCode = sqlDataReader["OrderUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.GeneralPurchaseGroupMasterID = sqlDataReader["GeneralPurchaseGroupMasterID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["GeneralPurchaseGroupMasterID"]);
                        item.PurchaseGroupCode = sqlDataReader["PurchaseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseGroupCode"]);
                        item.MinimumOrderquantity = sqlDataReader["MinOrderQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["MinOrderQuantity"]);
                        item.SerialAndBatchManagedBy = sqlDataReader["SerialAndBatchmanagedBy"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SerialAndBatchmanagedBy"]);
                        item.TaxRateList = sqlDataReader["TaxRateList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxRateList"]);
                        item.TaxList = sqlDataReader["TaxList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxList"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetCCRMPartNoSearchList(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMPartNo_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemMaster item = new GeneralItemMaster();
                        item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                       
                        item.ItemCategoryCode = sqlDataReader["ItemCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        //item.LastCallNo = sqlDataReader["LastCallNo"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["LastCallNo"]);
                        item.lifeInCopies = sqlDataReader["lifeInCopies"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["lifeInCopies"]);
                        //item.LastQuantity = sqlDataReader["LastQuantity"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["LastQuantity"]);
                        //item.LastMtrRead = sqlDataReader["LastMtrRead"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["LastMtrRead"]);
                      
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
