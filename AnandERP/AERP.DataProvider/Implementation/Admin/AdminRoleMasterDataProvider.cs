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
    public class AdminRoleMasterDataProvider : DBInteractionBase, IAdminRoleMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        public AdminRoleMasterDataProvider()
        {
        }

        public AdminRoleMasterDataProvider(ILogger logException)
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
        public IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminRoleMasterBySearch(AdminRoleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminPostApplicableToRole_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleMaster>();
                    while (sqlDataReader.Read())
                    {
                        AdminRoleMaster item = new AdminRoleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminSnPostID"]) == false)
                        {
                            item.AdminSnPostID = Convert.ToInt32(sqlDataReader["AdminSnPostID"]);
                        }

                        item.SanctPostName = sqlDataReader["SactionedPostDescription"].ToString();
                        //item.MonitoringLevel = sqlDataReader["MonitoringLevel"].ToString();
                        item.AdminRoleCode = sqlDataReader["AdminRoleCode"].ToString();
                        item.NoOfPosts = Convert.ToInt32(sqlDataReader["NoOfPosts"]);
                        item.NomenAdminRoleCode = sqlDataReader["NomenAdminRoleCode"].ToString();
                        item.Designation = sqlDataReader["Description"].ToString();
                        //item.IsAcadMgr = Convert.ToBoolean(sqlDataReader["IsAcadMgr"]);
                        //item.IsEstMgr = Convert.ToBoolean(sqlDataReader["IsEstMgr"]);
                        //item.IsFinMgr = Convert.ToBoolean(sqlDataReader["IsFinMgr"]);
                        //item.IsAdmMgr = Convert.ToBoolean(sqlDataReader["IsAdmMgr"]);
                        //item.IsDefaultRole = Convert.ToBoolean(sqlDataReader["IsDefaultRole"]);
                        //item.IsCopyForSame = Convert.ToBoolean(sqlDataReader["IsCopyForSame"]);
                        //item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        //item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        //item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        //item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);

                        //if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
                        //{
                        //    item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        //{
                        //    item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["DeletedBy"]) == false)
                        //{
                        //    item.DeletedBy = Convert.ToInt32(sqlDataReader["DeletedBy"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["DeletedDate"]) == false)
                        //{
                        //    item.DeletedDate = Convert.ToDateTime(sqlDataReader["DeletedDate"]);
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
                        throw new Exception("Stored Procedure 'USP_AdminPostApplicableToRole_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// 
        public IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminRoleMasterBySearchForAdminRoleDetailsBySPD(AdminRoleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleMaster_SelectAllWAdminSnPostIDLogic";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminSnPostID", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdmSnPostID));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleMaster>();
                    while (sqlDataReader.Read())
                    {
                        AdminRoleMaster item = new AdminRoleMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.AdminSnPostID = Convert.ToInt32(sqlDataReader["AdminSnPostID"]);
                        item.SanctPostName = sqlDataReader["SanctPostName"].ToString();
                        item.MonitoringLevel = sqlDataReader["MonitoringLevel"].ToString();
                        item.AdminRoleCode = sqlDataReader["AdminRoleCode"].ToString();
                        item.OthCentreLevel = sqlDataReader["OthCentreLevel"].ToString();
                        //item.IsSuperUser = Convert.ToBoolean(sqlDataReader["IsSuperUser"]);
                        //item.IsAcadMgr = Convert.ToBoolean(sqlDataReader["IsAcadMgr"]);
                        //item.IsEstMgr = Convert.ToBoolean(sqlDataReader["IsEstMgr"]);
                        //item.IsFinMgr = Convert.ToBoolean(sqlDataReader["IsFinMgr"]);
                        item.IsAdmMgr = Convert.ToBoolean(sqlDataReader["IsAdmMgr"]);
                        item.IsDefaultRole = Convert.ToBoolean(sqlDataReader["IsDefaultRole"]);
                        item.IsCopyForSame = Convert.ToBoolean(sqlDataReader["IsCopyForSame"]);
                        item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);

                        if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
                        {
                            item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedBy"]) == false)
                        {
                            item.DeletedBy = Convert.ToInt32(sqlDataReader["DeletedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedDate"]) == false)
                        {
                            item.DeletedDate = Convert.ToDateTime(sqlDataReader["DeletedDate"]);
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
                        throw new Exception("Stored Procedure 'USP_AdminRoleMaster_SelectAllWAdminSnPostIDLogic' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from Admin Role CentreRights table by ID for showing other centre rights 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        public IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminCentreRightsByRole(AdminRoleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleCentreRightsByAdminRole";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleMaster>();
                    while (sqlDataReader.Read())
                    {
                        AdminRoleMaster item = new AdminRoleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        }
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.CentreName = sqlDataReader["CentreName"].ToString();

                        if (DBNull.Value.Equals(sqlDataReader["RightName"]) == false)
                        {
                            item.RightName = sqlDataReader["RightName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleRightTypeID"]) == false)
                        {
                            item.AdminRoleRightTypeID = Convert.ToInt16(sqlDataReader["AdminRoleRightTypeID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["RoleRightStatus"]) == false)
                        {
                            item.RoleRightStatus = sqlDataReader["RoleRightStatus"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleCentreRightsID"]) == false)
                        {
                            item.AdminRoleCentreRightsID = Convert.ToInt32(sqlDataReader["AdminRoleCentreRightsID"]);
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
                        throw new Exception("Stored Procedure 'USP_AdminRoleCentreRightsByAdminRole' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<AdminRoleMaster> GetDefaultRoleRightsType(AdminRoleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleDefaultRoleRightsType";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleMaster>();
                    while (sqlDataReader.Read())
                    {
                        AdminRoleMaster item = new AdminRoleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["RightName"]) == false)
                        {
                            item.RightName = sqlDataReader["RightName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleRightTypeID"]) == false)
                        {
                            item.AdminRoleRightTypeID = Convert.ToInt16(sqlDataReader["AdminRoleRightTypeID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["RoleRightStatus"]) == false)
                        {
                            item.RoleRightStatus = sqlDataReader["RoleRightStatus"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleCentreRightsID"]) == false)
                        {
                            item.AdminRoleCentreRightsID = Convert.ToInt32(sqlDataReader["AdminRoleCentreRightsID"]);
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
                        throw new Exception("Stored Procedure 'USP_AdminRoleCentreRightsByAdminRole' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<AdminRoleMaster> GetAdminRoleMasterByID(AdminRoleMaster item)
        {
            IBaseEntityResponse<AdminRoleMaster> response = new BaseEntityResponse<AdminRoleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleMaster_SelectOne";
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
                        AdminRoleMaster _item = new AdminRoleMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["AdminSnPostID"]) == false)
                        {
                            _item.AdminSnPostID = Convert.ToInt32(sqlDataReader["AdminSnPostID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SanctPostName"]) == false)
                        {
                            _item.SanctPostName = sqlDataReader["SanctPostName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MonitoringLevel"]) == false)
                        {
                            _item.MonitoringLevel = sqlDataReader["MonitoringLevel"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OthCentreLevel"]) == false)
                        {
                            _item.OthCentreLevel = sqlDataReader["OthCentreLevel"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleCode"]) == false)
                        {
                            _item.AdminRoleCode = sqlDataReader["AdminRoleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLoginAllowFromOutside"]) == false)
                        {
                            _item.IsLoginAllowFromOutside = Convert.ToBoolean(sqlDataReader["IsLoginAllowFromOutside"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsAttendaceAllowFromOutside"]) == false)
                        {
                            _item.IsAttendaceAllowFromOutside = Convert.ToBoolean(sqlDataReader["IsAttendaceAllowFromOutside"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DesignationType"]) == false)
                        {
                            _item.DesignationType = sqlDataReader["DesignationType"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_AdminRoleMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<AdminRoleMaster> InsertAdminRoleMaster(AdminRoleMaster item)
        {
            IBaseEntityResponse<AdminRoleMaster> response = new BaseEntityResponse<AdminRoleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminSnPostID", SqlDbType.Int, 4,
                                                                 ParameterDirection.Input, false, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.AdminSnPostID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSanctPostName", SqlDbType.NVarChar, 100,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                DataRowVersion.Proposed, item.SanctPostName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sMonitoringLevel", SqlDbType.NVarChar, 12,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                DataRowVersion.Proposed, item.MonitoringLevel));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOthCentreLevel", SqlDbType.NVarChar, 30,
                                                                ParameterDirection.Input, false, 0, 0, "",
                                                               DataRowVersion.Proposed, item.OthCentreLevel != null ? item.OthCentreLevel : string.Empty));
                    if (item.IDs != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000,
                                                                     ParameterDirection.Input, false, 0, 0, "",
                                                                    DataRowVersion.Proposed, item.IDs));
                    }else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                DataRowVersion.Proposed, item.AdminRoleMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsOthCentreLevel", SqlDbType.NVarChar, 30,
                    //                                             ParameterDirection.Input, false, 0, 0, "",
                    //                                            DataRowVersion.Proposed, item.OthCentreLevel));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsSuperUser", SqlDbType.Bit, 1,
                                                                 ParameterDirection.Input, true, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.IsSuperUser));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAcadMgr", SqlDbType.Bit, 1,
                                                                 ParameterDirection.Input, true, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.IsAcadMgr));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsEstMgr", SqlDbType.Bit, 1,
                                                                 ParameterDirection.Input, true, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.IsEstMgr));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsFinMgr", SqlDbType.Bit, 1,
                                                                 ParameterDirection.Input, true, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.IsFinMgr));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAdmMgr", SqlDbType.Bit, 1,
                                                                 ParameterDirection.Input, true, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.IsAdmMgr));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsDefaultRole", SqlDbType.Bit, 1,
                    //                                             ParameterDirection.Input, true, 0, 0, "",
                    //                                             DataRowVersion.Proposed, item.IsDefaultRole));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsCopyForSame", SqlDbType.Bit, 1,
                    //                                             ParameterDirection.Input, true, 0, 0, "",
                    //                                             DataRowVersion.Proposed, item.IsCopyForSame));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLoginAllowFromOutside", SqlDbType.Bit, 1,
                                                                 ParameterDirection.Input, true, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.IsLoginAllowFromOutside));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAttendaceAllowFromOutside", SqlDbType.Bit, 1,
                                                                 ParameterDirection.Input, true, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.IsAttendaceAllowFromOutside));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1,
                                                                 ParameterDirection.Input, true, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                                                 ParameterDirection.Input, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.CreatedBy));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iNewID", SqlDbType.Int, 4, ParameterDirection.Output,
                                                                 true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                                                 ParameterDirection.Output, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4,
                                                                 ParameterDirection.Output, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleCentreRightsStatus", SqlDbType.Int, 4,
                                                                 ParameterDirection.Output, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.AdminRoleCentreRightsStatus));
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
                        item.ID = (Int32)cmdToExecute.Parameters["@iNewID"].Value;
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
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.LimitExceeds)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AdminSnPosts_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of admin role detail
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleMaster> UpdateAdminRoleMaster(AdminRoleMaster item)
        {
            IBaseEntityResponse<AdminRoleMaster> response = new BaseEntityResponse<AdminRoleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminSnPostID ", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdminSnPostID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSanctPostName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SanctPostName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sMonitoringLevel", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MonitoringLevel));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOthCentreLevel", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OthCentreLevel));
                    if (item.IDs != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IDs));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsSuperUser", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsSuperUser));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAcadMgr", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsAcadMgr));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsEstMgr", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsEstMgr));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsFinMgr", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsFinMgr));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAdmMgr", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsAdmMgr));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAttendaceAllowFromOutside", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsAttendaceAllowFromOutside));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLoginAllowFromOutside", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsLoginAllowFromOutside));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@daModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ModifiedDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iNewID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleCentreRightsStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleCentreRightsStatus));
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
                        throw new Exception("Stored Procedure 'USP_AdminRoleMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Delete a selected record from admin role detail.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleMaster> DeleteAdminRoleMaster(AdminRoleMaster item)
        {
            IBaseEntityResponse<AdminRoleMaster> response = new BaseEntityResponse<AdminRoleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        throw new Exception("Stored Procedure 'USP_AdminRoleMaster_Delete' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminRoleDomainList(AdminRoleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<AdminRoleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRolDomainList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleDomainForID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleDomainForID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleDomainFor", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleDomainFor));
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

                    baseEntityCollection.CollectionResponse = new List<AdminRoleMaster>();
                    while (sqlDataReader.Read())
                    {
                        AdminRoleMaster item = new AdminRoleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleDomainID"]) == false)
                        {
                            item.AdminRoleDomainID = Convert.ToByte(sqlDataReader["AdminRoleDomainID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleDomainName"]) == false)
                        {
                            item.AdminRoleDomainName = sqlDataReader["AdminRoleDomainName"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleDomainApplicableID"]) == false)
                        {
                            item.AdminRoleDomainApplicableID = Convert.ToInt32(sqlDataReader["AdminRoleDomainApplicableID"]);
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
                        throw new Exception("Stored Procedure 'USP_AdminRoleCentreRightsByAdminRole' reported the ErrorCode: " + _errorCode);
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
