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
    public class SalesEnquiryMasterAndDetailsDataProvider : DBInteractionBase, ISalesEnquiryMasterAndDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalesEnquiryMasterAndDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalesEnquiryMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from SalesEnquiryMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetSalesEnquiryMasterAndDetailsBySearch(SalesEnquiryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesEnquiryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesEnquiryMasterAndDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //---------------- INPUT PARAMETER--------------------//
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    if(searchRequest.TransactionDate==""|| searchRequest.TransactionDate==null)
                    { 
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.NVarChar,35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TransactionDate));
                    }
                    //---------------- OUTPUT PARAMETER--------------------//                    
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
                    baseEntityCollection.CollectionResponse = new List<SalesEnquiryMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesEnquiryMasterAndDetails item = new SalesEnquiryMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["EnquiryNumber"]) == false)
                        {
                            item.EnquiryNumber = Convert.ToString(sqlDataReader["EnquiryNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SalesEnquiryMasterID"]) == false)
                        {
                            item.SalesEnquiryMasterID = Convert.ToInt32(sqlDataReader["SalesEnquiryMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerMasterID"]) == false)
                        {
                            item.CustomerMasterID = Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerBranchMasterID"]) == false)
                        {
                            item.CustomerBranchMasterID = Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ContactPersonID"]) == false)
                        {
                            item.ContactPersonID = Convert.ToInt16(sqlDataReader["ContactPersonID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Status"]) == false)
                        {
                            item.Status = Convert.ToByte(sqlDataReader["Status"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StatusMode"]) == false)
                        {
                            item.StatusMode = Convert.ToByte(sqlDataReader["StatusMode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReferenceBy"]) == false)
                        {
                            item.ReferenceBy = Convert.ToByte(sqlDataReader["ReferenceBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerMasterName"]) == false)
                        {
                            item.CustomerMasterName = Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerContactPersonName"]) == false)
                        {
                            item.CustomerContactPersonName = Convert.ToString(sqlDataReader["CustomerContactPersonName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BranchName"]) == false)
                        {
                            item.CustomerBranchMasterName = Convert.ToString(sqlDataReader["BranchName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SalesQuotationMasterID"]) == false)
                        {
                            item.SalesQuotationMasterID = Convert.ToInt16(sqlDataReader["SalesQuotationMasterID"]);
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
                        throw new Exception("Stored Procedure 'USP_SalesEnquiryMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> GetSalesEnquiryMasterAndDetailsByID(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> response = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerBranchMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iSalesEnquiryMasterAndDetailsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalesEnquiryMasterAndDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerBranchMasterID));
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
                        SalesEnquiryMasterAndDetails _item = new SalesEnquiryMasterAndDetails();
                        _item.CustomerBranchMasterID = Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);

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
        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> response = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesEnquiryMasterAndDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CustomerMasterID));
                    if (item.CustomerBranchMasterID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@siContactPersonID", SqlDbType.SmallInt, 4,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.ContactPersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xSalesEnquiryDetailsXML", SqlDbType.Xml, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.XmlString));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0,
                                         ParameterDirection.Input, true, 10, 0, "",
                                         DataRowVersion.Proposed, item.TransactionDate));
                    if (item.ReferenceBy != 0 || item.ReferenceBy != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiReferenceBy", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ReferenceBy));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiReferenceBy", SqlDbType.TinyInt, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalesEnquiryMasterAndDetails_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of SalesEnquiryMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> UpdateSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> response = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesEnquiryMasterAndDetails_UpdateXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.SalesEnquiryMasterID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@xSalesEnquirymasteranddetailsUpdateXml", SqlDbType.Xml, 0,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.XmlString));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModifiedBy));
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalesEnquiryMasterAndDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of SalesEnquiryMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> DeleteSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> response = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesEnquiryMasterAndDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Input, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.SalesEnquiryMasterAndDetailsID));
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
                    //  item.SalesEnquiryMasterAndDetailsID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalesEnquiryMasterAndDetails_Delete' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetSalesEnquiryMasterAndDetailsSearchList(SalesEnquiryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesEnquiryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesEnquiryMasterAndDetails_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<SalesEnquiryMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesEnquiryMasterAndDetails item = new SalesEnquiryMasterAndDetails();
                        //item.SalesEnquiryMasterAndDetailsID = sqlDataReader["SalesEnquiryMasterAndDetailsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalesEnquiryMasterAndDetailsID"]);
                        //item.SalesEnquiryMasterAndDetailsName = sqlDataReader["SalesEnquiryMasterAndDetailsName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesEnquiryMasterAndDetailsName"]);
                        //item.CustomerType = sqlDataReader["CustomerType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CustomerType"]);
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesEnquiryMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetCustomerBranchMasterSearchList(SalesEnquiryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesEnquiryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerBranchMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesEnquiryMasterAndDetailsID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalesEnquiryMasterAndDetailsID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesEnquiryMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesEnquiryMasterAndDetails item = new SalesEnquiryMasterAndDetails();
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        // item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesEnquiryMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetailsContactDetails(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> response = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerContactDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //if (item.CustomerBranchMasterID != 0)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4,
                    //                            ParameterDirection.Input, false, 10, 0, "",
                    //                           DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                       DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //cmdToExecute.Parameters.Add(new SqlParameter("@xCustomerContactDetailsXml", SqlDbType.Xml, 0,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.XmlString));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSalesEnquiryMasterAndDetailsID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.SalesEnquiryMasterAndDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModifiedBy));
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
                        //   item.SalesEnquiryMasterAndDetailsID = (Int32)cmdToExecute.Parameters["@iSalesEnquiryMasterAndDetailsID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalesEnquiryMasterAndDetails_INSERT' reported the ErrorCode: " +
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
        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetailsBranchDetails(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> response = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesEnquiryMasterAndDetailsBranchDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSalesEnquiryMasterAndDetailsID", SqlDbType.Int, 4,
                    //                            ParameterDirection.Input, false, 10, 0, "",
                    //                            DataRowVersion.Proposed, item.SalesEnquiryMasterAndDetailsID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsMainBranch", SqlDbType.Bit, 0,
                    //                          ParameterDirection.Input, false, 10, 0, "",
                    //                          DataRowVersion.Proposed, item.IsMainBranch));
                    //if (item.Address1 != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.Address1));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, DBNull.Value));

                    //}
                    //if (item.Address2 != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.Address2));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, DBNull.Value));

                    //}
                    //if (item.Address3 != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.Address3));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, DBNull.Value));

                    //}
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.SmallInt, 4,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.CountryID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStateID", SqlDbType.SmallInt, 4,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.StateID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.CityID));

                    //if (item.GSTNumber != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsGSTNumber", SqlDbType.NVarChar, 50,
                    //                                   ParameterDirection.Input, true, 10, 0, "",
                    //                                   DataRowVersion.Proposed, item.GSTNumber));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsGSTNumber", SqlDbType.NVarChar, 50,
                    //                                   ParameterDirection.Input, true, 10, 0, "",
                    //                                   DataRowVersion.Proposed, DBNull.Value));
                    //}

                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsTaxExempted", SqlDbType.Bit, 0,
                    //                              ParameterDirection.Input, false, 10, 0, "",
                    //                              DataRowVersion.Proposed, item.IsTaxExempted));
                    //if (item.ReasonForExemption != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiReasonForExemption", SqlDbType.TinyInt, 4,
                    //                                  ParameterDirection.Input, false, 10, 0, "",
                    //                                  DataRowVersion.Proposed, item.ReasonForExemption));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiReasonForExemption", SqlDbType.TinyInt, 4,
                    //                              ParameterDirection.Input, false, 10, 0, "",
                    //                              DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //if (item.BankName != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30,
                    //                              ParameterDirection.Input, true, 10, 0, "",
                    //                              DataRowVersion.Proposed, item.BankName));

                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30,
                    //                                  ParameterDirection.Input, true, 10, 0, "",
                    //                                  DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //if (item.IFCICODE != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsIFCICODE", SqlDbType.NVarChar, 15,
                    //                                  ParameterDirection.Input, true, 10, 0, "",
                    //                                  DataRowVersion.Proposed, item.IFCICODE));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsIFCICODE", SqlDbType.NVarChar, 15,
                    //                              ParameterDirection.Input, true, 10, 0, "",
                    //                              DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //if (item.BankAccountNumber != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAccountNumber", SqlDbType.NVarChar, 25,
                    //                                  ParameterDirection.Input, true, 10, 0, "",
                    //                                  DataRowVersion.Proposed, item.BankAccountNumber));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAccountNumber", SqlDbType.NVarChar, 25,
                    //                                 ParameterDirection.Input, true, 10, 0, "",
                    //                                 DataRowVersion.Proposed, DBNull.Value));

                    //}
                    //if (item.CreditPeriod != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriod", SqlDbType.TinyInt, 4,
                    //                                  ParameterDirection.Input, false, 10, 0, "",
                    //                                  DataRowVersion.Proposed, item.CreditPeriod));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriod", SqlDbType.TinyInt, 4,
                    //                              ParameterDirection.Input, false, 10, 0, "",
                    //                              DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //if (item.UnitMasterId != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiUnitMasterID", SqlDbType.TinyInt, 4,
                    //                                  ParameterDirection.Input, false, 10, 0, "",
                    //                                  DataRowVersion.Proposed, item.UnitMasterId));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiUnitMasterID", SqlDbType.TinyInt, 4,
                    //                              ParameterDirection.Input, false, 10, 0, "",
                    //                              DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //if (item.CustomerBranchMasterName != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerBranchMasterName", SqlDbType.NVarChar, 50,
                    //                             ParameterDirection.Input, false, 10, 0, "",
                    //                             DataRowVersion.Proposed, item.CustomerBranchMasterName));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerBranchMasterName", SqlDbType.NVarChar, 50,
                    //                         ParameterDirection.Input, false, 10, 0, "",
                    //                         DataRowVersion.Proposed, DBNull.Value));
                    //}

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
                    if (_rowsAffected > 0)
                    {
                        //     item.SalesEnquiryMasterAndDetailsID = (Int32)cmdToExecute.Parameters["@iSalesEnquiryMasterAndDetailsID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalesEnquiryMasterAndDetails_INSERT' reported the ErrorCode: " +
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


        public IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetEnquiryDetailsByID(SalesEnquiryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesEnquiryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesEnquiryMasterandDetails_GetbyMasterID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesEnquiryMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalesEnquiryMasterAndDetailsID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesEnquiryMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesEnquiryMasterAndDetails item = new SalesEnquiryMasterAndDetails();
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.SaleEnquiryDetailsID = sqlDataReader["SaleEnquiryDetailsID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["SaleEnquiryDetailsID"]);
                        item.ItemDescription= sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.UOM = sqlDataReader["UOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOM"]);
                        item.Quantity= sqlDataReader["Quantity"] is DBNull ? new decimal(): Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["TransactionDate"]);
                        item.ReferenceBy = sqlDataReader["ReferenceBy"] is DBNull ?new byte(): Convert.ToByte(sqlDataReader["ReferenceBy"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        item.CustomerContactPersonName = sqlDataReader["CustomerContactPersonName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerContactPersonName"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesEnquiryMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
