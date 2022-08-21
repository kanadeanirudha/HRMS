
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
    public class PurchaseReportMasterDataProvider : DBInteractionBase, IPurchaseReportMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor

        /// Constructor to initialized data member and member functions        
        public PurchaseReportMasterDataProvider()
        {
        }
        
        /// Constructor to initialized data member and member functions        
        public PurchaseReportMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["DeveloperDBEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion


        #region Method Implementation 

        // PurchaseReportMaster Method
        #region PurchaseReportMaster

       
        /// Select a record from PurchaseReportMaster table by ID        
        public IBaseEntityResponse<PurchaseReportMaster> GetPurchaseReportMasterByID(PurchaseReportMaster item)
        {
            IBaseEntityResponse<PurchaseReportMaster> response = new BaseEntityResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseReportMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LocationID));
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
                        PurchaseReportMaster _item = new PurchaseReportMaster();

                        //Property of EntranceExamPaymentDetails
                        //if (DBNull.Value.Equals(sqlDataReader["StudentRegistrationID"]) == false)
                        //{
                        //    _item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                        //{
                        //    _item.StudentName = sqlDataReader["StudentName"].ToString();
                        //}
                        


                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseReportMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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

        /// Create new record of the table        
        public IBaseEntityResponse<PurchaseReportMaster> InsertPurchaseReportMaster(PurchaseReportMaster item)
        {
            IBaseEntityResponse<PurchaseReportMaster> response = new BaseEntityResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseReportMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //Property of PurchaseReportMaster
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamValidationParameterApplicableID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamValidationParameterApplicableID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.StudentRegistrationID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dcPaymentAmount", SqlDbType.Decimal, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentAmount));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@tiPaymentMode", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentMode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iPaymentThrough", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentThrough));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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

                    if (_rowsAffected > 0)
                    {
                        //item.LocationID = (Int32)cmdToExecute.Parameters["@iLocationID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseReportMaster_Insert' reported the ErrorCode: " + _errorCode);
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

        /// Update a specific record of PurchaseReportMaster        
        public IBaseEntityResponse<PurchaseReportMaster> UpdatePurchaseReportMaster(PurchaseReportMaster item)
        {
            IBaseEntityResponse<PurchaseReportMaster> response = new BaseEntityResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseReportMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of PurchaseReportMaster
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));

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

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseReportMaster_Delete' reported the ErrorCode: " + _errorCode);
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

        /// Delete a specific record of PurchaseReportMaster        
        public IBaseEntityResponse<PurchaseReportMaster> DeletePurchaseReportMaster(PurchaseReportMaster item)
        {
            IBaseEntityResponse<PurchaseReportMaster> response = new BaseEntityResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseReportMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamPaymentDetails
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    //item.LocationID = (Int32)cmdToExecute.Parameters["@iLocationID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseReportMaster_Delete' reported the ErrorCode: " + _errorCode);
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


        // Select all record from PurchaseReportMaster table with search list.
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetPurchaseReportMasterSearchList(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseReportMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseReportMasterSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseReportMasterSearchWord));

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
                    baseEntityCollection.CollectionResponse = new List<PurchaseReportMaster>();

                    while (sqlDataReader.Read())
                    {
                        PurchaseReportMaster item = new PurchaseReportMaster();

                        //Property of PurchaseReportMaster
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EntranceExamPaymentDetails_SearchList' reported the ErrorCode: " + _errorCode);
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


        /// Select all record from PurchaseReportMaster table with search parameters        
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetArticalMovementReport(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_ArticalMovement_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,35, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));

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
                    baseEntityCollection.CollectionResponse = new List<PurchaseReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReportMaster item = new PurchaseReportMaster();
                        //Property of PurchaseReportMaster
                        if (DBNull.Value.Equals(sqlDataReader["BarCode"]) == false)
                        {
                            item.BarCode = Convert.ToString(sqlDataReader["BarCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OpeningBalanceQty"]) == false)
                        {
                            item.OpeningBalanceQty = Convert.ToDecimal(sqlDataReader["OpeningBalanceQty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ClosingBalanceQty"]) == false)
                        {
                            item.OpeningBalanceQty = Convert.ToDecimal(sqlDataReader["ClosingBalanceQty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentStockQty"]) == false)
                        {
                            item.CurrentStockQty = Convert.ToDecimal(sqlDataReader["CurrentStockQty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransDate"]) == false)
                        {
                            item.TransDate = Convert.ToString(sqlDataReader["TransDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                        }
                        
                        if (DBNull.Value.Equals(sqlDataReader["BaseUOM"]) == false)
                        {
                            item.BaseUOMCode = Convert.ToString(sqlDataReader["BaseUOM"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionUOM"]) == false)
                        {
                            item.TransactionUOM = Convert.ToString(sqlDataReader["TransactionUOM"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionQuantity"]) == false)
                        {
                            item.TransactionQuantity = Convert.ToDecimal(sqlDataReader["TransactionQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationName"]) == false)
                        {
                            item.LocationName = sqlDataReader["LocationName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MovementTypeCode"]) == false)
                        {
                            item.MovementTypeCode = Convert.ToString(sqlDataReader["MovementTypeCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                        {
                            item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MovementType"]) == false)
                        {
                            item.MovementType = Convert.ToString(sqlDataReader["MovementType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BatchNumber"]) == false)
                        {
                            item.BatchNumber = Convert.ToString(sqlDataReader["BatchNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderNumber"]) == false)
                        {
                            item.PurchaseOrderNumber = Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VendorNumber"]) == false)
                        {
                            item.VendorNumber = Convert.ToInt32(sqlDataReader["VendorNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionTypeId"]) == false)
                        {
                            item.TransactionTypeId = Convert.ToByte(sqlDataReader["TransactionTypeId"]);
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
                        throw new Exception("Stored Procedure 'USP_ArticalMovement_Report' reported the ErrorCode: " + _errorCode);
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


        /// Select all record from DailyRateChange        
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetLocationWiseCurrentStockReport(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandText = "USP_GetItemCurrentStockLocationWise_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xLocationIDXmlString", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationNameListXml));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReportMaster item = new PurchaseReportMaster();

                        ////Property of PurchaseReportMaster
                        if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                        {
                            item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                        {
                            item.ItemDescription = sqlDataReader["ItemDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentStockQty"]) == false)
                        {
                            item.CurrentStockQty = Convert.ToDecimal(sqlDataReader["CurrentStockQty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BarCode"]) == false)
                        {
                            item.BarCode = sqlDataReader["BarCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationName"]) == false)
                        {
                            item.LocationName = Convert.ToString(sqlDataReader["LocationName"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        //{
                        //    item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                       // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_DailyRateChange_SelectAll' reported the ErrorCode: " + _errorCode);
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


        /// Select all record from DumpAndShrinkReport        
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetStockConsumptionReport(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandTimeout = 20000;
                    cmdToExecute.CommandText = "dbo.USP_InventoryDumpAndShrink_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountBalsheetMstID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.FromDate)));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.UptoDate)));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@xLocationIDXmlString", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationNameListXml));

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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<PurchaseReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReportMaster item = new PurchaseReportMaster();

                        //Property of PurchaseReportMaster
                        //if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        //{
                        //    item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        //{
                        //    item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OpeningBalance"]) == false)
                        //{
                        //    item.OpeningBalance = Convert.ToDecimal(sqlDataReader["OpeningBalance"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ClosingBalance"]) == false)
                        //{
                        //    item.ClosingBalance = Convert.ToDecimal(sqlDataReader["ClosingBalance"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        //{
                        //item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TotalInwardQuantity"]) == false)
                        //{
                        //    item.TotalInwardQuantity = Convert.ToDecimal(sqlDataReader["TotalInwardQuantity"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TotalOutwardQuantity"]) == false)
                        //{
                        //    item.TotalOutwardQuantity = Convert.ToDecimal(sqlDataReader["TotalOutwardQuantity"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["DumpQuantity"]) == false)
                        //{
                        //    item.DumpQuantity = Convert.ToDecimal(sqlDataReader["DumpQuantity"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ShrinkQuantity"]) == false)
                        //{
                        //    item.ShrinkQuantity = Convert.ToDecimal(sqlDataReader["ShrinkQuantity"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TotalPurchaseQuantity"]) == false)
                        //{
                        //    item.TotalPurchaseQuantity = Convert.ToDecimal(sqlDataReader["TotalPurchaseQuantity"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TotalSaleQuantity"]) == false)
                        //{
                        //    item.TotalSaleQuantity = Convert.ToDecimal(sqlDataReader["TotalSaleQuantity"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["LocationName"]) == false)
                        //{
                        //    item.LocationName = sqlDataReader["LocationName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        //{
                        //    item.ItemName = sqlDataReader["ItemName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ItemCode"]) == false)
                        //{
                        //    item.ItemCode = sqlDataReader["ItemCode"].ToString();
                        //}
                       
                        baseEntityCollection.CollectionResponse.Add(item);
                        //baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDumpAndShrink_Report' reported the ErrorCode: " + _errorCode);
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


        /// Select all record from PurchaseReportMaster table with search parameters ( DailyItemRateChange Report)       
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetDailyItemRateChangeReportBySearch(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDailyRateChange_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetID", SqlDbType.VarChar, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AccountBalsheetMstID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReportMaster item = new PurchaseReportMaster();
                        //Property of PurchaseReportMaster
                        //if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        //{
                        //    item.TransactionDate = sqlDataReader["TransactionDate"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.ItemID = Convert.ToInt32(sqlDataReader["ID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CategoryDescription"]) == false)
                        //{
                        //    item.CategoryCode = sqlDataReader["CategoryDescription"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        //{
                        //    item.ItemName = sqlDataReader["ItemName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ItemCode"]) == false)
                        //{
                        //    item.ItemCode = sqlDataReader["ItemCode"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CurrentRate"]) == false)
                        //{
                        //    item.CurrentRate = Convert.ToDecimal(sqlDataReader["CurrentRate"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["PreviousSaleRate"]) == false)
                        //{
                        //    item.PreviousSaleRate = Convert.ToDecimal(sqlDataReader["PreviousSaleRate"]);
                        //}

                        //item.FromDate = searchRequest.FromDate;
                        //item.UptoDate = searchRequest.UptoDate;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDailyItemRateChange_Report' reported the ErrorCode: " + _errorCode);
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

        //Below Indend Level Report.
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetBelowIndendLevelReportBySearch(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryBelowIndendLevelList_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountBalsheetMstID));                    
                    //cmdToExecute.Parameters.Add(new SqlParameter("@xLocationIDXmlString", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationNameListXml));

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
                    baseEntityCollection.CollectionResponse = new List<PurchaseReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReportMaster item = new PurchaseReportMaster();

                        ////Property of PurchaseReportMaster
                        //if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        //{
                        //    item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        //}                        
                        //if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        //{
                        //    item.ItemName = sqlDataReader["ItemName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CategoryCode"]) == false)
                        //{
                        //    item.CategoryCode = sqlDataReader["CategoryCode"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["MinIndentLevel"]) == false)
                        //{
                        //    item.MinIndentLevel = Convert.ToDecimal(sqlDataReader["MinIndentLevel"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["Category"]) == false)
                        //{
                        //    item.Category = sqlDataReader["Category"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CurrentQuantity"]) == false)
                        //{
                        //    item.CurrentQuantity = Convert.ToDecimal(sqlDataReader["CurrentQuantity"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["LocationName"]) == false)
                        //{
                        //    item.LocationName = sqlDataReader["LocationName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["IndendQuantity"]) == false)
                        //{
                        //    item.IndendQuantity = Convert.ToDecimal(sqlDataReader["IndendQuantity"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                        //baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryBelowIndendLevelList_Report' reported the ErrorCode: " + _errorCode);
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


        #endregion
        //For Item Order Status Report

           //Below Indend Level Report.
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetItemOrderStatusList(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_ItemOrderStatusReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));                    
                    //cmdToExecute.Parameters.Add(new SqlParameter("@xLocationIDXmlString", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationNameListXml));

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
                    baseEntityCollection.CollectionResponse = new List<PurchaseReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReportMaster item = new PurchaseReportMaster();

                        ////Property of PurchaseReportMaster
                        if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                        {
                            item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                        {
                            item.ItemDescription = sqlDataReader["ItemDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentStockQty"]) == false)
                        {
                            item.CurrentStock = sqlDataReader["CurrentStockQty"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReorderPoint"]) == false)
                        {
                            item.ReOrderPoint = Convert.ToString(sqlDataReader["ReorderPoint"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SafetyStockDriven"]) == false)
                        {
                            item.SafetyStock = sqlDataReader["SafetyStockDriven"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastPOStatus"]) == false)
                        {
                            item.LastPOStatus = Convert.ToString(sqlDataReader["LastPOStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BaseUomCode"]) == false)
                        {
                            item.BaseUomCode = Convert.ToString(sqlDataReader["BaseUomCode"]);
                        }

                        item.CentreName = searchRequest.CentreName;
                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;

                        baseEntityCollection.CollectionResponse.Add(item);
                        //baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryBelowIndendLevelList_Report' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetInventoryPurchaseStockReport(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryPurchaseStock_GetReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
                    
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReportMaster item = new PurchaseReportMaster();

                        if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                        {
                            item.ItemDescription = sqlDataReader["ItemDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentStockQty"]) == false)
                        {
                            item.CurrentStock = sqlDataReader["CurrentStockQty"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SaleOrderQuantity"]) == false)
                        {
                            item.SaleOrderQuantity = Convert.ToString(sqlDataReader["SaleOrderQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderQuantity"]) == false)
                        {
                            item.PurchaseOrderQuantity = sqlDataReader["PurchaseOrderQuantity"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseRequiredQuantity"]) == false)
                        {
                            item.PurchaseRequiredQuantity = Convert.ToString(sqlDataReader["PurchaseRequiredQuantity"]);
                        }
                        
                        item.FromDate = searchRequest.FromDate;
                        item.UptoDate = searchRequest.UptoDate;
                        item.LocationName = searchRequest.LocationName;

                        baseEntityCollection.CollectionResponse.Add(item);
                        //baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryBelowIndendLevelList_Report' reported the ErrorCode: " + _errorCode);
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
