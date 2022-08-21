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
   public class CCRMContractTypesMasterDataProvider :DBInteractionBase, ICCRMContractTypesMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        public CCRMContractTypesMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public CCRMContractTypesMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        public IBaseEntityCollectionResponse<CCRMContractTypesMaster> GetCCRMContractTypesMasterBySearch(CCRMContractTypesMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMContractTypesMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMContractTypesMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractTypeMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<CCRMContractTypesMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMContractTypesMaster item = new CCRMContractTypesMaster();

                        item.ID = sqlDataReader["ID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["ID"]);
                        item.ContractCode = sqlDataReader["ContractCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractCode"]);
                        item.ContractName = sqlDataReader["ContractName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractName"]);
                        item.ContractType = sqlDataReader["ContractType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContractType"]);
                        //item.IsSpares = sqlDataReader["IsSpares"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsSpares"]);
                        //item.IsConsumables = sqlDataReader["IsConsumables"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsConsumables"]);
                        //item.ISService = sqlDataReader["ISService"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["ISService"]);
                        //item.IsRentMachine = sqlDataReader["IsRentMachine"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsRentMachine"]);
                        //item.CCRMContractTypeDetailsID = sqlDataReader["CCRMContractTypeDetailsID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["CCRMContractTypeDetailsID"]);
                        //item.ItemCategoryMasterID = sqlDataReader["ItemCategoryMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["ItemCategoryMasterID"]);
                        //item.ItemCategoryCode = sqlDataReader["ItemCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                      



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
                        throw new Exception("Stored Procedure 'USP_CCRMContractTypeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMContractTypesMaster> GetCCRMContractTypesMasterByID(CCRMContractTypesMaster item)
        {
            IBaseEntityResponse<CCRMContractTypesMaster> response = new BaseEntityResponse<CCRMContractTypesMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractTypeMaster_SelectOne";
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
                        CCRMContractTypesMaster _item = new CCRMContractTypesMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.ContractCode = sqlDataReader["ContractCode"].ToString();
                        _item.ContractName = sqlDataReader["ContractName"].ToString();
                        _item.ContractType = Convert.ToByte(sqlDataReader["ContractType"]);
                        _item.IsSpares = Convert.ToBoolean(sqlDataReader["IsSpares"]);
                        _item.IsConsumables = Convert.ToBoolean(sqlDataReader["IsConsumables"]);
                        _item.ISService = Convert.ToBoolean(sqlDataReader["ISService"]);
                        _item.IsRentMachine = Convert.ToBoolean(sqlDataReader["IsRentMachine"]);
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
        public IBaseEntityResponse<CCRMContractTypesMaster> InsertCCRMContractTypesMaster(CCRMContractTypesMaster item)
        {
            IBaseEntityResponse<CCRMContractTypesMaster> response = new BaseEntityResponse<CCRMContractTypesMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractTypeMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMContractTypeMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractCode", SqlDbType.NVarChar, 50,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, item.ContractCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractName", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ContractName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiContractType", SqlDbType.TinyInt, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ContractType));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsSpares", SqlDbType.Bit, 1,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, item.IsSpares));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsConsumables", SqlDbType.Bit, 1,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.IsConsumables));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bISService", SqlDbType.Bit, 1,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.ISService));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsRentMachine", SqlDbType.Bit, 1,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.IsRentMachine));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectedCategoryMasterIDs", SqlDbType.Xml, 0,
                    //                                           ParameterDirection.Input, false, 10, 0, "",
                    //                                           DataRowVersion.Proposed, item.SelectedCategoryMasterIDs));


                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

                    if (item.SelectedCategoryMasterIDs != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectedCategoryMasterIDs", SqlDbType.Xml, 0,
                                                              ParameterDirection.Input, false, 10, 0, "",
                                                              DataRowVersion.Proposed, item.SelectedCategoryMasterIDs));
                    }
                    else
                    {

                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectedCategoryMasterIDs", SqlDbType.Xml, 0,
                                                              ParameterDirection.Input, false, 10, 0, "",
                                                              DataRowVersion.Proposed, DBNull.Value));

                    }

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
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iCCRMContractTypesMasterID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;


                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMContractTypeMaster_Insert' reported the ErrorCode: " +
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
        public IBaseEntityResponse<CCRMContractTypesMaster> InsertCCRMContractTypeDetails(CCRMContractTypesMaster item)
        {
            IBaseEntityResponse<CCRMContractTypesMaster> response = new BaseEntityResponse<CCRMContractTypesMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractTypeDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMContractTypesMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMContractTypeDetailsID", SqlDbType.Int, 4,
                                           ParameterDirection.Output, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CCRMContractTypeDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemCategoryMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ItemCategoryMasterID));

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
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iCCRMContractTypesMasterID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;


                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMContractTypesMaster_Insert' reported the ErrorCode: " +
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
        public IBaseEntityResponse<CCRMContractTypesMaster> UpdateCCRMContractTypesMaster(CCRMContractTypesMaster item)
        {
            IBaseEntityResponse<CCRMContractTypesMaster> response = new BaseEntityResponse<CCRMContractTypesMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractTypeMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractCode", SqlDbType.NVarChar, 50,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ContractCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractName", SqlDbType.NVarChar, 100,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ContractName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiContractType", SqlDbType.TinyInt, 4,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ContractType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsSpares", SqlDbType.Bit, 1,
                                       ParameterDirection.Input, false, 0, 0, "",
                                       DataRowVersion.Proposed, item.IsSpares));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsConsumables", SqlDbType.Bit, 1,
                                     ParameterDirection.Input, false, 0, 0, "",
                                     DataRowVersion.Proposed, item.IsConsumables));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bISService", SqlDbType.Bit, 1,
                                     ParameterDirection.Input, false, 0, 0, "",
                                     DataRowVersion.Proposed, item.ISService));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsRentMachine", SqlDbType.Bit, 1,
                                    ParameterDirection.Input, false, 0, 0, "",
                                    DataRowVersion.Proposed, item.IsRentMachine));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectedCategoryMasterIDs", SqlDbType.Xml, 0,
                    //                                          ParameterDirection.Input, false, 10, 0, "",
                    //                                         DataRowVersion.Proposed, item.SelectedCategoryMasterIDs));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
                    if (item.SelectedCategoryMasterIDs != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectedCategoryMasterIDs", SqlDbType.Xml, 0,
                                                              ParameterDirection.Input, false, 10, 0, "",
                                                              DataRowVersion.Proposed, item.SelectedCategoryMasterIDs));
                    }
                    else
                    {

                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectedCategoryMasterIDs", SqlDbType.Xml, 0,
                                                              ParameterDirection.Input, false, 10, 0, "",
                                                              DataRowVersion.Proposed, DBNull.Value));

                    }

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
                        throw new Exception("Stored Procedure 'dbo.USP_CCRMContractTypeMaster_Delete' reported the ErrorCode: " +
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
        public IBaseEntityResponse<CCRMContractTypesMaster> DeleteCCRMContractTypesMaster(CCRMContractTypesMaster item)
        {
            IBaseEntityResponse<CCRMContractTypesMaster> response = new BaseEntityResponse<CCRMContractTypesMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractTypeMaster_Delete";
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
                        throw new Exception("Stored Procedure 'USP_CCRMContractTypeMaster_Delete' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMContractTypesMaster> GetCCRMContractTypesMasterList(CCRMContractTypesMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMContractTypesMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMContractTypesMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractTypeMaster_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<CCRMContractTypesMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMContractTypesMaster item = new CCRMContractTypesMaster();
                        item.ContractTypeId = Convert.ToInt32(sqlDataReader["ContractTypeId"]);
                       // item.ContractCode = sqlDataReader["ContractCode"].ToString();
                        item.ContractCode = sqlDataReader["ContractCode"].ToString();
                        //item.ContractType = Convert.ToByte(sqlDataReader["ContractType"]);
                        //item.IsSpares=Convert.ToBoolean(sqlDataReader["IsSpares"]);
                        //item.IsConsumables = Convert.ToBoolean(sqlDataReader["IsConsumables"]);
                        //item.ISService = Convert.ToBoolean(sqlDataReader["ISService"]);
                        //item.IsRentMachine = Convert.ToBoolean(sqlDataReader["IsRentMachine"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMContractTypeMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
