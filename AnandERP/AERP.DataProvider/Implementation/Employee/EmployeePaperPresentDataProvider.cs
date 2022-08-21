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
    public class EmployeePaperPresentDataProvider : DBInteractionBase, IEmployeePaperPresentDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeePaperPresentDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeePaperPresentDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EmployeePaperPresent table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePaperPresent> GetEmployeePaperPresentBySearch(EmployeePaperPresentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePaperPresent> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeePaperPresent>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePaperPresentPresenter_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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
                    baseEntityCollection.CollectionResponse = new List<EmployeePaperPresent>();
                    while (sqlDataReader.Read())
                    {
                        EmployeePaperPresent item = new EmployeePaperPresent();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["PaperTopic"]) == false)
                        {
                            item.PaperTopic = sqlDataReader["PaperTopic"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JournalName"]) == false)
                        {
                            item.JournalName = sqlDataReader["JournalName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JournalVolumeNumber"]) == false)
                        {
                            item.JournalVolumeNumber = sqlDataReader["JournalVolumeNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JournalPageNumber"]) == false)
                        {
                            item.JournalPageNumber = sqlDataReader["JournalPageNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeYear"]) == false)
                        {
                            item.EmployeeYear = sqlDataReader["EmployeeYear"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperType"]) == false)
                        {
                            item.PaperType = sqlDataReader["PaperType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralLevelMasterID"]) == false)
                        {
                            item.GeneralLevelMasterID = Convert.ToInt32(sqlDataReader["GeneralLevelMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeBookReview"]) == false)
                        {
                            item.EmployeeBookReview = sqlDataReader["EmployeeBookReview"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeArticleReview"]) == false)
                        {
                            item.EmployeeArticleReview = sqlDataReader["EmployeeArticleReview"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PublishMedium"]) == false)
                        {
                            item.PublishMedium = sqlDataReader["PublishMedium"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeConferenceDateFrom"]) == false)
                        {
                            item.EmployeeConferenceDateFrom = sqlDataReader["EmployeeConferenceDateFrom"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ConferenceName"]) == false)
                        {
                            item.ConferenceName = sqlDataReader["ConferenceName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeConferenceVenue"]) == false)
                        {
                            item.EmployeeConferenceVenue = sqlDataReader["EmployeeConferenceVenue"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PublishDate"]) == false)
                        {
                            item.PublishDate = sqlDataReader["PublishDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeProceedingPageNumber"]) == false)
                        {
                            item.EmployeeProceedingPageNumber = sqlDataReader["EmployeeProceedingPageNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeConferenceProceeding"]) == false)
                        {
                            item.EmployeeConferenceProceeding = sqlDataReader["EmployeeConferenceProceeding"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralLevel"]) == false)
                        {
                            item.GeneralLevel = sqlDataReader["GeneralLevel"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeePaperPresenterID"]) == false)
                        {
                            item.EmployeePaperPresenterID = Convert.ToInt32(sqlDataReader["EmployeePaperPresenterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeParticipationRole"]) == false)
                        {
                            item.EmployeeParticipationRole = sqlDataReader["EmployeeParticipationRole"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
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
                        throw new Exception("Stored Procedure 'USP_EmployeePaperPresent_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from EmployeePaperPresent table with search parameters for one employee for profile report
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePaperPresent> GetEmployeePaperPresentAppliedDetails(EmployeePaperPresentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePaperPresent> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeePaperPresent>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePaperPresentPresenter_Applicable";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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
                    baseEntityCollection.CollectionResponse = new List<EmployeePaperPresent>();
                    while (sqlDataReader.Read())
                    {
                        EmployeePaperPresent item = new EmployeePaperPresent();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["PaperTopic"]) == false)
                        {
                            item.PaperTopic = sqlDataReader["PaperTopic"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JournalName"]) == false)
                        {
                            item.JournalName = sqlDataReader["JournalName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JournalVolumeNumber"]) == false)
                        {
                            item.JournalVolumeNumber = sqlDataReader["JournalVolumeNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JournalPageNumber"]) == false)
                        {
                            item.JournalPageNumber = sqlDataReader["JournalPageNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeYear"]) == false)
                        {
                            item.EmployeeYear = sqlDataReader["EmployeeYear"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperType"]) == false)
                        {
                            item.PaperType = sqlDataReader["PaperType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralLevelMasterID"]) == false)
                        {
                            item.GeneralLevelMasterID = Convert.ToInt32(sqlDataReader["GeneralLevelMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeBookReview"]) == false)
                        {
                            item.EmployeeBookReview = sqlDataReader["EmployeeBookReview"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeArticleReview"]) == false)
                        {
                            item.EmployeeArticleReview = sqlDataReader["EmployeeArticleReview"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PublishMedium"]) == false)
                        {
                            item.PublishMedium = sqlDataReader["PublishMedium"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeConferenceDateFrom"]) == false)
                        {
                            item.EmployeeConferenceDateFrom = sqlDataReader["EmployeeConferenceDateFrom"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ConferenceName"]) == false)
                        {
                            item.ConferenceName = sqlDataReader["ConferenceName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeConferenceVenue"]) == false)
                        {
                            item.EmployeeConferenceVenue = sqlDataReader["EmployeeConferenceVenue"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PublishDate"]) == false)
                        {
                            item.PublishDate = sqlDataReader["PublishDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeProceedingPageNumber"]) == false)
                        {
                            item.EmployeeProceedingPageNumber = sqlDataReader["EmployeeProceedingPageNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeConferenceProceeding"]) == false)
                        {
                            item.EmployeeConferenceProceeding = sqlDataReader["EmployeeConferenceProceeding"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralLevel"]) == false)
                        {
                            item.GeneralLevel = sqlDataReader["GeneralLevel"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeePaperPresenterID"]) == false)
                        {
                            item.EmployeePaperPresenterID = Convert.ToInt32(sqlDataReader["EmployeePaperPresenterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeParticipationRole"]) == false)
                        {
                            item.EmployeeParticipationRole = sqlDataReader["EmployeeParticipationRole"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
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
                        throw new Exception("Stored Procedure 'USP_EmployeePaperPresentPresenter_Applicable' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeePaperPresent> GetEmployeePaperPresentByID(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> response = new BaseEntityResponse<EmployeePaperPresent>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePaperPresentPresenter_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeePaperPresenterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeePaperPresenterID));
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    while (sqlDataReader.Read())
                    {
                        EmployeePaperPresent _item = new EmployeePaperPresent();

                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["PaperTopic"]) == false)
                        {
                            _item.PaperTopic = sqlDataReader["PaperTopic"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JournalName"]) == false)
                        {
                            _item.JournalName = sqlDataReader["JournalName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JournalVolumeNumber"]) == false)
                        {
                            _item.JournalVolumeNumber = sqlDataReader["JournalVolumeNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JournalPageNumber"]) == false)
                        {
                            _item.JournalPageNumber = sqlDataReader["JournalPageNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeYear"]) == false)
                        {
                            _item.EmployeeYear = sqlDataReader["EmployeeYear"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperType"]) == false)
                        {
                            _item.PaperType = sqlDataReader["PaperType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralLevelMasterID"]) == false)
                        {
                            _item.GeneralLevelMasterID = Convert.ToInt32(sqlDataReader["GeneralLevelMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeArticleReview"]) == false)
                        {
                            _item.EmployeeBookReview = sqlDataReader["EmployeeBookReview"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeArticleReview"]) == false)
                        {
                            _item.EmployeeArticleReview = sqlDataReader["EmployeeArticleReview"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PublishMedium"]) == false)
                        {
                            _item.PublishMedium = sqlDataReader["PublishMedium"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeConferenceDateFrom"]) == false)
                        {
                            _item.EmployeeConferenceDateFrom = sqlDataReader["EmployeeConferenceDateFrom"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeConferenceDateTo"]) == false)
                        {
                            _item.EmployeeConferenceDateTo = sqlDataReader["EmployeeConferenceDateTo"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ConferenceName"]) == false)
                        {
                            _item.ConferenceName = sqlDataReader["ConferenceName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeConferenceVenue"]) == false)
                        {
                            _item.EmployeeConferenceVenue = sqlDataReader["EmployeeConferenceVenue"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PublishDate"]) == false)
                        {
                            
                            _item.PublishDate = sqlDataReader["PublishDate"].ToString();
                            
                            
                        }
                        if (sqlDataReader["SelfGroupPresenter"].ToString() == "True" || sqlDataReader["SelfGroupPresenter"].ToString() == "1")
                        {
                            _item.SelfGroupPresenter = "true";
                        }
                        else
                        {
                            _item.SelfGroupPresenter = "false";
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeProceedingPageNumber"]) == false)
                        {
                            _item.EmployeeProceedingPageNumber = sqlDataReader["EmployeeProceedingPageNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeConferenceProceeding"]) == false)
                        {
                            _item.EmployeeConferenceProceeding = sqlDataReader["EmployeeConferenceProceeding"].ToString();
                        }
                        if (item.EmployeePaperPresenterID != 0)
                        {
                            _item.EmployeeParticipationRole = sqlDataReader["EmployeeParticipationRole"].ToString();
                            _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
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
        public IBaseEntityResponse<EmployeePaperPresent> InsertEmployeePaperPresent(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> response = new BaseEntityResponse<EmployeePaperPresent>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePaperPresentPresenter_InsertUpdate";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));

                    if (item.PaperTopic != null && item.PaperTopic != "" && item.PaperTopic != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPaperTopic", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PaperTopic));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPaperTopic", SqlDbType.VarChar, 500,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.JournalName != null && item.JournalName != "" && item.JournalName != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sJournalName", SqlDbType.VarChar, 500,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.JournalName));
                    }
                    else 
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sJournalName", SqlDbType.VarChar, 500,
                                                                       ParameterDirection.Input, false, 10, 0, "",
                                                                       DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.JournalVolumeNumber != null && item.JournalVolumeNumber != "" && item.JournalVolumeNumber != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sJournalVolumeNumber", SqlDbType.VarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.JournalVolumeNumber));
                    }
                    else 
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sJournalVolumeNumber", SqlDbType.VarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed,DBNull.Value));
                    
                    }
                    if (item.JournalPageNumber != null && item.JournalPageNumber != "" && item.JournalPageNumber != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sJournalPageNumber", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.JournalPageNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sJournalPageNumber", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    

                    }
                    if (item.EmployeeYear != null && item.EmployeeYear != "" && item.EmployeeYear != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeYear", SqlDbType.VarChar, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.EmployeeYear));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeYear", SqlDbType.VarChar, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    
                    
                    }

                    if (item.PaperType != null && item.PaperType != "" && item.PaperType != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPaperType", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PaperType));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPaperType", SqlDbType.VarChar, 15,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    
                    
                    }

                    if (item.GeneralLevelMasterID != null && item.GeneralLevelMasterID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralLevelMasterID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.GeneralLevelMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralLevelMasterID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                   
                    
                    }

                    if (item.EmployeeBookReview != null && item.EmployeeBookReview != "" && item.EmployeeBookReview != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeBookReview", SqlDbType.VarChar, 4000,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.EmployeeBookReview));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeBookReview", SqlDbType.VarChar, 4000,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    
                    
                    }
                    if (item.EmployeeArticleReview != null && item.EmployeeArticleReview != "" && item.EmployeeArticleReview != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeArticleReview", SqlDbType.VarChar, 1000,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.EmployeeArticleReview));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeArticleReview", SqlDbType.VarChar, 1000,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    
                    }
                    if (item.PublishMedium != null && item.PublishMedium != "" && item.PublishMedium != string.Empty)
                    {
                         cmdToExecute.Parameters.Add(new SqlParameter("@sPublishMedium", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PublishMedium));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sPublishMedium", SqlDbType.VarChar, 15,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    
                    }
                    if (item.EmployeeConferenceDateFrom != null && item.EmployeeConferenceDateFrom != "" && item.EmployeeConferenceDateFrom != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daEmployeeCoferenceDateFrom", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.EmployeeConferenceDateFrom)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daEmployeeCoferenceDateFrom", SqlDbType.Date, 0,
                                             ParameterDirection.Input, false, 0, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    
                    }
                    if (item.EmployeeConferenceDateTo != null && item.EmployeeConferenceDateTo != "" && item.EmployeeConferenceDateTo != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daEmployeeConferenceDateTo", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.EmployeeConferenceDateTo)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daEmployeeConferenceDateTo", SqlDbType.Date, 0,
                                                 ParameterDirection.Input, false, 0, 0, "",
                                                 DataRowVersion.Proposed, DBNull.Value));
                    
                    
                    }
                    if (item.ConferenceName != null && item.ConferenceName != "" && item.ConferenceName != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sConferenceName", SqlDbType.VarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ConferenceName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sConferenceName", SqlDbType.VarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed,DBNull.Value));
                    
                    }
                    if (item.EmployeeConferenceVenue != null && item.EmployeeConferenceVenue != "" && item.EmployeeConferenceVenue != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeConferenceVenue", SqlDbType.VarChar, 150,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.EmployeeConferenceVenue));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeConferenceVenue", SqlDbType.VarChar, 150,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    
                    }
                    if (item.PublishDate != null && item.PublishDate != "" && item.PublishDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daPublishDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.PublishDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daPublishDate", SqlDbType.Date, 0,
                                             ParameterDirection.Input, false, 0, 0, "",
                                             DataRowVersion.Proposed,DBNull.Value));
                    
                    
                    }

                    if (item.EmployeeProceedingPageNumber != null && item.EmployeeProceedingPageNumber != "" && item.EmployeeProceedingPageNumber != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeProceedingPageNumber", SqlDbType.VarChar, 15,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, item.EmployeeProceedingPageNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeProceedingPageNumber", SqlDbType.VarChar, 15,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, DBNull.Value));
                    
                    
                    }
                    if (item.EmployeeConferenceProceeding != null && item.EmployeeConferenceProceeding != "" && item.EmployeeConferenceProceeding != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeConferenceProceeding", SqlDbType.VarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.EmployeeConferenceProceeding));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeConferenceProceeding", SqlDbType.VarChar, 255,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed,DBNull.Value));
                    
                    }
                   
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeePaperPresenterID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.EmployeePaperPresenterID));
                  

                    if (item.EmployeeID != null && item.EmployeeID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.EmployeeID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    
                    }
                    if (item.EmployeeParticipationRole != null && item.EmployeeParticipationRole != "" && item.EmployeeParticipationRole != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeParticipationRole", SqlDbType.VarChar, 15,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.EmployeeParticipationRole));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeParticipationRole", SqlDbType.VarChar, 15,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed,DBNull.Value));
                    
                    }

                  
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 4,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, item.IsActive));

                        if (item.SelfGroupPresenter != null && item.SelfGroupPresenter != "" && item.SelfGroupPresenter != string.Empty)
                        {
                            cmdToExecute.Parameters.Add(new SqlParameter("@bSelfGroupPresenter", SqlDbType.Bit, 4,
                                                    ParameterDirection.Input, true, 10, 0, "",
                                                    DataRowVersion.Proposed, Convert.ToBoolean(item.SelfGroupPresenter)));
                        }
                        else
                        {
                            cmdToExecute.Parameters.Add(new SqlParameter("@bSelfGroupPresenter", SqlDbType.Bit, 4,
                                                    ParameterDirection.Input, true, 10, 0, "",
                                                    DataRowVersion.Proposed,DBNull.Value));
                    
                        }

                        cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, item.CreatedBy));
                    
                    
                        cmdToExecute.Parameters.Add(new SqlParameter("@iNewID", SqlDbType.Int, 4,
                                               ParameterDirection.Output, true, 10, 0, "",
                                               DataRowVersion.Proposed, _errorCode));
                    

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
                        throw new Exception("Stored Procedure 'USP_EmployeePaperPresentPresenter_InsertUpdate' reported the ErrorCode: " +
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
        /// UpDate a specific record of EmployeePaperPresent
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> UpdateEmployeePaperPresent(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> response = new BaseEntityResponse<EmployeePaperPresent>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePaperPresent_UpDate";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPaperTopic", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.PaperTopic));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sJournalName", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.JournalName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sJournalVolumeNumber", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.JournalVolumeNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sJournalPageNumber", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.JournalPageNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.EmployeeYear));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPaperType", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.PaperType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralLevelMasterID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.GeneralLevelMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeBookReview", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.EmployeeBookReview));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeArticleReview", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.EmployeeArticleReview));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPublishMedium", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.PublishMedium));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.EmployeeConferenceDateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sConferenceName", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ConferenceName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeConferenceVenue", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.EmployeeConferenceVenue));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.PublishDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeProceedingPageNumber", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.EmployeeProceedingPageNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeConferenceProceeding", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.EmployeeConferenceProceeding));

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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeePaperPresent_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of EmployeePaperPresent
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> DeleteEmployeePaperPresent(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> response = new BaseEntityResponse<EmployeePaperPresent>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePaperPresent_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeePaperPresent_Delete' reported the ErrorCode: " +
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

        /// <summary>
        /// Select all record from EmployeePaperPresenter table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePaperPresent> GetEmployeePaperPresenterBySearch(EmployeePaperPresentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePaperPresent> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeePaperPresent>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePaperPresenter_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
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
                    baseEntityCollection.CollectionResponse = new List<EmployeePaperPresent>();
                    while (sqlDataReader.Read())
                    {
                        EmployeePaperPresent item = new EmployeePaperPresent();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.EmployeePaperPresentID = Convert.ToInt32(sqlDataReader["EmployeePaperPresentID"]);
                        item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        item.EmployeeParticipationRole = sqlDataReader["EmployeeParticipationRole"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_EmployeePaperPresenter_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeePaperPresent> GetEmployeePaperPresenterByID(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> response = new BaseEntityResponse<EmployeePaperPresent>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePaperPresenter_SelectOne";
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
                        EmployeePaperPresent _item = new EmployeePaperPresent();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.EmployeePaperPresentID = Convert.ToInt32(sqlDataReader["EmployeePaperPresentID"]);
                        _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        _item.EmployeeParticipationRole = sqlDataReader["EmployeeParticipationRole"].ToString();

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
        public IBaseEntityResponse<EmployeePaperPresent> InsertEmployeePaperPresenter(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> response = new BaseEntityResponse<EmployeePaperPresent>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePaperPresenter_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeePaperPresentID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.EmployeePaperPresentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeParticipationRole", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeParticipationRole));
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeePaperPresenter_INSERT' reported the ErrorCode: " +
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
        /// UpDate a specific record of EmployeePaperPresenter
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> UpdateEmployeePaperPresenter(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> response = new BaseEntityResponse<EmployeePaperPresent>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePaperPresenter_UpDate";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeePaperPresentID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.EmployeePaperPresentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeParticipationRole", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.EmployeeParticipationRole));

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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeePaperPresenter_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of EmployeePaperPresenter
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> DeleteEmployeePaperPresenter(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> response = new BaseEntityResponse<EmployeePaperPresent>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeePaperPresenter_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeePaperPresenter_Delete' reported the ErrorCode: " +
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

    }
}
