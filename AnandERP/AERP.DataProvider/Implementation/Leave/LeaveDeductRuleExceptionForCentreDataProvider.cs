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
    public class LeaveDeductRuleExceptionForCentreDataProvider : DBInteractionBase, ILeaveDeductRuleExceptionForCentreDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public LeaveDeductRuleExceptionForCentreDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public LeaveDeductRuleExceptionForCentreDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        
        /// Select all record from General Region Master table with search parameters.    
        public IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetLeaveDeductRuleExceptionForCentreBySearch(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveDeductRuleExceptionForCentre_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentrecode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));

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

                    baseEntityCollection.CollectionResponse = new List<LeaveDeductRuleExceptionForCentre>();
                    while (sqlDataReader.Read())
                    {
                        LeaveDeductRuleExceptionForCentre item = new LeaveDeductRuleExceptionForCentre();
                        if (DBNull.Value.Equals(sqlDataReader["LeaveMasterID"]) == false)
                        {
                            item.LeaveMasterID = Convert.ToInt32(sqlDataReader["LeaveMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveDescription"]) == false)
                        {
                            item.LeaveDescription = sqlDataReader["LeaveDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveCode"]) == false)
                        {
                            item.LeaveCode = sqlDataReader["LeaveCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PriorityLeaveMasterID"]) == false)
                        {
                            item.PriorityLeaveMasterID = Convert.ToInt32(sqlDataReader["PriorityLeaveMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PriorityLeaveDescription"]) == false)
                        {
                            item.PriorityLeaveDescription = sqlDataReader["PriorityLeaveDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LeaveDeductRuleID"]) == false)
                        {
                            item.LeaveDeductRuleID = Convert.ToInt32(sqlDataReader["LeaveDeductRuleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrioritySequenceNumber"]) == false)
                        {
                            item.PrioritySequenceNumber = Convert.ToInt16(sqlDataReader["PrioritySequenceNumber"]);
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
                        throw new Exception("Stored Procedure 'USP_LeaveDeductRuleExceptionForCentre_SelectAll' reported the ErrorCode: " + _errorCode);
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

       
        

        
        /// Select a record from General Region Master table by ID.       
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> GetLeaveDeductRuleExceptionForCentreByID(LeaveDeductRuleExceptionForCentre item)
        {
            IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> response = new BaseEntityResponse<LeaveDeductRuleExceptionForCentre>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveDeductRuleExceptionForCentre_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LeaveMasterID));
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

                        LeaveDeductRuleExceptionForCentre _item = new LeaveDeductRuleExceptionForCentre();
                        _item.LeaveMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.CountryName = sqlDataReader["CountryName"].ToString();
                        //_item.ContryCode = sqlDataReader["ContryCode"].ToString();
                        //_item.SeqNo = Convert.ToInt32(sqlDataReader["SeqNo"].ToString());
                        //_item.DefaultFlag = Convert.ToBoolean(sqlDataReader["DefaultFlag"].ToString());
                        //_item.IsUserDefined = Convert.ToBoolean(sqlDataReader["IsUserDefined"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveDeductRuleExceptionForCentre_SelectAll' reported the ErrorCode: " + _errorCode);
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

        
        /// Create new record of General Region Master     
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> InsertLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item)
        {
            IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> response = new BaseEntityResponse<LeaveDeductRuleExceptionForCentre>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveDeductRuleExceptionForCentre_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCountryName", SqlDbType.NVarChar, 60,
                    //                                             ParameterDirection.Input, false, 10, 0, "",
                    //                                             DataRowVersion.Proposed, item.CountryName.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sContryCode", SqlDbType.NVarChar, 5,
                    //                                             ParameterDirection.Input, false, 10, 0, "",
                    //                                             DataRowVersion.Proposed, item.ContryCode.Trim()));
                    ////cmdToExecute.Parameters.Add(new SqlParameter("@iSeqNo", SqlDbType.Int, 10,
                    ////                                             ParameterDirection.Input, false, 0, 0, "",
                    ////                                             DataRowVersion.Proposed, item.SeqNo));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bDefaultFlag", SqlDbType.Bit, 25,
                    //                                             ParameterDirection.Input, false, 0, 0, "",
                    //                                             DataRowVersion.Proposed, item.DefaultFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                                                 ParameterDirection.Input, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output,
                                                                 true, 10, 0, "", DataRowVersion.Proposed, item.LeaveMasterID));
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
                        item.LeaveMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    //response.Message.Add(new MessageDTO
                    //    //{
                    //    //    ErrorMessage = "Create failed"
                    //    //});
                    //    response.Entity = item;
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveDeductRuleExceptionForCentre_Insert' reported the ErrorCode: " +
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

       
        /// Update a specific record of General Region Master.        
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> UpdateLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item)
        {
            IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> response = new BaseEntityResponse<LeaveDeductRuleExceptionForCentre>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveDeductRuleExceptionForCentre_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LeaveMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCountryName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.CountryName.Trim()));
                    ////  cmdToExecute.Parameters.Add(new SqlParameter("@iSeqNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SeqNo));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sContryCode", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ContryCode.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bDefaultFlag", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DefaultFlag));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveDeductRuleExceptionForCentre_Insert' reported the ErrorCode: " + _errorCode);
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

        
        /// Delete a selected record from General Region Master.      
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> DeleteLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item)
        {
            IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> response = new BaseEntityResponse<LeaveDeductRuleExceptionForCentre>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveDeductRuleExceptionForCentre_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LeaveMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveDeductRuleExceptionForCentre_Delete' reported the ErrorCode: " + _errorCode);
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

        /// Select all record from General Region Master table with search parameters        
        public IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetLeaveDeductRuleExceptionForCentreGetBySearchList(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre>();
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
                    cmdToExecute.CommandText = "dbo.USP_LeaveDeductRuleExceptionForCentre_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<LeaveDeductRuleExceptionForCentre>();
                    while (sqlDataReader.Read())
                    {
                        LeaveDeductRuleExceptionForCentre item = new LeaveDeductRuleExceptionForCentre();
                        item.LeaveMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.CountryName = sqlDataReader["CountryName"].ToString();
                        //item.ContryCode = sqlDataReader["ContryCode"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_LeaveDeductRuleExceptionForCentre_SearchList' reported the ErrorCode: " + _errorCode);
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
