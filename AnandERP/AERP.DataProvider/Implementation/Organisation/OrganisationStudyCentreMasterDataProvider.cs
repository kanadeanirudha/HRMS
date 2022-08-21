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
    public class OrganisationStudyCentreMasterDataProvider : DBInteractionBase, IOrganisationStudyCentreMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OrganisationStudyCentreMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OrganisationStudyCentreMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        #region Method Implementation
        /// <summary>
        /// Select all record from OrganisationStudyCentreMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreMasterBySearch(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationStudyCentreMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgStudyCentreMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationStudyCentreMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationStudyCentreMaster item = new OrganisationStudyCentreMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.CentreName = sqlDataReader["CentreName"].ToString();
                        item.HoCoRoScFlag = sqlDataReader["HoCoRoScFlag"].ToString();
                        item.HoID = Convert.ToInt32(sqlDataReader["HoID"]);
                        item.CoID = Convert.ToInt32(sqlDataReader["CoID"]);
                        item.RoID = Convert.ToInt32(sqlDataReader["RoID"]);
                        item.CentreSpecialization = sqlDataReader["CentreSpecialization"].ToString();
                        item.CentreAddress = sqlDataReader["CentreAddress"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["PlotNo"]) == false)
                        {
                            item.PlotNo = sqlDataReader["PlotNo"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StreetName"]) == false)
                        {
                            item.StreetName = sqlDataReader["StreetName"].ToString();
                        }
                        item.CityID = Convert.ToInt32(sqlDataReader["CityID"]);
                        item.Pincode = sqlDataReader["Pincode"].ToString();
                        item.EmailID = sqlDataReader["EmailID"].ToString();
                        item.Url = sqlDataReader["Url"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["CellPhone"]) == false)
                        {
                            item.CellPhone = sqlDataReader["CellPhone"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FaxNumber"]) == false)
                        {
                            item.FaxNumber = sqlDataReader["FaxNumber"].ToString();
                        }
                        item.PhoneNumberOffice = sqlDataReader["PhoneNumberOffice"].ToString();
                        item.CentreEstablishmentDatetime = Convert.ToString(sqlDataReader["CentreEstablishmentDatetime"]);
                        item.OrganisationID = Convert.ToInt32(sqlDataReader["OrganisationID"]);
                        //item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"]);
                        if (DBNull.Value.Equals(sqlDataReader["CentreLoginNumber"]) == false)
                        {
                            item.CentreLoginNumber = Convert.ToInt32(sqlDataReader["CentreLoginNumber"]);
                        }

                        item.InstituteCode = sqlDataReader["InstituteCode"].ToString();
                        //if (DBNull.Value.Equals(sqlDataReader["TimeZone"]) == false)
                        //{
                        //    item.TimeZone = sqlDataReader["TimeZone"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["Latitude"]) == false)
                        //{
                        //    item.Latitude = Convert.ToDecimal(sqlDataReader["Latitude"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["Longitude"]) == false)
                        //{
                        //    item.Longitude = Convert.ToDecimal(sqlDataReader["Longitude "]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CampusArea"]) == false)
                        //{
                        //    item.CampusArea = Convert.ToDecimal(sqlDataReader["CampusArea"]);
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
                        throw new Exception("Stored Procedure 'USP_OrgStudyCentreMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationStudyCentreMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreMasterGetListHORO(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationStudyCentreMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgStudyCentreMasterConditionalList";
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationStudyCentreMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationStudyCentreMaster item = new OrganisationStudyCentreMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.CentreName = sqlDataReader["CentreName"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgStudyCentreMasterConditionalList' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationStudyCentreMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreListBySearch(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationStudyCentreMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationStudyCentreList";
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationStudyCentreMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationStudyCentreMaster item = new OrganisationStudyCentreMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.CentreName = sqlDataReader["CentreName"].ToString();
                        //item.HoCoRoScFlag = sqlDataReader["HoCoRoScFlag"].ToString();
                        //item.HoID = Convert.ToInt32(sqlDataReader["HoID"]);
                        //item.CoID = Convert.ToInt32(sqlDataReader["CoID"]);
                        //item.RoID = Convert.ToInt32(sqlDataReader["RoID"]);
                        //item.CentreSpecialization = sqlDataReader["CentreSpecialization"].ToString();
                        //item.CentreAddress = sqlDataReader["CentreAddress"].ToString();
                        //item.PlotNo = sqlDataReader["PlotNo"].ToString();
                        //item.StreetName = sqlDataReader["StreetName"].ToString();
                        //item.CityID = Convert.ToInt32(sqlDataReader["CityID"]);
                        //item.Pincode = sqlDataReader["Pincode"].ToString();
                        //item.EmailID = sqlDataReader["EmailID"].ToString();
                        //item.Url = sqlDataReader["Url"].ToString();
                        //item.CellPhone = sqlDataReader["CellPhone"].ToString();
                        //item.FaxNumber = sqlDataReader["FaxNumber"].ToString();
                        //item.PhoneNumberOffice = sqlDataReader["PhoneNumberOffice"].ToString();
                        //item.CentreEstablishmentDatetime = Convert.ToDateTime(sqlDataReader["CentreEstablishmentDatetime"]);
                        //item.OrganisationID = Convert.ToInt32(sqlDataReader["OrganisationID"]);
                        // item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"]);
                        //item.CentreLoginNumber = Convert.ToInt32(sqlDataReader["CentreLoginNumber"]);
                        //item.InstituteCode = sqlDataReader["InstituteCode"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrganisationStudyCentreList' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationStudyCentreMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetStudyCentreDetailsForReports(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationStudyCentreMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralStudyCentreMaster_ReportSearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalanceSheetMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationStudyCentreMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationStudyCentreMaster item = new OrganisationStudyCentreMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine1"]) == false)
                        {
                            item.PrintingLine1 = sqlDataReader["PrintingLine1"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine2"]) == false)
                        {
                            item.PrintingLine2 = Convert.ToString(sqlDataReader["PrintingLine2"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine3"]) == false)
                        {
                            item.PrintingLine3 = Convert.ToString(sqlDataReader["PrintingLine3"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine4"]) == false)
                        {
                            item.PrintingLine4 = Convert.ToString(sqlDataReader["PrintingLine4"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["Logo"]) == false)
                        {
                            item.Logo = (byte[])(sqlDataReader["Logo"]);
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
                        throw new Exception("Stored Procedure 'USP_OrganisationStudyCentreList' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OrganisationStudyCentreMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetStudyCentreListRoleWise(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationStudyCentreMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_AdminRoleApplicableCentre";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.RoleId));
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
                    baseEntityCollection.CollectionResponse = new List<OrganisationStudyCentreMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationStudyCentreMaster item = new OrganisationStudyCentreMaster();
                        item.ScopeIdentity = Convert.ToString(sqlDataReader["ScopeIdentity"]);
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.CentreName = sqlDataReader["CentreName"].ToString();
                        //item.HoCoRoScFlag = sqlDataReader["HoCoRoScFlag"].ToString();
                        //item.HoID = Convert.ToInt32(sqlDataReader["HoID"]);
                        //item.CoID = Convert.ToInt32(sqlDataReader["CoID"]);
                        //item.RoID = Convert.ToInt32(sqlDataReader["RoID"]);
                        //item.CentreSpecialization = sqlDataReader["CentreSpecialization"].ToString();
                        //item.CentreAddress = sqlDataReader["CentreAddress"].ToString();
                        //item.PlotNo = sqlDataReader["PlotNo"].ToString();
                        //item.StreetName = sqlDataReader["StreetName"].ToString();
                        //item.CityID = Convert.ToInt32(sqlDataReader["CityID"]);
                        //item.Pincode = sqlDataReader["Pincode"].ToString();
                        //item.EmailID = sqlDataReader["EmailID"].ToString();
                        //item.Url = sqlDataReader["Url"].ToString();
                        //item.CellPhone = sqlDataReader["CellPhone"].ToString();
                        //item.FaxNumber = sqlDataReader["FaxNumber"].ToString();
                        //item.PhoneNumberOffice = sqlDataReader["PhoneNumberOffice"].ToString();
                        //item.CentreEstablishmentDatetime = Convert.ToDateTime(sqlDataReader["CentreEstablishmentDatetime"]);
                        //item.OrganisationID = Convert.ToInt32(sqlDataReader["OrganisationID"]);
                        // item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"]);
                        //item.CentreLoginNumber = Convert.ToInt32(sqlDataReader["CentreLoginNumber"]);
                        //item.InstituteCode = sqlDataReader["InstituteCode"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrganisationStudyCentreList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreMasterByID(OrganisationStudyCentreMaster item)
        {
            IBaseEntityResponse<OrganisationStudyCentreMaster> response = new BaseEntityResponse<OrganisationStudyCentreMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgStudyCentreMaster_SelectOne";
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
                        OrganisationStudyCentreMaster _item = new OrganisationStudyCentreMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        _item.CentreName = sqlDataReader["CentreName"].ToString();
                        _item.HoCoRoScFlag = sqlDataReader["HoCoRoScFlag"].ToString();
                        _item.HoID = Convert.ToInt32(sqlDataReader["HoID"]);
                        _item.CoID = Convert.ToInt32(sqlDataReader["CoID"]);
                        _item.RoID = Convert.ToInt32(sqlDataReader["RoID"]);
                        _item.CentreSpecialization = sqlDataReader["CentreSpecialization"].ToString();
                        _item.CentreAddress = sqlDataReader["CentreAddress"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["PlotNo"]) == false)
                        {
                            _item.PlotNo = sqlDataReader["PlotNo"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StreetName"]) == false)
                        {
                            _item.StreetName = sqlDataReader["StreetName"].ToString();
                        }
                        _item.CityID = Convert.ToInt32(sqlDataReader["CityID"]);
                        if (DBNull.Value.Equals(sqlDataReader["Pincode"]) == false)
                        {
                            _item.Pincode = sqlDataReader["Pincode"].ToString();
                        }
                        _item.EmailID = sqlDataReader["EmailID"].ToString();
                        _item.Url = sqlDataReader["Url"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["CellPhone"]) == false)
                        {
                            _item.CellPhone = sqlDataReader["CellPhone"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FaxNumber"]) == false)
                        {
                            _item.FaxNumber = sqlDataReader["FaxNumber"].ToString();
                        }
                        _item.PhoneNumberOffice = sqlDataReader["PhoneNumberOffice"].ToString();
                        _item.CentreEstablishmentDatetime = Convert.ToString(sqlDataReader["CentreEstablishmentDatetime"]);
                        _item.OrganisationID = Convert.ToInt32(sqlDataReader["OrganisationID"]);
                        // _item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"]);
                        if (DBNull.Value.Equals(sqlDataReader["CentreLoginNumber"]) == false)
                        {
                            _item.CentreLoginNumber = Convert.ToInt32(sqlDataReader["CentreLoginNumber"]);
                        }
                        _item.InstituteCode = sqlDataReader["InstituteCode"].ToString();
                        _item.TimeZone = sqlDataReader["Timezone"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["Longitude"]) == false)
                        {
                            _item.Longitude = Convert.ToDecimal(sqlDataReader["Longitude"]);
                        }
                       // _item.Longitude = Convert.ToDecimal(sqlDataReader["Longitude"]);
                        //_item.Latitude = Convert.ToDecimal(sqlDataReader["Latitude"]);
                        //_item.CampusArea = Convert.ToDecimal(sqlDataReader["CampusArea"]);
                        //if (DBNull.Value.Equals(sqlDataReader["TimeZone"]) == false)
                        //{
                        //    item.TimeZone = sqlDataReader["TimeZone"].ToString();
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["Latitude"]) == false)
                        {
                            _item.Latitude = Convert.ToDecimal(sqlDataReader["Latitude"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Longitude"]) == false)
                        {
                            _item.Longitude = Convert.ToDecimal(sqlDataReader["Longitude"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CampusArea"]) == false)
                        {
                            _item.CampusArea = Convert.ToDecimal(sqlDataReader["CampusArea"]);
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



        public IBaseEntityResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreMasterHOROCount(OrganisationStudyCentreMaster item)
        {
            IBaseEntityResponse<OrganisationStudyCentreMaster> response = new BaseEntityResponse<OrganisationStudyCentreMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgStudyCentreMaster_HoCount";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        OrganisationStudyCentreMaster _item = new OrganisationStudyCentreMaster();
                        _item.HoCount = Convert.ToInt32(sqlDataReader["HoCount"]);
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
        public IBaseEntityResponse<OrganisationStudyCentreMaster> InsertOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item)
        {
            IBaseEntityResponse<OrganisationStudyCentreMaster> response = new BaseEntityResponse<OrganisationStudyCentreMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgStudyCentreMaster_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sHoCoRoScFlag", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.HoCoRoScFlag.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iHoID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.HoID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCoID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CoID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRoID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RoID));
                    if (item.CentreSpecialization != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreSpecialization", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreSpecialization.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreSpecialization", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreAddress.Trim()));
                    if (item.PlotNo != "0" && item.PlotNo != "" && item.PlotNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNo", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PlotNo.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNo", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StreetName != null && item.StreetName != "" && item.StreetName != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetName", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StreetName.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetName", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPincode", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Pincode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailID.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sUrl", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Url));
                    if (item.CellPhone != "0" && item.CellPhone != "" && item.CellPhone != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCellPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CellPhone.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCellPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FaxNumber != "0" && item.FaxNumber != "" && item.FaxNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFaxNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FaxNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFaxNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneNumberOffice", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PhoneNumberOffice.Trim()));

                    if (item.CentreEstablishmentDatetime != null && item.CentreEstablishmentDatetime != "" && item.CentreEstablishmentDatetime != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daCentreEstablishmentDatetime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CentreEstablishmentDatetime.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daCentreEstablishmentDatetime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOrganisationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OrganisationID));
                    if (item.CentreLoginNumber != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCentreLoginNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CentreLoginNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCentreLoginNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.InstituteCode != null && item.InstituteCode != "" && item.InstituteCode != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsInstituteCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InstituteCode.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsInstituteCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,DBNull.Value));
                    }
                    if (item.IDs != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IDs.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTimeZone", SqlDbType.VarChar, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TimeZone.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLatitude", SqlDbType.Decimal,0 , ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Latitude != null? Convert.ToDecimal(item.Latitude):0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLongitude", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Longitude != null ? Convert.ToDecimal(item.Longitude) : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dCampusArea", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CampusArea != null ? Convert.ToDecimal(item.CampusArea) : 0));
                                                                                                                                                    

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                        throw new Exception("Stored Procedure 'dbo.USP_OrgStudyCentreMaster_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of OrganisationStudyCentreMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationStudyCentreMaster> UpdateOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item)
        {
            IBaseEntityResponse<OrganisationStudyCentreMaster> response = new BaseEntityResponse<OrganisationStudyCentreMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgStudyCentreMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sHoCoRoScFlag", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.HoCoRoScFlag.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iHoID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.HoID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCoID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CoID));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRoID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RoID));
                    if (item.CentreSpecialization != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreSpecialization", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreSpecialization.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreSpecialization", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreAddress.Trim()));
                    if (item.PlotNo != "0" && item.PlotNo != "" && item.PlotNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNo", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PlotNo.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNo", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StreetName != null && item.StreetName != "" && item.StreetName != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetName", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StreetName.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetName", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPincode", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Pincode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailID.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sUrl", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Url));
                    if (item.CellPhone != "0" && item.CellPhone != "" && item.CellPhone != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCellPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CellPhone.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCellPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FaxNumber != "0" && item.FaxNumber != "" && item.FaxNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFaxNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FaxNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFaxNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneNumberOffice", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PhoneNumberOffice.Trim()));

                    if (item.CentreEstablishmentDatetime != null && item.CentreEstablishmentDatetime != "" && item.CentreEstablishmentDatetime != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daCentreEstablishmentDatetime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CentreEstablishmentDatetime.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daCentreEstablishmentDatetime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOrganisationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OrganisationID));
                    if (item.CentreLoginNumber != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCentreLoginNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CentreLoginNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCentreLoginNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.InstituteCode != null && item.InstituteCode != "" && item.InstituteCode != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsInstituteCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InstituteCode.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsInstituteCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTimeZone", SqlDbType.VarChar, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TimeZone.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLatitude", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Latitude != null ? Convert.ToDecimal(item.Latitude) : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLongitude", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Longitude != null ? Convert.ToDecimal(item.Longitude) : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dCampusArea", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CampusArea != null ? Convert.ToDecimal(item.CampusArea) : 0));
                                                                                                                                                    

                   // cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IDs.Trim()));
                    if (item.IDs != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IDs.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgStudyCentreMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of OrganisationStudyCentreMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationStudyCentreMaster> DeleteOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item)
        {
            IBaseEntityResponse<OrganisationStudyCentreMaster> response = new BaseEntityResponse<OrganisationStudyCentreMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgStudyCentreMaster_Delete";
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
                                            DataRowVersion.Proposed, item.DeletedBy));
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OrgStudyCentreMaster_Delete' reported the ErrorCode: " +
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
