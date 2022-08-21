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
    public class SalesCustomerRecieptDataProvider : DBInteractionBase, ISalesCustomerRecieptDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalesCustomerRecieptDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalesCustomerRecieptDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from SalesCustomerReciept table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesCustomerReciept> GetSalesCustomerRecieptBySearch(SalesCustomerRecieptSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesCustomerReciept> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesCustomerReciept>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesInvoiceReciept_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionStartDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TransactionFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionEndDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TransactionUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiTransactionSubType", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));//Transaction Sub Type='Customer Reciept'--1

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
                    baseEntityCollection.CollectionResponse = new List<SalesCustomerReciept>();
                    while (sqlDataReader.Read())
                    {
                        SalesCustomerReciept item = new SalesCustomerReciept();
                        item.VoucherNumber = sqlDataReader["VoucherNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VoucherNumber"]);

                        item.PaidAmount = sqlDataReader["Amount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Amount"]);
                        item.payementmode = sqlDataReader["TransactionMode"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TransactionMode"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.InvoiceTrackingMasterID = sqlDataReader["InvoiceTrackingMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["InvoiceTrackingMasterID"]);
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        item.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        item.BranchName = sqlDataReader["BranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchName"]);
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
        public IBaseEntityResponse<SalesCustomerReciept> GetSalesCustomerRecieptByID(SalesCustomerReciept item)
        {
            IBaseEntityResponse<SalesCustomerReciept> response = new BaseEntityResponse<SalesCustomerReciept>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesCustomerReciept_SelectOne";
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
                        SalesCustomerReciept _item = new SalesCustomerReciept();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);


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
        public IBaseEntityResponse<SalesCustomerReciept> InsertSalesCustomerReciept(SalesCustomerReciept item)
        {
            IBaseEntityResponse<SalesCustomerReciept> response = new BaseEntityResponse<SalesCustomerReciept>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesCustomerReciept_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    if (item.XMLstring != "" || item.XMLstring != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xCustomerRecieptXML", SqlDbType.Xml, 0,
                            ParameterDirection.Input, false, 0, 0, "",
                            DataRowVersion.Proposed, item.XMLstring));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xCustomerRecieptXML", SqlDbType.Xml, 0,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalPaidAmount", SqlDbType.Money, 0,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, item.PaidAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, item.CustomerMasterID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPayementMode", SqlDbType.TinyInt, 4,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, item.payementmode));
                    if (item.CentreCode != "" || item.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35,
                           ParameterDirection.Input, false, 0, 0, "",
                           DataRowVersion.Proposed, item.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForVouchar != "" || item.XMLstringForVouchar != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xCustomerRecieptVoucherXML", SqlDbType.Xml, 0,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, item.XMLstringForVouchar));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xCustomerRecieptVoucherXML", SqlDbType.Xml, 0,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BankName == "" || item.BankName == null || item.payementmode == 1)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 35,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 35,
                      ParameterDirection.Input, false, 0, 0, "",
                      DataRowVersion.Proposed, item.BankName));
                    }
                    if (item.IFSCCode == "" || item.IFSCCode == null || item.payementmode == 1)
                    {

                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFSCCode", SqlDbType.NVarChar, 35,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {

                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFSCCode", SqlDbType.NVarChar, 35,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, item.IFSCCode));
                    }
                    if (item.ChequeNumber == "" || item.ChequeNumber == null || item.payementmode == 1)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsChequeNumber", SqlDbType.NVarChar, 35,
                           ParameterDirection.Input, false, 0, 0, "",
                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsChequeNumber", SqlDbType.NVarChar, 35,
                           ParameterDirection.Input, false, 0, 0, "",
                           DataRowVersion.Proposed, item.ChequeNumber));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                      ParameterDirection.Input, false, 0, 0, "",
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalesCustomerReciept_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of SalesCustomerReciept
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesCustomerReciept> UpdateSalesCustomerReciept(SalesCustomerReciept item)
        {
            IBaseEntityResponse<SalesCustomerReciept> response = new BaseEntityResponse<SalesCustomerReciept>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesCustomerReciept_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));

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
                        throw new Exception("Stored Procedure 'dbo.USP_SalesCustomerReciept_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of SalesCustomerReciept
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesCustomerReciept> DeleteSalesCustomerReciept(SalesCustomerReciept item)
        {
            IBaseEntityResponse<SalesCustomerReciept> response = new BaseEntityResponse<SalesCustomerReciept>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesCustomerReciept_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_SalesCustomerReciept_Delete' reported the ErrorCode: " +
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
        public IBaseEntityCollectionResponse<SalesCustomerReciept> GetCustomerWiseInvoiceDetailsForCustomerRecieptList(SalesCustomerRecieptSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesCustomerReciept> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesCustomerReciept>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerReciept_GetCustomerWiseInvoiceDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerBranchMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesCustomerReciept>();
                    while (sqlDataReader.Read())
                    {
                        SalesCustomerReciept item = new SalesCustomerReciept();
                        item.SalesInvoiceMasterID = sqlDataReader["SalesInvoiceMasterID"] == DBNull.Value ? 0 : Convert.ToInt32(sqlDataReader["SalesInvoiceMasterID"]);
                        item.InvoiceDate = sqlDataReader["InvoiceDate"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["InvoiceDate"]);
                        item.InvoiceNumber = sqlDataReader["InvoiceNumber"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["InvoiceNumber"]);
                        item.StatusFlag = sqlDataReader["InvoiceStatusFlag"] == DBNull.Value ? new byte() : Convert.ToByte(sqlDataReader["InvoiceStatusFlag"]);
                        item.InvoiceAmount = sqlDataReader["InvoiceAmount"] == DBNull.Value ? new decimal() : Convert.ToDecimal(sqlDataReader["InvoiceAmount"]);
                        item.CreditAmount = sqlDataReader["CreditAmount"] == DBNull.Value ? new decimal() : Convert.ToDecimal(sqlDataReader["CreditAmount"]);


                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesCustomerReciept_SelectByPurchaseRequisitionMasterID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalesCustomerReciept> GetRecordForPurchaseOrderPDF(SalesCustomerRecieptSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesCustomerReciept> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesCustomerReciept>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesInvoiceReciept_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInvoiceTrackingMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.InvoiceTrackingMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiTransactionSubType", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    baseEntityCollection.CollectionResponse = new List<SalesCustomerReciept>();
                    while (sqlDataReader.Read())
                    {
                        SalesCustomerReciept item = new SalesCustomerReciept();
                        item.InvoiceTrackingMasterID = sqlDataReader["InvoiceTrackingMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["InvoiceTrackingMasterID"]);
                        item.ChequeNumber = sqlDataReader["ChequeNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ChequeNumber"]);
                        item.IFSCCode = sqlDataReader["IFCICode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["IFCICode"]);
                        item.BankName = sqlDataReader["BankName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankName"]);
                        item.VoucherNumber = sqlDataReader["VoucherNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VoucherNumber"]);
                        item.payementmode = sqlDataReader["TransactionMode"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TransactionMode"]);
                        item.PaidInvoiceAmount = sqlDataReader["PaidInvoiceAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PaidInvoiceAmount"]);
                        item.PaidAmount = sqlDataReader["TotalPaidAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalPaidAmount"]);
                        item.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        item.BranchName = sqlDataReader["BranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchName"]);
                        item.StatusFlag = sqlDataReader["TrackingStatus"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TrackingStatus"]);
                        item.InvoiceNumber = sqlDataReader["InvoiceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["InvoiceNumber"]);
                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);
                        if (item.payementmode == 1)
                        {
                            item.PayementModeType = "Cash";
                        }
                        else { item.PayementModeType = "Card"; }

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

        #endregion
    }
}
