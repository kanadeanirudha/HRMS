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
    public class SalesInvoiceMasterAndDetailsDataProvider : DBInteractionBase, ISalesInvoiceMasterAndDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalesInvoiceMasterAndDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalesInvoiceMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from SalesInvoiceMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetSalesInvoiceMasterAndDetailsBySearch(SalesInvoiceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesInvoiceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesInvoiceMasterAndDetailsMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@tiPurchaseOrderType", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));

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
                    baseEntityCollection.CollectionResponse = new List<SalesInvoiceMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesInvoiceMasterAndDetails item = new SalesInvoiceMasterAndDetails();
                        item.ID = sqlDataReader["SalesInvoiceID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalesInvoiceID"]);
                        item.SalesOrderMasterID = sqlDataReader["SalesOrderMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalesOrderMasterID"]);
                        item.SalesOrderNumber = sqlDataReader["SalesOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderNumber"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.CustomerName = sqlDataReader["Customername"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Customername"]);
                        //item.PurchaseGRNMasterID = sqlDataReader["PurchaseGRNMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseGRNMasterID"]);
                        item.CreatedDate = sqlDataReader["CreatedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        item.DeliveryNumber = sqlDataReader["DeliveryNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryNumber"]);
                        item.CustomerInvoiceNumber = sqlDataReader["CustomerInvoiceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerInvoiceNumber"]);
                        item.SalesQuotationMasterID = sqlDataReader["SalesQuotationMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalesQuotationMasterID"]);
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        item.Isinvoiced = sqlDataReader["Isinvoiced"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["Isinvoiced"]);

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
                        throw new Exception("Stored Procedure 'USP_PurchaseOrderMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalesInvoiceMasterAndDetails> GetSalesInvoiceMasterAndDetailsByID(SalesInvoiceMasterAndDetails item)
        {
            IBaseEntityResponse<SalesInvoiceMasterAndDetails> response = new BaseEntityResponse<SalesInvoiceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesInvoiceMasterAndDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        SalesInvoiceMasterAndDetails _item = new SalesInvoiceMasterAndDetails();
                        //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.PurchaseRequisitionMasterID = Convert.ToInt32(sqlDataReader["PurchaseRequisitionMasterID"]);
                        //_item.PurchaseOrderNumber = sqlDataReader["PurchaseOrderNumber"].ToString();
                        //_item.PurchaseOrderDate = Convert.ToString(sqlDataReader["PurchaseOrderDate"]);
                        //_item.VendorID = Convert.ToInt32(sqlDataReader["VendorID"]);

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
        public IBaseEntityResponse<SalesInvoiceMasterAndDetails> InsertSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item)
        {
            IBaseEntityResponse<SalesInvoiceMasterAndDetails> response = new BaseEntityResponse<SalesInvoiceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesInvoiceMasterAndDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0,
                        ParameterDirection.Output, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesOrderMasterID", SqlDbType.Int, 0,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.SalesOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.CustomerMasterID));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@siStorageLocationID", SqlDbType.SmallInt, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.StorageLocationID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.SmallInt, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFreight", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.Freight));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mShippingHandling", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ShippingHandling));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mDiscount", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.Discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mnetAmount", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.Amount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.TotalTaxAmount));

                    var TotalinvoiceAmount = (item.Amount + item.ShippingHandling + item.Freight + item.TotalTaxAmount);
                    var DiscountAmount = ((TotalinvoiceAmount * item.Discount) / 100);
                    var TotalInvoiceAmount1 = (TotalinvoiceAmount - DiscountAmount);
                    item.TotalIInvoiceAmount = TotalInvoiceAmount1;

                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalInvoiceAmount", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.TotalIInvoiceAmount));
                    if(item.XMLstringForVouchar==null || item.XMLstringForVouchar == "")
                    { 
                    cmdToExecute.Parameters.Add(new SqlParameter("@xSaleInvoiceVoucherXML", SqlDbType.Xml, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSaleInvoiceVoucherXML", SqlDbType.Xml, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.XMLstringForVouchar));
                    }
                    if (item.XMLstring == null || item.XMLstring == "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSaleInvoiceXML", SqlDbType.Xml, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSaleInvoiceXML", SqlDbType.Xml, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.XMLstring));
                    }
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
                   // item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalesInvoiceMasterAndDetails_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of SalesInvoiceMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesInvoiceMasterAndDetails> UpdateSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item)
        {
            IBaseEntityResponse<SalesInvoiceMasterAndDetails> response = new BaseEntityResponse<SalesInvoiceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesInvoiceMasterAndDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseRequisitionMasterID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.PurchaseRequisitionMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumber", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.PurchaseOrderNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daPurchaseOrderDate", SqlDbType.DateTime, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.PurchaseOrderDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.VendorID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.TinyInt, 3,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.PurchaseOrderType));

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
                   // item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalesInvoiceMasterAndDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of SalesInvoiceMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesInvoiceMasterAndDetails> DeleteSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item)
        {
            IBaseEntityResponse<SalesInvoiceMasterAndDetails> response = new BaseEntityResponse<SalesInvoiceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesInvoiceMasterAndDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 0));
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
                   // item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalesInvoiceMasterAndDetails_Delete' reported the ErrorCode: " +
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
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> SelectBySalesOrderMasterID(SalesInvoiceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesInvoiceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesInvoiceMaster_SelectBySalesorderMasterID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalesOrderMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesInvoiceMasterAndDetails>();
                    decimal TotalTaxAmount = 0;
                    while (sqlDataReader.Read())
                    {
                        SalesInvoiceMasterAndDetails item = new SalesInvoiceMasterAndDetails();
                        //  item.ItemID = sqlDataReader["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);

                        item.SalesOrderMasterID = sqlDataReader["SalesOrderMasterID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["SalesOrderMasterID"]);
                        item.SalesOrderNumber = sqlDataReader["SalesOrderNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderNumber"]);
                        item.DeliveryNumber = sqlDataReader["DeliveryNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["DeliveryNumber"]);
                        item.CustomerName = sqlDataReader["CustomerName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        item.Quantity = sqlDataReader["Quantity"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Quantity"]);


                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] == DBNull.Value ? Convert.ToInt32(0) : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);

                        item.SaleUomCode = sqlDataReader["SaleUOMcode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["SaleUOMcode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);

                        item.Freight = sqlDataReader["Freight"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling = sqlDataReader["ShippingHandling"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToInt16(sqlDataReader["ShippingHandling"]);
                        item.Discount = sqlDataReader["Discount"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Discount"]);
                        item.TaxAmount = sqlDataReader["TotalTaxAmount"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.Rate = sqlDataReader["Rate"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);


                        item.LocationName = sqlDataReader["LocationName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.CustomerInvoiceNumber = sqlDataReader["CustomerInvoiceNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["CustomerInvoiceNumber"]);


                        item.BatchNumber = sqlDataReader["BatchNumbers"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BatchNumbers"]);
                        item.ExpiryDate = sqlDataReader["ExpiryDate"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ExpiryDate"]);
                        item.StorageLocationID = sqlDataReader["IssueFromLocationID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["IssueFromLocationID"]);
                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        item.SalesOrderDeliveryMasterID = sqlDataReader["SalesOrderDeliveryMasterID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["SalesOrderDeliveryMasterID"]);
                        item.DMNumber = sqlDataReader["DMNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["DMNumber"]);
                        item.TaxRateList = sqlDataReader["TaxRateList"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["TaxRateList"]);
                        item.TaxList = sqlDataReader["TaxList"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["TaxList"]);
                        item.TaxAmountList = sqlDataReader["TaxAmountList"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["TaxAmountList"]);


                        TotalTaxAmount = TotalTaxAmount + item.TaxAmount;
                        item.TotalTaxAmount = TotalTaxAmount;


                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesInvoiceMasterAndDetails_SelectByPurchaseRequisitionMasterID' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> ViewDetailsBySalesInvoiceMasterID(SalesInvoiceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesInvoiceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesInvoiceMaster_ViewDetailsByInvoiceID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesInvoiceMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesInvoiceMasterAndDetails>();
                    decimal TotalTaxAmount = 0;
                    while (sqlDataReader.Read())
                    {
                        SalesInvoiceMasterAndDetails item = new SalesInvoiceMasterAndDetails();
                        //  item.ItemID = sqlDataReader["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);

                        item.SalesOrderMasterID = sqlDataReader["SalesOrderMasterID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["SalesOrderMasterID"]);
                        item.SalesOrderNumber = sqlDataReader["SalesOrderNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderNumber"]);
                        //item.DeliveryNumber = sqlDataReader["DeliveryNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["DeliveryNumber"]);
                        item.CustomerName = sqlDataReader["CustomerName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        item.Quantity = sqlDataReader["Quantity"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Quantity"]);


                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] == DBNull.Value ? Convert.ToInt32(0) : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);

                        item.SaleUomCode = sqlDataReader["SaleUOMcode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["SaleUOMcode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);

                        item.Freight = sqlDataReader["Freight"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling = sqlDataReader["ShippingHandling"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToInt16(sqlDataReader["ShippingHandling"]);
                        item.Discount = sqlDataReader["Discount"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Discount"]);
                        item.TaxAmount = sqlDataReader["TotalTaxAmount"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.Rate = sqlDataReader["Rate"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);


                        item.LocationName = sqlDataReader["LocationName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.CustomerInvoiceNumber = sqlDataReader["CustomerInvoiceNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["CustomerInvoiceNumber"]);


                        item.BatchNumber = sqlDataReader["BatchNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BatchNumber"]);
                        item.ExpiryDate = sqlDataReader["ExpiryDate"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ExpiryDate"]);
                        item.StorageLocationID = sqlDataReader["IssueFromLocationID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["IssueFromLocationID"]);
                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        item.SalesOrderDeliveryMasterID = sqlDataReader["SalesOrderDeliveryMasterID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["SalesOrderDeliveryMasterID"]);
                        item.DMNumber = sqlDataReader["DMNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["DMNumber"]);
                        item.TaxRateList = sqlDataReader["TaxRateList"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["TaxRateList"]);
                        item.TaxList = sqlDataReader["TaxList"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["TaxList"]);
                        item.TaxAmountList = sqlDataReader["TaxAmountList"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["TaxAmountList"]);


                        TotalTaxAmount = TotalTaxAmount + item.TaxAmount;
                        item.TotalTaxAmount = TotalTaxAmount;


                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesInvoiceMasterAndDetails_SelectByPurchaseRequisitionMasterID' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetRecordForSalesinvoiceOrderPDF(SalesInvoiceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesInvoiceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetRecordForSalesInvoiceMasterPDF";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalesOrderMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesInvoiceMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesInvoiceMasterAndDetails item = new SalesInvoiceMasterAndDetails();
                        item.SalesOrderNumber = sqlDataReader["SalesOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderNumber"]);
                        item.TransactionDate = sqlDataReader["InvoiceDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["InvoiceDate"]);
                        item.DeliveryNumber = sqlDataReader["DeliveryNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryNumber"]);
                        item.Quantity = sqlDataReader["InvoiceQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["InvoiceQuantity"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.SaleUomCode = sqlDataReader["SaleUOMcode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["SaleUOMcode"]);
                        item.Freight = sqlDataReader["Freight"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling = sqlDataReader["ShippingHandling"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ShippingHandling"]);
                        item.Discount = sqlDataReader["Discount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Discount"]);
                       
                        item.Rate = sqlDataReader["Rate"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.LocationName = sqlDataReader["LocationName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.BatchNumber = sqlDataReader["BatchNumbers"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BatchNumbers"]);
                        item.ExpiryDate= sqlDataReader["ExpiryDate"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ExpiryDate"]);
                        item.CustomerInvoiceNumber = sqlDataReader["CustomerInvoiceNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["CustomerInvoiceNumber"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);
                        item.LogoPath = sqlDataReader["LogoPath"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LogoPath"]);
                        item.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        item.CustomerAddress = sqlDataReader["CustomerAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerAddress"]);
                        item.BranchName = sqlDataReader["BranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchName"]);
                        item.CustomerBranchAddress = sqlDataReader["CustomerBranchAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchAddress"]);
                        item.CountryName = sqlDataReader["CountryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CountryName"]);
                        item.StateName = sqlDataReader["Statename"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Statename"]);
                        item.CityName = sqlDataReader["CityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CityName"]);
                        item.BranchCountryName = sqlDataReader["BranchCountryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchCountryName"]);
                        item.BranchStateName = sqlDataReader["BranchStateName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchStateName"]);
                        item.BranchCityName = sqlDataReader["BranchCityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchCityName"]);
                        item.CellPhone = sqlDataReader["CellPhone"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CellPhone"]);
                        item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);
                        item.EmailID = sqlDataReader["EmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmailID"]);
                        item.FaxNumber = sqlDataReader["FaxNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FaxNumber"]);
                        item.PhoneNumberOffice = sqlDataReader["PhoneNumberOffice"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PhoneNumberOffice"]);
                        item.CentreAddress1 = sqlDataReader["Address1"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Address1"]);
                        item.CentreAddress2 = sqlDataReader["Address2"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Address2"]);
                        item.Website = sqlDataReader["Website"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Website"]);
                        item.Currency = sqlDataReader["Currency"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Currency"]);
                        item.IsOther = sqlDataReader["IsOther"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsOther"]);
                        item.HSNCode = sqlDataReader["HSNCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSNCode"]);
                        item.NetAmount = sqlDataReader["ItemWiseAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ItemWiseAmount"]);
                        item.TaxAmount = sqlDataReader["ItemWiseTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ItemWiseTaxAmount"]);
                        item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);

                        item.CustomerGSTNumber= sqlDataReader["CustomerGSTNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerGSTNumber"]);
                        item.BranchGSTNumber = sqlDataReader["BranchGSTNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchGSTNumber"]);
                        item.CustomerPinCode = sqlDataReader["CustomerPinCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerPinCode"]);
                        item.CustomerBranchPinCode = sqlDataReader["CustomerBranchPinCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchPinCode"]);
                        item.StateCode = sqlDataReader["StateCode"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["StateCode"]);
                        item.BranchStateCode = sqlDataReader["BranchStateCode"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["BranchStateCode"]);



                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseOrderMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalesInvoiceMasterAndDetails> InsertDirectSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item)
        {
            IBaseEntityResponse<SalesInvoiceMasterAndDetails> response = new BaseEntityResponse<SalesInvoiceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_DirectSalesInvoiceMasterAndDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 0,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.SmallInt, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFreight", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.Freight));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mShippingHandling", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ShippingHandling));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mDiscount", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.Discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mnetAmount", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.Amount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.TotalTaxAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalInvoiceAmount", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.TotalIInvoiceAmount));
                    if (item.XMLstringForVouchar == null || item.XMLstringForVouchar == "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSaleInvoiceVoucherXML", SqlDbType.Xml, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSaleInvoiceVoucherXML", SqlDbType.Xml, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.XMLstringForVouchar));
                    }
                    if (item.XMLstringForInvoice == null || item.XMLstringForInvoice == "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSaleInvoiceMasterXML", SqlDbType.Xml, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSaleInvoiceMasterXML", SqlDbType.Xml, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.XMLstringForInvoice));
                    }
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
                    // item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalesInvoiceMasterAndDetails_INSERT' reported the ErrorCode: " +
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

        #endregion
    }
}
