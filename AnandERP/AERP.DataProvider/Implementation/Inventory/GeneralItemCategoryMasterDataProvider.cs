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
    public class GeneralItemCategoryMasterDataProvider : DBInteractionBase, IGeneralItemCategoryMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public GeneralItemCategoryMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public GeneralItemCategoryMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from GeneralItemCategoryMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetGeneralItemCategoryMasterBySearch(GeneralItemCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemCategoryMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemCategoryMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneraltemCategoryMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemCategoryMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemCategoryMaster item = new GeneralItemCategoryMaster();

                        item.ID = sqlDataReader["GeneralItemCategoryMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralItemCategoryMasterID"]);
                        item.ItemCategoryCode = sqlDataReader["ItemCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                        item.ItemCategoryDescription = sqlDataReader["ItemCategoryDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryDescription"]);
                       
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
                        throw new Exception("Stored Procedure 'USP_GeneralItemCategoryMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetGeneralItemCategoryMasterSearchList(GeneralItemCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemCategoryMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemCategoryMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemCategoryMaster_GetDropDownListForItemCategoryCode";
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
                    baseEntityCollection.CollectionResponse = new List<GeneralItemCategoryMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemCategoryMaster item = new GeneralItemCategoryMaster();
                        item.ID = Convert.ToInt16(sqlDataReader["GeneralItemCategoryMasterID"]);
                        item.ItemCategoryCode = sqlDataReader["ItemCategoryCode"].ToString();
                        item.ItemCategoryDescription = Convert.ToString(sqlDataReader["ItemCategoryDescription"]);
                       
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemCategoryMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<GeneralItemCategoryMaster> GetGeneralItemCategoryMasterByID(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> response = new BaseEntityResponse<GeneralItemCategoryMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemCategoryMaster_SelectOne";
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
                        GeneralItemCategoryMaster _item = new GeneralItemCategoryMaster();
                        //_item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        _item.ItemCategoryDescription = sqlDataReader["ItemCategoryDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryDescription"]);
                        _item.ItemCategoryCode = sqlDataReader["ItemCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                        _item.MerchandiseCategoryID = sqlDataReader["MerchantiseCategoryID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MerchantiseCategoryID"]);
                        _item.MerchandiseDepartmentID = sqlDataReader["MerchantiseDepartmentID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MerchantiseDepartmentID"]);
                        _item.MarchandiseGroupID = sqlDataReader["MarchandiseGroupID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MarchandiseGroupID"]);
                        _item.MarchandiseSubCategoryID = sqlDataReader["MarchandiseSubCategoryID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MarchandiseSubCategoryID"]);
                        _item.MarchandiseBaseCatgoryID = sqlDataReader["MarchandiseBaseCatgoryId"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MarchandiseBaseCatgoryId"]);

                        _item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                        _item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                        _item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                        _item.MerchantiseSubCategoryCode = sqlDataReader["MerchantiseSubCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseSubCategoryCode"]);
                        _item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                        _item.IsConsumable = sqlDataReader["IsConsumable"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsConsumable"]);
                        _item.IsMachine = sqlDataReader["IsMachine"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsMachine"]);
                        _item.IsToner = sqlDataReader["IsToner"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsToner"]);

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
        public IBaseEntityResponse<GeneralItemCategoryMaster> InsertGeneralItemCategoryMaster(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> response = new BaseEntityResponse<GeneralItemCategoryMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneraltemCategoryMaster_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCategoryDescription", SqlDbType.NVarChar, 200,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ItemCategoryDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCategoryCode", SqlDbType.NVarChar, 20,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ItemCategoryCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMarchandiseGroupID", SqlDbType.SmallInt, 4,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.MarchandiseGroupID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMerchandiseDepartmentID", SqlDbType.SmallInt, 4,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.MerchandiseDepartmentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMerchantdiseCategoryID", SqlDbType.SmallInt, 4,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.MerchandiseCategoryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMarchandiseSubCategoryID", SqlDbType.SmallInt, 4,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.MarchandiseSubCategoryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMarchandiseBaseCatgoryID", SqlDbType.SmallInt, 4,
                                         ParameterDirection.Input, false, 10, 0, "",
                                         DataRowVersion.Proposed, item.MarchandiseBaseCatgoryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneraltemCategoryMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsConsumable", SqlDbType.Bit, 1,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.IsConsumable));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsMachine", SqlDbType.Bit, 1,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.IsMachine));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsToner", SqlDbType.Bit, 1,
                                      ParameterDirection.Input, false, 10, 0, "",
                                      DataRowVersion.Proposed, item.IsToner));

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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_GeneralItemCategoryMaster_INSERT' reported the ErrorCode: " +
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
                        throw new Exception("Stored Procedure 'USP_GeneralItemCategoryMaster_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of GeneralItemCategoryMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemCategoryMaster> UpdateGeneralItemCategoryMaster(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> response = new BaseEntityResponse<GeneralItemCategoryMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemCatgoryMaster_EditBMC";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCategoryDescription", SqlDbType.NVarChar, 200,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ItemCategoryDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCategoryCode", SqlDbType.NVarChar, 20,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ItemCategoryCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsConsumable", SqlDbType.Bit, 1,
                                       ParameterDirection.Input, true, 0, 0, "",
                                       DataRowVersion.Proposed, item.IsConsumable));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsMachine", SqlDbType.Bit, 1,
                                       ParameterDirection.Input, false, 0, 0, "",
                                       DataRowVersion.Proposed, item.IsMachine));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsToner", SqlDbType.Bit, 1,
                                       ParameterDirection.Input, false, 0, 0, "",
                                       DataRowVersion.Proposed, item.IsToner));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siMarchandiseGroupID", SqlDbType.SmallInt, 4,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MarchandiseGroupID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siMerchantiseDepartmentID", SqlDbType.SmallInt, 4,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MerchandiseDepartmentID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siMerchantiseCategoryID", SqlDbType.SmallInt, 4,
                    //                  ParameterDirection.Input, false, 10, 0, "",
                    //                  DataRowVersion.Proposed, item.MerchandiseCategoryID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siMarchandiseSubCategoryID", SqlDbType.SmallInt, 4,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MarchandiseSubCategoryID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siMarchandiseBaseCatgoryId", SqlDbType.SmallInt, 4,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MarchandiseBaseCatgoryID));
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
                   // item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_GeneralItemCategoryMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of GeneralItemCategoryMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemCategoryMaster> DeleteGeneralItemCategoryMaster(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> response = new BaseEntityResponse<GeneralItemCategoryMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemCategoryMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
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
                        throw new Exception("Stored Procedure 'USP_GeneralItemCategoryMaster_Delete' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<GeneralItemCategoryMaster> InsertGeneralItemCategoryMasterExcel(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> response = new BaseEntityResponse<GeneralItemCategoryMaster>();
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
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_ BaseMerchandiseCategoryUploadExcel_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    
                    if (item.XMLstring != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xBaseMerchandiseCategoryXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,item.XMLstring));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xBaseMerchandiseCategoryXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.errorMessage));
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
                    item.errorMessage = (string)cmdToExecute.Parameters["@sErrorMessage"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry && _errorCode != 18 && _errorCode != 19 && _errorCode != 20 && _errorCode != 21 && _errorCode != 22 && _errorCode != 23)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_ BaseMerchandiseCategoryUploadExcel_InsertXML' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<GeneralItemCategoryMaster> GetGeneralItemByCategoryCode(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> response = new BaseEntityResponse<GeneralItemCategoryMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemmaster_GetGeneralItemByCategoryCode";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCategoryCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemCategoryCode));
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
                        GeneralItemCategoryMaster _item = new GeneralItemCategoryMaster();
                        // _item.ID = Convert.ToInt16(sqlDataReader["GenSupplierMasterID"]);
                        //_item.MerchandiseCategory = sqlDataReader["CategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CategoryCode"]);
                        _item.IsConsumable = sqlDataReader["IsConsumable"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsConsumable"]);
                        _item.IsMachine = sqlDataReader["IsMachine"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsMachine"]);
                        _item.IsToner = sqlDataReader["IsToner"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsToner"]);
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
        public IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetGeneralItemCategoryMasterGetBySearchList(GeneralItemCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemCategoryMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralItemCategoryMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemCategoryMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<GeneralItemCategoryMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralItemCategoryMaster item = new GeneralItemCategoryMaster();
                        item.ID = sqlDataReader["ID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ID"]);
                        item.ItemCategoryCode = sqlDataReader["ItemCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                        item.CCRMContractTypeDetailsID = sqlDataReader["CCRMContractTypeDetailsID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["CCRMContractTypeDetailsID"]);
                        item.StatusFlag = sqlDataReader["StatusFlag"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StatusFlag"]);
                        item.IsActive = sqlDataReader["IsActive"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsActive"]);
                        //item.ItemCategoryDescription = sqlDataReader["ItemCategoryDescription"].ToString();
                     


                      

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemCategoryMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
