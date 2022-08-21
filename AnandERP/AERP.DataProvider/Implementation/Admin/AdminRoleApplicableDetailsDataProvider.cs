using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public class AdminRoleApplicableDetailsDataProvider : DBInteractionBase, IAdminRoleApplicableDetailsDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        public AdminRoleApplicableDetailsDataProvider()
        {
        }

        public AdminRoleApplicableDetailsDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        /// <summary>
        /// Select all record from Admin Role Detail table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminRoleApplicableDetailsBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleApplicableDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<AdminRoleApplicableDetails>();
                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails item = new AdminRoleApplicableDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                            item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                            item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
                        }

                        item.EmployeeName = item.EmployeeFirstName+" "+item.EmployeeMiddleName+" "+item.EmployeeLastName ;
                        if (DBNull.Value.Equals(sqlDataReader["Description"]) == false)
                        {
                            item.DesignationName = sqlDataReader["Description"].ToString();
                        }
                       // item.SactionedPostDescription = sqlDataReader["SactionedPostDescription"].ToString();
                       
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleCode"]) == false)
                        {
                            item.AdminRoleCode = sqlDataReader["AdminRoleCode"].ToString();
                        }
                        item.EmployeeID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.DesignationID = Convert.ToInt32(sqlDataReader["EmployeeDesignationMasterID"]);
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WorkFromDate"]) == false)
                        {
                            item.WorkFromDate = String.Format("{0:yyyy-MM-dd}", sqlDataReader["WorkFromDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Reason"]) == false)
                        {
                            item.Reason = sqlDataReader["Reason"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoleApllicableID"]) == false)
                        {
                            item.RoleApplicableID = Convert.ToInt32(sqlDataReader["RoleApllicableID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["AdminSnPostsID"]) == false)
                        //{
                        //    item.AdminSnPostsID = Convert.ToInt32(sqlDataReader["AdminSnPostsID"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        {
                            item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
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
                        throw new Exception("Stored Procedure 'USP_AdminRoleApplicableDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from Admin Role Detail table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleApplicableDetails> GetAdminRoleApplicableDetailsByID(AdminRoleApplicableDetails item)
        {
            IBaseEntityResponse<AdminRoleApplicableDetails> response = new BaseEntityResponse<AdminRoleApplicableDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleApplicableDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RoleApplicableID));
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails _item = new AdminRoleApplicableDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.RoleApplicableID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            _item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleCode"]) == false)
                        {
                            _item.AdminRoleCode = sqlDataReader["AdminRoleCode"].ToString();
                        }                        
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DesignationID"]) == false)
                        {
                            _item.DesignationID = Convert.ToInt32(sqlDataReader["DesignationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WorkFromDate"]) == false)
                        {
                            _item.WorkFromDate =  sqlDataReader["WorkFromDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WorkToDate"]) == false)
                        {
                            _item.WorkToDate = Convert.ToString(sqlDataReader["WorkToDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoleType"]) == false)
                        {
                            _item.RoleType = sqlDataReader["RoleType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Reason"]) == false)
                        {
                            _item.Reason = sqlDataReader["Reason"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
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
                        throw new Exception("Stored Procedure 'USP_AdminRoleApplicableDetails_SelectOne' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of Admin Role Detail
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleApplicableDetails> InsertAdminRoleApplicableDetails(AdminRoleApplicableDetails item)
        {
            IBaseEntityResponse<AdminRoleApplicableDetails> response = new BaseEntityResponse<AdminRoleApplicableDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleApplicableDetails_Insert_XML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4,
                                                                 ParameterDirection.Input, false, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.EmployeeID));                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 000,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                DataRowVersion.Proposed, item.SelectedIDs != null ? item.SelectedIDs : string.Empty));                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                                                 ParameterDirection.Input, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.CreatedBy));                 
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                                                 ParameterDirection.Output, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4,
                                                                ParameterDirection.Output, true, 10, 0, "",
                                                                DataRowVersion.Proposed, item.Status));

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
                    if ((Int32)cmdToExecute.Parameters["@iStatus"].Value == 1)
                    {
                        item.Status = (Int32)cmdToExecute.Parameters["@iStatus"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.LimitExceeds)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AdminRoleApplicableDetails_Insert_XML' reported the ErrorCode: " +
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
        /// Update a specific record of admin role detail
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleApplicableDetails> UpdateAdminRoleApplicableDetails(AdminRoleApplicableDetails item)
        {
            IBaseEntityResponse<AdminRoleApplicableDetails> response = new BaseEntityResponse<AdminRoleApplicableDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleApplicableDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterIDOld", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleMasterIDOld));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAdminRoleCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AdminRoleCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDesignationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DesignationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daWorkFromDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.WorkFromDate != null ? Convert.ToDateTime(item.WorkFromDate) : Convert.ToDateTime(DBNull.Value)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daWorkToDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.WorkToDate != null ? Convert.ToDateTime(item.WorkToDate) : Convert.ToDateTime(DBNull.Value)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sRoleType", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RoleType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sReason", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Reason));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ModifiedDate));
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

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AdminRoleApplicableDetails_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Delete a selected record from admin role detail.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleApplicableDetails> DeleteAdminRoleApplicableDetails(AdminRoleApplicableDetails item)
        {
            IBaseEntityResponse<AdminRoleApplicableDetails> response = new BaseEntityResponse<AdminRoleApplicableDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleApplicableDetails_Delete";
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

                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AdminRoleApplicableDetails_Delete' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from Admin Role Detail table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminRegularListBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRegularRoleList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID ", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));

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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleApplicableDetails>();
                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails item = new AdminRoleApplicableDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminSnPostID"]) == false)
                        {
                            item.AdminSnPostsID = Convert.ToInt32(sqlDataReader["AdminSnPostID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SanctPostName"]) == false)
                        {
                            item.SactionedPostDescription = sqlDataReader["SanctPostName"].ToString();
                        }
                     
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleCode"]) == false)
                        {
                            item.AdminRoleCode = sqlDataReader["AdminRoleCode"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["WorkFromDate"]) == false)
                        {
                            item.WorkFromDate = String.Format("{0:yyyy-MM-dd}", sqlDataReader["WorkFromDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["WorkToDate"]) == false)
                        {
                            item.WorkToDate = String.Format("{0:yyyy-MM-dd}", sqlDataReader["WorkToDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["Reason"]) == false)
                        {
                            item.Reason = sqlDataReader["Reason"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DesignationID"]) == false)
                        {
                            item.DesignationID = Convert.ToInt32(sqlDataReader["DesignationID"]);
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
                        throw new Exception("Stored Procedure 'USP_AdminRegularRoleList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminAdditionalListBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminAdditionalRoleList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));

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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleApplicableDetails>();
                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails item = new AdminRoleApplicableDetails();
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }                        
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleCode"]) == false)
                        {
                            item.AdminRoleCode = sqlDataReader["AdminRoleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        {
                            item.DepartmentIdWithName = sqlDataReader["DepartmentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        {
                            item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DesignationID"]) == false)
                        {
                            item.DesignationID = Convert.ToInt32(sqlDataReader["DesignationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoleApplicableID"]) == false)
                        {
                            item.RoleApplicableID = Convert.ToInt32(sqlDataReader["RoleApplicableID"]);
                        }  
                        if (DBNull.Value.Equals(sqlDataReader["WorkFromDate"]) == false)
                        {
                            item.WorkFromDate = sqlDataReader["WorkFromDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WorkToDate"]) == false)
                        {
                            item.WorkToDate = sqlDataReader["WorkToDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Reason"]) == false)
                        {
                            item.Reason = sqlDataReader["Reason"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }                       
                        if (DBNull.Value.Equals(sqlDataReader["StatusFlag"]) == false)
                        {
                            item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
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
                        throw new Exception("Stored Procedure 'USP_AdminAdditionalRoleList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetRoleListForLoginUserIDBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection1 = baseEntityCollection1 = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleApplicableDetails_ForRoleList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDefaultRoleId", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDefaultRoleCode", SqlDbType.NVarChar, 30, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID ", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));

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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleApplicableDetails>();
                 
                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails item = new AdminRoleApplicableDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleCode"]) == false)
                        {
                            item.AdminRoleCode = sqlDataReader["AdminRoleCode"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["DesignationID"]) == false)
                        {
                            item.DesignationID = Convert.ToInt32(sqlDataReader["DesignationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DefaultRoleId"]) == false)
                        {
                            item.DefaultRoleID = Convert.ToInt32(sqlDataReader["DefaultRoleId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DefaultRoleCode"]) == false)
                        {
                            item.DefaultRoleCode = sqlDataReader["DefaultRoleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoleType"]) == false)
                        {
                            item.RoleType = sqlDataReader["RoleType"].ToString();
                        }
                        baseEntityCollection.CollectionResponse.Add(item);  
                    }
                  
                    sqlDataReader.Close();
                  
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (cmdToExecute.Parameters["@iDefaultRoleId"].Value != null)
                    {
                      //item1.DefaultRoleID  = Convert.ToInt32(cmdToExecute.Parameters["@iDefaultRoleId"].Value);
                    }
                    if (cmdToExecute.Parameters["@nsDefaultRoleCode"].Value != null)
                    {
                    // item1.DefaultRoleCode = cmdToExecute.Parameters["@nsDefaultRoleCode"].Value.ToString();
                    }
                  
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AdminRoleApplicableDetails_ForRoleList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
           
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
                    cmdToExecute.CommandText = "dbo.USP_GetCentreListForHRManager";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleApplicableDetails>();
                 
                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails item = new AdminRoleApplicableDetails();
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsSuperUser"]) == false)
                        {
                            item.IsSuperUser = Convert.ToInt32(sqlDataReader["IsSuperUser"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsAcadMgr"]) == false)
                        {
                            item.IsAcadMgr = Convert.ToInt32(sqlDataReader["IsAcadMgr"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEstMgr"]) == false)
                        {
                            item.IsEstMgr = Convert.ToInt32(sqlDataReader["IsEstMgr"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsFinMgr"]) == false)
                        {
                            item.IsFinMgr = Convert.ToInt32(sqlDataReader["IsFinMgr"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsAdmMgr"]) == false)
                        {
                            item.IsAdmMgr = Convert.ToInt32(sqlDataReader["IsAdmMgr"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScopeIdentity"]) == false)
                        {
                            item.ScopeIdentity = sqlDataReader["ScopeIdentity"].ToString();
                        }
                      
                        baseEntityCollection.CollectionResponse.Add(item);  
                    }
                  
                    sqlDataReader.Close();                  
                 
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetCentreListForEstablishmentManager' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForAcademicManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();

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
                    cmdToExecute.CommandText = "dbo.USP_GetCentreListForAcademicManager";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleApplicableDetails>();

                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails item = new AdminRoleApplicableDetails();
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RightName"]) == false)
                        {
                            item.RightName = Convert.ToString(sqlDataReader["RightName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleRightTypeID"]) == false)
                        {
                            item.AdminRoleRightTypeID = Convert.ToInt16(sqlDataReader["AdminRoleRightTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScopeIdentity"]) == false)
                        {
                            item.ScopeIdentity = sqlDataReader["ScopeIdentity"].ToString();
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    sqlDataReader.Close();

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetCentreListForAcademicManager' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForFinanceManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();

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
                    cmdToExecute.CommandText = "dbo.USP_GetCentreListForFinanceManager";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleApplicableDetails>();

                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails item = new AdminRoleApplicableDetails();
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RightName"]) == false)
                        {
                            item.RightName = Convert.ToString(sqlDataReader["RightName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleRightTypeID"]) == false)
                        {
                            item.AdminRoleRightTypeID = Convert.ToInt16(sqlDataReader["AdminRoleRightTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScopeIdentity"]) == false)
                        {
                            item.ScopeIdentity = sqlDataReader["ScopeIdentity"].ToString();
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    sqlDataReader.Close();

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetCentreListForAcademicManager' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from 'AdminRoleMaster' and 'AdminSnPosts' and 'EmpEmployeeMaster'
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleApplicableDetails> SelectActiveAdminRoleCodeByEmployeeID(AdminRoleApplicableDetails item)
        {
            IBaseEntityResponse<AdminRoleApplicableDetails> response = new BaseEntityResponse<AdminRoleApplicableDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetActiveAdminRoleCode_ForEmployeeID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DepartmentID));
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
                        AdminRoleApplicableDetails _item = new AdminRoleApplicableDetails();
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleCode"]) == false)
                        {
                            _item.AdminRoleCode = sqlDataReader["AdminRoleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            _item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
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
                        throw new Exception("Stored Procedure 'USP_GetActiveAdminRoleCode_ForEmployeeID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForPurchaseManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();

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
                    cmdToExecute.CommandText = "dbo.USP_GetCentreListForPurchaseManager";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleApplicableDetails>();

                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails item = new AdminRoleApplicableDetails();
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RightName"]) == false)
                        {
                            item.RightName = Convert.ToString(sqlDataReader["RightName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleRightTypeID"]) == false)
                        {
                            item.AdminRoleRightTypeID = Convert.ToInt16(sqlDataReader["AdminRoleRightTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScopeIdentity"]) == false)
                        {
                            item.ScopeIdentity = sqlDataReader["ScopeIdentity"].ToString();
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    sqlDataReader.Close();

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetCentreListForAcademicManager' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForStoreManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();

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
                    cmdToExecute.CommandText = "dbo.USP_GetCentreListForStoreManager";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleApplicableDetails>();

                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails item = new AdminRoleApplicableDetails();
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RightName"]) == false)
                        {
                            item.RightName = Convert.ToString(sqlDataReader["RightName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleRightTypeID"]) == false)
                        {
                            item.AdminRoleRightTypeID = Convert.ToInt16(sqlDataReader["AdminRoleRightTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScopeIdentity"]) == false)
                        {
                            item.ScopeIdentity = sqlDataReader["ScopeIdentity"].ToString();
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    sqlDataReader.Close();

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetCentreListForAcademicManager' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForSalesManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();

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
                    cmdToExecute.CommandText = "dbo.USP_GetCentreListForSalesManager";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleApplicableDetails>();

                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails item = new AdminRoleApplicableDetails();
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RightName"]) == false)
                        {
                            item.RightName = Convert.ToString(sqlDataReader["RightName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleRightTypeID"]) == false)
                        {
                            item.AdminRoleRightTypeID = Convert.ToInt16(sqlDataReader["AdminRoleRightTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScopeIdentity"]) == false)
                        {
                            item.ScopeIdentity = sqlDataReader["ScopeIdentity"].ToString();
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    sqlDataReader.Close();

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetCentreListForAcademicManager' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForHRManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();

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
                    cmdToExecute.CommandText = "dbo.USP_GetCentreListForHRManager";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleApplicableDetails>();

                    while (sqlDataReader.Read())
                    {
                        AdminRoleApplicableDetails item = new AdminRoleApplicableDetails();
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RightName"]) == false)
                        {
                            item.RightName = Convert.ToString(sqlDataReader["RightName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleRightTypeID"]) == false)
                        {
                            item.AdminRoleRightTypeID = Convert.ToInt16(sqlDataReader["AdminRoleRightTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScopeIdentity"]) == false)
                        {
                            item.ScopeIdentity = sqlDataReader["ScopeIdentity"].ToString();
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    sqlDataReader.Close();

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetCentreListForAcademicManager' reported the ErrorCode: " + _errorCode);
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
