
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
    public class PurchaseGRNMasterDataProvider : DBInteractionBase, IPurchaseGRNMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public PurchaseGRNMasterDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public PurchaseGRNMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation 

        /// <summary>
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGRNMasterBySearch(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseGRNMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPOStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.POStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<PurchaseGRNMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRNMaster item = new PurchaseGRNMaster();
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseGRNMasterID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["PurchaseGRNMasterID"]);
                        }
                        item.PurchaseOrderMasterID = Convert.ToInt32(sqlDataReader["PurchaseOrderMasterID"]);
                        if (DBNull.Value.Equals(sqlDataReader["GRNNumber"]) == false)
                        {
                            item.GRNNumber = Convert.ToString(sqlDataReader["GRNNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLocked"]) == false)
                        {
                            item.IsLocked = Convert.ToBoolean(sqlDataReader["IsLocked"]);
                        }
                        item.ReceivedQuantity = sqlDataReader["ReceivedQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["ReceivedQuantity"]);
                        item.Quantity = sqlDataReader["PurchaseOrderQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["PurchaseOrderQuantity"]);
                        item.LockedGRNQuantity = sqlDataReader["LockedGRNQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(sqlDataReader["LockedGRNQuantity"]);
                        if (DBNull.Value.Equals(sqlDataReader["GRNIsLockedStatusFlag"]) == false)
                        {
                            item.GRNIsLockedStatusFlag = Convert.ToBoolean(sqlDataReader["GRNIsLockedStatusFlag"]);
                        }

                        item.PurchaseOrderNumber = sqlDataReader["PurchaseOrderNumber"].ToString();
                        item.PurchaseOrderType = Convert.ToInt32(sqlDataReader["PurchaseOrderType"]);
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
                        throw new Exception("Stored Procedure 'USP_PurchaseGRNMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGRNMasterGetBySearchList(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseGRNMaster_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<PurchaseGRNMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRNMaster item = new PurchaseGRNMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.CountryName = sqlDataReader["CountryName"].ToString();
                        //item.ContryCode = sqlDataReader["ContryCode"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseGRNMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from General Region Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> GetPurchaseGRNMasterByID(PurchaseGRNMaster item)
        {
            IBaseEntityResponse<PurchaseGRNMaster> response = new BaseEntityResponse<PurchaseGRNMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseGRNMaster_SelectOne";
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

                        PurchaseGRNMaster _item = new PurchaseGRNMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.CountryName = sqlDataReader["CountryName"].ToString();
                        //_item.ContryCode = sqlDataReader["ContryCode"].ToString();
                        //_item.SeqNo = Convert.ToInt32(sqlDataReader["SeqNo"].ToString());
                        //_item.DefaultFlag = Convert.ToBoolean(sqlDataReader["DefaultFlag"].ToString());
                        //_item.IsUserDefined = Convert.ToBoolean(sqlDataReader["IsUserDefined"]);    
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseGRNMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of General Region Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> InsertPurchaseGRNMaster(PurchaseGRNMaster item)
        {
            IBaseEntityResponse<PurchaseGRNMaster> response = new BaseEntityResponse<PurchaseGRNMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseGRNMaster_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseOrderMasterID", SqlDbType.Int, 0,
                                                                 ParameterDirection.Input, false, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.PurchaseOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtGRNTransDate", SqlDbType.DateTime, 0,
                                                                 ParameterDirection.Input, false, 10, 0, "",
                                                                 DataRowVersion.Proposed, DateTime.UtcNow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPurchaseGRNDetails", SqlDbType.Xml, 0,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.XMLstring));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@xPurchaseVoucherXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLstringForVouchar));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLocked", SqlDbType.Bit, 25,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.IsLocked));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                                                 ParameterDirection.Input, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output,
                                                                 true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                                                 ParameterDirection.Output, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sErrorMessage", SqlDbType.NVarChar, 50,
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
                    item.errorMessage = cmdToExecute.Parameters["@sErrorMessage"].Value.ToString();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != 22)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseGRNMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of General Region Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> UpdatePurchaseGRNMaster(PurchaseGRNMaster item)
        {
            IBaseEntityResponse<PurchaseGRNMaster> response = new BaseEntityResponse<PurchaseGRNMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseGRNMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@nsCountryName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.CountryName.Trim()));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@iSeqNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SeqNo));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sContryCode", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ContryCode.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bDefaultFlag", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DefaultFlag));
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseGRNMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Delete a selected record from General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> DeletePurchaseGRNMaster(PurchaseGRNMaster item)
        {
            IBaseEntityResponse<PurchaseGRNMaster> response = new BaseEntityResponse<PurchaseGRNMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseGRNMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));
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
                        throw new Exception("Stored Procedure 'USP_PurchaseGRNMaster_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseOrderMasterListForGRN(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetPurchaseOrderMasterListForGRN";
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseGRNMaster>();
                    decimal ammount = 0;
                    Random rand = new Random(DateTime.Now.Millisecond);
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRNMaster item = new PurchaseGRNMaster();
                        item.PurchaseOrderMasterID      = sqlDataReader["PurchaseOrderDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseOrderDetailsID"]);
                        //item.ItemID                   = sqlDataReader["ItemID"] is DBNull ? 0                           : Convert.ToInt32(sqlDataReader["ItemID"]);
                        item.ItemNumber                 = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemName                   = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.BarCode                    = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.BaseUOMCode                = sqlDataReader["BaseUOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.OrderUomCode               = sqlDataReader["OrderUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.BaseUOMQuantity            = sqlDataReader["BaseUOMQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.GeneralItemCodeID          = sqlDataReader["GeneralItemCodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        //item.ReceivedQuantity         = sqlDataReader["ReceivedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ReceivedQuantity"]);
                        item.Quantity                   = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.Rate                       = sqlDataReader["Rate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.PriorityFlag               = sqlDataReader["PriorityFlag"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["PriorityFlag"]);
                        if (item.PriorityFlag == 3)
                        {
                            item.Priority = "Low";
                        }
                        else if (item.PriorityFlag == 2)
                        {
                            item.Priority = "Medium";
                        }
                        else if (item.PriorityFlag == 1)
                        {
                            item.Priority = "High";
                        }
                        item.StorageLocationID          = sqlDataReader["StorageLocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StorageLocationID"]);
                        item.ReceivingLocationID        = sqlDataReader["IssueFromLocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["IssueFromLocationID"]);
                        //item.IsLocked                 = Convert.ToBoolean(sqlDataReader["IsLocked"]);
                        item.StorageLocationName        = sqlDataReader["StorageLocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StorageLocationName"]);
                        item.ReceivingLocationName      = sqlDataReader["IssueFromLocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["IssueFromLocationName"]);
                        //item.Remark                   = sqlDataReader["Remark"] is DBNull ? string.Empty                : Convert.ToString(sqlDataReader["Remark"]);
                        //item.GRNNumber                = sqlDataReader["GRNNumber"] is DBNull ? string.Empty             : Convert.ToString(sqlDataReader["GRNNumber"]);
                        // item.Isexpiry                = sqlDataReader["Isexpiry"] is DBNull ? false                     : Convert.ToBoolean(sqlDataReader["Isexpiry"]);
                        item.SerialAndBatchManagedBy    = sqlDataReader["SerialAndBatchManagedBy"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SerialAndBatchManagedBy"]);

                        var qty = Math.Round((item.Quantity),2);
                        var Recived = Math.Round((item.ReceivedQuantity),2);
                        var RemainingReceivedqty = Math.Round((qty - Recived),2);
                        item.RemainingQuantity = 0;

                      
                        item.TotalTaxAmount             = sqlDataReader["TotalTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.Discount                   = sqlDataReader["Discount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Discount"]);
                        item.Freight                    = sqlDataReader["Freight"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Freight"]);
                        item.ShippingHandling           = sqlDataReader["ShippingHandling"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ShippingHandling"]);
                        item.PurchaseOrderNumber        = sqlDataReader["PurchaseOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        item.ShelfLife                  = sqlDataReader["ShelfExpiryLife"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ShelfExpiryLife"]);
                        item.RemainingShelfLife         = sqlDataReader["RemainingShelfLife"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RemainingShelfLife"]);
                        item.VendorID                   = sqlDataReader["VendorID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorID"]);
                        item.ReceivedQuantity           = sqlDataReader["ReceivedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ReceivedQuantity"]);
                        // item.FOCReceivedQuantity        = sqlDataReader["FocReceivedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["FocReceivedQuantity"]);

                        item.PurchaseOrderType = sqlDataReader["PurchaseOrderType"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseOrderType"]);

                        if (DBNull.Value.Equals(sqlDataReader["ReturnGoods"]) == false)
                        {
                            item.ReturnGoods = Convert.ToBoolean(sqlDataReader["ReturnGoods"]);
                        }
                        
                        var quantity = Math.Round(item.Quantity, 3);
                        var rate = Math.Round(item.Rate, 2);
                        var amount = quantity * rate;
                        ammount = ammount + amount;
                        item.GrossAmount = Math.Round(ammount, 2);
                        //item.GrossAmount = amount;
                         item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        int rndnumber = 0;
                        if ((item.SerialAndBatchManagedBy==2) && (item.Quantity > 0) && (item.PurchaseOrderType !=3))
                        {
                            rndnumber = rand.Next();
                            item.BatchNumber = "Batch-" + item.ItemNumber +"-"+ rndnumber;
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
                        throw new Exception("Stored Procedure 'USP_PurchaseRequisitionMaster_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetBatchList(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemBatchMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 25, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseGRNMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRNMaster item = new PurchaseGRNMaster();
                        item.BatchID = sqlDataReader["BatchID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["BatchID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.BatchNumber = sqlDataReader["BatchNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BatchNumber"]);
                        item.ExpiryDate = sqlDataReader["ExpiryDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExpiryDate"]);
                        item.BatchQuantity = sqlDataReader["BatchQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BatchQuantity"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseRequisitionMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGRNDetailsByID(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseGRNMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseGRNMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseGRNMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRNMaster item = new PurchaseGRNMaster();
                        item.ID = sqlDataReader["PurchaseGRNMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseGRNMasterID"]);
                        item.GRNNumber = sqlDataReader["GRNNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GRNNumber"]);
                        item.GRNTransDate = sqlDataReader["GRNTransDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GRNTransDate"]);
                        item.PurchaseGRNDetailsID = sqlDataReader["PurchaseGRNMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseGRNMasterID"]);
                        item.IsLocked = Convert.ToBoolean(sqlDataReader["IsLocked"]);
                        item.ReceivedQuantity = sqlDataReader["ReceivedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ReceivedQuantity"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.OrderUomCode = sqlDataReader["OrderUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.FOCReceivedQuantity = sqlDataReader["FocReceivedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["FocReceivedQuantity"]);
                        //   item.Quantity               = sqlDataReader["Quantity"] is DBNull            ? 0            : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        //     item.RemainingQuantity      = sqlDataReader["RemainingQuantity"] is DBNull   ? 0            : Convert.ToDecimal(sqlDataReader["RemainingQuantity"]);
                        item.Remark = sqlDataReader["Remark"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Remark"]);
                        item.ItemName = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        //item.ReceivingLocationName = sqlDataReader["ReceivingLocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ReceivingLocationName"]);  
                        item.BatchNumber = sqlDataReader["BatchNumber"] is DBNull ?string.Empty : Convert.ToString(sqlDataReader["BatchNumber"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseRequisitionMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGrnMasterListForPDF(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetRecordForPurchaseGRNMasterPDF";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@PurchaseorderMasteriID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseGRNMaster>();
                    decimal ammount = 0;
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRNMaster item = new PurchaseGRNMaster();

                        item.GRNNumber                = sqlDataReader["GRNNumber"] is DBNull ? string.Empty                  : Convert.ToString(sqlDataReader["GRNNumber"]);
                        item.GRNTransDate             = sqlDataReader["GRNTransDate"] is DBNull ? string.Empty               : Convert.ToString(sqlDataReader["GRNTransDate"]);
                        item.IsLocked = sqlDataReader["IsLocked"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsLocked"]);
                       // item.IsLocked                 = Convert.ToBoolean(sqlDataReader["IsLocked"]);                        
                        item.ReceivedQuantity         = sqlDataReader["ReceivedQuantity"] is DBNull ? 0                      : Convert.ToDecimal(sqlDataReader["ReceivedQuantity"]);
                        item.ItemNumber               = sqlDataReader["ItemNumber"] is DBNull ? 0                            : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemName                 = sqlDataReader["ItemDescription"] is DBNull ? string.Empty            : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.OrderUomCode             = sqlDataReader["OrderUomCode"] is DBNull ? string.Empty               : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.OrderQuantity            = sqlDataReader["OrderedQuantity"] is DBNull ? 0                       : Convert.ToDecimal(sqlDataReader["OrderedQuantity"]);
                        item.Quantity                 = sqlDataReader["ReceivedQuantity"] is DBNull ? 0                      : Convert.ToDecimal(sqlDataReader["ReceivedQuantity"]);
                        item.FOCReceivedQuantity      = sqlDataReader["FocReceivedQuantity"] is DBNull ? 0                   : Convert.ToDecimal(sqlDataReader["FocReceivedQuantity"]);
                        item.Rate                     = sqlDataReader["Rate"] is DBNull ? 0                                  : Convert.ToDecimal(sqlDataReader["Rate"]);
                       // item.StorageLocationName      = sqlDataReader["LocationName"] is DBNull ? string.Empty             : Convert.ToString(sqlDataReader["LocationName"]);
                                                                                                                             
                         item.PrintingLine1            = sqlDataReader["PrintingLine1"] is DBNull ? string.Empty              : Convert.ToString(sqlDataReader["PrintingLine1"]);
                        //item.PrintingLine2            = sqlDataReader["PrintingLine2"] is DBNull ? string.Empty              : Convert.ToString(sqlDataReader["PrintingLine2"]);
                        //item.PrintingLine3            = sqlDataReader["PrintingLine3"] is DBNull ? string.Empty              : Convert.ToString(sqlDataReader["PrintingLine3"]);
                        //item.PrintingLine4            = sqlDataReader["PrintingLine4"] is DBNull ? string.Empty              : Convert.ToString(sqlDataReader["PrintingLine4"]);
                                                                                                                             
                        item.VendorName               = sqlDataReader["VendorName"] is DBNull ? string.Empty                 : Convert.ToString(sqlDataReader["VendorName"]);
                        item.VendorAddress            = sqlDataReader["VendorAddress"] is DBNull ? string.Empty              : Convert.ToString(sqlDataReader["VendorAddress"]);
                        item.VendorPhoneNumber        = sqlDataReader["VendorPhoneNumber"] is DBNull ? string.Empty          : Convert.ToString(sqlDataReader["VendorPhoneNumber"]);
                        item.VendorNumber             = sqlDataReader["VendorNumber"] is DBNull ? 0                          : Convert.ToInt32(sqlDataReader["VendorNumber"]);
                        item.VendorPinCode            = sqlDataReader["VendorPinCode"] is DBNull ? 0                         : Convert.ToInt32(sqlDataReader["VendorPinCode"]);
                        item.Currency                 = sqlDataReader["Currency"] is DBNull ? string.Empty                   : Convert.ToString(sqlDataReader["Currency"]);

                        item.PurchaseRequisitionNumber = sqlDataReader["PurchaseRequisitionNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseRequisitionNumber"]);
                        item.PurchaseOrderNumber       = sqlDataReader["PurchaseOrderNumber"] is DBNull ? string.Empty       : Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        item.ExpectedDeliveryDate      = sqlDataReader["ExpectedDeliveryDate"] is DBNull ? string.Empty      : Convert.ToString(sqlDataReader["ExpectedDeliveryDate"]);
                        item.PurchaseOrderDate         = sqlDataReader["PurchaseOrderDate"] is DBNull ? string.Empty         : Convert.ToString(sqlDataReader["PurchaseOrderDate"]);
                        item.GRNAmount                 = sqlDataReader["GRNAmount"] is DBNull ? 0                            : Convert.ToDecimal(sqlDataReader["GRNAmount"]);
                        item.POAmount                  = sqlDataReader["POAmount"] is DBNull ? 0                             : Convert.ToDecimal(sqlDataReader["POAmount"]);
                        item.TaxRate                   = sqlDataReader["TaxRate"] is DBNull ? 0                              : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.Received                  = sqlDataReader["Received"] is DBNull ? new bool()                    : Convert.ToBoolean(sqlDataReader["Received"]);
                        item.LogoPath                  = sqlDataReader["LogoPath"] is DBNull ? string.Empty                  : Convert.ToString(sqlDataReader["LogoPath"]);
                        item.City                      = sqlDataReader["Description"] is DBNull ? string.Empty               : Convert.ToString(sqlDataReader["Description"]);
                        item.LocationAddress           = sqlDataReader["LocationAddress"] is DBNull ? string.Empty           : Convert.ToString(sqlDataReader["LocationAddress"]);
                        item.Pincode                   = sqlDataReader["Pincode"] is DBNull ? string.Empty                   : Convert.ToString(sqlDataReader["Pincode"]);

                        item.ToUnitName                = sqlDataReader["ToUnitName"] is DBNull ? string.Empty                : Convert.ToString(sqlDataReader["ToUnitName"]);
                        item.ToCity                    = sqlDataReader["ToCity"] is DBNull ? string.Empty                    : Convert.ToString(sqlDataReader["ToCity"]);
                        item.Topincode                 = sqlDataReader["Topincode"] is DBNull ? string.Empty                 : Convert.ToString(sqlDataReader["Topincode"]);
                        item.ToLocationAddress         = sqlDataReader["ToLocationAddress"] is DBNull ? string.Empty         : Convert.ToString(sqlDataReader["ToLocationAddress"]);
                        item.ToLocationName            = sqlDataReader["ToLocationName"] is DBNull ? string.Empty            : Convert.ToString(sqlDataReader["ToLocationName"]);
                        item.FromLocationName          = sqlDataReader["FromLocationName"] is DBNull ? string.Empty          : Convert.ToString(sqlDataReader["FromLocationName"]);
                        item.FromUnitName              = sqlDataReader["FromUnitName"] is DBNull ? string.Empty              : Convert.ToString(sqlDataReader["FromUnitName"]);
                        item.FromCity                  = sqlDataReader["FromCity"] is DBNull ? string.Empty                  : Convert.ToString(sqlDataReader["FromCity"]);
                        item.Frompincode               = sqlDataReader["Frompincode"] is DBNull ? string.Empty               : Convert.ToString(sqlDataReader["Frompincode"]);
                        item.FromLocationAddress       = sqlDataReader["FromLocationAddress"] is DBNull ? string.Empty       : Convert.ToString(sqlDataReader["FromLocationAddress"]);
                        item.PurchaseOrderType = sqlDataReader["PurchaseOrderType"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["PurchaseOrderType"]);

                        var taxamount = ((item.GRNAmount * item.TaxRate) / 100);
                        item.TotalTaxAmount = taxamount;


                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseRequisitionMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

