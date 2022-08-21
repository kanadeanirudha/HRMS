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
    public class UserMasterDataProvider : DBInteractionBase, IUserMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public UserMasterDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public UserMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        //#region Method Implementation

        ///// <summary>
        ///// Select all record from Admin Role Detail table with search parameters
        ///// </summary>
        ///// <param name="searchRequest"></param>
        ///// <returns></returns>
        //public IBaseEntityCollectionResponse<UserMaster> GetUserMasterBySearch(UserMasterSearchRequest searchRequest)
        //{
        //    IBaseEntityCollectionResponse<UserMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserMaster>();
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    SqlDataReader sqlDataReader = null;

        //    try
        //    {
        //        if (string.IsNullOrEmpty(searchRequest.ConnectionString))
        //        {
        //            baseEntityCollection.Message.Add(new MessageDTO()
        //            {
        //                ErrorMessage = "Connection string is empty.",
        //                MessageType = MessageTypeEnum.Error
        //            });
        //        }
        //        else
        //        {
        //            // Use base class' connection object
        //            _mainConnection.ConnectionString = searchRequest.ConnectionString;

        //            cmdToExecute.Connection = _mainConnection;
        //            cmdToExecute.CommandText = "dbo.USP_UserMaster_SelectAll";
        //            cmdToExecute.CommandType = CommandType.StoredProcedure;
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

        //            if (_mainConnectionIsCreatedLocal)
        //            {
        //                // Open connection.
        //                _mainConnection.Open();
        //            }
        //            else
        //            {
        //                if (_mainConnectionProvider.IsTransactionPending)
        //                {
        //                    cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //                }
        //            }

        //            sqlDataReader = cmdToExecute.ExecuteReader();

        //            baseEntityCollection.CollectionResponse = new List<UserMaster>();
        //            while (sqlDataReader.Read())
        //            {
        //                UserMaster item = new UserMaster();
        //                item.ID = Convert.ToInt32(sqlDataReader["ID"]);
        //                item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
        //                item.AdminRoleCode = sqlDataReader["AdminRoleCode"].ToString();
        //                item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
        //                item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
        //                item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
        //                item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);

        //                if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
        //                {
        //                    item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
        //                }
        //                if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
        //                {
        //                    item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
        //                }
        //                if (DBNull.Value.Equals(sqlDataReader["DeletedBy"]) == false)
        //                {
        //                    item.DeletedBy = Convert.ToInt32(sqlDataReader["DeletedBy"]);
        //                }
        //                if (DBNull.Value.Equals(sqlDataReader["DeletedDate"]) == false)
        //                {
        //                    item.DeletedDate = Convert.ToDateTime(sqlDataReader["DeletedDate"]);
        //                }
        //                baseEntityCollection.CollectionResponse.Add(item);
        //            }

        //            if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
        //            {
        //                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
        //            }
        //            if (_errorCode != (int)ErrorEnum.AllOk)
        //            {
        //                // Throw error.
        //                throw new Exception("Stored Procedure 'USP_UserMaster_SelectAll' reported the ErrorCode: " + _errorCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        baseEntityCollection.Message.Add(new MessageDTO()
        //        {
        //            ErrorMessage = ex.InnerException.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        // _logException.Error(ex.Message);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //    return baseEntityCollection;
        //}

        ///// <summary>
        ///// Select a record from Admin Role Detail table by ID
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public IBaseEntityResponse<UserMaster> GetUserMasterByID(UserMaster item)
        //{
        //    IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    SqlDataReader sqlDataReader = null;

        //    try
        //    {
        //        if (string.IsNullOrEmpty(item.ConnectionString))
        //        {
        //            response.Message.Add(new MessageDTO()
        //            {
        //                ErrorMessage = "Connection string is empty.",
        //                MessageType = MessageTypeEnum.Error
        //            });
        //        }
        //        else
        //        {
        //            // Use base class' connection object
        //            _mainConnection.ConnectionString = item.ConnectionString;

        //            cmdToExecute.Connection = _mainConnection;
        //            cmdToExecute.CommandText = "dbo.USP_UserMaster_SelectOne";
        //            cmdToExecute.CommandType = CommandType.StoredProcedure;
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

        //            if (_mainConnectionIsCreatedLocal)
        //            {
        //                // Open connection.
        //                _mainConnection.Open();
        //            }
        //            else
        //            {
        //                if (_mainConnectionProvider.IsTransactionPending)
        //                {
        //                    cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //                }
        //            }

        //            sqlDataReader = cmdToExecute.ExecuteReader();

        //            while (sqlDataReader.Read())
        //            {
        //                UserMaster _item = new UserMaster();
        //                _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
        //                _item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
        //                _item.AdminRoleCode = sqlDataReader["AdminRoleCode"].ToString();
        //                _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
        //                _item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
        //                _item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
        //                _item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);

        //                if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
        //                {
        //                    _item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
        //                }
        //                if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
        //                {
        //                    _item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
        //                }
        //                if (DBNull.Value.Equals(sqlDataReader["DeletedBy"]) == false)
        //                {
        //                    _item.DeletedBy = Convert.ToInt32(sqlDataReader["DeletedBy"]);
        //                }
        //                if (DBNull.Value.Equals(sqlDataReader["DeletedDate"]) == false)
        //                {
        //                    _item.DeletedDate = Convert.ToDateTime(sqlDataReader["DeletedDate"]);
        //                }
        //                response.Entity = _item;
        //            }

        //            if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
        //            {
        //                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
        //            }
        //            if (_errorCode != (int)ErrorEnum.AllOk)
        //            {
        //                // Throw error.
        //                throw new Exception("Stored Procedure 'USP_UserMaster_SelectAll' reported the ErrorCode: " + _errorCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message.Add(new MessageDTO()
        //        {
        //            ErrorMessage = ex.InnerException.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        // _logException.Error(ex.Message);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //    return response;
        //}

        ///// <summary>
        ///// Create new record of Admin Role Detail
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public IBaseEntityResponse<UserMaster> InsertUserMaster(UserMaster item)
        //{
        //    IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
        //    SqlCommand cmdToExecute = new SqlCommand();

        //    try
        //    {

        //        if (string.IsNullOrEmpty(item.ConnectionString))
        //        {
        //            response.Message.Add(new MessageDTO()
        //                {
        //                    ErrorMessage = "Connection string is empty.",
        //                    MessageType = MessageTypeEnum.Error
        //                });
        //        }
        //        else
        //        {
        //            _mainConnection.ConnectionString = item.ConnectionString;
        //            cmdToExecute.Connection = _mainConnection;
        //            cmdToExecute.CommandText = "dbo.USP_UserMaster_Insert";
        //            cmdToExecute.CommandType = CommandType.StoredProcedure;


        //            cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4,
        //                                                         ParameterDirection.Input, false, 10, 0, "",
        //                                                         DataRowVersion.Proposed, item.AdminRoleMasterID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@sAdminRoleCode", SqlDbType.NVarChar, 30,
        //                                                         ParameterDirection.Input, false, 0, 0, "",
        //                                                         DataRowVersion.Proposed, item.AdminRoleCode));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1,
        //                                                         ParameterDirection.Input, true, 0, 0, "",
        //                                                         DataRowVersion.Proposed, item.IsActive));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeleted", SqlDbType.Bit, 1,
        //                                                         ParameterDirection.Input, true, 0, 0, "",
        //                                                         DataRowVersion.Proposed, item.IsDeleted));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
        //                                                         ParameterDirection.Input, true, 10, 0, "",
        //                                                         DataRowVersion.Proposed, item.CreatedBy));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@daCreatedDate", SqlDbType.DateTime, 8,
        //                                                         ParameterDirection.Input, true, 0, 0, "",
        //                                                         DataRowVersion.Proposed, item.CreatedDate));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
        //                                                         ParameterDirection.Input, true, 10, 0, "",
        //                                                         DataRowVersion.Proposed, item.ModifiedBy));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@daModifiedDate", SqlDbType.DateTime, 8,
        //                                                         ParameterDirection.Input, true, 0, 0, "",
        //                                                         DataRowVersion.Proposed, item.ModifiedDate));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
        //                                                         ParameterDirection.Input, true, 10, 0, "",
        //                                                         DataRowVersion.Proposed, DBNull.Value));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@daDeletedDate", SqlDbType.DateTime, 8,
        //                                                         ParameterDirection.Input, true, 0, 0, "",
        //                                                         DataRowVersion.Proposed, DBNull.Value));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output,
        //                                                         true, 10, 0, "", DataRowVersion.Proposed, item.ID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
        //                                                         ParameterDirection.Output, true, 10, 0, "",
        //                                                         DataRowVersion.Proposed, _errorCode));

        //            if (_mainConnectionIsCreatedLocal)
        //            {
        //                // Open connection.
        //                _mainConnection.Open();
        //            }
        //            else
        //            {
        //                if (_mainConnectionProvider.IsTransactionPending)
        //                {
        //                    cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //                }
        //            }

        //            // Execute query.
        //            _rowsAffected = cmdToExecute.ExecuteNonQuery();
        //            item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
        //            _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

        //            if (_errorCode != (int)ErrorEnum.AllOk)
        //            {
        //                // Throw error.
        //                throw new Exception("Stored Procedure 'USP_UserMaster_Insert' reported the ErrorCode: " +
        //                                    _errorCode);
        //            }

        //            if (_rowsAffected > 0)
        //            {
        //                response.Entity = item;
        //            }
        //            else
        //            {
        //                response.Message.Add(new MessageDTO
        //                    {
        //                        ErrorMessage = "Create failed"
        //                    });
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        response.Message.Add(new MessageDTO
        //        {
        //            ErrorMessage = ex.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        _logException.Error(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message.Add(new MessageDTO
        //            {
        //                ErrorMessage = ex.Message,
        //                MessageType = MessageTypeEnum.Error
        //            });
        //        _logException.Error(ex.Message);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //    return response;
        //}

        ///// <summary>
        ///// Update a specific record of admin role detail
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public IBaseEntityResponse<UserMaster> UpdateUserMaster(UserMaster item)
        //{
        //    IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
        //    SqlCommand cmdToExecute = new SqlCommand();

        //    try
        //    {

        //        if (string.IsNullOrEmpty(item.ConnectionString))
        //        {
        //            response.Message.Add(new MessageDTO()
        //            {
        //                ErrorMessage = "Connection string is empty.",
        //                MessageType = MessageTypeEnum.Error
        //            });
        //        }
        //        else
        //        {
        //            _mainConnection.ConnectionString = item.ConnectionString;
        //            cmdToExecute.Connection = _mainConnection;
        //            cmdToExecute.CommandText = "dbo.USP_UserMaster_Update";
        //            cmdToExecute.CommandType = CommandType.StoredProcedure;

        //            cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleMasterID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@sAdminRoleCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AdminRoleCode));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@daModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ModifiedDate));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

        //            if (_mainConnectionIsCreatedLocal)
        //            {
        //                // Open connection.
        //                _mainConnection.Open();
        //            }
        //            else
        //            {
        //                if (_mainConnectionProvider.IsTransactionPending)
        //                {
        //                    cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //                }
        //            }

        //            // Execute query.
        //            _rowsAffected = cmdToExecute.ExecuteNonQuery();
        //            _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

        //            if (_errorCode != (int)ErrorEnum.AllOk)
        //            {
        //                // Throw error.
        //                throw new Exception("Stored Procedure 'USP_UserMaster_Insert' reported the ErrorCode: " + _errorCode);
        //            }

        //            if (_rowsAffected > 0)
        //            {
        //                response.Entity = item;
        //            }
        //            else
        //            {
        //                response.Message.Add(new MessageDTO
        //                {
        //                    ErrorMessage = "Create failed"
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message.Add(new MessageDTO
        //        {
        //            ErrorMessage = ex.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        _logException.Error(ex.Message);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //    return response;
        //}

        ///// <summary>
        ///// Delete a selected record from admin role detail.
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public IBaseEntityResponse<UserMaster> DeleteUserMaster(UserMaster item)
        //{
        //    IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
        //    SqlCommand cmdToExecute = new SqlCommand();

        //    try
        //    {

        //        if (string.IsNullOrEmpty(item.ConnectionString))
        //        {
        //            response.Message.Add(new MessageDTO()
        //            {
        //                ErrorMessage = "Connection string is empty.",
        //                MessageType = MessageTypeEnum.Error
        //            });
        //        }
        //        else
        //        {
        //            _mainConnection.ConnectionString = item.ConnectionString;
        //            cmdToExecute.Connection = _mainConnection;
        //            cmdToExecute.CommandText = "dbo.USP_UserMaster_Delete";
        //            cmdToExecute.CommandType = CommandType.StoredProcedure;

        //            cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

        //            if (_mainConnectionIsCreatedLocal)
        //            {
        //                // Open connection.
        //                _mainConnection.Open();
        //            }
        //            else
        //            {
        //                if (_mainConnectionProvider.IsTransactionPending)
        //                {
        //                    cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //                }
        //            }

        //            // Execute query.
        //            _rowsAffected = cmdToExecute.ExecuteNonQuery();
        //            _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

        //            if (_errorCode != (int)ErrorEnum.AllOk)
        //            {
        //                // Throw error.
        //                throw new Exception("Stored Procedure 'USP_UserMaster_Delete' reported the ErrorCode: " + _errorCode);
        //            }

        //            if (_rowsAffected > 0)
        //            {
        //                response.Entity = item;
        //            }
        //            else
        //            {
        //                response.Message.Add(new MessageDTO
        //                {
        //                    ErrorMessage = "Create failed"
        //                });
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        response.Message.Add(new MessageDTO
        //        {
        //            ErrorMessage = ex.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        _logException.Error(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message.Add(new MessageDTO
        //        {
        //            ErrorMessage = ex.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        _logException.Error(ex.Message);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //    return response;
        //}

        //#endregion

        public IBaseEntityCollectionResponse<UserMaster> GetUserMasterBySearch(UserMasterSearchRequest searchRequest)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<UserMaster> GetUserMasterByID(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserMaster_SelectOne";
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
                        UserMaster _item = new UserMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.UserTypeID = Convert.ToInt32(sqlDataReader["UserTypeID"]);
                        _item.EmailID = sqlDataReader["EmailID"].ToString();
                        _item.Password = sqlDataReader["Password"].ToString();
                        _item.FirstName = sqlDataReader["FirstName"].ToString();
                        _item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        _item.LastName = sqlDataReader["LastName"].ToString();
                        _item.Gender = sqlDataReader["Gender"].ToString();
                        _item.DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]);
                        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        _item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        _item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        _item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);

                        if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
                        {
                            _item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            _item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedBy"]) == false)
                        {
                            _item.DeletedBy = Convert.ToInt32(sqlDataReader["DeletedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedDate"]) == false)
                        {
                            _item.DeletedDate = Convert.ToDateTime(sqlDataReader["DeletedDate"]);
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
                        throw new Exception("Stored Procedure 'USP_UserMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<UserMaster> GetUserType(UserMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserTypeMaster_SelectList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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
                    baseEntityCollection.CollectionResponse = new List<UserMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserMaster item = new UserMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        item.UserType = Convert.ToChar(sqlDataReader["UserType"]);
                        item.UserDescription = sqlDataReader["UserDescription"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_UserTypeMaster_SelectList' reported the ErrorCode: " + _errorCode);
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




        public IBaseEntityResponse<UserMaster> InsertUserMaster(UserMaster item)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<UserMaster> UpdateUserMaster(UserMaster item)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<UserMaster> DeleteUserMaster(UserMaster item)
        {
            throw new NotImplementedException();
        }
        
        public IBaseEntityResponse<UserMaster> SelectByEmailID(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmailIDVerification";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sLatitude", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Latitude));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sLongitude", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Longitude));                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDistanceFlag", SqlDbType.Bit, 1, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bAttendanceFlag", SqlDbType.Bit, 1, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiAttendanceStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bLoginFlag", SqlDbType.Bit, 1, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));

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
                    UserMaster _item = new UserMaster();
                    while (sqlDataReader.Read())
                    {
                        var exists = sqlDataReader["exist"].ToString();
                        if (exists == "Exists")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                            {
                                _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UserTypeID"]) == false)
                            {
                                _item.UserTypeID = Convert.ToInt32(sqlDataReader["UserTypeID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UserType"]) == false)
                            {
                                _item.UserType = Convert.ToChar(sqlDataReader["UserType"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                            {
                                _item.EmailID = sqlDataReader["EmailID"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FirstName"]) == false)
                            {
                                _item.FirstName = sqlDataReader["FirstName"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LastName"]) == false)
                            {
                                _item.LastName = sqlDataReader["LastName"].ToString();
                            }   
                            if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                            {
                                _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                            }                           
                        }                        
                    }

                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iStatus"].Value != DBNull.Value)
                    {
                        _item.Status = Convert.ToInt32(cmdToExecute.Parameters["@iStatus"].Value);
                    }
                    //if (DBNull.Value.Equals(cmdToExecute.Parameters["@nsErrorMessage"]) == true)
                    //{
                    //    _item.ErrorMessage = cmdToExecute.Parameters["@nsErrorMessage"].Value.ToString();
                    //}
                    if (DBNull.Value.Equals(cmdToExecute.Parameters["@iErrorCode"]) == false)
                    {
                        _item.ErrorCode = Convert.ToInt32(cmdToExecute.Parameters["@iErrorCode"].Value.ToString());
                    }
                    if (DBNull.Value.Equals(cmdToExecute.Parameters["@bDistanceFlag"]) == false)
                    {
                        _item.DistanceFlag = Convert.ToBoolean(cmdToExecute.Parameters["@bDistanceFlag"].Value);
                    }
                    if (DBNull.Value.Equals(cmdToExecute.Parameters["@bAttendanceFlag"]) == false)
                    {
                        _item.AttendanceFlag = Convert.ToBoolean(cmdToExecute.Parameters["@bAttendanceFlag"].Value);
                    }
                    if (DBNull.Value.Equals(cmdToExecute.Parameters["@bLoginFlag"]) == false)
                    {
                        _item.LoginFlag = Convert.ToBoolean(cmdToExecute.Parameters["@bLoginFlag"].Value);
                    }
                    if (cmdToExecute.Parameters["@tiAttendanceStatus"].Value != DBNull.Value)
                    {
                        var a= cmdToExecute.Parameters["@tiAttendanceStatus"].Value;
                        if (Convert.ToString(a)=="Null")
                        {
                            _item.ErrorCode = 3;
                        }
                        else
                        {
                            _item.AttendanceStatus = Convert.ToInt16(cmdToExecute.Parameters["@tiAttendanceStatus"].Value.ToString());
                        }
                    }
                   
                    response.Entity = _item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmailIDVerification' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<UserMaster> GetUserMasterByEmailIDPassword(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
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
                   // cmdToExecute.CommandText = "dbo.USP_AdminLoginVerification";
                   cmdToExecute.CommandText = "dbo.USP_AdminLoginVerification";                    
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPassword", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Password));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sMachinName", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MachinName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sIP", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IP));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bMarkAttendanceCheckInTime", SqlDbType.Bit, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MarkAttendanceCheckInTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sUserType", SqlDbType.VarChar, 1, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLogInsertStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLogInsertError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLockInsertStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLockInsertError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveRuleMasterID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));

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
                    UserMaster _item = new UserMaster();
                    while (sqlDataReader.Read())
                    {
                        var exists = sqlDataReader["exist"].ToString();
                        if (exists == "Exists")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                            {
                                _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UserTypeID"]) == false)
                            {
                                _item.UserTypeID = Convert.ToInt32(sqlDataReader["UserTypeID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UserType"]) == false)
                            {
                                _item.UserType = Convert.ToChar(sqlDataReader["UserType"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                            {
                                _item.EmailID = sqlDataReader["EmailID"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Password"]) == false)
                            {
                                _item.Password = sqlDataReader["Password"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["PersonID"]) == false)
                            {
                                _item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"].ToString());
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FirstName"]) == false)
                            {
                                _item.FirstName = sqlDataReader["FirstName"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["MiddleName"]) == false)
                            {
                                _item.MiddleName = sqlDataReader["MiddleName"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LastName"]) == false)
                            {
                                _item.LastName = sqlDataReader["LastName"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Gender"]) == false)
                            {
                                _item.Gender = sqlDataReader["Gender"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["DateOfBirth"]) == false)
                            {
                                _item.DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                            {
                                _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ProfilePhoto"]) == false)
                            {
                                _item.ProfilePhoto = (byte[])(sqlDataReader["ProfilePhoto"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ProfilePhotoSize"]) == false)
                            {
                                _item.ProfilePhotoSize = sqlDataReader["ProfilePhotoSize"].ToString(); 
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LastModuleCode"]) == false)
                            {
                                _item.LastModuleCode = sqlDataReader["LastModuleCode"].ToString();
                            }
                            //    response.Entity = _item;
                        }
                      
                    }

                    sqlDataReader.Close();

                    if ( cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _item.ErrorCode = Convert.ToInt32(cmdToExecute.Parameters["@iErrorCode"].Value.ToString());
                    }

                    if (cmdToExecute.Parameters["@iPersonID"].Value != null && cmdToExecute.Parameters["@iPersonID"].Value.ToString() != "")
                    {
                        _item.PersonID = Convert.ToInt32(cmdToExecute.Parameters["@iPersonID"].Value);
                    }
                    if ( cmdToExecute.Parameters["@nsErrorMessage"].Value != null && cmdToExecute.Parameters["@nsErrorMessage"].Value.ToString() != "")
                    {
                        _item.ErrorMessage = cmdToExecute.Parameters["@nsErrorMessage"].Value.ToString();
                    }
                    if (cmdToExecute.Parameters["@iStatus"].Value != null)
                    {
                        _item.Status = Convert.ToInt32(cmdToExecute.Parameters["@iStatus"].Value);
                    }
                    //if (cmdToExecute.Parameters["@sUserType"].Value.ToString() != "Null")
                    //{
                    //    _item.UserType = Convert.ToChar(cmdToExecute.Parameters["@sUserType"].Value);
                    //}
                    response.Entity = _item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AdminLoginVerification' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<UserMaster> UserLoginApi(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
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
                   // cmdToExecute.CommandText = "dbo.USP_AdminLoginVerification";
                    cmdToExecute.CommandText = "dbo.USP_UserMasterLogin_ForPOS";                    
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPassword", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Password));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeviceToken", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DeviceToken));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sUserType", SqlDbType.VarChar, 1, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLogInsertStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLogInsertError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLockInsertStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLockInsertError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));

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
                    UserMaster _item = new UserMaster();
                    while (sqlDataReader.Read())
                    {
                        var exists = sqlDataReader["exist"].ToString();
                        if (exists == "Exists")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                            {
                                _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UserTypeID"]) == false)
                            {
                                _item.UserTypeID = Convert.ToInt32(sqlDataReader["UserTypeID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UserType"]) == false)
                            {
                                _item.UserType = Convert.ToChar(sqlDataReader["UserType"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                            {
                                _item.EmailID = sqlDataReader["EmailID"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Password"]) == false)
                            {
                                _item.Password = sqlDataReader["Password"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["PersonID"]) == false)
                            {
                                _item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"].ToString());
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FirstName"]) == false)
                            {
                                _item.FirstName = sqlDataReader["FirstName"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["MiddleName"]) == false)
                            {
                                _item.MiddleName = sqlDataReader["MiddleName"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LastName"]) == false)
                            {
                                _item.LastName = sqlDataReader["LastName"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Gender"]) == false)
                            {
                                _item.Gender = sqlDataReader["Gender"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                            {
                                _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["GeneralPOSMasterID"]) == false)
                            {
                                _item.GeneralPOSMasterID = Convert.ToInt32(sqlDataReader["GeneralPOSMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["GeneralCounterMasterID"]) == false)
                            {
                                _item.GeneralCounterMasterID = Convert.ToInt32(sqlDataReader["GeneralCounterMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["GeneralUnitsID"]) == false)
                            {
                                _item.GeneralUnitsID = Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                            }
                            //    response.Entity = _item;
                        }
                      
                    }

                    sqlDataReader.Close();

                    if ( cmdToExecute.Parameters["@iErrorCode"].Value.ToString() != "Null")
                    {
                        _item.ErrorCode = Convert.ToInt32(cmdToExecute.Parameters["@iErrorCode"].Value.ToString());
                    }

                    if ( cmdToExecute.Parameters["@nsErrorMessage"].Value.ToString() != "Null")
                    {
                        _item.ErrorMessage = cmdToExecute.Parameters["@nsErrorMessage"].Value.ToString();
                    }
                    if (cmdToExecute.Parameters["@iStatus"].Value.ToString() != "Null")
                    {
                        _item.Status = Convert.ToInt32(cmdToExecute.Parameters["@iStatus"].Value);
                    }
                    if (cmdToExecute.Parameters["@iUserID"].Value.ToString() != "Null")
                    {
                        _item.UserID = Convert.ToChar(cmdToExecute.Parameters["@iUserID"].Value);
                    }
                    response.Entity = _item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_UserMasterLogin_ForPOS' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<UserMaster> UserLogoutApi(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
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
                   // cmdToExecute.CommandText = "dbo.USP_AdminLoginVerification";
                    cmdToExecute.CommandText = "dbo.USP_UserMasterLogout_ForPOS";                    
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralCounterMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralCounterMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralPOSMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralPOSMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeviceToken", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DeviceToken));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sLogoutType", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LogoutType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));

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
                    UserMaster _item = new UserMaster();
                    while (sqlDataReader.Read())
                    {
                      
                    }

                    sqlDataReader.Close();

                    if ( cmdToExecute.Parameters["@iErrorCode"].Value.ToString() != "Null")
                    {
                        _item.ErrorCode = Convert.ToInt32(cmdToExecute.Parameters["@iErrorCode"].Value.ToString());
                    }

                    if ( cmdToExecute.Parameters["@nsErrorMessage"].Value.ToString() != "Null")
                    {
                        _item.ErrorMessage = cmdToExecute.Parameters["@nsErrorMessage"].Value.ToString();
                    }
                    if (cmdToExecute.Parameters["@iStatus"].Value.ToString() != "Null")
                    {
                        _item.Status = Convert.ToInt32(cmdToExecute.Parameters["@iStatus"].Value);
                    }

                    response.Entity = _item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_UserMasterLogin_ForPOS' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<UserMaster> GetRolesBySearch(UserMasterSearchRequest searchRequest)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<UserMaster> LogOffByUserID(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_User_Logoff";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sLogoutType", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LogoutType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bMarkAttendanceCheckOutTime", SqlDbType.Bit, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MarkAttendanceCheckOutTime));
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
                    UserMaster _item = new UserMaster();
                    while (sqlDataReader.Read())
                    {                       
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                    }

                    sqlDataReader.Close();

                    if ( cmdToExecute.Parameters["@iErrorCode"].Value.ToString() != "Null")
                    {
                        _item.ErrorCode = Convert.ToInt32(cmdToExecute.Parameters["@iErrorCode"].Value.ToString());
                    }                 
                    response.Entity = _item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_User_Logoff' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<UserMaster> GetActiveUserBySearch(UserMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_ActiveUser_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<UserMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserMaster item = new UserMaster();

                        item.UserCode = sqlDataReader["UserCode"].ToString();
                        item.UserName = sqlDataReader["UserName"].ToString();                       
                        item.UserType = Convert.ToChar(sqlDataReader["UserType"]);
                        item.SystemStatus = sqlDataReader["SystemStatus"].ToString();
                        item.UserStatus = sqlDataReader["UserStatus"].ToString();
                        item.LastActivity = sqlDataReader["LastActivity"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ActiveUser_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<UserMaster> UserLoginReset(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_User_LoginReset";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UserID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.ErrorMessage));
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
                    UserMaster _item = new UserMaster();
                    while (sqlDataReader.Read())
                    {
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                    }

                    sqlDataReader.Close();

                    if (cmdToExecute.Parameters["@iErrorCode"].Value.ToString() != "Null")
                    {
                        _item.ErrorCode = Convert.ToInt32(cmdToExecute.Parameters["@iErrorCode"].Value.ToString());
                    }
                    _item.Status = (int)cmdToExecute.Parameters["@iStatus"].Value;
                    _item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;

                    response.Entity = _item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_User_LoginReset' reported the ErrorCode: " + _errorCode);
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
    }
}
