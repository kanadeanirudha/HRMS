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
    public class PurchaseInvoiceDataProvider : DBInteractionBase, IPurchaseInvoiceDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public PurchaseInvoiceDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public PurchaseInvoiceDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from PurchaseInvoice table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseInvoice> GetPurchaseInvoiceBySearch(PurchaseInvoiceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseInvoice> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseInvoice>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseInvoiceMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPurchaseOrderType", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderType));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseInvoice>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseInvoice item = new PurchaseInvoice();
                        item.ID = sqlDataReader["PurchaseInvoiceID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseInvoiceID"]);
                        item.PurchaseOrderMasterID = sqlDataReader["PurchaseOrderMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseOrderMasterID"]);
                        item.PurchaseOrderNumber = sqlDataReader["PurchaseOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        item.VendorID = sqlDataReader["VendorID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorID"]);
                        item.VendorName = sqlDataReader["Vender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
                        //item.PurchaseGRNMasterID = sqlDataReader["PurchaseGRNMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseGRNMasterID"]);
                        item.CreatedDate = sqlDataReader["CreatedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        item.GRNNumber = sqlDataReader["PurchaseGRNNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseGRNNumber"]);
                        item.VendorInvoiceNo = sqlDataReader["VendorInvoiceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorInvoiceNumber"]);
                        item.PurchaseRequisitionMasterID = sqlDataReader["PurchaseRequisitionMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseRequisitionMasterID"]);

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
        public IBaseEntityResponse<PurchaseInvoice> GetPurchaseInvoiceByID(PurchaseInvoice item)
        {
            IBaseEntityResponse<PurchaseInvoice> response = new BaseEntityResponse<PurchaseInvoice>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseInvoice_SelectOne";
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
                        PurchaseInvoice _item = new PurchaseInvoice();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.PurchaseRequisitionMasterID = Convert.ToInt32(sqlDataReader["PurchaseRequisitionMasterID"]);
                        _item.PurchaseOrderNumber = sqlDataReader["PurchaseOrderNumber"].ToString();
                        _item.PurchaseOrderDate = Convert.ToString(sqlDataReader["PurchaseOrderDate"]);
                        _item.VendorID = Convert.ToInt32(sqlDataReader["VendorID"]);

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
        public IBaseEntityResponse<PurchaseInvoice> InsertPurchaseInvoice(PurchaseInvoice item)
        {
            IBaseEntityResponse<PurchaseInvoice> response = new BaseEntityResponse<PurchaseInvoice>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseInvoiceMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0,
                        ParameterDirection.Output, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseGRNMasterID", SqlDbType.Int, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.PurchaseGRNMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseOrderMasterID", SqlDbType.Int, 0,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.PurchaseOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.VendorID));
                    if (item.VendorInvoiceNo == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsVendorInvoiceNumber", SqlDbType.NVarChar, 60,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsVendorInvoiceNumber", SqlDbType.NVarChar, 60,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.VendorInvoiceNo));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@siStorageLocationID", SqlDbType.SmallInt, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.StorageLocationID));
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
                    item.TotalInvoiceAmount = TotalInvoiceAmount1;

                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalInvoiceAmount", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.TotalInvoiceAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPurchaseInvoiceVoucherXML", SqlDbType.Xml, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.XMLstringForVouchar));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseInvoice_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of PurchaseInvoice
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseInvoice> UpdatePurchaseInvoice(PurchaseInvoice item)
        {
            IBaseEntityResponse<PurchaseInvoice> response = new BaseEntityResponse<PurchaseInvoice>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseInvoice_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseRequisitionMasterID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.PurchaseRequisitionMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumber", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.PurchaseOrderNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daPurchaseOrderDate", SqlDbType.DateTime, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.PurchaseOrderDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.TinyInt, 3,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.PurchaseOrderType));

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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseInvoice_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of PurchaseInvoice
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseInvoice> DeletePurchaseInvoice(PurchaseInvoice item)
        {
            IBaseEntityResponse<PurchaseInvoice> response = new BaseEntityResponse<PurchaseInvoice>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseInvoice_Delete";
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseInvoice_Delete' reported the ErrorCode: " +
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
        public IBaseEntityCollectionResponse<PurchaseInvoice> GetPurchaseInvoiceByPurchaseGRNMasterID(PurchaseInvoiceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseInvoice> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseInvoice>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseInvoiceMaster_SelectByPurchaseGRNMasterID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPurchaseOrderType", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderType));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseInvoice>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseInvoice item = new PurchaseInvoice();
                        //  item.ItemID = sqlDataReader["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemName = sqlDataReader["ItemName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        // item.PurchaseGRNMasterID    = sqlDataReader["PurchaseGRNMasterID"] == DBNull.Value ? 0                    : Convert.ToInt32(sqlDataReader["PurchaseGRNMasterID"]);
                        item.GRNNumber = sqlDataReader["GRNNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["GRNNumber"]);
                        //item.GRNTransDate           = sqlDataReader["GRNTransDate"]        == DBNull.Value ? string.Empty         : Convert.ToString(sqlDataReader["GRNTransDate"]);
                        item.Quantity = sqlDataReader["Quantity"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.FocReceivedQuantity = sqlDataReader["FocReceivedQuantity"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["FocReceivedQuantity"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] == DBNull.Value ? Convert.ToInt32(0) : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.OrderUomCode = sqlDataReader["OrderUomCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.Freight = sqlDataReader["Freight"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling = sqlDataReader["ShippingHandling"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToInt16(sqlDataReader["ShippingHandling"]);
                        item.Discount = sqlDataReader["Discount"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Discount"]);
                        item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.Rate = sqlDataReader["Rate"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.LocationName = sqlDataReader["LocationName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.VendorID = sqlDataReader["GensupplierID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["GensupplierID"]);
                        item.VendorName = sqlDataReader["VendorName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["VendorName"]);
                        item.VendorInvoiceNo = sqlDataReader["VendorNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["VendorNumber"]);
                        item.IsOtherState = sqlDataReader["IsOtherState"] == DBNull.Value ? false : Convert.ToBoolean(sqlDataReader["IsOtherState"]);
                        item.PurchaseOrderMasterID = sqlDataReader["PurchaseOrderMasterID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["PurchaseOrderMasterID"]);
                        item.BatchNumber = sqlDataReader["BatchNumbers"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BatchNumbers"]);
                        item.ExpiryDate = sqlDataReader["ExpiryDate"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ExpiryDate"]);
                        item.StorageLocationID = sqlDataReader["StorageLocationID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["StorageLocationID"]);
                        item.VendorInvoiceNo = sqlDataReader["VendorInvoiceNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["VendorInvoiceNumber"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseInvoice_SelectByPurchaseRequisitionMasterID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseInvoice> GetRecordForPurchaseOrderPDF(PurchaseInvoiceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseInvoice> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseInvoice>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetRecordForPurchaseOrderPDF";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseInvoice>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseInvoice item = new PurchaseInvoice();
                        item.ID = sqlDataReader["PurchaseOrderMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseOrderMasterID"]);
                        item.PurchaseOrderType = Convert.ToInt16(sqlDataReader["PurchaseOrderType"]);
                        if (item.PurchaseOrderType == 1)
                        {
                            item.PurchaseOrderTypeDescription = "Sub Contracting Requisition";
                        }
                        else if (item.PurchaseOrderType == 2)
                        {
                            item.PurchaseOrderTypeDescription = "Consignment Requision";
                        }
                        else if (item.PurchaseOrderType == 3)
                        {
                            item.PurchaseOrderTypeDescription = "Stock Transfer Requisition";
                        }
                        else if (item.PurchaseOrderType == 4)
                        {
                            item.PurchaseOrderTypeDescription = "Service Type Requisition";

                        }
                        else if (item.PurchaseOrderType == 5)
                        {
                            item.PurchaseOrderTypeDescription = "Standard Type Requisition";
                        }
                        item.PurchaseOrderDate = sqlDataReader["PurchaseOrderDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderDate"]);

                        item.VendorID = sqlDataReader["VendorID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorID"]);
                        //item.Vendor = sqlDataReader["Vender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
                        item.PurchaseOrderNumber = sqlDataReader["PurchaseOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        item.Rate = sqlDataReader["Rate"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.Quantity = sqlDataReader["Quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.StorageLocationID = sqlDataReader["StorageLocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StorageLocationID"]);
                        item.LocationName = sqlDataReader["LocationName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.BarCode = sqlDataReader["BarCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.OrderUomCode = sqlDataReader["OrderUomCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUomQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["BaseUomQuantity"]);
                        item.ItemName = sqlDataReader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.ExpectedDeliveryDate = sqlDataReader["ExpectedDeliveryDate"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ExpectedDeliveryDate"]);
                        //item.PrintingLine1 = sqlDataReader["PrintingLine1"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine1"]);
                        //item.PrintingLine2 = sqlDataReader["PrintingLine2"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine2"]);
                        //item.PrintingLine3 = sqlDataReader["PrintingLine3"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine3"]);
                        //item.PrintingLine4 = sqlDataReader["PrintingLine4"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine4"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.Freight = sqlDataReader["Freight"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling = sqlDataReader["ShippingHandling"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ShippingHandling"]);
                        item.Discount = sqlDataReader["Discount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Discount"]);

                        var Amount = (item.Quantity * item.Rate);
                        var taxamount = ((Amount * item.TaxRate) / 100);
                        var grossAmmount = Amount + taxamount;

                        item.Amount = Amount;
                        item.TotalTaxAmount = taxamount;
                        //item.GrossAmount = grossAmmount;

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
        public IBaseEntityResponse<PurchaseInvoice> InsertManualPurchaseInvoice(PurchaseInvoice item)
        {
            IBaseEntityResponse<PurchaseInvoice> response = new BaseEntityResponse<PurchaseInvoice>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseInvoiceMaster_DirectManualInvoice";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0,
                        ParameterDirection.Output, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siStorageLocationID", SqlDbType.SmallInt, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.StorageLocationID));
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
                                        DataRowVersion.Proposed, item.TotalInvoiceAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPurchaseInvoiceVoucherXML", SqlDbType.Xml, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.XmlStringForDirectinvoiceVoucher));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPurchaseDetailsXML", SqlDbType.Xml, 0,
                                       ParameterDirection.Input, false, 0, 0, "",
                                       DataRowVersion.Proposed, item.PurchaseDetailsXML));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseInvoice_INSERT' reported the ErrorCode: " +
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
