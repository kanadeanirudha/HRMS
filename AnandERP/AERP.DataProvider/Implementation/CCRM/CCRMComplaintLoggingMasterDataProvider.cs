using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AERP.DataProvider
{
   public class CCRMComplaintLoggingMasterDataProvider :DBInteractionBase,ICCRMComplaintLoggingMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion
        #region Constructor
        public CCRMComplaintLoggingMasterDataProvider()
        {
        }
        public CCRMComplaintLoggingMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion
        public IBaseEntityResponse<CCRMComplaintLoggingMaster> InsertCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityResponse<CCRMComplaintLoggingMaster> response = new BaseEntityResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMComplaintLoggingMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallDate));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallTypeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SerialNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFName", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MIFName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCompanyCallDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CompanyCallDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCompanyCallNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CompanyCallNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallerName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallerName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallerPh", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallerPh.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nseMail", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EmailID.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSymId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SymptomID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSymCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SymptomCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSymptomTitle", SqlDbType.NVarChar, 255, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SymptomTitle.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsComPlaint", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ComPlaint.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMCStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MachineStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPriority", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Priority));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.A4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.A4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.A3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.A3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dCallCharges", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallCharges));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bCustApproval", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustApproval));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bTeleSol", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TeleSolution));
                 
                    cmdToExecute.Parameters.Add(new SqlParameter("@bSSSApproval", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SSSApproval));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMCAddress", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MCAddress.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomertID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustName", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iKeyOperatorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.KeyOperatorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsKeyOperator", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.KeyOperator.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneno", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Phoneno.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModelNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModelNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iContractTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractTypeId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractType", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractType.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContOpDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContOpDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContClDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContClDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAreaPatchID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EngineerID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnggMobNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EnggMobNo.Trim()));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iComplaintSrNo", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ComplaintSrNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bAllotment", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Allotment));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallStatus));
                    if (item.CallTktNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCallTktNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallTktNo.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCallTktNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Solution != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSloution", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Solution.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSloution", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.SplRemarks != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSplRemarks", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SplRemarks.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSplRemarks", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.SplInstructions != null)
                    {

                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSplInstructions", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SplInstructions.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSplInstructions", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    //************************CCRMMIF************************//
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallerID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMifID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MIFID));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@bCallerFlag", SqlDbType.Bit, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallerFlag));
                   
                   
                    //if (item.KeyOperatorName != null)
                    //{

                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsKeyOperatorName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.KeyOperatorName.Trim()));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsKeyOperatorName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}

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
                        throw new Exception("Stored Procedure 'USP_CCRMComplaintLoggingMaster_Insert' reported the ErrorCode: " +
                                            _errorCode);
                    }


                    //        if (_rowsAffected > 0)
                    //        {
                    //            response.Entity = item;
                    //        }
                    //        else
                    //        {
                    //            response.Message.Add(new MessageDTO
                    //            {
                    //                ErrorMessage = "Create failed"
                    //            });
                    //        }
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
        public IBaseEntityResponse<CCRMComplaintLoggingMaster> UpdateCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityResponse<CCRMComplaintLoggingMaster> response = new BaseEntityResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMComplaintLoggingMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallTktNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallTktNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallTypeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SerialNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFName", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MIFName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCompanyCallDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CompanyCallDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCompanyCallNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CompanyCallNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallerName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallerName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallerPh", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallerPh.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nseMail", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EmailID.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSymId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SymptomID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSymCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SymptomCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSymptomTitle", SqlDbType.NVarChar, 255, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SymptomTitle.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsComPlaint", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ComPlaint.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMCStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MachineStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPriority", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Priority));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.A4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.A4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.A3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.A3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dCallCharges", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallCharges));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bCustApproval", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustApproval));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bTeleSol", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TeleSolution));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bSSSApproval", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SSSApproval));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMCAddress", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MCAddress.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomertID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustName", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iKeyOperatorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.KeyOperatorID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsKeyOperator", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.KeyOperator.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneno", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Phoneno.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModelNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModelNo.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iContractTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractTypeId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractType", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractType.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContOpDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContOpDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContClDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContClDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAreaPatchID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EngineerID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnggMobNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EnggMobNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iComplaintSrNo", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ComplaintSrNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bAllotment", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Allotment));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMifID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MIFID));
                    if (item.Solution != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSloution", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Solution.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSloution", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.SplRemarks != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSplRemarks", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SplRemarks.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSplRemarks", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.SplInstructions != null)
                    {

                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSplInstructions", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SplInstructions.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSplInstructions", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
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
                        throw new Exception("Stored Procedure 'USP_CCRMComplaintLoggingMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMComplaintLoggingMaster> DeleteCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityResponse<CCRMComplaintLoggingMaster> response = new BaseEntityResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMComplaintLoggingMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DeletedBy));
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
                        throw new Exception("Stored Procedure 'USP_CCRMComplaintLoggingMaster_Delete' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggingMasterByID(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityResponse<CCRMComplaintLoggingMaster> response = new BaseEntityResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMComplaintLoggingMaster_SelectOne";
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
                        CCRMComplaintLoggingMaster _item = new CCRMComplaintLoggingMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.CallDate = sqlDataReader["CallDate"].ToString();
                        _item.CallTktNo = sqlDataReader["CallTktNo"].ToString();
                        _item.CallTypeID = Convert.ToInt32(sqlDataReader["CallTypeID"]);
                        _item.SerialNo = sqlDataReader["SerialNo"].ToString();
                        _item.MIFName = sqlDataReader["MIFName"].ToString();
                        _item.CompanyCallDate = sqlDataReader["CompanyCallDate"].ToString();
                        _item.CompanyCallNo = sqlDataReader["CompanyCallNo"].ToString();
                        _item.CallerName = sqlDataReader["CallerName"].ToString();
                        _item.CallerPh = sqlDataReader["CallerPh"].ToString();
                        _item.EmailID = sqlDataReader["EmailID"].ToString();
                        _item.SymptomID = Convert.ToInt32(sqlDataReader["SymptomID"]);
                        _item.SymptomCode = sqlDataReader["SymptomCode"].ToString();
                        _item.SymptomTitle = sqlDataReader["SymptomTitle"].ToString();
                        _item.ComPlaint = sqlDataReader["ComPlaint"].ToString();
                        _item.MachineStatus = Convert.ToByte(sqlDataReader["MachineStatus"]);
                        _item.Priority = Convert.ToByte(sqlDataReader["Priority"]);
                        _item.A4Mono = Convert.ToInt32(sqlDataReader["A4Mono"]);
                        _item.A4Col = Convert.ToInt32(sqlDataReader["A4Col"]);
                        _item.A3Mono = Convert.ToInt32(sqlDataReader["A3Mono"]);
                        _item.A3Col = Convert.ToInt32(sqlDataReader["A3Col"]);
                        _item.CallCharges = Convert.ToDecimal(sqlDataReader["CallCharges"]);
                        _item.CustApproval = Convert.ToBoolean(sqlDataReader["CustApproval"]);
                        _item.TeleSolution = Convert.ToBoolean(sqlDataReader["TeleSolution"]);
                        _item.Solution = sqlDataReader["Solution"].ToString();
                        _item.SSSApproval = Convert.ToBoolean(sqlDataReader["SSSApproval"]);

                        _item.SplRemarks = sqlDataReader["SplRemarks"].ToString();
                        _item.SplInstructions = sqlDataReader["SplInstructions"].ToString();
                        _item.MCAddress = sqlDataReader["MCAddress"].ToString();
                        _item.CustomertID = Convert.ToInt32(sqlDataReader["CustomertID"]);
                        _item.CustomerName = sqlDataReader["CustomerName"].ToString();
                        _item.KeyOperatorID = Convert.ToInt32(sqlDataReader["KeyOperatorID"]);
                        _item.KeyOperator = sqlDataReader["KeyOperator"].ToString();
                        _item.Phoneno = sqlDataReader["Phoneno"].ToString();
                        _item.ModelNo = sqlDataReader["ModelNo"].ToString();
                       // _item.ContractTypeId = Convert.ToInt32(sqlDataReader["ContractTypeId"]);
                        _item.ContractType = sqlDataReader["ContractType"].ToString();
                        _item.ContractNo = sqlDataReader["ContractNo"].ToString();
                        _item.ContOpDate = sqlDataReader["ContOpDate"].ToString();
                        _item.ContClDate = sqlDataReader["ContClDate"].ToString();
                        _item.EngineerID = Convert.ToInt32(sqlDataReader["EngineerID"]);
                        _item.EnggMobNo = sqlDataReader["EnggMobNo"].ToString();
                        _item.ItemDescription = sqlDataReader["ItemDescription"].ToString();
                        _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        _item.AdminRoleMasterID = Convert.ToInt16(sqlDataReader["AdminRoleMasterID"]);
                        _item.RightName = sqlDataReader["RightName"].ToString();
                        _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        _item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        _item.EmployeeName = sqlDataReader["EmployeeName"].ToString();
                        _item.ComplaintSrNo = Convert.ToInt32(sqlDataReader["ComplaintSrNo"]);
                        _item.MIFID = Convert.ToInt32(sqlDataReader["MIFID"]);
                        _item.Allotment = Convert.ToBoolean(sqlDataReader["Allotment"]);
                        _item.CallStatus = Convert.ToByte(sqlDataReader["CallStatus"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMComplaintLoggingMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggingMasterBySearch(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMComplaintLoggingMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
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

                    baseEntityCollection.CollectionResponse = new List<CCRMComplaintLoggingMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMComplaintLoggingMaster item = new CCRMComplaintLoggingMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CallDate = sqlDataReader["CallDate"].ToString();
                        item.CallTypeID = Convert.ToInt32(sqlDataReader["CallTypeID"]);
                        item.MIFName = sqlDataReader["MIFName"].ToString();
                        item.CallTypeName = sqlDataReader["CallTypeName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CCRMComplaintLoggingMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggingMasterList(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMComplaintLoggingMaster_List";
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

                    baseEntityCollection.CollectionResponse = new List<CCRMComplaintLoggingMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMComplaintLoggingMaster item = new CCRMComplaintLoggingMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CompanyCallNo = sqlDataReader["CompanyCallNo"].ToString();
                        item.CallDate = sqlDataReader["CallDate"].ToString();
                        item.CompanyCallDate = sqlDataReader["CompanyCallDate"].ToString();
                        item.EngineerID = Convert.ToInt32(sqlDataReader["EngineerID"]);
                        item.A4Mono = Convert.ToInt32(sqlDataReader["A4Mono"]);
                        item.A4Col = Convert.ToInt32(sqlDataReader["A4Col"]);
                        item.ComPlaint = sqlDataReader["ComPlaint"].ToString();
                        item.SymptomTitle = sqlDataReader["SymptomTitle"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMComplaintLoggingMaster_List' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetListOfPriviousCallByID(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMComplaintLoggingMaster_GetListOfPriviousCallByID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CCRMComplaintLoggingMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<CCRMComplaintLoggingMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMComplaintLoggingMaster item = new CCRMComplaintLoggingMaster();

                        //item.CustomerContactPersonName = sqlDataReader["CustomerContactPersonName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerContactPersonName"]);
                        item.CallTktNo = sqlDataReader["CallTktNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallTktNo"]);
                        item.CallDate = sqlDataReader["CallDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallDate"]);
                        item.CompanyCallDate = sqlDataReader["CompanyCallDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CompanyCallDate"]);
                        item.EngineerID = sqlDataReader["EngineerID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EngineerID"]);

                        item.ComPlaint = sqlDataReader["ComPlaint"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ComPlaint"]);
                        item.SymptomTitle = sqlDataReader["SymptomTitle"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SymptomTitle"]);
                        item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        item.AdminRoleMasterID = sqlDataReader["AdminRoleMasterID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["AdminRoleMasterID"]);
                        item.RightName = sqlDataReader["RightName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RightName"]);
                        item.EmployeeID = sqlDataReader["EmployeeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        item.EmployeeCode = sqlDataReader["EmployeeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeCode"]);
                        item.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);

                        item.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMComplaintLoggingMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMCallerSearchList(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCCRMComplaintLoggingMasterCallerName_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));

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

                    baseEntityCollection.CollectionResponse = new List<CCRMComplaintLoggingMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMComplaintLoggingMaster item = new CCRMComplaintLoggingMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CallerName = sqlDataReader["CallerName"].ToString();
                        item.CallerPh = sqlDataReader["CallerPh"].ToString();
                        item.EmailID = sqlDataReader["EmailID"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMCCRMComplaintLoggingMasterCallerName_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggingMasterSearchList(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMComplaintLoggingMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallTktNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CallTktNo.Trim()));
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
                    baseEntityCollection.CollectionResponse = new List<CCRMComplaintLoggingMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMComplaintLoggingMaster item = new CCRMComplaintLoggingMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CallerName = sqlDataReader["CallerName"].ToString();
                        item.CallerPh = sqlDataReader["CallerPh"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMComplaintLoggingMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetDeviceToken(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetDeviceToken";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                  //  cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CCRMComplaintLoggingMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<CCRMComplaintLoggingMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMComplaintLoggingMaster item = new CCRMComplaintLoggingMaster();

                        item.DeviceToken = sqlDataReader["DeviceToken"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeviceToken"]);
                        item.Latitude = sqlDataReader["Latitude"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Latitude"]);
                        item.Longitude = sqlDataReader["Longitude"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Longitude"]);
                        item.EngineerID = sqlDataReader["EngineerID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EngineerID"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetDeviceToken' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggedByList(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMComplaintLoggedBy_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<CCRMComplaintLoggingMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMComplaintLoggingMaster item = new CCRMComplaintLoggingMaster();
                        item.UserID = Convert.ToInt32(sqlDataReader["UserID"]);
                        item.UserName = sqlDataReader["UserName"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMComplaintLoggedBy_SearchList' reported the ErrorCode: " + _errorCode);
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
