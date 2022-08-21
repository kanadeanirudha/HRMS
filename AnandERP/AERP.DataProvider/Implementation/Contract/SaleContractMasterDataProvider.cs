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
    public class SaleContractMasterDataProvider : DBInteractionBase, ISaleContractMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SaleContractMasterDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SaleContractMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<SaleContractMaster> GetSaleContractMasterBySearch(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.ID = Convert.ToInt64(sqlDataReader["ID"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);
                        item.SaleContractType = sqlDataReader["SaleContractType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SaleContractType"]);
                        item.Narration = sqlDataReader["Narration"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Narration"]);

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
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractMaster> InsertSaleContractMaster(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> response = new BaseEntityResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsConfidential", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsConfidential));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeMasterID));
                    if (item.Narration != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNarration", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Narration));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNarration", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PurchaseOrderNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumber", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PurchaseOrderNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumber", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PurchaseOrderDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PurchaseOrderDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDisplayPurchaseDetails", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsDisplayPurchaseDetails));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerMasterID));
                    if (item.CustomerBranchMasterID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerContactPersonID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerContactPersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtContractStartDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractStartDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtContractEndDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractEndDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiBillingType", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BillingType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBillingFixedAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BillingFixedAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiFixedBillingType", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedBillingType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFixedBillingForManPowerItemID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedBillingForManPowerItemID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiShortExtraPostingRateAccTo", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ShortExtraPostingRateAccTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsIncludeAllPostingForShortExtraRate", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsIncludeAllPostingForShortExtraRate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiAdditionalAllowancePaidBy", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdditionalAllowancePaidBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMaterialSupplyDay", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MaterialSupplyDay));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiRenewCallBeforeDays", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RenewCallBeforeDays));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMaterialSupplyFixAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MaterialSupplyFixAmount));
                    if (item.SalaryEffectiveFromDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSalaryEffectiveFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalaryEffectiveFromDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSalaryEffectiveFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractStartDate));
                    }
                    if (item.SalaryEffectiveUptoDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSalaryEffectiveUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalaryEffectiveUptoDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSalaryEffectiveUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractEndDate));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiServiceChargesDependOn", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ServiceChargesDependOn));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiServiceChargesCalculateOn", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ServiceChargesCalculateOn));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsInclusiveServiceCharges", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsInclusiveServiceCharges));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsServiceChargesAppliedToAddAmount", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsServiceChargesAppliedToAddAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsServiceChargesAppliedToServiceItem", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsServiceChargesAppliedToServiceItem));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsServiceChargesAppliedToOverTime", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsServiceChargesAppliedToOverTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsRateFixedForRateContract", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsRateFixedForRateContract));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fServiceChargesPercentage", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ServiceChargesPercentage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiOverTimeDependOn", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OverTimeDependOn));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@tiOverTimeDisplayFormat", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OverTimeDisplayFormat));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mFixedAmountForInvoice", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedAmountForInvoice));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mFixedAmountForSalaryCompliance", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedAmountForSalaryCompliance));
                    if (item.XMLstringForOverTime != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTime", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForOverTime));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTime", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForOverTimeFix != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTimeFix", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForOverTimeFix));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTimeFix", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.XMLstringForManPowerServiceCharge != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerServiceCharge", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForManPowerServiceCharge));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerServiceCharge", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForManPowerServiceChargeForHead != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerServiceChargeForHead", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForManPowerServiceChargeForHead));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerServiceChargeForHead", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.XMLstringForManPowerItem != null && item.XMLstringForAssignedEmployee != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForManPowerItem));
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForAssignedEmployee", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForAssignedEmployee));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForAssignedEmployee", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForContractMaterial != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForContractMaterial", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForContractMaterial));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForContractMaterial", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForMachine != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForMachine", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForMachine));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForMachine", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForJobWorkItem != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForJobWorkItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForJobWorkItem));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForJobWorkItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForFixItem != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForFixItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForFixItem));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForFixItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForServiceItem != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForServiceItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForServiceItem));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForServiceItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleID)); 
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractNumber", SqlDbType.NVarChar, 30, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ContractNumber));
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
                        item.ID = (Int64)cmdToExecute.Parameters["@iID"].Value;
                        item.ContractNumber = (String)cmdToExecute.Parameters["@nsContractNumber"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != 15)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_Insert' reported the ErrorCode: " +
                                            _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetContractNumberSearchList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_SearchContractNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.ID = Convert.ToInt64(sqlDataReader["ID"]);
                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractMaster> GetGeneralContractDetails(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> response = new BaseEntityResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetGeneralContractDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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

                        SaleContractMaster _item = new SaleContractMaster();

                        _item.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        _item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        _item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        _item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        _item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        _item.CustomerContactPersonID = sqlDataReader["ContactPersonID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ContactPersonID"]);
                        _item.CustomerContactPersonName = sqlDataReader["CustomerContactPersonName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerContactPersonName"]);
                        _item.ContractStartDate = sqlDataReader["ContractStartDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractStartDate"]);
                        _item.ContractEndDate = sqlDataReader["ContractEndDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractEndDate"]);
                        _item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        _item.BillingType = sqlDataReader["BillingType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["BillingType"]);
                        _item.BillingFixedAmount = sqlDataReader["BillingFixedAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillingFixedAmount"]);
                        _item.FixedBillingType = sqlDataReader["FixedBillingType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["FixedBillingType"]);
                        _item.FixedBillingForManPowerItemID = sqlDataReader["FixedBillingForManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["FixedBillingForManPowerItemID"]);
                        _item.FixedBillingForManPowerItemName = sqlDataReader["FixedBillingForManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FixedBillingForManPowerItemName"]);
                        _item.ShortExtraPostingRateAccTo = sqlDataReader["ShortExtraPostingRateAccTo"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ShortExtraPostingRateAccTo"]);
                        _item.IsConfidential = sqlDataReader["IsConfidential"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsConfidential"]);
                        _item.IsIncludeAllPostingForShortExtraRate = sqlDataReader["IsIncludeAllPostingForShortExtraRate"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsIncludeAllPostingForShortExtraRate"]);
                        _item.EmployeeMasterID = sqlDataReader["EmployeeMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeMasterID"]);
                        _item.EmployeeMasterName = sqlDataReader["EmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeMasterName"]);
                        _item.Narration = sqlDataReader["Narration"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Narration"]);
                        _item.PurchaseOrderNumber = sqlDataReader["PurchaseOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        _item.PurchaseOrderDate = sqlDataReader["PurchaseOrderDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderDate"]);
                        _item.IsDisplayPurchaseDetails= sqlDataReader["IsDisplayPurchaseDetails"] is DBNull ? false: Convert.ToBoolean(sqlDataReader["IsDisplayPurchaseDetails"]);

                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractEmployeeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractMaster> GetTermDetailsData(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> response = new BaseEntityResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetTermDetailsData";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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

                        SaleContractMaster _item = new SaleContractMaster();

                        _item.SaleContractTermDetailsID = sqlDataReader["SaleContractTermDetailsID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractTermDetailsID"]);
                        _item.AdditionalAllowancePaidBy = sqlDataReader["AdditionalAllowancePaidBy"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["AdditionalAllowancePaidBy"]);
                        _item.MaterialSupplyDay = sqlDataReader["MaterialSupplyDay"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["MaterialSupplyDay"]);
                        _item.RenewCallBeforeDays = sqlDataReader["RenewCallBeforeDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["RenewCallBeforeDays"]);
                        _item.MaterialSupplyFixAmount = sqlDataReader["MaterialSupplyFixAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["MaterialSupplyFixAmount"]);
                        _item.ServiceChargesDependOn = sqlDataReader["ServiceChargesDependOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ServiceChargesDependOn"]);
                        _item.ServiceChargesCalculateOn = sqlDataReader["ServiceChargesCalculateOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ServiceChargesCalculateOn"]);
                        _item.IsInclusiveServiceCharges = sqlDataReader["IsInclusiveServiceCharges"] is DBNull ? false : Convert.ToBoolean(sqlDataReader
                            ["IsInclusiveServiceCharges"]);
                        _item.IsServiceChargesAppliedToAddAmount = sqlDataReader["IsServiceChargesAppliedToAddAmount"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsServiceChargesAppliedToAddAmount"]);
                        _item.IsServiceChargesAppliedToServiceItem = sqlDataReader["IsServiceChargesAppliedToServiceItem"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsServiceChargesAppliedToServiceItem"]);
                        _item.IsServiceChargesAppliedToOverTime = sqlDataReader["IsServiceChargesAppliedToOverTime"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsServiceChargesAppliedToOverTime"]);
                        _item.IsRateFixedForRateContract = sqlDataReader["IsRateFixedForRateContract"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsRateFixedForRateContract"]);
                        _item.SalaryEffectiveFromDate = sqlDataReader["SalaryEffectiveFromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader
                            ["SalaryEffectiveFromDate"]);
                        _item.SalaryEffectiveUptoDate = sqlDataReader["SalaryEffectiveUptoDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader
                            ["SalaryEffectiveUptoDate"]);
                        _item.ServiceChargesPercentage = sqlDataReader["ServiceChargesPercentage"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader
                             ["ServiceChargesPercentage"]);
                        _item.OverTimeDependOn = sqlDataReader["OverTimeDependOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["OverTimeDependOn"]);
                        //_item.OverTimeDisplayFormat = sqlDataReader["OverTimeDisplayFormat"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["OverTimeDisplayFormat"]);
                        //_item.SaleContractOvertimeID = sqlDataReader["SaleContractOvertimeID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractOvertimeID"]);
                        //_item.FixedAmountForInvoice = sqlDataReader["FixedAmountForInvoice"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FixedAmountForInvoice"]);
                        //_item.FixedAmountForSalaryCompliance = sqlDataReader["FixedAmountForSalaryCompliance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FixedAmountForSalaryCompliance"]);

                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractEmployeeMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetManPowerItemList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetManPowerItemList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.SaleContractRequirementDetailsID = sqlDataReader["SaleContractRequirementDetailsID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractRequirementDetailsID"]);
                        item.Gender = sqlDataReader["Gender"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Gender"]);
                        item.SaleContractManPowerItemRequired = sqlDataReader["SaleContractManPowerItemRequired"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["SaleContractManPowerItemRequired"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.SaleContractManPowerItemName = sqlDataReader["SaleContractManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemName"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.IsSalaryDaysCountFix = sqlDataReader["IsSalaryDaysCountFix"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsSalaryDaysCountFix"]);
                        item.FixedDays = sqlDataReader["FixedDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["FixedDays"]);
                        item.IsSalaryDaysOnWeeklyOff = sqlDataReader["IsSalaryDaysOnWeeklyOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsSalaryDaysOnWeeklyOff"]);
                        item.FixedRate = sqlDataReader["FixedRate"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedRate"]), 2);
                        item.IsBillingDaysFixed = sqlDataReader["IsBillingDaysFixed"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsBillingDaysFixed"]);
                        item.FixedBillingDays = sqlDataReader["FixedBillingDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["FixedBillingDays"]);
                        item.IsBillingDaysOnWeeklyOff = sqlDataReader["IsBillingDaysOnWeeklyOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsBillingDaysOnWeeklyOff"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetAssignedEmployeeList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetAssignedEmployeeList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.SaleContractRequirementDetailsID = sqlDataReader["SaleContractRequirementDetailsID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractRequirementDetailsID"]);
                        item.SaleContractManPowerAssignID = sqlDataReader["SaleContractManPowerAssignID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractManPowerAssignID"]);
                        item.Gender = sqlDataReader["Gender"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Gender"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.SaleContractManPowerItemName = sqlDataReader["SaleContractManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemName"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.EmployeeShiftMasterID = sqlDataReader["EmployeeShiftMasterID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["EmployeeShiftMasterID"]);
                        item.EmployeeShiftMasterName = sqlDataReader["EmployeeShiftMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeShiftMasterName"]);
                        item.ManPowerAssignFromDate = sqlDataReader["ManPowerAssignFromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ManPowerAssignFromDate"]);
                        item.IsActive = sqlDataReader["IsActive"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsActive"]);
                        item.SaleContractEmployeeAdditionalAmount = sqlDataReader["AdditionalAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["AdditionalAmount"]);
                        item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetContractMaterialList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetContractMaterialList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetMachineMasterList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetMachineMasterList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.SaleContractRequirementDetailsID = sqlDataReader["SaleContractRequirementDetailsID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractRequirementDetailsID"]);
                        item.SaleContractMachineAssignID = sqlDataReader["SaleContractMachineAssignID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractMachineAssignID"]);
                        item.SaleContractMachineMasterRate = sqlDataReader["SaleContractMachineMasterRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SaleContractMachineMasterRate"]);
                        item.SaleContractMachineMasterID = sqlDataReader["SaleContractMachineMasterID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SaleContractMachineMasterID"]);
                        item.SaleContractMachineMasterName = sqlDataReader["SaleContractMachineMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractMachineMasterName"]);
                        item.SaleContractMachineMasterSerialNumber = sqlDataReader["SaleContractMachineMasterSerialNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractMachineMasterSerialNumber"]);
                        item.MachineAssignFromDate = sqlDataReader["MachineAssignFromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MachineAssignFromDate"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetJobWorkItemList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetJobWorkItemList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.SaleContractRequirementDetailsID = sqlDataReader["SaleContractRequirementDetailsID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractRequirementDetailsID"]);
                        item.SaleContractJobWorkItemRate = sqlDataReader["SaleContractJobWorkItemRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SaleContractJobWorkItemRate"]);
                        item.SaleContractJobWorkItemID = sqlDataReader["SaleContractJobWorkItemID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SaleContractJobWorkItemID"]);
                        item.SaleContractJobWorkItemName = sqlDataReader["SaleContractJobWorkItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractJobWorkItemName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetFixItemList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetFixItemList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.SaleContractRequirementDetailsID = sqlDataReader["SaleContractRequirementDetailsID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractRequirementDetailsID"]);
                        item.SaleContractFixItemQuantity = sqlDataReader["SaleContractFixItemQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SaleContractFixItemQuantity"]);
                        item.SaleContractFixItemRate = sqlDataReader["SaleContractFixItemRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SaleContractFixItemRate"]);
                        item.SaleContractFixItemID = sqlDataReader["SaleContractFixItemID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SaleContractFixItemID"]);
                        item.SaleContractFixItemName = sqlDataReader["SaleContractFixItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractFixItemName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetServiceChargeList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetServiceChargeList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractTermDetailsID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractTermDetailsID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.SaleContractManPowerItemName = sqlDataReader["SaleContractManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemName"]);
                        item.ServiceChargesFixAmount = sqlDataReader["ChargeAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ChargeAmount"]);
                        item.ServiceChargesFromDate = sqlDataReader["FromEffectiveDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromEffectiveDate"]);
                        item.ServiceChargesUptoDate = sqlDataReader["UptoDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UptoDate"]);
                        item.SaleContractServiceChargeOnManPowerItemID = sqlDataReader["SaleContractServiceChargeOnManPowerItemID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractServiceChargeOnManPowerItemID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetServiceChargeOnAllowanceList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetServiceChargeOnAllowanceList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractTermDetailsID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractTermDetailsID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.ReferenceID = sqlDataReader["ReferenceID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ReferenceID"]);
                        item.CalculateOnName = sqlDataReader["CalculateOnName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnName"]);
                        item.AllowanceOrDeduction = sqlDataReader["AllowanceOrDeduction"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["AllowanceOrDeduction"]);
                        item.SelectedStatusFlag = sqlDataReader["SelectedStatusFlag"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SelectedStatusFlag"]);
                        item.ServiceChargeOnSalaryHeadsID = sqlDataReader["ServiceChargeOnSalaryHeadsID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ServiceChargeOnSalaryHeadsID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetOverTimeList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetOverTimeList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.SalaryAllowanceMasterID = sqlDataReader["SalaryAllowanceMasterID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SalaryAllowanceMasterID"]);
                        item.SalaryAllowanceMasterName = sqlDataReader["SalaryAllowanceMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalaryAllowanceMasterName"]);
                        item.ForInvoiceOrSalaryCompliance = sqlDataReader["ForInvoiceOrSalaryCompliance"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ForInvoiceOrSalaryCompliance"]);
                        item.BasicOrAllowance = sqlDataReader["BasicOrAllowance"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["BasicOrAllowance"]);
                        item.OverTimeFromDate = sqlDataReader["FromEffectiveDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromEffectiveDate"]);
                        item.OverTimeUptoDate = sqlDataReader["UptoDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UptoDate"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.SaleContractManPowerItemName = sqlDataReader["SaleContractManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemName"]);
                        item.SaleContractOvertimeSumOfID = sqlDataReader["SaleContractOvertimeSumOfID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractOvertimeSumOfID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetOverTimeFixList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetOverTimeFixList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.SaleContractManPowerItemName = sqlDataReader["SaleContractManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemName"]);
                        item.FixedAmountForInvoice = sqlDataReader["FixedAmountForInvoice"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FixedAmountForInvoice"]);
                        item.FixedAmountForSalaryCompliance = sqlDataReader["FixedAmountForSalaryCompliance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FixedAmountForSalaryCompliance"]);
                        item.SaleContractOvertimeID = sqlDataReader["SaleContractOvertimeID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractOvertimeID"]);
                        item.IsOverTimeDaysFix = sqlDataReader["IsOverTimeDaysFix"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOverTimeDaysFix"]);
                        item.OTFixedDays = sqlDataReader["OTFixedDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["OTFixedDays"]);
                        item.IsOTDaysOnTotalOff = sqlDataReader["IsOTDaysOnTotalOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOTDaysOnTotalOff"]);
                        item.IsOverTimeBillingDaysFix = sqlDataReader["IsOverTimeBillingDaysFix"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOverTimeBillingDaysFix"]);
                        item.OTBillingFixedDays = sqlDataReader["OTBillingFixedDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["OTBillingFixedDays"]);
                        item.IsOTBillingDaysOnTotalOff = sqlDataReader["IsOTBillingDaysOnTotalOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOTBillingDaysOnTotalOff"]);
                        item.OverTimeDisplayFormat = sqlDataReader["OverTimeDisplayFormat"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["OverTimeDisplayFormat"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetServiceItemList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_GetServiceItemList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.SaleContractRequirementDetailsID = sqlDataReader["SaleContractRequirementDetailsID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractRequirementDetailsID"]);
                        item.SaleContractServiceItemNumber = sqlDataReader["SaleContractServiceItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractServiceItemNumber"]);
                        item.SaleContractServiceItemName = sqlDataReader["SaleContractServiceItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractServiceItemName"]);
                        item.SaleContractServiceItemRate = sqlDataReader["SaleContractServiceItemRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SaleContractServiceItemRate"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetContractNumberSearchListByCustomer(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_SearchContractNumberByCustomer";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, searchRequest.CustomerBranchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractMaster>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractMaster item = new SaleContractMaster();

                        item.ID = Convert.ToInt64(sqlDataReader["ID"]);
                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractMaster> ModifySaleContractMaster(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> response = new BaseEntityResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_Modify";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeMasterID));
                    if (item.Narration != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNarration", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Narration));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNarration", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PurchaseOrderNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumber", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PurchaseOrderNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumber", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PurchaseOrderDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PurchaseOrderDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDisplayPurchaseDetails", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsDisplayPurchaseDetails));
                    if (item.XMLstringForManPowerServiceCharge != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerServiceCharge", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForManPowerServiceCharge));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerServiceCharge", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.XMLstringForOverTime != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTime", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForOverTime));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTime", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForOverTimeFix != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTimeFix", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForOverTimeFix));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTimeFix", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForManPowerItem != null && item.XMLstringForAssignedEmployee != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForManPowerItem));
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForAssignedEmployee", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForAssignedEmployee));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForAssignedEmployee", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.XMLstringForMachine != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForMachine", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForMachine));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForMachine", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForJobWorkItem != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForJobWorkItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForJobWorkItem));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForJobWorkItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForFixItem != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForFixItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForFixItem));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForFixItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForServiceItem != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForServiceItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForServiceItem));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForServiceItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_Insert' reported the ErrorCode: " +
                                            _errorCode);
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

        public IBaseEntityResponse<SaleContractMaster> ExtendSaleContractMaster(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> response = new BaseEntityResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_Extend";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dtContractEndDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractEndDate));

                    if (item.SalaryEffectiveUptoDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSalaryEffectiveUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalaryEffectiveUptoDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSalaryEffectiveUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractEndDate));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_Insert' reported the ErrorCode: " +
                                            _errorCode);
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

        public IBaseEntityResponse<SaleContractMaster> SaleContractMasterShiftEmployee(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> response = new BaseEntityResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_ShiftEmployee";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));

                    if (item.XMLstringForShiftingEmployee != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForShiftingEmployee", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForShiftingEmployee));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForShiftingEmployee", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_Insert' reported the ErrorCode: " +
                                            _errorCode);
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

        public IBaseEntityResponse<SaleContractMaster> RenewSaleContractMaster(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> response = new BaseEntityResponse<SaleContractMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_Renew";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeMasterID));
                    if (item.Narration != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNarration", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Narration));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNarration", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PurchaseOrderNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumber", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PurchaseOrderNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumber", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PurchaseOrderDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PurchaseOrderDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDisplayPurchaseDetails", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsDisplayPurchaseDetails));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtContractStartDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractStartDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtContractEndDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractEndDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiBillingType", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BillingType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBillingFixedAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BillingFixedAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiFixedBillingType", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedBillingType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFixedBillingForManPowerItemID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedBillingForManPowerItemID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiShortExtraPostingRateAccTo", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ShortExtraPostingRateAccTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsIncludeAllPostingForShortExtraRate", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsIncludeAllPostingForShortExtraRate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMaterialSupplyDay", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MaterialSupplyDay));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiRenewCallBeforeDays", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RenewCallBeforeDays));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMaterialSupplyFixAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MaterialSupplyFixAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiAdditionalAllowancePaidBy", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdditionalAllowancePaidBy));
                    if (item.SalaryEffectiveFromDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSalaryEffectiveFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalaryEffectiveFromDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSalaryEffectiveFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractStartDate));
                    }
                    if (item.SalaryEffectiveUptoDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSalaryEffectiveUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalaryEffectiveUptoDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSalaryEffectiveUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractEndDate));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiServiceChargesDependOn", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ServiceChargesDependOn));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiServiceChargesCalculateOn", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ServiceChargesCalculateOn));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsInclusiveServiceCharges", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsInclusiveServiceCharges));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsServiceChargesAppliedToAddAmount", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsServiceChargesAppliedToAddAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsServiceChargesAppliedToServiceItem", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsServiceChargesAppliedToServiceItem));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsServiceChargesAppliedToOverTime", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsServiceChargesAppliedToOverTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsRateFixedForRateContract", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsRateFixedForRateContract));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fServiceChargesPercentage", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ServiceChargesPercentage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiOverTimeDependOn", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OverTimeDependOn));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@tiOverTimeDisplayFormat", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OverTimeDisplayFormat));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mFixedAmountForInvoice", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedAmountForInvoice));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mFixedAmountForSalaryCompliance", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedAmountForSalaryCompliance));
                    if (item.XMLstringForOverTime != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTime", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForOverTime));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTime", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForOverTimeFix != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTimeFix", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForOverTimeFix));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForOverTimeFix", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForManPowerServiceCharge != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerServiceCharge", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForManPowerServiceCharge));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerServiceCharge", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForManPowerServiceChargeForHead != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerServiceChargeForHead", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForManPowerServiceChargeForHead));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerServiceChargeForHead", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForManPowerItem != null && item.XMLstringForAssignedEmployee != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForManPowerItem));
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForAssignedEmployee", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForAssignedEmployee));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForManPowerItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForAssignedEmployee", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForContractMaterial != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForContractMaterial", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForContractMaterial));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForContractMaterial", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForMachine != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForMachine", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForMachine));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForMachine", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForJobWorkItem != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForJobWorkItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForJobWorkItem));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForJobWorkItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForFixItem != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForFixItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForFixItem));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForFixItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForServiceItem != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForServiceItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForServiceItem));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForServiceItem", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractNumber", SqlDbType.NVarChar, 30, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ContractNumber));
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
                        item.ID = (Int64)cmdToExecute.Parameters["@iID"].Value;
                        item.ContractNumber = (String)cmdToExecute.Parameters["@nsContractNumber"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_Insert' reported the ErrorCode: " +
                                            _errorCode);
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
