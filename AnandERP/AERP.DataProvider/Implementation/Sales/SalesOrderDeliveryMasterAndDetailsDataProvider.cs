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
    public class SalesOrderDeliveryMasterAndDetailsDataProvider : DBInteractionBase, ISalesOrderDeliveryMasterAndDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalesOrderDeliveryMasterAndDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalesOrderDeliveryMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from SalesOrderDeliveryMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetSalesOrderDeliveryMasterAndDetailsBySearch(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderDeliveryMasterAndDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiSOStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SOStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMonthName", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MonthName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMonthYear", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MonthYear));

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
                    baseEntityCollection.CollectionResponse = new List<SalesOrderDeliveryMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesOrderDeliveryMasterAndDetails item = new SalesOrderDeliveryMasterAndDetails();

                        item.SalesOrderMasterID = sqlDataReader["SalesOrderMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["SalesOrderMasterID"]);
                        item.SalesOrderDate = sqlDataReader["SalesOrderDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderDate"]);
                        item.SalesOrderNumber = sqlDataReader["SalesOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderNumber"]);
                        item.DeliveryNumber = sqlDataReader["DeliveryNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryNumber"]);
                        item.DeliveryTransDate = sqlDataReader["DeliveryTransDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryTransDate"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.SalesOrderDeliveryMasterID = sqlDataReader["SalesOrderDeliveryMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["SalesOrderDeliveryMasterID"]);
                        item.IsLocked = sqlDataReader["IsLocked"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsLocked"]);
                        item.DispatchedQuantity = sqlDataReader["DispatchedQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DispatchedQuantity"]);
                        item.SalesOrderDeliveryMasterID = sqlDataReader["SalesOrderDeliveryMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["SalesOrderDeliveryMasterID"]);
                        item.IsInvoiced = sqlDataReader["IsInvoiced"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsInvoiced"]);

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
                        throw new Exception("Stored Procedure 'USP_SalesOrderDeliveryMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetSalesOrderDeliveryMasterAndDetailsSearchList(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderDeliveryMasterAndDetails_GetListForDropDown";
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
                    baseEntityCollection.CollectionResponse = new List<SalesOrderDeliveryMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesOrderDeliveryMasterAndDetails item = new SalesOrderDeliveryMasterAndDetails();
                        //item.ID = Convert.ToInt16(sqlDataReader["SalesOrderDeliveryMasterAndDetailsID"]);
                        //item.CompanyName = sqlDataReader["CompanyName"].ToString();
                        // item.MarchandiseGroupCode = Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesOrderDeliveryMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> GetSalesOrderDeliveryMasterAndDetailsByID(SalesOrderDeliveryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> response = new BaseEntityResponse<SalesOrderDeliveryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderDeliveryMasterAndDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        SalesOrderDeliveryMasterAndDetails _item = new SalesOrderDeliveryMasterAndDetails();
                        _item.SalesOrderDeliveryMasterID = Convert.ToInt32(sqlDataReader["SalesOrderDeliveryMasterID"]);
                        _item.DeliveryNumber = sqlDataReader["DeliveryNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryNumber"]);
                        _item.DeliveryTransDate = sqlDataReader["DeliveryTransDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryTransDate"]);
                        _item.SalesOrderDeliveryDetailsID = sqlDataReader["SalesOrderDeliveryDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalesOrderDeliveryDetailsID"]);
                        _item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        _item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        _item.DispatchedQuantity = sqlDataReader["DispatchedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DispatchedQuantity"]);
                        _item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        _item.SalesUomCode = sqlDataReader["SalesUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesUomCode"]);
                        _item.BaseUOMCode = sqlDataReader["BaseUOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        _item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        _item.LocationName = sqlDataReader["DispatchedLocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DispatchedLocationName"]);
                        _item.BatchNumber = sqlDataReader["BatchNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BatchNumber"]);
                        _item.IsLocked = sqlDataReader["IsLocked"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsLocked"]);
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
        public IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> InsertSalesOrderDeliveryMasterAndDetails(SalesOrderDeliveryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> response = new BaseEntityResponse<SalesOrderDeliveryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderDeliveryMasterAndDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesOrderMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.SalesOrderMasterID));
                    if (item.DeliveryTransDate != "" || item.DeliveryTransDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtDeliveryTransDate", SqlDbType.DateTime, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.DeliveryTransDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtDeliveryTransDate", SqlDbType.DateTime, 50,
                                                                        ParameterDirection.Input, false, 10, 0, "",
                                                                        DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLocked", SqlDbType.Bit, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.IsLocked));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iShipToCountryID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ShipToCountryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iShipToCityID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ShipToCityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siShipToStateID", SqlDbType.SmallInt, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ShipToStateID));

                    if (item.ShipToAddress == "" || item.ShipToAddress == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsShipToAddress", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsShipToAddress", SqlDbType.NVarChar, 50,
                                                                        ParameterDirection.Input, false, 10, 0, "",
                                                                        DataRowVersion.Proposed, item.ShipToAddress));
                    }
                    if (item.VehicalNumber == "" || item.VehicalNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsVehicalNumber", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsVehicalNumber", SqlDbType.NVarChar, 50,
                                                                        ParameterDirection.Input, false, 10, 0, "",
                                                                        DataRowVersion.Proposed, item.VehicalNumber));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralShipperID", SqlDbType.Int, 4,
                                          ParameterDirection.Input, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.GeneralShipperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFrieghtCharges", SqlDbType.Money, 4,
                                          ParameterDirection.Input, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.FrieghtCharges));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biSaleMasterID", SqlDbType.BigInt, 4,
                                         ParameterDirection.Input, true, 10, 0, "",
                                         DataRowVersion.Proposed, item.SaleMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.BigInt, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.GeneralUnitsID));

                    if (item.XmlString != "" || item.XmlString != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xDMXmlDetails", SqlDbType.Xml, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.XmlString));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xDMXmlDetails", SqlDbType.Xml, 0,
                                                                        ParameterDirection.Input, false, 10, 0, "",
                                                                        DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.TransportationMode != "" && item.TransportationMode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTransportationMode", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.TransportationMode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTransportationMode", SqlDbType.NVarChar, 100,
                                                                        ParameterDirection.Input, false, 10, 0, "",
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iSalesOrderDeliveryMasterAndDetailsID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;


                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesOrderDeliveryMasterAndDetails_Insert' reported the ErrorCode: " +
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

        public IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> InsertSalesOrderDeliveryMasterAndDetailsForDirectDM(SalesOrderDeliveryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> response = new BaseEntityResponse<SalesOrderDeliveryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderDeliveryMasterAndDetails_InsertXMLForDirectDM";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if (item.DeliveryTransDate != "" || item.DeliveryTransDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtDeliveryTransDate", SqlDbType.DateTime, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.DeliveryTransDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtDeliveryTransDate", SqlDbType.DateTime, 50,
                                                                        ParameterDirection.Input, false, 10, 0, "",
                                                                        DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iShipToCountryID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ShipToCountryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iShipToCityID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ShipToCityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siShipToStateID", SqlDbType.SmallInt, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ShipToStateID));

                    if (item.ShipToAddress == "" || item.ShipToAddress == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsShipToAddress", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsShipToAddress", SqlDbType.NVarChar, 50,
                                                                        ParameterDirection.Input, false, 10, 0, "",
                                                                        DataRowVersion.Proposed, item.ShipToAddress));
                    }
                    if (item.VehicalNumber == "" || item.VehicalNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsVehicalNumber", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsVehicalNumber", SqlDbType.NVarChar, 50,
                                                                        ParameterDirection.Input, false, 10, 0, "",
                                                                        DataRowVersion.Proposed, item.VehicalNumber));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralShipperID", SqlDbType.Int, 4,
                                          ParameterDirection.Input, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.GeneralShipperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFrieghtCharges", SqlDbType.Money, 4,
                                          ParameterDirection.Input, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.FrieghtCharges));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.GeneralUnitsID));

                    if (item.XmlString != "" || item.XmlString != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xDirectDMXmlDetails", SqlDbType.Xml, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.XmlString));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xDirectDMXmlDetails", SqlDbType.Xml, 0,
                                                                        ParameterDirection.Input, false, 10, 0, "",
                                                                        DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4,
                                       ParameterDirection.Input, true, 10, 0, "",
                                       DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iContactPersonID", SqlDbType.Int, 4,
                                       ParameterDirection.Input, true, 10, 0, "",
                                       DataRowVersion.Proposed, item.ContactPersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4,
                                       ParameterDirection.Input, true, 10, 0, "",
                                       DataRowVersion.Proposed, item.CustomerMasterID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@mNetAmount", SqlDbType.Money, 8,
                                       ParameterDirection.Input, true, 10, 0, "",
                                       DataRowVersion.Proposed, item.TotalAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 8,
                                                           ParameterDirection.Input, true, 10, 0, "",
                                                           DataRowVersion.Proposed, item.TotalTaxAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalGrossAmount", SqlDbType.Money, 8,
                                                           ParameterDirection.Input, true, 10, 0, "",
                                                           DataRowVersion.Proposed, item.TotalBillAmount));

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
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iSalesOrderDeliveryMasterAndDetailsID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;


                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesOrderDeliveryMasterAndDetails_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of SalesOrderDeliveryMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> UpdateSalesOrderDeliveryMasterAndDetails(SalesOrderDeliveryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> response = new BaseEntityResponse<SalesOrderDeliveryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderDeliveryMasterAndDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.SalesOrderDeliveryMasterID));
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
                        throw new Exception("Stored Procedure 'dbo.USP_SalesOrderDeliveryMasterAndDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of SalesOrderDeliveryMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> DeleteSalesOrderDeliveryMasterAndDetails(SalesOrderDeliveryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> response = new BaseEntityResponse<SalesOrderDeliveryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderDeliveryMasterAndDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SalesOrderDeliveryMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.DeletedBy));
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
                        throw new Exception("Stored Procedure 'USP_SalesOrderDeliveryMasterAndDetails_Delete' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetDeliveryMemoListBySalesOrder(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetSalesOrderDeliveryMasterRecordBySaleMasterID";
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
                    baseEntityCollection.CollectionResponse = new List<SalesOrderDeliveryMasterAndDetails>();
                    decimal NetAmount = 0, TotalAmount = 0;
                    while (sqlDataReader.Read())
                    {
                        SalesOrderDeliveryMasterAndDetails item = new SalesOrderDeliveryMasterAndDetails();

                        item.SalesOrderDetailsID = sqlDataReader["SalesOrderDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalesOrderDetailsID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.SalesUomCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.ReceivedQuantity = sqlDataReader["ReceivedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ReceivedQuantity"]);
                        item.DispatchedQuantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.LocationID = sqlDataReader["IssueFromLocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["IssueFromLocationID"]);
                        item.RemainingQuantity = 0;
                        item.LocationName = sqlDataReader["StoragelocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StoragelocationName"]);


                        item.Discount = sqlDataReader["Discount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Discount"]);
                        item.Freight = sqlDataReader["Freight"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling = sqlDataReader["ShippingHandling"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ShippingHandling"]);
                        item.SalesOrderNumber = sqlDataReader["SalesOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderNumber"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.GenTaxGroupMasterID = sqlDataReader["GeneralTaxGroupMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralTaxGroupMasterID"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);

                        TotalAmount = item.DispatchedQuantity * item.Rate;
                        item.TaxableAmount = Math.Round((item.DispatchedQuantity * item.Rate), 2);
                        item.TaxAmount = Math.Round((item.TaxableAmount * item.TaxRate) / 100, 2);
                        item.NetAmount = Math.Round(item.TaxAmount + item.TaxableAmount, 2);


                        item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.TotalBillAmount = sqlDataReader["TotalBillAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalBillAmount"]);
                        //item.TotalAmount= Math.Round(item.TotalTaxAmount + item.TotalBillAmount, 2);

                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        item.SerialAndBatchManagedBy = sqlDataReader["SerialAndBatchManagedBy"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SerialAndBatchManagedBy"]);
                        item.ConversionFactor = sqlDataReader["ConversionFactor"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ConversionFactor"]);
                        item.BaseUoMReceivedQuantity = sqlDataReader["BaseUoMReceivedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BaseUoMReceivedQuantity"]);
                        item.CurrentStockQty = sqlDataReader["CurrentStockQty"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CurrentStockQty"]);
                        item.PurchaseUOMConversion = sqlDataReader["PurchaseUOMConversion"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchaseUOMConversion"]);
                        item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesOrderDeliveryMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetDeliveryMemoDetailsByID(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesOrderDeliveryMasterAndDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalesOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesOrderDeliveryMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesOrderDeliveryMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesOrderDeliveryMasterAndDetails _item = new SalesOrderDeliveryMasterAndDetails();

                        _item.SalesOrderDeliveryMasterID = Convert.ToInt32(sqlDataReader["SalesOrderDeliveryMasterID"]);
                        _item.DeliveryNumber = sqlDataReader["DeliveryNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryNumber"]);
                        _item.DeliveryTransDate = sqlDataReader["DeliveryTransDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryTransDate"]);
                        _item.SalesOrderDeliveryDetailsID = sqlDataReader["SalesOrderDeliveryDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalesOrderDeliveryDetailsID"]);
                        _item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        _item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        _item.DispatchedQuantity = sqlDataReader["DispatchedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DispatchedQuantity"]);
                        _item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        _item.SalesUomCode = sqlDataReader["SalesUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesUomCode"]);
                        _item.BaseUOMCode = sqlDataReader["BaseUOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        _item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        _item.LocationName = sqlDataReader["DispatchedLocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DispatchedLocationName"]);
                        _item.BatchNumber = sqlDataReader["BatchNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BatchNumber"]);
                        _item.IsLocked = sqlDataReader["IsLocked"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsLocked"]);
                        _item.IsInvoiced = sqlDataReader["IsInvoiced"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsInvoiced"]);
                        _item.IsDeleted = sqlDataReader["IsDeleted"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        _item.IsCancelled = sqlDataReader["IsCancelled"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsCancelled"]);


                        baseEntityCollection.CollectionResponse.Add(_item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesOrderDeliveryMasterAndDetails_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetRecordForSaleseOrderDeliveryMemoPDF(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetRecordForSalesOrderDeliveryMemoPDF";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalesOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesOrderDeliveryMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesOrderDeliveryMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesOrderDeliveryMasterAndDetails _item = new SalesOrderDeliveryMasterAndDetails();
                        _item.DeliveryNumber = sqlDataReader["DeliveryNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryNumber"]);
                        _item.DeliveryTransDate = sqlDataReader["DeliveryTransDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryTransDate"]);
                        _item.DispatchedQuantity = sqlDataReader["DispatchedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DispatchedQuantity"]);
                        _item.SalesOrderQuantity = sqlDataReader["SalesOrderQty"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SalesOrderQty"]);
                        _item.SalesUomCode = sqlDataReader["SalesUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesUomCode"]);
                        _item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        _item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        _item.HSNCode = sqlDataReader["HSNCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSNCode"]);
                        _item.Rate = sqlDataReader["Rate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Rate"]);
                        _item.LocationName = sqlDataReader["DispatchedLocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DispatchedLocationName"]);
                        _item.BatchNumber = sqlDataReader["BatchNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BatchNumber"]);
                        _item.ExpiryDate = sqlDataReader["ExpiryDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExpiryDate"]);


                        _item.CountryName = sqlDataReader["CountryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CountryName"]);
                        _item.StateName = sqlDataReader["Statename"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Statename"]);
                        _item.CityName = sqlDataReader["CityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CityName"]);
                        _item.BranchCountryName = sqlDataReader["BranchCountryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchCountryName"]);
                        _item.BranchStateName = sqlDataReader["BranchStateName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchStateName"]);
                        _item.BranchCityName = sqlDataReader["BranchCityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchCityName"]);
                        _item.CellPhone = sqlDataReader["CellPhone"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CellPhone"]);
                        _item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);
                        _item.EmailID = sqlDataReader["EmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmailID"]);
                        _item.FaxNumber = sqlDataReader["FaxNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FaxNumber"]);
                        _item.PhoneNumberOffice = sqlDataReader["PhoneNumberOffice"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PhoneNumberOffice"]);
                        _item.CentreAddress1 = sqlDataReader["Address1"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Address1"]);
                        _item.CentreAddress2 = sqlDataReader["Address2"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Address2"]);

                        _item.Website = sqlDataReader["Website"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Website"]);
                        _item.NetAmount = sqlDataReader["ItemWiseAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ItemWiseAmount"]);
                        _item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        _item.TaxAmount = sqlDataReader["TaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxAmount"]);
                        _item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        _item.TaxGroupName = sqlDataReader["TaxGroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);
                        _item.TaxList = sqlDataReader["TaxList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxList"]);
                        _item.TaxRateList = sqlDataReader["TaxRateList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxRateList"]);
                        _item.GenTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["GenTaxGroupMasterID"]);
                        _item.IsOther = sqlDataReader["IsOther"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsOther"]);
                        _item.IsDeleted = sqlDataReader["IsDeleted"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        _item.LogoPath = sqlDataReader["LogoPath"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LogoPath"]);

                        _item.BranchName = sqlDataReader["BranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchName"]);
                        _item.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        _item.CustomerAddress = sqlDataReader["CustomerAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerAddress"]);
                        _item.CustomerBranchAddress = sqlDataReader["CustomerBranchAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchAddress"]);
                        _item.CustomerGSTNumber = sqlDataReader["CustomerGSTNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerGSTNumber"]);
                        _item.BranchGSTNumber = sqlDataReader["BranchGSTNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchGSTNumber"]);
                        _item.SalesOrderNumber = sqlDataReader["SalesOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesOrderNumber"]);
                        _item.VehicalNumber = sqlDataReader["VehicalNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VehicalNumber"]);
                        _item.ShipperName = sqlDataReader["ShipperName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ShipperName"]);
                        _item.ShipToAddress = sqlDataReader["ShipToAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ShipToAddress"]);
                        _item.CustomerPinCode = sqlDataReader["CustomerPinCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerPinCode"]);
                        _item.CustomerBranchPinCode = sqlDataReader["CustomerBranchPinCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchPinCode"]);
                        _item.StateCode = sqlDataReader["StateCode"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["StateCode"]);
                        _item.BranchStateCode = sqlDataReader["BranchStateCode"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["BranchStateCode"]);
                        _item.CINNumber = sqlDataReader["CINNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CINNumber"]);
                        _item.ESICNumber = sqlDataReader["ESICNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ESICNumber"]);
                        _item.GSTINNumber = sqlDataReader["GSTINNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GSTINNumber"]);
                        _item.PanNumber = sqlDataReader["PanNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PanNumber"]);
                        _item.PFNumber = sqlDataReader["PFNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PFNumber"]);
                        _item.PrintingLineBelowLogo = sqlDataReader["PrintingLineBelowLogo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLineBelowLogo"]);
                        _item.CentreSpecialization = sqlDataReader["CentreSpecialization"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreSpecialization"]);
                        _item.TransportationMode = sqlDataReader["TransportationMode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransportationMode"]);
                        _item.PurchaseOrderNumberClient = sqlDataReader["PurchaseOrderNumberClient"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderNumberClient"]);
                        baseEntityCollection.CollectionResponse.Add(_item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesOrderDeliveryMasterAndDetails_SelectOne' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetDeliveryMemoNumberSearchList_ForSaleContract(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetDeliveryMemoNumberSearchList_ForSaleContract";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractBillingSpanID));

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
                    baseEntityCollection.CollectionResponse = new List<SalesOrderDeliveryMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesOrderDeliveryMasterAndDetails item = new SalesOrderDeliveryMasterAndDetails();

                        item.DeliveryNumber = sqlDataReader["DeliveryNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryNumber"]);
                        item.SalesOrderDeliveryMasterID = sqlDataReader["SalesOrderDeliveryMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["SalesOrderDeliveryMasterID"]);
                        item.IsInvoiced = sqlDataReader["IsInvoiced"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsInvoiced"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesOrderDeliveryMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
