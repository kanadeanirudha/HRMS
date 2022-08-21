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
	public class OrganisationSubjectGrpRuleDataProvider : DBInteractionBase,IOrganisationSubjectGrpRuleDataProvider
	{
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public OrganisationSubjectGrpRuleDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public OrganisationSubjectGrpRuleDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion

		#region Method Implementation

		/// <summary>
		/// Select all record from OrganisationSubjectGrpRule table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrganisationSubjectGrpRuleBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubjectGrpRule_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSubjectGrpRule>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSubjectGrpRule item = new OrganisationSubjectGrpRule();

                        item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        if (item.StatusFlag == false)
                        {
                            item.RuleName = "";
                            item.ID = 0;
                        }
                        else
                        {
                            item.RuleName =  "      ("+ Convert.ToString(sqlDataReader["RuleName"])+ ")" ;
                            item.ID = Convert.ToInt32(sqlDataReader["OrgSubjectGrpRuleID"]);
                        }
                        
                        item.CourseYearCode = Convert.ToString(sqlDataReader["CourseYearCode"]);
                        item.OrgSemesterName = Convert.ToString(sqlDataReader["OrgSemesterName"]);

                        if (DBNull.Value.Equals(sqlDataReader["RuleCode"]) == false)
                        {
                            item.RuleCode = Convert.ToString(sqlDataReader["RuleCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BranchDescription"]) == false)
                        {
                            item.BranchDescription = Convert.ToString(sqlDataReader["BranchDescription"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["TotalSubjects"]) == false)
                        {
                            item.TotalSubjects = Convert.ToUInt16(sqlDataReader["TotalSubjects"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MaxCompulsorySubjects"]) == false)
                        {
                            item.MaxCompulsorySubjects = Convert.ToUInt16(sqlDataReader["MaxCompulsorySubjects"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MaxOptSubjects"]) == false)
                        {
                            item.MaxOptSubjects = Convert.ToUInt16(sqlDataReader["MaxOptSubjects"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["NoOfOptSubjects"]) == false)
                        {
                            item.NoOfOptSubjects = Convert.ToUInt16(sqlDataReader["NoOfOptSubjects"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CourseYearSemesterID"]) == false)
                        {
                            item.CourseYearSemesterID = Convert.ToUInt16(sqlDataReader["CourseYearSemesterID"]);
                        }

                        //item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);

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
                        throw new Exception("Stored Procedure 'USP_OrgSubjectGrpRule_SelectAll' reported the ErrorCode: " + _errorCode);
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
		/// Select all record from OrganisationSubjectGrpRule table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetForOrgSubGrpRuleSessionwise(OrganisationSubjectGrpRuleSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubGrpRuleSessionwise_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEntityLevel", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ScopeIdentity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionID));
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
					baseEntityCollection.CollectionResponse = new List<OrganisationSubjectGrpRule>();
					while (sqlDataReader.Read())
					{
						OrganisationSubjectGrpRule item = new OrganisationSubjectGrpRule();
                        item.ID = Convert.ToInt32(sqlDataReader["OrgSubjectGrpRuleID"]);                        
						item.RuleName = sqlDataReader["RuleName"].ToString();
						item.RuleCode = sqlDataReader["RuleCode"].ToString();
                        item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        item.BranchShortCode = sqlDataReader["BranchShortCode"].ToString();
						item.TotalSubjects = Convert.ToInt32(sqlDataReader["TotalSubjects"]);
						item.MaxCompulsorySubjects = Convert.ToInt32(sqlDataReader["MaxCompulsorySubjects"]);
						item.MaxOptSubjects = Convert.ToInt32(sqlDataReader["MaxOptSubjects"]);
						item.NoOfOptSubjects = Convert.ToInt32(sqlDataReader["NoOfOptSubjects"]);
						item.CourseYearSemesterID = Convert.ToInt32(sqlDataReader["CourseYearSemesterID"]);
                        //item.OrgSessionCryrAllotID = Convert.ToInt32(sqlDataReader["OrgSessionCryrAllocationID"]);
                        item.SessionID = Convert.ToInt32(sqlDataReader["CourseYearSemesterID"]);
                        item.SemesterName = sqlDataReader["OrgSemesterName"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["OrgSubGrpRuleSessionwiseID"]) == false)
                        {
                            item.OrgSubGrpRuleSessionwiseID = Convert.ToInt32(sqlDataReader["OrgSubGrpRuleSessionwiseID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StatusFlag"]) == false)
                        {
                            item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrgSessionCryAllocationID"]) == false)
                        {
                            item.OrgSessionCryAllocationID = Convert.ToInt32(sqlDataReader["OrgSessionCryAllocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SessionCryAllocationStatus"]) == false)
                        {
                            item.SessionCryAllocationStatus = Convert.ToBoolean(sqlDataReader["SessionCryAllocationStatus"]);
                        }
						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgSubGrpRuleSessionwise_SelectAll' reported the ErrorCode: " + _errorCode);
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
		public IBaseEntityResponse<OrganisationSubjectGrpRule> GetOrganisationSubjectGrpRuleByID(OrganisationSubjectGrpRule item)
		{
			IBaseEntityResponse<OrganisationSubjectGrpRule> response = new BaseEntityResponse<OrganisationSubjectGrpRule>();
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
					cmdToExecute.CommandText = "dbo.USP_OrgSubjectGrpRule_SelectOne";
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
						OrganisationSubjectGrpRule _item = new OrganisationSubjectGrpRule();
						_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						_item.RuleName = sqlDataReader["RuleName"].ToString();
						_item.RuleCode = sqlDataReader["RuleCode"].ToString();
						_item.TotalSubjects = Convert.ToInt32(sqlDataReader["TotalSubjects"]);
						_item.MaxCompulsorySubjects = Convert.ToInt32(sqlDataReader["MaxCompulsorySubjects"]);
						_item.MaxOptSubjects = Convert.ToInt32(sqlDataReader["MaxOptSubjects"]);
						_item.NoOfOptSubjects = Convert.ToInt32(sqlDataReader["NoOfOptSubjects"]);
						_item.MaxGroups = Convert.ToInt32(sqlDataReader["MaxGroups"]);
						_item.MaxNoOfCompulsoryGroups = Convert.ToInt32(sqlDataReader["MaxNoOfCompulsoryGroups"]);
						_item.CourseYearSemesterID = Convert.ToInt32(sqlDataReader["CourseYearSemesterID"]);
						_item.OrgSessionCryrAllotID = Convert.ToInt32(sqlDataReader["OrgSessionCryrAllotID"]);
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
		public IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item)
		{
			IBaseEntityResponse<OrganisationSubjectGrpRule> response = new BaseEntityResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubjectGrpRule_Insert";
					cmdToExecute.CommandType = CommandType.StoredProcedure;

					cmdToExecute.Parameters.Add(new SqlParameter("@sRuleName", SqlDbType.NVarChar,100,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.RuleName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sRuleCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RuleCode.Trim()));
					cmdToExecute.Parameters.Add(new SqlParameter("@iTotalSubjects", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.TotalSubjects));
					cmdToExecute.Parameters.Add(new SqlParameter("@iMaxCompulsorySubjects", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.MaxCompulsorySubjects));
					cmdToExecute.Parameters.Add(new SqlParameter("@iMaxOptSubjects", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.MaxOptSubjects));
					cmdToExecute.Parameters.Add(new SqlParameter("@iNoOfOptSubjects", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.NoOfOptSubjects));
					cmdToExecute.Parameters.Add(new SqlParameter("@iMaxGroups", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.MaxGroups));
					cmdToExecute.Parameters.Add(new SqlParameter("@iMaxNoOfCompulsoryGroups", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.MaxNoOfCompulsoryGroups));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearSemesterID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.CourseYearSemesterID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iOrgSessionCryrAllotID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.OrgSessionCryrAllotID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit,0,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.IsActive));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0,"",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Output, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0,"",DataRowVersion.Proposed, _errorCode));

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
					if (_errorCode != (int)ErrorEnum.AllOk&& _errorCode != (int)ErrorEnum.DuplicateEntry)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_OrgSubjectGrpRule_INSERT' reported the ErrorCode: " + _errorCode);
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
		/// Update a specific record of OrganisationSubjectGrpRule
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item)
		{
			IBaseEntityResponse<OrganisationSubjectGrpRule> response = new BaseEntityResponse<OrganisationSubjectGrpRule>();
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
					cmdToExecute.CommandText ="dbo.USP_OrgSubjectGrpRule_Update";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sRuleName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RuleName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sRuleCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RuleCode.Trim()));
					cmdToExecute.Parameters.Add(new SqlParameter("@iTotalSubjects", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.TotalSubjects));
					cmdToExecute.Parameters.Add(new SqlParameter("@iMaxCompulsorySubjects", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.MaxCompulsorySubjects));
					cmdToExecute.Parameters.Add(new SqlParameter("@iMaxOptSubjects", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.MaxOptSubjects));
					cmdToExecute.Parameters.Add(new SqlParameter("@iNoOfOptSubjects", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.NoOfOptSubjects));
					cmdToExecute.Parameters.Add(new SqlParameter("@iMaxGroups", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.MaxGroups));
					cmdToExecute.Parameters.Add(new SqlParameter("@iMaxNoOfCompulsoryGroups", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.MaxNoOfCompulsoryGroups));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearSemesterID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.CourseYearSemesterID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iOrgSessionCryrAllotID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.OrgSessionCryrAllotID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit,0,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0,"",DataRowVersion.Proposed, item.ModifiedBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0,"",DataRowVersion.Proposed, _errorCode));

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
					if (_errorCode != (int)ErrorEnum.AllOk &&_errorCode != (int)ErrorEnum.DuplicateEntry)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_OrgSubjectGrpRule_Delete' reported the ErrorCode: " + _errorCode);
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
		/// Delete a specific record of OrganisationSubjectGrpRule
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSubjectGrpRule> DeleteOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item)
		{
			IBaseEntityResponse<OrganisationSubjectGrpRule> response = new BaseEntityResponse<OrganisationSubjectGrpRule>();
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
					cmdToExecute.CommandText ="dbo.USP_OrgSubjectGrpRule_Delete";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0,"",DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0,"",DataRowVersion.Proposed, 1));//1 FOR HARD DELETE
					cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0,"",DataRowVersion.Proposed, 1));
					cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0,"",DataRowVersion.Proposed, item.DeletedBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0,"",DataRowVersion.Proposed, _errorCode));

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
						throw new Exception("Stored Procedure 'dbo.USP_OrgSubjectGrpRule_Delete' reported the ErrorCode: " + 
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
							ErrorMessage ="Create failed"
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

        // Methods for table OrgElectiveGrpMaster

        /// <summary>
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrgElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> response = new BaseEntityResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgElectiveGrpMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Output, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sGroupShortCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GroupShortCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sGroupName", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GroupName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectRuleGrpNumber", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SubjectRuleGrpNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sGroupCompulsoryFlag", SqlDbType.Bit, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.GroupCompulsoryFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNoOfSubGroups", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.NoOfSubGroups));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNoOfCompulsorySubGrp", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.NoOfCompulsorySubGrp));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNoOfSubGrpSubjectSelect", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.NoOfSubGrpSubjectSelect));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveCommonGroup", SqlDbType.VarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ElectiveCommonGroup));
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
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSubjectGrpRule_INSERT' reported the ErrorCode: " +_errorCode);
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
        /// Update a specific record of OrganisationSubjectGrpRule
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrgElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> response = new BaseEntityResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgElectiveGrpMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.OrgElectiveGrpMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sGroupShortCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GroupShortCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sGroupName", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GroupName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectRuleGrpNumber", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SubjectRuleGrpNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sGroupCompulsoryFlag", SqlDbType.Bit, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.GroupCompulsoryFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNoOfSubGroups", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.NoOfSubGroups));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNoOfCompulsorySubGrp", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.NoOfCompulsorySubGrp));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNoOfSubGrpSubjectSelect", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.NoOfSubGrpSubjectSelect));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveCommonGroup", SqlDbType.VarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ElectiveCommonGroup));

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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSubjectGrpRule_Delete' reported the ErrorCode: " +_errorCode);
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
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> SelectOrgElectiveGrpMasterByID(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> response = new BaseEntityResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgElectiveGrpMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OrgElectiveGrpMasterID));
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
                        OrganisationSubjectGrpRule _item = new OrganisationSubjectGrpRule();
                        _item.OrgElectiveGrpMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.GroupShortCode = sqlDataReader["GroupShortCode"].ToString();
                        //_item.GroupName = sqlDataReader["GroupName"].ToString();
                        //_item.SubjectRuleGrpNumber = Convert.ToInt32(sqlDataReader["SubjectRuleGrpNumber"]);
                        //_item.GroupCompulsoryFlag = Convert.ToBoolean(sqlDataReader["GroupCompulsoryFlag"].ToString());
                        _item.NoOfSubGroups = Convert.ToInt32(sqlDataReader["NoOfSubGroups"]);
                        //_item.NoOfCompulsorySubGrp = Convert.ToInt32(sqlDataReader["NoOfCompulsorySubGrp"]);
                        //_item.NoOfSubGrpSubjectSelect = Convert.ToInt32(sqlDataReader["NoOfSubGrpSubjectSelect"]);
                        //_item.ElectiveCommonGroup = sqlDataReader["ElectiveCommonGroup"].ToString();

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
        /// Select all record from OrganisationSubjectGrpRule table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgElectiveGrpMasterBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgElectiveGrpMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSubjectGrpRule>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSubjectGrpRule item = new OrganisationSubjectGrpRule();
                        item.OrgElectiveGrpMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.GroupShortCode = sqlDataReader["GroupShortCode"].ToString();
                        item.GroupName = sqlDataReader["GroupName"].ToString();
                        item.SubjectRuleGrpNumber = Convert.ToInt32(sqlDataReader["SubjectRuleGrpNumber"]);
                        if (DBNull.Value.Equals(sqlDataReader["GroupCompulsoryFlag"]) == false)
                        {
                            if (sqlDataReader["GroupCompulsoryFlag"].ToString() == "1")
                            {
                                item.GroupCompulsoryFlag = true;          
                            }
                            else if (sqlDataReader["GroupCompulsoryFlag"].ToString() == "0")
                            {
                                item.GroupCompulsoryFlag = false;          
                            }
                          
                        }
                        
                        item.NoOfSubGroups = Convert.ToInt32(sqlDataReader["NoOfSubGroups"]);
                        item.NoOfCompulsorySubGrp = Convert.ToInt32(sqlDataReader["NoOfCompulsorySubGrp"]);
                        item.NoOfSubGrpSubjectSelect = Convert.ToInt32(sqlDataReader["NoOfSubGrpSubjectSelect"]);
                        //item.ElectiveCommonGroup = sqlDataReader["ElectiveCommonGroup"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                        
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrganisationElectiveGrpMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        // Methods for table OrgSubElectiveGrpMaster

        /// <summary>
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrgSubElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> response = new BaseEntityResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubElectiveGrpMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OrgSubElectiveGrpDescription.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sShortDescription", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ShortDescription.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOrgElectiveGrpID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.OrgElectiveGrpID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalNoOfSubjects", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.TotalNoOfSubjects));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAllowToSelect", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.AllowToSelect));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bSubGroupCompulsoryFlag", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SubGroupCompulsoryFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Output, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));


                    //cmdToExecute.Parameters.Add(new SqlParameter("@bSubGroupCompulsoryFlag", SqlDbType.Bit, 0,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.SubGroupCompulsoryFlag));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iTotalNoOfSubjectCompulsory", SqlDbType.Int, 10,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.TotalNoOfSubjectCompulsory));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveCommonSubGroup", SqlDbType.VarChar, 0,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.ElectiveCommonSubGroup));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bFeeBased", SqlDbType.Bit, 0,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.FeeBased));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iNextSubElectiveGrpID", SqlDbType.Int, 10,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.NextSubElectiveGrpID));


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
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSubElectiveGrpMaster_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of OrganisationSubjectGrpRule
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrgSubElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> response = new BaseEntityResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubElectiveGrpMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.OrgSubElectiveGrpMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOrgElectiveGrpID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.OrgElectiveGrpID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.NVarChar, 240,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.OrgSubElectiveGrpDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sShortDescription", SqlDbType.NVarChar, 30,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ShortDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalNoOfSubjects", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.TotalNoOfSubjects));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bSubGrpCompulsorySubjFlag", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SubGrpCompulsorySubjFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAllowToSelect", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.AllowToSelect));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bSubGroupCompulsoryFlag", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SubGroupCompulsoryFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalNoOfSubjectCompulsory", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.TotalNoOfSubjectCompulsory));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveCommonSubGroup", SqlDbType.VarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ElectiveCommonSubGroup));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bFeeBased", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.FeeBased));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iNextSubElectiveGrpID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.NextSubElectiveGrpID));

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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgSubElectiveGrpMaster_Delete' reported the ErrorCode: " +_errorCode);
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
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> SelectOrgSubElectiveGrpMasterByID(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> response = new BaseEntityResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubElectiveGrpMaster_SelectOne";
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
                        OrganisationSubjectGrpRule _item = new OrganisationSubjectGrpRule();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.OrgElectiveGrpID = Convert.ToInt32(sqlDataReader["OrgElectiveGrpID"]);
                        _item.OrgSubElectiveGrpDescription = sqlDataReader["Description"].ToString();
                        _item.ShortDescription = sqlDataReader["ShortDescription"].ToString();
                        _item.TotalNoOfSubjects = Convert.ToInt32(sqlDataReader["TotalNoOfSubjects"]);
                        _item.SubGrpCompulsorySubjFlag = Convert.ToBoolean(sqlDataReader["SubGrpCompulsorySubjFlag"]);
                        _item.AllowToSelect = Convert.ToInt32(sqlDataReader["AllowToSelect"]);
                        _item.SubGroupCompulsoryFlag = Convert.ToBoolean(sqlDataReader["SubGroupCompulsoryFlag"]);
                        _item.TotalNoOfSubjectCompulsory = Convert.ToInt32(sqlDataReader["TotalNoOfSubjectCompulsory"]);
                        _item.ElectiveCommonSubGroup = sqlDataReader["ElectiveCommonSubGroup"].ToString();
                        _item.FeeBased = Convert.ToBoolean(sqlDataReader["FeeBased"]);
                        _item.NextSubElectiveGrpID = Convert.ToInt32(sqlDataReader["NextSubElectiveGrpID"]);

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
        /// Select all record from OrganisationSubjectGrpRule table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgSubElectiveGrpMasterBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSubElectiveGrpMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGroupRuleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GroupRuleID));
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSubjectGrpRule>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSubjectGrpRule item = new OrganisationSubjectGrpRule();
                        item.OrgSubElectiveGrpMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.OrgElectiveGrpID = Convert.ToInt32(sqlDataReader["OrgElectiveGrpID"]);
                        item.OrgSubElectiveGrpDescription = sqlDataReader["Description"].ToString();
                        item.ShortDescription = sqlDataReader["ShortDescription"].ToString();
                        item.TotalNoOfSubjects = Convert.ToInt32(sqlDataReader["TotalNoOfSubjects"]);
                        //item.SubGrpCompulsorySubjFlag = Convert.ToBoolean(sqlDataReader["SubGrpCompulsorySubjFlag"]);
                        item.AllowToSelect = Convert.ToInt32(sqlDataReader["AllowToSelect"]);
                        item.SubGroupCompulsoryFlag = Convert.ToBoolean(sqlDataReader["SubGroupCompulsoryFlag"]);
                        //item.TotalNoOfSubjectCompulsory = Convert.ToInt32(sqlDataReader["TotalNoOfSubjectCompulsory"]);
                        //item.ElectiveCommonSubGroup = sqlDataReader["ElectiveCommonSubGroup"].ToString();
                        //item.FeeBased = Convert.ToBoolean(sqlDataReader["FeeBased"]);
                        //item.NextSubElectiveGrpID = Convert.ToInt32(sqlDataReader["NextSubElectiveGrpID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                      
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgSubElectiveGrpMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationSubjectGrpRule table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgSubjectGroupRuleSearchList(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSubjectGrpRule>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgElectiveGrpMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectRuleGrpNumber", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SubjectRuleGrpNumber));

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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSubjectGrpRule>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSubjectGrpRule item = new OrganisationSubjectGrpRule();
                        item.OrgElectiveGrpMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.GroupName = sqlDataReader["GroupName"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgSubElectiveGrpMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
