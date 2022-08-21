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
    public class LeaveMasterDataProvider : DBInteractionBase, ILeaveMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public LeaveMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public LeaveMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from LeaveMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveMaster> GetLeaveMasterBySearch(LeaveMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<LeaveMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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
                    baseEntityCollection.CollectionResponse = new List<LeaveMaster>();
                    while (sqlDataReader.Read())
                    {
                        LeaveMaster item = new LeaveMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["LeaveCode"]) == false)
                        {
                            item.LeaveCode = sqlDataReader["LeaveCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveDescription"]) == false)
                        {
                            item.LeaveDescription = sqlDataReader["LeaveDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCarryForwardForNextYear"]) == false)
                        {
                            item.IsCarryForwardForNextYear = Convert.ToBoolean(sqlDataReader["IsCarryForwardForNextYear"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEnCash"]) == false)
                        {
                            item.IsEnCash = Convert.ToBoolean(sqlDataReader["IsEnCash"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["AttendanceNeeded"]) == false)
                        //{
                        //    item.AttendanceNeeded = Convert.ToBoolean(sqlDataReader["AttendanceNeeded"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["DocumentsNeeded"]) == false)
                        {
                            item.DocumentsNeeded = Convert.ToBoolean(sqlDataReader["DocumentsNeeded"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["HalfDayFlag"]) == false)
                        //{
                        //    item.HalfDayFlag = Convert.ToBoolean(sqlDataReader["HalfDayFlag"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["LossOfPay"]) == false)
                        {
                            item.LossOfPay = Convert.ToBoolean(sqlDataReader["LossOfPay"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["NoCredit"]) == false)
                        //{
                        //    item.NoCredit = Convert.ToBoolean(sqlDataReader["NoCredit"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["MinServiceRequire"]) == false)
                        {
                            item.MinServiceRequire = Convert.ToBoolean(sqlDataReader["MinServiceRequire"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["OnDuty"]) == false)
                        //{
                        //    item.OnDuty = Convert.ToBoolean(sqlDataReader["OnDuty"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["IsNeedToInformAdvance"]) == false)
                        {
                            item.NeedToInformInAdvance = Convert.ToBoolean(sqlDataReader["IsNeedToInformAdvance"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsPostedOnce"]) == false)
                        {
                            item.IsPostedOnce = Convert.ToBoolean(sqlDataReader["IsPostedOnce"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveType"]) == false)
                        {
                            item.LeaveType = sqlDataReader["LeaveType"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_LeaveMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<LeaveMaster> GetLeaveMasterByID(LeaveMaster item)
        {
            IBaseEntityResponse<LeaveMaster> response = new BaseEntityResponse<LeaveMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveMaster_SelectOne";
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
                        LeaveMaster _item = new LeaveMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["LeaveCode"]) == false)
                        {
                            _item.LeaveCode = sqlDataReader["LeaveCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveDescription"]) == false)
                        {
                            _item.LeaveDescription = sqlDataReader["LeaveDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCarryForwardForNextYear"]) == false)
                        {
                            _item.IsCarryForwardForNextYear = Convert.ToBoolean(sqlDataReader["IsCarryForwardForNextYear"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEnCash"]) == false)
                        {
                            _item.IsEnCash = Convert.ToBoolean(sqlDataReader["IsEnCash"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["AttendanceNeeded"]) == false)
                        //{
                        //    _item.AttendanceNeeded = Convert.ToBoolean(sqlDataReader["AttendanceNeeded"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["DocumentsNeeded"]) == false)
                        {
                            _item.DocumentsNeeded = Convert.ToBoolean(sqlDataReader["DocumentsNeeded"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["HalfDayFlag"]) == false)
                        //{
                        //    _item.HalfDayFlag = Convert.ToBoolean(sqlDataReader["HalfDayFlag"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["LossOfPay"]) == false)
                        {
                            _item.LossOfPay = Convert.ToBoolean(sqlDataReader["LossOfPay"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["NoCredit"]) == false)
                        //{
                        //    _item.NoCredit = Convert.ToBoolean(sqlDataReader["NoCredit"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["MinServiceRequire"]) == false)
                        {
                            _item.MinServiceRequire = Convert.ToBoolean(sqlDataReader["MinServiceRequire"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["OnDuty"]) == false)
                        //{
                        //    _item.OnDuty = Convert.ToBoolean(sqlDataReader["OnDuty"]);
                        //}

                        if (DBNull.Value.Equals(sqlDataReader["IsNeedToInformAdvance"]) == false)
                        {
                            _item.NeedToInformInAdvance = Convert.ToBoolean(sqlDataReader["IsNeedToInformAdvance"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsPostedOnce"]) == false)
                        {
                            _item.IsPostedOnce = Convert.ToBoolean(sqlDataReader["IsPostedOnce"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveType"]) == false)
                        {
                            _item.LeaveType = sqlDataReader["LeaveType"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_LeaveMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<LeaveMaster> InsertLeaveMaster(LeaveMaster item)
        {
            IBaseEntityResponse<LeaveMaster> response = new BaseEntityResponse<LeaveMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLeaveCode", SqlDbType.NVarChar, 5,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.LeaveCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLeaveDescription", SqlDbType.NVarChar,20,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.LeaveDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCarryForwardForNextYear", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.IsCarryForwardForNextYear));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsEnCash", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.IsEnCash));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bAttendanceNeeded", SqlDbType.Bit, 0,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.AttendanceNeeded));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDocumentsNeeded", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.DocumentsNeeded));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bHalfDayFlag", SqlDbType.Bit, 0,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.HalfDayFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bLossOfPay", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.LossOfPay));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bNoCredit", SqlDbType.Bit, 0,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.NoCredit));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bMinServiceRequire", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MinServiceRequire));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bOnDuty", SqlDbType.Bit, 0,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.OnDuty));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bNeedToInformInAdvance", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.NeedToInformInAdvance));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsPostedOnce", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.IsPostedOnce));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLeaveType", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.LeaveType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output,
                                                                 true, 10, 0, "", DataRowVersion.Proposed, item.ID));
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

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of LeaveMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveMaster> UpdateLeaveMaster(LeaveMaster item)
        {
            IBaseEntityResponse<LeaveMaster> response = new BaseEntityResponse<LeaveMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLeaveCode", SqlDbType.NVarChar, 5,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.LeaveCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLeaveDescription", SqlDbType.NVarChar, 20,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.LeaveDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCarryForwardForNextYear", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsCarryForwardForNextYear));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsEnCash", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsEnCash));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bAttendanceNeeded", SqlDbType.Bit, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.AttendanceNeeded));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDocumentsNeeded", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.DocumentsNeeded));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bHalfDayFlag", SqlDbType.Bit, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.HalfDayFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bLossOfPay", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.LossOfPay));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bNoCredit", SqlDbType.Bit, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.NoCredit));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bMinServiceRequire", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.MinServiceRequire));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bOnDuty", SqlDbType.Bit, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.OnDuty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsPostedOnce", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsPostedOnce));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLeaveType", SqlDbType.NVarChar, 15,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.LeaveType));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsNeedToInformAdvance", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.NeedToInformInAdvance));

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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveMaster_Update' reported the ErrorCode: " + _errorCode);
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
        /// Delete a specific record of LeaveMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveMaster> DeleteLeaveMaster(LeaveMaster item)
        {
            IBaseEntityResponse<LeaveMaster> response = new BaseEntityResponse<LeaveMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveMaster_Delete";
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveMaster_Delete' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from LeaveMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveMaster> GetBySearchList(LeaveMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<LeaveMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveMaster_SearchList";
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
                    baseEntityCollection.CollectionResponse = new List<LeaveMaster>();
                    while (sqlDataReader.Read())
                    {
                        LeaveMaster item = new LeaveMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["LeaveCode"]) == false)
                        {
                            item.LeaveCode = sqlDataReader["LeaveCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveDescription"]) == false)
                        {
                            item.LeaveDescription = sqlDataReader["LeaveDescription"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_LeaveMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
