
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
	public class OrganisationSectionDetailsDataProvider : DBInteractionBase,IOrganisationSectionDetailsDataProvider
	{
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public OrganisationSectionDetailsDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public OrganisationSectionDetailsDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
		#region Method Implementation
		/// <summary>
		/// Select all record from OrganisationSectionDetails table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<OrganisationSectionDetails>     GetOrganisationSectionDetailsBySearch(OrganisationSectionDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
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
					cmdToExecute.CommandText = "dbo.USP_OrgSectionDetails_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
					cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
					baseEntityCollection.CollectionResponse = new List<OrganisationSectionDetails>();
					while (sqlDataReader.Read())
					{
						OrganisationSectionDetails item = new OrganisationSectionDetails();
						item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);
						item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        item.BranchDescriptions = sqlDataReader["BranchDescription"].ToString();
						item.StandardID = Convert.ToInt32(sqlDataReader["StandardID"]);
                        item.StandardDescriptions = sqlDataReader["STANDARDDESCRIPTION"].ToString();
                        item.StandardNumber = Convert.ToInt32(sqlDataReader["StandardNumber"]);
						//item.MediumID = Convert.ToInt32(sqlDataReader["MediumID"]);
						//item.Duration = Convert.ToInt32(sqlDataReader["Duration"]);
						item.CourseYearDescriptions = sqlDataReader["Descriptions"].ToString();
						item.SectionID = Convert.ToInt32(sqlDataReader["SectionID"]);
						//item.SectionActive = Convert.ToBoolean(sqlDataReader["SectionActive"]);
						//item.SectionCapacity = Convert.ToInt32(sqlDataReader["SectionCapacity"]);
						//item.ExamApplicable = sqlDataReader["ExamApplicable"].ToString();
						//item.NextSectionDetailID = sqlDataReader["NextSectionDetailID"].ToString();
						item.ExamPattern = sqlDataReader["ExamPattern"].ToString();
						item.NumberOfSemester = Convert.ToInt32(sqlDataReader["NumberOfSemester"]);
						item.SectionDetailCode = sqlDataReader["SectionDetailCode"].ToString();
						item.DegreeName = sqlDataReader["DegreeName"].ToString();
						item.CourseYearDetailID = Convert.ToInt32(sqlDataReader["CourseYearDetailID"]);
						item.BranchDetID = Convert.ToInt32(sqlDataReader["BranchDetID"]);
						item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
						//item.CourseStartDetID = Convert.ToInt32(sqlDataReader["CourseStartDetID"]);
						//item.ActualExamPattern = Convert.ToBoolean(sqlDataReader["ActualExamPattern"]);
						//item.OrgShiftCode = sqlDataReader["OrgShiftCode"].ToString();

						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_OrgSectionDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// 
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsRole_CentreCode_UniversityWise(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleApplicableSectionDetails";
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSectionDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSectionDetails item = new OrganisationSectionDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                      //  item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        item.CourseYearDescriptions = sqlDataReader["CourseYearDescription"].ToString();
                        item.Descriptions = sqlDataReader["SectionDetailDescription"].ToString();
                        item.SectionDetailCode = sqlDataReader["SectionDetailCode"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                     
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgSectionDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
		
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetOrganisationSectionDetailsByID(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSectionDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BranchDetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardNo", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StandardNumber));
                  
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSectionDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSectionDetails item = new OrganisationSectionDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);
                        //item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        //item.BranchDescriptions = sqlDataReader["BranchDescription"].ToString();
                        //item.StandardID = Convert.ToInt32(sqlDataReader["StandardID"]);
                        //item.StandardDescriptions = sqlDataReader["STANDARDDESCRIPTION"].ToString();
                        //item.StandardNumber = Convert.ToInt32(sqlDataReader["StandardNumber"]);
                        //item.MediumID = Convert.ToInt32(sqlDataReader["MediumID"]);
                        //item.Duration = Convert.ToInt32(sqlDataReader["Duration"]);
                        item.CourseYearDescriptions = sqlDataReader["Descriptions"].ToString();
                        //item.SectionID = Convert.ToInt32(sqlDataReader["SectionID"]);
                        ////item.SectionActive = Convert.ToBoolean(sqlDataReader["SectionActive"]);
                        ////item.SectionCapacity = Convert.ToInt32(sqlDataReader["SectionCapacity"]);
                        ////item.ExamApplicable = sqlDataReader["ExamApplicable"].ToString();
                        ////item.NextSectionDetailID = sqlDataReader["NextSectionDetailID"].ToString();
                        //item.ExamPattern = sqlDataReader["ExamPattern"].ToString();
                        //item.NumberOfSemester = Convert.ToInt32(sqlDataReader["NumberOfSemester"]);
                        //item.SectionDetailCode = sqlDataReader["SectionDetailCode"].ToString();
                        //item.DegreeName = sqlDataReader["DegreeName"].ToString();
                        //item.CourseYearDetailID = Convert.ToInt32(sqlDataReader["CourseYearDetailID"]);
                        //item.BranchDetID = Convert.ToInt32(sqlDataReader["BranchDetID"]);
                        //item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //item.CourseStartDetID = Convert.ToInt32(sqlDataReader["CourseStartDetID"]);
                        //item.ActualExamPattern = Convert.ToBoolean(sqlDataReader["ActualExamPattern"]);
                        //item.OrgShiftCode = sqlDataReader["OrgShiftCode"].ToString();
                        item.IsFinalCourseYear = Convert.ToBoolean(sqlDataReader["IsFinalCourseYear"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                  
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgSectionDetails_SelectOne' reported the ErrorCode: " + _errorCode);
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
		/// Create new record of the table
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSectionDetails> InsertOrganisationSectionDetails(OrganisationSectionDetails item)
		{
			IBaseEntityResponse<OrganisationSectionDetails> response = new BaseEntityResponse<OrganisationSectionDetails>();
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
					cmdToExecute.CommandText = "dbo.USP_OrgSectionDetails_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStreamID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.StreamID));

					cmdToExecute.Parameters.Add(new SqlParameter("@iBranchID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.BranchID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStandardID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.StandardID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iMediumID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.MediumID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siDuration", SqlDbType.Int, 5,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.Duration));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsDescriptions", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.Descriptions.Trim()));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSectionID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.SectionID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bSectionActive", SqlDbType.Bit,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.SectionActive));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSectionCapacity", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.SectionCapacity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cExamApplicable", SqlDbType.VarChar, 0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.ExamApplicable));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sNextSectionDetailID", SqlDbType.VarChar,0,
                    //                        ParameterDirection.Input,false,10,0,"",
                    //                        DataRowVersion.Proposed, item.NextSectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cExamPattern", SqlDbType.VarChar, 0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.ExamPattern));
					cmdToExecute.Parameters.Add(new SqlParameter("@iNumberOfSemester", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.NumberOfSemester));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsSectionDetailCode", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
                                            DataRowVersion.Proposed, item.SectionDetailCode.Trim()));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsDegreeName", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
                                            DataRowVersion.Proposed, item.DegreeName.Trim()));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.CourseYearDetailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.BranchDetID));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
                                            DataRowVersion.Proposed, item.CentreCode.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCourseStartDetID", SqlDbType.Int,10,
                    //                        ParameterDirection.Input,false,0,0,"",
                    //                        DataRowVersion.Proposed, item.CourseStartDetID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bActualExamPattern", SqlDbType.Bit,0,
                    //                        ParameterDirection.Input,false,0,0,"",
                    //                        DataRowVersion.Proposed, item.ActualExamPattern));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsOrgShiftCode", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
                                            DataRowVersion.Proposed, item.OrgShiftCode.Trim()));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
											ParameterDirection.Input, true, 10, 0,"",
											DataRowVersion.Proposed, item.CreatedBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
											ParameterDirection.Output, true, 10, 0,"",
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
						throw new Exception("Stored Procedure 'dbo.USP_OrgSectionDetails_INSERT' reported the ErrorCode: " + 
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
                    //        ErrorMessage ="Create failed"
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
		/// Update a specific record of OrganisationSectionDetails
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSectionDetails> UpdateOrganisationSectionDetails(OrganisationSectionDetails item)
		{
			IBaseEntityResponse<OrganisationSectionDetails> response = new BaseEntityResponse<OrganisationSectionDetails>();
			SqlCommand cmdToExecute = new SqlCommand();
			try
			{
				if (string.IsNullOrEmpty(item.ConnectionString))
				{
					response.Message.Add(new MessageDTO()
					{
						ErrorMessage ="Connection string is empty.",
						MessageType = MessageTypeEnum.Error
					});
				}
				else
				{
					_mainConnection.ConnectionString = item.ConnectionString;
					cmdToExecute.Connection = _mainConnection;
					cmdToExecute.CommandText ="dbo.USP_OrgSectionDetails_Update";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStreamID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.StreamID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iBranchID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.BranchID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStandardID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.StandardID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iMediumID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.MediumID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siDuration", SqlDbType.Int,5,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.Duration));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sDescriptions", SqlDbType.VarChar,0,
                    //                    ParameterDirection.Input,false,10,0,"",
                    //                    DataRowVersion.Proposed, item.Descriptions));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSectionID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.SectionID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bSectionActive", SqlDbType.Bit,0,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.SectionActive));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSectionCapacity", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.SectionCapacity));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bExamApplicable", SqlDbType.Bit,0,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.ExamApplicable));
					cmdToExecute.Parameters.Add(new SqlParameter("@sNextSectionDetailID", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.NextSectionDetailID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bExamPattern", SqlDbType.Bit,0,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.ExamPattern));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iNumberOfSemester", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.NumberOfSemester));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sSectionDetailCode", SqlDbType.VarChar,0,
                    //                    ParameterDirection.Input,false,10,0,"",
                    //                    DataRowVersion.Proposed, item.SectionDetailCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sDegreeName", SqlDbType.VarChar,0,
                    //                    ParameterDirection.Input,false,10,0,"",
                    //                    DataRowVersion.Proposed, item.DegreeName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.CourseYearDetailID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.BranchDetID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,0,
                    //                    ParameterDirection.Input,false,10,0,"",
                    //                    DataRowVersion.Proposed, item.CentreCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCourseStartDetID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.CourseStartDetID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bActualExamPattern", SqlDbType.Bit,0,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.ActualExamPattern));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sOrgShiftCode", SqlDbType.VarChar,0,
                    //                    ParameterDirection.Input,false,10,0,"",
                    //                    DataRowVersion.Proposed, item.OrgShiftCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsFinalCourseYear", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.IsFinalCourseYear));

						cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
											ParameterDirection.Input, true, 10, 0,"",
											DataRowVersion.Proposed, item.ModifiedBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
											ParameterDirection.Output, true, 10, 0,"",
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
					{
						// Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSectionDetails_Update' reported the ErrorCode: " + 
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
                    //        ErrorMessage ="Create failed"
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
		/// Delete a specific record of OrganisationSectionDetails
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSectionDetails> DeleteOrganisationSectionDetails(OrganisationSectionDetails item)
		{
			IBaseEntityResponse<OrganisationSectionDetails> response = new BaseEntityResponse<OrganisationSectionDetails>();
			SqlCommand cmdToExecute = new SqlCommand();
			try
			{
				if (string.IsNullOrEmpty(item.ConnectionString))
				{
					response.Message.Add(new MessageDTO()
					{
						ErrorMessage ="Connection string is empty.",
						MessageType = MessageTypeEnum.Error
					});
				}
				else
				{
					_mainConnection.ConnectionString = item.ConnectionString;
					cmdToExecute.Connection = _mainConnection;
					cmdToExecute.CommandText ="dbo.USP_OrgSectionDetails_Delete";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
											ParameterDirection.Input, true, 10, 0,"",
											DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
											ParameterDirection.Input, false, 0, 0,"",
											DataRowVersion.Proposed, 0));
					cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
											ParameterDirection.Input, false, 0, 0,"",
											DataRowVersion.Proposed, 1));
					cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
											ParameterDirection.Input, true, 10, 0,"",
											DataRowVersion.Proposed, item.DeletedBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
											ParameterDirection.Output, true, 10, 0,"",
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
						throw new Exception("Stored Procedure 'dbo.USP_OrgSectionDetails_Delete' reported the ErrorCode: " + 
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
                    //        ErrorMessage ="Create failed"
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

        public IBaseEntityResponse<OrganisationSectionDetails> GetSearchOrganisationSectionDetailsByID(OrganisationSectionDetails item)
        {
            IBaseEntityResponse<OrganisationSectionDetails> response = new BaseEntityResponse<OrganisationSectionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgBranchDetails_SelectOneByID";
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
                    //DataTable dt= new DataTable();
                    //dt.Load(sqlDataReader);

                    while (sqlDataReader.Read())
                    {
                        OrganisationSectionDetails _item = new OrganisationSectionDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.BranchDetID = Convert.ToInt32(sqlDataReader["BranchDetID"]);                    
                        _item.StandardNumber = Convert.ToInt32(sqlDataReader["StandardNumber"]);
                       
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
        /// Select all record from OrganisationSectionDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetOrganisationSectionDetailsBySearchForSectionDetailsAdd(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgCourseSectionDetailsList_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSectionDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSectionDetails item = new OrganisationSectionDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        item.SectionActive = Convert.ToBoolean(sqlDataReader["SectionActive"]);
                        if (sqlDataReader["Descriptions"].ToString() != null)
                        {
                            item.Descriptions = sqlDataReader["Descriptions"].ToString();
                        }
                        else
                            item.Descriptions= "";
                        item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);
                        item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        item.BranchDescriptions = sqlDataReader["BranchDescription"].ToString();
                        item.StandardID = Convert.ToInt32(sqlDataReader["StandardID"]);
                        item.CourseYearDetailID = Convert.ToInt32(sqlDataReader["CourseYearDetailID"]);
                       // item.StandardNumber = Convert.ToInt32(sqlDataReader["StandardNumber"]);
                        //item.MediumID = Convert.ToInt32(sqlDataReader["MediumID"]);
                        //item.Duration = Convert.ToInt32(sqlDataReader["Duration"]);
                        item.CourseYearDescriptions = sqlDataReader["Description"].ToString();
                       // item.SectionID = Convert.ToInt32(sqlDataReader["SectionID"]);
                        //item.SectionActive = Convert.ToBoolean(sqlDataReader["SectionActive"]);
                        //item.SectionCapacity = Convert.ToInt32(sqlDataReader["SectionCapacity"]);
                        //item.ExamApplicable = sqlDataReader["ExamApplicable"].ToString();
                        //item.NextSectionDetailID = sqlDataReader["NextSectionDetailID"].ToString();
                      //  item.ExamPattern = sqlDataReader["ExamPattern"].ToString();
                      // item.NumberOfSemester = Convert.ToInt32(sqlDataReader["NumberOfSemester"]);
                      //  item.SectionDetailCode = sqlDataReader["SectionDetailCode"].ToString();
                      //  item.DegreeName = sqlDataReader["DegreeName"].ToString();
                       
                        //item.BranchDetID = Convert.ToInt32(sqlDataReader["BranchDetID"]);
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                      
                        //item.CourseStartDetID = Convert.ToInt32(sqlDataReader["CourseStartDetID"]);
                        //item.ActualExamPattern = Convert.ToBoolean(sqlDataReader["ActualExamPattern"]);
                        //item.OrgShiftCode = sqlDataReader["OrgShiftCode"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_OrgCourseSectionDetailsList_SelectAll' reported the ErrorCode: " + _errorCode);
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
      
        public IBaseEntityResponse<OrganisationSectionDetails> GetSearchOrganisationSectionDetailsByID_OR_CourseYearID(OrganisationSectionDetails item)
        {
            IBaseEntityResponse<OrganisationSectionDetails> response = new BaseEntityResponse<OrganisationSectionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSectionDetailsByCourseYear_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CourseYearDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
					
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
                    //DataTable dt= new DataTable();
                    //dt.Load(sqlDataReader);
                    if (item.ID == 0)
                    {
                        while (sqlDataReader.Read())
                        {
                            OrganisationSectionDetails _item = new OrganisationSectionDetails();
                            //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                            //{
                            //    _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                            //}
                            _item.CourseYearDetailID = Convert.ToInt32(sqlDataReader["CourseYearDetailID"]);
                            _item.CourseYearDescriptions = sqlDataReader["CourseYearDescription"].ToString();

                            _item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);
                            _item.StreamDescriptions = sqlDataReader["StreamDescription"].ToString();

                            _item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                            _item.BranchDescriptions = sqlDataReader["BranchDescription"].ToString();

                            _item.StandardID = Convert.ToInt32(sqlDataReader["StandardID"]);
                            _item.StandardDescriptions = sqlDataReader["StandardDescription"].ToString();

                            _item.MediumID = Convert.ToInt32(sqlDataReader["MediumID"]);
                            _item.MediumDescription = sqlDataReader["MediumDescription"].ToString();

                            _item.Duration = Convert.ToInt32(sqlDataReader["Duration"]);

                         
                            if (sqlDataReader["ExamApplicable"].ToString() == "B")
                            {
                                _item.ExamApplicable = "Internal & External";
                            }
                            else if (sqlDataReader["ExamApplicable"].ToString() == "I")
                            {
                                _item.ExamApplicable = "Internal";
                            }
                            else if (sqlDataReader["ExamApplicable"].ToString() == "E")
                            {
                                _item.ExamApplicable = "External";
                            }
                            else if (sqlDataReader["ExamApplicable"].ToString() == "N")
                            {
                                _item.ExamApplicable = "None";
                            }

                            if (sqlDataReader["ExamPattern"].ToString() == "S")
                            {
                                _item.ExamPattern = "Semester";
                            }
                            else if (sqlDataReader["ExamPattern"].ToString() == "Y")
                            {
                                _item.ExamPattern = "Yearly";
                            }
                            _item.DegreeName = sqlDataReader["DegreeName"].ToString();

                            _item.CentreCode = sqlDataReader["CentreCode"].ToString();

                            _item.BranchDetID = Convert.ToInt32(sqlDataReader["BranchDetID"]);
                            _item.NumberOfSemester = Convert.ToInt32(sqlDataReader["NumberOfSemester"]);


                            //_item.SectionActive = Convert.ToBoolean(sqlDataReader["SectionActive"]);
                            //_item.SectionCapacity = Convert.ToInt32(sqlDataReader["SectionCapacity"]);
                            //_item.SectionDetailCode = sqlDataReader["SectionDetailCode"].ToString();
                            //_item.OrgShiftCode = sqlDataReader["OrgShiftCode"].ToString();
                            //_item.Descriptions = sqlDataReader["Descriptions"].ToString();
                            response.Entity = _item;
                        }

                    }
                    else if (item.ID > 0)
                    {

                        while (sqlDataReader.Read())
                        {
                            OrganisationSectionDetails _item = new OrganisationSectionDetails();
                            if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                            {
                                _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                            }
                            _item.CourseYearDetailID = Convert.ToInt32(sqlDataReader["CourseYearDetailID"]);
                            _item.CourseYearDescriptions = sqlDataReader["CourseYearDescription"].ToString();

                            _item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);
                            _item.StreamDescriptions = sqlDataReader["StreamDescription"].ToString();

                            _item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                            _item.BranchDescriptions = sqlDataReader["BranchDescription"].ToString();

                            _item.StandardID = Convert.ToInt32(sqlDataReader["StandardID"]);
                            _item.StandardDescriptions = sqlDataReader["StandardDescription"].ToString();

                            _item.MediumID = Convert.ToInt32(sqlDataReader["MediumID"]);
                            _item.MediumDescription = sqlDataReader["MediumDescription"].ToString();

                            _item.Duration = Convert.ToInt32(sqlDataReader["Duration"]);

                            if (DBNull.Value.Equals(sqlDataReader["SectionID"]) == false)
                            {
                                _item.SectionID = Convert.ToInt32(sqlDataReader["SectionID"]);
                            }
                            if (sqlDataReader["ExamApplicable"].ToString() == "B")
                            {
                                _item.ExamApplicable = "Internal & External";
                            }
                            else if (sqlDataReader["ExamApplicable"].ToString() == "I")
                            {
                                _item.ExamApplicable = "Internal";
                            }
                            else if (sqlDataReader["ExamApplicable"].ToString() == "E")
                            {
                                _item.ExamApplicable = "External";
                            }
                            else if (sqlDataReader["ExamApplicable"].ToString() == "N")
                            {
                                _item.ExamApplicable = "None";
                            }

                            if (sqlDataReader["ExamPattern"].ToString() == "S")
                            {
                                _item.ExamPattern = "Semester";
                            }
                            else if (sqlDataReader["ExamPattern"].ToString() == "Y")
                            {
                                _item.ExamPattern = "Yearly";
                            }
                            _item.DegreeName = sqlDataReader["DegreeName"].ToString();

                            _item.CentreCode = sqlDataReader["CentreCode"].ToString();

                            _item.BranchDetID = Convert.ToInt32(sqlDataReader["BranchDetID"]);
                            _item.NumberOfSemester = Convert.ToInt32(sqlDataReader["NumberOfSemester"]);


                            _item.SectionActive = Convert.ToBoolean(sqlDataReader["SectionActive"]);
                            _item.SectionCapacity = Convert.ToInt32(sqlDataReader["SectionCapacity"]);
                            _item.SectionDetailCode = sqlDataReader["SectionDetailCode"].ToString();
                            _item.OrgShiftCode = sqlDataReader["OrgShiftCode"].ToString();
                            _item.Descriptions = sqlDataReader["Descriptions"].ToString();
                            response.Entity = _item;
                        }

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgSectionDetailsByCourseYear_SelectOne' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of OrganisationSectionDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSectionDetails> UpdateOrganisationSectionDetailsAdd(OrganisationSectionDetails item)
        {
            IBaseEntityResponse<OrganisationSectionDetails> response = new BaseEntityResponse<OrganisationSectionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSectionDetailsAdd_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStreamID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.StreamID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iBranchID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.BranchID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStandardID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.StandardID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iMediumID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.MediumID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siDuration", SqlDbType.Int,5,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.Duration));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDescriptions", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.Descriptions.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.SectionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bSectionActive", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.SectionActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionCapacity", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.SectionCapacity));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bExamApplicable", SqlDbType.Bit,0,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.ExamApplicable));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sNextSectionDetailID", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.NextSectionDetailID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bExamPattern", SqlDbType.Bit,0,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.ExamPattern));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iNumberOfSemester", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.NumberOfSemester));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSectionDetailCode", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.SectionDetailCode.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sDegreeName", SqlDbType.VarChar,0,
                    //                    ParameterDirection.Input,false,10,0,"",
                    //                    DataRowVersion.Proposed, item.DegreeName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.CourseYearDetailID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.BranchDetID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,0,
                    //                    ParameterDirection.Input,false,10,0,"",
                    //                    DataRowVersion.Proposed, item.CentreCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCourseStartDetID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.CourseStartDetID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bActualExamPattern", SqlDbType.Bit,0,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.ActualExamPattern));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOrgShiftCode", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.OrgShiftCode.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsFinalCourseYear", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.IsFinalCourseYear));

                   
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
                  _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                  item.ErrorCode = (Int32)_errorCode;
                  response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSectionDetailsAdd_Update' reported the ErrorCode: " +
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
        /// Select all record from OrganisationSectionDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsRoleWise(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
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
                    if (searchRequest.StandardNumber <= 0)
                    {
                        _mainConnection.ConnectionString = searchRequest.ConnectionString;
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.CommandText = "dbo.USP_OrgSectionDetailsByBranch";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iBranchId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BranchID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    }
                    else if (searchRequest.StandardNumber > 0)
                    {
                       _mainConnection.ConnectionString = searchRequest.ConnectionString;
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.CommandText = "dbo.USP_OrgCourseYearDetailsByUniversityBranch";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iStandardNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StandardNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsCommonBranchApplicable", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSectionDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSectionDetails item = new OrganisationSectionDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.SectionID = Convert.ToInt32(sqlDataReader["SectionID"]);
                        item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        item.Descriptions = sqlDataReader["Descriptions"].ToString();
                        item.StandardID = Convert.ToInt32(sqlDataReader["StandardID"]);


                        baseEntityCollection.CollectionResponse.Add(item);
                       
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgSectionDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationSectionDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsForPromotion(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSectionDetails_ListForBranchPromotion";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSectionDetails>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSectionDetails item = new OrganisationSectionDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.StreamID = Convert.ToInt32(sqlDataReader["StreamID"]);
                        item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);


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
                        throw new Exception("Stored Procedure 'USP_OrgSectionDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
