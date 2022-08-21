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
    public class UserMainMenuMasterDataProvider : DBInteractionBase, IUserMainMenuMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public UserMainMenuMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public UserMainMenuMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from UserMainMenuMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetUserMainMenuMasterBySearch(UserMainMenuMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserMainMenuMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserMainMenuMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<UserMainMenuMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserMainMenuMaster item = new UserMainMenuMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleID"]) == false)
                        {
                            item.ModuleID = Convert.ToInt32(sqlDataReader["ModuleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleName"]) == false)
                        {
                            item.ModuleName = sqlDataReader["ModuleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCode"]) == false)
                        {
                            item.MenuCode = sqlDataReader["MenuCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuName"]) == false)
                        {
                            item.MenuName = sqlDataReader["MenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuInnerLevel"]) == false)
                        {
                            item.MenuInnerLevel = Convert.ToInt32(sqlDataReader["MenuInnerLevel"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuID"]) == false)
                        {
                            item.ParentMenuID = Convert.ToInt32(sqlDataReader["ParentMenuID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuDisplaySeqNo"]) == false)
                        {
                            item.MenuDisplaySeqNo = Convert.ToInt32(sqlDataReader["MenuDisplaySeqNo"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuVerNo"]) == false)
                        {
                            item.MenuVerNo = sqlDataReader["MenuVerNo"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuInstalledFlag"]) == false)
                        {
                            item.MenuInstalledFlag = Convert.ToBoolean(sqlDataReader["MenuInstalledFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuLink"]) == false)
                        {
                            item.MenuLink = sqlDataReader["MenuLink"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEnable"]) == false)
                        {
                            item.IsEnable = Convert.ToBoolean(sqlDataReader["IsEnable"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DisableDate"]) == false)
                        {
                            item.DisableDate = Convert.ToString(sqlDataReader["DisableDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RemarkAboutDisable"]) == false)
                        {
                            item.RemarkAboutDisable = sqlDataReader["RemarkAboutDisable"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuToolTip"]) == false)
                        {
                            item.MenuToolTip = sqlDataReader["MenuToolTip"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuName"]) == false)
                        {
                            item.ParentMenuName = sqlDataReader["ParentMenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuCode"]) == false)
                        {
                            item.ParentMenuCode = sqlDataReader["ParentMenuCode"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_UserMainMenuMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<UserMainMenuMaster> GetUserMainMenuMasterByID(UserMainMenuMaster item)
        {
            IBaseEntityResponse<UserMainMenuMaster> response = new BaseEntityResponse<UserMainMenuMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserMainMenuMaster_SelectOne";
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
                        UserMainMenuMaster _item = new UserMainMenuMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleID"]) == false)
                        {
                            _item.ModuleID = Convert.ToInt32(sqlDataReader["ModuleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            _item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCode"]) == false)
                        {
                            _item.MenuCode = sqlDataReader["MenuCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuName"]) == false)
                        {
                            _item.MenuName = sqlDataReader["MenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuInnerLevel"]) == false)
                        {
                            _item.MenuInnerLevel = Convert.ToInt32(sqlDataReader["MenuInnerLevel"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuID"]) == false)
                        {
                            _item.ParentMenuID = Convert.ToInt32(sqlDataReader["ParentMenuID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuDisplaySeqNo"]) == false)
                        {
                            _item.MenuDisplaySeqNo = Convert.ToInt32(sqlDataReader["MenuDisplaySeqNo"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuVerNo"]) == false)
                        {
                            _item.MenuVerNo = sqlDataReader["MenuVerNo"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuInstalledFlag"]) == false)
                        {
                            _item.MenuInstalledFlag = Convert.ToBoolean(sqlDataReader["MenuInstalledFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuLink"]) == false)
                        {
                            _item.MenuLink = sqlDataReader["MenuLink"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEnable"]) == false)
                        {
                            _item.IsEnable = Convert.ToBoolean(sqlDataReader["IsEnable"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DisableDate"]) == false)
                        {
                            _item.DisableDate = Convert.ToString(sqlDataReader["DisableDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RemarkAboutDisable"]) == false)
                        {
                            _item.RemarkAboutDisable = sqlDataReader["RemarkAboutDisable"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuToolTip"]) == false)
                        {
                            _item.MenuToolTip = sqlDataReader["MenuToolTip"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuName"]) == false)
                        {
                            _item.ParentMenuName = sqlDataReader["ParentMenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuCode"]) == false)
                        {
                            _item.ParentMenuCode = sqlDataReader["ParentMenuCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuIconName"]) == false)
                        {
                            _item.MenuIconName = sqlDataReader["MenuIconName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_UserMainMenuMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<UserMainMenuMaster> InsertUserMainMenuMaster(UserMainMenuMaster item)
        {
            IBaseEntityResponse<UserMainMenuMaster> response = new BaseEntityResponse<UserMainMenuMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserMainMenuMaster_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModuleID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ModuleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModuleCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuName", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MenuName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MenuCode));                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMenuInnerLevel", SqlDbType.SmallInt, 5,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MenuInnerLevel));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iParentMenuID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ParentMenuID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMenuDisplaySeqNo", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MenuDisplaySeqNo!=null ? item.MenuDisplaySeqNo : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuVerNo", SqlDbType.NVarChar, 60,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bMenuInstalledFlag", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MenuInstalledFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuLink", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MenuLink != null ? item.MenuLink : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsEnable", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    if (item.DisableDate == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDisableDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDisableDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.DisableDate)));
                    }
                    if (item.RemarkAboutDisable == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarkAboutDisable", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarkAboutDisable", SqlDbType.NVarChar, 100,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, item.RemarkAboutDisable));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuToolTip", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MenuToolTip));
                    if (item.IsParent == true)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMenuName", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ParentMenuName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMenuName", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ParentMenuCode == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMenuCode", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMenuCode", SqlDbType.NVarChar, 50,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, item.ParentMenuCode));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuIconName", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.MenuIconName != null ? item.MenuIconName : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeleted", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.IsDeleted));                    
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
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_UserMainMenuMaster_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of UserMainMenuMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserMainMenuMaster> UpdateUserMainMenuMaster(UserMainMenuMaster item)
        {
            IBaseEntityResponse<UserMainMenuMaster> response = new BaseEntityResponse<UserMainMenuMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserMainMenuMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModuleID", SqlDbType.Int, 4,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ModuleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.NVarChar, 10,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModuleCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuCode", SqlDbType.NVarChar, 50,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.MenuCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuName", SqlDbType.NVarChar, 100,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.MenuName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMenuInnerLevel", SqlDbType.SmallInt, 5,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.MenuInnerLevel));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iParentMenuID", SqlDbType.Int, 4,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ParentMenuID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMenuDisplaySeqNo", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.MenuDisplaySeqNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuVerNo", SqlDbType.NVarChar, 60,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bMenuInstalledFlag", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    if (item.IsParent == true)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuLink", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuLink", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.MenuLink));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsEnable", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsEnable));
                    if (item.DisableDate == null || item.DisableDate == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDisableDate", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarkAboutDisable", SqlDbType.NVarChar, 100,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    }
                    else 
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDisableDate", SqlDbType.DateTime, 0,
                                             ParameterDirection.Input, false, 0, 0, "",
                                             DataRowVersion.Proposed, item.DisableDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarkAboutDisable", SqlDbType.NVarChar, 100,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.RemarkAboutDisable));
                    }
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuToolTip", SqlDbType.NVarChar, 30,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.MenuToolTip));
                    if (item.IsParent == true)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMenuName", SqlDbType.NVarChar, 100,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, item.ParentMenuName));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMenuCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ParentMenuCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMenuName", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMenuCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));                       
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMenuIconName", SqlDbType.NVarChar, 50,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.MenuIconName)); 
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
                   // _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_UserMainMenuMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of UserMainMenuMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserMainMenuMaster> DeleteUserMainMenuMaster(UserMainMenuMaster item)
        {
            IBaseEntityResponse<UserMainMenuMaster> response = new BaseEntityResponse<UserMainMenuMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserMainMenuMaster_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_UserMainMenuMaster_Delete' reported the ErrorCode: " +
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
        /// Select  record from UserMainMenuMaster table with search parameters ModuleID for Menubar
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetMenuByModuleID(UserMainMenuMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserMainMenuMaster>();
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
                   // cmdToExecute.CommandText = "dbo.USP_UserMainMenuMaster_ByModuleID";
                    if (searchRequest.RoleId != 0)
                    {
                        cmdToExecute.CommandText = "dbo.USP_UserMainMenuMaster_ByRoleIDTest";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                       // cmdToExecute.Parameters.Add(new SqlParameter("@iModuleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ModuleID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ModuleCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.RoleId));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iUserId", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.UserId));

                    }
                    else
                    {
                        cmdToExecute.CommandText = "dbo.USP_UserMainMenuMaster_ByModuleCode";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ModuleCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iUserId", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.UserId));

                    }
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
                    baseEntityCollection.CollectionResponse = new List<UserMainMenuMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserMainMenuMaster item = new UserMainMenuMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["ModuleID"]) == false)
                        {
                            item.ModuleID = Convert.ToInt32(sqlDataReader["ModuleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCode"]) == false)
                        {
                            item.MenuCode = sqlDataReader["MenuCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuName"]) == false)
                        {
                            item.MenuName = sqlDataReader["MenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuInnerLevel"]) == false)
                        {
                            item.MenuInnerLevel = Convert.ToInt32(sqlDataReader["MenuInnerLevel"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuID"]) == false)
                        {
                            item.ParentMenuID = Convert.ToInt32(sqlDataReader["ParentMenuID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuDisplaySeqNo"]) == false)
                        {
                            item.MenuDisplaySeqNo = Convert.ToInt32(sqlDataReader["MenuDisplaySeqNo"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuVerNo"]) == false)
                        {
                            item.MenuVerNo = sqlDataReader["MenuVerNo"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuInstalledFlag"]) == false)
                        {
                            item.MenuInstalledFlag = Convert.ToBoolean(sqlDataReader["MenuInstalledFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuLink"]) == false)
                        {
                            item.MenuLink = sqlDataReader["MenuLink"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuIconName"]) == false)
                        {
                            item.MenuIconName = sqlDataReader["MenuIconName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEnable"]) == false)
                        {
                            item.IsEnable = Convert.ToBoolean(sqlDataReader["IsEnable"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DisableDate"]) == false)
                        {
                            item.DisableDate = Convert.ToString(sqlDataReader["DisableDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RemarkAboutDisable"]) == false)
                        {
                            item.RemarkAboutDisable = sqlDataReader["RemarkAboutDisable"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuToolTip"]) == false)
                        {
                            item.MenuToolTip = sqlDataReader["MenuToolTip"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuName"]) == false)
                        {
                            item.ParentMenuName = sqlDataReader["ParentMenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuCode"]) == false)
                        {
                            item.ParentMenuCode = sqlDataReader["ParentMenuCode"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_UserMainMenuMaster_ByModuleID' reported the ErrorCode: " + _errorCode);
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
        /// Select  record from UserMainMenuMaster table with search parameters ModuleID for Menubar
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetParentMenuByModuleID(UserMainMenuMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserMainMenuMaster>();
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
                   // cmdToExecute.CommandText = "dbo.USP_ParentMenu_List_ByModuleID";
                    cmdToExecute.CommandText = "dbo.USP_ParentMenu_List_ByModuleCode";
                    
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ModuleCode));
                  
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
                    baseEntityCollection.CollectionResponse = new List<UserMainMenuMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserMainMenuMaster item = new UserMainMenuMaster();
                        
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ParentMenuID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleID"]) == false)
                        {
                            item.ModuleID = Convert.ToInt32(sqlDataReader["ModuleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuName"]) == false)
                        {
                            item.ParentMenuName = sqlDataReader["ParentMenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_ParentMenu_List_ByModuleID' reported the ErrorCode: " + _errorCode);
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
        /// Select  record from UserMainMenuMaster table with search parameters ModuleCode for Menubar
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetMenuByModuleCode(UserMainMenuMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserMainMenuMaster>();
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
                    //cmdToExecute.CommandText = "dbo.USP_AdminGetCentrewiseMenuListForStudent";
                    
                    cmdToExecute.CommandText = "dbo.USP_UserMainMenuMaster_ByModuleCode";


                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ModuleCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserId", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.UserId));

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
                    baseEntityCollection.CollectionResponse = new List<UserMainMenuMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserMainMenuMaster item = new UserMainMenuMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["ModuleID"]) == false)
                        {
                            item.ModuleID = Convert.ToInt32(sqlDataReader["ModuleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCode"]) == false)
                        {
                            item.MenuCode = sqlDataReader["MenuCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuName"]) == false)
                        {
                            item.MenuName = sqlDataReader["MenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuInnerLevel"]) == false)
                        {
                            item.MenuInnerLevel = Convert.ToInt32(sqlDataReader["MenuInnerLevel"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuID"]) == false)
                        {
                            item.ParentMenuID = Convert.ToInt32(sqlDataReader["ParentMenuID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuDisplaySeqNo"]) == false)
                        {
                            item.MenuDisplaySeqNo = Convert.ToInt32(sqlDataReader["MenuDisplaySeqNo"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuVerNo"]) == false)
                        {
                            item.MenuVerNo = sqlDataReader["MenuVerNo"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuInstalledFlag"]) == false)
                        {
                            item.MenuInstalledFlag = Convert.ToBoolean(sqlDataReader["MenuInstalledFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuLink"]) == false)
                        {
                            item.MenuLink = sqlDataReader["MenuLink"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuIconName"]) == false)
                        {
                            item.MenuIconName = sqlDataReader["MenuIconName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEnable"]) == false)
                        {
                            item.IsEnable = Convert.ToBoolean(sqlDataReader["IsEnable"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DisableDate"]) == false)
                        {
                            item.DisableDate = Convert.ToString(sqlDataReader["DisableDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RemarkAboutDisable"]) == false)
                        {
                            item.RemarkAboutDisable = sqlDataReader["RemarkAboutDisable"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuToolTip"]) == false)
                        {
                            item.MenuToolTip = sqlDataReader["MenuToolTip"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuName"]) == false)
                        {
                            item.ParentMenuName = sqlDataReader["ParentMenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuCode"]) == false)
                        {
                            item.ParentMenuCode = sqlDataReader["ParentMenuCode"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_AdminGetCentrewiseMenuListForStudent' reported the ErrorCode: " + _errorCode);
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
        /// Select  record from UserMainMenuMaster table with search parameters ModuleCode and centreCode for student dashboard Menubar 
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetCentrewiseMenuListForStudent(UserMainMenuMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserMainMenuMaster>();
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
                    //cmdToExecute.CommandText = "dbo.USP_AdminGetCentrewiseMenuListForStudent";

                    cmdToExecute.CommandText = "dbo.USP_AdminGetCentrewiseMenuListForStudent";


                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sModuleCode", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ModuleCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                  
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
                    baseEntityCollection.CollectionResponse = new List<UserMainMenuMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserMainMenuMaster item = new UserMainMenuMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["ModuleID"]) == false)
                        {
                            item.ModuleID = Convert.ToInt32(sqlDataReader["ModuleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleCode"]) == false)
                        {
                            item.ModuleCode = sqlDataReader["ModuleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCode"]) == false)
                        {
                            item.MenuCode = sqlDataReader["MenuCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuName"]) == false)
                        {
                            item.MenuName = sqlDataReader["MenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuInnerLevel"]) == false)
                        {
                            item.MenuInnerLevel = Convert.ToInt32(sqlDataReader["MenuInnerLevel"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuID"]) == false)
                        {
                            item.ParentMenuID = Convert.ToInt32(sqlDataReader["ParentMenuID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuDisplaySeqNo"]) == false)
                        {
                            item.MenuDisplaySeqNo = Convert.ToInt32(sqlDataReader["MenuDisplaySeqNo"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuVerNo"]) == false)
                        {
                            item.MenuVerNo = sqlDataReader["MenuVerNo"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuInstalledFlag"]) == false)
                        {
                            item.MenuInstalledFlag = Convert.ToBoolean(sqlDataReader["MenuInstalledFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuLink"]) == false)
                        {
                            item.MenuLink = sqlDataReader["MenuLink"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuIconName"]) == false)
                        {
                            item.MenuIconName = sqlDataReader["MenuIconName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEnable"]) == false)
                        {
                            item.IsEnable = Convert.ToBoolean(sqlDataReader["IsEnable"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DisableDate"]) == false)
                        {
                            item.DisableDate = Convert.ToString(sqlDataReader["DisableDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RemarkAboutDisable"]) == false)
                        {
                            item.RemarkAboutDisable = sqlDataReader["RemarkAboutDisable"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuToolTip"]) == false)
                        {
                            item.MenuToolTip = sqlDataReader["MenuToolTip"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuName"]) == false)
                        {
                            item.ParentMenuName = sqlDataReader["ParentMenuName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ParentMenuCode"]) == false)
                        {
                            item.ParentMenuCode = sqlDataReader["ParentMenuCode"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_AdminGetCentrewiseMenuListForStudent' reported the ErrorCode: " + _errorCode);
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
