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
    public class LeaveRuleMasterDataProvider : DBInteractionBase, ILeaveRuleMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public LeaveRuleMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public LeaveRuleMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from LeaveRuleMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveRuleMaster> GetLeaveRuleMasterBySearch(LeaveRuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveRuleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<LeaveRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveRuleMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
                    baseEntityCollection.CollectionResponse = new List<LeaveRuleMaster>();
                    while (sqlDataReader.Read())
                    {
                        LeaveRuleMaster item = new LeaveRuleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveMasterID"]) == false)
                        {
                            item.LeaveMasterID = Convert.ToInt32(sqlDataReader["LeaveMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveDescription"]) == false)
                        {
                            item.LeaveDescription = (sqlDataReader["LeaveDescription"].ToString()).Trim();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveRuleDescription"]) == false)
                        {
                            item.LeaveRuleDescription = (sqlDataReader["LeaveRuleDescription"].ToString()).Trim();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfLeaves"]) == false)
                        {
                            item.NumberOfLeaves = Convert.ToInt16(sqlDataReader["NumberOfLeaves"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaxLeaveAtTime"]) == false)
                        {
                            item.MaxLeaveAtTime = Convert.ToInt16(sqlDataReader["MaxLeaveAtTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MinimumLeaveEncash"]) == false)
                        {
                            item.MinimumLeaveEncash = Convert.ToInt32(sqlDataReader["MinimumLeaveEncash"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaxLeaveEncash"]) == false)
                        {
                            item.MaxLeaveEncash = Convert.ToInt32(sqlDataReader["MaxLeaveEncash"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaxLeaveAccumulated"]) == false)
                        {
                            item.MaxLeaveAccumulated = Convert.ToInt32(sqlDataReader["MaxLeaveAccumulated"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MinServiceRequiredInMonth"]) == false)
                        {
                            item.MinServiceRequiredInMonth = Convert.ToInt32(sqlDataReader["MinServiceRequiredInMonth"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AttendDaysRequired"]) == false)
                        {
                            item.AttendDaysRequired = Convert.ToInt32(sqlDataReader["AttendDaysRequired"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreditDependOn"]) == false)
                        {
                            item.CreditDependOn = sqlDataReader["CreditDependOn"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DayOfTheMonth"]) == false)
                        {
                            item.DayOfTheMonth = Convert.ToInt32(sqlDataReader["DayOfTheMonth"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLocked"]) == false)
                        {
                            item.IsLocked = Convert.ToBoolean(sqlDataReader["IsLocked"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MinLeavesAtTime"]) == false)
                        {
                            item.MinLeavesAtTime = Convert.ToDouble(sqlDataReader["MinLeavesAtTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLeaveAccumulatePeriodically"]) == false)
                        {
                            item.IsLeaveAccumulatePeriodically = Convert.ToBoolean(sqlDataReader["IsLeaveAccumulatePeriodically"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfMonths"]) == false)
                        {
                            item.NumberOfMonths = Convert.ToInt16(sqlDataReader["NumberOfMonths"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfAccumulatedLeaves"]) == false)
                        {
                            item.NumberOfAccumulatedLeaves = Convert.ToInt16(sqlDataReader["NumberOfAccumulatedLeaves"]);
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
                        throw new Exception("Stored Procedure 'USP_LeaveRuleMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<LeaveRuleMaster> GetLeaveRuleMasterByID(LeaveRuleMaster item)
        {
            IBaseEntityResponse<LeaveRuleMaster> response = new BaseEntityResponse<LeaveRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveRuleMaster_SelectOne";
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
                        LeaveRuleMaster _item = new LeaveRuleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveMasterID"]) == false)
                        {
                            _item.LeaveMasterID = Convert.ToInt32(sqlDataReader["LeaveMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveRuleDescription"]) == false)
                        {
                            _item.LeaveRuleDescription = sqlDataReader["LeaveRuleDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfLeaves"]) == false)
                        {
                            _item.NumberOfLeaves = Convert.ToInt16(sqlDataReader["NumberOfLeaves"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaxLeaveAtTime"]) == false)
                        {
                            _item.MaxLeaveAtTime = Convert.ToInt16(sqlDataReader["MaxLeaveAtTime"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["MinimumLeaveEncash"]) == false)
                        //{
                        //    _item.MinimumLeaveEncash = Convert.ToInt32(sqlDataReader["MinimumLeaveEncash"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["MaxLeaveEncash"]) == false)
                        {
                            _item.MaxLeaveEncash = Convert.ToInt32(sqlDataReader["MaxLeaveEncash"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaxLeaveAccumulated"]) == false)
                        {
                            _item.MaxLeaveAccumulated = Convert.ToInt32(sqlDataReader["MaxLeaveAccumulated"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MinServiceRequiredInMonth"]) == false)
                        {
                            _item.MinServiceRequiredInMonth = Convert.ToInt32(sqlDataReader["MinServiceRequiredInMonth"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["AttendDaysRequired"]) == false)
                        //{
                        //    _item.AttendDaysRequired = Convert.ToInt32(sqlDataReader["AttendDaysRequired"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CreditDependOn"]) == false)
                        //{
                        //    _item.CreditDependOn = sqlDataReader["CreditDependOn"].ToString();
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["DayOfTheMonth"]) == false)
                        {
                            _item.DayOfTheMonth = Convert.ToInt32(sqlDataReader["DayOfTheMonth"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLocked"]) == false)
                        {
                            _item.IsLocked = Convert.ToBoolean(sqlDataReader["IsLocked"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MinLeavesAtTime"]) == false)
                        {
                            _item.MinLeavesAtTime = Convert.ToDouble(sqlDataReader["MinLeavesAtTime"]);
                        }
                        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DaysBeforeApplicationSubmitted"]) == false)
                        {
                            _item.DaysBeforeApplicationSubmitted = Convert.ToInt16(sqlDataReader["DaysBeforeApplicationSubmitted"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveApplicationSubmittedUptoDays"]) == false)
                        {
                            _item.LeaveApplicationSubmittedUptoDays = Convert.ToInt16(sqlDataReader["LeaveApplicationSubmittedUptoDays"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["IsLeaveAccumulatePeriodically"]) == false)
                        //{
                        //    _item.IsLeaveAccumulatePeriodically = Convert.ToBoolean(sqlDataReader["IsLeaveAccumulatePeriodically"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["AccumulationMethod"]) == false)
                        {
                            _item.AccumulationMethod = Convert.ToInt16(sqlDataReader["AccumulationMethod"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveMonthRatio"]) == false)
                        {
                            _item.LeaveMonthRatio = Convert.ToDecimal(sqlDataReader["LeaveMonthRatio"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveEncashFormula"]) == false)
                        {
                            _item.LeaveEncashFormula = Convert.ToString(sqlDataReader["LeaveEncashFormula"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfMonths"]) == false)
                        {
                            _item.NumberOfMonths = Convert.ToInt16(sqlDataReader["NumberOfMonths"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfAccumulatedLeaves"]) == false)
                        {
                            _item.NumberOfAccumulatedLeaves = Convert.ToInt16(sqlDataReader["NumberOfAccumulatedLeaves"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaxDaysUpto"]) == false)
                        {
                            _item.DaysAfterApplicationSubmitted = Convert.ToInt16(sqlDataReader["MaxDaysUpto"]);
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
                        throw new Exception("Stored Procedure 'USP_LeaveRuleMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<LeaveRuleMaster> InsertLeaveRuleMaster(LeaveRuleMaster item)
        {
            IBaseEntityResponse<LeaveRuleMaster> response = new BaseEntityResponse<LeaveRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveRuleMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Output, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveMasterID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.LeaveMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLeaveRuleDescription", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.LeaveRuleDescription.Trim() != null ? item.LeaveRuleDescription.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siNumberOfLeaves", SqlDbType.SmallInt, 5,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.NumberOfLeaves));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMaxLeaveAtTime", SqlDbType.SmallInt, 5,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MaxLeaveAtTime));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iMinimumLeaveEncash", SqlDbType.Int, 10,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.MinimumLeaveEncash));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMaxLeaveEncash", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MaxLeaveEncash));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMaxLeaveAccumulated", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MaxLeaveAccumulated));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMinServiceRequiredInMonth", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MinServiceRequiredInMonth));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAttendDaysRequired", SqlDbType.Int, 10,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.AttendDaysRequired));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sCreditDependOn", SqlDbType.VarChar, 15,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.CreditDependOn != null ? item.CreditDependOn.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDayOfTheMonth", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.DayOfTheMonth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiDaysBeforeApplicationSubmitted", SqlDbType.TinyInt, 3,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.DaysBeforeApplicationSubmitted));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiLeaveApplicationSubmittedUptoDays", SqlDbType.TinyInt, 3,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.LeaveApplicationSubmittedUptoDays));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fMinLeaveAtTime", SqlDbType.Float, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MinLeavesAtTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CentreCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLeaveEncashFormula", SqlDbType.NVarChar, 150,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.LeaveEncashFormula != null ? item.LeaveEncashFormula.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiAccumulationMethod", SqlDbType.TinyInt, 3,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.AccumulationMethod));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLeaveMonthRatio", SqlDbType.Decimal, 5,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.LeaveMonthRatio));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsLeaveAccumulatePeriodically", SqlDbType.Bit, 0,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.IsLeaveAccumulatePeriodically));

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiNumberOfMonths", SqlDbType.TinyInt, 3,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.NumberOfMonths));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siNumberOfAccumulatedLeaves", SqlDbType.SmallInt, 5,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.NumberOfAccumulatedLeaves));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMaxDaysUpto", SqlDbType.TinyInt, 3,
                                         ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, item.DaysAfterApplicationSubmitted));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CreatedBy));
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
                        throw new Exception("Stored Procedure 'dbo.USP_LeaveRuleMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of LeaveRuleMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleMaster> UpdateLeaveRuleMaster(LeaveRuleMaster item)
        {
            IBaseEntityResponse<LeaveRuleMaster> response = new BaseEntityResponse<LeaveRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveRuleMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveMasterID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.LeaveMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLeaveRuleDescription", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.LeaveRuleDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siNumberOfLeaves", SqlDbType.SmallInt, 5,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.NumberOfLeaves));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMaxLeaveAtTime", SqlDbType.SmallInt, 5,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.MaxLeaveAtTime));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iMinimumLeaveEncash", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.MinimumLeaveEncash));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMaxLeaveEncash", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.MaxLeaveEncash));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMaxLeaveAccumulated", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.MaxLeaveAccumulated));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMinServiceRequiredInMonth", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.MinServiceRequiredInMonth));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAttendDaysRequired", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.AttendDaysRequired));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sCreditDependOn", SqlDbType.VarChar, 15,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.CreditDependOn != null ? item.CreditDependOn.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDayOfTheMonth", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.DayOfTheMonth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiDaysBeforeApplicationSubmitted", SqlDbType.TinyInt, 3,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.DaysBeforeApplicationSubmitted));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiLeaveApplicationSubmittedUptoDays", SqlDbType.TinyInt, 3,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.LeaveApplicationSubmittedUptoDays));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fMinLeaveAtTime", SqlDbType.Float, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.MinLeavesAtTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.CentreCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsLeaveAccumulatePeriodically", SqlDbType.Bit, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.IsLeaveAccumulatePeriodically));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLeaveEncashFormula", SqlDbType.NVarChar, 150,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.LeaveEncashFormula != null ? item.LeaveEncashFormula.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiAccumulationMethod", SqlDbType.TinyInt, 3,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.AccumulationMethod));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLeaveMonthRatio", SqlDbType.Decimal, 5,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.LeaveMonthRatio));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiNumberOfMonths", SqlDbType.TinyInt, 3,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.NumberOfMonths));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siNumberOfAccumulatedLeaves", SqlDbType.SmallInt, 5,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.NumberOfAccumulatedLeaves));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMaxDaysUpto", SqlDbType.TinyInt, 3,
                                      ParameterDirection.Input, false, 0, 0, "",
                                      DataRowVersion.Proposed, item.DaysAfterApplicationSubmitted));
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
                        throw new Exception("Stored Procedure 'dbo.USP_LeaveRuleMaster_Update' reported the ErrorCode: " +
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
        /// Delete a specific record of LeaveRuleMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleMaster> DeleteLeaveRuleMaster(LeaveRuleMaster item)
        {
            IBaseEntityResponse<LeaveRuleMaster> response = new BaseEntityResponse<LeaveRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveRuleMaster_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_LeaveRuleMaster_Delete' reported the ErrorCode: " +
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
        /// Select all record from LeaveRuleMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveRuleMaster> GetLeaveRuleMasterByLeaveCode(LeaveRuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveRuleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<LeaveRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveRuleMasterByLeaveCode";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLeaveCode", SqlDbType.NVarChar, 5, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LeaveCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
                    baseEntityCollection.CollectionResponse = new List<LeaveRuleMaster>();
                    while (sqlDataReader.Read())
                    {
                        LeaveRuleMaster item = new LeaveRuleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveRuleDescription"]) == false)
                        {
                            item.LeaveRuleDescription = (sqlDataReader["LeaveRuleDescription"].ToString()).Trim();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveMasterID"]) == false)
                        {
                            item.LeaveMasterID = Convert.ToInt32(sqlDataReader["LeaveMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveCode"]) == false)
                        {
                            item.LeaveCode = (sqlDataReader["LeaveCode"].ToString()).Trim();
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
                        throw new Exception("Stored Procedure 'USP_LeaveRuleMasterByLeaveCode' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<LeaveRuleMaster> GetLeaveDetails(LeaveRuleMaster item)
        {
            IBaseEntityResponse<LeaveRuleMaster> response = new BaseEntityResponse<LeaveRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveDetails_ByEmployee_LeaveMaster_LeaveSessionID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LeaveMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLeaveSessionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LeaveSessionID));
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
                        LeaveRuleMaster _item = new LeaveRuleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["LeaveRuleMasterID"]) == false)
                        {
                            _item.ID = Convert.ToInt16(sqlDataReader["LeaveRuleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfLeaves"]) == false)
                        {
                            _item.NumberOfLeaves = Convert.ToInt16(sqlDataReader["NumberOfLeaves"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaxLeaveAtTime"]) == false)
                        {
                            _item.MaxLeaveAtTime = Convert.ToInt16(sqlDataReader["MaxLeaveAtTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BalanceLeave"]) == false)
                        {
                            _item.BalanceLeave = Convert.ToDouble(sqlDataReader["BalanceLeave"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCompensatory"]) == false)
                        {
                            _item.IsCompensatory = Convert.ToDouble(sqlDataReader["IsCompensatory"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DocumentCompulsaryFlag"]) == false)
                        {
                            _item.DocumentCompulsaryFlag = Convert.ToBoolean(sqlDataReader["DocumentCompulsaryFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DocumentRequiredFlag"]) == false)
                        {
                            _item.DocumentRequiredFlag = Convert.ToBoolean(sqlDataReader["DocumentRequiredFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DocumentRequiredID"]) == false)
                        {
                            _item.DocumentRequiredID = Convert.ToInt32(sqlDataReader["DocumentRequiredID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DaysBeforeApplicationSubmitted"]) == false)
                        {
                            _item.DaysBeforeApplicationSubmitted = Convert.ToInt16(sqlDataReader["DaysBeforeApplicationSubmitted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveApplicationSubmittedUptoDays"]) == false)
                        {
                            _item.LeaveApplicationSubmittedUptoDays = Convert.ToInt16(sqlDataReader["LeaveApplicationSubmittedUptoDays"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SpanFromDayDiffecrence"]) == false)
                        {
                            _item.LeaveAttendanceSpanFromDayDiffecrence = Convert.ToInt16(sqlDataReader["SpanFromDayDiffecrence"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PermitedDaysAfterLeaveCan"]) == false)
                        {
                            _item.PermitedDaysAfterLeaveCan = Convert.ToInt16(sqlDataReader["PermitedDaysAfterLeaveCan"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaxDaysUpto"]) == false)
                        {
                            _item.MaxDaysUpto = Convert.ToInt16(sqlDataReader["MaxDaysUpto"]);
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
                        throw new Exception("Stored Procedure 'USP_LeaveDetails_ByEmployee_LeaveMaster_LeaveSessionID' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<LeaveRuleMaster> LeaveRuleStatusGetByCentreAndEmployee(LeaveRuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveRuleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<LeaveRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveRuleMasterStatusBy_EmployeeID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
                    baseEntityCollection.CollectionResponse = new List<LeaveRuleMaster>();
                    while (sqlDataReader.Read())
                    {
                        LeaveRuleMaster item = new LeaveRuleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveRuleDescription"]) == false)
                        {
                            item.LeaveRuleDescription = (sqlDataReader["LeaveRuleDescription"].ToString()).Trim();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveMasterID"]) == false)
                        {
                            item.LeaveMasterID = Convert.ToInt32(sqlDataReader["LeaveMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveCode"]) == false)
                        {
                            item.LeaveCode = (sqlDataReader["LeaveCode"].ToString()).Trim();
                        }

                        item.LeaveStatus = Convert.ToBoolean(sqlDataReader["LeaveStatus"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveRuleMasterByLeaveCode' reported the ErrorCode: " + _errorCode);
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
