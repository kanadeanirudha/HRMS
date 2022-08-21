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
    public class EmployeeExperienceDataProvider : DBInteractionBase, IEmployeeExperienceDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeeExperienceDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeeExperienceDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EmployeeExperience table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeExperience> GetEmployeeExperienceBySearch(EmployeeExperienceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeExperience> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeExperience>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeExperience_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<EmployeeExperience>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeExperience item = new EmployeeExperience();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PreviousOrganisationName"]) == false)
                        {
                            item.PreviousOrganisationName = sqlDataReader["PreviousOrganisationName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Designation"]) == false)
                        {
                            item.Designation = sqlDataReader["Designation"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralExperienceTypeMasterID"]) == false)
                        {
                            item.GeneralExperienceTypeMasterID = Convert.ToInt32(sqlDataReader["GeneralExperienceTypeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExperienceType"]) == false)
                        {
                            item.GeneralExperienceType = sqlDataReader["ExperienceType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExperienceInMonth"]) == false)
                        {
                            item.ExperienceInMonth = Convert.ToInt16(sqlDataReader["ExperienceInMonth"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralJobStatusID"]) == false)
                        {
                            item.GeneralJobStatusID = Convert.ToInt32(sqlDataReader["GeneralJobStatusID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobStatus"]) == false)
                        {
                            item.GeneralJobStatus = sqlDataReader["JobStatus"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalNumber"]) == false)
                        {
                            item.UniversityApprovalNumber = sqlDataReader["UniversityApprovalNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NatureOfAppointment"]) == false)
                        {
                            item.NatureOfAppointment = sqlDataReader["NatureOfAppointment"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExperienceFromYear"]) == false)
                        {
                            item.ExperienceFromYear = Convert.ToString(sqlDataReader["ExperienceFromYear"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExperienceToYear"]) == false)
                        {
                            item.ExperienceToYear = Convert.ToString(sqlDataReader["ExperienceToYear"]);
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
                        throw new Exception("Stored Procedure 'USP_EmployeeExperience_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select  records from EmployeeExperience table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeExperience> GetEmployeeExperienceBySearchList(EmployeeExperienceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeExperience> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeExperience>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeExperience_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));

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
                    baseEntityCollection.CollectionResponse = new List<EmployeeExperience>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeExperience item = new EmployeeExperience();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["SequenceNumber"]) == false)
                        //{
                        //    item.SequenceNumber = Convert.ToInt32(sqlDataReader["SequenceNumber"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OrderNumber"]) == false)
                        //{
                        //    item.OrderNumber = sqlDataReader["OrderNumber"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["PromotionDemotionFlag"]) == false)
                        //{
                        //    item.PromotionDemotionFlag = sqlDataReader["PromotionDemotionFlag"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        //{
                        //    item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OldDesignationID"]) == false)
                        //{
                        //    item.OldDesignationID = Convert.ToInt32(sqlDataReader["OldDesignationID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OldDepartmentID"]) == false)
                        //{
                        //    item.OldDepartmentID = Convert.ToInt32(sqlDataReader["OldDepartmentID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        //{
                        //    item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["EmployeeDesignation"]) == false)
                        //{
                        //    item.EmployeeDesignation = sqlDataReader["EmployeeDesignation"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OldDepartmentName"]) == false)
                        //{
                        //    item.DepartmentName = sqlDataReader["OldDepartmentName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["IsCurrentFlag"]) == false)
                        //{
                        //    item.IsCurrentFlag = Convert.ToBoolean(sqlDataReader["IsCurrentFlag"]);
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
                        throw new Exception("Stored Procedure 'USP_EmployeeExperience_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeExperience> GetEmployeeExperienceByID(EmployeeExperience item)
        {
            IBaseEntityResponse<EmployeeExperience> response = new BaseEntityResponse<EmployeeExperience>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeExperience_SelectOne";
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
                        EmployeeExperience _item = new EmployeeExperience();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExperienceFromYear"]) == false)
                        {
                            _item.ExperienceFromYear = Convert.ToString(sqlDataReader["ExperienceFromYear"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExperienceToYear"]) == false)
                        {
                            _item.ExperienceToYear = Convert.ToString(sqlDataReader["ExperienceToYear"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExperienceInMonth"]) == false)
                        {
                            _item.ExperienceInMonth = Convert.ToInt16(sqlDataReader["ExperienceInMonth"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PreviousOrganisationName"]) == false)
                        {
                            _item.PreviousOrganisationName = sqlDataReader["PreviousOrganisationName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PreviousOrgnisationAddress"]) == false)
                        {
                            _item.PreviousOrganisationAddress = sqlDataReader["PreviousOrgnisationAddress"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Designation"]) == false)
                        {
                            _item.Designation = sqlDataReader["Designation"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Remarks"]) == false)
                        {
                            _item.Remarks = sqlDataReader["Remarks"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralExperienceTypeMasterID"]) == false)
                        {
                            _item.GeneralExperienceTypeMasterID = Convert.ToInt32(sqlDataReader["GeneralExperienceTypeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastPayDrawnPayScale"]) == false)
                        {
                            _item.LastPayDrawnPayScale = sqlDataReader["LastPayDrawnPayScale"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NatureOfAppointment"]) == false)
                        {
                            _item.NatureOfAppointment = sqlDataReader["NatureOfAppointment"].ToString();
                        }                        
                        if (DBNull.Value.Equals(sqlDataReader["GeneralJobStatusID"]) == false)
                        {
                            _item.GeneralJobStatusID = Convert.ToInt32(sqlDataReader["GeneralJobStatusID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AppointmentOrderNumber"]) == false)
                        {
                            _item.AppointmentOrderNumber = sqlDataReader["AppointmentOrderNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AppointmentOrderDate"]) == false)
                        {
                            _item.AppointmentOrderDate = Convert.ToString(sqlDataReader["AppointmentOrderDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalNumber"]) == false)
                        {
                            _item.UniversityApprovalNumber = sqlDataReader["UniversityApprovalNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalDate"]) == false)
                        {
                            _item.UniversityApprovalDate = Convert.ToString(sqlDataReader["UniversityApprovalDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralBoardUniversityID"]) == false)
                        {
                            _item.GeneralBoardUniversityID = Convert.ToInt32(sqlDataReader["GeneralBoardUniversityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectForApproval"]) == false)
                        {
                            _item.SubjectForApproval = sqlDataReader["SubjectForApproval"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalType"]) == false)
                        {
                            _item.UniversityApprovalType = sqlDataReader["UniversityApprovalType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MonthOfApproval"]) == false)
                        {
                            _item.MonthOfApproval = Convert.ToInt16(sqlDataReader["MonthOfApproval"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["YearOfApproval"]) == false)
                        {
                            _item.YearOfApproval = Convert.ToInt16(sqlDataReader["YearOfApproval"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
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
                        throw new Exception("Stored Procedure 'USP_EmployeeExperience_SelectOne' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from table by EmployeeID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeExperience> GetEmployeeExperienceByEmployeeID(EmployeeExperience item)
        {
            IBaseEntityResponse<EmployeeExperience> response = new BaseEntityResponse<EmployeeExperience>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeExperience_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
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
                        EmployeeExperience _item = new EmployeeExperience();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["SequenceNumber"]) == false)
                        //{
                        //    _item.SequenceNumber = Convert.ToInt32(sqlDataReader["SequenceNumber"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OrderNumber"]) == false)
                        //{
                        //    _item.OrderNumber = sqlDataReader["OrderNumber"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["AcceptedByEmployee"]) == false)
                        //{
                        //    _item.AcceptedByEmployee = sqlDataReader["AcceptedByEmployee"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["PromotionDemotionFlag"]) == false)
                        //{
                        //    _item.PromotionDemotionFlag = sqlDataReader["PromotionDemotionFlag"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["PromotionDemotionDate"]) == false)
                        //{
                        //    _item.PromotionDemotionDate = Convert.ToDateTime(sqlDataReader["PromotionDemotionDate"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["PreviousPromotionDemotionDate"]) == false)
                        //{
                        //    _item.PreviousPromotionDemotionDate = Convert.ToDateTime(sqlDataReader["PreviousPromotionDemotionDate"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["EmployeeDesignationMasterID"]) == false)
                        //{
                        //    _item.EmployeeDesignationMasterID = Convert.ToInt32(sqlDataReader["EmployeeDesignationMasterID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        //{
                        //    _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        //{
                        //    _item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ChargeTakingDate"]) == false)
                        //{
                        //    _item.ChargeTakingDate = Convert.ToDateTime(sqlDataReader["ChargeTakingDate"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OldDesignationID"]) == false)
                        //{
                        //    _item.OldDesignationID = Convert.ToInt32(sqlDataReader["OldDesignationID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OldCentreCode"]) == false)
                        //{
                        //    _item.OldCentreCode = sqlDataReader["OldCentreCode"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OldDepartmentID"]) == false)
                        //{
                        //    _item.OldDepartmentID = Convert.ToInt32(sqlDataReader["OldDepartmentID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CollegeApprovalDate"]) == false)
                        //{
                        //    _item.CollegeApprovalDate = Convert.ToDateTime(sqlDataReader["CollegeApprovalDate"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalDate"]) == false)
                        //{
                        //    _item.UniversityApprovalDate = Convert.ToDateTime(sqlDataReader["UniversityApprovalDate"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CollegeApprovalNumber"]) == false)
                        //{
                        //    _item.CollegeApprovalNumber = sqlDataReader["CollegeApprovalNumber"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalNumber"]) == false)
                        //{
                        //    _item.UniversityApprovalNumber = sqlDataReader["UniversityApprovalNumber"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["NatureOfDuty"]) == false)
                        //{
                        //    _item.NatureOfDuty = sqlDataReader["NatureOfDuty"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["BasicAmount"]) == false)
                        //{
                        //    _item.BasicAmount = Convert.ToDecimal(sqlDataReader["BasicAmount"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ApprovedBy"]) == false)
                        //{
                        //    _item.ApprovedBy = sqlDataReader["ApprovedBy"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["NewGrade"]) == false)
                        //{
                        //    _item.NewGrade = Convert.ToDecimal(sqlDataReader["NewGrade"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["NewPayscaleID"]) == false)
                        //{
                        //    _item.NewPayscaleID = Convert.ToInt32(sqlDataReader["NewPayscaleID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["NatureOfAppointment"]) == false)
                        //{
                        //    _item.NatureOfAppointment = sqlDataReader["NatureOfAppointment"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalType"]) == false)
                        //{
                        //    _item.UniversityApprovalType = sqlDataReader["UniversityApprovalType"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["GeneralBoardUniversityID"]) == false)
                        //{
                        //    _item.GeneralBoardUniversityID = Convert.ToInt32(sqlDataReader["GeneralBoardUniversityID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["SubjectForApproval"]) == false)
                        //{
                        //    _item.SubjectForApproval = sqlDataReader["SubjectForApproval"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["GrantedPromotionDate"]) == false)
                        //{
                        //    _item.GrantedPromotionDate = Convert.ToDateTime(sqlDataReader["GrantedPromotionDate"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["GrantedPromotionDesignationID"]) == false)
                        //{
                        //    _item.GrantedPromotionDesignationID = Convert.ToInt32(sqlDataReader["GrantedPromotionDesignationID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["GrantedPromotionLevel"]) == false)
                        //{
                        //    _item.GrantedPromotionLevel = sqlDataReader["GrantedPromotionLevel"].ToString();
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["OldDepartmentName"]) == false)
                        //{
                        //    _item.OldDepartmentName = sqlDataReader["OldDepartmentName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["IsCurrentFlag"]) == false)
                        //{
                        //    _item.IsCurrentFlag = Convert.ToBoolean(sqlDataReader["IsCurrentFlag"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        //{
                        //    _item.CentreName = sqlDataReader["CentreName"].ToString();
                        //}
                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeExperience_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeExperience> InsertEmployeeExperience(EmployeeExperience item)
        {
            IBaseEntityResponse<EmployeeExperience> response = new BaseEntityResponse<EmployeeExperience>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeExperience_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeID));
                    if (item.ExperienceFromYear != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExperienceFromYear", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.ExperienceFromYear)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExperienceFromYear", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ExperienceToYear != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExperienceToYear", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.ExperienceToYear)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExperienceToYear", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ExperienceInMonth != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siExperienceInMonth", SqlDbType.SmallInt, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ExperienceInMonth));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siExperienceInMonth", SqlDbType.SmallInt, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PreviousOrganisationName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousOrganisationName", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PreviousOrganisationName.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousOrganisationName", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PreviousOrganisationAddress != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousOrgnisationAddress", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PreviousOrganisationAddress.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousOrgnisationAddress", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Designation != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.Designation.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Remarks != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.Remarks.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GeneralExperienceTypeMasterID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralExperienceTypeMasterID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.GeneralExperienceTypeMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralExperienceTypeMasterID", SqlDbType.Int, 10,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.LastPayDrawnPayScale != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastPayDrawnPayScale", SqlDbType.NVarChar, 100,
                                                       ParameterDirection.Input, false, 0, 0, "",
                                                       DataRowVersion.Proposed, item.LastPayDrawnPayScale));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastPayDrawnPayScale", SqlDbType.NVarChar, 100,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.NatureOfAppointment != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNatureOfAppointment", SqlDbType.NVarChar, 100,
                                                       ParameterDirection.Input, false, 0, 0, "",
                                                       DataRowVersion.Proposed, item.NatureOfAppointment.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNatureOfAppointment", SqlDbType.NVarChar, 100,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GeneralJobStatusID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralJobStatusID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.GeneralJobStatusID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralJobStatusID", SqlDbType.Int, 10,
                                                  ParameterDirection.Input, false, 0, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.AppointmentOrderNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sAppointmentOrderNumber", SqlDbType.VarChar, 50,
                                                       ParameterDirection.Input, false, 0, 0, "",
                                                       DataRowVersion.Proposed, item.AppointmentOrderNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sAppointmentOrderNumber", SqlDbType.VarChar, 50,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.AppointmentOrderDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daAppointmentOrderDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.AppointmentOrderDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daAppointmentOrderDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalNumber", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.UniversityApprovalNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalNumber", SqlDbType.VarChar, 15,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daUniversityApprovalDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, Convert.ToDateTime(item.UniversityApprovalDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daUniversityApprovalDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GeneralBoardUniversityID != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralBoardUniversityID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.GeneralBoardUniversityID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralBoardUniversityID", SqlDbType.Int, 10,
                                                  ParameterDirection.Input, false, 0, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.SubjectForApproval != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSubjectForApproval", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.SubjectForApproval.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSubjectForApproval", SqlDbType.NVarChar, 50,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalType != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalType", SqlDbType.VarChar, 20,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.UniversityApprovalType.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalType", SqlDbType.VarChar, 20,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MonthOfApproval != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siMonthOfApproval", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MonthOfApproval));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siMonthOfApproval", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.YearOfApproval != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siYearOfApproval", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.YearOfApproval));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siYearOfApproval", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                             ParameterDirection.Input, false, 0, 0, "",
                                             DataRowVersion.Proposed, item.IsActive));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.CreatedBy));   
               
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                            ParameterDirection.Output, true, 0, 0, "",
                                            DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 10,
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeExperience_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of EmployeeExperience
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeExperience> UpdateEmployeeExperience(EmployeeExperience item)
        {
            IBaseEntityResponse<EmployeeExperience> response = new BaseEntityResponse<EmployeeExperience>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeExperience_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.EmployeeID));
                    if (item.ExperienceFromYear != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExperienceFromYear", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.ExperienceFromYear)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExperienceFromYear", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ExperienceToYear != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExperienceToYear", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.ExperienceToYear)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExperienceToYear", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ExperienceInMonth != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siExperienceInMonth", SqlDbType.SmallInt, 4,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ExperienceInMonth));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siExperienceInMonth", SqlDbType.SmallInt, 4,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PreviousOrganisationName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousOrganisationName", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PreviousOrganisationName.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousOrganisationName", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PreviousOrganisationAddress != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousOrgnisationAddress", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PreviousOrganisationAddress.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousOrgnisationAddress", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Designation != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.Designation.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Remarks != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.Remarks.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GeneralExperienceTypeMasterID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralExperienceTypeMasterID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.GeneralExperienceTypeMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralExperienceTypeMasterID", SqlDbType.Int, 10,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.LastPayDrawnPayScale != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastPayDrawnPayScale", SqlDbType.NVarChar, 100,
                                                       ParameterDirection.Input, false, 0, 0, "",
                                                       DataRowVersion.Proposed, item.LastPayDrawnPayScale.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastPayDrawnPayScale", SqlDbType.NVarChar, 100,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.NatureOfAppointment != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNatureOfAppointment", SqlDbType.NVarChar, 100,
                                                       ParameterDirection.Input, false, 0, 0, "",
                                                       DataRowVersion.Proposed, item.NatureOfAppointment.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNatureOfAppointment", SqlDbType.NVarChar, 100,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GeneralJobStatusID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralJobStatusID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.GeneralJobStatusID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralJobStatusID", SqlDbType.Int, 10,
                                                  ParameterDirection.Input, false, 0, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.AppointmentOrderNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sAppointmentOrderNumber", SqlDbType.VarChar, 50,
                                                       ParameterDirection.Input, false, 0, 0, "",
                                                       DataRowVersion.Proposed, item.AppointmentOrderNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sAppointmentOrderNumber", SqlDbType.VarChar, 50,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.AppointmentOrderDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daAppointmentOrderDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.AppointmentOrderDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daAppointmentOrderDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalNumber", SqlDbType.VarChar, 30,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.UniversityApprovalNumber.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalNumber", SqlDbType.VarChar, 30,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daUniversityApprovalDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, Convert.ToDateTime(item.UniversityApprovalDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daUniversityApprovalDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GeneralBoardUniversityID != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralBoardUniversityID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.GeneralBoardUniversityID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralBoardUniversityID", SqlDbType.Int, 10,
                                                  ParameterDirection.Input, false, 0, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.SubjectForApproval != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSubjectForApproval", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.SubjectForApproval.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSubjectForApproval", SqlDbType.NVarChar, 50,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalType != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalType", SqlDbType.VarChar, 20,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.UniversityApprovalType.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalType", SqlDbType.VarChar, 20,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MonthOfApproval != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siMonthOfApproval", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MonthOfApproval));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siMonthOfApproval", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.YearOfApproval != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siYearOfApproval", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.YearOfApproval));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siYearOfApproval", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
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
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeExperience_Update' reported the ErrorCode: " +
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
        /// Delete a specific record of EmployeeExperience
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeExperience> DeleteEmployeeExperience(EmployeeExperience item)
        {
            IBaseEntityResponse<EmployeeExperience> response = new BaseEntityResponse<EmployeeExperience>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeExperience_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeExperience_Delete' reported the ErrorCode: " +
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
