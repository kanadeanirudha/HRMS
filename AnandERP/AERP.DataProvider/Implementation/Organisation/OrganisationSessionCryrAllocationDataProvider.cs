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
    public class OrganisationSessionCryrAllocationDataProvider : DBInteractionBase, IOrganisationSessionCryrAllocationDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OrganisationSessionCryrAllocationDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OrganisationSessionCryrAllocationDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from OrganisationSessionCryrAllocation table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSessionCryrAllocation> GetOrganisationSessionCryrAllocationBySearch(OrganisationSessionCryrAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSessionCryrAllocation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSessionCryrAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSessionCourseYearAllocation_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEntityLevel", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ScopeIdentity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 100));//searchRequest.EndRow));
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


                    baseEntityCollection.CollectionResponse = new List<OrganisationSessionCryrAllocation>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSessionCryrAllocation item = new OrganisationSessionCryrAllocation();
                       // item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["SessionID"]) == false)
                        {
                            item.SessionID = Convert.ToInt32(sqlDataReader["SessionID"]);
                        }
                        item.OrgSemesterMstID = Convert.ToInt32(sqlDataReader["OrgSemesterMstID"]);
                        //New Fields
                        item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        item.SemesterType = sqlDataReader["SemesterType"].ToString();
                        item.OrgSemesterName = sqlDataReader["OrgSemesterName"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["OrgSessionCourseYearAllocationID"]) == false)
                        {
                            item.OrgSessionCourseYearAllocationID = Convert.ToInt32(sqlDataReader["OrgSessionCourseYearAllocationID"]);
                        }

                        item.OrgSessionCryrAllotStatus = Convert.ToBoolean(sqlDataReader["OrgSessionCryrAllotStatus"]);
                        item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        item.Current_CentreCode = sqlDataReader["CentreCode"].ToString();
                        //
                        item.CourseYearSemesterID = Convert.ToInt32(sqlDataReader["CourseYearSemesterID"]);
                        //item.SemesterUptoDate = Convert.ToDateTime(sqlDataReader["SemesterUptoDate"]);
                        //item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        //item.TotalExpectedWeeks = Convert.ToInt32(sqlDataReader["TotalExpectedWeeks"]);
                        //item.PeriodStartDate = Convert.ToDateTime(sqlDataReader["PeriodStartDate"]);
                        //item.PeriodEndDate = Convert.ToDateTime(sqlDataReader["PeriodEndDate"]);

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
                        throw new Exception("Stored Procedure 'USP_OrgSessionCourseYearAllocation_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> GetOrganisationSessionCryrAllocationByID(OrganisationSessionCryrAllocation item)
        {
            IBaseEntityResponse<OrganisationSessionCryrAllocation> response = new BaseEntityResponse<OrganisationSessionCryrAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSessionCryrAllocation_SelectOne";
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
                        OrganisationSessionCryrAllocation _item = new OrganisationSessionCryrAllocation();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.SessionID = Convert.ToInt32(sqlDataReader["SessionID"]);
                        _item.SemesterMasterID = Convert.ToInt32(sqlDataReader["SemesterMasterID"]);
                        _item.SemesterType = sqlDataReader["SemesterType"].ToString();
                        _item.CourseYearSemesterID = Convert.ToInt32(sqlDataReader["CourseYearSemesterID"]);
                        _item.SemesterFromDate = Convert.ToString(sqlDataReader["SemesterFromDate"]);
                        _item.SemesterUptoDate = Convert.ToString(sqlDataReader["SemesterUptoDate"]);
                        //_item.SemesterUptoDate =Convert.ToDateTime(sqlDataReader["SemesterUptoDate"]).ToString("dd MM yyyy"); ;
                        _item.CurrentActiveSemesterFlag = Convert.ToBoolean(sqlDataReader["CurrentActiveSemesterFlag"]);
                        _item.TotalExpectedWeeks = Convert.ToInt32(sqlDataReader["TotalExpectedWeeks"]);
                        _item.PeriodStartDate = Convert.ToString(sqlDataReader["PeriodStartDate"]);
                        _item.PeriodEndDate = Convert.ToString(sqlDataReader["PeriodEndDate"]);
                        //_item.PeriodEndDate = Convert.ToDateTime(sqlDataReader["PeriodEndDate"]).ToString("dd MM yyyy"); ;

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
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> GetCurrentSession(OrganisationSessionCryrAllocation item)
        {
            IBaseEntityResponse<OrganisationSessionCryrAllocation> response = new BaseEntityResponse<OrganisationSessionCryrAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSessionCryrAllocation_GetCurrentSession";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
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
                        OrganisationSessionCryrAllocation _item = new OrganisationSessionCryrAllocation();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.SessionID = Convert.ToInt32(sqlDataReader["SessionID"]);
                        _item.SessionName = Convert.ToString(sqlDataReader["SessionName"]);
                        //_item.SemesterType = sqlDataReader["SemesterType"].ToString();
                        //_item.CourseYearSemesterID = Convert.ToInt32(sqlDataReader["CourseYearSemesterID"]);
                        //_item.SemesterFromDate = Convert.ToDateTime(sqlDataReader["SemesterFromDate"]);
                        //_item.SemesterUptoDate = Convert.ToDateTime(sqlDataReader["SemesterUptoDate"]);
                        //_item.CurrentActiveSemesterFlag = Convert.ToBoolean(sqlDataReader["CurrentActiveSemesterFlag"]);
                        //_item.TotalExpectedWeeks = Convert.ToInt32(sqlDataReader["TotalExpectedWeeks"]);
                        //_item.PeriodStartDate = Convert.ToDateTime(sqlDataReader["PeriodStartDate"]);
                        //_item.PeriodEndDate = Convert.ToDateTime(sqlDataReader["PeriodEndDate"]);

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
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> InsertOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item)
        {
            IBaseEntityResponse<OrganisationSessionCryrAllocation> response = new BaseEntityResponse<OrganisationSessionCryrAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSessionCryrAllocation_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSemesterMasterID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SemesterMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSemesterType", SqlDbType.VarChar, 1,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.SemesterType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearSemesterID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CourseYearSemesterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daSemesterFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.SemesterFromDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daSemesterUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.SemesterUptoDate)));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@daSemesterFromDate", SqlDbType.DateTime, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SemesterFromDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daSemesterUptoDate", SqlDbType.DateTime, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SemesterUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bCurrentActiveSemesterFlag", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CurrentActiveSemesterFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalExpectedWeeks", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.TotalExpectedWeeks));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daPeriodStartDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.PeriodStartDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daPeriodEndDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.PeriodEndDate)));
                    
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daPeriodStartDate", SqlDbType.DateTime, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.PeriodStartDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daPeriodEndDate", SqlDbType.DateTime, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.PeriodEndDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
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
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSessionCryrAllocation_INSERT' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of OrganisationSessionCryrAllocation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> UpdateOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item)
        {
            IBaseEntityResponse<OrganisationSessionCryrAllocation> response = new BaseEntityResponse<OrganisationSessionCryrAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSessionCryrAllocation_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSemesterMasterID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SemesterMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSemesterType", SqlDbType.VarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.SemesterType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearSemesterID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CourseYearSemesterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daSemesterFromDate", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SemesterFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daSemesterUptoDate", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SemesterUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bCurrentActiveSemesterFlag", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CurrentActiveSemesterFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalExpectedWeeks", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.TotalExpectedWeeks));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daPeriodStartDate", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.PeriodStartDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daPeriodEndDate", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.PeriodEndDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ModifiedBy));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSessionCryrAllocation_Delete' reported the ErrorCode: " +
                                        _errorCode);
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
        /// Delete a specific record of OrganisationSessionCryrAllocation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> DeleteOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item)
        {
            IBaseEntityResponse<OrganisationSessionCryrAllocation> response = new BaseEntityResponse<OrganisationSessionCryrAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSessionCryrAllocation_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, 1));//1 for hard delete
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.DeletedBy));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSessionCryrAllocation_Delete' reported the ErrorCode: " +
                                        _errorCode);
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
        #endregion
    }
}
