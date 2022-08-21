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
    public class EmployeeSalaryTransactionDataProvider : DBInteractionBase, IEmployeeSalaryTransactionDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeeSalaryTransactionDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeeSalaryTransactionDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetEmployeeSalaryTransactionBySearch(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalaryTransaction_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCenterCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CenterCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siEmployeeSalarySpanID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeSalarySpanID));
                    
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

                    baseEntityCollection.CollectionResponse = new List<EmployeeSalaryTransaction>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeSalaryTransaction item = new EmployeeSalaryTransaction();

                        item.EmployeeMasterID = sqlDataReader["EmployeeMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeMasterID"]);
                        item.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        item.EmployeeCode = sqlDataReader["EmployeeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeCode"]);
                        item.EmployeeSalaryTransactionID = sqlDataReader["EmployeeSalaryTransactionID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["EmployeeSalaryTransactionID"]);
                        item.BasicAmount = sqlDataReader["BasicAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BasicAmount"]);
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalSalary"]);
                        item.NetPayable = sqlDataReader["NetPayable"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["NetPayable"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.EmployeeSalaryRulesID = sqlDataReader["EmployeeSalaryRulesID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["EmployeeSalaryRulesID"]); 

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
                        throw new Exception("Stored Procedure 'USP_EmployeeSalaryTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionForGeneration(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalaryTransaction_GenerateDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeSalarySpanID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeSalarySpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeSalaryRulesID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeSalaryRulesID));
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

                    baseEntityCollection.CollectionResponse = new List<EmployeeSalaryTransaction>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeSalaryTransaction item = new EmployeeSalaryTransaction();

                        item.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        item.EmployeeMasterID= sqlDataReader["EmployeeMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeMasterID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.OvertimeHours = sqlDataReader["TotalOvertime"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalOvertime"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]), 2);
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalSalary"]), 2);
                        item.EmployeeSalarySpanID = sqlDataReader["EmployeeSalarySpanID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["EmployeeSalarySpanID"]);
                        item.SpanName = sqlDataReader["SpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SpanName"]);
                        item.RuleType = sqlDataReader["RuleType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RuleType"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.HeadID = sqlDataReader["HeadID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["HeadID"]);
                        item.EmployeeSalaryRulesAllowanceID = sqlDataReader["EmployeeSalaryRulesAllowanceID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["EmployeeSalaryRulesAllowanceID"]);
                        item.EmployeeSalaryRulesDeductionID = sqlDataReader["EmployeeSalaryRulesDeductionID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["EmployeeSalaryRulesDeductionID"]);
                        item.IsAllowance = sqlDataReader["IsAllowance"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsAllowance"]);
                        item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedAmount"]), 2);
                        item.Percentage = sqlDataReader["Percentage"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Percentage"]), 2);
                        item.HeadType = sqlDataReader["HeadType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadType"]);
                        item.HeadSubType = sqlDataReader["HeadSubType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadSubType"]);
                        item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        item.CalculateOnString = sqlDataReader["CalculateOnString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnString"]);
                        item.RangeFrom = sqlDataReader["RangeFrom"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeFrom"]), 2);
                        item.RangeUpto = sqlDataReader["RangeUpto"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeUpto"]), 2);
                        item.ComplianceType = sqlDataReader["ComplianceType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ComplianceType"]);
                        item.CalculateOnFixedAmount = sqlDataReader["CalculateOnFixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["CalculateOnFixedAmount"]), 2);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeSalaryTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<EmployeeSalaryTransaction> GenerateEmployeeSalaryTransaction(EmployeeSalaryTransaction item)
        {
            IBaseEntityResponse<EmployeeSalaryTransaction> response = new BaseEntityResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalaryTransaction_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@siEmployeeSalarySpanID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeSalarySpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeSalaryRulesID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeSalaryRulesID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBasicAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BasicAmount));
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

        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionDetailsByID(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalaryTransaction_GetDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.CommandTimeout = 0;
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

                    baseEntityCollection.CollectionResponse = new List<EmployeeSalaryTransaction>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeSalaryTransaction item = new EmployeeSalaryTransaction();

                        item.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        item.EmployeeMasterID = sqlDataReader["EmployeeMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeMasterID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.OvertimeHours = sqlDataReader["TotalOvertime"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalOvertime"]);
                        item.AdjustedTotalDays = sqlDataReader["AdjustedTotalDays"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["AdjustedTotalDays"]);
                        item.BasicAmount = sqlDataReader["BasicAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["BasicAmount"]), 2);
                        item.ActualBasicAmount = sqlDataReader["ActualBasicAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["ActualBasicAmount"]), 2);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]));
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalSalary"]));
                        item.AdjustedTotalSalary = sqlDataReader["AdjustedTotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["AdjustedTotalSalary"]));
                        item.GrossAmount = sqlDataReader["GrossAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["GrossAmount"]));
                        item.TotalEarnings = sqlDataReader["TotalEarnings"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalEarnings"]));
                        item.TotalDeduction = sqlDataReader["TotalDeduction"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalDeduction"]));
                        item.NetPayable = sqlDataReader["NetPayable"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["NetPayable"]));
                        item.EmployerContributionTotal = sqlDataReader["EmployerContributionTotal"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["EmployerContributionTotal"]));
                        item.EmployeeSalarySpanID = sqlDataReader["EmployeeSalarySpanID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["EmployeeSalarySpanID"]);
                        item.SpanName = sqlDataReader["SpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SpanName"]);
                        item.RuleType = sqlDataReader["RuleType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RuleType"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.HeadID = sqlDataReader["HeadID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["HeadID"]);
                        item.EmployeeSalaryRulesAllowanceID = sqlDataReader["EmployeeSalaryRulesAllowanceID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["EmployeeSalaryRulesAllowanceID"]);
                        item.EmployeeSalaryRulesDeductionID = sqlDataReader["EmployeeSalaryRulesDeductionID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["EmployeeSalaryRulesDeductionID"]);
                        item.IsAllowance = sqlDataReader["IsAllowance"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsAllowance"]);
                        item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedAmount"]), 2);
                        item.Percentage = sqlDataReader["Percentage"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Percentage"]), 2);
                        item.ActualAmount = sqlDataReader["ActualAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["ActualAmount"]));
                        item.AdjustedAmount = sqlDataReader["AdjustedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["AdjustedAmount"]));
                        item.HeadType = sqlDataReader["HeadType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadType"]);
                        item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        item.CalculateOnString = sqlDataReader["CalculateOnString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnString"]);
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
                        item.CalculateOnFixedAmount = sqlDataReader["CalculateOnFixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["CalculateOnFixedAmount"]), 2);
                        //item.BankACNumber =  sqlDataReader["BankACNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankACNumber"]);
                        //item.ProvidentFundNumber = sqlDataReader["ProvidentFundNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ProvidentFundNumber"]);
                       // item.DesignationName = sqlDataReader["ProvidentFundNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ProvidentFundNumber"]);
                        item.UANNumber = sqlDataReader["UANNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UANNumber"]);
                        item.DesignationName = sqlDataReader["DesignationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DesignationName"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeSalaryTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionForBulkGeneration(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalaryTransaction_GenerateBulkDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCenterCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CenterCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@siEmployeeSalarySpanID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeSalarySpanID));

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

                    baseEntityCollection.CollectionResponse = new List<EmployeeSalaryTransaction>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeSalaryTransaction item = new EmployeeSalaryTransaction();

                        item.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        item.EmployeeMasterID = sqlDataReader["EmployeeMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeMasterID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.OvertimeHours = sqlDataReader["TotalOvertime"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalOvertime"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]), 2);
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalSalary"]), 2);
                        item.EmployeeSalarySpanID= sqlDataReader["EmployeeSalarySpanID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["EmployeeSalarySpanID"]);
                        item.SpanName = sqlDataReader["SpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SpanName"]);
                        item.RuleType = sqlDataReader["RuleType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RuleType"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.HeadID = sqlDataReader["HeadID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["HeadID"]);
                        item.EmployeeSalaryRulesAllowanceID = sqlDataReader["EmployeeSalaryRulesAllowanceID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeSalaryRulesAllowanceID"]);
                        item.EmployeeSalaryRulesDeductionID = sqlDataReader["EmployeeSalaryRulesDeductionID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeSalaryRulesDeductionID"]);
                        item.IsAllowance = sqlDataReader["IsAllowance"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsAllowance"]);
                        item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedAmount"]), 2);
                        item.Percentage = sqlDataReader["Percentage"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Percentage"]), 2);
                        item.HeadType = sqlDataReader["HeadType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadType"]);
                        item.HeadSubType = sqlDataReader["HeadSubType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadSubType"]);
                        item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        item.CalculateOnString = sqlDataReader["CalculateOnString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnString"]);
                        item.EmployeeSalaryRulesID = sqlDataReader["EmployeeSalaryRulesID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["EmployeeSalaryRulesID"]);
                        item.RangeFrom = sqlDataReader["RangeFrom"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeFrom"]), 2);
                        item.RangeUpto = sqlDataReader["RangeUpto"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeUpto"]), 2);
                        item.SaleContractEmployeeMasterIDList = sqlDataReader["SaleContractEmployeeMasterIDList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterIDList"]);
                       
                        item.ComplianceType = sqlDataReader["ComplianceType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ComplianceType"]);
                        item.CalculateOnFixedAmount = sqlDataReader["CalculateOnFixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["CalculateOnFixedAmount"]), 2);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeSalaryTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<EmployeeSalaryTransaction> GenerateSaleContractBulkSalaryTransaction(EmployeeSalaryTransaction item)
        {
            IBaseEntityResponse<EmployeeSalaryTransaction> response = new BaseEntityResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalaryTransaction_InsertXMLBulkSalary";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siEmployeeSalarySpanID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeSalarySpanID));
                  //  cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DepartmentMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringBulkSalaryTransactionEmployee", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLStringBulkSalaryTransactionEmployee));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringBulkSalaryTransaction", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLStringBulkSalaryTransaction));
                    if (item.XMLstringForVouchar != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForVouchar", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForVouchar));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForVouchar", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
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

        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionDetailsForSalarySheet(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalaryTransactionSalaryReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.CommandTimeout = 0;
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

                    baseEntityCollection.CollectionResponse = new List<EmployeeSalaryTransaction>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeSalaryTransaction item = new EmployeeSalaryTransaction();

                        item.EmployeeName= sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        item.EmployeeMasterID = sqlDataReader["EmployeeMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeMasterID"]);
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
                        item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);
                        item.CalculateOnString = sqlDataReader["CalculateOnString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnString"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeSalaryTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<EmployeeSalaryTransaction> DeleteEmployeeSalary(EmployeeSalaryTransaction item)
        {
            IBaseEntityResponse<EmployeeSalaryTransaction> response = new BaseEntityResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalary_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiID", SqlDbType.BigInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));

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
                        throw new Exception("Stored Procedure 'USP_CCRMBrokenCallReasonMaster_Delete' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetEmployeeSalarySheetExcel(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalaryTransaction_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.CommandTimeout = 0;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCenterCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CenterCode));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siEmployeeSalarySpanID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeSalarySpanID));

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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);

                    baseEntityCollection.CollectionResponse = new List<EmployeeSalaryTransaction>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeSalaryTransaction item = new EmployeeSalaryTransaction();
                        item.EmployeeName = sqlDataReader["EmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeMasterName"]);
                        item.EmployeeMasterID = sqlDataReader["EmployeeMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeMasterID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.BasicAmount = sqlDataReader["BasicAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BasicAmount"]);
                        item.OvertimeHours = sqlDataReader["TotalOvertime"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalOvertime"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]), 2);
                        item.TotalSalary = sqlDataReader["TotalSalary"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalSalary"]), 2);
                        item.NetPayable = sqlDataReader["NetPayable"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["NetPayable"]), 2);

                        item.EmployeeSalarySpanID = sqlDataReader["EmployeeSalarySpanID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["EmployeeSalarySpanID"]);
                        item.SpanName = sqlDataReader["SpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SpanName"]);
                        item.RuleType = sqlDataReader["RuleType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RuleType"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.HeadID = sqlDataReader["HeadID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["HeadID"]);
                        item.IsAllowance = sqlDataReader["IsAllowance"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsAllowance"]);
                        item.Amount = sqlDataReader["Amount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Amount"]), 2);
                        item.HeadType = sqlDataReader["HeadType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadType"]);
                        item.HeadSubType = sqlDataReader["HeadSubType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadSubType"]);
                        item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        item.SaleContractEmployeeMasterIDList = sqlDataReader["SaleContractEmployeeMasterIDList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterIDList"]);
                        item.ComplianceType = sqlDataReader["ComplianceType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ComplianceType"]);                    
                        item.SalaryMonth = sqlDataReader["SalaryMonth"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalaryMonth"]);
                        item.SalaryYear = sqlDataReader["SalaryYear"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalaryYear"]);
                        item.CalculateOnString = sqlDataReader["CalculateOnString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnString"]);
                        item.CalculateOnFixedAmount = sqlDataReader["CalculateOnFixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["CalculateOnFixedAmount"]), 2);
                        item.BankACNumber = sqlDataReader["BankACNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankACNumber"]);
                        item.ESINumber = sqlDataReader["ESINumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ESINumber"]);
                        item.ProvidentFundNumber = sqlDataReader["ProvidentFundNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ProvidentFundNumber"]);
                        item.UANNumber = sqlDataReader["UANNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UANNumber"]);
                        item.DesignationName = sqlDataReader["DesignationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DesignationName"]);
                        item.DepartmentName = sqlDataReader["DepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DepartmentName"]);
                        item.EmployeeCode = sqlDataReader["EmployeeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeCode"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrganisationDepartmentMaster_Departmentwise' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionDetailsForNRSheet(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalaryTransactionNRReport";
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

                    baseEntityCollection.CollectionResponse = new List<EmployeeSalaryTransaction>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeSalaryTransaction item = new EmployeeSalaryTransaction();

                        item.EmployeeName= sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        item.EmployeeMasterID = sqlDataReader["EmployeeMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeMasterID"]);
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
                        throw new Exception("Stored Procedure 'USP_EmployeeSalaryTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetListEmployeeSalaryTransactionDeduction(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalaryTransactionDeduction_RunTime_SelectList";
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

                    baseEntityCollection.CollectionResponse = new List<EmployeeSalaryTransaction>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeSalaryTransaction item = new EmployeeSalaryTransaction();

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
                        throw new Exception("Stored Procedure 'USP_EmployeeSalaryTransactionDeduction_RunTime_SelectList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<EmployeeSalaryTransaction> AddEmployeeSalaryTransactionDeduction(EmployeeSalaryTransaction item)
        {
            IBaseEntityResponse<EmployeeSalaryTransaction> response = new BaseEntityResponse<EmployeeSalaryTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeSalaryTransactionDeduction_RunTime_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeSalaryRulesID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeSalaryRulesID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractManPowerDeductionID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractManPowerDeductionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiHeadID", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.HeadID));
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
                        throw new Exception("Stored Procedure 'USP_EmployeeSalaryTransactionDeduction_RunTime_Insert' reported the ErrorCode: " +
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
