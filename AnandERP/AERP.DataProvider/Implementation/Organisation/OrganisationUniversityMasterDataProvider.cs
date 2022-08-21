using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace AMS.DataProvider 
{
    public class OrganisationUniversityMasterDataProvider : DBInteractionBase,IOrganisationUniversityMasterDataProvider 
    {
       #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OrganisationUniversityMasterDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OrganisationUniversityMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        /// <summary>
        /// Select all record from OrganisationUniversityMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetOrganisationUniversityMasterBySearch(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationUniversityMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationUniversityMaster_SelectAll";
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

                    baseEntityCollection.CollectionResponse = new List<OrganisationUniversityMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationUniversityMaster item = new OrganisationUniversityMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.UniversityName = sqlDataReader["UniversityName"].ToString();
                        item.EstablishmentCode = sqlDataReader["EstablishmentCode"].ToString();
                        item.UniversityFoundationDatetime = Convert.ToString(sqlDataReader["UniversityFoundationDatetime"]);
                        item.UniversityFounderMember = sqlDataReader["UniversityFounderMember"].ToString();
                        item.UniversityShortName = sqlDataReader["UniversityShortName"].ToString();  
                        item.UniversityAddress1 = sqlDataReader["UniversityAddress1"].ToString();                  
                        item.UniversityAddress2 = sqlDataReader["UniversityAddress2"].ToString();
                        //item.UniversityFoundationDatetime = Convert.ToString(sqlDataReader["UniversityFoundationDatetime"]);
                        item.UniversityFounderMember = sqlDataReader["UniversityFounderMember"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
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
                        throw new Exception("Stored Procedure 'USP_OrganisationUniversityMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationUniversityMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetOrganisationUniversityMasterGetBySearchList(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationUniversityMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationUniversityMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //---------------- INPUT PARAMETER--------------------//
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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

                    baseEntityCollection.CollectionResponse = new List<OrganisationUniversityMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationUniversityMaster item = new OrganisationUniversityMaster();
                        item.universityID = sqlDataReader["ID"].ToString();
                        item.UniversityName = sqlDataReader["UniversityName"].ToString();
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.StudyCentreUniversityApplicableID = Convert.ToInt32(sqlDataReader["StudyCentreUniversityApplicableID"]);
                        item.universityFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrganisationUniversityMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from OrganisationUniversityMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> GetOrganisationUniversityMasterByID(OrganisationUniversityMaster item)
        {
            IBaseEntityResponse<OrganisationUniversityMaster> response = new BaseEntityResponse<OrganisationUniversityMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgUniversityMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //---------------- INPUT PARAMETER--------------------//
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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

                    while (sqlDataReader.Read())
                    {
                     
                        OrganisationUniversityMaster _item = new OrganisationUniversityMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.UniversityName = sqlDataReader["UniversityName"].ToString();
                        _item.EstablishmentCode = sqlDataReader["EstablishmentCode"].ToString();
                        _item.UniversityFoundationDatetime = Convert.ToString(sqlDataReader["UniversityFoundationDatetime"]);
                        _item.UniversityFounderMember = sqlDataReader["UniversityFounderMember"].ToString();
                        _item.UniversityShortName = sqlDataReader["UniversityShortName"].ToString();
                        _item.UniversityAddress1 = sqlDataReader["UniversityAddress1"].ToString();
                        _item.UniversityAddress2 = sqlDataReader["UniversityAddress2"].ToString();                        
                        _item.PlotNumber = sqlDataReader["PlotNumber"].ToString();
                        _item.StreetNumber = sqlDataReader["StreetNumber"].ToString();
                        _item.CityID = Convert.ToInt32(sqlDataReader["CityID"]);
                        _item.Pincode = sqlDataReader["Pincode"].ToString();
                        _item.FaxNumber = sqlDataReader["FaxNumber"].ToString();
                        _item.PhoneNumberOffice = sqlDataReader["PhoneNumberOffice"].ToString();
                        _item.Extention = sqlDataReader["Extention"].ToString();
                        _item.CellPhone =(sqlDataReader["CellPhone"]).ToString();
                        _item.EmailID = sqlDataReader["EmailID"].ToString();
                        _item.Url =(sqlDataReader["Url"]).ToString();
                        _item.OfficeComment = sqlDataReader["OfficeComment"].ToString();
                        _item.MissionStatement = sqlDataReader["MissionStatement"].ToString();
                        _item.UniversityReportPath = sqlDataReader["UniversityReportPath"].ToString();
                        _item.DefaultFlag = Convert.ToBoolean(sqlDataReader["DefaultFlag"].ToString()); 

                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgUniversityMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of OrganisationUniversityMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> InsertOrganisationUniversityMaster(OrganisationUniversityMaster item)
        {
            IBaseEntityResponse<OrganisationUniversityMaster> response = new BaseEntityResponse<OrganisationUniversityMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgUniversityMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //---------------- INPUT PARAMETER--------------------//
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityName", SqlDbType.NVarChar, 60,
                                                                 ParameterDirection.Input, false, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.UniversityName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEstablishmentCode", SqlDbType.NVarChar, 60,
                                                                 ParameterDirection.Input, false, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.EstablishmentCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daUniversityFoundationDatetime", SqlDbType.DateTime, 10,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.UniversityFoundationDatetime.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityFounderMember", SqlDbType.NVarChar, 60,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.UniversityFounderMember.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityAddress1", SqlDbType.NVarChar, 60,
                                                                 ParameterDirection.Input, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.UniversityAddress1.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityAddress2", SqlDbType.NVarChar, 60,
                                                                 ParameterDirection.Input, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.UniversityAddress2.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 60,
                                                                ParameterDirection.Input, false, 10, 0, "",
                                                                DataRowVersion.Proposed, item.PlotNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetNumber", SqlDbType.NVarChar, 60,
                                                                 ParameterDirection.Input, false, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.StreetNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.CityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPincode", SqlDbType.NVarChar, 6,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.Pincode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFaxNumber", SqlDbType.NVarChar, 30,
                                                                 ParameterDirection.Input, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.FaxNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneNumberOffice", SqlDbType.NVarChar, 30,
                                                                 ParameterDirection.Input, false, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.PhoneNumberOffice.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsExtention", SqlDbType.NVarChar, 30,
                                                                 ParameterDirection.Input, false, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.Extention.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCellPhone", SqlDbType.NVarChar, 30,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.CellPhone.Trim()));
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
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityReportPath", SqlDbType.NVarChar, 100,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.UniversityReportPath.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityShortName", SqlDbType.NVarChar, 15,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.UniversityShortName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDefaultFlag", SqlDbType.Bit, 25,
                                                                 ParameterDirection.Input, false, 0, 0, "",
                                                                 DataRowVersion.Proposed, item.DefaultFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                                                 ParameterDirection.Input, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.CreatedBy));
                    //---------------- OUTPUT PARAMETER--------------------//
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
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgUniversityMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of OrganisationUniversityMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> UpdateOrganisationUniversityMaster(OrganisationUniversityMaster item)
        {
            IBaseEntityResponse<OrganisationUniversityMaster> response = new BaseEntityResponse<OrganisationUniversityMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgUniversityMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //---------------- INPUT PARAMETER--------------------//
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.UniversityName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEstablishmentCode", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EstablishmentCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daUniversityFoundationDatetime", SqlDbType.DateTime, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.UniversityFoundationDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityFounderMember", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.UniversityFounderMember.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityAddress1", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.UniversityAddress1.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityAddress2", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UniversityAddress2.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PlotNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StreetNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPincode", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.Pincode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFaxNumber", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FaxNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneNumberOffice", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PhoneNumberOffice.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsExtention", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Extention.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCellPhone", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CellPhone.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.EmailID.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sUrl", SqlDbType.VarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Url.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOfficeComment", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OfficeComment.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMissionStatement", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MissionStatement.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityShortName", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.UniversityShortName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityReportPath", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.UniversityReportPath.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDefaultFlag", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.DefaultFlag));
                    //---------------- OUTPUT PARAMETER--------------------//
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
                        throw new Exception("Stored Procedure 'USP_OrgUniversityMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Delete a selected record from OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> DeleteOrganisationUniversityMaster(OrganisationUniversityMaster item)
        {
            IBaseEntityResponse<OrganisationUniversityMaster> response = new BaseEntityResponse<OrganisationUniversityMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgUniversityMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,item.DeletedBy));
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
                        throw new Exception("Stored Procedure 'USP_OrgUniversityMaster_Delete' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetOrganisationUniversityMasterByCentreCode(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationUniversityMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgStudyCentreUniversityApplicable_SelectByCentreCode";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));
                    string[] CentreCode_current = searchRequest.CentreCode.Split(':');

                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, CentreCode_current[0]));

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

                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);


                    baseEntityCollection.CollectionResponse = new List<OrganisationUniversityMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationUniversityMaster item = new OrganisationUniversityMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["UniversityID"]);
                        item.UniversityName = sqlDataReader["UniversityName"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgStudyCentreUniversityApplicable_SelectByCentreCode' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationUniversityMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetOrganisationUniversityMasterGetBySearchListWithoutCenterCode(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationUniversityMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationUniversityMaster_SearchListWithoutCenterCode";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.sortBy));
                  //  cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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

                    baseEntityCollection.CollectionResponse = new List<OrganisationUniversityMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationUniversityMaster item = new OrganisationUniversityMaster();
                        item.universityID = sqlDataReader["ID"].ToString();
                        item.UniversityName = sqlDataReader["UniversityName"].ToString();
                        //item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //item.StudyCentreUniversityApplicableID = Convert.ToInt32(sqlDataReader["StudyCentreUniversityApplicableID"]);
                        //item.universityFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure USP_OrganisationUniversityMaster_SearchListWithoutCenterCode' reported the ErrorCode: " + _errorCode);
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
