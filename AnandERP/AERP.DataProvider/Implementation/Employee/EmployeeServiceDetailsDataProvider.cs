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
    public class EmployeeServiceDetailsDataProvider : DBInteractionBase, IEmployeeServiceDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeeServiceDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeeServiceDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EmployeeServiceDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeServiceDetails> GetEmployeeServiceDetailsBySearch(EmployeeServiceDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeServiceDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeServiceDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeServiceDetails_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<EmployeeServiceDetails>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeServiceDetails item = new EmployeeServiceDetails();
                        //item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        //item.SequenceNumber = Convert.ToInt32(sqlDataReader["SequenceNumber"]);
                        //item.OrderNumber = sqlDataReader["OrderNumber"].ToString();
                        //item.AcceptedByEmployee = sqlDataReader["AcceptedByEmployee"].ToString();
                        //item.PromotionDemotionFlag = sqlDataReader["PromotionDemotionFlag"].ToString();
                        //Not
                        //Not
                        //item.EmployeeDesignationMasterID = Convert.ToInt32(sqlDataReader["EmployeeDesignationMasterID"]);
                        //item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        //Not
                        //item.OldDesignationID = Convert.ToInt32(sqlDataReader["OldDesignationID"]);
                        //item.OldDepartmentID = Convert.ToInt32(sqlDataReader["OldDepartmentID"]);
                        //Not
                        //Not
                        //item.CollegeApprovalNumber = sqlDataReader["CollegeApprovalNumber"].ToString();
                        //item.UniversityApprovalNumber = sqlDataReader["UniversityApprovalNumber"].ToString();
                        //item.NatureOfDuty = sqlDataReader["NatureOfDuty"].ToString();
                        //Not
                        //item.ApprovedBy = sqlDataReader["ApprovedBy"].ToString();
                        //Not
                        //item.NewPayscaleID = Convert.ToInt32(sqlDataReader["NewPayscaleID"]);
                        //item.NatureOfAppointment = sqlDataReader["NatureOfAppointment"].ToString();
                        //item.UniversityApprovalType = sqlDataReader["UniversityApprovalType"].ToString();
                        //item.GeneralBoardUniversityID = Convert.ToInt32(sqlDataReader["GeneralBoardUniversityID"]);
                        //item.SubjectForApproval = sqlDataReader["SubjectForApproval"].ToString();
                        //Not
                        //item.GrantedPromotionDesignationID = Convert.ToInt32(sqlDataReader["GrantedPromotionDesignationID"]);
                        //item.GrantedPromotionLevel = sqlDataReader["GrantedPromotionLevel"].ToString();
                        //item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);

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
                        throw new Exception("Stored Procedure 'USP_EmployeeServiceDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select  records from EmployeeServiceDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeServiceDetails> GetEmployeeServiceDetailsBySearchList(EmployeeServiceDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeServiceDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeServiceDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeServiceDetails_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<EmployeeServiceDetails>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeServiceDetails item = new EmployeeServiceDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SequenceNumber"]) == false)
                        {
                            item.SequenceNumber = Convert.ToInt32(sqlDataReader["SequenceNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderNumber"]) == false)
                        {
                            item.OrderNumber = sqlDataReader["OrderNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PromotionDemotionFlag"]) == false)
                        {
                            item.PromotionDemotionFlag = sqlDataReader["PromotionDemotionFlag"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        {
                            item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldDesignationID"]) == false)
                        {
                            item.OldDesignationID = Convert.ToInt32(sqlDataReader["OldDesignationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldDepartmentID"]) == false)
                        {
                            item.OldDepartmentID = Convert.ToInt32(sqlDataReader["OldDepartmentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDesignation"]) == false)
                        {
                            item.EmployeeDesignation = sqlDataReader["EmployeeDesignation"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldDepartmentName"]) == false)
                        {
                            item.DepartmentName = sqlDataReader["OldDepartmentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCurrentFlag"]) == false)
                        {
                            item.IsCurrentFlag = Convert.ToBoolean(sqlDataReader["IsCurrentFlag"]);
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
                        throw new Exception("Stored Procedure 'USP_EmployeeServiceDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeServiceDetails> GetEmployeeServiceDetailsByID(EmployeeServiceDetails item)
        {
            IBaseEntityResponse<EmployeeServiceDetails> response = new BaseEntityResponse<EmployeeServiceDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeServiceDetails_SelectOneByID";
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
                        EmployeeServiceDetails _item = new EmployeeServiceDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SequenceNumber"]) == false)
                        {
                            _item.SequenceNumber = Convert.ToInt32(sqlDataReader["SequenceNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderNumber"]) == false)
                        {
                            _item.OrderNumber = sqlDataReader["OrderNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderDate"]) == false)
                        {
                            _item.OrderDate = sqlDataReader["OrderDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AcceptedByEmployee"]) == false)
                        {
                            _item.AcceptedByEmployee = sqlDataReader["AcceptedByEmployee"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PromotionDemotionFlag"]) == false)
                        {
                            _item.PromotionDemotionFlag = sqlDataReader["PromotionDemotionFlag"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PromotionDemotionDate"]) == false)
                        {
                            _item.PromotionDemotionDate = sqlDataReader["PromotionDemotionDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PreviousPromotionDemotionDate"]) == false)
                        {
                            _item.PreviousPromotionDemotionDate = sqlDataReader["PreviousPromotionDemotionDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDesignationMasterID"]) == false)
                        {
                            _item.EmployeeDesignationMasterID = Convert.ToInt32(sqlDataReader["EmployeeDesignationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        {
                            _item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChargeTakingDate"]) == false)
                        {
                            _item.ChargeTakingDate = sqlDataReader["ChargeTakingDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldDesignationID"]) == false)
                        {
                            _item.OldDesignationID = Convert.ToInt32(sqlDataReader["OldDesignationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldCentreCode"]) == false)
                        {
                            _item.OldCentreCode = sqlDataReader["OldCentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldDepartmentID"]) == false)
                        {
                            _item.OldDepartmentID = Convert.ToInt32(sqlDataReader["OldDepartmentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CollegeApprovalDate"]) == false)
                        {
                            _item.CollegeApprovalDate = sqlDataReader["CollegeApprovalDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalDate"]) == false)
                        {
                            _item.UniversityApprovalDate = sqlDataReader["UniversityApprovalDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CollegeApprovalNumber"]) == false)
                        {
                            _item.CollegeApprovalNumber = sqlDataReader["CollegeApprovalNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalNumber"]) == false)
                        {
                            _item.UniversityApprovalNumber = sqlDataReader["UniversityApprovalNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NatureOfDuty"]) == false)
                        {
                            _item.NatureOfDuty = sqlDataReader["NatureOfDuty"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BasicAmount"]) == false)
                        {
                            _item.BasicAmount = Convert.ToDecimal(sqlDataReader["BasicAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovedBy"]) == false)
                        {
                            _item.ApprovedBy = sqlDataReader["ApprovedBy"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NewGrade"]) == false)
                        {
                            _item.NewGrade = Convert.ToDecimal(sqlDataReader["NewGrade"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NewPayscaleID"]) == false)
                        {
                            _item.NewPayscaleID = Convert.ToInt32(sqlDataReader["NewPayscaleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NatureOfAppointment"]) == false)
                        {
                            _item.NatureOfAppointment = sqlDataReader["NatureOfAppointment"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalType"]) == false)
                        {
                            _item.UniversityApprovalType = sqlDataReader["UniversityApprovalType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralBoardUniversityID"]) == false)
                        {
                            _item.GeneralBoardUniversityID = Convert.ToInt32(sqlDataReader["GeneralBoardUniversityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectForApproval"]) == false)
                        {
                            _item.SubjectForApproval = sqlDataReader["SubjectForApproval"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GrantedPromotionDate"]) == false)
                        {
                            _item.GrantedPromotionDate = sqlDataReader["GrantedPromotionDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GrantedPromotionDesignationID"]) == false)
                        {
                            _item.GrantedPromotionDesignationID = Convert.ToInt32(sqlDataReader["GrantedPromotionDesignationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GrantedPromotionLevel"]) == false)
                        {
                            _item.GrantedPromotionLevel = sqlDataReader["GrantedPromotionLevel"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldDepartmentName"]) == false)
                        {
                            _item.OldDepartmentName = sqlDataReader["OldDepartmentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCurrentFlag"]) == false)
                        {
                            _item.IsCurrentFlag = Convert.ToBoolean(sqlDataReader["IsCurrentFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            _item.CentreName = sqlDataReader["CentreName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_EmployeeServiceDetails_SelectOneByID' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeServiceDetails> GetEmployeeServiceDetailsByEmployeeID(EmployeeServiceDetails item)
        {
            IBaseEntityResponse<EmployeeServiceDetails> response = new BaseEntityResponse<EmployeeServiceDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeServiceDetails_SelectOne";
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
                        EmployeeServiceDetails _item = new EmployeeServiceDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SequenceNumber"]) == false)
                        {
                            _item.SequenceNumber = Convert.ToInt32(sqlDataReader["SequenceNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderNumber"]) == false)
                        {
                            _item.OrderNumber = sqlDataReader["OrderNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderDate"]) == false)
                        {
                            _item.OrderDate = sqlDataReader["OrderDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AcceptedByEmployee"]) == false)
                        {
                            _item.AcceptedByEmployee = sqlDataReader["AcceptedByEmployee"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PromotionDemotionFlag"]) == false)
                        {
                            _item.PromotionDemotionFlag = sqlDataReader["PromotionDemotionFlag"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PromotionDemotionDate"]) == false)
                        {
                            _item.PromotionDemotionDate = sqlDataReader["PromotionDemotionDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PreviousPromotionDemotionDate"]) == false)
                        {
                            _item.PreviousPromotionDemotionDate = sqlDataReader["PreviousPromotionDemotionDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDesignationMasterID"]) == false)
                        {
                            _item.EmployeeDesignationMasterID = Convert.ToInt32(sqlDataReader["EmployeeDesignationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        {
                            _item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChargeTakingDate"]) == false)
                        {
                            _item.ChargeTakingDate = sqlDataReader["ChargeTakingDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldDesignationID"]) == false)
                        {
                            _item.OldDesignationID = Convert.ToInt32(sqlDataReader["OldDesignationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldCentreCode"]) == false)
                        {
                            _item.OldCentreCode = sqlDataReader["OldCentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldDepartmentID"]) == false)
                        {
                            _item.OldDepartmentID = Convert.ToInt32(sqlDataReader["OldDepartmentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CollegeApprovalDate"]) == false)
                        {
                            _item.CollegeApprovalDate = sqlDataReader["CollegeApprovalDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalDate"]) == false)
                        {
                            _item.UniversityApprovalDate = sqlDataReader["UniversityApprovalDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CollegeApprovalNumber"]) == false)
                        {
                            _item.CollegeApprovalNumber = sqlDataReader["CollegeApprovalNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalNumber"]) == false)
                        {
                            _item.UniversityApprovalNumber = sqlDataReader["UniversityApprovalNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NatureOfDuty"]) == false)
                        {
                            _item.NatureOfDuty = sqlDataReader["NatureOfDuty"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BasicAmount"]) == false)
                        {
                            _item.BasicAmount = Convert.ToDecimal(sqlDataReader["BasicAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovedBy"]) == false)
                        {
                            _item.ApprovedBy = sqlDataReader["ApprovedBy"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NewGrade"]) == false)
                        {
                            _item.NewGrade = Convert.ToDecimal(sqlDataReader["NewGrade"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NewPayscaleID"]) == false)
                        {
                            _item.NewPayscaleID = Convert.ToInt32(sqlDataReader["NewPayscaleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NatureOfAppointment"]) == false)
                        {
                            _item.NatureOfAppointment = sqlDataReader["NatureOfAppointment"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityApprovalType"]) == false)
                        {
                            _item.UniversityApprovalType = sqlDataReader["UniversityApprovalType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralBoardUniversityID"]) == false)
                        {
                            _item.GeneralBoardUniversityID = Convert.ToInt32(sqlDataReader["GeneralBoardUniversityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectForApproval"]) == false)
                        {
                            _item.SubjectForApproval = sqlDataReader["SubjectForApproval"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GrantedPromotionDate"]) == false)
                        {
                            _item.GrantedPromotionDate = sqlDataReader["GrantedPromotionDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GrantedPromotionDesignationID"]) == false)
                        {
                            _item.GrantedPromotionDesignationID = Convert.ToInt32(sqlDataReader["GrantedPromotionDesignationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GrantedPromotionLevel"]) == false)
                        {
                            _item.GrantedPromotionLevel = sqlDataReader["GrantedPromotionLevel"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldDepartmentName"]) == false)
                        {
                            _item.OldDepartmentName = sqlDataReader["OldDepartmentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCurrentFlag"]) == false)
                        {
                            _item.IsCurrentFlag = Convert.ToBoolean(sqlDataReader["IsCurrentFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            _item.CentreName = sqlDataReader["CentreName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_EmployeeServiceDetails_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeServiceDetails> InsertEmployeeServiceDetails(EmployeeServiceDetails item)
        {
            IBaseEntityResponse<EmployeeServiceDetails> response = new BaseEntityResponse<EmployeeServiceDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeServiceDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeID));
                    if (item.SequenceNumber != null && item.SequenceNumber != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iSequenceNumber", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.SequenceNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iSequenceNumber", SqlDbType.Int, 10,
                                                    ParameterDirection.Input, false, 0, 0, "",
                                                    DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.OrderNumber != null && item.OrderNumber != "" && item.OrderNumber != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOrderNumber", SqlDbType.NVarChar, 20,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.OrderNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOrderNumber", SqlDbType.NVarChar, 20,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.OrderDate != null && item.OrderDate != "" && item.OrderDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daOrderDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed,Convert.ToDateTime(item.OrderDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daOrderDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.AcceptedByEmployee != null && item.AcceptedByEmployee != "" && item.AcceptedByEmployee != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAcceptedByEmployee", SqlDbType.Char, 1,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.AcceptedByEmployee));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAcceptedByEmployee", SqlDbType.Char, 1,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PromotionDemotionFlag != null && item.PromotionDemotionFlag != "" && item.PromotionDemotionFlag != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cPromotionDemotionFlag", SqlDbType.Char, 1,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PromotionDemotionFlag));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cPromotionDemotionFlag", SqlDbType.Char, 1,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PromotionDemotionDate != null && item.PromotionDemotionDate != "" && item.PromotionDemotionDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daPromotionDemotionDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.PromotionDemotionDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daPromotionDemotionDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PreviousPromotionDemotionDate != null && item.PreviousPromotionDemotionDate != "" && item.PreviousPromotionDemotionDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daPreviousPromotionDemotionDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.PreviousPromotionDemotionDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daPreviousPromotionDemotionDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.EmployeeDesignationMasterID != null && item.EmployeeDesignationMasterID != 0 )
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeDesignationMasterID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.EmployeeDesignationMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeDesignationMasterID", SqlDbType.Int, 10,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CentreCode != null && item.CentreCode != "" && item.CentreCode != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,15,
                                                       ParameterDirection.Input, false, 0, 0, "",
                                                       DataRowVersion.Proposed, item.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.DepartmentID != null && item.DepartmentID != 0 )
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.DepartmentID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 10,
                                                  ParameterDirection.Input, false, 0, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ChargeTakingDate != null && item.ChargeTakingDate != "" && item.ChargeTakingDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daChargeTakingDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.ChargeTakingDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daChargeTakingDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.OldDesignationID != null && item.OldDesignationID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOldDesignationID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.OldDesignationID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOldDesignationID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.OldCentreCode != null && item.OldCentreCode != "" && item.OldCentreCode != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOldCentreCode", SqlDbType.NVarChar, 15,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.OldCentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOldCentreCode", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.OldDepartmentID != null && item.OldDepartmentID != 0 )
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOldDepartmentID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.OldDepartmentID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOldDepartmentID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CollegeApprovalDate != null && item.CollegeApprovalDate != "" && item.CollegeApprovalDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daCollegeApprovalDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, Convert.ToDateTime(item.CollegeApprovalDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daCollegeApprovalDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalDate != null && item.UniversityApprovalDate != "" && item.UniversityApprovalDate != string.Empty)
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
                    if (item.CollegeApprovalNumber != null && item.CollegeApprovalNumber != "" && item.CollegeApprovalNumber != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCollegeApprovalNumber", SqlDbType.NVarChar, 30,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.CollegeApprovalNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCollegeApprovalNumber", SqlDbType.NVarChar, 30,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalNumber != null && item.UniversityApprovalNumber != "" && item.UniversityApprovalNumber != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityApprovalNumber", SqlDbType.NVarChar, 30,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.UniversityApprovalNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityApprovalNumber", SqlDbType.NVarChar, 30,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.NatureOfDuty != null && item.NatureOfDuty != "" && item.NatureOfDuty != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNatureOfDuty", SqlDbType.NVarChar, 30,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.NatureOfDuty));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNatureOfDuty", SqlDbType.NVarChar, 30,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BasicAmount != null && item.BasicAmount != 0 )
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nBasicAmount", SqlDbType.Decimal, 17,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.BasicAmount));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nBasicAmount", SqlDbType.Decimal, 17,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ApprovedBy != null && item.ApprovedBy != "" && item.ApprovedBy != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sApprovedBy", SqlDbType.VarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ApprovedBy));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sApprovedBy", SqlDbType.VarChar, 50,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.NewGrade != null && item.NewGrade != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@NewGrade", SqlDbType.Decimal, 17,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.NewGrade));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@NewGrade", SqlDbType.Decimal, 17,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.NewPayscaleID != null && item.NewPayscaleID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iNewPayscaleID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.NewPayscaleID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iNewPayscaleID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.NatureOfAppointment != null && item.NatureOfAppointment != "" && item.NatureOfAppointment != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sNatureOfAppointment", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.NatureOfAppointment));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sNatureOfAppointment", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalType != null && item.UniversityApprovalType != "" && item.UniversityApprovalType != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalType", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.UniversityApprovalType));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalType", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GeneralBoardUniversityID != null && item.GeneralBoardUniversityID !=0)
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
                    if (item.SubjectForApproval != null && item.SubjectForApproval != "" && item.SubjectForApproval != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSubjectForApproval", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.SubjectForApproval));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSubjectForApproval", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GrantedPromotionDate != null && item.GrantedPromotionDate != "" && item.GrantedPromotionDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daGrantedPromotionDate", SqlDbType.Date, 255,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.GrantedPromotionDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daGrantedPromotionDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GrantedPromotionDesignationID != null && item.GrantedPromotionDesignationID !=0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGrantedPromotionDesignationID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.GrantedPromotionDesignationID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGrantedPromotionDesignationID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GrantedPromotionLevel != null && item.GrantedPromotionLevel != "" && item.GrantedPromotionLevel != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sGrantedPromotionLevel", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.GrantedPromotionLevel));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sGrantedPromotionLevel", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.IsCurrentFlag != null )
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsCurrentFlag", SqlDbType.Bit, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.IsCurrentFlag));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsCurrentFlag", SqlDbType.Bit, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.IsActive != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                             ParameterDirection.Input, false, 0, 0, "",
                                             DataRowVersion.Proposed, item.IsActive));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.IsActive));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.CreatedBy));
                    if (item.ID != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCurrentID", SqlDbType.Int, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ID));                 //For updateing current flag 
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCurrentID", SqlDbType.Int, 0,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));     
                    }
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeServiceDetails_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of EmployeeServiceDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeServiceDetails> UpdateEmployeeServiceDetails(EmployeeServiceDetails item)
        {
            IBaseEntityResponse<EmployeeServiceDetails> response = new BaseEntityResponse<EmployeeServiceDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeServiceDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,
                                         ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, item.EmployeeID));
                    //if (item.SequenceNumber != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iSequenceNumber", SqlDbType.Int, 10,
                    //                            ParameterDirection.Input, false, 0, 0, "",
                    //                            DataRowVersion.Proposed, item.SequenceNumber));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iSequenceNumber", SqlDbType.Int, 10,
                    //                                ParameterDirection.Input, false, 0, 0, "",
                    //                                DataRowVersion.Proposed, DBNull.Value));
                    //}
                    if (item.OrderNumber != null && item.OrderNumber != "" && item.OrderNumber != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOrderNumber", SqlDbType.NVarChar, 30,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.OrderNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOrderNumber", SqlDbType.NVarChar, 30,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.OrderDate != null && item.OrderDate != "" && item.OrderDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daOrderDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed,Convert.ToDateTime(item.OrderDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daOrderDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.AcceptedByEmployee != null && item.AcceptedByEmployee != "" && item.AcceptedByEmployee != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAcceptedByEmployee", SqlDbType.Char, 1,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.AcceptedByEmployee));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAcceptedByEmployee", SqlDbType.Char, 1,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PromotionDemotionFlag != null && item.PromotionDemotionFlag != "" && item.PromotionDemotionFlag != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cPromotionDemotionFlag", SqlDbType.Char, 1,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PromotionDemotionFlag));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cPromotionDemotionFlag", SqlDbType.Char, 1,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PromotionDemotionDate != null && item.PromotionDemotionDate != "" && item.PromotionDemotionDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daPromotionDemotionDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed,Convert.ToDateTime( item.PromotionDemotionDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daPromotionDemotionDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PreviousPromotionDemotionDate != null && item.PreviousPromotionDemotionDate != "" && item.PreviousPromotionDemotionDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daPreviousPromotionDemotionDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed,Convert.ToDateTime( item.PreviousPromotionDemotionDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daPreviousPromotionDemotionDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.EmployeeDesignationMasterID != null && item.EmployeeDesignationMasterID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeDesignationMasterID", SqlDbType.Int, 10,
                                         ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, item.EmployeeDesignationMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeDesignationMasterID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    }


                    if (item.CentreCode != null && item.CentreCode != "" && item.CentreCode != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15,
                                                       ParameterDirection.Input, false, 0, 0, "",
                                                       DataRowVersion.Proposed, item.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15,
                                                   ParameterDirection.Input, false, 0, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.DepartmentID != null && item.DepartmentID !=0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 10,
                                         ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, item.DepartmentID));
                    }
                    else
                    {
                         cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.ChargeTakingDate != null && item.ChargeTakingDate != "" && item.ChargeTakingDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daChargeTakingDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed,Convert.ToDateTime( item.ChargeTakingDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daChargeTakingDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.OldDesignationID != null && item.OldDesignationID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOldDesignationID", SqlDbType.Int, 10,
                                       ParameterDirection.Input, false, 0, 0, "",
                                       DataRowVersion.Proposed, item.OldDesignationID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOldDesignationID", SqlDbType.Int, 10,
                                       ParameterDirection.Input, false, 0, 0, "",
                                       DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.OldCentreCode != null && item.OldCentreCode != "" && item.OldCentreCode != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOldCentreCode", SqlDbType.NVarChar, 15,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.OldCentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOldCentreCode", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.OldDepartmentID != null && item.OldDepartmentID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOldDepartmentID", SqlDbType.Int, 10,
                                         ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, item.OldDepartmentID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iOldDepartmentID", SqlDbType.Int, 10,
                                         ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.CollegeApprovalDate != null && item.CollegeApprovalDate != "" && item.CollegeApprovalDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daCollegeApprovalDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.CollegeApprovalDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daCollegeApprovalDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalDate != null && item.UniversityApprovalDate != "" && item.UniversityApprovalDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daUniversityApprovalDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed,Convert.ToDateTime( item.UniversityApprovalDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daUniversityApprovalDate", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CollegeApprovalNumber != null && item.CollegeApprovalNumber != "" && item.CollegeApprovalNumber != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCollegeApprovalNumber", SqlDbType.NVarChar, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.CollegeApprovalNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCollegeApprovalNumber", SqlDbType.NVarChar, 30,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalNumber != null && item.UniversityApprovalNumber != "" && item.UniversityApprovalNumber != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityApprovalNumber", SqlDbType.NVarChar, 30,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.UniversityApprovalNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUniversityApprovalNumber", SqlDbType.NVarChar, 30,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.NatureOfDuty != null && item.NatureOfDuty != "" && item.NatureOfDuty != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sNatureOfDuty", SqlDbType.VarChar, 30,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.NatureOfDuty));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sNatureOfDuty", SqlDbType.Decimal, 17,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BasicAmount != null && item.BasicAmount != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nBasicAmount", SqlDbType.Decimal, 17,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.BasicAmount));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nBasicAmount", SqlDbType.Decimal, 17,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ApprovedBy != null && item.ApprovedBy != "" && item.ApprovedBy != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sApprovedBy", SqlDbType.VarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ApprovedBy));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sApprovedBy", SqlDbType.VarChar, 50,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.NewGrade != null && item.NewGrade != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@NewGrade", SqlDbType.Decimal, 17,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.NewGrade));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@NewGrade", SqlDbType.Decimal, 17,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.NewPayscaleID != null && item.NewPayscaleID != 0)
                    {
                       cmdToExecute.Parameters.Add(new SqlParameter("@iNewPayscaleID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.NewPayscaleID));
                    }
                    else
                    {
                      cmdToExecute.Parameters.Add(new SqlParameter("@iNewPayscaleID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.NatureOfAppointment != null && item.NatureOfAppointment != "" && item.NatureOfAppointment != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sNatureOfAppointment", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.NatureOfAppointment));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sNatureOfAppointment", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UniversityApprovalType != null && item.UniversityApprovalType != "" && item.UniversityApprovalType != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalType", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.UniversityApprovalType));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sUniversityApprovalType", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralBoardUniversityID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.GeneralBoardUniversityID));
                    if (item.SubjectForApproval != null && item.SubjectForApproval != "" && item.SubjectForApproval != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSubjectForApproval", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.SubjectForApproval));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSubjectForApproval", SqlDbType.NVarChar, 255,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GrantedPromotionDate != null && item.GrantedPromotionDate != "" && item.GrantedPromotionDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daGrantedPromotionDate", SqlDbType.Date, 255,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.GrantedPromotionDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daGrantedPromotionDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GrantedPromotionDesignationID != null && item.GrantedPromotionDesignationID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGrantedPromotionDesignationID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.GrantedPromotionDesignationID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGrantedPromotionDesignationID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.GrantedPromotionLevel != null && item.GrantedPromotionLevel != "" && item.GrantedPromotionLevel != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sGrantedPromotionLevel", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.GrantedPromotionLevel));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sGrantedPromotionLevel", SqlDbType.VarChar, 15,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCurrentFlag", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsCurrentFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeServiceDetails_Update' reported the ErrorCode: " +
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
        /// Delete a specific record of EmployeeServiceDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeServiceDetails> DeleteEmployeeServiceDetails(EmployeeServiceDetails item)
        {
            IBaseEntityResponse<EmployeeServiceDetails> response = new BaseEntityResponse<EmployeeServiceDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeServiceDetails_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeServiceDetails_Delete' reported the ErrorCode: " +
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
