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
    public class OrganisationDirectorMasterDataProvider : DBInteractionBase, IOrganisationDirectorMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OrganisationDirectorMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OrganisationDirectorMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from OrgDirectorMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationDirectorMaster> GetOrganisationDirectorMasterBySearch(OrganisationDirectorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDirectorMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationDirectorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationDirectorMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsEntityLevel", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EntityLevel));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));

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
                    baseEntityCollection.CollectionResponse = new List<OrganisationDirectorMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationDirectorMaster item = new OrganisationDirectorMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrgMembersMasterID"]) == false)
                        {
                            item.OrganisationMembersMasterID = Convert.ToInt32(sqlDataReader["OrgMembersMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLifeTimeDirector"]) == false)
                        {
                            item.IsLifeTimeDirector = Convert.ToBoolean(sqlDataReader["IsLifeTimeDirector"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DesignationID"]) == false)
                        {
                            item.DesignationID = Convert.ToInt32(sqlDataReader["DesignationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JoiningDate"]) == false)
                        {
                            item.JoiningDate = sqlDataReader["JoiningDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeavingDate"]) == false)
                        {
                            item.LeavingDate = sqlDataReader["LeavingDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrintingSeqOrder"]) == false)
                        {
                            item.PrintingSeqOrder = Convert.ToInt32(sqlDataReader["PrintingSeqOrder"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCurrentDirector"]) == false)
                        {
                            item.IsCurrentDirector = Convert.ToBoolean(sqlDataReader["IsCurrentDirector"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedBy"]) == false)
                        {
                            item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
                        {
                            item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonID"]) == false)
                        {
                            item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonType"]) == false)
                        {
                            item.PersonType = sqlDataReader["PersonType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstName"]) == false)
                        {
                            item.FirstName = sqlDataReader["FirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MiddleName"]) == false)
                        {
                            item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastName"]) == false)
                        {
                            item.LastName = sqlDataReader["LastName"].ToString();
                        }

                        // Description set to Extra Feild Designation.
                        if (DBNull.Value.Equals(sqlDataReader["Description"]) == false)
                        {
                            item.Designation = sqlDataReader["Description"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_OrgDirectorMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<OrganisationDirectorMaster> GetOrganisationDirectorMasterByID(OrganisationDirectorMaster item)
        {
            IBaseEntityResponse<OrganisationDirectorMaster> response = new BaseEntityResponse<OrganisationDirectorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationDirectorMaster_SelectOne";
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
                        OrganisationDirectorMaster _item = new OrganisationDirectorMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrgMembersMasterID"]) == false)
                        {
                            _item.OrganisationMembersMasterID = Convert.ToInt32(sqlDataReader["OrgMembersMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLifeTimeDirector"]) == false)
                        {
                            _item.IsLifeTimeDirector = Convert.ToBoolean(sqlDataReader["IsLifeTimeDirector"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DesignationID"]) == false)
                        {
                            _item.DesignationID = Convert.ToInt32(sqlDataReader["DesignationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JoiningDate"]) == false)
                        {
                            _item.JoiningDate = sqlDataReader["JoiningDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeavingDate"]) == false)
                        {
                            _item.LeavingDate = sqlDataReader["LeavingDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrintingSeqOrder"]) == false)
                        {
                            _item.PrintingSeqOrder = Convert.ToInt32(sqlDataReader["PrintingSeqOrder"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCurrentDirector"]) == false)
                        {
                            _item.IsCurrentDirector = Convert.ToBoolean(sqlDataReader["IsCurrentDirector"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            _item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedBy"]) == false)
                        {
                            _item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            _item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
                        //{
                        //    _item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        //{
                        //    _item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["PersonID"]) == false)
                        {
                            _item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonType"]) == false)
                        {
                            _item.PersonType = sqlDataReader["PersonType"].ToString();
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
        public IBaseEntityResponse<OrganisationDirectorMaster> InsertOrganisationDirectorMaster(OrganisationDirectorMaster item)
        {
            IBaseEntityResponse<OrganisationDirectorMaster> response = new BaseEntityResponse<OrganisationDirectorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationDirectorMaster_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOrgMembersMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OrganisationMembersMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLifeTimeDirector", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsLifeTimeDirector));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDesignationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DesignationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daJoiningDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.JoiningDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daLeavingDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPrintingSeqOrder", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PrintingSeqOrder));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCurrentDirector", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsCurrentDirector));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CreatedBy));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPersonType", SqlDbType.Char, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PersonType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MiddleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastName));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive == false ? item.IsActive : false));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.UserID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.Status));


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
                        throw new Exception("Stored Procedure 'dbo.USP_OrgDirectorMaster_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of OrgDirectorMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationDirectorMaster> UpdateOrganisationDirectorMaster(OrganisationDirectorMaster item)
        {
            IBaseEntityResponse<OrganisationDirectorMaster> response = new BaseEntityResponse<OrganisationDirectorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationDirectorMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLifeTimeDirector", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsLifeTimeDirector));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daLeavingDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LeavingDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCurrentDirector", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsCurrentDirector));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    

                   // cmdToExecute.Parameters.Add(new SqlParameter("@iOrgMembersMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OrganisationMembersMasterID));                    
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iDesignationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DesignationID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daJoiningDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.JoiningDate));                    
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iPrintingSeqOrder", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PrintingSeqOrder));                    
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeleted", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsDeleted));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daCreatedDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CreatedDate));                    
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daModifiedDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedDate));
                                        
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
                    //item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgDirectorMaster_Delete' reported the ErrorCode: " + _errorCode);
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
        /// Delete a specific record of OrgDirectorMaster
        /// No Functionality available for Organisation Director Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationDirectorMaster> DeleteOrganisationDirectorMaster (OrganisationDirectorMaster item)
        {
            IBaseEntityResponse<OrganisationDirectorMaster> response = new BaseEntityResponse<OrganisationDirectorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationDirectorMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    //item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrganisationDirectorMaster_Delete' reported the ErrorCode: " +
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
        /// Select all record from OrganisationMemberMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationDirectorMaster> GetUserEntityCentrewiseSearchList(OrganisationDirectorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDirectorMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationDirectorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationDirectorMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));

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
                    baseEntityCollection.CollectionResponse = new List<OrganisationDirectorMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationDirectorMaster item = new OrganisationDirectorMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.OrganisationMembersMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonID"]) == false)
                        {
                            item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonType"]) == false)
                        {
                            item.PersonType = sqlDataReader["PersonType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstName"]) == false)
                        {
                            item.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MiddleName"]) == false)
                        {
                            item.MiddleName = Convert.ToString(sqlDataReader["MiddleName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastName"]) == false)
                        {
                            item.LastName = Convert.ToString(sqlDataReader["LastName"]);
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
                        throw new Exception("Stored Procedure 'USP_OrganisationMemberMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
