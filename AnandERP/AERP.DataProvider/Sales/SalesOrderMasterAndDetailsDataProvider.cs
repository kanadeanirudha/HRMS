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
    public class SalesOrderMasterAndDetailsDataProvider : DBInteractionBase, ISalesOrderMasterAndDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalesOrderMasterAndDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalesOrderMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from SalesOrderMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetSalesOrderMasterAndDetailsBySearch(SalesOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderMasterAndDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalesOrderDate));



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
                    baseEntityCollection.CollectionResponse = new List<SalesOrderMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesOrderMasterAndDetails item = new SalesOrderMasterAndDetails();

                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        item.ContactPersonID = sqlDataReader["ContactPersonID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["ContactPersonID"]);
                        item.QuotationNumber = sqlDataReader["QuotationNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["QuotationNumber"]);
                        item.SalesQuotationMasterID = sqlDataReader["SalesQuotationMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["SalesQuotationMasterID"]);
                        item.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["CustomerName"]);
                        item.SalesOrderNumber = sqlDataReader["SalesOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderNumber"]);
                        item.SalesOrderMasterID = sqlDataReader["SalesOrderMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["SalesOrderMasterID"]);
                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        item.Status = sqlDataReader["Status"] is DBNull ? new byte(): Convert.ToByte(sqlDataReader["Status"]);

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
                        throw new Exception("Stored Procedure 'USP_SalesOrderMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetSalesOrderMasterAndDetailsSearchList(SalesOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderMasterAndDetails_GetDropDownForPriceGroupCode";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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
                    baseEntityCollection.CollectionResponse = new List<SalesOrderMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesOrderMasterAndDetails item = new SalesOrderMasterAndDetails();
                     //   item.ID = Convert.ToInt16(sqlDataReader["SalesOrderMasterAndDetailsID"]);
                        //item.SalesOrderMasterAndDetailsCode = sqlDataReader["SalesOrderMasterAndDetailsCode"].ToString();
                        //item.SalesOrderMasterAndDetailsDescription = Convert.ToString(sqlDataReader["SalesOrderMasterAndDetailsDescription"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesOrderMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalesOrderMasterAndDetails> GetSalesOrderMasterAndDetailsByID(SalesOrderMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderMasterAndDetails> response = new BaseEntityResponse<SalesOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderMasterAndDetails_SelectOne";
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
                        SalesOrderMasterAndDetails _item = new SalesOrderMasterAndDetails();
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
        public IBaseEntityResponse<SalesOrderMasterAndDetails> InsertSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderMasterAndDetails> response = new BaseEntityResponse<SalesOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderMasterAndDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                   cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesQuotationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iContactPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContactPersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtSalesOrderDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
                    if (item.PurchaseOrderNumberClient != "" || item.PurchaseOrderNumberClient != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumberClient", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PurchaseOrderNumberClient));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumberClient", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalTaxAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFreight", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Freight));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mShippingHandling", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ShippingHandling));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mDiscount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTradeIn", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Tradein));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fTotalPOAmount", SqlDbType.Float, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fRoundOffAmount", SqlDbType.Float, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));
                    
                    if (item.XmlString != "" || item.XmlString != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XSalesorderDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XmlString));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XSalesorderDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    
                    //Addition to sales order
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iSalesOrderMasterAndDetailsID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_SalesOrderMasterAndDetails_Insert' reported the ErrorCode: " +
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
                        throw new Exception("Stored Procedure 'USP_SalesOrderMasterAndDetails_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of SalesOrderMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderMasterAndDetails> UpdateSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderMasterAndDetails> response = new BaseEntityResponse<SalesOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderMasterAndDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterName", SqlDbType.NVarChar, 60,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterCode", SqlDbType.NVarChar,20,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterCode));

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
                        throw new Exception("Stored Procedure 'dbo.USP_SalesOrderMasterAndDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of SalesOrderMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderMasterAndDetails> DeleteSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderMasterAndDetails> response = new BaseEntityResponse<SalesOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralOrderingDaysCode_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Input, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.ID));
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
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesOrderMasterAndDetails_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetDropDownListForSalesOrderMasterAndDetails(SalesOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralOrderingDaysCode_GetListForDropDown";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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
                    baseEntityCollection.CollectionResponse = new List<SalesOrderMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesOrderMasterAndDetails item = new SalesOrderMasterAndDetails();
                        //item.ID = Convert.ToInt16(sqlDataReader["GeneralOrderingDaysCodeID"]);
                        //item.code = Convert.ToString(sqlDataReader["Code"]);
                        //item.OrderingDay = Convert.ToString(sqlDataReader["OrderingDay"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesOrderMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetRecordForSaleseOrderPDF(SalesOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetRecordForSalesOrderPDF";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalesOrderMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesOrderMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesOrderMasterAndDetails item = new SalesOrderMasterAndDetails();
                        item.SalesOrderMasterID = sqlDataReader["SalesOrderMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalesOrderMasterID"]);
                        item.SalesOrderDate = sqlDataReader["SalesOrderDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderDate"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);

                        item.TotalAmount=sqlDataReader["TotalPOAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalPOAmount"]);
                        item.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        item.SalesOrderNumber = sqlDataReader["SalesOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderNumber"]);
                        item.Rate = sqlDataReader["Rate"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.Quantity = sqlDataReader["Quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.IssueFromLocationID = sqlDataReader["IssueFromLocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["IssueFromLocationID"]);
                        item.LocationName = sqlDataReader["LocationName"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.BarCode = sqlDataReader["BarCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.UOM = sqlDataReader["UomCode"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUomQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["BaseUomQuantity"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);

                       
                        item.Freight = sqlDataReader["Freight"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling = sqlDataReader["ShippingHandling"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ShippingHandling"]);
                        item.Discount = sqlDataReader["Discount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Discount"]);

                        item.CustomerAddress = sqlDataReader["CustomerAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerAddress"]);
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
                        item.NetAmount=sqlDataReader["ItemWiseAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ItemWiseAmount"]);
                        item.HSNCode = sqlDataReader["HSNCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSNCode"]);
                        item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.TaxAmount = sqlDataReader["TaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxAmount"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);
                        item.IsOther=sqlDataReader["IsOther"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsOther"]);
                        item.IsDeleted = sqlDataReader["IsDeleted"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        item.LogoPath = sqlDataReader["LogoPath"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LogoPath"]);

                        item.CustomerGSTNumber = sqlDataReader["CustomerGSTNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerGSTNumber"]);
                        item.BranchGSTNumber = sqlDataReader["BranchGSTNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchGSTNumber"]);
                        item.CustomerBranchMasterName = sqlDataReader["BranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchName"]);
                        item.QuotationNumber = sqlDataReader["QuotationNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["QuotationNumber"]);
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
        public IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> ViewSalesOrderMasterDetailsListBySalesOrderMasterID(SalesOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesOrderMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderMaster_ViewDetailsofSalesOrder";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalesOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchaMsterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerBranchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesOrderMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesOrderMasterAndDetails item = new SalesOrderMasterAndDetails();
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.PurchaseOrderNumberClient = sqlDataReader["PurchaseOrderNumberClient"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderNumberClient"]);
                        item.TotalBillAmount = sqlDataReader["TotalPOAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalPOAmount"]);
                        item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);

                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.UOM = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        item.CustomerBranchMasterName = sqlDataReader["BranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchName"]);
                        item.ContactPersonName = sqlDataReader["ContactPersonName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContactPersonName"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Rate"]);

                      //  item.TaxableAmount = sqlDataReader["TaxableAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxableAmount"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.Freight = sqlDataReader["Freight"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling= sqlDataReader["ShippingHandling"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ShippingHandling"]);
                        item.Tradein= sqlDataReader["Tradein"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Tradein"]);
                        item.Discount = sqlDataReader["Discount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Discount"]);
                        item.TaxAmount = sqlDataReader["TaxAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxAmount"]);
                        item.GeneralTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterId"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["GenTaxGroupMasterId"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesOrderMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
