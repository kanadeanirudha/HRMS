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
    public class EmployeeChildrenDetailsDataProvider : DBInteractionBase, IEmployeeChildrenDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeeChildrenDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeeChildrenDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EmployeeChildrenDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeChildrenDetails> GetEmployeeChildrenDetailsBySearch(EmployeeChildrenDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EmployeeChildrenDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeChildrenDetails>();
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
					cmdToExecute.CommandText = "dbo.USP_EmployeeChildrenDetails_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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
					baseEntityCollection.CollectionResponse = new List<EmployeeChildrenDetails>();
					while (sqlDataReader.Read())
					{
						EmployeeChildrenDetails item = new EmployeeChildrenDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                      
                        if (DBNull.Value.Equals(sqlDataReader["NameTitle"]) == false)
                        {
                            item.NameTitle = sqlDataReader["NameTitle"].ToString();

                        }

                        if (DBNull.Value.Equals(sqlDataReader["ChildName"]) == false)
                        {
                            item.ChildName = sqlDataReader["ChildName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChildQualification"]) == false)
                        {
                            item.ChildQualification = sqlDataReader["ChildQualification"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChildDateOfBirth"]) == false)
                        {
                            item.ChildDateOfBirth = Convert.ToString(sqlDataReader["ChildDateOfBirth"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Hobby"]) == false)
                        {
                            item.Hobby = Convert.ToString(sqlDataReader["Hobby"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Sports"]) == false)
                        {
                            item.Sports = Convert.ToString(sqlDataReader["Sports"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurriculamActivity"]) == false)
                        {
                            item.CurriculamActivity = Convert.ToString(sqlDataReader["CurriculamActivity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GotAnyMedal"]) == false)
                        {
                            item.GotAnyMedal = Convert.ToBoolean(sqlDataReader["GotAnyMedal"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MedalReceivedDate"]) == false)
                        {

                            item.MedalReceivedDate = Convert.ToString(sqlDataReader["MedalReceivedDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MedalDescription"]) == false)
                        {
                            item.MedalDescription = sqlDataReader["MedalDescription"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["IsScholarshipReceived"]) == false)
                        {
                            item.IsScholarshipReceived = Convert.ToBoolean(sqlDataReader["IsScholarshipReceived"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipAmount"]) == false)
                        {
                            item.ScholarshipAmount = Convert.ToDecimal(sqlDataReader["ScholarshipAmount"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipStartDate"]) == false)
                        {

                            item.ScholarshipStartDate = Convert.ToString(sqlDataReader["ScholarshipStartDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipUptoDate"]) == false)
                        {

                            item.ScholarshipUptoDate = Convert.ToString(sqlDataReader["ScholarshipUptoDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipDescription"]) == false)
                        {
                            item.ScholarshipDescription = sqlDataReader["ScholarshipDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IdentityMarks"]) == false)
                        {
                            item.IdentityMarks = Convert.ToString(sqlDataReader["IdentityMarks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Profession"]) == false)
                        {
                            item.Profession = Convert.ToString(sqlDataReader["Profession"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["Height"]) == false)
                        {
                            item.Height = Convert.ToString(sqlDataReader["Height"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Weight"]) == false)
                        {
                            item.Weight = Convert.ToString(sqlDataReader["Weight"]);
                        }


                       
                        if (DBNull.Value.Equals(sqlDataReader["ChildrenRelation"]) == false)
                        {
                            item.ChildrenRelation = Convert.ToString(sqlDataReader["ChildrenRelation"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        { 
						item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
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
						throw new Exception("Stored Procedure 'USP_EmployeeChildrenDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeChildrenDetails> GetEmployeeChildrenDetailsByID(EmployeeChildrenDetails item)
		{
			IBaseEntityResponse<EmployeeChildrenDetails> response = new BaseEntityResponse<EmployeeChildrenDetails>();
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
					cmdToExecute.CommandText = "dbo.USP_EmployeeChildrenDetails_SelectOne";
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
						EmployeeChildrenDetails _item = new EmployeeChildrenDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                       
                        if (DBNull.Value.Equals(sqlDataReader["NameTitle"]) == false)
                        {
                            _item.NameTitle = sqlDataReader["NameTitle"].ToString();

                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChildName"]) == false)
                        {
                            _item.ChildName = sqlDataReader["ChildName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChildQualification"]) == false)
                        {
                            _item.ChildQualification = sqlDataReader["ChildQualification"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChildDateOfBirth"]) == false)
                        {
                            _item.ChildDateOfBirth = Convert.ToString(sqlDataReader["ChildDateOfBirth"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Hobby"]) == false)
                        {
                            _item.Hobby = sqlDataReader["Hobby"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Sports"]) == false)
                        {
                            _item.Sports = sqlDataReader["Sports"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurriculamActivity"]) == false)
                        {
                            _item.CurriculamActivity = sqlDataReader["CurriculamActivity"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GotAnyMedal"]) == false)
                        {
                            _item.GotAnyMedal = Convert.ToBoolean(sqlDataReader["GotAnyMedal"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MedalReceivedDate"]) == false)
                        {

                            _item.MedalReceivedDate = Convert.ToString(sqlDataReader["MedalReceivedDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MedalDescription"]) == false)
                        {
                            _item.MedalDescription = sqlDataReader["MedalDescription"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["IsScholarshipReceived"]) == false)
                        {
                            _item.IsScholarshipReceived = Convert.ToBoolean(sqlDataReader["IsScholarshipReceived"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipAmount"]) == false)
                        {
                            _item.ScholarshipAmount = Convert.ToDecimal(sqlDataReader["ScholarshipAmount"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipStartDate"]) == false)
                        {

                            _item.ScholarshipStartDate = Convert.ToString(sqlDataReader["ScholarshipStartDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipUptoDate"]) == false)
                        {

                            _item.ScholarshipUptoDate = Convert.ToString(sqlDataReader["ScholarshipUptoDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipDescription"]) == false)
                        {
                            _item.ScholarshipDescription = Convert.ToString(sqlDataReader["ScholarshipDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IdentityMarks"]) == false)
                        {
                            _item.IdentityMarks = Convert.ToString(sqlDataReader["IdentityMarks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Profession"]) == false)
                        {
                            _item.Profession = Convert.ToString(sqlDataReader["Profession"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Height"]) == false)
                        {
                            _item.Height = Convert.ToString(sqlDataReader["Height"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Weight"]) == false)
                        {
                            _item.Weight = Convert.ToString(sqlDataReader["Weight"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChildrenRelation"]) == false)
                        {
                            _item.ChildrenRelation = Convert.ToString(sqlDataReader["ChildrenRelation"]);
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
        public IBaseEntityResponse<EmployeeChildrenDetails> InsertEmployeeChildrenDetails(EmployeeChildrenDetails item)
        {
            IBaseEntityResponse<EmployeeChildrenDetails> response = new BaseEntityResponse<EmployeeChildrenDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeChildrenDetails_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNameTitle", SqlDbType.NVarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.NameTitle));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsChildName", SqlDbType.NVarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ChildName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsChildQualification", SqlDbType.NVarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ChildQualification));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daChildDateOfBirth", SqlDbType.Date, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ChildDateOfBirth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsHobby", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Hobby != null ? item.Hobby : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSports", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Sports != null ? item.Sports : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCurriculamActivity", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CurriculamActivity != null ? item.CurriculamActivity : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bGotAnyMedal", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GotAnyMedal));
                    if (item.MedalReceivedDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMedalReceivedDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MedalReceivedDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMedalReceivedDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.MedalDescription != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMedalDescription", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MedalDescription));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMedalDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }


                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsScholarshipReceived", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsScholarshipReceived));
                    if (item.ScholarshipAmount != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dScholarshipAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipAmount));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dScholarshipAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }




                    if (item.ScholarshipDescription != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsScholarshipDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipDescription));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsScholarshipDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }



                    if (item.ScholarshipStartDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipStartDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipStartDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipStartDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.ScholarshipUptoDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipUptoDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipUptoDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipUptoDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsIdentityMarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IdentityMarks != null ? item.IdentityMarks : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsProfession", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Profession != null ? item.Profession : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsHeight", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Height != null ? item.Height : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsWeight", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Weight != null ? item.Weight : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsChildrenRelation", SqlDbType.NVarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ChildrenRelation));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsActive));
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeChildrenDetails_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of EmployeeChildrenDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeChildrenDetails> UpdateEmployeeChildrenDetails(EmployeeChildrenDetails item)
        {
            IBaseEntityResponse<EmployeeChildrenDetails> response = new BaseEntityResponse<EmployeeChildrenDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeChildrenDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNameTitle", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.NameTitle));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsChildName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ChildName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsChildQualification", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ChildQualification));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daChildDateOfBirth", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ChildDateOfBirth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsHobby", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Hobby != null ? item.Hobby : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSports", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Sports != null ? item.Sports : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCurriculamActivity", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CurriculamActivity != null ? item.CurriculamActivity : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bGotAnyMedal", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GotAnyMedal));
                    if (item.MedalReceivedDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMedalReceivedDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MedalReceivedDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMedalReceivedDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.MedalDescription != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMedalDescription", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MedalDescription));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMedalDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }


                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsScholarshipReceived", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsScholarshipReceived));
                    if (item.ScholarshipAmount != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dScholarshipAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipAmount));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dScholarshipAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }




                    if (item.ScholarshipDescription != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsScholarshipDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipDescription));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsScholarshipDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }



                    if (item.ScholarshipStartDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipStartDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipStartDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipStartDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.ScholarshipUptoDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipUptoDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipUptoDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipUptoDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsIdentityMarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IdentityMarks != null ? item.IdentityMarks : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsProfession", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Profession != null ? item.Profession : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsHeight", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Height != null ? item.Height : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsWeight", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Weight != null ? item.Weight : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsChildrenRelation", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ChildrenRelation));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeChildrenDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of EmployeeChildrenDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeChildrenDetails> DeleteEmployeeChildrenDetails(EmployeeChildrenDetails item)
        {
            IBaseEntityResponse<EmployeeChildrenDetails> response = new BaseEntityResponse<EmployeeChildrenDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeChildrenDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ID));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeChildrenDetails_Delete' reported the ErrorCode: " +
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
