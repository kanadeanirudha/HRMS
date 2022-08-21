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
    public class GeneralLocationMasterDataProvider : DBInteractionBase, IGeneralLocationMasterDataProvider
    {

       #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public GeneralLocationMasterDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public GeneralLocationMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        /// <summary>
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLocationMaster> GetGeneralLocationMasterBySearch(GeneralLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralLocationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralLocationMaster_SelectAll";
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

                    baseEntityCollection.CollectionResponse = new List<GeneralLocationMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralLocationMaster item = new GeneralLocationMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.LocationAddress = sqlDataReader["LocationAddress"].ToString();
                        item.PostCode = sqlDataReader["PostCode"].ToString();
                        item.Latitude = sqlDataReader["Latitude"].ToString();
                        item.Longitude = sqlDataReader["Longitude"].ToString();
                        item.CountryName = sqlDataReader["CountryName"].ToString();
                        item.RegionName = sqlDataReader["RegionName"].ToString();
                        item.Description = sqlDataReader["Description"].ToString();
                        item.CityID = Convert.ToInt32(sqlDataReader["CityID"].ToString());
                        item.RegionID = Convert.ToInt32(sqlDataReader["RegionID"].ToString());                        
                        item.DefaultFlag = Convert.ToBoolean(sqlDataReader["DefaultFlag"]);
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);    
                        }
                        item.IsUserDefined = Convert.ToBoolean(sqlDataReader["IsUserDefined"]);
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
                        throw new Exception("Stored Procedure 'USP_GeneralLocationMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLocationMaster> GetGeneralLocationMasterGetBySearchList(GeneralLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralLocationMaster>();
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

                    if (searchRequest.CityID > 0)
                    {

                        cmdToExecute.CommandText = "dbo.USP_GeneralLocationMaster_SearchListByCityID";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CityID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    }
                    else
                    {

                        cmdToExecute.CommandText = "dbo.USP_GeneralLocationMaster_SearchList";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
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

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<GeneralLocationMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralLocationMaster item = new GeneralLocationMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.LocationAddress = sqlDataReader["LocationAddress"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);

                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralLocationMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from General Region Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLocationMaster> GetGeneralLocationMasterByID(GeneralLocationMaster item)
        {
            IBaseEntityResponse<GeneralLocationMaster> response = new BaseEntityResponse<GeneralLocationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralLocationMaster_SelectOne";
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
                        GeneralLocationMaster _item = new GeneralLocationMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.LocationAddress = sqlDataReader["LocationAddress"].ToString();
                        _item.PostCode = sqlDataReader["PostCode"].ToString();
                        _item.Latitude = sqlDataReader["Latitude"].ToString();
                        _item.Longitude = sqlDataReader["Longitude"].ToString();
                        _item.CityID = Convert.ToInt32(sqlDataReader["CityID"].ToString());
                        _item.RegionID = Convert.ToInt32(sqlDataReader["RegionID"].ToString());
                        _item.CountryID = Convert.ToInt32(sqlDataReader["CountryID"].ToString());
                        _item.CountryName = sqlDataReader["CountryName"].ToString();
                        _item.RegionName = sqlDataReader["RegionName"].ToString();
                        _item.Description = sqlDataReader["Description"].ToString();
                        _item.DefaultFlag = Convert.ToBoolean(sqlDataReader["DefaultFlag"]);
                        _item.IsUserDefined = Convert.ToBoolean(sqlDataReader["IsUserDefined"]);
                       
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralLocationMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of General Region Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLocationMaster> InsertGeneralLocationMaster(GeneralLocationMaster item)
        {
            IBaseEntityResponse<GeneralLocationMaster> response = new BaseEntityResponse<GeneralLocationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralLocationMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLocationAddress", SqlDbType.NVarChar, 60,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.LocationAddress.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPostCode", SqlDbType.Char, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PostCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sLatitude", SqlDbType.VarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Latitude.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sLongitude", SqlDbType.VarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Longitude.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.RegionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDefaultFlag", SqlDbType.Bit, 25,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.DefaultFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output,true, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        throw new Exception("Stored Procedure 'USP_GeneralLocationMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of General Region Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLocationMaster> UpdateGeneralLocationMaster(GeneralLocationMaster item)
        {
            IBaseEntityResponse<GeneralLocationMaster> response = new BaseEntityResponse<GeneralLocationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralLocationMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLocationAddress", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.LocationAddress.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPostCode", SqlDbType.VarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.PostCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sLatitude", SqlDbType.VarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.Latitude.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sLongitude", SqlDbType.VarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.Longitude.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RegionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDefaultFlag", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DefaultFlag));                    
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralLocationMaster_Insert' reported the ErrorCode: " + _errorCode);
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

        /// <summary>
        /// Delete a selected record from General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLocationMaster> DeleteGeneralLocationMaster(GeneralLocationMaster item)
        {
            IBaseEntityResponse<GeneralLocationMaster> response = new BaseEntityResponse<GeneralLocationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralLocationMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1)); //1 for hard delete
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
                        throw new Exception("Stored Procedure 'USP_GeneralLocationMaster_Delete' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLocationMaster> GetGeneralLocationMasterGetByCityID(GeneralLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralLocationMaster>();
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

                    if (searchRequest.CityID > 0)
                    {

                        cmdToExecute.CommandText = "dbo.USP_GeneralLocationMaster_SearchListByCityID";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CityID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    }
                    else
                    {

                        cmdToExecute.CommandText = "dbo.USP_GeneralLocationMaster_SearchList";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
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

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<GeneralLocationMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralLocationMaster item = new GeneralLocationMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.LocationAddress = sqlDataReader["LocationAddress"].ToString();
                        item.PostCode = sqlDataReader["PostCode"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);

                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralLocationMaster_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<GeneralLocationMaster> GetByRegionIDAndCityID(GeneralLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralLocationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GenLocationMaster_SearchList";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CityID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 10, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.RegionID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iMaxResults", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.MaxResults));
                   
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

                    baseEntityCollection.CollectionResponse = new List<GeneralLocationMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralLocationMaster item = new GeneralLocationMaster();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationAddress"]) == false)
                        {
                            item.LocationAddress = sqlDataReader["LocationAddress"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PostCode"]) == false)
                        {
                            item.PostCode = sqlDataReader["PostCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Latitude"]) == false)
                        {
                            item.Latitude = sqlDataReader["Latitude"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Longitude"]) == false)
                        {
                            item.Longitude = sqlDataReader["Longitude"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_GeneralLocationMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<GeneralLocationMaster> GetBySearchKeyWord(GeneralLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralLocationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GenLocationMaster_ListBySearchKeyWord";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                       
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 10, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));                       
                        cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iMaxResults", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.MaxResults));
                   
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

                    baseEntityCollection.CollectionResponse = new List<GeneralLocationMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralLocationMaster item = new GeneralLocationMaster();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationAddress"]) == false)
                        {
                            item.LocationAddress = sqlDataReader["LocationAddress"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PostCode"]) == false)
                        {
                            item.PostCode = sqlDataReader["PostCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Latitude"]) == false)
                        {
                            item.Latitude = sqlDataReader["Latitude"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Longitude"]) == false)
                        {
                            item.Longitude = sqlDataReader["Longitude"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_GeneralLocationMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
