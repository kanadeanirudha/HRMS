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
    public class GSTReportsDataProvider : DBInteractionBase, IGSTReportsDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public GSTReportsDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public GSTReportsDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<GSTReports> GetGSTR1ReportsDataList(GSTReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GSTReports> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GSTReports>();
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
                    cmdToExecute.CommandText = "dbo.USP_GSTR1Reports_Select";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));

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

                    baseEntityCollection.CollectionResponse = new List<GSTReports>();
                    while (sqlDataReader.Read())
                    {
                        GSTReports item = new GSTReports();

                        item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        item.GSTINNumber = sqlDataReader["GSTINNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GSTINNumber"]);
                        item.InvoiceNumber = sqlDataReader["InvoiceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["InvoiceNumber"]);
                        item.InvoiceType = sqlDataReader["InvoiceType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["InvoiceType"]);
                        item.InvoiceDate = sqlDataReader["InvoiceDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["InvoiceDate"]);
                        item.PlaceOfSupply = sqlDataReader["PlaceOfSupply"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlaceOfSupply"]);
                        item.ReverseCharge = sqlDataReader["ReverseCharge"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ReverseCharge"]);
                        item.HSNCode = sqlDataReader["HSNCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HSNCode"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.UOMCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.TaxableAmount = sqlDataReader["TaxableAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxableAmount"]);
                        item.IGST = sqlDataReader["IGST"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["IGST"]);
                        item.CGST = sqlDataReader["CGST"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CGST"]);
                        item.SGST = sqlDataReader["SGST"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SGST"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAmount"]);
                        item.FromDate = searchRequest.FromDate;
                        item.UptoDate = searchRequest.UptoDate;
                        item.CentreName = searchRequest.CentreName;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GSTReports_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<GSTReports> GetGSTR2ReportsDataList(GSTReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GSTReports> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GSTReports>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeesProvidentFundsForm6A";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));

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

                    baseEntityCollection.CollectionResponse = new List<GSTReports>();
                    while (sqlDataReader.Read())
                    {
                        GSTReports item = new GSTReports();



                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GSTReports_SelectAll' reported the ErrorCode: " + _errorCode);
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
