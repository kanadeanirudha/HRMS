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
    public class LeaveAvailedDataProvider : DBInteractionBase, ILeaveAvailedDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public LeaveAvailedDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public LeaveAvailedDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from LeaveAvailed table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveAvailed> GetLeaveAvailedBySearch(LeaveAvailedSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<LeaveAvailed> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<LeaveAvailed>();
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
					cmdToExecute.CommandText = "dbo.USP_LeaveAvailed_SelectAll";
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
					baseEntityCollection.CollectionResponse = new List<LeaveAvailed>();
					while (sqlDataReader.Read())
					{
						LeaveAvailed item = new LeaveAvailed();
						item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						item.LeaveApprovedID = Convert.ToInt32(sqlDataReader["LeaveApprovedID"]);
                        //Not
                        //Not
                        //item.TotalFullDay = Convert.ToInt32(sqlDataReader["TotalFullDay"]);
                        //item.TotalHalfDay = Convert.ToInt32(sqlDataReader["TotalHalfDay"]);
                        //item.HalfLeaveStartStatus = sqlDataReader["HalfLeaveStartStatus"].ToString();
                        //item.LeaveSummaryID = Convert.ToInt32(sqlDataReader["LeaveSummaryID"]);
                        //item.Remark = sqlDataReader["Remark"].ToString();
                        //item.LeaveStatus = sqlDataReader["LeaveStatus"].ToString();
                        //Not
                        //Not
                        //item.TotalFullDayOrg = Convert.ToInt32(sqlDataReader["TotalFullDayOrg"]);
                        //item.TotalHalfDayOrg = Convert.ToInt32(sqlDataReader["TotalHalfDayOrg"]);
                        //item.LeaveApplicationID = Convert.ToInt32(sqlDataReader["LeaveApplicationID"]);
                        //item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
						item.LeaveCreditDetailsID = Convert.ToInt32(sqlDataReader["LeaveCreditDetailsID"]);
						item.LeaveAvailedFlag = Convert.ToBoolean(sqlDataReader["LeaveAvailedFlag"]);
						item.LeaveCancelCreditID = Convert.ToInt32(sqlDataReader["LeaveCancelCreditID"]);

						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_LeaveAvailed_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<LeaveAvailed> GetLeaveAvailedByID(LeaveAvailed item)
		{
			IBaseEntityResponse<LeaveAvailed> response = new BaseEntityResponse<LeaveAvailed>();
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
					cmdToExecute.CommandText = "dbo.USP_LeaveAvailed_SelectOne";
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
						LeaveAvailed _item = new LeaveAvailed();
						_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						_item.LeaveApprovedID = Convert.ToInt32(sqlDataReader["LeaveApprovedID"]);
                        //_Not
                        //_Not
                        //_item.TotalFullDay = Convert.ToInt32(sqlDataReader["TotalFullDay"]);
                        //_item.TotalHalfDay = Convert.ToInt32(sqlDataReader["TotalHalfDay"]);
                        //_item.HalfLeaveStartStatus = sqlDataReader["HalfLeaveStartStatus"].ToString();
                        //_item.LeaveSummaryID = Convert.ToInt32(sqlDataReader["LeaveSummaryID"]);
                        //_item.Remark = sqlDataReader["Remark"].ToString();
                        //_item.LeaveStatus = sqlDataReader["LeaveStatus"].ToString();
                        //_Not
                        //_Not
                        //_item.TotalFullDayOrg = Convert.ToInt32(sqlDataReader["TotalFullDayOrg"]);
                        //_item.TotalHalfDayOrg = Convert.ToInt32(sqlDataReader["TotalHalfDayOrg"]);
                        //_item.LeaveApplicationID = Convert.ToInt32(sqlDataReader["LeaveApplicationID"]);
                        //_item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //_item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
						_item.LeaveCreditDetailsID = Convert.ToInt32(sqlDataReader["LeaveCreditDetailsID"]);
						_item.LeaveAvailedFlag = Convert.ToBoolean(sqlDataReader["LeaveAvailedFlag"]);
						_item.LeaveCancelCreditID = Convert.ToInt32(sqlDataReader["LeaveCancelCreditID"]);

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
        public IBaseEntityResponse<LeaveAvailed> InsertLeaveAvailed(LeaveAvailed item)
        {
            IBaseEntityResponse<LeaveAvailed> response = new BaseEntityResponse<LeaveAvailed>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveAvailed_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveApplicationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LeaveApplicationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectdIDs", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SelectedIDs));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToByte(item.IsLastRecord)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskReportingDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskReportingDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bApprovalStatus", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToBoolean(Convert.ToInt16(item.ApprovalStatus))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LeaveMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StageSequenceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRemark", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Remark != null ? item.Remark.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fTotalDay", SqlDbType.Float, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalDays));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fTotalApprovedFullDay", SqlDbType.Float, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalApprovedFullDay));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fTotalApprovedHalfDay", SqlDbType.Float, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalApprovedHalfDay));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Status));                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
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
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveAvailed_Insert' reported the ErrorCode: " +
                                            _errorCode);
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
        /// Update a specific record of LeaveAvailed
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveAvailed> UpdateLeaveAvailed(LeaveAvailed item)
        {
            IBaseEntityResponse<LeaveAvailed> response = new BaseEntityResponse<LeaveAvailed>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveAvailed_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveApprovedID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.LeaveApprovedID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.date, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.LeaveAvailedFromDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.date, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.LeaveAvailedUptoDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siTotalFullDay", SqlDbType.smallint, 5,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.TotalFullDay));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siTotalHalfDay", SqlDbType.smallint, 5,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.TotalHalfDay));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sHalfLeaveStartStatus", SqlDbType.varchar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.HalfLeaveStartStatus));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveSummaryID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.LeaveSummaryID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sRemark", SqlDbType.varchar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.Remark));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sLeaveStatus", SqlDbType.varchar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.LeaveStatus));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.date, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.LeaveAvailedFromDateOrg));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.date, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.LeaveAvailedUptoDateOrg));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siTotalFullDayOrg", SqlDbType.smallint, 5,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.TotalFullDayOrg));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siTotalHalfDayOrg", SqlDbType.smallint, 5,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.TotalHalfDayOrg));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveApplicationID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.LeaveApplicationID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.CentreCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveCreditDetailsID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.LeaveCreditDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bLeaveAvailedFlag", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.LeaveAvailedFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveCancelCreditID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.LeaveCancelCreditID));

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
                        throw new Exception("Stored Procedure 'dbo.USP_LeaveAvailed_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of LeaveAvailed
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveAvailed> DeleteLeaveAvailed(LeaveAvailed item)
        {
            IBaseEntityResponse<LeaveAvailed> response = new BaseEntityResponse<LeaveAvailed>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveAvailed_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_LeaveAvailed_Delete' reported the ErrorCode: " +
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
        /// Select all record from LeaveAvailed table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveAvailed> GetLeaveRequestForApproval_ByPersonID(LeaveAvailedSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveAvailed> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<LeaveAvailed>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveRequestForApproval_ByPersonID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskNotificationMasterID));
                    
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
                    baseEntityCollection.CollectionResponse = new List<LeaveAvailed>();
                    while (sqlDataReader.Read())
                    {
                        LeaveAvailed item = new LeaveAvailed();
                        if (DBNull.Value.Equals(sqlDataReader["LeaveDescription"]) == false)
                        {
                            item.LeaveDescription = sqlDataReader["LeaveDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveReason"]) == false)
                        {
                            item.LeaveReason = sqlDataReader["LeaveReason"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Dates"]) == false)
                        {
                            //item.Dates = String.Format("{0:yyyy-MM-dd}",sqlDataReader["Dates"]);
                            item.Dates = sqlDataReader["Dates"].ToString();
                        }
                        item.FullDayHalfDayFlag = Convert.ToBoolean(sqlDataReader["FullDayHalfDayFlag"]);                       
                        if (DBNull.Value.Equals(sqlDataReader["HalfLeaveStatus"]) == false)
                        {
                            item.HalfLeaveStatus = sqlDataReader["HalfLeaveStatus"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveTransactionHistoryStatus"]) == false)
                        {
                            item.LeaveTransactionHistoryStatus = sqlDataReader["LeaveTransactionHistoryStatus"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovalStatus"]) == false)
                        {
                            item.ApprovalStatus = sqlDataReader["ApprovalStatus"].ToString();
                        }                       
                        if (DBNull.Value.Equals(sqlDataReader["LastApprovalStatus"]) == false)
                        {
                            item.LastApprovalStatus = sqlDataReader["LastApprovalStatus"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveApplicationID"]) == false)
                        {
                            item.LeaveApplicationID = Convert.ToInt32(sqlDataReader["LeaveApplicationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveApplicationTransactionID"]) == false)
                        {
                            item.LeaveApplicationTransactionID = Convert.ToInt32(sqlDataReader["LeaveApplicationTransactionID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveMasterID"]) == false)
                        {
                            item.LeaveMasterID = Convert.ToInt32(sqlDataReader["LeaveMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActionFlag"]) == false)
                        {
                            item.ActionFlag = Convert.ToBoolean(sqlDataReader["ActionFlag"]);
                        }
                       
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
                        throw new Exception("Stored Procedure 'USP_LeaveRequestForApproval_ByPersonID' reported the ErrorCode: " + _errorCode);
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
