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
    public class CCRMContractMasterDataProvider :DBInteractionBase ,ICCRMContractMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion
        #region Constructor
        public CCRMContractMasterDataProvider()
        {
        }
        public CCRMContractMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion
        public IBaseEntityResponse<CCRMContractMaster> InsertCCRMContractMaster(CCRMContractMaster item)
        {
            IBaseEntityResponse<CCRMContractMaster> response = new BaseEntityResponse<CCRMContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iFinancialyearID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FinancialyearID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iContractTypeId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractTypeId));
                   
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModelNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModelNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFName", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MIFName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MIFAddress.Trim()));

                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerAddress.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsColour", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Colour.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPaperSize", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaperSize.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractOpDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractOpDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractClosingDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractClosingDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustOrderNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustOrderNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustOrderDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustOrderDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siBillTypeId", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BillTypeId));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsBillType", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BillType.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiContractStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartReadA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.StartReadA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartReadA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.StartReadA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartReadA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.StartReadA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartReadA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.StartReadA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dRentPerCopyA4Mono", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RentPerCopyA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dRentPerCopyA4Col", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RentPerCopyA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dRentPerCopyA3Mono", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RentPerCopyA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dRentPerCopyA3Col", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RentPerCopyA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFreeCopiesA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FreeCopiesA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFreeCopiesA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FreeCopiesA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFreeCopiesA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FreeCopiesA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFreeCopiesA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FreeCopiesA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMinCopiesA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MinCopiesA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMinCopiesA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MinCopiesA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMinCopiesA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MinCopiesA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMinCopiesA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MinCopiesA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalFreeA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalFreeA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalFreeA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalFreeA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalFreeA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalFreeA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalFreeA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalFreeA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInitFreeCopiesA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InitFreeCopiesA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInitFreeCopiesA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InitFreeCopiesA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInitFreeCopiesA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InitFreeCopiesA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInitFreeCopiesA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InitFreeCopiesA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dContractValue", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractValue));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dBilledValue", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BilledValue));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dRentalAmt", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RentalAmt));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dWastePerc", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.WastePerc));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dAnnualCharges", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AnnualCharges));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiApplicableMonth", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ApplicableMonth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dBasicCharges", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BasicCharges));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPMPeriod", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PMPeriod));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallsAllowed", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallsAllowed));
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerName", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (item.ContractNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsContractNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractNo.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsContractNo", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Remarks != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Remarks));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.SerialNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SerialNo.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

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
                        throw new Exception("Stored Procedure 'USP_CCRMContractMaster_Insert' reported the ErrorCode: " +
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
        public IBaseEntityResponse<CCRMContractMaster> UpdateCCRMContractMaster(CCRMContractMaster item)
        {
            IBaseEntityResponse<CCRMContractMaster> response = new BaseEntityResponse<CCRMContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iFinancialyearID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FinancialyearID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iContractTypeId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractTypeId));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SerialNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModelNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModelNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFName", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MIFName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MIFAddress.Trim()));


                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerAddress.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsColour", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Colour.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPaperSize", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaperSize.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractOpDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractOpDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractClosingDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractClosingDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustOrderNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustOrderNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustOrderDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustOrderDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siBillTypeId", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BillTypeId));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsBillType", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BillType.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiContractStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartReadA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.StartReadA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartReadA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.StartReadA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartReadA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.StartReadA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartReadA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.StartReadA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dRentPerCopyA4Mono", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RentPerCopyA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dRentPerCopyA4Col", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RentPerCopyA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dRentPerCopyA3Mono", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RentPerCopyA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dRentPerCopyA3Col", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RentPerCopyA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFreeCopiesA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FreeCopiesA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFreeCopiesA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FreeCopiesA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFreeCopiesA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FreeCopiesA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFreeCopiesA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FreeCopiesA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMinCopiesA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MinCopiesA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMinCopiesA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MinCopiesA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMinCopiesA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MinCopiesA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMinCopiesA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MinCopiesA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalFreeA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalFreeA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalFreeA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalFreeA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalFreeA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalFreeA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalFreeA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalFreeA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInitFreeCopiesA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InitFreeCopiesA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInitFreeCopiesA4Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InitFreeCopiesA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInitFreeCopiesA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InitFreeCopiesA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInitFreeCopiesA3Col", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InitFreeCopiesA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dContractValue", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContractValue));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dBilledValue", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BilledValue));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dRentalAmt", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RentalAmt));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dWastePerc", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.WastePerc));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dAnnualCharges", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AnnualCharges));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiApplicableMonth", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ApplicableMonth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dBasicCharges", SqlDbType.Decimal, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BasicCharges));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPMPeriod", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PMPeriod));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallsAllowed", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallsAllowed));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerName", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    if (item.Remarks != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Remarks));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

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
                        throw new Exception("Stored Procedure 'USP_CCRMContractMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMContractMaster> DeleteCCRMContractMaster(CCRMContractMaster item)
        {
            IBaseEntityResponse<CCRMContractMaster> response = new BaseEntityResponse<CCRMContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractMaster_Delete";
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
                        throw new Exception("Stored Procedure 'USP_CCRMContractMaster_Delete' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMContractMaster> GetCCRMContractMasterByID(CCRMContractMaster item)
        {
            IBaseEntityResponse<CCRMContractMaster> response = new BaseEntityResponse<CCRMContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractMaster_SelectOne";
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
                        CCRMContractMaster _item = new CCRMContractMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.FinancialyearID = Convert.ToInt32(sqlDataReader["FinancialyearID"]);
                       // _item.ContractDate = Convert.ToString(sqlDataReader["ContractDate"]);
                        _item.ContractDate = sqlDataReader["ContractDate"].ToString();
                        _item.ContractTypeId = Convert.ToInt32(sqlDataReader["ContractTypeId"]);
                        _item.ContractNo = sqlDataReader["ContractNo"].ToString();
                        _item.SerialNo = sqlDataReader["SerialNo"].ToString();
                        _item.ModelNo = sqlDataReader["ModelNo"].ToString();
                        _item.MIFName = sqlDataReader["MIFName"].ToString();
                        _item.MIFAddress = sqlDataReader["MIFAddress"].ToString();
                       // _item.CustomerCode = sqlDataReader["CustomerCode"].ToString();
                        _item.CustomerMasterID = Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        _item.CustomerAddress = sqlDataReader["CustomerAddress"].ToString();
                        _item.Colour = sqlDataReader["Colour"].ToString();
                        _item.PaperSize = sqlDataReader["PaperSize"].ToString();
                        _item.ContractOpDate = sqlDataReader["ContractOpDate"].ToString();
                        _item.ContractClosingDate = sqlDataReader["ContractClosingDate"].ToString();
                        _item.CustOrderNo = sqlDataReader["CustOrderNo"].ToString();
                        _item.CustOrderDate = sqlDataReader["CustOrderDate"].ToString();
                        _item.BillTypeId = Convert.ToInt32(sqlDataReader["BillTypeId"]);
                        //_item.BillType = sqlDataReader["BillType"].ToString();
                        _item.ContractStatus = Convert.ToByte(sqlDataReader["ContractStatus"]);
                        _item.StartReadA4Mono = Convert.ToInt32(sqlDataReader["StartReadA4Mono"]);
                        _item.StartReadA4Col = Convert.ToInt32(sqlDataReader["StartReadA4Col"]);
                        _item.StartReadA3Mono = Convert.ToInt32(sqlDataReader["StartReadA3Mono"]);
                        _item.StartReadA3Col = Convert.ToInt32(sqlDataReader["StartReadA3Col"]);
                        _item.RentPerCopyA4Mono = Convert.ToDecimal(sqlDataReader["RentPerCopyA4Mono"]);
                        _item.RentPerCopyA4Col = Convert.ToDecimal(sqlDataReader["RentPerCopyA4Col"]);
                        _item.RentPerCopyA3Mono = Convert.ToDecimal(sqlDataReader["RentPerCopyA3Mono"]);
                        _item.RentPerCopyA3Col = Convert.ToDecimal(sqlDataReader["RentPerCopyA3Col"]);
                        _item.FreeCopiesA4Mono = Convert.ToInt32(sqlDataReader["FreeCopiesA4Mono"]);
                        _item.FreeCopiesA4Col = Convert.ToInt32(sqlDataReader["FreeCopiesA4Col"]);
                        _item.FreeCopiesA3Mono = Convert.ToInt32(sqlDataReader["FreeCopiesA3Mono"]);
                        _item.FreeCopiesA3Col = Convert.ToInt32(sqlDataReader["FreeCopiesA3Col"]);
                        _item.MinCopiesA4Mono = Convert.ToInt32(sqlDataReader["MinCopiesA4Mono"]);
                        _item.MinCopiesA4Col = Convert.ToInt32(sqlDataReader["MinCopiesA4Col"]);
                        _item.MinCopiesA3Mono = Convert.ToInt32(sqlDataReader["MinCopiesA3Mono"]);
                        _item.MinCopiesA3Col = Convert.ToInt32(sqlDataReader["MinCopiesA3Col"]);
                        _item.TotalFreeA4Mono = Convert.ToInt32(sqlDataReader["TotalFreeA4Mono"]);
                        _item.TotalFreeA4Col = Convert.ToInt32(sqlDataReader["TotalFreeA4Col"]);
                        _item.TotalFreeA3Mono = Convert.ToInt32(sqlDataReader["TotalFreeA3Mono"]);
                        _item.TotalFreeA3Col = Convert.ToInt32(sqlDataReader["TotalFreeA3Col"]);
                        _item.InitFreeCopiesA4Mono = Convert.ToInt32(sqlDataReader["InitFreeCopiesA4Mono"]);
                        _item.InitFreeCopiesA4Col = Convert.ToInt32(sqlDataReader["InitFreeCopiesA4Col"]);
                        _item.InitFreeCopiesA3Mono = Convert.ToInt32(sqlDataReader["InitFreeCopiesA3Mono"]);
                        _item.InitFreeCopiesA3Col = Convert.ToInt32(sqlDataReader["InitFreeCopiesA3Col"]);
                        _item.ContractValue = Convert.ToDecimal(sqlDataReader["ContractValue"]);
                        _item.BilledValue = Convert.ToDecimal(sqlDataReader["BilledValue"]);
                        _item.RentalAmt = Convert.ToDecimal(sqlDataReader["RentalAmt"]);
                        _item.WastePerc = Convert.ToDecimal(sqlDataReader["WastePerc"]);
                        _item.AnnualCharges = Convert.ToDecimal(sqlDataReader["AnnualCharges"]);
                        _item.ApplicableMonth = Convert.ToByte(sqlDataReader["ApplicableMonth"]);
                        _item.BasicCharges = Convert.ToDecimal(sqlDataReader["BasicCharges"]);
                        _item.PMPeriod = Convert.ToInt32(sqlDataReader["PMPeriod"]);
                        _item.CallsAllowed = Convert.ToInt32(sqlDataReader["CallsAllowed"]);
                        _item.Remarks = sqlDataReader["Remarks"].ToString();
                        _item.CustomerName = sqlDataReader["CustomerName"].ToString();
                        _item.ItemDescription = sqlDataReader["ItemDescription"].ToString();
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMContractMaster> GetCCRMContractMasterBySearch(CCRMContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractMaster_SelectAll";
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

                    baseEntityCollection.CollectionResponse = new List<CCRMContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMContractMaster item = new CCRMContractMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.ContractTypeId = Convert.ToInt32(sqlDataReader["ContractTypeId"]);
                     
                        item.ContractNo = sqlDataReader["ContractNo"].ToString();
                        item.SerialNo = sqlDataReader["SerialNo"].ToString();
                        item.ContractName = sqlDataReader["ContractName"].ToString();
                        //item.ActionDesciption = sqlDataReader["ActionDesciption"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CCRMContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
