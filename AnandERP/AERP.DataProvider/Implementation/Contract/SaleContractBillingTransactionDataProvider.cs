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
    public class SaleContractBillingTransactionDataProvider : DBInteractionBase, ISaleContractBillingTransactionDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SaleContractBillingTransactionDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SaleContractBillingTransactionDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetSaleContractBillingTransactionBySearch(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractBillingTransaction_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractBillingTransaction>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractBillingTransaction item = new SaleContractBillingTransaction();

                        //item.ID = sqlDataReader["ID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ID"]);
                        item.SaleContractMasterID = sqlDataReader["SaleContractMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractMasterID"]);
                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);
                        item.BillingType = sqlDataReader["BillingType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["BillingType"]);
                        item.SaleContractBillingSpanID = sqlDataReader["SaleContractBillingSpanID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractBillingSpanID"]);
                        item.SaleContractBillingSpanName = sqlDataReader["SaleContractBillingSpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractBillingSpanName"]);
                        item.TotalBillAmount = sqlDataReader["TotalBillAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalBillAmount"]), 2);
                        item.RoundOffAmount = sqlDataReader["RoundOffAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RoundOffAmount"]), 2);
                        item.IsBillGenerated = sqlDataReader["IsBillGenerated"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsBillGenerated"]);
                        item.CustomerInvoiceNumber = sqlDataReader["CustomerInvoiceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerInvoiceNumber"]);

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
                        throw new Exception("Stored Procedure 'USP_SaleContractBillingTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetBillingTransactionForGeneration(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
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
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleContractBillingTransaction_GenerateDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiBillingType", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BillingType));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractBillingTransaction>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractBillingTransaction item = new SaleContractBillingTransaction();

                        //item.ID = sqlDataReader["ID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ID"]);
                        item.SaleContractMasterID = sqlDataReader["SaleContractMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractMasterID"]);
                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.SaleContractBillingSpanID = sqlDataReader["SaleContractBillingSpanID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractBillingSpanID"]);
                        item.SaleContractBillingSpanName = sqlDataReader["SaleContractBillingSpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractBillingSpanName"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.FixedQuantity = sqlDataReader["FixedQuantity"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedQuantity"]), 2);
                        item.OriginalQuantity = sqlDataReader["OriginalQuantity"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["OriginalQuantity"]), 2);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Rate"]), 2);
                        item.ShortExtraRate = sqlDataReader["ShortExtraRate"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["ShortExtraRate"]), 2); 
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.ItemAssignedPeriod = sqlDataReader["ItemAssignedPeriod"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemAssignedPeriod"]);
                        item.HSNCode = sqlDataReader["HSNCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSNCode"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.GeneralTaxGroupMasterID = sqlDataReader["GeneralTaxGroupMasterID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["GeneralTaxGroupMasterID"]);
                        item.GeneralTaxGroupMasterName = sqlDataReader["GeneralTaxGroupMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GeneralTaxGroupMasterName"]);
                        item.IsOtherState = sqlDataReader["IsOtherState"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOtherState"]);
                        item.SaleContractRequirementDetailsID = sqlDataReader["SaleContractRequirementDetailsID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractRequirementDetailsID"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TaxRate"]), 2);
                        item.TaxList = sqlDataReader["TaxList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxList"]);
                        item.TaxRateList = sqlDataReader["TaxRateList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxRateList"]);
                        item.VariationMasterID = sqlDataReader["VariationMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["VariationMasterID"]);
                        item.VariationMasterName = sqlDataReader["VariationMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VariationMasterName"]);
                        item.SaleContractRequiredTypeID = sqlDataReader["SaleContractRequiredTypeID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SaleContractRequiredTypeID"]);
                        item.IsInclusiveServiceCharges = sqlDataReader["IsInclusiveServiceCharges"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsInclusiveServiceCharges"]);
                        item.ServiceChargesCalculateOn = sqlDataReader["ServiceChargesCalculateOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ServiceChargesCalculateOn"]);
                        item.IsServiceChargesAppliedToAddAmount = sqlDataReader["IsServiceChargesAppliedToAddAmount"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsServiceChargesAppliedToAddAmount"]);
                        item.IsServiceChargesAppliedToServiceItem = sqlDataReader["IsServiceChargesAppliedToServiceItem"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsServiceChargesAppliedToServiceItem"]);
                        item.IsServiceChargesAppliedToOverTime = sqlDataReader["IsServiceChargesAppliedToOverTime"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsServiceChargesAppliedToOverTime"]); 
                        item.ServiceChargesDependOn = sqlDataReader["ServiceChargesDependOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ServiceChargesDependOn"]);
                        item.GrossAmountRate = sqlDataReader["GrossAmountRate"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["GrossAmountRate"]), 2);
                        item.FixAmountPerManPowerRate = sqlDataReader["FixAmountPerManPowerRate"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixAmountPerManPowerRate"]), 2);
                        item.IsTaxExempted = sqlDataReader["IsTaxExempted"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsTaxExempted"]);
                        item.ReasonForExemption = sqlDataReader["ReasonForExemption"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ReasonForExemption"]);
                        item.FixedBillingType = sqlDataReader["FixedBillingType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["FixedBillingType"]);
                        item.TaxExemptionRemark = sqlDataReader["TaxExemptionRemark"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxExemptionRemark"]);
                        item.IsMachine = sqlDataReader["IsMachine"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsMachine"]); 

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractBillingTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractBillingTransaction> GenerateSaleContractInvoiceTransaction(SaleContractBillingTransaction item)
        {
            IBaseEntityResponse<SaleContractBillingTransaction> response = new BaseEntityResponse<SaleContractBillingTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractBillingTransaction_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalBillAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalBillAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRoundOffAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RoundOffAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTaxableAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TaxableAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTaxAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TaxAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringBillingTransaction", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLStringBillingTransaction));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForVouchar", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForVouchar)); 
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

        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetBillingTransactionDetailsByID(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractBillingTransaction_GetDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractBillingTransaction>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractBillingTransaction item = new SaleContractBillingTransaction();

                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);
                        item.BillingType = sqlDataReader["BillingType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["BillingType"]);
                        item.SaleContractBillingSpanName = sqlDataReader["SaleContractBillingSpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractBillingSpanName"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Quantity"]), 2);
                        item.FixedQuantity = sqlDataReader["FixedQuantity"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedQuantity"]), 2);
                        item.OriginalQuantity = sqlDataReader["OriginalQuantity"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["OriginalQuantity"]), 2);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Rate"]), 2);
                        item.ShortExtraRate= sqlDataReader["ShortExtraRate"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["ShortExtraRate"]), 2);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.ItemAssignedPeriod = sqlDataReader["ItemAssignedPeriod"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemAssignedPeriod"]);
                        item.HSNCode = sqlDataReader["HSNCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSNCode"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.GeneralTaxGroupMasterName = sqlDataReader["GeneralTaxGroupMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GeneralTaxGroupMasterName"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.IsOtherState = sqlDataReader["IsOtherState"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOtherState"]);
                        item.TaxableAmount = sqlDataReader["TaxableAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TaxableAmount"]), 2);
                        item.TaxAmount = sqlDataReader["TaxAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TaxAmount"]), 2);
                        item.NetAmount = sqlDataReader["NetAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["NetAmount"]), 2);
                        item.TotalBillAmount = sqlDataReader["TotalBillAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalBillAmount"]), 2);
                        item.RoundOffAmount = sqlDataReader["RoundOffAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RoundOffAmount"]), 2);
                        item.SalesInvoiceMasterID = sqlDataReader["SalesInvoiceMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalesInvoiceMasterID"]);
                        item.CustomerInvoiceNumber = sqlDataReader["CustomerInvoiceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerInvoiceNumber"]);
                        item.LocationID = sqlDataReader["LocationID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["LocationID"]);
                        item.LocationName = sqlDataReader["LocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.SaleContractRequiredTypeID = sqlDataReader["SaleContractRequiredTypeID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SaleContractRequiredTypeID"]);
                        item.IsServiceChargesAppliedToServiceItem = sqlDataReader["IsServiceChargesAppliedToServiceItem"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsServiceChargesAppliedToServiceItem"]);
                        item.IsTaxExempted = sqlDataReader["IsTaxExempted"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsTaxExempted"]);
                        item.ReasonForExemption = sqlDataReader["ReasonForExemption"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ReasonForExemption"]);
                        item.TaxExemptionRemark = sqlDataReader["TaxExemptionRemark"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxExemptionRemark"]);
                        item.IsCanceled = sqlDataReader["IsCanceled"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsCanceled"]);
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]); 

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractBillingTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetBillingTransactionDetailsByIDForInvoicePDF(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractBillingTransaction_GetDetailsForInvoicePDF";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractBillingTransaction>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractBillingTransaction item = new SaleContractBillingTransaction();

                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);
                        item.BillingType = sqlDataReader["BillingType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["BillingType"]);
                        item.SaleContractBillingSpanName = sqlDataReader["SaleContractBillingSpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractBillingSpanName"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Quantity"]), 2);
                        item.FixedQuantity = sqlDataReader["FixedQuantity"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedQuantity"]), 2);
                        item.OriginalQuantity = sqlDataReader["OriginalQuantity"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["OriginalQuantity"]), 2);
                        item.ShortExtraRate = sqlDataReader["ShortExtraRate"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["ShortExtraRate"]), 2);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Rate"]), 2);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.ItemAssignedPeriod = sqlDataReader["ItemAssignedPeriod"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemAssignedPeriod"]);
                        item.HSNCode = sqlDataReader["HSNCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSNCode"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.GeneralTaxGroupMasterName = sqlDataReader["GeneralTaxGroupMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GeneralTaxGroupMasterName"]);
                        item.GeneralTaxGroupMasterID = sqlDataReader["GeneralTaxGroupMasterID"] is DBNull ? new byte(): Convert.ToByte(sqlDataReader["GeneralTaxGroupMasterID"]); 
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.IsOtherState = sqlDataReader["IsOtherState"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOtherState"]);
                        item.TaxableAmount = sqlDataReader["TaxableAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TaxableAmount"]), 2);
                        item.TaxAmount = sqlDataReader["TaxAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TaxAmount"]), 2);
                        item.NetAmount = sqlDataReader["NetAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["NetAmount"]), 2);
                        item.TotalBillAmount = sqlDataReader["TotalBillAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalBillAmount"]), 2);
                        item.RoundOffAmount = sqlDataReader["RoundOffAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RoundOffAmount"]), 2);
                        item.SalesInvoiceMasterID = sqlDataReader["SalesInvoiceMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalesInvoiceMasterID"]);
                        item.CustomerInvoiceNumber = sqlDataReader["CustomerInvoiceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerInvoiceNumber"]);
                        item.LocationID = sqlDataReader["LocationID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["LocationID"]);
                        item.LocationName = sqlDataReader["LocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);

                        item.CountryName = sqlDataReader["CountryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CountryName"]);
                        item.StateName = sqlDataReader["Statename"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Statename"]);
                        item.CityName = sqlDataReader["CityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CityName"]);
                        item.BranchCountryName = sqlDataReader["BranchCountryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchCountryName"]);
                        item.BranchStateName = sqlDataReader["BranchStateName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchStateName"]);
                        item.BranchCityName = sqlDataReader["BranchCityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchCityName"]);
                        item.CellPhone = sqlDataReader["CellPhone"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CellPhone"]);
                        item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);
                        item.EmailID = sqlDataReader["EmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmailID"]);
                        item.FaxNumber = sqlDataReader["FaxNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FaxNumber"]);
                        item.PhoneNumberOffice = sqlDataReader["PhoneNumberOffice"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PhoneNumberOffice"]);
                        item.CentreAddress1 = sqlDataReader["Address1"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Address1"]);
                        item.CentreAddress2 = sqlDataReader["Address2"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Address2"]);
                        item.Website = sqlDataReader["Website"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Website"]);
                        item.Currency = sqlDataReader["Currency"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Currency"]);

                        item.CustomerGSTNumber = sqlDataReader["CustomerGSTNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerGSTNumber"]);
                        item.BranchGSTNumber = sqlDataReader["BranchGSTNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchGSTNumber"]);
                        item.LogoPath = sqlDataReader["LogoPath"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LogoPath"]);
                        item.InvoiceTransactionDate = sqlDataReader["InvoiceTransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["InvoiceTransactionDate"]);
                        item.SaleContractRequiredTypeID = sqlDataReader["SaleContractRequiredTypeID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SaleContractRequiredTypeID"]);
                        item.IsServiceChargesAppliedToServiceItem = sqlDataReader["IsServiceChargesAppliedToServiceItem"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsServiceChargesAppliedToServiceItem"]);
                        item.IsTaxExempted = sqlDataReader["IsTaxExempted"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsTaxExempted"]);
                        item.ReasonForExemption = sqlDataReader["ReasonForExemption"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ReasonForExemption"]);
                        item.CustomerPinCode = sqlDataReader["CustomerPinCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerPinCode"]);
                        item.CustomerBranchPinCode = sqlDataReader["CustomerBranchPinCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchPinCode"]);
                        item.StateCode = sqlDataReader["StateCode"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["StateCode"]);
                        item.BranchStateCode = sqlDataReader["BranchStateCode"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["BranchStateCode"]);
                        item.CINNumber = sqlDataReader["CINNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CINNumber"]);
                        item.ESICNumber = sqlDataReader["ESICNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ESICNumber"]);
                        item.GSTINNumber = sqlDataReader["GSTINNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GSTINNumber"]);
                        item.PanNumber = sqlDataReader["PanNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PanNumber"]);
                        item.PFNumber = sqlDataReader["PFNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PFNumber"]);
                        item.PrintingLineBelowLogo = sqlDataReader["PrintingLineBelowLogo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLineBelowLogo"]);
                        item.CentreSpecialization = sqlDataReader["CentreSpecialization"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreSpecialization"]);
                        item.CustomerAddress = sqlDataReader["CustomerAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerAddress"]);
                        item.CustomerBranchAddress = sqlDataReader["CustomerBranchAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchAddress"]);
                        item.TaxExemptionRemark = sqlDataReader["TaxExemptionRemark"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxExemptionRemark"]);
                        item.IsDisplayPurchaseDetails = sqlDataReader["IsDisplayPurchaseDetails"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsDisplayPurchaseDetails"]);
                        item.PurchaseOrderNumber = sqlDataReader["PurchaseOrderNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        item.PurchaseOrderDate = sqlDataReader["PurchaseOrderDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseOrderDate"]);
                        item.DateTimeOfSupply = sqlDataReader["DateTimeOfSupply"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DateTimeOfSupply"]);
                        item.IsCanceled = sqlDataReader["IsCanceled"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsCanceled"]); 

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractBillingTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetSummerySheetForBillingTransactionDetails(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
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
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleContractBillingTransactionSalaryReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractBillingTransaction>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractBillingTransaction item = new SaleContractBillingTransaction();
                        item.HeadType = sqlDataReader["HeadType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadType"]);
                        item.IsAllowance = sqlDataReader["IsAllowance"] is DBNull ? new bool(): Convert.ToBoolean(sqlDataReader["IsAllowance"]);
                        item.ComplianceType = sqlDataReader["ComplianceType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ComplianceType"]); 
                        item.TotalDaysSum = sqlDataReader["TotalDays"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalDays"]);
                        item.TotalBillAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAmount"]);
                        item.BasicAmount = sqlDataReader["BasicAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BasicAmount"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAmount"]);
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalSalary"]);
                        item.GrossAmount = sqlDataReader["GrossAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["GrossAmount"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new int() : Convert.ToInt16(sqlDataReader["SaleContractManPowerItemID"]);
                        item.SaleContractManPowerItemName= sqlDataReader["SaleContractManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemName"]);
                        item.AllowanceDeductionAmount = sqlDataReader["AllowanceDeductionAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["AllowanceDeductionAmount"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.SaleContractBillingSpanName= sqlDataReader["BillingSpanDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BillingSpanDate"]);
                        item.SaleContractManPowerItemList = sqlDataReader["SaleContractManPowerItemList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemList"]);
                        item.TotalOverTime = sqlDataReader["TotalOverTime"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalOverTime"]);
                        item.OverTimeRate = sqlDataReader["OverTimeRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["OverTimeRate"]);
                        item.OverTimeAmount = sqlDataReader["OverTimeAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["OverTimeAmount"]);
                        item.AdditionalAmount = sqlDataReader["AdditionalAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["AdditionalAmount"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractBillingTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetSummerySheetForBillingTransactionDetails_Second(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
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
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleContractBillingTransactionSalaryReport_Second";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractBillingTransaction>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractBillingTransaction item = new SaleContractBillingTransaction();
                        item.HeadType = sqlDataReader["HeadType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadType"]);
                        item.IsAllowance = sqlDataReader["IsAllowance"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsAllowance"]);
                        item.ComplianceType = sqlDataReader["ComplianceType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ComplianceType"]);
                        item.TotalDaysSum = sqlDataReader["TotalDays"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalDays"]);
                        item.TotalBillAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAmount"]);
                        item.BasicAmount = sqlDataReader["BasicAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BasicAmount"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAmount"]);
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalSalary"]);
                        item.GrossAmount = sqlDataReader["GrossAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["GrossAmount"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new int() : Convert.ToInt16(sqlDataReader["SaleContractManPowerItemID"]);
                        item.SaleContractManPowerItemName = sqlDataReader["SaleContractManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemName"]);
                        item.AllowanceDeductionAmount = sqlDataReader["AllowanceDeductionAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["AllowanceDeductionAmount"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.SaleContractBillingSpanName = sqlDataReader["BillingSpanDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BillingSpanDate"]);
                        item.SaleContractManPowerItemList = sqlDataReader["SaleContractManPowerItemList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemList"]);
                        item.TotalOverTime = sqlDataReader["TotalOverTime"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalOverTime"]);
                        item.OverTimeRate = sqlDataReader["OverTimeRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["OverTimeRate"]);
                        item.OverTimeAmount = sqlDataReader["OverTimeAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["OverTimeAmount"]);
                        item.AdditionalAmount = sqlDataReader["AdditionalAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["AdditionalAmount"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractBillingTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractBillingTransaction> CancelSaleContractInvoiceTransaction(SaleContractBillingTransaction item)
        {
            IBaseEntityResponse<SaleContractBillingTransaction> response = new BaseEntityResponse<SaleContractBillingTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractBillingTransaction_Cancel";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForVouchar", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForVouchar));
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
