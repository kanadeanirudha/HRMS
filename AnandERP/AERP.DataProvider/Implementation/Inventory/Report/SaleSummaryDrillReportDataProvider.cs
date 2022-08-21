using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public class SaleSummaryDrillReportDataProvider : DBInteractionBase, ISaleSummaryDrillReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public SaleSummaryDrillReportDataProvider() { }
        public SaleSummaryDrillReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_YearList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleSummaryDrillReport_YearWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<SaleSummaryDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        SaleSummaryDrillReport item = new SaleSummaryDrillReport();

                        item.Date = sqlDataReader["Date"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Date"]);
                        item.TotalCard = sqlDataReader["TotalCard"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCard"]);
                        item.TotalCash = sqlDataReader["TotalCash"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCash"]);
                        item.TotalSale = sqlDataReader["TotalSale"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalSale"]);
                        item.SalesReturnAmount = sqlDataReader["SalesReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SalesReturnAmount"]);
                        item.CentreName = searchRequest.CentreName;
                        item.NextReport = searchRequest.NextReport;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleSummeryReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_MonthList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleSummaryDrillReport_MonthWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Date));
                   
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<SaleSummaryDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        SaleSummaryDrillReport item = new SaleSummaryDrillReport();

                        item.Date = sqlDataReader["Date"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Date"]);
                        item.TotalCard = sqlDataReader["TotalCard"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCard"]);
                        item.TotalCash = sqlDataReader["TotalCash"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCash"]);
                        item.TotalSale = sqlDataReader["TotalSale"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalSale"]);
                        item.SalesReturnAmount = sqlDataReader["SalesReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SalesReturnAmount"]);

                        item.NextReport = searchRequest.NextReport;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleSummeryReport_DateWise_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_DayList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleSummaryDrillReport_DayWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Date));
                   
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<SaleSummaryDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        SaleSummaryDrillReport item = new SaleSummaryDrillReport();

                        item.Date = sqlDataReader["Date"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Date"]);
                        item.TotalCard = sqlDataReader["TotalCard"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCard"]);
                        item.TotalCash = sqlDataReader["TotalCash"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCash"]);
                        item.TotalSale = sqlDataReader["TotalSale"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalSale"]);
                        item.SalesReturnAmount = sqlDataReader["SalesReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SalesReturnAmount"]);

                        item.NextReport = searchRequest.NextReport;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleSummeryReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_BillList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleSummaryDrillReport_BillWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Date));

                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<SaleSummaryDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        SaleSummaryDrillReport item = new SaleSummaryDrillReport();

                        item.Date = sqlDataReader["Date"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Date"]);
                        item.TotalCard = sqlDataReader["TotalCard"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCard"]);
                        item.TotalCash = sqlDataReader["TotalCash"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalCash"]);
                        item.BillNumber = sqlDataReader["BillNumber"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["BillNumber"]);
                        item.SalesReturnAmount = sqlDataReader["SalesReturnAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SalesReturnAmount"]);
                        item.BillFor = sqlDataReader["BillFor"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["BillFor"]);

                        item.NextReport = searchRequest.NextReport;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleSummeryReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_ItemList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleSummaryDrillReport_ItemWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBillNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BillNumber));

                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<SaleSummaryDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        SaleSummaryDrillReport item = new SaleSummaryDrillReport();

                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.Price = sqlDataReader["Price"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Price"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.TotalPrice = sqlDataReader["TotalPrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalPrice"]);
                        item.DiscountAmount = sqlDataReader["DiscountAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DiscountAmount"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalAmount"]);

                        item.BillNumber = searchRequest.BillNumber;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleSummeryReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_ItemListSaleReturn(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
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
                    _wareHouseDbConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _wareHouseDbConnection;
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_SaleSummaryDrillReport_ItemWiseSaleReturn";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBillNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BillNumber));

                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_wareHouseDbConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _wareHouseDbConnection.Open();
                    }
                    else
                    {
                        if (_wareHouseDbConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _wareHouseDbConnectionProvider.CurrentTransaction;
                        }
                    }

                    sqlDataReader = cmdToExecute.ExecuteReader();

                    baseEntityCollection.CollectionResponse = new List<SaleSummaryDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        SaleSummaryDrillReport item = new SaleSummaryDrillReport();

                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.Price = sqlDataReader["SaleReturnPrice"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnPrice"]);
                        item.Quantity = sqlDataReader["SaleReturnQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["SaleReturnQuantity"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalAmount"]);
                        item.DiscountAmount = sqlDataReader["DiscountAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DiscountAmount"]);

                        item.BillNumber = searchRequest.BillNumber;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleSummeryReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
                if (_wareHouseDbConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _wareHouseDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
    }
}
