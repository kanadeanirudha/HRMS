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
	public class OrganisationSubElectiveGrpMasterDataProvider : DBInteractionBase,IOrganisationSubElectiveGrpMasterDataProvider
	{
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public OrganisationSubElectiveGrpMasterDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public OrganisationSubElectiveGrpMasterDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
		#region Method Implementation
		/// <summary>
		/// Select all record from OrganisationSubElectiveGrpMaster table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<OrganisationSubElectiveGrpMaster>     GetOrganisationSubElectiveGrpMasterBySearch(OrganisationSubElectiveGrpMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<OrganisationSubElectiveGrpMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSubElectiveGrpMaster>();
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
					cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
					cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
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
					baseEntityCollection.CollectionResponse = new List<OrganisationSubElectiveGrpMaster>();
					while (sqlDataReader.Read())
					{
						OrganisationSubElectiveGrpMaster item = new OrganisationSubElectiveGrpMaster();
						item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						item.OrgElectiveGrpID = Convert.ToInt32(sqlDataReader["OrgElectiveGrpID"]);
						item.Description = sqlDataReader["Description"].ToString();
						item.ShortDescription = sqlDataReader["ShortDescription"].ToString();
						item.TotalNoOfSubjects = Convert.ToInt32(sqlDataReader["TotalNoOfSubjects"]);
						item.SubGrpCompulsorySubjFlag = Convert.ToBoolean(sqlDataReader["SubGrpCompulsorySubjFlag"]);
						item.AllowToSelect = Convert.ToInt32(sqlDataReader["AllowToSelect"]);
						item.SubGroupCompulsoryFlag = Convert.ToBoolean(sqlDataReader["SubGroupCompulsoryFlag"]);
						item.TotalNoOfSubjectCompulsory = Convert.ToInt32(sqlDataReader["TotalNoOfSubjectCompulsory"]);
						item.ElectiveCommonSubGroup = sqlDataReader["ElectiveCommonSubGroup"].ToString();
						item.FeeBased = Convert.ToBoolean(sqlDataReader["FeeBased"]);
						item.NextSubElectiveGrpID = Convert.ToInt32(sqlDataReader["NextSubElectiveGrpID"]);

						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
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
		/// Select a record from table by ID
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> GetOrganisationSubElectiveGrpMasterByID(OrganisationSubElectiveGrpMaster item)
		{
			IBaseEntityResponse<OrganisationSubElectiveGrpMaster> response = new BaseEntityResponse<OrganisationSubElectiveGrpMaster>();
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
						OrganisationSubElectiveGrpMaster _item = new OrganisationSubElectiveGrpMaster();
						_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						_item.OrgElectiveGrpID = Convert.ToInt32(sqlDataReader["OrgElectiveGrpID"]);
						_item.Description = sqlDataReader["Description"].ToString();
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
		/// Create new record of the table
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> InsertOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item)
		{
			IBaseEntityResponse<OrganisationSubElectiveGrpMaster> response = new BaseEntityResponse<OrganisationSubElectiveGrpMaster>();
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
					cmdToExecute.CommandText = "dbo.USP_OrgSubElectiveGrpMaster_INSERT";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
										cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iOrgElectiveGrpID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.OrgElectiveGrpID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.Description));
					cmdToExecute.Parameters.Add(new SqlParameter("@sShortDescription", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.ShortDescription));
					cmdToExecute.Parameters.Add(new SqlParameter("@iTotalNoOfSubjects", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.TotalNoOfSubjects));
					cmdToExecute.Parameters.Add(new SqlParameter("@bSubGrpCompulsorySubjFlag", SqlDbType.Bit,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.SubGrpCompulsorySubjFlag));
					cmdToExecute.Parameters.Add(new SqlParameter("@iAllowToSelect", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.AllowToSelect));
					cmdToExecute.Parameters.Add(new SqlParameter("@bSubGroupCompulsoryFlag", SqlDbType.Bit,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.SubGroupCompulsoryFlag));
					cmdToExecute.Parameters.Add(new SqlParameter("@iTotalNoOfSubjectCompulsory", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.TotalNoOfSubjectCompulsory));
					cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveCommonSubGroup", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.ElectiveCommonSubGroup));
					cmdToExecute.Parameters.Add(new SqlParameter("@bFeeBased", SqlDbType.Bit,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.FeeBased));
					cmdToExecute.Parameters.Add(new SqlParameter("@iNextSubElectiveGrpID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.NextSubElectiveGrpID));
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
					item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
					_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_OrgSubElectiveGrpMaster_INSERT' reported the ErrorCode: " + 
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
		/// <summary>
		/// Update a specific record of OrganisationSubElectiveGrpMaster
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> UpdateOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item)
		{
			IBaseEntityResponse<OrganisationSubElectiveGrpMaster> response = new BaseEntityResponse<OrganisationSubElectiveGrpMaster>();
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
					cmdToExecute.CommandText ="dbo.USP_OrgSubElectiveGrpMaster_Update";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iOrgElectiveGrpID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.OrgElectiveGrpID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.Description));
					cmdToExecute.Parameters.Add(new SqlParameter("@sShortDescription", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.ShortDescription));
					cmdToExecute.Parameters.Add(new SqlParameter("@iTotalNoOfSubjects", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.TotalNoOfSubjects));
					cmdToExecute.Parameters.Add(new SqlParameter("@bSubGrpCompulsorySubjFlag", SqlDbType.Bit,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.SubGrpCompulsorySubjFlag));
					cmdToExecute.Parameters.Add(new SqlParameter("@iAllowToSelect", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AllowToSelect));
					cmdToExecute.Parameters.Add(new SqlParameter("@bSubGroupCompulsoryFlag", SqlDbType.Bit,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.SubGroupCompulsoryFlag));
					cmdToExecute.Parameters.Add(new SqlParameter("@iTotalNoOfSubjectCompulsory", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.TotalNoOfSubjectCompulsory));
					cmdToExecute.Parameters.Add(new SqlParameter("@sElectiveCommonSubGroup", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.ElectiveCommonSubGroup));
					cmdToExecute.Parameters.Add(new SqlParameter("@bFeeBased", SqlDbType.Bit,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.FeeBased));
					cmdToExecute.Parameters.Add(new SqlParameter("@iNextSubElectiveGrpID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.NextSubElectiveGrpID));

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
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_OrgSubElectiveGrpMaster_Delete' reported the ErrorCode: " + 
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
		/// <summary>
		/// Delete a specific record of OrganisationSubElectiveGrpMaster
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> DeleteOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item)
		{
			IBaseEntityResponse<OrganisationSubElectiveGrpMaster> response = new BaseEntityResponse<OrganisationSubElectiveGrpMaster>();
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
					cmdToExecute.CommandText ="dbo.USP_OrgSubElectiveGrpMaster_Delete";
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
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_OrgSubElectiveGrpMaster_Delete' reported the ErrorCode: " + 
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
		#endregion
	}
}
