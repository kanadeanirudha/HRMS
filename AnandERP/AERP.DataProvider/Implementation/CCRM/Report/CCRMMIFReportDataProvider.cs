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
  public  class CCRMMIFReportDataProvider :DBInteractionBase,ICCRMMIFReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public CCRMMIFReportDataProvider() { }
        public CCRMMIFReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        public IBaseEntityCollectionResponse<CCRMMIFReport> GetCCRMMIFReportBySearch(CCRMMIFReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<CCRMMIFReport> baseEntityCollection = new BaseEntityCollectionResponse<CCRMMIFReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMIFReport_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiStatus", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToByte(searchRequest.Status)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iContractTypeId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ContractTypeId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEngineerID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EngineerID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMAreaPatchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CCRMAreaPatchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCategory", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToByte(searchRequest.Category)));
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

                    baseEntityCollection.CollectionResponse = new List<CCRMMIFReport>();
                    while (sqlDataReader.Read())
                    {
                        CCRMMIFReport item = new CCRMMIFReport();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.InstallationDate = sqlDataReader["InstallationDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["InstallationDate"]);
                        
                        item.MIFTitle = sqlDataReader["MIFTitle"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFTitle"]);
                        item.MIFAddress = sqlDataReader["MIFAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFAddress"]);
                        item.SerialNo = sqlDataReader["SerialNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SerialNo"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.CCRMAreaPatchMasterID = sqlDataReader["CCRMAreaPatchMasterID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["CCRMAreaPatchMasterID"]);
                        item.ContractTypeId = sqlDataReader["ContractTypeId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ContractTypeId"]);
                        item.ContractCode = sqlDataReader["ContractCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractCode"]);
                        item.EngineerID = sqlDataReader["EngineerID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EngineerID"]);
                        //item.CCRMLocationTypeID = sqlDataReader["CCRMLocationTypeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CCRMLocationTypeID"]);
                        //item.MachineFamilyID = sqlDataReader["MachineFamilyID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["MachineFamilyID"]);
                        //item.InstalledById = sqlDataReader["InstalledById"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["InstalledById"]);

                        item.WarantyExpiryDate = sqlDataReader["WarantyExpiryDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["WarantyExpiryDate"]);
                        item.Status = sqlDataReader["Status"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Status"]);
                        item.Category = sqlDataReader["Category"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Category"]);
                        item.PhoneNo = sqlDataReader["PhoneNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PhoneNo"]);
                        item.MobileNo = sqlDataReader["MobileNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MobileNo"]);
                        item.Priority = sqlDataReader["Priority"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Priority"]);
                        item.AreaPatchName = sqlDataReader["AreaPatchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AreaPatchName"]);
                        item.GroupName = sqlDataReader["GroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupName"]);
                        item.LocationTypeCode = sqlDataReader["LocationTypeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationTypeCode"]);
                        item.MachineFamilyName = sqlDataReader["MachineFamilyName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MachineFamilyName"]);
                        item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        item.ContractNo = sqlDataReader["ContractNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNo"]);
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
