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
    public class EmployeeShiftMasterDataProvider : DBInteractionBase, IEmployeeShiftMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeeShiftMasterDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeeShiftMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        /// <summary>
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeShiftMaster> GetEmployeeShiftMasterBySearch(EmployeeShiftMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeShiftMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeShiftMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeShiftMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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

                    baseEntityCollection.CollectionResponse = new List<EmployeeShiftMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeShiftMaster item = new EmployeeShiftMaster();
                        item.EmployeeShiftMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.EmployeeShiftDescription = sqlDataReader["ShiftDescription"].ToString();
                        item.IsShiftLocked = Convert.ToBoolean(sqlDataReader["IsShiftIsLocked"]);
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
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
                        throw new Exception("Stored Procedure 'USP_EmployeeShiftMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<EmployeeShiftMaster> GetEmployeeShiftMasterBySearchList(EmployeeShiftMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeShiftMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeShiftMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeShiftMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode != null ? searchRequest.CentreCode : string.Empty));
                    
                   
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

                    baseEntityCollection.CollectionResponse = new List<EmployeeShiftMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeShiftMaster item = new EmployeeShiftMaster();
                        item.EmployeeShiftMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.EmployeeShiftDescription = sqlDataReader["ShiftDescription"].ToString();
                        item.ShiftAllocationCentreID = Convert.ToInt32(sqlDataReader["ShiftAllocationCentreID"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeShiftMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeShiftMaster> GetEmployeeShiftMasterBySelectByEmployeeShiftMasterID(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> response = new BaseEntityResponse<EmployeeShiftMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeShiftMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeShiftMasterID));
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

                        EmployeeShiftMaster _item = new EmployeeShiftMaster();
                        _item.EmployeeShiftMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.EmployeeShiftDescription = sqlDataReader["ShiftDescription"].ToString();
                        //_item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //_item.CentreName = sqlDataReader["CentreName"].ToString();
                       // _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"].ToString());
                        _item.IsShiftLocked = Convert.ToBoolean(sqlDataReader["IsShiftIsLocked"].ToString()); 
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeShiftMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeShiftMaster> InsertEmployeeShiftMaster(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> response = new BaseEntityResponse<EmployeeShiftMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeShiftMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeShiftDescription", SqlDbType.NVarChar, 30,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.EmployeeShiftDescription.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 5,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.IsActive));                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output,true, 10, 0, "", DataRowVersion.Proposed, item.EmployeeShiftMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
                    
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
                        item.EmployeeShiftMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    //response.Message.Add(new MessageDTO
                    //    //{
                    //    //    ErrorMessage = "Create failed"
                    //    //});
                    //    response.Entity = item;
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeShiftMaster_Insert' reported the ErrorCode: " +
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
        public IBaseEntityResponse<EmployeeShiftMaster> UpdateEmployeeShiftMaster(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> response = new BaseEntityResponse<EmployeeShiftMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeShiftMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeShiftMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeShiftDescription", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.EmployeeShiftDescription.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
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
                        throw new Exception("Stored Procedure 'USP_EmployeeShiftMaster_Update' reported the ErrorCode: " + _errorCode);
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
        /// Delete a selected record from EmployeeShiftMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftMaster> DeleteEmployeeShiftMaster(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> response = new BaseEntityResponse<EmployeeShiftMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeShiftMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeShiftMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
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
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeShiftMaster_Delete' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from EmployeeShiftMasterDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeShiftMaster> GetEmployeeShiftMasterDetailsBySearch(EmployeeShiftMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeShiftMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeShiftMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeShiftMasterDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeShiftMasterID", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeShiftMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<EmployeeShiftMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeShiftMaster item = new EmployeeShiftMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.EmployeeShiftMasterDetailsID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeShiftMasterID"]) == false)
                        {
                            item.EmployeeShiftMasterID = Convert.ToInt32(sqlDataReader["EmployeeShiftMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralWeekDaysID"]) == false)
                        {
                            item.GeneralWeekDaysID = Convert.ToInt32(sqlDataReader["GeneralWeekDaysID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WeeklyOffStatus"]) == false)
                        {
                            item.WeeklyOffStatus = Convert.ToString(sqlDataReader["WeeklyOffStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TimeFrom"]) == false)
                        {
                            item.ShiftTimeFrom = sqlDataReader.GetTimeSpan(5);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TimeUpto"]) == false)
                        {
                            item.ShiftTimeUpto = sqlDataReader.GetTimeSpan(6);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TimeMargin"]) == false)
                        {
                            item.ShiftTimeMargin = Convert.ToInt16(sqlDataReader["TimeMargin"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EndBuffer"]) == false)
                        {
                            item.ShiftEndBuffer = Convert.ToInt16(sqlDataReader["EndBuffer"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ConsiderLateMarkUpto"]) == false)
                        {
                            item.ConsiderLateMarkUpto = sqlDataReader.GetTimeSpan(9);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SecondHalfFrom"]) == false)
                        {
                            item.SecondHalfFrom = sqlDataReader.GetTimeSpan(10);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstHalfUpto"]) == false)
                        {
                            item.FirstHalfUpto = sqlDataReader.GetTimeSpan(11);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LunchTimeFrom"]) == false)
                        {
                            item.LunchTimeFrom = sqlDataReader.GetTimeSpan(12);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LunchTimeUpto"]) == false)
                        {
                            item.LunchTimeUpto = sqlDataReader.GetTimeSpan(13);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WeeklyOffType"]) == false)
                        {
                            item.WeeklyOffType = sqlDataReader["WeeklyOffType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WeekDay"]) == false)
                        {
                            item.WeekDay = Convert.ToString(sqlDataReader["WeekDay"]);
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
                        throw new Exception("Stored Procedure 'USP_EmployeeShiftMasterDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of EmployeeShiftMasterDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftMaster> InsertEmployeeShiftMasterDetails(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> response = new BaseEntityResponse<EmployeeShiftMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeShiftMasterDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeShiftMasterID", SqlDbType.Int, 10,ParameterDirection.Input,false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeShiftMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralWeekDaysID", SqlDbType.Int, 4,ParameterDirection.Input,true, 10, 0, "",DataRowVersion.Proposed, item.GeneralWeekDaysID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cWeeklyOffStatus", SqlDbType.Char, 1,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.WeeklyOffStatus.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tShiftTimeFrom", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ShiftTimeFrom)); 
                    cmdToExecute.Parameters.Add(new SqlParameter("@tShiftTimeUpto", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ShiftTimeUpto));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siShiftTimeMargin", SqlDbType.SmallInt, 4,ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ShiftTimeMargin));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siShiftEndBuffer", SqlDbType.SmallInt, 4,ParameterDirection.Input,true, 10, 0, "",DataRowVersion.Proposed, item.ShiftEndBuffer));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tConsiderLateMarkUpto", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ConsiderLateMarkUpto));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tSecondHalfFrom", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.SecondHalfFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tFirstHalfUpto", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.FirstHalfUpto));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tLunchTimeFrom", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.LunchTimeFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tLunchTimeUpto", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.LunchTimeUpto));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sWeeklyOffType", SqlDbType.VarChar, 25,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.WeeklyOffType.Trim()));                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output,true, 10, 0, "", DataRowVersion.Proposed, item.EmployeeShiftMasterDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));

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
                        item.EmployeeShiftMasterDetailsID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    //response.Message.Add(new MessageDTO
                    //    //{
                    //    //    ErrorMessage = "Create failed"
                    //    //});
                    //    response.Entity = item;
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeShiftMasterDetails_Insert' reported the ErrorCode: " +
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
        /// Select a record from General Region Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftMaster> GetEmployeeShiftMasterDetailsBySelectByEmployeeShiftMasterDetailsID(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> response = new BaseEntityResponse<EmployeeShiftMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeShiftMasterDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeShiftMasterDetailsID));
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

                        EmployeeShiftMaster _item = new EmployeeShiftMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.EmployeeShiftMasterDetailsID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeShiftMasterID"]) == false)
                        {
                            _item.EmployeeShiftMasterID = Convert.ToInt32(sqlDataReader["EmployeeShiftMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralWeekDayID"]) == false)
                        {
                            _item.GeneralWeekDaysID = Convert.ToInt32(sqlDataReader["GeneralWeekDayID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WeeklyOffStatus"]) == false)
                        {
                            _item.WeeklyOffStatus = sqlDataReader["WeeklyOffStatus"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TimeFrom"]) == false)
                        {
                            _item.ShiftTimeFrom = sqlDataReader.GetTimeSpan(4);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TimeUpto"]) == false)
                        {
                            _item.ShiftTimeUpto = sqlDataReader.GetTimeSpan(5);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TimeMargin"]) == false)
                        {
                            _item.ShiftTimeMargin = Convert.ToInt16(sqlDataReader["TimeMargin"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EndBuffer"]) == false)
                        {
                            _item.ShiftEndBuffer = Convert.ToInt16(sqlDataReader["EndBuffer"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstHalfUpto"]) == false)
                        {
                            _item.FirstHalfUpto = sqlDataReader.GetTimeSpan(8);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SecondHalfFrom"]) == false)
                        {
                            _item.SecondHalfFrom = sqlDataReader.GetTimeSpan(9);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LunchTimeFrom"]) == false)
                        {
                            _item.LunchTimeFrom = sqlDataReader.GetTimeSpan(10);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LunchTimeUpto"]) == false)
                        {
                            _item.LunchTimeUpto = sqlDataReader.GetTimeSpan(11);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ConsiderLateMarkUpto"]) == false)
                        {
                            _item.ConsiderLateMarkUpto = sqlDataReader.GetTimeSpan(12);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WeeklyOffType"]) == false)
                        {
                            _item.WeeklyOffType = sqlDataReader["WeeklyOffType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WeekDescription"]) == false)
                        {
                            _item.WeekDay = sqlDataReader["WeekDescription"].ToString();
                        }
                         response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeShiftMasterDetails_SelectOne' reported the ErrorCode: " + _errorCode);
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
        /// Update record of EmployeeShiftMasterDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftMaster> UpdateEmployeeShiftMasterDetails(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> response = new BaseEntityResponse<EmployeeShiftMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveEmployeeShiftMasterDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@cWeeklyOffStatus", SqlDbType.Char, 1,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.WeeklyOffStatus.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tShiftTimeFrom", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ShiftTimeFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tShiftTimeUpto", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ShiftTimeUpto));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siShiftTimeMargin", SqlDbType.SmallInt, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ShiftTimeMargin));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siShiftEndBuffer", SqlDbType.SmallInt, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ShiftEndBuffer));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tConsiderLateMarkUpto", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ConsiderLateMarkUpto));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tSecondHalfFrom", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.SecondHalfFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tFirstHalfUpto", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.FirstHalfUpto));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tLunchTimeFrom", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.LunchTimeFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tLunchTimeUpto", SqlDbType.Time, 7,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.LunchTimeUpto));                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@sWeeklyOffType", SqlDbType.VarChar, 25,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.WeeklyOffType.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input,true, 10, 0, "", DataRowVersion.Proposed, item.EmployeeShiftMasterDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));

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
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    //response.Message.Add(new MessageDTO
                    //    //{
                    //    //    ErrorMessage = "Create failed"
                    //    //});
                    //    response.Entity = item;
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeShiftMasterDetails_Update' reported the ErrorCode: " +
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
        #endregion
    }
}
