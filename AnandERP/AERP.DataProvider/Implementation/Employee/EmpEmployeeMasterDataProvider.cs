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
    public class EmpEmployeeMasterDataProvider : DBInteractionBase, IEmpEmployeeMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmpEmployeeMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmpEmployeeMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EmpEmployeeMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmpEmployeeMasterBySearch(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.-";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEntityLevel", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EntityLevel));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        {
                            item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeCode"]) == false)
                        {
                            item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                        {
                            item.EmailID = sqlDataReader["EmailID"].ToString();
                        }
                        //item.OtherEmailID = sqlDataReader["OtherEmailID"].ToString();
                        //item.NameTitle = sqlDataReader["NameTitle"].ToString();		
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                            item.EmployeeMiddleName  = sqlDataReader["EmployeeMiddleName"].ToString();
                        }
                        //item.EmployeeMiddleName  = sqlDataReader["EmployeeMiddleName"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                            item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
                        }
                        //item.NickName = sqlDataReader["NickName"].ToString();
                        //item.IsEmployeeSmoker = Convert.ToBoolean(sqlDataReader["IsEmployeeSmoker"]);
                        //item.EthanicRaceCode = sqlDataReader["EthanicRaceCode"].ToString();
                        //item.Birthdate = Convert.ToDateTime(sqlDataReader["Birthdate"]);
                        //item.NationalityID = Convert.ToInt32(sqlDataReader["NationalityID"]);
                        if (DBNull.Value.Equals(sqlDataReader["GenderCode"]) == false)
                        {
                            item.GenderCode = sqlDataReader["GenderCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        {
                            item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentrewiseDeptID"]) == false)
                        {
                            item.CentrewiseDeptID = Convert.ToInt32(sqlDataReader["CentrewiseDeptID"]);
                        }
                        //item.MarritalStaus = sqlDataReader["MarritalStaus"].ToString();
                        //item.SSNNumber = sqlDataReader["SSNNumber"].ToString();
                        //item.SINNumber = sqlDataReader["SINNumber"].ToString();
                        //item.DrivingLicenceNumber = sqlDataReader["DrivingLicenceNumber"].ToString();
                        //item.DrivingLicenceExpireDate=Convert.ToDateTime(sqlDataReader["DrivingLicenceExpireDate"]);
                        //item.TelephoneNumber = sqlDataReader["TelephoneNumber"].ToString();
                        //item.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                        //item.PanNumber = sqlDataReader["PanNumber"].ToString();
                        //item.ESINumber = sqlDataReader["ESINumber"].ToString();
                        //item.ProvidentFundNumber = sqlDataReader["ProvidentFundNumber"].ToString();
                        //item.ProvidentFundApplicableDate=Convert.ToDateTime(sqlDataReader["ProvidentFundApplicableDate"]);
                        //item.BankACNumber = sqlDataReader["BankACNumber"].ToString();
                        //item.EmployeeShiftApplicableMasterID = Convert.ToInt32(sqlDataReader["EmployeeShiftApplicableMasterID"]);
                        //item.SalaryGradeCode = sqlDataReader["SalaryGradeCode"].ToString();
                        //item.JoiningDate=Convert.ToDateTime(sqlDataReader["JoiningDate"]);
                        //item.DateOfLeaving=Convert.ToDateTime(sqlDataReader["DateOfLeaving"]);
                        //item.DateOfRetirment=Convert.ToDateTime(sqlDataReader["DateOfRetirment"]);
                        //item.TerminationID = Convert.ToInt32(sqlDataReader["TerminationID"]);
                        //item.TerminationDate=Convert.ToDateTime(sqlDataReader["TerminationDate"]);
                        //item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        //item.EmployeeDesignationMasterID = Convert.ToInt32(sqlDataReader["EmployeeDesignationMasterID"]);
                        //item.JobStatusID = Convert.ToInt32(sqlDataReader["JobStatusID"]);
                        //item.JobStatus = sqlDataReader["JobStatus"].ToString();
                        //item.JobProfileID = Convert.ToInt32(sqlDataReader["JobProfileID"]);
                        //item.BasicSalary = Convert.ToDecimal(sqlDataReader["BasicSalary"]);
                        //item.UserRemark = sqlDataReader["UserRemark"].ToString();
                        //item.ReasonOfLeaving = sqlDataReader["ReasonOfLeaving"].ToString();
                        //item.EmployeeType = sqlDataReader["EmployeeType"].ToString();
                        //item.PayScaleMstID = Convert.ToInt32(sqlDataReader["PayScaleMstID"]);
                        //item.PaymentMode  = sqlDataReader["PaymentMode"].ToString();
                        //item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //item.EmployeeNameAsPerTC = sqlDataReader["EmployeeNameAsPerTC"].ToString();
                        //item.MaidenFirstName = sqlDataReader["MaidenFirstName"].ToString();
                        //item.MaidenMiddleName = sqlDataReader["MaidenMiddleName"].ToString();
                        //item.MaidenLastName = sqlDataReader["MaidenLastName"].ToString();
                        //item.IsNameChangedBefore = sqlDataReader["IsNameChangedBefrore"].ToString();
                        //item.PriorFirstName = sqlDataReader["PriorFirstName"].ToString();
                        //item.PriorMiddleName = sqlDataReader["PriorMiddleName"].ToString();
                        //item.PriorLastName = sqlDataReader["PriorLastName"].ToString();
                        //item.BioMatrixEmployeeID = Convert.ToInt32(sqlDataReader["BioMatrixEmployeeID"]);
                        //item.AdharCardNumber = sqlDataReader["AdharCardNumber"].ToString();
                        //item.EnquiryLevelID = Convert.ToInt32(sqlDataReader["EnquiryLevelID"]);
                        //item.ActiveCommissionID = Convert.ToInt32(sqlDataReader["ActiveCommissionID"]);					
                        //item.custom1 = sqlDataReader["custom1"].ToString();
                        //item.custom2 = sqlDataReader["custom2"].ToString();
                        //item.custom3 = sqlDataReader["custom3"].ToString();
                        //item.custom4 = sqlDataReader["custom4"].ToString();
                        //item.custom5 = sqlDataReader["custom5"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLeave"]) == false)
                        {
                            item.IsLeave = Convert.ToBoolean(sqlDataReader["IsLeave"]);
                        }
                        //item.InActiveReason = sqlDataReader["InActiveReason"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_EmpEmployeeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmpEmployeeMaster> GetEmpEmployeeMasterByID(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> response = new BaseEntityResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_SelectOne";
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
                        EmpEmployeeMaster _item = new EmpEmployeeMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeCode"]) == false)
                        {
                            _item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                        {
                            _item.EmailID = sqlDataReader["EmailID"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OtherEmailID"]) == false)
                        {
                            _item.OtherEmailID = sqlDataReader["OtherEmailID"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["NameTitle"]) == false)
                        {
                            _item.NameTitle = sqlDataReader["NameTitle"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AppointmentApprovalDate"]) == false)
                        {
                            _item.AppointmentApprovalDate = sqlDataReader["AppointmentApprovalDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            _item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                            _item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                            _item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NickName"]) == false)
                        {
                            _item.NickName = sqlDataReader["NickName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEmployeeSmoker"]) == false)
                        {
                            _item.IsEmployeeSmoker = Convert.ToBoolean(sqlDataReader["IsEmployeeSmoker"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EthanicRaceCode"]) == false)
                        {
                            _item.EthanicRaceCode = sqlDataReader["EthanicRaceCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Birthdate"]) == false)
                        {
                            _item.Birthdate = sqlDataReader["Birthdate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NationalityID"]) == false)
                        {
                            _item.NationalityID = Convert.ToInt32(sqlDataReader["NationalityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GenderCode"]) == false)
                        {
                            _item.GenderCode = sqlDataReader["GenderCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MarritalStaus"]) == false)
                        {
                            _item.MarritalStaus = sqlDataReader["MarritalStaus"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SSNNumber"]) == false)
                        {
                            _item.SSNNumber = sqlDataReader["SSNNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SINNumber"]) == false)
                        {
                            _item.SINNumber = sqlDataReader["SINNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DrivingLicenceNumber"]) == false)
                        {
                            _item.DrivingLicenceNumber = sqlDataReader["DrivingLicenceNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DrivingLicenceExpireDate"]) == false)
                        {
                            _item.DrivingLicenceExpireDate = sqlDataReader["DrivingLicenceExpireDate"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["PanNumber"]) == false)
                        {
                            _item.PanNumber = sqlDataReader["PanNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ESINumber"]) == false)
                        {
                            _item.ESINumber = sqlDataReader["ESINumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ProvidentFundNumber"]) == false)
                        {
                            _item.ProvidentFundNumber = sqlDataReader["ProvidentFundNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ProvidentFundApplicableDate"]) == false)
                        {
                            _item.ProvidentFundApplicableDate = sqlDataReader["ProvidentFundApplicableDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UANNumber"]) == false)
                        {
                            _item.UANNumber= sqlDataReader["UANNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankACNumber"]) == false)
                        {
                            _item.BankACNumber = sqlDataReader["BankACNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IFSCCode"]) == false)
                        {
                            _item.IFSCCode = sqlDataReader["IFSCCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeShiftApplicableMasterID"]) == false)
                        {
                            _item.EmployeeShiftApplicableMasterID = Convert.ToInt32(sqlDataReader["EmployeeShiftApplicableMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SalaryGradeCode"]) == false)
                        {
                            _item.SalaryGradeCode = sqlDataReader["SalaryGradeCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JoiningDate"]) == false)
                        {
                            _item.JoiningDate = sqlDataReader["JoiningDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DateOfLeaving"]) == false)
                        {
                            _item.DateOfLeaving = sqlDataReader["DateOfLeaving"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DateOfRetirment"]) == false)
                        {
                            _item.DateOfRetirment = sqlDataReader["DateOfRetirment"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TerminationID"]) == false)
                        {
                            _item.TerminationID = Convert.ToInt32(sqlDataReader["TerminationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TerminationDate"]) == false)
                        {
                            _item.TerminationDate = sqlDataReader["TerminationDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        {
                            _item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDesignationMasterID"]) == false)
                        {
                            _item.EmployeeDesignationMasterID = Convert.ToInt32(sqlDataReader["EmployeeDesignationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDesignation"]) == false)
                        {
                            _item.EmployeeDesignation = Convert.ToString(sqlDataReader["EmployeeDesignation"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobStatusID"]) == false)
                        {
                            _item.JobStatusID = Convert.ToInt32(sqlDataReader["JobStatusID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobStatus"]) == false)
                        {
                            _item.JobStatus = sqlDataReader["JobStatus"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobProfileID"]) == false)
                        {
                            _item.JobProfileID = Convert.ToInt32(sqlDataReader["JobProfileID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BasicSalary"]) == false)
                        {
                            _item.BasicSalary = Convert.ToDecimal(sqlDataReader["BasicSalary"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UserRemark"]) == false)
                        {
                            _item.UserRemark = sqlDataReader["UserRemark"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReasonOfLeaving"]) == false)
                        {
                            _item.ReasonOfLeaving = sqlDataReader["ReasonOfLeaving"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeType"]) == false)
                        {
                            _item.EmployeeType = sqlDataReader["EmployeeType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PayScaleMstID"]) == false)
                        {
                            _item.PayScaleMstID = Convert.ToInt32(sqlDataReader["PayScaleMstID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaymentMode"]) == false)
                        {
                            _item.PaymentMode = sqlDataReader["PaymentMode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeNameAsPerTC"]) == false)
                        {
                            _item.EmployeeNameAsPerTC = sqlDataReader["EmployeeNameAsPerTC"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaidenFirstName"]) == false)
                        {
                            _item.MaidenFirstName = sqlDataReader["MaidenFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaidenMiddleName"]) == false)
                        {
                            _item.MaidenMiddleName = sqlDataReader["MaidenMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaidenLastName"]) == false)
                        {
                            _item.MaidenLastName = sqlDataReader["MaidenLastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsNameChangedBefore"]) == false)
                        {
                            _item.IsNameChangedBefore = Convert.ToBoolean(sqlDataReader["IsNameChangedBefore"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PriorFirstName"]) == false)
                        {
                            _item.PriorFirstName = sqlDataReader["PriorFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PriorMiddleName"]) == false)
                        {
                            _item.PriorMiddleName = sqlDataReader["PriorMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PriorLastName"]) == false)
                        {
                            _item.PriorLastName = sqlDataReader["PriorLastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BioMatrixEmployeeID"]) == false)
                        {
                            _item.BioMatrixEmployeeID = Convert.ToInt32(sqlDataReader["BioMatrixEmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdharCardNumber"]) == false)
                        {
                            _item.AdharCardNumber = sqlDataReader["AdharCardNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EnquiryLevelID"]) == false)
                        {
                            _item.EnquiryLevelID = Convert.ToInt32(sqlDataReader["EnquiryLevelID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActiveCommissionID"]) == false)
                        {
                            _item.ActiveCommissionID = Convert.ToInt32(sqlDataReader["ActiveCommissionID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["custom1"]) == false)
                        {
                            _item.custom1 = sqlDataReader["custom1"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["custom2"]) == false)
                        {
                            _item.custom2 = sqlDataReader["custom2"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["custom3"]) == false)
                        {
                            _item.custom3 = sqlDataReader["custom3"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["custom4"]) == false)
                        {
                            _item.custom4 = sqlDataReader["custom4"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["custom5"]) == false)
                        {
                            _item.custom5 = sqlDataReader["custom5"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLeave"]) == false)
                        {
                            _item.IsLeave = Convert.ToBoolean(sqlDataReader["IsLeave"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InActiveReason"]) == false)
                        {
                            _item.InActiveReason = sqlDataReader["InActiveReason"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        {
                            _item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobProfileDescription"]) == false)
                        {
                            _item.JobProfileDescription = sqlDataReader["JobProfileDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobStatusDescription"]) == false)
                        {
                            _item.JobStatusDescription = sqlDataReader["JobStatusDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Nationality"]) == false)
                        {
                            _item.Nationality = sqlDataReader["Nationality"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrencyCode"]) == false)
                        {
                            _item.CurrencyCode = sqlDataReader["CurrencyCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IMEI"]) == false)
                        {
                            _item.IMEI = sqlDataReader["IMEI"].ToString();
                        }

                        _item.IsExemptedEmployee = Convert.ToBoolean(sqlDataReader["IsExemptedEmployee"]);

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
        public IBaseEntityResponse<EmpEmployeeMaster> InsertEmpEmployeeMaster(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> response = new BaseEntityResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;



                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNameTitle", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.NameTitle != null ? item.NameTitle.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cGenderCode", SqlDbType.Char, 1,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.GenderCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeFirstName", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeFirstName != null ? item.EmployeeFirstName.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeMiddleName", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeMiddleName != null ? item.EmployeeMiddleName.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeLastName", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeLastName != null ? item.EmployeeLastName.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmailID != null ? item.EmailID.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CentreCode != null ? item.CentreCode.Trim() : string.Empty));
                    if (item.Birthdate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.Date, 15,
                            ParameterDirection.Input, false, 10, 0, "",
                            DataRowVersion.Proposed, Convert.ToDateTime(item.Birthdate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.Date, 15,
                            ParameterDirection.Input, false, 10, 0, "",
                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    if ((item.EmployeeCode == null)|| (item.EmployeeCode == ""))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeCode", SqlDbType.NVarChar, 20,
                            ParameterDirection.Input, false, 10, 0, "",
                            DataRowVersion.Proposed,DBNull.Value ));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeCode", SqlDbType.NVarChar, 20,
                            ParameterDirection.Input, false, 10, 0, "",
                            DataRowVersion.Proposed, item.EmployeeCode));
                    }
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.Date, 15,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.Birthdate != null ? Convert.ToDateTime(item.Birthdate) : DBNull.Value.ToString()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCentrewiseDeptID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.CentrewiseDeptID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeDesignationMasterID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeDesignationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, true));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                           ParameterDirection.Output, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 10,
                                           ParameterDirection.Output, false, 0, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 10,
                                           ParameterDirection.Output, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.Status));
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmpEmployeeMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of EmpEmployeeMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMaster(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> response = new BaseEntityResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeCode ", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.EmployeeCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.EmailID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sOtherEmailID", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.OtherEmailID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsNameTitle", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.NameTitle));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sMrOrMrs ", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MrOrMrs));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeFirstName ", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.EmployeeFirstName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeMiddleName ", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.EmployeeMiddleName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeLastName ", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.EmployeeLastName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sNickName", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.NickName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsEmployeeSmoker", SqlDbType.Bit, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.IsEmployeeSmoker));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsEthanicRaceCode", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.EthanicRaceCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.date, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.Birthdate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iNationalityID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.NationalityID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@cGenderCode", SqlDbType.Char, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.GenderCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@cMarritalStaus", SqlDbType.Char, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MarritalStaus));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@cSSNNumber", SqlDbType.Char, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.SSNNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@cSINNumber", SqlDbType.Char, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.SINNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsDrivingLicenceNumber", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.DrivingLicenceNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.date, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.DrivingLicenceExpireDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sTelephoneNumber", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.TelephoneNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sMobileNumber", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MobileNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.numeric, 18,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.PanNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sESINumber", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.ESINumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sProvidentFundNumber", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.ProvidentFundNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.date, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.ProvidentFundApplicableDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sBankACNumber", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.BankACNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeShiftApplicableMasterID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.EmployeeShiftApplicableMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sSalaryGradeCode", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.SalaryGradeCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.date, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.JoiningDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.date, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.DateOfLeaving));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.date, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.DateOfRetirment));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iTerminationID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.TerminationID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.date, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.TerminationDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.DepartmentID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeDesignationMasterID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.EmployeeDesignationMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iJobStatusID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.JobStatusID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sJobStatus", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.JobStatus));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iJobProfileID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.JobProfileID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.money, 19,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.BasicSalary));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sUserRemark", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.UserRemark));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sReasonOfLeaving", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.ReasonOfLeaving));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@cEmployeeType", SqlDbType.Char, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.EmployeeType));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iPayScaleMstID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.PayScaleMstID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@cPaymentMode ", SqlDbType.Char, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.PaymentMode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sCentreCode", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.CentreCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeNameAsPerTC", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.EmployeeNameAsPerTC));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsMaidenFirstName", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MaidenFirstName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsMaidenMiddleName", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MaidenMiddleName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsMaidenLastName", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.MaidenLastName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@cIsNameChangedBefrore", SqlDbType.Char, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.IsNameChangedBefrore));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsPriorFirstName", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.PriorFirstName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsPriorMiddleName", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.PriorMiddleName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsPriorLastName", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.PriorLastName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iBioMatrixEmployeeID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.BioMatrixEmployeeID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sAdharCardNumber", SqlDbType.VarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.AdharCardNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEnquiryLevelID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.EnquiryLevelID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iActiveCommissionID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.ActiveCommissionID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bActiveFlag ", SqlDbType.Bit, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.ActiveFlag));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nscustom1", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.custom1));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nscustom2", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.custom2));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nscustom3", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.custom3));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nscustom4", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.custom4));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nscustom5", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.custom5));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.IsActive));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsInActiveReason", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.InActiveReason));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                    //                    ParameterDirection.Input, true, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.ModifiedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                    //                        ParameterDirection.Output, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, _errorCode));
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmpEmployeeMaster_Delete' reported the ErrorCode: " +
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
        /// Update a specific record of EmpEmployeeMasterPersonal Information
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMasterPersonalInformation(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> response = new BaseEntityResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMasterPersonalInformation_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmployeeCode ", SqlDbType.VarChar, 20,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.EmployeeCode));
                    if (item.EmailID == null || item.EmailID == "" || item.EmailID == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 100,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmailID.Trim()));
                    }
                    if (item.OtherEmailID == null || item.OtherEmailID == "" || item.OtherEmailID == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOtherEmailID", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOtherEmailID", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OtherEmailID.Trim()));
                    }
                    if (item.NameTitle == null || item.NameTitle == "" || item.NameTitle == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNameTitle", SqlDbType.NVarChar, 50,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNameTitle", SqlDbType.NVarChar, 50,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.NameTitle.Trim()));
                    }


                    if (item.EmployeeFirstName == null || item.EmployeeFirstName == "" || item.EmployeeFirstName == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeFirstName ", SqlDbType.NVarChar, 30,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeFirstName", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeFirstName.Trim()));
                    }
                    if (item.EmployeeMiddleName == null || item.EmployeeMiddleName == "" || item.EmployeeMiddleName == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeMiddleName", SqlDbType.NVarChar, 30,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeMiddleName", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeMiddleName.Trim()));
                    }
                    if (item.EmployeeLastName == null || item.EmployeeLastName == "" || item.EmployeeLastName == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeLastName ", SqlDbType.NVarChar, 30,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeLastName ", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeLastName.Trim()));
                    }
                    if (item.NickName == null || item.NickName == "" || item.NickName == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNickName", SqlDbType.NVarChar, 10,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNickName", SqlDbType.NVarChar, 10,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.NickName.Trim()));
                    }
                    if (item.IsEmployeeSmoker == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsEmployeeSmoker", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsEmployeeSmoker", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.IsEmployeeSmoker));
                    }
                    if (item.EthanicRaceCode == null || item.EthanicRaceCode == "" || item.EthanicRaceCode == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEthanicRaceCode", SqlDbType.NVarChar, 50,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEthanicRaceCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EthanicRaceCode.Trim()));
                    }
                    if (item.Birthdate == null || item.Birthdate == "" || item.Birthdate == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daBirthdate", SqlDbType.Date, 0,
                                          ParameterDirection.Input, false, 0, 0, "",
                                          DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daBirthdate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.Birthdate)));
                    }
                    if (item.NationalityID == null || item.NationalityID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iNationalityID", SqlDbType.Int, 10,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iNationalityID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.NationalityID));
                    }
                    if (item.GenderCode == null || item.GenderCode == "" || item.GenderCode == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cGenderCode", SqlDbType.Char, 1,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cGenderCode", SqlDbType.Char, 1,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.GenderCode.Trim()));
                    }
                    if (item.MarritalStaus == null || item.MarritalStaus == "" || item.MarritalStaus == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cMarritalStaus", SqlDbType.Char, 1,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cMarritalStaus", SqlDbType.Char, 1,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MarritalStaus.Trim()));
                    }
                    if (item.EmployeeNameAsPerTC == null || item.EmployeeNameAsPerTC == "" || item.EmployeeNameAsPerTC == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeNameAsPerTC", SqlDbType.NVarChar, 200,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeNameAsPerTC", SqlDbType.NVarChar, 200,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmployeeNameAsPerTC.Trim()));
                    }
                    if (item.MaidenFirstName == null || item.MaidenFirstName == "" || item.MaidenFirstName == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMaidenFirstName", SqlDbType.NVarChar, 50,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMaidenFirstName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MaidenFirstName.Trim()));
                    }
                    if (item.MaidenMiddleName == null || item.MaidenMiddleName == "" || item.MaidenMiddleName == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMaidenMiddleName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMaidenMiddleName", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.MaidenMiddleName.Trim()));
                    }
                    if (item.MaidenLastName == null || item.MaidenLastName == "" || item.MaidenLastName == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMaidenLastName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMaidenLastName", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.MaidenLastName.Trim()));
                    }
                    if (item.IsNameChangedBefore == false)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsNameChangedBefore", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsNameChangedBefore", SqlDbType.Bit, 1,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, true));
                    }
                    if (item.PriorFirstName == null || item.PriorFirstName == "" || item.PriorFirstName == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPriorFirstName", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPriorFirstName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PriorFirstName.Trim()));
                    }
                    if (item.PriorMiddleName == null || item.PriorMiddleName == "" || item.PriorMiddleName == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPriorMiddleName", SqlDbType.NVarChar, 50,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPriorMiddleName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PriorMiddleName.Trim()));
                    }
                    if (item.PriorLastName == null || item.PriorLastName == "" || item.PriorLastName == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPriorLastName", SqlDbType.NVarChar, 50,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPriorLastName", SqlDbType.NVarChar, 50,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.PriorLastName.Trim()));
                    }
                    if (item.IMEI == null || item.IMEI == "" || item.IMEI == string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIMEI", SqlDbType.NVarChar, 15,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIMEI", SqlDbType.NVarChar, 15,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.IMEI.Trim()));
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmpEmployeeMasterPersonalInformation_Update' reported the ErrorCode: " +
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
        /// Update a specific record of EmpEmployeeMaster Office Details
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMasterOfficeDetails(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> response = new BaseEntityResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMasterOfficeDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    if (item.SSNNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cSSNNumber", SqlDbType.Char, 30,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cSSNNumber", SqlDbType.Char, 30,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, item.SSNNumber.Trim()));
                    }
                    if (item.SINNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cSINNumber", SqlDbType.Char, 100,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cSINNumber", SqlDbType.Char, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.SINNumber.Trim()));
                    }
                    if (item.DrivingLicenceNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDrivingLicenceNumber", SqlDbType.NVarChar, 25,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDrivingLicenceNumber", SqlDbType.NVarChar, 25,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.DrivingLicenceNumber.Trim()));
                    }
                    if (item.DrivingLicenceExpireDate == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDrivingLicenceExpireDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDrivingLicenceExpireDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.DrivingLicenceExpireDate)));
                    }
                    if (item.PanNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPanNumber", SqlDbType.NVarChar, 20,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPanNumber", SqlDbType.NVarChar, 20,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.PanNumber.Trim()));
                    }
                    if (item.ESINumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsESINumber", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsESINumber", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ESINumber.Trim()));
                    }
                    if (item.ProvidentFundNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsProvidentFundNumber", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsProvidentFundNumber", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ProvidentFundNumber.Trim()));
                    }
                    if (item.ProvidentFundApplicableDate == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daProvidentFundApplicableDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daProvidentFundApplicableDate", SqlDbType.Date, 0,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, Convert.ToDateTime(item.ProvidentFundApplicableDate)));
                    }
                    if (item.UANNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUANNumber", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUANNumber", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.UANNumber.Trim()));
                    }
                    if (item.BankACNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankACNumber", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankACNumber", SqlDbType.NVarChar, 50,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.BankACNumber.Trim()));
                    }
                    if (item.IFSCCode == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFSCCode", SqlDbType.NVarChar, 25,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFSCCode", SqlDbType.NVarChar, 25,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.IFSCCode.Trim()));
                    }

                    if (item.EmployeeShiftApplicableMasterID == null || item.EmployeeShiftApplicableMasterID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeShiftApplicableMasterID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeShiftApplicableMasterID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.EmployeeShiftApplicableMasterID));
                    }
                    if (item.SalaryGradeCode == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSalaryGradeCode", SqlDbType.NVarChar, 50,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSalaryGradeCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.SalaryGradeCode.Trim()));
                    }
                    if (item.AppointmentApprovalDate == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daAppointmentApprovalDate", SqlDbType.Date, 0,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daAppointmentApprovalDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.AppointmentApprovalDate)));
                    }
                    if (item.JoiningDate == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daJoiningDate", SqlDbType.Date, 0,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daJoiningDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.JoiningDate)));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLeave", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsLeave));
                    if (item.DateOfLeaving == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfLeaving", SqlDbType.Date, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfLeaving", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.DateOfLeaving)));
                    }
                    if (item.DateOfRetirment == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfRetirment", SqlDbType.Date, 0,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfRetirment", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.DateOfRetirment)));
                    }
                    if (item.TerminationID == null || item.TerminationID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iTerminationID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iTerminationID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.TerminationID));
                    }
                    if (item.TerminationDate == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daTerminationDate", SqlDbType.Date, 0,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daTerminationDate", SqlDbType.Date, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.TerminationDate)));
                    }
                    if (item.DepartmentID == null || item.DepartmentID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.DepartmentID));
                    }
                    if (item.EmployeeDesignationMasterID == null || item.EmployeeDesignationMasterID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeDesignationMasterID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeDesignationMasterID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.EmployeeDesignationMasterID));
                    }
                    if (item.JobStatusID == null || item.JobStatusID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iJobStatusID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iJobStatusID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.JobStatusID));
                    }
                    if (item.JobStatus == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sJobStatus", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sJobStatus", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.JobStatus.Trim()));
                    }
                    if (item.JobProfileID == null || item.JobProfileID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iJobProfileID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iJobProfileID", SqlDbType.Int, 10,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.JobProfileID));
                    }
                    if (item.BasicSalary == null || item.BasicSalary == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mBasicSalary", SqlDbType.Money, 19,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mBasicSalary", SqlDbType.Money, 19,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.BasicSalary));
                    }
                    if (item.UserRemark == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUserRemark", SqlDbType.NVarChar, 255,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUserRemark", SqlDbType.NVarChar, 255,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.UserRemark.Trim()));
                    }
                    if (item.ReasonOfLeaving == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsReasonOfLeaving", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsReasonOfLeaving", SqlDbType.NVarChar, 0,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.ReasonOfLeaving.Trim()));
                    }
                    if (item.PayScaleMstID == null || item.PayScaleMstID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iPayScaleMstID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iPayScaleMstID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.PayScaleMstID));
                    }
                    if (item.PaymentMode == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cPaymentMode", SqlDbType.Char, 0,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cPaymentMode", SqlDbType.Char, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PaymentMode));
                    }
                    if (item.CentreCode == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CentreCode.Trim()));
                    }
                    if (item.BioMatrixEmployeeID == null || item.BioMatrixEmployeeID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iBioMatrixEmployeeID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iBioMatrixEmployeeID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.BioMatrixEmployeeID));
                    }
                    if (item.AdharCardNumber == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAdharCardNumber", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAdharCardNumber", SqlDbType.NVarChar, 0,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.AdharCardNumber.Trim()));
                    }
                    if (item.EnquiryLevelID == null || item.EnquiryLevelID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEnquiryLevelID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEnquiryLevelID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.EnquiryLevelID));
                    }
                    if (item.ActiveCommissionID == null || item.ActiveCommissionID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iActiveCommissionID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iActiveCommissionID", SqlDbType.Int, 10,
                                               ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.ActiveCommissionID));
                    }
                    if (item.custom1 == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nscustom1", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nscustom1", SqlDbType.NVarChar, 0,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.custom1.Trim()));
                    }
                    if (item.custom2 == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nscustom2", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nscustom2", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.custom2.Trim()));
                    }
                    if (item.custom3 == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nscustom3", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nscustom3", SqlDbType.NVarChar, 0,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.custom3.Trim()));
                    }
                    if (item.custom4 == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nscustom4", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nscustom4", SqlDbType.NVarChar, 0,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.custom4.Trim()));
                    }
                    if (item.custom5 == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nscustom5", SqlDbType.NVarChar, 0,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nscustom5", SqlDbType.NVarChar, 0,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.custom5.Trim()));
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmpEmployeeMasterOfficeDetails_Update' reported the ErrorCode: " +
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
        /// Delete a specific record of EmpEmployeeMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmpEmployeeMaster> DeleteEmpEmployeeMaster(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> response = new BaseEntityResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_EmpEmployeeMaster_Delete' reported the ErrorCode: " +
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
        /// Select all record from EmpEmployeeMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_GetEmployeeList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                            item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                            item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFullName"]) == false)
                        {
                            item.EmployeeFullName = sqlDataReader["EmployeeFullName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_EmpEmployeeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from EmpEmployeeMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeCentrewiseSearchList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_GetEmployeeCentrewiseSearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = Convert.ToString(sqlDataReader["EmployeeFirstName"]) + " " + Convert.ToString(sqlDataReader["EmployeeMiddleName"]) + " " + Convert.ToString(sqlDataReader["EmployeeLastName"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        //{
                        //    item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["AdminRoleCode"]) == false)
                        //{
                        //    item.AdminRoleCode = Convert.ToString(sqlDataReader["AdminRoleCode"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmpEmployeeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from EmpEmployeeMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeRoleCentrewiseSearchList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_GetEmployeeRoleCentrewiseSearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFullName"]) == false)
                        {
                            item.EmployeeFullName = Convert.ToString(sqlDataReader["EmployeeFullName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleCode"]) == false)
                        {
                            item.AdminRoleCode = Convert.ToString(sqlDataReader["AdminRoleCode"]);
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
                        throw new Exception("Stored Procedure 'USP_EmpEmployeeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from EmpEmployeeMaster table with search parameters for employee list ByCentreCodeAndDeptID
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetByCentreCodeAndDeptID(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_GetByCenterCodeAndDepartmentWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentId", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["NameTitle"]) == false)
                        {
                            item.NameTitle = sqlDataReader["NameTitle"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFullName"]) == false)
                        {
                            item.EmployeeFullName = sqlDataReader["EmployeeFullName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                            item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                            item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_EmpEmployeeMaster_GetByCenterCodeAndDepartmentWise' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<EmpEmployeeMaster> GetCurrentPassword(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> response = new BaseEntityResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeGetCurrentpassword";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        EmpEmployeeMaster _item = new EmpEmployeeMaster();

                        if (DBNull.Value.Equals(sqlDataReader["Password"]) == false)
                        {
                            _item.Password = sqlDataReader["Password"].ToString();
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

        public IBaseEntityResponse<EmpEmployeeMaster> InsertNewPassword(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> response = new BaseEntityResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeCurrentpassword_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;



                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNewPassword", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.NewPassword != null ? item.NewPassword.Trim() : string.Empty));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 10,
                                           ParameterDirection.Input, false, 0, 0, "",
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
                    // item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EmpEmployeeMaster_Insert' reported the ErrorCode: " +
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
        /// Select all record from EmpEmployeeMaster table with search parameters for Caller employee for CRM
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetCallerEmployeeList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_GetCallerEmployeeList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = Convert.ToString(sqlDataReader["EmployeeFirstName"]) + " " + Convert.ToString(sqlDataReader["EmployeeMiddleName"]) + " " + Convert.ToString(sqlDataReader["EmployeeLastName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
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
                        throw new Exception("Stored Procedure 'USP_EmpEmployeeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetByEmployeeInCRMSales(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_GetEmployeeCRMSaleWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSelectedParamerterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SelectedParamerterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sCRMSaleRecordFor", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CRMSaleRecordFor));
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
                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                            item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                            item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFullName"]) == false)
                        {
                            item.EmployeeFullName = sqlDataReader["EmployeeFullName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDesignation"]) == false)
                        {
                            item.EmployeeDesignation = sqlDataReader["EmployeeDesignation"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        {
                            item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                        {
                            item.EmailID = sqlDataReader["EmailID"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_EmpEmployeeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetListEmpEmployeeMasterForCRMSalesGroup(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_GetEmployeeForCRMSalesGroup";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSelectedParamerterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SelectedParamerterID));
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
                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                            item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                            item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFullName"]) == false)
                        {
                            item.EmployeeFullName = sqlDataReader["EmployeeFullName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDesignation"]) == false)
                        {
                            item.EmployeeDesignation = sqlDataReader["EmployeeDesignation"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        {
                            item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                        {
                            item.EmailID = sqlDataReader["EmailID"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_EmpEmployeeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetListEmpEmployeeMasterForTargetException(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_GetEmployeeForTargetException";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSelectedParamerterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SelectedParamerterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAuthorEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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
                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                            item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                            item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFullName"]) == false)
                        {
                            item.EmployeeFullName = sqlDataReader["EmployeeFullName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDesignation"]) == false)
                        {
                            item.EmployeeDesignation = sqlDataReader["EmployeeDesignation"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        {
                            item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                        {
                            item.EmailID = sqlDataReader["EmailID"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_EmpEmployeeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        //Staff Allocation
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeNameList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpEmployeeMaster_GetEmployeeNameSearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,searchRequest.ID));
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
                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = Convert.ToString(sqlDataReader["EmployeeFirstName"]) + " " + Convert.ToString(sqlDataReader["EmployeeLastName"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        //{
                        //    item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["AdminRoleCode"]) == false)
                        //{
                        //    item.AdminRoleCode = Convert.ToString(sqlDataReader["AdminRoleCode"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmpEmployeeMaster_GetEmployeeNameSearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeDetailsForImportExcel(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmpoyeeMasterDetails_ForExportExcelData";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));
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
                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeName"]) == false)
                        {
                            item.EmployeeName = Convert.ToString(sqlDataReader["EmployeeName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Birthdate"]) == false)
                        {
                            item.DateOfBirth = Convert.ToString(sqlDataReader["Birthdate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["EmployeeCode"]) == false)
                        {
                            item.EmployeeCode = Convert.ToString(sqlDataReader["EmployeeCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JoiningDate"]) == false)
                        {
                            item.JoiningDate = Convert.ToString(sqlDataReader["JoiningDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        {
                            item.DepartmentName = Convert.ToString(sqlDataReader["DepartmentName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDesignation"]) == false)
                        {
                            item.EmployeeDesignation = Convert.ToString(sqlDataReader["EmployeeDesignation"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MobileNumber"]) == false)
                        {
                            item.MobileNumber = Convert.ToString(sqlDataReader["MobileNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankACNumber"]) == false)
                        {
                            item.BankACNumber = Convert.ToString(sqlDataReader["BankACNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PanNumber"]) == false)
                        {
                            item.PanNumber = Convert.ToString(sqlDataReader["PanNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ProvidentFundNumber"]) == false)
                        {
                            item.ProvidentFundNumber = Convert.ToString(sqlDataReader["ProvidentFundNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GenderCode"]) == false)
                        {
                            item.GenderCode = Convert.ToString(sqlDataReader["GenderCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MarritalStaus"]) == false)
                        {
                            item.MarritalStaus = Convert.ToString(sqlDataReader["MarritalStaus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmplyeeExperienceList"]) == false)
                        {
                            item.EmplyeeExperienceList = Convert.ToString(sqlDataReader["EmplyeeExperienceList"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFamilyList"]) == false)
                        {
                            item.EmployeeFamilyList = Convert.ToString(sqlDataReader["EmployeeFamilyList"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NomineeName"]) == false)
                        {
                            item.NomineeName = Convert.ToString(sqlDataReader["NomineeName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdharCardNumber"]) == false)
                        {
                            item.AdharCardNumber = Convert.ToString(sqlDataReader["AdharCardNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UANNumber"]) == false)
                        {
                            item.UANNumber= Convert.ToString(sqlDataReader["UANNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FromYear"]) == false)
                        {
                            item.FromYear = Convert.ToString(sqlDataReader["FromYear"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UptoYear"]) == false)
                        {
                            item.UptoYear = Convert.ToString(sqlDataReader["UptoYear"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NameOfInstitution"]) == false)
                        {
                            item.NameOfInstitution = Convert.ToString(sqlDataReader["NameOfInstitution"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SpecailisationIn"]) == false)
                        {
                            item.SpecailisationIn = Convert.ToString(sqlDataReader["SpecailisationIn"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["YearOfPassing"]) == false)
                        {
                            item.YearOfPassing = Convert.ToString(sqlDataReader["YearOfPassing"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DateOfLeaving"]) == false)
                        {
                            item.DateOfLeaving = Convert.ToString(sqlDataReader["DateOfLeaving"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DateOfRetirment"]) == false)
                        {
                            item.DateOfRetirment = Convert.ToString(sqlDataReader["DateOfRetirment"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TerminationDate"]) == false)
                        {
                            item.TerminationDate = Convert.ToString(sqlDataReader["TerminationDate"]);
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
                        throw new Exception("Stored Procedure 'USP_EmpEmployeeMaster_GetEmployeeNameSearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<EmpEmployeeMaster> GetDataValidationListsForEmployeeMasterExcel(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> response = new BaseEntityResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.[USP_EmployeeMaster_GetDataValidationListsForExcel]";
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

                    while (sqlDataReader.Read())
                    {

                        EmpEmployeeMaster _item = new EmpEmployeeMaster();
                        _item.NameTitle = sqlDataReader["TitleList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TitleList"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeMaster_GetDataValidationListsForExcel' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<EmpEmployeeMaster> InsertEmployeeMasterExcelUpload(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> response = new BaseEntityResponse<EmpEmployeeMaster>();

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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeMaster_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.CommandTimeout = 0;

                    if (item.XMLString != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForEmployeeMaster", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLString));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForEmployeeMaster", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.DepartmentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sCentreCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sErrorMessage", SqlDbType.NVarChar, 50, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.errorMessage));

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

                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    item.errorMessage = cmdToExecute.Parameters["@sErrorMessage"].Value.ToString();
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry && _errorCode != 77)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure '[USP_EmployeeBulkAttendence_InsertXML]' reported the ErrorCode: " + _errorCode);
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
                _errorCode = 18;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
                //_logException.Error(ex.Message);

            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _errorCode = 18;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
                //_logException.Error(ex.Message);
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
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmpEmployeeMasterServiceList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeMasterService_List";
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

                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.AdminRoleMasterID = Convert.ToInt16(sqlDataReader["AdminRoleMasterID"]);

                        item.RightName = sqlDataReader["RightName"].ToString();
                        item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        item.EmployeeName = sqlDataReader["EmployeeName"].ToString();
                        // item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        // item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        // item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeMasterService_List' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmpEmployeeMasterExecutive(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeMasterExecutive_List";
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

                    baseEntityCollection.CollectionResponse = new List<EmpEmployeeMaster>();
                    while (sqlDataReader.Read())
                    {
                        EmpEmployeeMaster item = new EmpEmployeeMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.AdminRoleMasterID = Convert.ToInt16(sqlDataReader["AdminRoleMasterID"]);

                        item.RightName = sqlDataReader["RightName"].ToString();
                        item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        item.EmployeeName = sqlDataReader["EmployeeName"].ToString();
                        // item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        // item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        // item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeMasterExecutive_List' reported the ErrorCode: " + _errorCode);
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
