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
    public class ContractEmployeeReportDataProvider : DBInteractionBase, IContractEmployeeReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public ContractEmployeeReportDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public ContractEmployeeReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<ContractEmployeeReport> GetContractEmployeeReportDataList(ContractEmployeeReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ContractEmployeeReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ContractEmployeeReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractEmployeeMaster_SelectAllReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiType", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ReportType));


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

                    baseEntityCollection.CollectionResponse = new List<ContractEmployeeReport>();
                    while (sqlDataReader.Read())
                    {
                        ContractEmployeeReport item = new ContractEmployeeReport();
                        item.Title = sqlDataReader["Title"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Title"]);
                        item.FirstName = sqlDataReader["FirstName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FirstName"]);
                        item.MiddleName = sqlDataReader["MiddleName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MiddleName"]);
                        item.LastName = sqlDataReader["LastName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LastName"]);
                        item.EmployeeCode = sqlDataReader["EmployeeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeCode"]);
                        item.FirstJoiningDate = sqlDataReader["FirstJoiningDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FirstJoiningDate"]);
                        item.IsLeft = sqlDataReader["IsLeft"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsLeft"]);
                        item.LastLeftDate = sqlDataReader["LastLeftDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LastLeftDate"]);
                        item.GenderCode = sqlDataReader["GenderCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GenderCode"]);
                        item.ESINumber = sqlDataReader["ESINumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ESINumber"]);
                        item.ProvidentFundNumber = sqlDataReader["ProvidentFundNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ProvidentFundNumber"]);
                        item.UANNumber = sqlDataReader["UANNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UANNumber"]);
                        item.BankName = sqlDataReader["BankName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankName"]);
                        item.BankACNumber = sqlDataReader["BankACNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankACNumber"]);
                        item.BankIFSICode = sqlDataReader["BankIFSICode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankIFSICode"]);
                        item.Birthdate = sqlDataReader["Birthdate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Birthdate"]);
                        item.ZoneName = sqlDataReader["ZoneName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ZoneName"]);
                        item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);
                        item.ReasonForLeft = sqlDataReader["ReasonForLeft"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ReasonForLeft"]);

                        item.CentreCode = searchRequest.CentreCode;
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ContractEmployeeReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<ContractEmployeeReport> InsertContractEmployeeReport(ContractEmployeeReport item)
        {
            IBaseEntityResponse<ContractEmployeeReport> response = new BaseEntityResponse<ContractEmployeeReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_ContractEmployeeReport_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractBillingSpanID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForContractEmployeeReportData", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForContractEmployeeReportData));
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

        public IBaseEntityCollectionResponse<ContractEmployeeReport> GetContractEmployeeWorkDetailsReportDataList(ContractEmployeeReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ContractEmployeeReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ContractEmployeeReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractEmployeeMasterWorkDetails_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (searchRequest.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractEmployeeMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractEmployeeMasterID));


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

                    baseEntityCollection.CollectionResponse = new List<ContractEmployeeReport>();
                    while (sqlDataReader.Read())
                    {
                        ContractEmployeeReport item = new ContractEmployeeReport();
                        item.FromDate = sqlDataReader["FromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromDate"]);
                        item.UptoDate = sqlDataReader["UptoDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UptoDate"]);
                        item.Narration = sqlDataReader["Narration"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Narration"]);

                        item.SaleContractEmployeeMasterName = searchRequest.SaleContractEmployeeMasterName;
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ContractEmployeeReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
