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
    public class DashboardDataProvider : DBInteractionBase, IDashboardDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public DashboardDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public DashboardDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from Dashboard table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        /// 
        public IBaseEntityCollectionResponse<Dashboard> GetByRequestApprovalField(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<Dashboard>();
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
                    cmdToExecute.CommandText = "USP_TaskRequestApproval_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sErrorMessage", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskNotificationMasterID));

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
                    baseEntityCollection.CollectionResponse = new List<Dashboard>();
                    while (sqlDataReader.Read())
                    {
                        Dashboard item = new Dashboard();
                        if (DBNull.Value.Equals(sqlDataReader["FormName"]) == false)
                        {
                            item.FormName = sqlDataReader["FormName"].ToString().Trim();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LabelWithValue"]) == false)
                        {
                            string[] LabelWithValue = sqlDataReader["LabelWithValue"].ToString().Split('`');
                            item.Lable = LabelWithValue[0].Trim();
                            item.LableValue = LabelWithValue[1].Trim();
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
                        throw new Exception("Stored Procedure 'USP_TaskNotificationDetails_SelectByRoleID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<Dashboard> GetDashboardContentListByAdminRoleID(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<Dashboard>();
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
                    cmdToExecute.CommandText = "dbo.USP_DashboardContentDetails_SelectByRoleID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<Dashboard>();
                    while (sqlDataReader.Read())
                    {
                        Dashboard item = new Dashboard();
                        if (DBNull.Value.Equals(sqlDataReader["ContentCode"]) == false)
                        {
                            item.ContentCode = sqlDataReader["ContentCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ContentTitle"]) == false)
                        {
                            item.ContentTitle = sqlDataReader["ContentTitle"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_GeneralTaskModel_SelectByRoleID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<Dashboard> GetDeshboardAllocationBySearch(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<Dashboard>();
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
                    cmdToExecute.CommandText = "dbo.USP_DashboardAllocationByRoleIDAndModule_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModuleCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ModuleCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
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
                    baseEntityCollection.CollectionResponse = new List<Dashboard>();
                    while (sqlDataReader.Read())
                    {
                        Dashboard item = new Dashboard();
                        if (DBNull.Value.Equals(sqlDataReader["DashboardContentDetailsID"]) == false)
                        {
                            item.DashboardContentDetailsID = Convert.ToInt32(sqlDataReader["DashboardContentDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ContentTitle"]) == false)
                        {
                            item.ContentTitle = sqlDataReader["ContentTitle"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModuleName"]) == false)
                        {
                            item.ModuleName = sqlDataReader["ModuleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DashboardAllocationID"]) == false)
                        {
                            item.DashboardAllocationID = Convert.ToInt32(sqlDataReader["DashboardAllocationID"]);
                        }
                        item.ContentStatus = Convert.ToBoolean(sqlDataReader["ContentStatus"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_DashboardAllocationByRoleIDAndModule_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<Dashboard> ApproveAllCompensatoryLeaveApplication(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> response = new BaseEntityResponse<Dashboard>();
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
                else if (item.TaskCode == "CODA")
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;

                    cmdToExecute.CommandText = "dbo.USP_LeaveCompensatoryWorkDayRequestApproval_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsXMLString", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLString));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    //   cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus ", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                        throw new Exception("Stored Procedure 'dbo.USP_LeaveAvailed_InsertXML' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<Dashboard> InsertDashboard(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> response = new BaseEntityResponse<Dashboard>();
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
                    cmdToExecute.CommandText = "dbo.USP_TaskRequestApproval_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToByte(item.IsLastRecord)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bApprovalStatus", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToBoolean(item.ApprovalStatus)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRemark", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Remark != null ? item.Remark.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iApprovedByUserID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApprovedByUserID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StageSequenceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTaskCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    //   cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Status));
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
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                    {
                        // item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
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
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_TaskRequestApproval_Insert' reported the ErrorCode: " +
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
        public IBaseEntityResponse<Dashboard> DeleteContaintAllocateStatus(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> response = new BaseEntityResponse<Dashboard>();
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
                    cmdToExecute.CommandText = "dbo.USP_DashboardContaintAllocateStatus_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDashboardContentDetailsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.DashboardContentDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleMasterID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
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
                    item.DashboardContentDetailsID = (Int32)cmdToExecute.Parameters["@iDashboardContentDetailsID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_DashboardContaintAllocateStatus_Delete' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<Dashboard> InsertContaintAllocateStatus(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> response = new BaseEntityResponse<Dashboard>();
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
                    cmdToExecute.CommandText = "dbo.USP_DashboardContaintAllocateStatus_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDashboardContentDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DashboardContentDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AdminRoleMasterID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDashboardAllocationID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                    //Excecute Row.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();

                    if (_rowsAffected > 0)
                    {
                        item.ID = (Int32)cmdToExecute.Parameters["@iDashboardAllocationID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_DashboardContaintAllocateStatus_Insert' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<Dashboard> GetDashboardRoleCodeList(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<Dashboard>();
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
                    cmdToExecute.CommandText = "dbo.USP_DashboardRoleCode_GetListForDropDown";
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
                    baseEntityCollection.CollectionResponse = new List<Dashboard>();
                    while (sqlDataReader.Read())
                    {
                        Dashboard item = new Dashboard();
                        item.AdminRoleMasterID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.AdminRoleCode = Convert.ToString(sqlDataReader["AdminRoleCode"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralTaskModel_SelectByRoleID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<Dashboard> GetGeneralTaskModelListByPersonID(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<Dashboard>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralTaskModel_SelectByRoleID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
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
                    baseEntityCollection.CollectionResponse = new List<Dashboard>();
                    while (sqlDataReader.Read())
                    {
                        Dashboard item = new Dashboard();
                        if (DBNull.Value.Equals(sqlDataReader["TaskCode"]) == false)
                        {
                            item.TaskCode = sqlDataReader["TaskCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaskDescription"]) == false)
                        {
                            item.TaskDescription = sqlDataReader["TaskDescription"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_GeneralTaskModel_SelectByRoleID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<Dashboard> ApproveAllManualAttendanceApplication(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> response = new BaseEntityResponse<Dashboard>();
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
                else if (item.TaskCode == "MA")
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;

                    cmdToExecute.CommandText = "dbo.USP_TaskRequestApproval_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsXMLString", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLString));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus ", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                        throw new Exception("Stored Procedure 'dbo.USP_LeaveManualAttendanceRequestApproval_InsertXML' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<Dashboard> GetDashboardBySearch(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<Dashboard>();
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
                    if (searchRequest.TaskCode == "LA")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForLeave_SelectByPersonID";
                    }
                    else if (searchRequest.TaskCode == "ASA")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForLeaveAttendanceSpecial_SelectByPersonID";
                    }
                    else if (searchRequest.TaskCode == "MA")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForManualAttendance_SelectByPersonID";
                    }
                    else if (searchRequest.TaskCode == "CODA")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForCompensatoryWorkDay_SelectByPersonID";
                    }
                    else if (searchRequest.TaskCode == "INWARD")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForInward_SelectByPersonID";
                    }
                    else if (searchRequest.TaskCode == "FSAA")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForFSAA_SelectByPersonID";
                    }
                    else if (searchRequest.TaskCode == "PR")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForPR_SelectByPersonID";
                    }
                    else if (searchRequest.TaskCode == "PRQA")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForPRQA_SelectByPersonID";
                    }
                    else if (searchRequest.TaskCode == "SSA")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForSSA_SelectByPersonID";
                    }
                    else if (searchRequest.TaskCode == "AVAR")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForAVAR_SelectByPersonID";
                    }
                    else if (searchRequest.TaskCode == "ATRA")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForATRA_SelectByPersonID";
                    }
                    else if (searchRequest.TaskCode == "PO")
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForPO_SelectByPersonID";
                    }
                    else
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetails_SelectByPersonID";
                    }

                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTaskCode", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskCode));
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
                    baseEntityCollection.CollectionResponse = new List<Dashboard>();
                    while (sqlDataReader.Read())
                    {
                        Dashboard item = new Dashboard();
                        if (DBNull.Value.Equals(sqlDataReader["Description"]) == false)
                        {
                            item.Description = sqlDataReader["Description"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCodeLink"]) == false)
                        {
                            item.MenuCodeLink = sqlDataReader["MenuCodeLink"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovalStatus"]) == false)
                        {
                            item.ApprovalStatus = Convert.ToInt32(sqlDataReader["ApprovalStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaskNotificationDetailsID"]) == false)
                        {
                            item.TaskNotificationDetailsID = Convert.ToInt32(sqlDataReader["TaskNotificationDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaskNotificationMasterID"]) == false)
                        {
                            item.TaskNotificationMasterID = Convert.ToInt32(sqlDataReader["TaskNotificationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralTaskReportingDetailsID"]) == false)
                        {
                            item.GeneralTaskReportingDetailsID = Convert.ToInt32(sqlDataReader["GeneralTaskReportingDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntitytableName"]) == false)
                        {
                            item.EntitytableName = sqlDataReader["EntitytableName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntityPKName"]) == false)
                        {
                            item.EntityPKName = sqlDataReader["EntityPKName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntityPKValue"]) == false)
                        {
                            item.EntityPKValue = Convert.ToInt32(sqlDataReader["EntityPKValue"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StageSequenceNumber"]) == false)
                        {
                            item.StageSequenceNumber = Convert.ToInt32(sqlDataReader["StageSequenceNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLastStage"]) == false)
                        {
                            item.IsLastRecordFlag = Convert.ToBoolean(sqlDataReader["IsLastStage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApplicationDate"]) == false)
                        {
                            item.ApplicationDate = sqlDataReader["ApplicationDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEngaged"]) == false)
                        {
                            item.IsEngaged = Convert.ToBoolean(sqlDataReader["IsEngaged"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EnagedByUserID"]) == false)
                        {
                            item.EngagedByUserID = Convert.ToInt32(sqlDataReader["EnagedByUserID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        }
                        if (searchRequest.TaskCode == "LA")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["FromDate"]) == false)
                            {
                                item.FromDate = Convert.ToString(sqlDataReader["FromDate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UptoDate"]) == false)
                            {
                                item.UptoDate = Convert.ToString(sqlDataReader["UptoDate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TotalfullDaysLeave"]) == false)
                            {
                                item.TotalfullDaysLeave = Convert.ToString(sqlDataReader["TotalfullDaysLeave"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TotalHalfDayLeave"]) == false)
                            {
                                item.TotalHalfDayLeave = Convert.ToString(sqlDataReader["TotalHalfDayLeave"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TotalDays"]) == false)
                            {
                                item.TotalDays = Convert.ToString(sqlDataReader["TotalDays"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LeaveMasterID"]) == false)
                            {
                                item.LeaveMasterID = Convert.ToInt32(sqlDataReader["LeaveMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LeaveMasterID"]) == false)
                            {
                                item.IsActiveMember = Convert.ToBoolean(sqlDataReader["IsActiveMember"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LeaveDescription"]) == false)
                            {
                                item.LeaveDescription = Convert.ToString(sqlDataReader["LeaveDescription"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ApplicationStatus"]) == false)
                            {
                                item.ApplicationStatus = Convert.ToString(sqlDataReader["ApplicationStatus"]);
                            }
                        }
                        if (searchRequest.TaskCode == "MA")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["AttendanceDate"]) == false)
                            {
                                item.AttendanceDate = Convert.ToString(sqlDataReader["AttendanceDate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["CheckInTime"]) == false)
                            {
                                item.CheckInTime = sqlDataReader.GetTimeSpan(4);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["CheckOutTime"]) == false)
                            {
                                item.CheckOutTime = sqlDataReader.GetTimeSpan(5);
                            }
                            item.Reason = sqlDataReader["Reason"].ToString();
                        }
                        if (searchRequest.TaskCode == "ASA")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["RequestedDate"]) == false)
                            {
                                item.RequestedDate = Convert.ToString(sqlDataReader["RequestedDate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LeaveAttendanceSpecialDesctiption"]) == false)
                            {
                                item.LeaveAttendanceSpecialDesctiption = Convert.ToString(sqlDataReader["LeaveAttendanceSpecialDesctiption"]);
                            }
                        }
                        else if (searchRequest.TaskCode == "CODA")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["WorkingDate"]) == false)
                            {
                                item.WorkingDate = Convert.ToString(sqlDataReader["WorkingDate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["CheckInTime"]) == false)
                            {
                                item.CheckInTime = sqlDataReader.GetTimeSpan(4);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["CheckOutTime"]) == false)
                            {
                                item.CheckOutTime = sqlDataReader.GetTimeSpan(5);
                            }
                            item.Reason = sqlDataReader["Reason"].ToString();
                        }

                        if (searchRequest.TaskCode == "INWARD")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["IssueFromLocation"]) == false)
                            {
                                item.IssueFromLocation = Convert.ToString(sqlDataReader["IssueFromLocation"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["IssueToLocation"]) == false)
                            {
                                item.IssueToLocation = Convert.ToString(sqlDataReader["IssueToLocation"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                            {
                                item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["IssueOrPurchaseID"]) == false)
                            {
                                item.IssueOrPurchaseID = Convert.ToInt32(sqlDataReader["IssueOrPurchaseID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                            {
                                item.InvInwardMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                            }

                        }
                        if (searchRequest.TaskCode == "FSAA")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["FeeStructureApplicableHistoryID"]) == false)
                            {
                                item.FeeStructureApplicableHistoryID = Convert.ToInt32(sqlDataReader["FeeStructureApplicableHistoryID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FeeStructureMasterID"]) == false)
                            {
                                item.FeeStructureMasterID = Convert.ToInt32(sqlDataReader["FeeStructureMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TotalFeeAmount"]) == false)
                            {
                                item.TotalFeeAmount = Convert.ToDecimal(sqlDataReader["TotalFeeAmount"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["SectionDescription"]) == false)
                            {
                                item.SectionDescription = Convert.ToString(sqlDataReader["SectionDescription"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["SessionName"]) == false)
                            {
                                item.SessionName = Convert.ToString(sqlDataReader["SessionName"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["StudentID"]) == false)
                            {
                                item.StudentID = Convert.ToInt32(sqlDataReader["StudentID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                            {
                                item.StudentName = Convert.ToString(sqlDataReader["StudentName"]);
                            }
                        }
                        if (searchRequest.TaskCode == "PR")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["PurchaseRequirementNumber"]) == false)
                            {
                                item.PurchaseRequirementNumber = Convert.ToString(sqlDataReader["PurchaseRequirementNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TransDate"]) == false)
                            {
                                item.TransDate = Convert.ToString(sqlDataReader["TransDate"]);
                            }
                        }
                        if (searchRequest.TaskCode == "PRQA")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["PurchaseRequisitionNumber"]) == false)
                            {
                                item.PurchaseRequisitionNumber = Convert.ToString(sqlDataReader["PurchaseRequisitionNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TransDate"]) == false)
                            {
                                item.TransDate = Convert.ToString(sqlDataReader["TransDate"]);
                            }
                        }
                        if (searchRequest.TaskCode == "SSA")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ScholarShipAllocationID"]) == false)
                            {
                                item.ScholarShipAllocationID = Convert.ToInt32(sqlDataReader["ScholarShipAllocationID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ApproveStatus"]) == false)
                            {
                                item.ApproveStatus = Convert.ToInt16(sqlDataReader["ApproveStatus"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ScholarSheepDocumentNumber"]) == false)
                            {
                                item.ScholarSheepDocumentNumber = Convert.ToString(sqlDataReader["ScholarSheepDocumentNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TransDate"]) == false)
                            {
                                item.TransDate = Convert.ToString(sqlDataReader["TransDate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["StudentID"]) == false)
                            {
                                item.StudentID = Convert.ToInt32(sqlDataReader["StudentID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                            {
                                item.StudentName = Convert.ToString(sqlDataReader["StudentName"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["SectionDescription"]) == false)
                            {
                                item.SectionDescription = Convert.ToString(sqlDataReader["SectionDescription"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ScholarShipDescription"]) == false)
                            {
                                item.ScholarShipDescription = Convert.ToString(sqlDataReader["ScholarShipDescription"]);
                            }
                        }
                        if (searchRequest.TaskCode == "AVAR")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["AccTransactionMainID"]) == false)
                            {
                                item.AccTransactionMainID = Convert.ToInt32(sqlDataReader["AccTransactionMainID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ApproveStatus"]) == false)
                            {
                                item.ApproveStatus = Convert.ToInt16(sqlDataReader["ApproveStatus"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["VoucherNumber"]) == false)
                            {
                                item.VoucherNumber = Convert.ToString(sqlDataReader["VoucherNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TransDate"]) == false)
                            {
                                item.TransDate = Convert.ToString(sqlDataReader["TransDate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Narration"]) == false)
                            {
                                item.Narration = Convert.ToString(sqlDataReader["Narration"]);
                            }
                        }
                        if (searchRequest.TaskCode == "ATRA")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["AccountTransferRequestID"]) == false)
                            {
                                item.AccountTransferRequestID = Convert.ToInt32(sqlDataReader["AccountTransferRequestID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["AccountTransferRequestReason"]) == false)
                            {
                                item.AccountTransferRequestReason = Convert.ToString(sqlDataReader["AccountTransferRequestReason"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["AccountTransferRequestStatus"]) == false)
                            {
                                item.AccountTransferRequestStatus = Convert.ToString(sqlDataReader["AccountTransferRequestStatus"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["AccountName"]) == false)
                            {
                                item.AccountName = Convert.ToString(sqlDataReader["AccountName"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["AccountType"]) == false)
                            {
                                item.AccountType = Convert.ToInt16(sqlDataReader["AccountType"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["OldSalesManName"]) == false)
                            {
                                item.OldSalesManName = Convert.ToString(sqlDataReader["OldSalesManName"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["RequestedSalesManName"]) == false)
                            {
                                item.RequestedSalesManName = Convert.ToString(sqlDataReader["RequestedSalesManName"]);
                            }
                        }
                        if (searchRequest.TaskCode == "PO")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["TransDate"]) == false)
                            {
                                item.TransDate = Convert.ToString(sqlDataReader["TransDate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["PurchaseRequisitionNumber"]) == false)
                            {
                                item.PurchaseRequisitionNumber = Convert.ToString(sqlDataReader["PurchaseRequisitionNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Vendor"]) == false)
                            {
                                item.Vendor = Convert.ToString(sqlDataReader["Vendor"]);
                            }
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
                        throw new Exception("Stored Procedure 'USP_TaskNotificationDetails_SelectByRoleID' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<Dashboard> ApproveAllLeaveApplication(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> response = new BaseEntityResponse<Dashboard>();
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
                else if (item.TaskCode == "LA")
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;

                    cmdToExecute.CommandText = "dbo.USP_LeaveAvailed_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsXMLString", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLString));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus ", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                        throw new Exception("Stored Procedure 'dbo.USP_LeaveAvailed_InsertXML' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<Dashboard> InformativeNotificationsReadInsert(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> response = new BaseEntityResponse<Dashboard>();
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
                    cmdToExecute.CommandText = "dbo.USP_InformativeNotificationsRead_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iNotificationTransactionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.NotificationTransactionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersonID));
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
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                    {
                        item.PersonID = (Int32)cmdToExecute.Parameters["@iPersonID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    //item.ErrorCode = (Int32)_errorCode;
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
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_TaskRequestApproval_Insert' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<Dashboard> GetInformativeNotificationListBySearch(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<Dashboard>();
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

                    cmdToExecute.CommandText = "dbo.USP_InformativeNotifications_SelectByPersonID";

                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
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
                    baseEntityCollection.CollectionResponse = new List<Dashboard>();
                    while (sqlDataReader.Read())
                    {
                        Dashboard item = new Dashboard();


                        if (DBNull.Value.Equals(sqlDataReader["NotificationTransactionID"]) == false)
                        {
                            item.NotificationTransactionID = Convert.ToInt32(sqlDataReader["NotificationTransactionID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectDescription"]) == false)
                        {
                            item.SubjectDescription = Convert.ToString(sqlDataReader["SubjectDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BodyDescription"]) == false)
                        {
                            item.BodyDescription = Convert.ToString(sqlDataReader["BodyDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Status"]) == false)
                        {
                            item.NotificationStatus = Convert.ToInt16(sqlDataReader["Status"]);
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
                        throw new Exception("Stored Procedure 'USP_InformativeNotifications_SelectByPersonID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<Dashboard> GetGeneralRequestBySearch(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<Dashboard>();
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

                    if (searchRequest.TaskCode == "Requests")
                    {
                        cmdToExecute.CommandText = "dbo.USP_GeneralRequestNotificationDetails_SelectByPersonID";
                    }
                    else
                    {
                        cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetails_SelectByPersonID";
                    }

                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTaskCode", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskCode));
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
                    baseEntityCollection.CollectionResponse = new List<Dashboard>();
                    while (sqlDataReader.Read())
                    {
                        Dashboard item = new Dashboard();

                        if (searchRequest.TaskCode == "Requests")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["GeneralRequestTransactionID"]) == false)
                            {
                                item.GeneralRequestTransactionID = Convert.ToInt32(sqlDataReader["GeneralRequestTransactionID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["RequestCode"]) == false)
                            {
                                item.RequestCode = Convert.ToString(sqlDataReader["RequestCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FromPersonID"]) == false)
                            {
                                item.FromPersonID = Convert.ToInt32(sqlDataReader["FromPersonID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["PrimaryKeyValue"]) == false)
                            {
                                item.PrimaryKeyValue = Convert.ToInt32(sqlDataReader["PrimaryKeyValue"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["RequestsStatus"]) == false)
                            {
                                item.RequestsStatus = Convert.ToInt16(sqlDataReader["RequestsStatus"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["RequestsMenuCode"]) == false)
                            {
                                item.RequestsMenuCode = Convert.ToString(sqlDataReader["RequestsMenuCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["RequestsLinkMenuCode"]) == false)
                            {
                                item.RequestsLinkMenuCode = Convert.ToString(sqlDataReader["RequestsLinkMenuCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["RequestApprovalBasedTable"]) == false)
                            {
                                item.RequestApprovalBasedTable = Convert.ToString(sqlDataReader["RequestApprovalBasedTable"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["RequestApprovalParamPrimaryKey"]) == false)
                            {
                                item.RequestApprovalParamPrimaryKey = Convert.ToString(sqlDataReader["RequestApprovalParamPrimaryKey"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["RequestDescription"]) == false)
                            {
                                item.RequestDescription = Convert.ToString(sqlDataReader["RequestDescription"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FromUserName"]) == false)
                            {
                                item.FromUserName = Convert.ToString(sqlDataReader["FromUserName"]);
                            }
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
                        throw new Exception("Stored Procedure 'USP_TaskNotificationDetails_SelectByRoleID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<Dashboard> ApproveAllAttendanceSpecialRequestApplication(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> response = new BaseEntityResponse<Dashboard>();
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
                else if (item.TaskCode == "ASA")
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;

                    cmdToExecute.CommandText = "dbo.USP_TaskRequestApproval_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsXMLString", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLString));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus ", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                        throw new Exception("Stored Procedure 'dbo.USP_LeaveAttendanceSpecialRequestApproval_InsertXML' reported the ErrorCode: " + _errorCode);
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
