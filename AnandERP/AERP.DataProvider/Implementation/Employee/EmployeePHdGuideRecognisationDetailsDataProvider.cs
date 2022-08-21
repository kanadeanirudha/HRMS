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
	public class EmployeePHdGuideRecognisationDetailsDataProvider : DBInteractionBase,IEmployeePHdGuideRecognisationDetailsDataProvider
	{
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public EmployeePHdGuideRecognisationDetailsDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public EmployeePHdGuideRecognisationDetailsDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
        #region Method Implementation EmployeePHdGuideRecognisationDetails
        /// <summary>
		/// Select all record from EmployeePHdGuideRecognisationDetails table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails>     GetEmployeePHdGuideRecognisationDetailsBySearch(EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails>();
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
					cmdToExecute.CommandText = "dbo.USP_EmployeePHdGuideRecognisationDetails_SelectAll";
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
					baseEntityCollection.CollectionResponse = new List<EmployeePHdGuideRecognisationDetails>();
					while (sqlDataReader.Read())
					{
						EmployeePHdGuideRecognisationDetails item = new EmployeePHdGuideRecognisationDetails();
						item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
						item.GeneralBoardUniversityID = Convert.ToInt32(sqlDataReader["GeneralBoardUniversityID"]);
						item.ApprovalSubjectName = sqlDataReader["ApprovalSubjectName"].ToString();
						
						item.UniversityApprovalNumber = sqlDataReader["UniversityApprovalNumber"].ToString();
						
						item.NoOfCandidateCompletedPHd = Convert.ToInt32(sqlDataReader["NoOfCandidateCompletedPHd"]);
						item.NumberOfCandidateRegistered = Convert.ToInt32(sqlDataReader["NumberOfCandidateRegistered"]);
						item.Remarks = sqlDataReader["Remarks"].ToString();

						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_EmployeePHdGuideRecognisationDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> GetEmployeePHdGuideRecognisationDetailsByID(EmployeePHdGuideRecognisationDetails item)
		{
			IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePHdGuideRecognisationDetails_SelectOne";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
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
						EmployeePHdGuideRecognisationDetails _item = new EmployeePHdGuideRecognisationDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralBoardUniversityID"]) == false)
                        {
                            _item.GeneralBoardUniversityID = Convert.ToInt32(sqlDataReader["GeneralBoardUniversityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovalSubjectName"]) == false)
                        {
                            _item.ApprovalSubjectName = Convert.ToString(sqlDataReader["ApprovalSubjectName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovalFromDate"]) == false)
                        {
                            _item.ApprovalFromDate = Convert.ToString(sqlDataReader["ApprovalFromDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ApprovalUptoDate"]) == false)
                        {
                            _item.ApprovalUptoDate = Convert.ToString(sqlDataReader["ApprovalUptoDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalNumber"]) == false)
                        {
                            _item.UniversityApprovalNumber = Convert.ToString(sqlDataReader["UniversityApprovalNumber"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalDate"]) == false)
                        {
                            _item.UniversityApprovalDate = Convert.ToString(sqlDataReader["UniversityApprovalDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NoOfCandidateCompletedPHd"]) == false)
                        {
                            _item.NoOfCandidateCompletedPHd = Convert.ToInt32(sqlDataReader["NoOfCandidateCompletedPHd"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfCandidateRegistered"]) == false)
                        {
                            _item.NumberOfCandidateRegistered = Convert.ToInt32(sqlDataReader["NumberOfCandidateRegistered"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Remarks"]) == false)
                        {
                            _item.Remarks = Convert.ToString(sqlDataReader["Remarks"]);
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
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> InsertEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item)
		{
			IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
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
					cmdToExecute.CommandText = "dbo.USP_EmployeePHdGuideRecognisationDetails_InsertUpdate";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralBoardUniversityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralBoardUniversityID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sApprovalSubjectName", SqlDbType.VarChar,50,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.ApprovalSubjectName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daApprovalFromDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApprovalFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daApprovalUptoDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApprovalUptoDate));
					cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalNumber", SqlDbType.VarChar,30,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.UniversityApprovalNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daUniversityApprovalDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.UniversityApprovalDate));
					cmdToExecute.Parameters.Add(new SqlParameter("@iNoOfCandidateCompletedPHd", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.NoOfCandidateCompletedPHd));
					cmdToExecute.Parameters.Add(new SqlParameter("@iNumberOfCandidateRegistered", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.NumberOfCandidateRegistered));
					cmdToExecute.Parameters.Add(new SqlParameter("@sRemarks", SqlDbType.VarChar,100,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.Remarks));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0,"",DataRowVersion.Proposed, item.CreatedBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0,"",DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNewID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, null));
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
                        item.ID = (Int32)cmdToExecute.Parameters["@iNewID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                   
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_EmployeePHdGuideRecognisationDetails_INSERT' reported the ErrorCode: " + 
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
		/// Update a specific record of EmployeePHdGuideRecognisationDetails
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> UpdateEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item)
		{
			IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
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
					cmdToExecute.CommandText ="dbo.USP_EmployeePHdGuideRecognisationDetails_Update";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.EmployeeID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralBoardUniversityID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.GeneralBoardUniversityID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sApprovalSubjectName", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.ApprovalSubjectName));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ApprovalFromDate));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ApprovalUptoDate));
					cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalNumber", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.UniversityApprovalNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.UniversityApprovalDate));
					cmdToExecute.Parameters.Add(new SqlParameter("@iNoOfCandidateCompletedPHd", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.NoOfCandidateCompletedPHd));
					cmdToExecute.Parameters.Add(new SqlParameter("@iNumberOfCandidateRegistered", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.NumberOfCandidateRegistered));
					cmdToExecute.Parameters.Add(new SqlParameter("@sRemarks", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.Remarks));

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
						throw new Exception("Stored Procedure 'dbo.USP_EmployeePHdGuideRecognisationDetails_Delete' reported the ErrorCode: " + 
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
		/// Delete a specific record of EmployeePHdGuideRecognisationDetails
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> DeleteEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item)
		{
			IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
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
					cmdToExecute.CommandText ="dbo.USP_EmployeePHdGuideRecognisationDetails_Delete";
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
											DataRowVersion.Proposed, 1));
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
						throw new Exception("Stored Procedure 'dbo.USP_EmployeePHdGuideRecognisationDetails_Delete' reported the ErrorCode: " + 
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
        #region Method Implementation EmployeePHdGuideStudentsDetails
        /// <summary> 
        /// Select all record from EmployeePHdGuideStudentsDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> GetEmployeePHdGuideStudentsDetailsBySearch(EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails>();
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
					cmdToExecute.CommandText = "dbo.USP_EmployeePHdGuideStudentsDetails_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
					cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    
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
					baseEntityCollection.CollectionResponse = new List<EmployeePHdGuideRecognisationDetails>();
					while (sqlDataReader.Read())
					{
						EmployeePHdGuideRecognisationDetails item = new EmployeePHdGuideRecognisationDetails();
                        if (DBNull.Value.Equals(sqlDataReader["EmployeePHdGuideStudentsDetailsID"]) == false)
                        {
                            item.EmployeePHdGuideStudentsDetailsID = Convert.ToInt32(sqlDataReader["EmployeePHdGuideStudentsDetailsID"]);    
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeePHdGuideRecognisationDetailsID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["EmployeePHdGuideRecognisationDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                        {
                            item.StudentName =Convert.ToString(sqlDataReader["StudentName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Synopsis"]) == false)
                        {
                            item.Synopsis = Convert.ToString(sqlDataReader["Synopsis"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersuingFromDate"]) == false)
                        {
                            item.PersuingFromDate = Convert.ToString(sqlDataReader["PersuingFromDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersuingUptoDate"]) == false)
                        {
                            item.PersuingUptoDate = Convert.ToString(sqlDataReader["PersuingUptoDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovalStatus"]) == false)
                        {
                            item.ApprovalStatus = Convert.ToString(sqlDataReader["ApprovalStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Remarks"]) == false)
                        {
                            item.EmployeePHdGuideStudentsDetailsRemarks = Convert.ToString(sqlDataReader["Remarks"]);
                        }
						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_EmployeePHdGuideStudentsDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> GetEmployeePHdGuideStudentsDetailsByID(EmployeePHdGuideRecognisationDetails item)
		{
			IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
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
					cmdToExecute.CommandText = "dbo.USP_EmployeePHdGuideStudentsDetails_SelectOne";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeePHdGuideStudentsDetailsID));
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
						EmployeePHdGuideRecognisationDetails _item = new EmployeePHdGuideRecognisationDetails();
                        if (DBNull.Value.Equals(sqlDataReader["EmployeePHdGuideStudentsDetailsID"]) == false)
                        {
                            _item.EmployeePHdGuideStudentsDetailsID = Convert.ToInt32(sqlDataReader["EmployeePHdGuideStudentsDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeePHdGuideRecognisationDetailsID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["EmployeePHdGuideRecognisationDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                        {
                            _item.StudentName = Convert.ToString(sqlDataReader["StudentName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Synopsis"]) == false)
                        {
                            _item.Synopsis = Convert.ToString(sqlDataReader["Synopsis"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersuingFromDate"]) == false)
                        {
                            _item.PersuingFromDate = Convert.ToString(sqlDataReader["PersuingFromDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersuingUptoDate"]) == false)
                        {
                            _item.PersuingUptoDate = Convert.ToString(sqlDataReader["PersuingUptoDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovalStatus"]) == false)
                        {
                            _item.ApprovalStatus = Convert.ToString(sqlDataReader["ApprovalStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovalDate"]) == false)
                        {
                            _item.ApprovalDate = Convert.ToString(sqlDataReader["ApprovalDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Remarks"]) == false)
                        {
                            _item.EmployeePHdGuideStudentsDetailsRemarks = Convert.ToString(sqlDataReader["Remarks"]);
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
        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> InsertEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item)
        {
            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePHdGuideStudentsDetails_InsertUpdate";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeePHdGuideRecognisationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EmployeePHdGuideStudentsDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sStudentName", SqlDbType.VarChar, 100,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.StudentName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSynopsis", SqlDbType.VarChar, 100,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.Synopsis));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daPersuingFromDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersuingFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daPersuingUptoDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersuingUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sApprovalStatus", SqlDbType.VarChar, 20,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ApprovalStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daApprovalDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApprovalDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sRemarks", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeePHdGuideStudentsDetailsRemarks));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNewID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, null));
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
                        item.EmployeePHdGuideStudentsDetailsID = (Int32)cmdToExecute.Parameters["@iNewID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeePHdGuideStudentsDetails_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of EmployeePHdGuideStudentsDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> UpdateEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item)
        {
            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePHdGuideStudentsDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeePHdGuideRecognisationDetailsID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.EmployeePHdGuideRecognisationDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sStudentName", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.StudentName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSynopsis", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.Synopsis));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.PersuingFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.PersuingUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sApprovalStatus", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ApprovalStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ApprovalDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sRemarks", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.Remarks));

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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeePHdGuideStudentsDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of EmployeePHdGuideStudentsDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> DeleteEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item)
        {
            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePHdGuideStudentsDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EmployeePHdGuideStudentsDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, 1));
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
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeePHdGuideStudentsDetails_Delete' reported the ErrorCode: " +
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
        #endregion
	}
}
