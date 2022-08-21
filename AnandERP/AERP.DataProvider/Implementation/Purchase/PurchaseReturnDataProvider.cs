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
    public class PurchaseReturnDataProvider : DBInteractionBase, IPurchaseReturnDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public PurchaseReturnDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public PurchaseReturnDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from PurchaseReturn table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<PurchaseReturn> GetBySearch(PurchaseReturnSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReturn>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseReturnMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.VendorId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TransactionDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siLocationID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationID));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseReturn>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReturn item = new PurchaseReturn();

                        item.ID = sqlDataReader["PurchaseReturnMasterId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["PurchaseReturnMasterId"]);
                        item.PurchaseReturnNumber = sqlDataReader["PurchaseReturnNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseReturnNumber"]);
                        item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                        item.RoundUpAmount = sqlDataReader["RoundUpAmount"]is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["RoundUpAmount"]);
                        item.PurchaseReturnAmount = sqlDataReader["PurchaseReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchaseReturnAmount"]);
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
                        throw new Exception("Stored Procedure 'USP_GeneralQuestionLevelMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseReturn> GetVendorSearchList(PurchaseReturnSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReturn>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseReturn_SearchListAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.VendorId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.VendorNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siLocationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseGRNMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseGRNMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchFor", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchFor));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseReturn>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReturn item = new PurchaseReturn();
                        if (searchRequest.SearchFor == "Vendor")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["VenderId"]) == false)
                            {
                                item.VendorId = Convert.ToInt32(sqlDataReader["VenderId"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Vender"]) == false)
                            {
                                item.vendor = Convert.ToString(sqlDataReader["Vender"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["VendorNumber"]) == false)
                            {
                                item.VendorNumber = Convert.ToInt32(sqlDataReader["VendorNumber"]);

                            }
                            if (DBNull.Value.Equals(sqlDataReader["CreditAmount"]) == false)
                            {
                                item.CreditAmount = Convert.ToDecimal(sqlDataReader["CreditAmount"]);

                            }
                        }
                        else if (searchRequest.SearchFor == "Item")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["GeneralItemMasterID"]) == false)
                            {
                                item.GeneralItemMasterID = Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                            {
                                item.ItemNumber = Convert.ToString(sqlDataReader["ItemNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                            {
                                item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["SerialAndBatchManagedBy"]) == false)
                            {
                                item.SerialAndBatchManagedBy = Convert.ToByte(sqlDataReader["SerialAndBatchManagedBy"]);
                            }

                        }
                        else if (searchRequest.SearchFor == "PurchaseOrder")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderMasterID"]) == false)
                            {
                                item.PurchaseOrderMasterID = Convert.ToInt32(sqlDataReader["PurchaseOrderMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderNumber"]) == false)
                            {
                                item.PurchaseOrderNumber = Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                            {
                                item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["OrderUomCode"]) == false)
                            {
                                item.OrderUomCode = Convert.ToString(sqlDataReader["OrderUomCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["BaseUOMQuantity"]) == false)
                            {
                                item.BaseUOMQuantity = Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["BaseUOMCode"]) == false)
                            {
                                item.BaseUOMCode = Convert.ToString(sqlDataReader["BaseUOMCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["GeneralItemCodeID"]) == false)
                            {
                                item.GeneralItemCodeID = Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                            }
                            item.TaxRateList = sqlDataReader["TaxRateList"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["TaxRateList"]);
                            item.TaxList = sqlDataReader["TaxList"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["TaxList"]);
                            item.GenTaxGroupMasterId = sqlDataReader["GeneralTaxGroupMasterID"] == DBNull.Value ? new int() : Convert.ToInt32(sqlDataReader["GeneralTaxGroupMasterID"]);

                        }
                        else if (searchRequest.SearchFor == "PurchaseGRN")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["PurchaseGRNMasterID"]) == false)
                            {
                                item.PurchaseGRNMasterID = Convert.ToInt32(sqlDataReader["PurchaseGRNMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["GRNNumber"]) == false)
                            {
                                item.PurchaseGrnNumber = Convert.ToString(sqlDataReader["GRNNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                            {
                                item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["OrderUomCode"]) == false)
                            {
                                item.OrderUomCode = Convert.ToString(sqlDataReader["OrderUomCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["BaseUOMQuantity"]) == false)
                            {
                                item.BaseUOMQuantity = Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["BaseUOMCode"]) == false)
                            {
                                item.BaseUOMCode = Convert.ToString(sqlDataReader["BaseUOMCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ReceivedQuantity"]) == false)
                            {
                                item.ReceivedQuantity = Convert.ToDecimal(sqlDataReader["ReceivedQuantity"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["GenTaxGroupMasterId"]) == false)
                            {
                                item.GenTaxGroupMasterId = Convert.ToInt32(sqlDataReader["GenTaxGroupMasterId"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TaxInPercentage"]) == false)
                            {
                                item.TaxInPercentage = Convert.ToInt32(sqlDataReader["TaxInPercentage"]);
                            }
                        }
                        else if (searchRequest.SearchFor == "Batch")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["BatchID"]) == false)
                            {
                                item.BatchID = Convert.ToInt32(sqlDataReader["BatchID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["BatchNumber"]) == false)
                            {
                                item.BatchNumber = Convert.ToString(sqlDataReader["BatchNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ExpiryDate"]) == false)
                            {
                                item.ExpiryDate = Convert.ToString(sqlDataReader["ExpiryDate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["BatchQuantity"]) == false)
                            {
                                item.BatchQuantity = Convert.ToDecimal(sqlDataReader["BatchQuantity"]);
                            }
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
                        throw new Exception("Stored Procedure 'USP_PurchaseReturn_SearchListAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseReturn> GetPurchaseReturnDetailLists(PurchaseReturnSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReturn>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseReturnMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseReturnMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseReturn>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReturn item = new PurchaseReturn();
                        item.ID = sqlDataReader["PurchaseReturnMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["PurchaseReturnMasterID"]);
                        item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                        item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.RoundUpAmount = sqlDataReader["RoundUpAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["RoundUpAmount"]);
                        item.PurchaseReturnAmount = sqlDataReader["PurchaseReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchaseReturnAmount"]);
                        item.vendor = sqlDataReader["Vendor"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vendor"]);
                        item.BalanceSheetID = sqlDataReader["BalanceSheetID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["BalanceSheetID"]);
                        item.LocationID = sqlDataReader["LocationID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["LocationID"]);
                        item.PurchaseReturnNumber = sqlDataReader["PurchaseReturnNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseReturnNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.PurchaseOrderNumber = sqlDataReader["PurchaseOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        item.PurchaseGrnNumber = sqlDataReader["PurchaseGrnNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseGrnNumber"]);
                        item.BatchNumber = sqlDataReader["BatchNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BatchNumber"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);
                        item.NetAmount = sqlDataReader["NetAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["NetAmount"]);
                        item.TaxAmount = sqlDataReader["TaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxAmount"]);
                        item.IsOtherState = sqlDataReader["IsOtherState"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsOtherState"]);


                        var Amount = (item.Quantity * item.Rate);
                        //item.Ammount = Amount;
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseReturn_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<PurchaseReturn> SelectByID(PurchaseReturn item)
        {
            IBaseEntityResponse<PurchaseReturn> response = new BaseEntityResponse<PurchaseReturn>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseReturnMaster";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseReturnMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        PurchaseReturn _item = new PurchaseReturn();
                        item.ID = sqlDataReader["PurchaseReturnMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["PurchaseReturnMasterID"]);
                        item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                        item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.RoundUpAmount = sqlDataReader["RoundUpAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["RoundUpAmount"]);
                        item.PurchaseReturnAmount = sqlDataReader["PurchaseReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["RoundUpAmount"]);
                        item.vendor = sqlDataReader["Vendor"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vendor"]);
                        item.BalanceSheetID = sqlDataReader["BalanceSheetID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["BalanceSheetID"]);
                        item.LocationID = sqlDataReader["LocationID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["LocationID"]);
                        item.PurchaseReturnNumber = sqlDataReader["PurchaseReturnNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseReturnNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.PurchaseOrderNumber = sqlDataReader["PurchaseOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        item.PurchaseGrnNumber = sqlDataReader["PurchaseGrnNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseGrnNumber"]);
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
        /// <summary>
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseReturn> InsertPurchaseReturn(PurchaseReturn item)
        {
            IBaseEntityResponse<PurchaseReturn> response = new BaseEntityResponse<PurchaseReturn>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseReturnMaster_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.VendorId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siLocationID", SqlDbType.Int, 4,
                                          ParameterDirection.Input, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0,
                                          ParameterDirection.Input, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.TransactionDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Decimal, 10, 
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.TotalTaxAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRoundUpAmount", SqlDbType.Decimal, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.RoundUpAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mPurchaseReturnAmount", SqlDbType.Decimal, 10,
                                          ParameterDirection.Input, false, 0, 0, "",
                                          DataRowVersion.Proposed, item.PurchaseReturnAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPurchaseReturnXML", SqlDbType.Xml, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ParameterXml));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPurchaseReturnVoucherXML", SqlDbType.Xml, 0,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.ParameterVoucherXml));
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
                    //    item.OrgBuildingTypeMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    //}
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamQuestionBankMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of PurchaseReturn
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseReturn> UpdatePurchaseReturn(PurchaseReturn item)
        {
            IBaseEntityResponse<PurchaseReturn> response = new BaseEntityResponse<PurchaseReturn>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.ID));
                    ////cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterName", SqlDbType.NVarChar, 60,
                    ////                    ParameterDirection.Input, false, 10, 0, "",
                    ////                    DataRowVersion.Proposed, item.CounterName));
                    ////cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterCode", SqlDbType.NVarChar,20,
                    ////                    ParameterDirection.Input, false, 0, 0, "",
                    ////                    DataRowVersion.Proposed, item.CounterCode));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                    //                    ParameterDirection.Input, true, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.ModifiedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                    //                        ParameterDirection.Output, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, _errorCode));
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
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamExaminationMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of PurchaseReturn
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseReturn> DeletePurchaseReturn(PurchaseReturn item)
        {
            IBaseEntityResponse<PurchaseReturn> response = new BaseEntityResponse<PurchaseReturn>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationBuildingWings_Delete";
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
                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrganisationBuildingWings_Delete' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<PurchaseReturn> GetUomWisePurchasePrice(PurchaseReturnSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReturn>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseReturn_GetUomWisePurchasePrice";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUoMCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.UnitCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseReturn>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReturn item = new PurchaseReturn();
                        //_item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemcodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemcodeID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemNumber"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.UomPurchasePrice = Math.Round(Convert.ToDouble(sqlDataReader["UomPurchasePrice"]), 2);
                        item.UnitCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.BaseUOMCode = sqlDataReader["LowerLevelUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LowerLevelUomCode"]);
                        item.BaseUOMQuantity = sqlDataReader["ConversionFactor"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ConversionFactor"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySale_SelectBillDetails' reported the ErrorCode: " + _errorCode);
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
