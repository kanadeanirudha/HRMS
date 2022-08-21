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
    public class OrganisationMasterDataProvider : DBInteractionBase, IOrganisationMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OrganisationMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OrganisationMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from OrganisationMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationMaster> GetOrganisationMasterBySearch(OrganisationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //---------------- INPUT PARAMETER--------------------//
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    //---------------- OUTPUT PARAMETER--------------------//                    
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationMaster item = new OrganisationMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.EstablishmentCode = sqlDataReader["EstablishmentCode"].ToString();
                        item.OrgName = sqlDataReader["OrgName"].ToString();
                        item.FoundationDatetime = Convert.ToString(sqlDataReader["FoundationDatetime"]);
                        item.FounderMember = sqlDataReader["FounderMember"].ToString();
                        item.Address1 = sqlDataReader["Address1"].ToString();
                        item.Address2 = sqlDataReader["Address2"].ToString();
                        item.PlotNumber = sqlDataReader["PlotNumber"].ToString();
                        item.StreetNumber = sqlDataReader["StreetNumber"].ToString();
                        item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        item.Pincode = sqlDataReader["Pincode"].ToString();
                        item.EmailID = sqlDataReader["EmailID"].ToString();
                        item.Url = sqlDataReader["Url"].ToString();
                        item.OfficeComment = sqlDataReader["OfficeComment"].ToString();
                        item.MissionStatement = sqlDataReader["MissionStatement"].ToString();
                        item.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                        item.FaxNumber = sqlDataReader["FaxNumber"].ToString();
                        item.OfficePhone1 = sqlDataReader["OfficePhone1"].ToString();
                        item.TotalRecordsFound = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate =Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }
                        item.OfficePhone2 = sqlDataReader["OfficePhone2"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_OrganisationMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationMaster> GetOrganisationMasterGetBySearchList(OrganisationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationMaster_SearchList";
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationMaster item = new OrganisationMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);                       
                        item.OrgName = sqlDataReader["OrgName"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrganisationMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<OrganisationMaster> GetOrganisationMasterByID(OrganisationMaster item)
        {
            IBaseEntityResponse<OrganisationMaster> response = new BaseEntityResponse<OrganisationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationMaster_SelectOne";
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
                        OrganisationMaster _item = new OrganisationMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.EstablishmentCode = sqlDataReader["EstablishmentCode"].ToString();
                        _item.OrgName = sqlDataReader["OrgName"].ToString();
                        _item.FoundationDatetime = Convert.ToString(sqlDataReader["FoundationDatetime"]);
                        _item.FounderMember = sqlDataReader["FounderMember"].ToString();
                        _item.Address1 = sqlDataReader["Address1"].ToString();
                        _item.Address2 = sqlDataReader["Address2"].ToString();
                        _item.PlotNumber = sqlDataReader["PlotNumber"].ToString();
                        _item.StreetNumber = sqlDataReader["StreetNumber"].ToString();
                        _item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        _item.Pincode = sqlDataReader["Pincode"].ToString();
                        _item.EmailID = sqlDataReader["EmailID"].ToString();
                        _item.Url = sqlDataReader["Url"].ToString();
                        _item.OfficeComment = sqlDataReader["OfficeComment"].ToString();
                        _item.MissionStatement = sqlDataReader["MissionStatement"].ToString();
                        _item.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                        _item.FaxNumber = sqlDataReader["FaxNumber"].ToString();
                        _item.OfficePhone1 = sqlDataReader["OfficePhone1"].ToString();
                        _item.OfficePhone2 = sqlDataReader["OfficePhone2"].ToString();
                        _item.PFNumber = sqlDataReader["PFNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PFNumber"]);
                        _item.ESICNumber = sqlDataReader["ESICNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ESICNumber"]);
                        _item.OrgShortCode = sqlDataReader["OrgCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrgCode"]);
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
        public IBaseEntityResponse<OrganisationMaster> InsertOrganisationMaster(OrganisationMaster item)
        {
            IBaseEntityResponse<OrganisationMaster> response = new BaseEntityResponse<OrganisationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationMaster_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    if (item.EstablishmentCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEstablishmentCode", SqlDbType.NVarChar, 120,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EstablishmentCode.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEstablishmentCode", SqlDbType.NVarChar, 120,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOrgName", SqlDbType.NVarChar, 120,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OrgName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daFoundationDatetime", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.FoundationDatetime.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFounderMember", SqlDbType.NVarChar, 60,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FounderMember.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 120,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address1.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 120,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address2.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PlotNumber.Trim()));
                    if (item.StreetNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetNumber", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.StreetNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetNumber", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }


                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPincode", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Pincode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 60,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmailID.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sUrl", SqlDbType.VarChar, 60,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Url.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOfficeComment", SqlDbType.NVarChar, 4000,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OfficeComment.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMissionStatement", SqlDbType.NVarChar, 4000,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MissionStatement.Trim()));
                    if (item.MobileNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 32,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.MobileNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 32,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }


                    if (item.FaxNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFaxNumber", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FaxNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFaxNumber", SqlDbType.NVarChar, 30,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOfficePhone1", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OfficePhone1.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOfficePhone2", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OfficePhone2.Trim()));
                    if (item.PFNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPFNumber", SqlDbType.NVarChar, 35,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PFNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPFNumber", SqlDbType.NVarChar, 35,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ESICNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsESICNumber", SqlDbType.NVarChar, 35,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ESICNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsESICNumber", SqlDbType.NVarChar, 35,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.OrgShortCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOrgShortCode", SqlDbType.NVarChar, 35,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OrgShortCode.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOrgShortCode", SqlDbType.NVarChar, 35,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, DBNull.Value));
                    }
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
                        throw new Exception("Stored Procedure 'dbo.USP_OrganisationMaster_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of OrganisationMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationMaster> UpdateOrganisationMaster(OrganisationMaster item)
        {
            IBaseEntityResponse<OrganisationMaster> response = new BaseEntityResponse<OrganisationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsEstablishmentCode", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.EstablishmentCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsOrgName", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.OrgName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daFoundationDatetime", SqlDbType.DateTime, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.FoundationDatetime));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsFounderMember", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.FounderMember));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.Address1));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.Address2));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sPlotNumber", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.PlotNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sStreetNumber", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.StreetNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.LocationID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iPincode", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.Pincode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.EmailID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sUrl", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.Url));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsOfficeComment", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.OfficeComment));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsMissionStatement", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MissionStatement));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sMobileNumber", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MobileNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sFaxNumber", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.FaxNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficePhone1", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.OfficePhone1));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficePhone2", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.OfficePhone2));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ID));

                    if (item.EstablishmentCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEstablishmentCode", SqlDbType.NVarChar, 120,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EstablishmentCode.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEstablishmentCode", SqlDbType.NVarChar, 120,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOrgName", SqlDbType.NVarChar, 120,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OrgName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daFoundationDatetime", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.FoundationDatetime.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFounderMember", SqlDbType.NVarChar, 60,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FounderMember.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 120,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address1.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 120,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address2.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PlotNumber.Trim()));
                    if (item.StreetNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetNumber", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.StreetNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetNumber", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPincode", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.Pincode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 60,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmailID.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sUrl", SqlDbType.VarChar, 60,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Url.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOfficeComment", SqlDbType.NVarChar, 4000,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OfficeComment.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMissionStatement", SqlDbType.NVarChar, 4000,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MissionStatement.Trim()));

                    if (item.MobileNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 32,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.MobileNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 32,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }

                   
                    if (item.FaxNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFaxNumber", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FaxNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFaxNumber", SqlDbType.NVarChar, 30,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed,DBNull.Value));
                    }
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOfficePhone1", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OfficePhone1.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOfficePhone2", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OfficePhone2.Trim()));
                    if (item.PFNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPFNumber", SqlDbType.NVarChar, 35,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PFNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPFNumber", SqlDbType.NVarChar, 35,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ESICNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsESICNumber", SqlDbType.NVarChar, 35,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ESICNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsESICNumber", SqlDbType.NVarChar, 35,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.OrgShortCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOrgShortCode", SqlDbType.NVarChar, 35,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OrgShortCode.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOrgShortCode", SqlDbType.NVarChar, 35,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, DBNull.Value));
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

                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrganisationMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of OrganisationMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationMaster> DeleteOrganisationMaster(OrganisationMaster item)
        {
            IBaseEntityResponse<OrganisationMaster> response = new BaseEntityResponse<OrganisationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationMaster_Delete";
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
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrganisationMaster_Delete' reported the ErrorCode: " +
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
