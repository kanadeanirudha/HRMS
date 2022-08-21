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
    public class EmployeeContactDetailsDataProvider : DBInteractionBase, IEmployeeContactDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeeContactDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeeContactDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EmployeeContactDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeContactDetails> GetEmployeeContactDetailsBySearch(EmployeeContactDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeContactDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeContactDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeContactDetails_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<EmployeeContactDetails>();
                    while (sqlDataReader.Read())
                    {

                        EmployeeContactDetails item = new EmployeeContactDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AddressType"]) == false)
                        {
                            item.AddressType = sqlDataReader["AddressType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeAddress1"]) == false)
                        {
                            item.EmployeeAddress1 = sqlDataReader["EmployeeAddress1"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeAddress2"]) == false)
                        {
                            item.EmployeeAddress2 = sqlDataReader["EmployeeAddress2"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PlotNumber"]) == false)
                        {
                            item.PlotNumber = sqlDataReader["PlotNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StreetName"]) == false)
                        {
                            item.StreetName = sqlDataReader["StreetName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CityID"]) == false)
                        {
                            item.CityID = Convert.ToInt32(sqlDataReader["CityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CityName"]) == false)
                        {
                            item.CityName = sqlDataReader["CityName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Pincode"]) == false)
                        {
                            item.Pincode = sqlDataReader["Pincode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TelephoneNumber"]) == false)
                        {
                            item.TelephoneNumber = sqlDataReader["TelephoneNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MobileNumber"]) == false)
                        {
                            item.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentAddressFlag"]) == false)
                        {
                            item.CurrentAddressFlag = Convert.ToBoolean(sqlDataReader["CurrentAddressFlag"]);
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
                        throw new Exception("Stored Procedure 'USP_EmployeeContactDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from EmployeeContactDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeContactDetails> GetEmployeeContactDetailsByID(EmployeeContactDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeContactDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeContactDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeContactDetailsByID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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
                    baseEntityCollection.CollectionResponse = new List<EmployeeContactDetails>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeContactDetails item = new EmployeeContactDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["CanRead"]) == false)
                        //{
                        //    item.CanRead = sqlDataReader["CanRead"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CanWrite"]) == false)
                        //{
                        //    item.CanWrite = sqlDataReader["CanWrite"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CanSpeak"]) == false)
                        //{
                        //    item.CanSpeak = sqlDataReader["CanSpeak"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["LanguageID"]) == false)
                        //{
                        //    item.LanguageID = Convert.ToInt32(sqlDataReader["LanguageID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["LanguageName"]) == false)
                        //{
                        //    item.LanguageName = sqlDataReader["LanguageName"].ToString();
                        //}

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
                        throw new Exception("Stored Procedure 'USP_EmployeeContactDetailsByID' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeContactDetails> GetEmployeeContactDetailsByID(EmployeeContactDetails item)
        {
            IBaseEntityResponse<EmployeeContactDetails> response = new BaseEntityResponse<EmployeeContactDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeContactDetails_SelectOne";
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
                        EmployeeContactDetails _item = new EmployeeContactDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AddressType"]) == false)
                        {
                            _item.AddressType = sqlDataReader["AddressType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeAddress1"]) == false)
                        {
                            _item.EmployeeAddress1 = sqlDataReader["EmployeeAddress1"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeAddress2"]) == false)
                        {
                            _item.EmployeeAddress2 = sqlDataReader["EmployeeAddress2"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PlotNumber"]) == false)
                        {
                            _item.PlotNumber = sqlDataReader["PlotNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StreetName"]) == false)
                        {
                            _item.StreetName = sqlDataReader["StreetName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CountryID"]) == false)
                        {
                            _item.CountryID = Convert.ToInt32(sqlDataReader["CountryID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RegionID"]) == false)
                        {
                            _item.RegionID = Convert.ToInt32(sqlDataReader["RegionID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CityID"]) == false)
                        {
                            _item.CityID = Convert.ToInt32(sqlDataReader["CityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            _item.ContactLocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Pincode"]) == false)
                        {
                            _item.Pincode = sqlDataReader["Pincode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TelephoneNumber"]) == false)
                        {
                            _item.TelephoneNumber = sqlDataReader["TelephoneNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MobileNumber"]) == false)
                        {
                            _item.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentAddressFlag"]) == false)
                        {
                            _item.CurrentAddressFlag = Convert.ToBoolean(sqlDataReader["CurrentAddressFlag"]);
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
        public IBaseEntityResponse<EmployeeContactDetails> InsertEmployeeContactDetails(EmployeeContactDetails item)
        {
            IBaseEntityResponse<EmployeeContactDetails> response = new BaseEntityResponse<EmployeeContactDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeContactDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if (item.EmployeeID == 0 || item.EmployeeID == null)
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
                    if (item.AddressType == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddressType", SqlDbType.NVarChar, 20,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddressType", SqlDbType.NVarChar, 20,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, item.AddressType));
                    }
                    if (item.EmployeeAddress1 == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeAddress1", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeAddress1", SqlDbType.NVarChar, 255,
                                                    ParameterDirection.Input, false, 0, 0, "",
                                                    DataRowVersion.Proposed, item.EmployeeAddress1));
                    }
                    if (item.EmployeeAddress2 == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeAddress2", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeAddress2", SqlDbType.NVarChar, 255,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, item.EmployeeAddress2));
                    }
                    if (item.PlotNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPlotNumber", SqlDbType.VarChar, 20,
                                                 ParameterDirection.Input, false, 0, 0, "",
                                                 DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPlotNumber", SqlDbType.VarChar, 20,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.PlotNumber));
                    }
                    if (item.StreetName == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStreetName", SqlDbType.VarChar, 50,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStreetName", SqlDbType.VarChar, 50,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.StreetName));
                    }
                    if (item.CountryID == 0 || item.CountryID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.CountryID));
                    }
                    if (item.RegionID == 0 || item.RegionID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.RegionID));
                    }
                    if (item.CityID == 0 || item.CityID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, item.CityID));
                    }
                    if (item.ContactLocationID == 0 || item.ContactLocationID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.ContactLocationID));
                    }
                    if (item.Pincode == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPincode", SqlDbType.VarChar, 20,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPincode", SqlDbType.VarChar, 20,
                                                  ParameterDirection.Input, false, 0, 0, "",
                                                  DataRowVersion.Proposed, item.Pincode));
                    }
                    if (item.TelephoneNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sTelephoneNumber", SqlDbType.VarChar, 30,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sTelephoneNumber", SqlDbType.VarChar, 30,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.TelephoneNumber));
                    }
                    if (item.MobileNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sMobileNumber", SqlDbType.VarChar, 30,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sMobileNumber", SqlDbType.VarChar, 30,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.MobileNumber));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bCurrentAddressFlag", SqlDbType.Bit, 1,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, true));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, true));
                    if (item.CreatedBy == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                                 ParameterDirection.Input, true, 10, 0, "",
                                                 DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, item.CreatedBy));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeContactDetails_InsertXML' reported the ErrorCode: " +
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
        /// Update a specific record of EmployeeContactDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeContactDetails> UpdateEmployeeContactDetails(EmployeeContactDetails item)
        {
            IBaseEntityResponse<EmployeeContactDetails> response = new BaseEntityResponse<EmployeeContactDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeContactDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
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
                    if (item.AddressType == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddressType", SqlDbType.NVarChar, 20,
                                         ParameterDirection.Input, false, 10, 0, "",
                                         DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddressType", SqlDbType.NVarChar, 20,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.AddressType));
                    }
                    if (item.EmployeeAddress1 == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeAddress1", SqlDbType.NVarChar, 255,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeAddress1", SqlDbType.NVarChar, 255,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeAddress1));
                    }
                    if (item.EmployeeAddress2 == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeAddress2", SqlDbType.NVarChar, 255,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeAddress2", SqlDbType.NVarChar, 255,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.EmployeeAddress2));
                    }
                    if (item.PlotNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPlotNumber", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPlotNumber", SqlDbType.VarChar, 20,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, item.PlotNumber));
                    }
                    if (item.StreetName == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStreetName", SqlDbType.VarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStreetName", SqlDbType.VarChar, 50,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.StreetName));
                    }
                    if (item.CountryID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.CountryID));
                    }
                    if (item.RegionID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, item.RegionID));
                    }
                    if (item.CityID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, item.CityID));
                    }
                    if (item.ContactLocationID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 10,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 10,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, item.ContactLocationID));
                    }
                    if (item.Pincode == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPincode", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPincode", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Pincode));
                    }
                    if (item.TelephoneNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sTelephoneNumber", SqlDbType.VarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sTelephoneNumber", SqlDbType.VarChar, 30,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.TelephoneNumber));
                    }
                    if (item.MobileNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sMobileNumber", SqlDbType.VarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sMobileNumber", SqlDbType.VarChar, 30,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.MobileNumber));
                    }
                    if (item.CurrentAddressFlag == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bCurrentAddressFlag", SqlDbType.Bit, 1,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bCurrentAddressFlag", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CurrentAddressFlag));
                    }
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeContactDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of EmployeeContactDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeContactDetails> DeleteEmployeeContactDetails(EmployeeContactDetails item)
        {
            IBaseEntityResponse<EmployeeContactDetails> response = new BaseEntityResponse<EmployeeContactDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeContactDetails_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeContactDetails_Delete' reported the ErrorCode: " +
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
