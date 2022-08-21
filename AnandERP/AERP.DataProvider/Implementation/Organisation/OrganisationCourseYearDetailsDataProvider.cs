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
    public class OrganisationCourseYearDetailsDataProvider : DBInteractionBase, IOrganisationCourseYearDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OrganisationCourseYearDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OrganisationCourseYearDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from OrganisationCourseYearDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetOrganisationCourseYearDetailsBySearch(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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

                    baseEntityCollection.CollectionResponse = new List<OrganisationCourseYearDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationCourseYearDetails item = new OrganisationCourseYearDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"]);
                        item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        if (sqlDataReader["Description"].ToString() != null)
                        {
                            item.CourseDescription = sqlDataReader["Description"].ToString();
                        }
                        else item.CourseDescription="";
                      
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearID"]) == false)
                        {
                            item.CourseYearID = Convert.ToInt32(sqlDataReader["CourseYearID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["StreamDescription"]) == false)
                        {
                            item.StreamDescription = Convert.ToString(sqlDataReader["StreamDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StreamID"]) == false)
                        {
                            item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);
                        }
                        //if (sqlDataReader["StreamID"] == null)
                        //{
                        //    item.StreamID = 0;
                        //}0
                        //else
                        //item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);

                        //item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        //item.StandardID = Convert.ToInt32(sqlDataReader["StandardID"]);
                        //item.MediumID = Convert.ToInt32(sqlDataReader["MediumID"]);
                        //item.Duration = Convert.ToInt32(sqlDataReader["Duration"]);
                        //item.Description = sqlDataReader["Description"].ToString();
                        //item.BranchActive = Convert.ToBoolean(sqlDataReader["BranchActive"]);
                        //item.SectionCapacity = Convert.ToInt32(sqlDataReader["SectionCapacity"]);
                        //item.ExamApplicable = Convert.ToBoolean(sqlDataReader["ExamApplicable"]);
                        //item.NextCourseYearDetailID = sqlDataReader["NextCourseYearDetailID"].ToString();
                        //item.ExamPattern = Convert.ToBoolean(sqlDataReader["ExamPattern"]);
                        //item.NumberOfSemester = Convert.ToInt32(sqlDataReader["NumberOfSemester"]);
                        //item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        //item.DegreeName = sqlDataReader["DegreeName"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_OrgCourseYearDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<OrganisationCourseYearDetails> GetOrganisationCourseYearDetailsByID(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> response = new BaseEntityResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetails_SelectOne";
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
                        OrganisationCourseYearDetails _item = new OrganisationCourseYearDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);
                        _item.StreamDescription = Convert.ToString(sqlDataReader["StreamDescription"]);
                        _item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        _item.StandardID = Convert.ToInt32(sqlDataReader["StandardID"]);
                        _item.MediumID = Convert.ToInt32(sqlDataReader["MediumID"]);
                        _item.Duration = Convert.ToInt32(sqlDataReader["Duration"]);
                        _item.Description = sqlDataReader["Description"].ToString();
                        _item.BranchActive = Convert.ToBoolean(sqlDataReader["BranchActive"]);
                        _item.SectionCapacity = Convert.ToInt32(sqlDataReader["SectionCapacity"]);
                        _item.ExamApplicable = sqlDataReader["ExamApplicable"].ToString();
                        _item.NextCourseYearDetailID = sqlDataReader["NextCourseYearDetailID"].ToString();
                        _item.ExamPattern = sqlDataReader["ExamPattern"].ToString();
                        _item.NumberOfSemester = Convert.ToInt32(sqlDataReader["NumberOfSemester"]);
                        _item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        _item.DegreeName = sqlDataReader["DegreeName"].ToString();

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
        public IBaseEntityResponse<OrganisationCourseYearDetails> InsertOrganisationCourseYearDetails(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> response = new BaseEntityResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetails_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStreamID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.StreamID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.BranchID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.StandardID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMediumID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.MediumID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDuration", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.Duration));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.NVarChar, 240,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.Description.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bBranchActive", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.BranchActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionCapacity", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SectionCapacity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cExamApplicable", SqlDbType.Char, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ExamApplicable));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sNextCourseYearDetailID", SqlDbType.VarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.NextCourseYearDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cExamPattern", SqlDbType.Char, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ExamPattern));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNumberOfSemester", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.NumberOfSemester));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sCourseYearCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CourseYearCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sDegreeName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DegreeName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSemesterIDs", SqlDbType.VarChar, 2000,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.SemesterIDs));
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgCourseYearDetails_INSERT' reported the ErrorCode: " +_errorCode);
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
        /// Update a specific record of OrganisationCourseYearDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearDetails> UpdateOrganisationCourseYearDetails(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> response = new BaseEntityResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStreamID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.StreamID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iBranchID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.BranchID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.StandardID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMediumID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.MediumID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDuration", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.Duration));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Description.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bBranchActive", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.BranchActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionCapacity", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SectionCapacity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cExamApplicable", SqlDbType.Char, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ExamApplicable));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sNextCourseYearDetailID", SqlDbType.VarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.NextCourseYearDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cExamPattern", SqlDbType.Char, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ExamPattern));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNumberOfSemester", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.NumberOfSemester));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sCourseYearCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CourseYearCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sDegreeName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DegreeName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSemesterIDs", SqlDbType.VarChar, 2000,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.SemesterIDs));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ModifiedBy));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgCourseYearDetails_Delete' reported the ErrorCode: " +_errorCode);
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
        /// Delete a specific record of OrganisationanisationCourseYearDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearDetails> DeleteOrganisationCourseYearDetails(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> response = new BaseEntityResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, 1));// 1 FOR HARD DELETE
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
                        throw new Exception("Stored Procedure 'dbo.USP_OrgCourseYearDetails_Delete' reported the ErrorCode: " +
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
        /// Select a record from table by ID For CourseDescription
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearDetails> GetOrganisationCourseYearDetailsByID_For_CourseDescription(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> response = new BaseEntityResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgDivisionMaster_SelectOne_For_CourseDescription";
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
                        OrganisationCourseYearDetails _item = new OrganisationCourseYearDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        // _item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        _item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        //_item.PresentIntake = Convert.ToInt32(sqlDataReader["PresentIntake"]);
                        //_item.IntroductionYear = Convert.ToInt32(sqlDataReader["IntroductionYear"]);
                        //_item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);
                        //_item.DteCode = sqlDataReader["DteCode"].ToString();
                        //_item.BranchPrintingSequence = Convert.ToInt32(sqlDataReader["BranchPrintingSequence"]);

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
        /// Select all record from OrganisationCourseYearDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetSemesterApplicableBySearch(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetails_ApplicableSemister";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearID));
                 

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

                    baseEntityCollection.CollectionResponse = new List<OrganisationCourseYearDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationCourseYearDetails item = new OrganisationCourseYearDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.OrgSemesterName = sqlDataReader["OrgSemesterName"].ToString();
                        item.SemesterType = sqlDataReader["SemesterType"].ToString();
                        item.SemesterStatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearDetailID"]) == false)
                        {
                            item.CourseYearID = Convert.ToInt32(sqlDataReader["CourseYearDetailID"]);
                        }
                        
                        item.CourseYearSemesterID = Convert.ToInt32(sqlDataReader["CourseYearSemesterID"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                       // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgCourseYearDetails_ApplicableSemister' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails>GetCourseYearListRole_CentreCode_UniversityWise(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleApplicableCourseYear";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sScopeIdentity", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ScopeIdentity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.RoleId));
 
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

                    baseEntityCollection.CollectionResponse = new List<OrganisationCourseYearDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationCourseYearDetails item = new OrganisationCourseYearDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        if (sqlDataReader["Description"].ToString() != null)
                        {
                            item.CourseDescription = sqlDataReader["Description"].ToString();
                        }
                        else item.CourseDescription = "";

                        baseEntityCollection.CollectionResponse.Add(item);
                      
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgCourseYearDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<OrganisationCourseYearDetails> SelectByBranchDetIDAndStandardNumber(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> response = new BaseEntityResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetails_ByBranchDetIdAndStandNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDelId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BranchDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StandardNumber));
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
                        OrganisationCourseYearDetails _item = new OrganisationCourseYearDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        _item.Description = sqlDataReader["Description"].ToString();

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
        /// Select all record from OrganisationCourseYearDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearListRoleWise(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetails_RoleWiseList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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

                    baseEntityCollection.CollectionResponse = new List<OrganisationCourseYearDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationCourseYearDetails item = new OrganisationCourseYearDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"]);
                        item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        if (sqlDataReader["Description"].ToString() != null)
                        {
                            item.CourseDescription = sqlDataReader["Description"].ToString();
                        }
                        else item.CourseDescription = "";

                        if (DBNull.Value.Equals(sqlDataReader["CourseYearID"]) == false)
                        {
                            item.CourseYearID = Convert.ToInt32(sqlDataReader["CourseYearID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["StreamDescription"]) == false)
                        {
                            item.StreamDescription = Convert.ToString(sqlDataReader["StreamDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StreamID"]) == false)
                        {
                            item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);
                        }
                        //if (sqlDataReader["StreamID"] == null)
                        //{
                        //    item.StreamID = 0;
                        //}0
                        //else
                        //item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);

                        //item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        //item.StandardID = Convert.ToInt32(sqlDataReader["StandardID"]);
                        //item.MediumID = Convert.ToInt32(sqlDataReader["MediumID"]);
                        //item.Duration = Convert.ToInt32(sqlDataReader["Duration"]);
                        //item.Description = sqlDataReader["Description"].ToString();
                        //item.BranchActive = Convert.ToBoolean(sqlDataReader["BranchActive"]);
                        //item.SectionCapacity = Convert.ToInt32(sqlDataReader["SectionCapacity"]);
                        //item.ExamApplicable = Convert.ToBoolean(sqlDataReader["ExamApplicable"]);
                        //item.NextCourseYearDetailID = sqlDataReader["NextCourseYearDetailID"].ToString();
                        //item.ExamPattern = Convert.ToBoolean(sqlDataReader["ExamPattern"]);
                        //item.NumberOfSemester = Convert.ToInt32(sqlDataReader["NumberOfSemester"]);
                        //item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        //item.DegreeName = sqlDataReader["DegreeName"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_OrgCourseYearDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationCourseYearDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetNextCourseYearForPromotion(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetails_ListForBranchPromotion";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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

                    baseEntityCollection.CollectionResponse = new List<OrganisationCourseYearDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationCourseYearDetails item = new OrganisationCourseYearDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"]);
                        item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        if (sqlDataReader["Description"].ToString() != null)
                        {
                            item.CourseDescription = sqlDataReader["Description"].ToString();
                        }
                        else item.CourseDescription = "";

                        if (DBNull.Value.Equals(sqlDataReader["CourseYearID"]) == false)
                        {
                            item.CourseYearID = Convert.ToInt32(sqlDataReader["CourseYearID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["StreamDescription"]) == false)
                        {
                            item.StreamDescription = Convert.ToString(sqlDataReader["StreamDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StreamID"]) == false)
                        {
                            item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);
                        }
                        //if (sqlDataReader["StreamID"] == null)
                        //{
                        //    item.StreamID = 0;
                        //}0
                        //else
                        //item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);

                        //item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        //item.StandardID = Convert.ToInt32(sqlDataReader["StandardID"]);
                        //item.MediumID = Convert.ToInt32(sqlDataReader["MediumID"]);
                        //item.Duration = Convert.ToInt32(sqlDataReader["Duration"]);
                        //item.Description = sqlDataReader["Description"].ToString();
                        //item.BranchActive = Convert.ToBoolean(sqlDataReader["BranchActive"]);
                        //item.SectionCapacity = Convert.ToInt32(sqlDataReader["SectionCapacity"]);
                        //item.ExamApplicable = Convert.ToBoolean(sqlDataReader["ExamApplicable"]);
                        //item.NextCourseYearDetailID = sqlDataReader["NextCourseYearDetailID"].ToString();
                        //item.ExamPattern = Convert.ToBoolean(sqlDataReader["ExamPattern"]);
                        //item.NumberOfSemester = Convert.ToInt32(sqlDataReader["NumberOfSemester"]);
                        //item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        //item.DegreeName = sqlDataReader["DegreeName"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_OrgCourseYearDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailsByCentreCode(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetails_ByCentreCode";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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

                    baseEntityCollection.CollectionResponse = new List<OrganisationCourseYearDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationCourseYearDetails item = new OrganisationCourseYearDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["CourseYearDetailsID"]);
                        if (sqlDataReader["CourseYearDescription"].ToString() != null)
                        {
                            item.CourseDescription = sqlDataReader["CourseYearDescription"].ToString();
                        }
                        else item.CourseDescription = "";

                        if (DBNull.Value.Equals(sqlDataReader["CourseYearCode"]) == false)
                        {
                            item.CourseYearCode = Convert.ToString(sqlDataReader["CourseYearCode"]);
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
                        throw new Exception("Stored Procedure 'USP_OrgCourseYearDetails_ByCentreCode' reported the ErrorCode: " + _errorCode);
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




        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailSearchList(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetails_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
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

                    baseEntityCollection.CollectionResponse = new List<OrganisationCourseYearDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationCourseYearDetails item = new OrganisationCourseYearDetails();
                        if (sqlDataReader["ID"] != null)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (sqlDataReader["CourseYearDescription"].ToString() != null)
                        {
                            item.CourseDescription = sqlDataReader["CourseYearDescription"].ToString();
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
                        throw new Exception("Stored Procedure 'dbo.USP_OrgCourseYearDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        // 
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailDescription(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetailsDescription_SearchListForDropDown";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                   // cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
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

                    baseEntityCollection.CollectionResponse = new List<OrganisationCourseYearDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationCourseYearDetails item = new OrganisationCourseYearDetails();
                        if (sqlDataReader["ID"] != null)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (sqlDataReader["Description"].ToString() != null)
                        {
                            item.CourseDescription = sqlDataReader["Description"].ToString();
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
                        throw new Exception("Stored Procedure 'dbo.USP_OrgCourseYearDetailsDescription_SearchList' reported the ErrorCode: " + _errorCode);
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
