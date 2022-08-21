using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
   public class CCRMCallLogReportDataProvider:DBInteractionBase,ICCRMCallLogReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public CCRMCallLogReportDataProvider() { }
        public CCRMCallLogReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        public IBaseEntityCollectionResponse<CCRMCallLogReport> GetCCRMCallLogReportBySearch(CCRMCallLogReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<CCRMCallLogReport> baseEntityCollection = new BaseEntityCollectionResponse<CCRMCallLogReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCallLogReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMIFType", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToByte(searchRequest.MIFType)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iContractTypeId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ContractTypeId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEngineerID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EngineerID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallTypeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CallTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMLocationTypeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CCRMLocationTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bSCNSubmitted", SqlDbType.Bit, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToByte(searchRequest.SCNSubmitted)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AllotUserID));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLoggID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LoggID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallStatus", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToByte(searchRequest.CallStatus)));
                    if (searchRequest.SerialNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SerialNo));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMAreaPatchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CCRMAreaPatchMasterID));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@tiCategory", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToByte(searchRequest.Category)));
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

                    baseEntityCollection.CollectionResponse = new List<CCRMCallLogReport>();
                    while (sqlDataReader.Read())
                    {
                        CCRMCallLogReport item = new CCRMCallLogReport();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                     
                        item.MIFName = sqlDataReader["MIFName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFName"]);
                        item.CallTktNo = sqlDataReader["CallTktNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallTktNo"]);
                        item.SerialNo = sqlDataReader["SerialNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SerialNo"]);
                        item.ContractNo = sqlDataReader["ContractNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNo"]);
                        item.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        item.Priority = sqlDataReader["Priority"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Priority"]);
                        item.CallDate = sqlDataReader["CallDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallDate"]);
                        item.EngineerID = sqlDataReader["EngineerID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EngineerID"]);
                        item.ContractTypeId = sqlDataReader["ContractTypeId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ContractTypeId"]);
                        item.CallTypeID = sqlDataReader["CallTypeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CallTypeID"]);
                        item.Allotment = sqlDataReader["Allotment"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Allotment"]);
                        item.ContractCode = sqlDataReader["ContractCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractCode"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.CallTypeCode = sqlDataReader["CallTypeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallTypeCode"]);
                        item.MIFType = sqlDataReader["MIFType"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["MIFType"]);
                        item.AreaPatchName = sqlDataReader["AreaPatchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AreaPatchName"]);
                        item.LocationType = sqlDataReader["LocationType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationType"]);
                        item.AllotEnggName = sqlDataReader["AllotEnggName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AllotEnggName"]);
                        item.AllotDate = sqlDataReader["AllotDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AllotDate"]);
                        item.UserID = sqlDataReader["UserID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["UserID"]);
                        item.UserName = sqlDataReader["UserName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UserName"]);
                        item.AllotPeriod = sqlDataReader["AllotPeriod"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["AllotPeriod"]);
                        item.CallerName = sqlDataReader["CallerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallerName"]);
                        item.CallerPh = sqlDataReader["CallerPh"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallerPh"]);
                        item.CallStatus = sqlDataReader["CallStatus"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallStatus"]);
                        item.A4Mono = sqlDataReader["A4Mono"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["A4Mono"]);
                        item.A4Col = sqlDataReader["A4Col"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["A4Col"]);
                        item.A3Mono = sqlDataReader["A3Mono"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["A3Mono"]);
                        item.A3Col = sqlDataReader["A3Col"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["A3Col"]);
                        
                        item.EmailID = sqlDataReader["EmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmailID"]);
                        item.SplRemarks = sqlDataReader["SplRemarks"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SplRemarks"]);
                        item.MachineFamilyName = sqlDataReader["MachineFamilyName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MachineFamilyName"]);
                        item.ArrivalDate = sqlDataReader["ArrivalDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ArrivalDate"]);
                        item.CompletionDate = sqlDataReader["CompletionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CompletionDate"]);
                        item.ArrivalPeriod = sqlDataReader["ArrivalPeriod"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ArrivalPeriod"]);
                        item.CompletionPeriod = sqlDataReader["CompletionPeriod"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CompletionPeriod"]);
                        item.TotalDownTime = sqlDataReader["TotalDownTime"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalDownTime"]);
                        item.ReasonCode = sqlDataReader["ReasonCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ReasonCode"]);
                        item.BrokenReason = sqlDataReader["BrokenReason"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BrokenReason"]);
                        item.SymptomCode = sqlDataReader["SymptomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SymptomCode"]);
                        item.CauseCode = sqlDataReader["CauseCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CauseCode"]);
                        item.ActionCode = sqlDataReader["ActionCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ActionCode"]);
                        item.SCNSubmitted = sqlDataReader["SCNSubmitted"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SCNSubmitted"]);

                        item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                      
                        item.AdminRoleMasterID = sqlDataReader["AdminRoleMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        item.RightName = sqlDataReader["RightName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RightName"]);
                        item.EmployeeID = sqlDataReader["EmployeeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeID"]);

                        item.EmployeeCode = sqlDataReader["EmployeeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeCode"]);
                        item.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);


                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
    }
}
