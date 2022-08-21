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
    public class OrganisationSubjectGroupDetailsDataProvider : DBInteractionBase, IOrganisationSubjectGroupDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OrganisationSubjectGroupDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OrganisationSubjectGroupDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from OrganisationSubjectGroupDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetOrganisationSubjectGroupDetailsBySearch(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSubjectGroupDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubjectGroupDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEntityLevel", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ScopeIdentity));

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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<OrganisationSubjectGroupDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSubjectGroupDetails item = new OrganisationSubjectGroupDetails();

                        if (DBNull.Value.Equals(sqlDataReader["OrgSubjectGroupID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["OrgSubjectGroupID"]);
                        }
                        //for Display
                        if (DBNull.Value.Equals(sqlDataReader["SubjectDescription"]) == false)
                        {
                            item.Description = sqlDataReader["SubjectDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectDescription"]) == true)
                        {
                            item.Description = "-".ToString();
                        }
                        item.ConcateField = sqlDataReader["ConcateField"].ToString();
                        item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        item.OrgSemesterName = sqlDataReader["OrgSemesterName"].ToString();
                        item.SemesterType = sqlDataReader["SemesterType"].ToString();
                        item.RuleName = sqlDataReader["RuleName"].ToString();
                        item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        // For Create                       
                        item.OrgSemesterMstID = Convert.ToInt32(sqlDataReader["OrgSemesterMstID"]);
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearId"]) == false)
                        {
                            item.CourseYearDetailID = Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        }

                        item.SubjectRuleGrpNumber = Convert.ToInt32(sqlDataReader["OrgSubjectGrpRuleID"]);

                        //item.CompulsoryOptionalFlag = sqlDataReader["CompulsoryOptionalFlag"].ToString();


                        //item.ElectiveGroupFlag = sqlDataReader["ElectiveGroupFlag"].ToString();
                        //item.OrgElectiveGrpID = Convert.ToInt32(sqlDataReader["OrgElectiveGrpID"]);
                        //item.ElectiveSubGroupFlag = sqlDataReader["ElectiveSubGroupFlag"].ToString();
                        //item.OrgSubElectiveGrpID = Convert.ToInt32(sqlDataReader["OrgSubElectiveGrpID"]);
                        //item.ElectiveSubjectCompFlag = sqlDataReader["ElectiveSubjectCompFlag"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_OrgSubjectGroupDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> GetOrganisationSubjectGroupDetailsByID(OrganisationSubjectGroupDetails item)
        {
            IBaseEntityResponse<OrganisationSubjectGroupDetails> response = new BaseEntityResponse<OrganisationSubjectGroupDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubjectGroupDetails_SelectOne";
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
                        OrganisationSubjectGroupDetails _item = new OrganisationSubjectGroupDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        _item.ShortDescription = sqlDataReader["ShortDescription"].ToString();
                        _item.Description = sqlDataReader["Description"].ToString();
                        _item.OrgSemesterMstID = Convert.ToInt32(sqlDataReader["OrgSemesterMstID"]);
                        _item.CourseYearDetailID = Convert.ToInt32(sqlDataReader["CourseYearDetailID"]);
                        _item.SubjectRuleGrpNumber = Convert.ToInt32(sqlDataReader["SubjectRuleGrpNumber"]);
                        if (sqlDataReader["CompulsoryOptionalFlag"].ToString() == "COMPULSORY")
                        {
                            _item.IsCompulsory = true;
                        }
                        else
                        {
                            _item.IsCompulsory = false;
                        }
                        _item.UniversityCode = sqlDataReader["UniversityCode"].ToString();
                        // _item.Pattern = sqlDataReader["Pattern"].ToString();


                        _item.ElectiveGroupFlag = sqlDataReader["ElectiveGroupFlag"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["OrgElectiveGrpID"]) == false)
                        {
                            _item.OrgElectiveGrpID = Convert.ToInt32(sqlDataReader["OrgElectiveGrpID"]);
                        }
                        _item.ElectiveSubGroupFlag = sqlDataReader["ElectiveSubGroupFlag"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["OrgSubElectiveGrpID"]) == false)
                        {
                            _item.OrgSubElectiveGrpID = Convert.ToInt32(sqlDataReader["OrgSubElectiveGrpID"]);
                        }
                        if (sqlDataReader["ElectiveSubjectCompFlag"].ToString() == "COMPULSORY")
                        {
                            _item.IsElectiveSubjectCompFlag = true;
                        }
                        else if (sqlDataReader["ElectiveSubjectCompFlag"].ToString() == "OPTIONAL")
                        {
                            _item.IsElectiveSubjectCompFlag = false;
                        }

                        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
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
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> InsertOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item)
        {
            IBaseEntityResponse<OrganisationSubjectGroupDetails> response = new BaseEntityResponse<OrganisationSubjectGroupDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubjectGroupDetails_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.SubjectID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsShortDescription", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ShortDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDescription", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Description));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOrgSemesterMstID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.OrgSemesterMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.CourseYearDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectRuleGrpNumber", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.SubjectRuleGrpNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sCompulsoryOptionalFlag", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CompulsoryOptionalFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityCode", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.UniversityCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveGroupFlag", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ElectiveGroupFlag));

                    if (item.OrgElectiveGrpID == 0 || item.OrgElectiveGrpID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOrgElectiveGrpID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOrgElectiveGrpID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.OrgElectiveGrpID));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveSubGroupFlag", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ElectiveSubGroupFlag));
                    if (item.OrgSubElectiveGrpID == 0 || item.OrgSubElectiveGrpID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOrgSubElectiveGrpID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOrgSubElectiveGrpID", SqlDbType.Int, 10,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.OrgSubElectiveGrpID));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveSubjectCompFlag", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ElectiveSubjectCompFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeleted", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, false));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOrganisationSubjectGrpCombinationIDs", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.SubjectGrpCombinationIDs));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOrganisationSubjectGrpMarksIDs", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.SubjectGrpMarksIDs));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOrganisationSubHoursGrpAllocationIDs", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.SubHoursGrpAllocationIDs));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.SessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNewID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, 0));
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
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSubjectGroupDetails_INSERT' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of OrganisationSubjectGroupDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> UpdateOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item)
        {
            IBaseEntityResponse<OrganisationSubjectGroupDetails> response = new BaseEntityResponse<OrganisationSubjectGroupDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubjectGroupDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.SubjectID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsShortDescription", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ShortDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDescription", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.Description));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOrgSemesterMstID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.OrgSemesterMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.CourseYearDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectRuleGrpNumber", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.SubjectRuleGrpNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sCompulsoryOptionalFlag", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.CompulsoryOptionalFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityCode", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.UniversityCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPattern", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.Pattern));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveGroupFlag", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ElectiveGroupFlag));
                    if (item.OrgElectiveGrpID == 0 || item.OrgElectiveGrpID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOrgElectiveGrpID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOrgElectiveGrpID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.OrgElectiveGrpID));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveSubGroupFlag", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ElectiveSubGroupFlag));
                    if (item.OrgSubElectiveGrpID == 0 || item.OrgSubElectiveGrpID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOrgSubElectiveGrpID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOrgSubElectiveGrpID", SqlDbType.Int, 10,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.OrgSubElectiveGrpID));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveSubjectCompFlag", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ElectiveSubjectCompFlag));

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
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSubjectGroupDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of OrganisationSubjectGroupDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> DeleteOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item)
        {
            IBaseEntityResponse<OrganisationSubjectGroupDetails> response = new BaseEntityResponse<OrganisationSubjectGroupDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubjectGroupDetails_Delete";
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
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSubjectGroupDetails_Delete' reported the ErrorCode: " +
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
        /// Select all record from OrganisationSubjectTypeMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetOrganisationSubjectTypeMasterBySearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSubjectGroupDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubjectGrpCombination_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCurrentSessionID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CurrentSessionID));
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSubjectGroupDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSubjectGroupDetails item = new OrganisationSubjectGroupDetails();
                        item.SubjectTypeID = Convert.ToInt16(sqlDataReader["SubjectTypeNumber"]);
                        item.SubjectType_Row = sqlDataReader["TypeName"].ToString();
                        item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);

                        if (DBNull.Value.Equals(sqlDataReader["MaxMarksInt"]) == false)
                        {
                            item.Internal_Max_Marks = Convert.ToInt16(sqlDataReader["MaxMarksInt"]);

                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectCombgrpID"]) == false)
                        {
                            item.SubjectCombgrpID = Convert.ToInt32(sqlDataReader["SubjectCombgrpID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectGrpMarksID"]) == false)
                        {
                            item.SubjectGrpMarksID = Convert.ToInt32(sqlDataReader["SubjectGrpMarksID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PassingMarksInt"]) == false)
                        {
                            item.Internal_Passing_Marks = Convert.ToInt32(sqlDataReader["PassingMarksInt"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaxMarksExt"]) == false)
                        {
                            item.External_Max_Marks = Convert.ToInt32(sqlDataReader["MaxMarksExt"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["PassingMarksExt"]) == false)
                        {
                            item.External_Passing_Marks = Convert.ToInt32(sqlDataReader["PassingMarksExt"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["GroupPassingMarks"]) == false)
                        {
                            item.External_Group_Min_Marks = Convert.ToInt32(sqlDataReader["GroupPassingMarks"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MaxGroupMarks"]) == false)
                        {
                            item.External_Group_Max_Marks = Convert.ToInt32(sqlDataReader["MaxGroupMarks"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ExamHours"]) == false)
                        {
                            item.ExamHours = Convert.ToInt32(sqlDataReader["ExamHours"]);
                        }

                        if (sqlDataReader["Internal"].ToString() == "I")
                        {
                            item.Internal_Row = true;
                        }
                        else
                        {
                            item.Internal_Row = false;
                        }
                        if (sqlDataReader["ExternalFlag"].ToString() == "E")
                        {
                            item.External_Row = true;
                        }
                        else
                        {
                            item.External_Row = false;
                        }

                        if (DBNull.Value.Equals(sqlDataReader["TotalNumberOfHours"]) == false)
                        {
                            item.WeeklyPeriodAllocation = Convert.ToInt32(sqlDataReader["TotalNumberOfHours"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubHoursGrpAllocationID"]) == false)
                        {
                            item.SubHoursGrpAllocationID = Convert.ToInt32(sqlDataReader["SubHoursGrpAllocationID"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                        //baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgSubjectGrpCombination_SelectOne' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationSubjectTypeMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetOrganisationElectiveGroupBySearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSubjectGroupDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgElectiveGrpMaster_SelectBy_SubjectRuleGrpNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectRuleGrpNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SubjectRuleGrpNumber));

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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSubjectGroupDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSubjectGroupDetails item = new OrganisationSubjectGroupDetails();
                        item.OrgElectiveGrpID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.ElectiveGroupName = sqlDataReader["GroupName"].ToString();
                        // item.TypeShortCode = sqlDataReader["TypeShortCode"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                        //baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgElectiveGrpMaster_SelectBy_SubjectRuleGrpNumber' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationSubjectTypeMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetSubOrganisationElectiveGroupBySearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSubjectGroupDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgElectiveGrpMaster_SelectBy_OrgElectiveGrpID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOrgElectiveGrpID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.OrgElectiveGrpID));

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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSubjectGroupDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSubjectGroupDetails item = new OrganisationSubjectGroupDetails();
                        item.OrgSubElectiveGrpID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.OrgSubElectiveGrpDescription = sqlDataReader["Description"].ToString();
                        // item.TypeShortCode = sqlDataReader["TypeShortCode"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                        //baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgElectiveGrpMaster_SelectBy_OrgElectiveGrpID' reported the ErrorCode: " + _errorCode);
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
        //used in OnlineExam
        /// <summary>
        /// Select all record from OrganisationSubjectTypeMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetByDescriptionList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSubjectGroupDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubjectGroupDetails_DesciptionList";
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSubjectGroupDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSubjectGroupDetails item = new OrganisationSubjectGroupDetails();
                        item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.Description = sqlDataReader["Description"].ToString();
                        // item.TypeShortCode = sqlDataReader["TypeShortCode"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                        //baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrganisationSubjectGroupDetails_DesciptionList' reported the ErrorCode: " + _errorCode);
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
