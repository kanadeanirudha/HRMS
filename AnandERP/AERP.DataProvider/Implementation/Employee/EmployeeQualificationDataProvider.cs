using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace AERP.DataProvider
{
    public class EmployeeQualificationDataProvider : DBInteractionBase, IEmployeeQualificationDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeeQualificationDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeeQualificationDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EmployeeQualification table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeQualification> GetEmployeeQualificationBySearch(EmployeeQualificationSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EmployeeQualification> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeQualification>();
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
					cmdToExecute.CommandText = "dbo.USP_EmployeeQualification_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
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
					baseEntityCollection.CollectionResponse = new List<EmployeeQualification>();
					while (sqlDataReader.Read())
					{
						EmployeeQualification item = new EmployeeQualification();
						item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
						item.FromYear = sqlDataReader["FromYear"].ToString();
						item.UptoYear = sqlDataReader["UptoYear"].ToString();
						item.YearOfPassing = sqlDataReader["YearOfPassing"].ToString();
						item.PassingDivision = sqlDataReader["PassingDivision"].ToString();
						item.NoOfAttempts = Convert.ToByte(sqlDataReader["NoOfAttempts"]);
						item.NameOfInstitution = sqlDataReader["NameOfInstitution"].ToString();
						item.EducationID = Convert.ToInt32(sqlDataReader["EducationID"]);
						item.EducationYear = sqlDataReader["EducationYear"].ToString();                       
						item.BoardUniversityID = Convert.ToInt32(sqlDataReader["BoardUniversityID"]);
						item.AggregatePercentage= Convert.ToDouble(sqlDataReader["AggregatePercentage"]);
						item.FinalYearPercentage= Convert.ToDouble(sqlDataReader["AggregatePercentage"]);
                        item.Rank = Convert.ToByte(sqlDataReader["Rank"]);
						item.Remark = sqlDataReader["Remark"].ToString();
						item.SpecailisationIn = sqlDataReader["SpecailisationIn"].ToString();
                        item.UniversityName = sqlDataReader["UniversityName"].ToString();
                        item.EducationName = sqlDataReader["Education"].ToString();
                        item.EducationType = sqlDataReader["EducationType"].ToString();
					

						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_EmployeeQualification_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeQualification> GetEmployeeQualificationByID(EmployeeQualification item)
		{
			IBaseEntityResponse<EmployeeQualification> response = new BaseEntityResponse<EmployeeQualification>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeQualification_SelectOne";
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
						EmployeeQualification _item = new EmployeeQualification();
						_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FromYear"]) == false)
                        {
                            _item.FromYear = sqlDataReader["FromYear"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UptoYear"]) == false)
                        {
                            _item.UptoYear = sqlDataReader["UptoYear"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["YearOfPassing"]) == false)
                        {
                            _item.YearOfPassing = sqlDataReader["YearOfPassing"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PassingDivision"]) == false)
                        {
                            _item.PassingDivision = sqlDataReader["PassingDivision"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NoOfAttempts"]) == false)
                        {
                            _item.NoOfAttempts = Convert.ToByte(sqlDataReader["NoOfAttempts"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NameOfInstitution"]) == false)
                        {
                            _item.NameOfInstitution = sqlDataReader["NameOfInstitution"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EducationTypeID"]) == false)
                        {
                            _item.EducationTypeID = Convert.ToInt32(sqlDataReader["EducationTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EducationID"]) == false)
                        {
                            _item.EducationID = Convert.ToInt32(sqlDataReader["EducationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EducationYear"]) == false)
                        {
                            _item.EducationYear = sqlDataReader["EducationYear"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Unit"]) == false)
                        {
                            _item.Unit = sqlDataReader["Unit"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BoardUniversityID"]) == false)
                        {
                            _item.BoardUniversityID = Convert.ToInt32(sqlDataReader["BoardUniversityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AggregatePercentage"]) == false)
                        {
                            _item.AggregatePercentage = Convert.ToDouble(sqlDataReader["AggregatePercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FinalYearPercentage"]) == false)
                        {
                            _item.FinalYearPercentage = Convert.ToDouble(sqlDataReader["FinalYearPercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rank"]) == false)
                        {
                            _item.Rank = Convert.ToByte(sqlDataReader["Rank"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Remark"]) == false)
                        {
                            _item.Remark = sqlDataReader["Remark"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SpecailisationIn"]) == false)
                        {
                            _item.SpecailisationIn = sqlDataReader["SpecailisationIn"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_EmployeeQualification_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeQualification> InsertEmployeeQualification(EmployeeQualification item)
		{
			IBaseEntityResponse<EmployeeQualification> response = new BaseEntityResponse<EmployeeQualification>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeQualification_Insert";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    if (item.EmployeeID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.EmployeeID));
                    }
                    if (item.FromYear == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sFromYear", SqlDbType.VarChar, 10,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sFromYear", SqlDbType.VarChar, 10,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.FromYear));
                    }
                    if (item.UptoYear == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUptoYear", SqlDbType.VarChar, 10,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUptoYear", SqlDbType.VarChar, 10,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.UptoYear));
                    }
                    if (item.YearOfPassing == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sYearOfPassing", SqlDbType.VarChar, 10,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sYearOfPassing", SqlDbType.VarChar, 10,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.YearOfPassing));
                    }
                    if (item.PassingDivision == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPassingDivision", SqlDbType.NVarChar, 50,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPassingDivision", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PassingDivision));
                    }
                    if (item.NoOfAttempts == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiNoOfAttempts", SqlDbType.TinyInt, 3,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiNoOfAttempts", SqlDbType.TinyInt, 3,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.NoOfAttempts));
                    }
                    if (item.NameOfInstitution == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNameOfInstitution", SqlDbType.NVarChar, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNameOfInstitution", SqlDbType.NVarChar, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.NameOfInstitution));                    
                    }
                    if (item.EducationTypeID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEducationTypeID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEducationTypeID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.EducationTypeID));
                    }
                    if (item.EducationID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEducationID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEducationID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.EducationID));
                    }
                    if (item.EducationYear == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEducationYear", SqlDbType.VarChar, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEducationYear", SqlDbType.VarChar, 0,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, item.EducationYear));
                    }
                    if (item.Unit == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUnit", SqlDbType.NVarChar, 10,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUnit", SqlDbType.NVarChar, 10,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, item.Unit));
                    }
                    if (item.BoardUniversityID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iBoardUniversityID", SqlDbType.Int, 10,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iBoardUniversityID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.BoardUniversityID));
                    }
                    if (item.AggregatePercentage == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("fAggregatePercentage", SqlDbType.Float, 53,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("fAggregatePercentage", SqlDbType.Float, 53,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.AggregatePercentage));
                    }
                    if (item.FinalYearPercentage == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("fFinalYearPercentage", SqlDbType.Float, 53,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("fFinalYearPercentage", SqlDbType.Float, 53,
                                                  ParameterDirection.Input, false, 0, 0, "",
                                                  DataRowVersion.Proposed, item.FinalYearPercentage));
                    }
                    if (item.Rank == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("tiRank", SqlDbType.TinyInt, 3,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("tiRank", SqlDbType.TinyInt, 3,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.Rank));
                    }
                    if (item.Remark == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemark", SqlDbType.NVarChar, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemark", SqlDbType.NVarChar, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.Remark));
                    }
                    if (item.SpecailisationIn == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSpecailisationIn", SqlDbType.NVarChar, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSpecailisationIn", SqlDbType.NVarChar, 0,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, item.SpecailisationIn));
                    }                   
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, true));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
											ParameterDirection.Input, true, 10, 0,"",
											DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                            ParameterDirection.Output, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ID));
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeQualification_Insert' reported the ErrorCode: " + 
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
        /// Update a specific record of EmployeeQualification
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeQualification> UpdateEmployeeQualification(EmployeeQualification item)
		{
			IBaseEntityResponse<EmployeeQualification> response = new BaseEntityResponse<EmployeeQualification>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeQualification_Update";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ID));
                    if (item.EmployeeID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                              ParameterDirection.Input, false, 0, 0, "",
                                              DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeID));
                    }
                    if (item.FromYear == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sFromYear", SqlDbType.VarChar, 10,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sFromYear", SqlDbType.VarChar, 10,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FromYear));
                    }
                    if (item.UptoYear == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUptoYear", SqlDbType.VarChar, 10,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUptoYear", SqlDbType.VarChar, 10,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.UptoYear));
                    }
                    if (item.YearOfPassing == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sYearOfPassing", SqlDbType.VarChar, 10,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sYearOfPassing", SqlDbType.VarChar, 10,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.YearOfPassing));
                    }
                    if (item.PassingDivision == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPassingDivision", SqlDbType.VarChar, 50,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPassingDivision", SqlDbType.VarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PassingDivision));
                    }
                    if (item.NoOfAttempts == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiNoOfAttempts", SqlDbType.TinyInt, 3,
                                             ParameterDirection.Input, false, 0, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiNoOfAttempts", SqlDbType.TinyInt, 3,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.NoOfAttempts));
                    }
                    if (item.NameOfInstitution == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNameOfInstitution", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNameOfInstitution", SqlDbType.NVarChar, 255,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.NameOfInstitution));
                    }
                    if (item.EducationTypeID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEducationTypeID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEducationTypeID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.EducationTypeID));
                    }
                    if (item.EducationID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEducationID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEducationID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.EducationID));
                    }
                    if (item.EducationYear == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEducationYear", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEducationYear", SqlDbType.VarChar, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.EducationYear));
                    }
                    if (item.Unit == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUnit", SqlDbType.NVarChar, 10,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUnit", SqlDbType.NVarChar, 10,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.Unit));
                    }
                    if (item.BoardUniversityID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iBoardUniversityID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iBoardUniversityID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.BoardUniversityID));
                    }
                    if (item.AggregatePercentage == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@fAggregatePercentage", SqlDbType.Float, 53,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@fAggregatePercentage", SqlDbType.Float, 53,
                                       ParameterDirection.Input, false, 0, 0, "",
                                       DataRowVersion.Proposed, item.AggregatePercentage));
                    }
                    if (item.FinalYearPercentage == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@fFinalYearPercentage", SqlDbType.Float, 53,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                        else
                    {
                    cmdToExecute.Parameters.Add(new SqlParameter("@fFinalYearPercentage", SqlDbType.Float, 53,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.FinalYearPercentage));
                    }
                    if (item.Rank == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiRank", SqlDbType.TinyInt, 3,
                                              ParameterDirection.Input, false, 0, 0, "",
                                              DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiRank", SqlDbType.TinyInt, 3,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.Rank));
                    }
                    if (item.Remark == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemark", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                     cmdToExecute.Parameters.Add(new SqlParameter("@nsRemark", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Remark));
                    }
                    if (item.SpecailisationIn == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSpecailisationIn", SqlDbType.NVarChar, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSpecailisationIn", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.SpecailisationIn));
                    }
                    if (item.IsActive == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.IsActive));
                    }
                    if (item.ModifiedBy == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                                    ParameterDirection.Input, true, 10, 0, "",
                                                    DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, item.ModifiedBy));
                    }
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeQualification_Update' reported the ErrorCode: " + 
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
        /// Delete a specific record of EmployeeQualification
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeQualification> DeleteEmployeeQualification(EmployeeQualification item)
        {
            IBaseEntityResponse<EmployeeQualification> response = new BaseEntityResponse<EmployeeQualification>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeQualification_Delete";
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
                                            DataRowVersion.Proposed, 1));
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeQualification_Delete' reported the ErrorCode: " +
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
