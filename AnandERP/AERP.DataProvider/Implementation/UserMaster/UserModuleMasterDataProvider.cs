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
    public class UserModuleMasterDataProvider : DBInteractionBase, IUserModuleMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public UserModuleMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public UserModuleMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        #region Method Implementation
        /// <summary>
        /// Select all record from UserModuleMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserModuleMaster> GetUserModuleMasterBySearch(UserModuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserModuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserModuleMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<UserModuleMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserModuleMaster item = new UserModuleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleName"]) == false)
                        {
                            item.ModuleName = sqlDataReader["ModuleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleInstalledFlag"]) == false)
                        {
                            item.ModuleInstalledFlag = Convert.ToBoolean(sqlDataReader["ModuleInstalledFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleActiveFlag"]) == false)
                        {
                            item.ModuleActiveFlag = Convert.ToBoolean(sqlDataReader["ModuleActiveFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleSeqNumber"]) == false)
                        {
                            item.ModuleSeqNumber = Convert.ToInt32(sqlDataReader["ModuleSeqNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleRelatedWith"]) == false)
                        {
                            item.ModuleRelatedWith = sqlDataReader["ModuleRelatedWith"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleTooltip"]) == false)
                        {
                            item.ModuleTooltip = sqlDataReader["ModuleTooltip"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleIconName"]) == false)
                        {
                            item.ModuleIconName = sqlDataReader["ModuleIconName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleIconPath"]) == false)
                        {
                            item.ModuleIconPath = sqlDataReader["ModuleIconPath"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleFormName"]) == false)
                        {
                            item.ModuleFormName = sqlDataReader["ModuleFormName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_UserModuleMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<UserModuleMaster> GetUserModuleMasterByID(UserModuleMaster item)
        {
            IBaseEntityResponse<UserModuleMaster> response = new BaseEntityResponse<UserModuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserModuleMaster_SelectOne";
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
                        UserModuleMaster _item = new UserModuleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            _item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleName"]) == false)
                        {
                            _item.ModuleName = sqlDataReader["ModuleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleInstalledFlag"]) == false)
                        {
                            _item.ModuleInstalledFlag = Convert.ToBoolean(sqlDataReader["ModuleInstalledFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleActiveFlag"]) == false)
                        {
                            _item.ModuleActiveFlag = Convert.ToBoolean(sqlDataReader["ModuleActiveFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleSeqNumber"]) == false)
                        {
                            _item.ModuleSeqNumber = Convert.ToInt32(sqlDataReader["ModuleSeqNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleRelatedWith"]) == false)
                        {
                            _item.ModuleRelatedWith = sqlDataReader["ModuleRelatedWith"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleTooltip"]) == false)
                        {
                            _item.ModuleTooltip = sqlDataReader["ModuleTooltip"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleIconName"]) == false)
                        {
                            _item.ModuleIconName = sqlDataReader["ModuleIconName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleIconPath"]) == false)
                        {
                            _item.ModuleIconPath = sqlDataReader["ModuleIconPath"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleFormName"]) == false)
                        {
                            _item.ModuleFormName = sqlDataReader["ModuleFormName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_UserModuleMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<UserModuleMaster> InsertUserModuleMaster(UserModuleMaster item)
        {
            IBaseEntityResponse<UserModuleMaster> response = new BaseEntityResponse<UserModuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserModuleMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.NVarChar, 10,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModuleCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleName", SqlDbType.NVarChar, 60,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModuleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bModuleInstalledFlag", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ModuleInstalledFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bModuleActiveFlag", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ModuleActiveFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModuleSeqNumber", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ModuleSeqNumber != null ? item.ModuleSeqNumber : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleRelatedWith", SqlDbType.NVarChar, 5,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModuleRelatedWith != null ? item.ModuleRelatedWith : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleTooltip", SqlDbType.NVarChar, 25,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModuleTooltip != null ? item.ModuleTooltip : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleIconName", SqlDbType.NVarChar, 25,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModuleIconName != null ? item.ModuleIconName : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleIconPath", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModuleIconPath != null ? item.ModuleIconPath : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleFormName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModuleFormName != null ? item.ModuleFormName : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Output, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ID));
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
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_UserModuleMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of UserModuleMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserModuleMaster> UpdateUserModuleMaster(UserModuleMaster item)
        {
            IBaseEntityResponse<UserModuleMaster> response = new BaseEntityResponse<UserModuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserModuleMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.NVarChar, 10,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModuleCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleName", SqlDbType.NVarChar, 60,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModuleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bModuleInstalledFlag", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ModuleInstalledFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bModuleActiveFlag", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ModuleActiveFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModuleSeqNumber", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ModuleSeqNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleRelatedWith", SqlDbType.NVarChar, 5,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModuleRelatedWith !=null ? item.ModuleRelatedWith : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleTooltip", SqlDbType.NVarChar, 25,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModuleTooltip != null ? item.ModuleTooltip : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleIconName", SqlDbType.NVarChar, 25,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModuleIconName != null ? item.ModuleIconName : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleIconPath", SqlDbType.NVarChar, 100,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModuleIconPath != null ? item.ModuleIconPath : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleFormName", SqlDbType.NVarChar, 50,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModuleFormName != null ? item.ModuleFormName : string.Empty));

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
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_UserModuleMaster_Update' reported the ErrorCode: " +
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
        /// Delete a specific record of UserModuleMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserModuleMaster> DeleteUserModuleMaster(UserModuleMaster item)
        {
            IBaseEntityResponse<UserModuleMaster> response = new BaseEntityResponse<UserModuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserModuleMaster_Delete";
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
                                            DataRowVersion.Proposed, item.DeletedBy));
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
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_UserModuleMaster_Delete' reported the ErrorCode: " +
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
        /// Select all record from UserModuleMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserModuleMaster> GetModuleListForLoginUserIDByRoleID(UserModuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserModuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserModule_List_ByRoleID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));

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
                    baseEntityCollection.CollectionResponse = new List<UserModuleMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserModuleMaster item = new UserModuleMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ModuleID"]);
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleName"]) == false)
                        {
                            item.ModuleName = sqlDataReader["ModuleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleIconName"]) == false)
                        {
                            item.ModuleIconName = sqlDataReader["ModuleIconName"].ToString();
                        }
                        //item.ModuleInstalledFlag = Convert.ToBoolean(sqlDataReader["ModuleInstalledFlag"]);
                        //item.ModuleActiveFlag = Convert.ToBoolean(sqlDataReader["ModuleActiveFlag"]);
                        //item.ModuleSeqNumber = Convert.ToInt32(sqlDataReader["ModuleSeqNumber"]);
                        //item.ModuleRelatedWith = sqlDataReader["ModuleRelatedWith"].ToString();
                        //item.ModuleTooltip = sqlDataReader["ModuleTooltip"].ToString();                       
                        //item.ModuleIconPath = sqlDataReader["ModuleIconPath"].ToString();
                        item.ModuleFormName = sqlDataReader["ModuleFormName"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["ModuleColorClass"]) == false)
                        {
                            item.ModuleColorClass = sqlDataReader["ModuleColorClass"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_UserModule_List_ByRoleID' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from UserModuleMaster table
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserModuleMaster> GetModuleListForAdmin(UserModuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserModuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserModuleMaster_SelectAllList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));

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
                    baseEntityCollection.CollectionResponse = new List<UserModuleMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserModuleMaster item = new UserModuleMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["ModuleName"]) == false)
                        {
                            item.ModuleName = sqlDataReader["ModuleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleIconName"]) == false)
                        {
                            item.ModuleIconName = sqlDataReader["ModuleIconName"].ToString();
                        }
                        //item.ModuleInstalledFlag = Convert.ToBoolean(sqlDataReader["ModuleInstalledFlag"]);
                        //item.ModuleActiveFlag = Convert.ToBoolean(sqlDataReader["ModuleActiveFlag"]);
                        //item.ModuleSeqNumber = Convert.ToInt32(sqlDataReader["ModuleSeqNumber"]);
                        //item.ModuleRelatedWith = sqlDataReader["ModuleRelatedWith"].ToString();
                        //item.ModuleTooltip = sqlDataReader["ModuleTooltip"].ToString();
                        //item.ModuleIconName = sqlDataReader["ModuleIconName"].ToString();
                        //item.ModuleIconPath = sqlDataReader["ModuleIconPath"].ToString();
                        //item.ModuleFormName = sqlDataReader["ModuleFormName"].ToString();
                     //   item.ModuleFormName = sqlDataReader["ModuleFormName"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["ModuleColorClass"]) == false)
                        {
                            item.ModuleColorClass = sqlDataReader["ModuleColorClass"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_UserModuleMaster_SelectAllList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<UserModuleMaster> GetUserModuleList(UserModuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserModuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserModuleMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@iCategoryCode", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CategoryCode));
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
                    baseEntityCollection.CollectionResponse = new List<UserModuleMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserModuleMaster item = new UserModuleMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.ModuleName = sqlDataReader["ModuleName"].ToString();
                        item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_UserModuleMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
