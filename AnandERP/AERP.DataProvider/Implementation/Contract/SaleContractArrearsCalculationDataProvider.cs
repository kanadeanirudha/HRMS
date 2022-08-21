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
    public class SaleContractArrearsCalculationDataProvider : DBInteractionBase, ISaleContractArrearsCalculationDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SaleContractArrearsCalculationDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SaleContractArrearsCalculationDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSaleContractArrearsCalculationBySearch(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculation_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractArrearsCalculation>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractArrearsCalculation item = new SaleContractArrearsCalculation();

                        item.ID = sqlDataReader["ID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ID"]);
                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                       item.BasicSalayAmount = sqlDataReader["BasicAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["BasicAmount"]), 2);

                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalSalary"]), 2);
                        item.SaleContractManPowerItemName = sqlDataReader["SaleContractManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemName"]);
                       // item.IsArreas = sqlDataReader["IsArreas"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["IsArreas"]);
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
                        throw new Exception("Stored Procedure 'USP_SaleContractArrearsCalculation_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionForGeneration(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculation_GenerateDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractEmployeeMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractEmployeeMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractManPowerItemID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractManPowerItemID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractArrearsCalculation>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractArrearsCalculation item = new SaleContractArrearsCalculation();

                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.OvertimeHours = sqlDataReader["OvertimeHours"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["OvertimeHours"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]), 2);
                        item.PreviousTotalAmount = sqlDataReader["PreviousTotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["PreviousTotalAmount"]), 2);
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalSalary"]), 2);
                        item.FixedSalaryAmount = sqlDataReader["FixedSalaryAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedSalaryAmount"]), 2);
                        item.SaleContractBillingSpanID = sqlDataReader["SaleContractBillingSpanID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractBillingSpanID"]);
                        item.SaleContractBillingSpanName = sqlDataReader["SaleContractBillingSpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractBillingSpanName"]);
                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);
                        item.RuleType = sqlDataReader["RuleType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RuleType"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.HeadID = sqlDataReader["HeadID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["HeadID"]);
                        item.SaleContractManPowerAllowanceID = sqlDataReader["SaleContractManPowerAllowanceID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerAllowanceID"]);
                        item.SaleContractManPowerDeductionID = sqlDataReader["SaleContractManPowerDeductionID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerDeductionID"]);
                        item.IsAllowance = sqlDataReader["IsAllowance"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsAllowance"]);
                        item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedAmount"]), 2);
                        item.CalculateOn = sqlDataReader["CalculateOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CalculateOn"]);
                        item.Percentage = sqlDataReader["Percentage"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Percentage"]), 2);
                        item.HeadType = sqlDataReader["HeadType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadType"]);
                        item.HeadSubType = sqlDataReader["HeadSubType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadSubType"]);
                        item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        item.CalculateOnString = sqlDataReader["CalculateOnString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnString"]);
                        item.RangeFrom = sqlDataReader["RangeFrom"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeFrom"]), 2);
                        item.RangeUpto = sqlDataReader["RangeUpto"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeUpto"]), 2);
                        item.ComplianceType = sqlDataReader["ComplianceType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ComplianceType"]);
                        item.PreviousFixedAmount = sqlDataReader["PreviousFixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["PreviousFixedAmount"]), 2);
                        item.CurrentFixedAmount = sqlDataReader["CurrentFixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["CurrentFixedAmount"]), 2);
                        item.CurrentPercentage = sqlDataReader["CurrentPercentage"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["CurrentPercentage"]), 2);
                        item.PreviousPercentage = sqlDataReader["PreviousPercentage"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["PreviousPercentage"]), 2);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractArrearsCalculation_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractArrearsCalculation> GenerateSaleContractArrearsCalculation(SaleContractArrearsCalculation item)
        {
            IBaseEntityResponse<SaleContractArrearsCalculation> response = new BaseEntityResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculation_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractEmployeeMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractEmployeeMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractManPowerItemID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractManPowerItemID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBasicSalayAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BasicSalayAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mAdjustedBasicAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdjustedBasicAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mGrossAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GrossAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalEarnings", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalEarnings)); 
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalDeduction", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalDeduction));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mNetPayable", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.NetPayable));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mEmployerContributionTotal", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployerContributionTotal));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalSalary", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalSalary));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mAdjustedTotalSalary", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdjustedTotalSalary));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiAdjustedTotalDays", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdjustedTotalDays));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringSalaryTransaction", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLStringSalaryTransaction));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForVouchar", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForVouchar));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsRemoveForAdjustment", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsRemoveForAdjustment));
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

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionDetailsByID(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculation_GetDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractArrearsCalculation>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractArrearsCalculation item = new SaleContractArrearsCalculation();

                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.OvertimeHours = sqlDataReader["OvertimeHours"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["OvertimeHours"]);
                        item.AdjustedTotalDays = sqlDataReader["AdjustedTotalDays"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["AdjustedTotalDays"]);
                        item.BasicSalayAmount = sqlDataReader["BasicSalayAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["BasicSalayAmount"]), 2);
                        item.ActualBasicAmount = sqlDataReader["BasicAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["BasicAmount"]), 2);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]));
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalSalary"]));
                        item.FixedSalaryAmount = sqlDataReader["FixedSalaryAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedSalaryAmount"]), 2);
                        item.AdjustedTotalSalary = sqlDataReader["AdjustedTotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["AdjustedTotalSalary"]));
                        item.GrossAmount = sqlDataReader["GrossAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["GrossAmount"]));
                        item.TotalEarnings = sqlDataReader["TotalEarnings"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalEarnings"])); 
                        item.TotalDeduction = sqlDataReader["TotalDeduction"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalDeduction"]));
                        item.NetPayable = sqlDataReader["NetPayable"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["NetPayable"]));
                        item.EmployerContributionTotal = sqlDataReader["EmployerContributionTotal"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["EmployerContributionTotal"]));
                        item.IsRemoveForAdjustment = sqlDataReader["IsRemoveForAdjustment"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsRemoveForAdjustment"]);
                        item.SaleContractBillingSpanID = sqlDataReader["SaleContractBillingSpanID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractBillingSpanID"]);
                        item.SaleContractBillingSpanName = sqlDataReader["SaleContractBillingSpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractBillingSpanName"]);
                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);
                        item.RuleType = sqlDataReader["RuleType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RuleType"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.HeadID = sqlDataReader["HeadID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["HeadID"]);
                        item.SaleContractManPowerAllowanceID = sqlDataReader["SaleContractManPowerAllowanceID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerAllowanceID"]);
                        item.SaleContractManPowerDeductionID = sqlDataReader["SaleContractManPowerDeductionID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerDeductionID"]);
                        item.IsAllowance = sqlDataReader["IsAllowance"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsAllowance"]);
                        item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedAmount"]), 2);
                        item.CalculateOn = sqlDataReader["CalculateOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CalculateOn"]);
                        item.Percentage = sqlDataReader["Percentage"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Percentage"]), 2);
                        item.ActualAmount = sqlDataReader["ActualAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["ActualAmount"]));
                        item.AdjustedAmount = sqlDataReader["AdjustedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["AdjustedAmount"]));
                        item.HeadType = sqlDataReader["HeadType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadType"]);
                        item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        item.CalculateOnString = sqlDataReader["CalculateOnString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnString"]);
                        item.SaleContractManPowerItemName = sqlDataReader["SaleContractManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemName"]);
                        item.EmployeeCode = sqlDataReader["EmployeeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeCode"]);
                        item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);
                        item.City = sqlDataReader["City"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["City"]);
                        item.BankACNumber = sqlDataReader["BankACNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankACNumber"]);
                        item.ESINumber = sqlDataReader["ESINumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ESINumber"]);
                        item.ProvidentFundNumber = sqlDataReader["ProvidentFundNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ProvidentFundNumber"]);
                        item.LogoPath = sqlDataReader["LogoPath"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LogoPath"]);
                        item.RangeFrom = sqlDataReader["RangeFrom"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeFrom"]), 2);
                        item.RangeUpto = sqlDataReader["RangeUpto"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeUpto"]), 2);
                        item.ComplianceType = sqlDataReader["ComplianceType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ComplianceType"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractArrearsCalculation_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionForBulkGeneration(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculation_GenerateBulkDetails";
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractArrearsCalculation>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractArrearsCalculation item = new SaleContractArrearsCalculation();

                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.OvertimeHours = sqlDataReader["OvertimeHours"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["OvertimeHours"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]), 2);
                        item.PreviousTotalAmount = sqlDataReader["PreviousTotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["PreviousTotalAmount"]), 2);

                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalSalary"]), 2);
                        item.FixedSalaryAmount = sqlDataReader["FixedSalaryAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedSalaryAmount"]), 2);
                        item.SaleContractBillingSpanID = sqlDataReader["SaleContractBillingSpanID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractBillingSpanID"]);
                        item.SaleContractBillingSpanName = sqlDataReader["SaleContractBillingSpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractBillingSpanName"]);
                        item.ContractNumber = sqlDataReader["ContractNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNumber"]);
                        item.RuleType = sqlDataReader["RuleType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RuleType"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.HeadID = sqlDataReader["HeadID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["HeadID"]);
                        item.SaleContractManPowerAllowanceID = sqlDataReader["SaleContractManPowerAllowanceID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerAllowanceID"]);
                        item.SaleContractManPowerDeductionID = sqlDataReader["SaleContractManPowerDeductionID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerDeductionID"]);
                        item.IsAllowance = sqlDataReader["IsAllowance"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsAllowance"]);
                        item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedAmount"]), 2);
                        item.PreviousFixedAmount = sqlDataReader["PreviousFixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["PreviousFixedAmount"]), 2);
                        item.CalculateOn = sqlDataReader["CalculateOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CalculateOn"]);
                        item.Percentage = sqlDataReader["Percentage"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Percentage"]), 2);
                        item.PreviousPercentage = sqlDataReader["PreviousPercentage"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["PreviousPercentage"]), 2);
                        item.HeadType = sqlDataReader["HeadType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadType"]);
                        item.HeadSubType = sqlDataReader["HeadSubType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadSubType"]);
                        item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        item.CalculateOnString = sqlDataReader["CalculateOnString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnString"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.RangeFrom = sqlDataReader["RangeFrom"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeFrom"]), 2);
                        item.RangeUpto = sqlDataReader["RangeUpto"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeUpto"]), 2);
                        item.SaleContractEmployeeMasterIDList = sqlDataReader["SaleContractEmployeeMasterIDList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterIDList"]);
                        item.ComplianceType = sqlDataReader["ComplianceType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ComplianceType"]);
                        item.CalculateOnFixedAmount = sqlDataReader["CalculateOnFixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["CalculateOnFixedAmount"]), 2);
                        item.PreviousCalculateOnFixedAmount = sqlDataReader["PreviousCalculateOnFixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["PreviousCalculateOnFixedAmount"]), 2); 

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractArrearsCalculation_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractArrearsCalculation> GenerateSaleContractBulkSalaryTransaction(SaleContractArrearsCalculation item)
        {
            IBaseEntityResponse<SaleContractArrearsCalculation> response = new BaseEntityResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsSalaryCalculation_InsertXMLBulkSalary";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringBulkSalaryTransactionEmployee", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLStringBulkSalaryTransactionEmployee));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringBulkSalaryTransaction", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLStringBulkSalaryTransaction));
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

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionDetailsForSalarySheet(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
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
                    if (searchRequest.SummaryFormat == 1)
                    {
                        cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculationSalaryReport_Save";
                    }
                    else if (searchRequest.SummaryFormat == 2)
                    {
                        cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculationSalaryReport";
                    }
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractArrearsCalculation>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractArrearsCalculation item = new SaleContractArrearsCalculation();

                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.OvertimeHours = sqlDataReader["OvertimeHours"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["OvertimeHours"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]), 2);
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalSalary"]), 2);
                        item.AdjustedBasicAmount = sqlDataReader["AdjustedBasicAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["AdjustedBasicAmount"]), 2);
                        item.SaleContractBillingSpanID = sqlDataReader["SaleContractBillingSpanID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractBillingSpanID"]);
                        item.SaleContractBillingSpanName = sqlDataReader["SaleContractBillingSpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractBillingSpanName"]);
                        item.RuleType = sqlDataReader["RuleType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RuleType"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.HeadID = sqlDataReader["HeadID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["HeadID"]);
                        item.IsAllowance = sqlDataReader["IsAllowance"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsAllowance"]);
                        item.Amount = sqlDataReader["Amount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Amount"]), 2);
                        item.AdjustedAmount = sqlDataReader["AdjustedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["AdjustedAmount"]), 2);
                        item.HeadType = sqlDataReader["HeadType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadType"]);
                        item.HeadSubType = sqlDataReader["HeadSubType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadSubType"]);
                        item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.SaleContractEmployeeMasterIDList = sqlDataReader["SaleContractEmployeeMasterIDList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterIDList"]);
                        item.ComplianceType = sqlDataReader["ComplianceType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ComplianceType"]);
                        item.SaleContractManPowerItemIDList = sqlDataReader["SaleContractManPowerItemIDList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemIDList"]);
                        item.SaleContractManPowerItemName = sqlDataReader["SaleContractManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemName"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        item.SalaryMonth = sqlDataReader["SalaryMonth"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalaryMonth"]);
                        item.SalaryYear = sqlDataReader["SalaryYear"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalaryYear"]);
                        item.CentreName= sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractArrearsCalculation_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionDetailsForNRSheet(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculationNRReport";
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractArrearsCalculation>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractArrearsCalculation item = new SaleContractArrearsCalculation();

                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]), 2);
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalSalary"]), 2);
                        item.AdjustedBasicAmount = sqlDataReader["AdjustedBasicAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["AdjustedBasicAmount"]), 2);
                        item.GrossAmount = sqlDataReader["GrossAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["GrossAmount"]), 2);
                        item.SaleContractBillingSpanID = sqlDataReader["SaleContractBillingSpanID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractBillingSpanID"]);
                        item.SaleContractBillingSpanName = sqlDataReader["SaleContractBillingSpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractBillingSpanName"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.SaleContractEmployeeMasterIDList = sqlDataReader["SaleContractEmployeeMasterIDList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterIDList"]);
                        item.SaleContractManPowerItemIDList = sqlDataReader["SaleContractManPowerItemIDList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemIDList"]);
                        item.SaleContractManPowerItemName = sqlDataReader["SaleContractManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractManPowerItemName"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        item.SalaryMonth = sqlDataReader["SalaryMonth"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalaryMonth"]);
                        item.SalaryYear = sqlDataReader["SalaryYear"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalaryYear"]);
                        item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractArrearsCalculation_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetListSaleContractArrearsCalculationDeduction(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculationDeduction_RunTime_SelectList";
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractArrearsCalculation>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractArrearsCalculation item = new SaleContractArrearsCalculation();

                        item.HeadID = sqlDataReader["HeadID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["HeadID"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.SaleContractManPowerDeductionID = sqlDataReader["RuleID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["RuleID"]);
                        
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractArrearsCalculationDeduction_RunTime_SelectList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractArrearsCalculation> AddSaleContractArrearsCalculationDeduction(SaleContractArrearsCalculation item)
        {
            IBaseEntityResponse<SaleContractArrearsCalculation> response = new BaseEntityResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculationDeduction_RunTime_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiHeadID", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.HeadID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractManPowerDeductionID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractManPowerDeductionID));
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
                        throw new Exception("Stored Procedure 'USP_SaleContractArrearsCalculationDeduction_RunTime_Insert' reported the ErrorCode: " +
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

        public IBaseEntityResponse<SaleContractArrearsCalculation> AddSaleContractArrearsAttendance(SaleContractArrearsCalculation item)
        {
            IBaseEntityResponse<SaleContractArrearsCalculation> response = new BaseEntityResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculation_InsertXMLBulkAttendance";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForAttendance", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForAttendance));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringBulkSalaryTransaction", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLStringBulkSalaryTransaction));
                   //
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

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSaleContractArrearsAttendanceSpanWise(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculationDeduction_RunTime_SelectList";
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractArrearsCalculation>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractArrearsCalculation item = new SaleContractArrearsCalculation();

                        item.HeadID = sqlDataReader["HeadID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["HeadID"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.SaleContractManPowerDeductionID = sqlDataReader["RuleID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["RuleID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractArrearsCalculationDeduction_RunTime_SelectList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetAttendanceListForSpanWise(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractArrearsCalculation_GetAttendance";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractBillingSpanID));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractArrearsCalculation>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractArrearsCalculation item = new SaleContractArrearsCalculation();

                        item.ID = sqlDataReader["ID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ID"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                      //  item.OvertimeHours = sqlDataReader["OvertimeHours"] is DBNull ? new byte() : Convert.ToDecimal(sqlDataReader["OvertimeHours"]);
                        item.IsSalaryDaysOnWeeklyOff = sqlDataReader["IsSalaryDaysOnWeeklyOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsSalaryDaysOnWeeklyOff"]);
                        item.IsBillingDaysOnWeeklyOff = sqlDataReader["IsBillingDaysOnWeeklyOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsBillingDaysOnWeeklyOff"]);
                        item.SaleContractManPowerAssignID = sqlDataReader["SaleContractManPowerAssignID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractManPowerAssignID"]);
                        /*item.TotalBillingDays = sqlDataReader["TotalBillingDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalBillingDays"]);
                        item.TotalWeeklyOffDays = sqlDataReader["TotalWeeklyOffDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalWeeklyOffDays"]);
                        item.TotalOverTimeSalaryDays = sqlDataReader["TotalOverTimeSalaryDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalOverTimeSalaryDays"]);
                        item.TotalOverTimeBillingDays = sqlDataReader["TotalOverTimeBillingDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalOverTimeBillingDays"]);
                        item.IsOTDaysOnTotalOff = sqlDataReader["IsOTDaysOnTotalOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOTDaysOnTotalOff"]);
                        item.IsOTBillingDaysOnTotalOff = sqlDataReader["IsOTBillingDaysOnTotalOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOTBillingDaysOnTotalOff"]);
                        item.TotalWeeklyOffBillingDays = sqlDataReader["TotalWeeklyOffBillingDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalWeeklyOffBillingDays"]);
                        item.SaleContractManPowerAssignID = sqlDataReader["SaleContractManPowerAssignID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractManPowerAssignID"]);
                        item.IsSalaryDaysCountFix = sqlDataReader["IsSalaryDaysCountFix"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsSalaryDaysCountFix"]);
                        item.IsBillingDaysFixed = sqlDataReader["IsBillingDaysFixed"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsBillingDaysFixed"]);
                        item.IsOverTimeDaysFix = sqlDataReader["IsOverTimeDaysFix"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOverTimeDaysFix"]);
                        item.IsOverTimeBillingDaysFix = sqlDataReader["IsOverTimeBillingDaysFix"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOverTimeBillingDaysFix"]);*/
                        item.SalaryForManPowerItemName = sqlDataReader["SalaryForManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalaryForManPowerItemName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractArrearsCalculationDeduction_RunTime_SelectList' reported the ErrorCode: " + _errorCode);
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
