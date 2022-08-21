using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AMS.DataProvider
{
    public class GeneralMainTypeMasterDataProvider : DBInteractionBase, IGeneralMainTypeMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public GeneralMainTypeMasterDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public GeneralMainTypeMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        /// <summary>
        /// Select all record from General Main Type Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetGeneralMainTypeMasterBySearch(GeneralMainTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralMainTypeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralMainTypeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralMainTypeMaster_SelectAll";
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

                    baseEntityCollection.CollectionResponse = new List<GeneralMainTypeMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralMainTypeMaster item = new GeneralMainTypeMaster();
                        //GeneralMainTypeMaster Table Property.
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TypeDesc"]) == false)
                        {
                            item.TypeDesc = sqlDataReader["TypeDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TypeShortDesc"]) == false)
                        {
                            item.TypeShortDesc = sqlDataReader["TypeShortDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RefTableEntity"]) == false)
                        {
                            item.RefTableEntity = sqlDataReader["RefTableEntity"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RefTableEntityKey"]) == false)
                        {
                            item.RefTableEntityKey = sqlDataReader["RefTableEntityKey"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCode"]) == false)
                        {
                            item.MenuCode = sqlDataReader["MenuCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuName"]) == false)
                        {
                            item.MenuName = sqlDataReader["MenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleName"]) == false)
                        {
                            item.ModuleName = sqlDataReader["ModuleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsFixed"]) == false)
                        {
                            item.IsFixed = Convert.ToBoolean(sqlDataReader["IsFixed"]);
                        }

                        ////GeneralSubTypeMaster Table Property.
                        //if (DBNull.Value.Equals(sqlDataReader["GeneralSubTypeMasterID"]) == false)
                        //{
                        //    item.GeneralSubTypeMasterID = Convert.ToInt32(sqlDataReader["GeneralSubTypeMasterID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["GeneralMainTypeMasterID"]) == false)
                        //{
                        //    item.GeneralMainTypeMasterID = Convert.ToInt32(sqlDataReader["GeneralMainTypeMasterID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["SubTypeDesc"]) == false)
                        //{
                        //    item.SubTypeDesc = sqlDataReader["SubTypeDesc"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["SubShortDesc"]) == false)
                        //{
                        //    item.SubTypeDesc = sqlDataReader["SubShortDesc"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                        //{
                        //    item.AccountID = Convert.ToInt32(sqlDataReader["AccountID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TransactionType"]) == false)
                        //{
                        //    item.TransactionType = sqlDataReader["TransactionType"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["RefTableEntityKeyValue"]) == false)
                        //{
                        //    item.RefTableEntityKeyValue = sqlDataReader["RefTableEntityKeyValue"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["KeyCode"]) == false)
                        //{
                        //    item.KeyCode = sqlDataReader["KeyCode"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["PersonTypeID"]) == false)
                        //{
                        //    item.PersonTypeID = Convert.ToInt32(sqlDataReader["PersonTypeID"]);
                        //}


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
                        throw new Exception("Stored Procedure 'USP_GeneralMainTypeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from General Main Type Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetGeneralMainTypeMasterGetBySearchList(GeneralMainTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralMainTypeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralMainTypeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralMainTypeMaster_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<GeneralMainTypeMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralMainTypeMaster item = new GeneralMainTypeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralMainTypeMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from General Main Type Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMainTypeMaster> GetGeneralMainTypeMasterByID(GeneralMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralMainTypeMaster> response = new BaseEntityResponse<GeneralMainTypeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralMainTypeMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralSubTypeMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralSubTypeMasterID));
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

                        GeneralMainTypeMaster _item = new GeneralMainTypeMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TypeDesc"]) == false)
                        {
                            _item.TypeDesc = sqlDataReader["TypeDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TypeShortDesc"]) == false)
                        {
                            _item.TypeShortDesc = sqlDataReader["TypeShortDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RefTableEntity"]) == false)
                        {
                            _item.RefTableEntity = sqlDataReader["RefTableEntity"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RefTableEntityKey"]) == false)
                        {
                            _item.RefTableEntityKey = sqlDataReader["RefTableEntityKey"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCode"]) == false)
                        {
                            _item.MenuCode = sqlDataReader["MenuCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            _item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        }

                        //GeneralSubTypeMaster Table Property.
                        if (DBNull.Value.Equals(sqlDataReader["GeneralSubTypeMasterID"]) == false)
                        {
                            _item.GeneralSubTypeMasterID = Convert.ToInt32(sqlDataReader["GeneralSubTypeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralMainTypeMasterID"]) == false)
                        {
                            _item.GeneralMainTypeMasterID = Convert.ToInt32(sqlDataReader["GeneralMainTypeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubTypeDesc"]) == false)
                        {
                            _item.SubTypeDesc = sqlDataReader["SubTypeDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubShortDesc"]) == false)
                        {
                            _item.SubTypeDesc = sqlDataReader["SubShortDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                        {
                            _item.AccountID = Convert.ToInt32(sqlDataReader["AccountID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionType"]) == false)
                        {
                            _item.TransactionType = sqlDataReader["TransactionTypeID"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RefTableEntityKeyValue"]) == false)
                        {
                            _item.RefTableEntityKeyValue = sqlDataReader["RefTableEntityKeyValue"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["KeyCode"]) == false)
                        {
                            _item.KeyCode = sqlDataReader["KeyCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonTypeID"]) == false)
                        {
                            _item.PersonTypeID = Convert.ToInt32(sqlDataReader["PersonTypeID"]);
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
                        throw new Exception("Stored Procedure 'USP_GeneralMainTypeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of General Main Type Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMainTypeMaster> InsertGeneralMainTypeMaster(GeneralMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralMainTypeMaster> response = new BaseEntityResponse<GeneralMainTypeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralMainTypeMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTypeDesc", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TypeDesc.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTypeShortDesc", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TypeShortDesc.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRefTableEntity", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RefTableEntity.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRefTableEntityKey", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RefTableEntityKey.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ModuleCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuCode", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MenuCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsFixed", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsFixed));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSubTypeDesc", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubTypeDesc.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSubShortDesc", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubShortDesc.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRefTableEntityKeyValue", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RefTableEntityKeyValue.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTransactionTypeCode", SqlDbType.NVarChar, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TransactionType.Trim()));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsKeyCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.KeyCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
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
                        throw new Exception("Stored Procedure 'USP_GeneralMainTypeMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of General Main Type Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMainTypeMaster> UpdateGeneralMainTypeMaster(GeneralMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralMainTypeMaster> response = new BaseEntityResponse<GeneralMainTypeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralMainTypeMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTypeDesc", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.TypeDesc));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTypeShortDesc", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.TypeShortDesc));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRefTableEntity", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 40, 0, "", DataRowVersion.Proposed, item.RefTableEntity.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRefTableEntityKey", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 40, 0, "", DataRowVersion.Proposed, item.RefTableEntityKey.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, item.MenuCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, item.ModuleCode.Trim()));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSubTypeDesc", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.SubTypeDesc));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSubShortDesc", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.SubShortDesc));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccountID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTransactionType", SqlDbType.NVarChar, 2, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TransactionType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRefTableEntityKeyValue", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 40, 0, "", DataRowVersion.Proposed, item.RefTableEntityKeyValue.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsKeyCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, item.KeyCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonTypeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PersonTypeID));

                   
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
                        throw new Exception("Stored Procedure 'USP_GeneralCountryMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Delete a selected record from General Main Type Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMainTypeMaster> DeleteGeneralMainTypeMaster(GeneralMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralMainTypeMaster> response = new BaseEntityResponse<GeneralMainTypeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralMainTypeMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralSubTypeMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralSubTypeMasterID));
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
                        throw new Exception("Stored Procedure 'USP_GeneralMainTypeMaster_Delete' reported the ErrorCode: " + _errorCode);
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


        ///Service Access interface to select record from GeneralPreTableForMainTypeMaster on Module code and MenuCode.
        public IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> GetGeneralPreTablesForMainTypeByModuleCodeAndMenuCode(GeneralPreTablesForMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> response = new BaseEntityResponse<GeneralPreTablesForMainTypeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralPreTableForMainTypeMasterByModuleCodeAndMenuCode_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nvModuleCode", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ModuleCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nvMenuCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MenuCode));
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
                    response.Entity = new GeneralPreTablesForMainTypeMaster();
                    while (sqlDataReader.Read())
                    {
                        GeneralPreTablesForMainTypeMaster _item = new GeneralPreTablesForMainTypeMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RefTableEntity"]) == false)
                        {
                            _item.RefTableEntity = sqlDataReader["RefTableEntity"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RefTableEntityKey"]) == false)
                        {
                            _item.RefTableEntityKey = sqlDataReader["RefTableEntityKey"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RefTableEntityDisplayKey"]) == false)
                        {
                            _item.RefTableEntityDisplayKey = sqlDataReader["RefTableEntityDisplayKey"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_GeneralPreTableForMainTypeMasterByModuleCodeAndMenuCode_SelectOne' reported the ErrorCode: " + _errorCode);
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

        #endregion

    }
}
