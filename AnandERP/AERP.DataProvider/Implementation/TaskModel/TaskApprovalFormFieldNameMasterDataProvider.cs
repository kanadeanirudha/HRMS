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
    public class TaskApprovalFormFieldNameMasterDataProvider : DBInteractionBase, ITaskApprovalFormFieldNameMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public TaskApprovalFormFieldNameMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public TaskApprovalFormFieldNameMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from TaskApprovalFormFieldNameMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetTaskApprovalFormFieldNameMasterBySearch(TaskApprovalFormFieldNameMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_TaskApprovalFormFieldNameDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    //   cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));

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
                    baseEntityCollection.CollectionResponse = new List<TaskApprovalFormFieldNameMaster>();
                    while (sqlDataReader.Read())
                    {
                        TaskApprovalFormFieldNameMaster item = new TaskApprovalFormFieldNameMaster();

                        item.TaskApprovalFormFieldNameDetailsID = sqlDataReader["TaskApprovalFormFieldNameDetailsID"] is DBNull ? new short() : Convert.ToInt32(sqlDataReader["TaskApprovalFormFieldNameDetailsID"]);
                        item.TaskApprovalFormFieldMasterId = sqlDataReader["TaskApprovalFormFieldMasterId"] is DBNull ? new short() : Convert.ToInt32(sqlDataReader["TaskApprovalFormFieldNameDetailsID"]);
                        item.LableName = sqlDataReader["LableName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LableName"]);
                        item.SequenceNumber = sqlDataReader["SequenceNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["SequenceNumber"]);
                        item.ColumnNumber = sqlDataReader["ColumnNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ColumnNumber"]);
                        item.FieldName = sqlDataReader["FieldName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FieldName"]);
                        //For Task Approval Form Field Master
                        item.FormName = sqlDataReader["FormName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FormName"]);
                        item.TaskCode = sqlDataReader["TaskCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaskCode"]);
                        item.ViewName = sqlDataReader["ViewName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ViewName"]);
                        item.InsertUpdateProcedure = sqlDataReader["InsertUpdateProcedure"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["InsertUpdateProcedure"]);
                        //item.LocationAddress = sqlDataReader["LocationAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationAddress"]);
                        //item.CityId = sqlDataReader["CityId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CityId"]);
                        //item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : sqlDataReader["CentreCode"].ToString();
                        //item.DepartmentID = sqlDataReader["DepartmentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        //item.UnitType = sqlDataReader["UnitType"] is DBNull ? string.Empty : sqlDataReader["UnitType"].ToString();
                        //item.Relatedwith = sqlDataReader["RelatedWith"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["RelatedWith"]);
                        //if (item.Relatedwith == 1)
                        ////{
                        //    item.RelatedwithUnitType = "Manufacturing";
                        //}
                        //else if (item.Relatedwith == 2)
                        //{
                        //    item.RelatedwithUnitType = "Sales";
                        //}
                        //else if (item.Relatedwith == 3)
                        //{
                        //    item.RelatedwithUnitType = "Purchase";
                        //}
                        //else if (item.Relatedwith == 4)
                        //{
                        //    item.RelatedwithUnitType = "Warehouse";
                        //}
                        //else if (item.Relatedwith == 5)
                        //{
                        //    item.RelatedwithUnitType = "Processing";
                        //}
                        //item.CityName = sqlDataReader["CityName"] is DBNull ? string.Empty : sqlDataReader["CityName"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_TaskApprovalFormFieldNameMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetTaskApprovalFormFieldNameMasterSearchList(TaskApprovalFormFieldNameMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_TaskApprovalFormFieldNameMaster_GetListForDropDown";
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
                    baseEntityCollection.CollectionResponse = new List<TaskApprovalFormFieldNameMaster>();
                    while (sqlDataReader.Read())
                    {
                        TaskApprovalFormFieldNameMaster item = new TaskApprovalFormFieldNameMaster();
                        item.TaskApprovalFormFieldNameDetailsID = Convert.ToInt32(sqlDataReader["TaskApprovalFormFieldNameDetailsID"]);
                        item.TaskApprovalFormFieldMasterId = Convert.ToInt32(sqlDataReader["TaskApprovalFormFieldMasterId"]);
                        item.LableName = Convert.ToString(sqlDataReader["LableName"]);
                        item.SequenceNumber = Convert.ToInt16(sqlDataReader["SequenceNumber"]);
                        item.ColumnNumber = Convert.ToInt16(sqlDataReader["ColumnNumber"]);
                        item.FieldName = Convert.ToString(sqlDataReader["FieldName"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_TaskApprovalFormFieldNameMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> GetTaskApprovalFormFieldNameMasterByID(TaskApprovalFormFieldNameMaster item)
        {
            IBaseEntityResponse<TaskApprovalFormFieldNameMaster> response = new BaseEntityResponse<TaskApprovalFormFieldNameMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_TaskApprovalFormFieldNameMaster_SelectOne";
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
                        TaskApprovalFormFieldNameMaster _item = new TaskApprovalFormFieldNameMaster();
                        // item.TaskApprovalFormFieldNameDetailsID = Convert.ToInt16(sqlDataReader["TaskApprovalFormFieldNameDetailsID"]);
                        //_item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        //_item.GeneralUnitTypeID = sqlDataReader["GeneralUnitTypeID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralUnitTypeID"].ToString());
                        //_item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        //_item.DepartmentID = sqlDataReader["DepartmentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        //_item.LocationAddress = sqlDataReader["LocationAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationAddress"]);
                        //_item.CityId = sqlDataReader["CityId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CityId"]);
                        //_item.UnitType = sqlDataReader["UnitType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitType"]);
                        //_item.Relatedwith = sqlDataReader["RelatedWith"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["RelatedWith"]);
                        //if (_item.Relatedwith == 1)
                        //{
                        //    _item.RelatedwithUnitType = "Manufacturing";
                        //}
                        //else if (_item.Relatedwith == 2)
                        //{
                        //    _item.RelatedwithUnitType = "Sales";
                        //}
                        //else if (_item.Relatedwith == 3)
                        //{
                        //    _item.RelatedwithUnitType = "Purchase";
                        //}
                        //else if (_item.Relatedwith == 4)
                        //{
                        //    _item.RelatedwithUnitType = "Warehouse";
                        //}
                        //else if (_item.Relatedwith == 5)
                        //{
                        //    _item.RelatedwithUnitType = "Processing";
                        //}
                        //_item.CentreName = sqlDataReader["CentreName"].ToString();
                        //_item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        //_item.CityName = sqlDataReader["CityName"].ToString();
                        //response.Entity = _item;
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
        public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> InsertTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item)
        {
            IBaseEntityResponse<TaskApprovalFormFieldNameMaster> response = new BaseEntityResponse<TaskApprovalFormFieldNameMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_TaskApprovalFormFieldNameDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@xTaskApprovalFormFieldNameDetailsXml", SqlDbType.Xml, 0,
                                                                               ParameterDirection.Input, false, 10, 0, "",
                                                                               DataRowVersion.Proposed, item.XMLstring));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iTaskApprovalFormFieldMasterId", SqlDbType.Int, 4,
                    //                                                       ParameterDirection.Input, false, 10, 0, "",
                    //                                     DataRowVersion.Proposed, item.TaskApprovalFormFieldMasterId));
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iTaskApprovalFormFieldNameMasterID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_TaskApprovalFormFieldNameMaster_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_TaskApprovalFormFieldNameMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of TaskApprovalFormFieldNameMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> UpdateTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item)
        {
            IBaseEntityResponse<TaskApprovalFormFieldNameMaster> response = new BaseEntityResponse<TaskApprovalFormFieldNameMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_TaskApprovalFormFieldNameMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterName", SqlDbType.NVarChar, 60,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterCode", SqlDbType.NVarChar,20,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterCode));

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
                    // item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_TaskApprovalFormFieldNameMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of TaskApprovalFormFieldNameMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
    public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> DeleteTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item)
    {
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> response = new BaseEntityResponse<TaskApprovalFormFieldNameMaster>();
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
                cmdToExecute.CommandText = "dbo.USP_TaskApprovalFormFieldNameDetails_Delete";
                cmdToExecute.CommandType = CommandType.StoredProcedure;
                cmdToExecute.Parameters.Add(new SqlParameter("@iTaskApprovalFormFieldNameDetailsID", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.TaskApprovalFormFieldNameDetailsID));
                cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, 1));
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
                    throw new Exception("Stored Procedure 'USP_TaskApprovalFormFieldNameMaster_Delete' reported the ErrorCode: " + _errorCode);
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
