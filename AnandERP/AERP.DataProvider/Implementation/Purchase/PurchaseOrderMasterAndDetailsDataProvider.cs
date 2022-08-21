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
    public class PurchaseOrderMasterAndDetailsDataProvider : DBInteractionBase, IPurchaseOrderMasterAndDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public PurchaseOrderMasterAndDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public PurchaseOrderMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from PurchaseOrderMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetPurchaseOrderMasterAndDetailsBySearch(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseOrderMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPurchaseOrderType", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtPurchaseOrderDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderDate));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseOrderMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseOrderMasterAndDetails item = new PurchaseOrderMasterAndDetails();
                        item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.PurchaseRequisitionMasterID = sqlDataReader["PurchaseRequisitionMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseRequisitionMasterID"]);
                        item.PurchaseRequisitionNumber = sqlDataReader["PurchaseRequisitionNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseRequisitionNumber"]);
                        item.VendorID = sqlDataReader["VendorID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorID"]);
                        item.Vendor = sqlDataReader["Vendor"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vendor"]);
                        item.PurchaseOrderNumber = sqlDataReader["PurchaseOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        item.POStatus = sqlDataReader["POStatus"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["POStatus"]);
                        item.IsDeleted = sqlDataReader["IsDeleted"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsDeleted"]);

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
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> GetPurchaseOrderMasterAndDetailsByID(PurchaseOrderMasterAndDetails item)
        {
            IBaseEntityResponse<PurchaseOrderMasterAndDetails> response = new BaseEntityResponse<PurchaseOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseOrderMasterAndDetails_SelectOne";
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
                        PurchaseOrderMasterAndDetails _item = new PurchaseOrderMasterAndDetails();
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
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> InsertPurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item)
        {
            IBaseEntityResponse<PurchaseOrderMasterAndDetails> response = new BaseEntityResponse<PurchaseOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseOrderMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0,
                        ParameterDirection.Output, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseRequisitionMasterID", SqlDbType.Int, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.PurchaseRequisitionMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPurchaseOrderType", SqlDbType.TinyInt, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.PurchaseOrderType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daPurchaseOrderDate", SqlDbType.DateTime, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, DateTime.UtcNow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFreight", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.Freight));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mShippingHandling", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ShippingHandling));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mDiscount", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.Discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.TotalTaxAmount));
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
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseOrderMasterAndDetails_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of PurchaseOrderMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> UpdatePurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item)
        {
            IBaseEntityResponse<PurchaseOrderMasterAndDetails> response = new BaseEntityResponse<PurchaseOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseOrderMasterAndDetails_Update";
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
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseOrderMasterAndDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of PurchaseOrderMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> DeletePurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item)
        {
            IBaseEntityResponse<PurchaseOrderMasterAndDetails> response = new BaseEntityResponse<PurchaseOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseOrderMasterAndDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                     item.errorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 77)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseOrderMasterAndDetails_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
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
        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetPurchaseOrderMasterAndDetailsByPurchaseRequisitionMasterID(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseOrderMasterAndDetails_SelectByPurchaseRequisitionMasterID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseRequisitionMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseRequisitionMasterID));

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
                    baseEntityCollection.CollectionResponse = new List<PurchaseOrderMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseOrderMasterAndDetails item = new PurchaseOrderMasterAndDetails();
                        item.ItemID = sqlDataReader["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.OrderUomCode = sqlDataReader["OrderUomCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.ItemName = sqlDataReader["ItemName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        item.ExpectedDeliveryDate = sqlDataReader["ExpectedDeliveryDate"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ExpectedDeliveryDate"]);
                        item.Rate = sqlDataReader["Rate"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.Quantity = sqlDataReader["Quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.LocationName = sqlDataReader["LocationName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.PriorityFlag = sqlDataReader["PriorityFlag"] == DBNull.Value ? Convert.ToInt16(0) : Convert.ToInt16(sqlDataReader["PriorityFlag"]);
                        item.Freight = sqlDataReader["Freight"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling = sqlDataReader["ShippingHandling"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToInt16(sqlDataReader["ShippingHandling"]);
                        item.Discount = sqlDataReader["Discount"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Discount"]);
                        item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.Vendor = sqlDataReader["Vender"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
                        item.IsOtherState = sqlDataReader["IsOtherState"] == DBNull.Value ? false : Convert.ToBoolean(sqlDataReader["IsOtherState"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);
                        item.TaxAmount = sqlDataReader["ItemWisetaxAmount"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["ItemWisetaxAmount"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseOrderMasterAndDetails_SelectByPurchaseRequisitionMasterID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetRecordForPurchaseOrderPDF(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseOrderMasterAndDetails>();
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseOrderMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseOrderMasterAndDetails item = new PurchaseOrderMasterAndDetails();
                        item.ID = sqlDataReader["PurchaseOrderMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseOrderMasterID"]);
                        item.PurchaseRequisitionMasterID = sqlDataReader["PurchaseRequisitionMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseRequisitionMasterID"]);
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
                        item.Vendor = sqlDataReader["Vender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
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
                        item.PrintingLine1 = sqlDataReader["PrintingLine1"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine1"]);
                        item.PrintingLine2 = sqlDataReader["PrintingLine2"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine2"]);
                        item.PrintingLine3 = sqlDataReader["PrintingLine3"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine3"]);
                        item.PrintingLine4 = sqlDataReader["PrintingLine4"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine4"]);

                        if (DBNull.Value.Equals(sqlDataReader["Logo"]) == false)
                        {
                            item.Logo = (byte[])(sqlDataReader["Logo"]);
                        }
                        item.LogoType = sqlDataReader["LogoType"].ToString();
                        item.LogoFileSize = sqlDataReader["LogoFileSize"].ToString();


                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.Freight = sqlDataReader["Freight"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling = sqlDataReader["ShippingHandling"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ShippingHandling"]);
                        item.Discount = sqlDataReader["Discount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Discount"]);

                        item.VendorName = sqlDataReader["VendorName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorName"]);
                        item.VendorAddress = sqlDataReader["VendorAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorAddress"]);
                        item.VendorPhoneNumber = sqlDataReader["VendorPhoneNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorPhoneNumber"]);
                        item.VendorNumber = sqlDataReader["VendorNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorNumber"]);
                        item.VendorPinCode = sqlDataReader["VendorPinCode"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorPinCode"]);
                        item.Currency = sqlDataReader["Currency"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Currency"]);
                        item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        item.LocationAddress = sqlDataReader["LocationAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationAddress"]);
                        item.City = sqlDataReader["Description"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Description"]);
                        item.Pincode = sqlDataReader["Pincode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Pincode"]);
                        if (DBNull.Value.Equals(sqlDataReader["CurrentDatedCheque"]) == false)
                        {
                            item.CurrentDatedCheque = Convert.ToBoolean(sqlDataReader["CurrentDatedCheque"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CashOnDelivery"]) == false)
                        {
                            item.CashOnDelivery = Convert.ToBoolean(sqlDataReader["CashOnDelivery"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Credit"]) == false)
                        {
                            item.Credit = Convert.ToBoolean(sqlDataReader["Credit"]);
                        }
                        item.IsDeleted = sqlDataReader["IsDeleted"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsDeleted"]);

                        item.FromUnitName = sqlDataReader["FromUnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromUnitName"]);
                        item.FromLocationAddress = sqlDataReader["FromLocationAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromLocationAddress"]);
                        item.FromCity = sqlDataReader["FromCity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromCity"]);
                        item.FromPincode = sqlDataReader["FromPincode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromPincode"]);

                        var Amount = (item.Quantity * item.Rate);
                        var taxamount = ((Amount * item.TaxRate) / 100);
                        var grossAmmount = Amount + taxamount;

                        item.Amount = Amount;
                        item.TotalTaxAmount = taxamount;
                        item.GrossAmount = grossAmmount;
                        item.LogoPath = sqlDataReader["LogoPath"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LogoPath"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);
                        item.IsOtherState = sqlDataReader["IsOtherState"] == DBNull.Value ? false : Convert.ToBoolean(sqlDataReader["IsOtherState"]);




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

        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> InsertApprovedPurchaseOrderRecord(PurchaseOrderMasterAndDetails item)
        {
            IBaseEntityResponse<PurchaseOrderMasterAndDetails> response = new BaseEntityResponse<PurchaseOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseOrderRequestApproval_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseRequisitionMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToByte(item.IsLastRecord)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskReportingDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskReportingDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bApprovalStatus", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApprovedStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StageSequenceNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsRemark", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "abc"));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Status));
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
                    if (cmdToExecute.Parameters["@iID"].Value != null)
                    {
                        //item.ID = (int)(SqlInt32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != DBNull.Value)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        item.ErrorCode = (int)_errorCode;
                    }
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseOrderMasterAndDetails_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    //if (_rowsAffected > 0)
                    //{
                        
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
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
        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetPurchaseOrderForApproval(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseOrder_GetRequestForApproval";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskReportingDetailsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralTaskReportingDetailsID));
                    

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
                    baseEntityCollection.CollectionResponse = new List<PurchaseOrderMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseOrderMasterAndDetails item = new PurchaseOrderMasterAndDetails();
                        item.ItemID = sqlDataReader["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ID = sqlDataReader["ID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.OrderUomCode = sqlDataReader["OrderUomCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.ItemName = sqlDataReader["ItemName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        item.ExpectedDeliveryDate = sqlDataReader["ExpectedDeliveryDate"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ExpectedDeliveryDate"]);
                        item.Rate = sqlDataReader["Rate"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.Quantity = sqlDataReader["Quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.LocationName = sqlDataReader["LocationName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.PriorityFlag = sqlDataReader["PriorityFlag"] == DBNull.Value ? Convert.ToInt16(0) : Convert.ToInt16(sqlDataReader["PriorityFlag"]);
                        item.Freight = sqlDataReader["Freight"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling = sqlDataReader["ShippingHandling"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToInt16(sqlDataReader["ShippingHandling"]);
                        item.Discount = sqlDataReader["Discount"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["Discount"]);
                        item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] == DBNull.Value ? Convert.ToDecimal(0) : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.Vendor = sqlDataReader["Vendor"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["Vendor"]);
                        item.PurchaseOrderType = Convert.ToInt16(sqlDataReader["PurchaseRequisitionType"]);
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
                       
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseOrder_GetRequestForApproval' reported the ErrorCode: " + _errorCode);
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
