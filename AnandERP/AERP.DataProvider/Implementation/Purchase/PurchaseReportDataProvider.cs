using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace AMS.DataProvider
{
    public class PurchaseReportDataProvider : DBInteractionBase, IPurchaseReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion


        #region Constructor


        /// Constructor to initialized data member and member functions       
        public PurchaseReportDataProvider()
        {
        }


        /// Constructor to initialized data member and member functions       
        public PurchaseReportDataProvider(ILogger logException)
        {
            _connectionString = "";
            _logException = logException;
        }

        #endregion


        #region Method Implementation PurchaseReport

        public IBaseEntityCollectionResponse<PurchaseReport> GetTopFiveVendorReport(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardTopFiveAccountDetailsByEmployee_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<PurchaseReport>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReport item = new PurchaseReport();


                        //if (DBNull.Value.Equals(sqlDataReader["Months"].ToString()) == false)
                        //{
                        //    item.InvoiceMonth = Convert.ToString(sqlDataReader["Months"]);
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["TotalInvoiceAmountList"].ToString()) == false)
                        //{
                        //    item.TotalInvoiceAmountList = Convert.ToString(sqlDataReader["TotalInvoiceAmountList"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        //{
                        //    item.AccountName = Convert.ToString(sqlDataReader["AccountName"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                        // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyPurchaseReport(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardMonthlyRevenueDetailsByEmployee_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<PurchaseReport>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReport item = new PurchaseReport();


                        //if (DBNull.Value.Equals(sqlDataReader["TotalInvoiceAmount"].ToString()) == false)
                        //{
                        //    item.TotalInvoiceAmount = Convert.ToString(sqlDataReader["TotalInvoiceAmount"]);
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["CallCountList"].ToString()) == false)
                        //{
                        //    item.TotalInvoiceAmount = Convert.ToString(sqlDataReader["CallCountList"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["MonthName"].ToString()) == false)
                        //{
                        //    item.InvoiceMonth = Convert.ToString(sqlDataReader["MonthName"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                        // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<PurchaseReport> GetRequisitionConversionReport(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleWicklyStatusDetailsInDateRange_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                  //  cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                  //  cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
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

                    baseEntityCollection.CollectionResponse = new List<PurchaseReport>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReport item = new PurchaseReport();


                        //if (DBNull.Value.Equals(sqlDataReader["ScheduleDescription"].ToString()) == false)
                        //{
                        //    item.ScheduleDescription = Convert.ToString(sqlDataReader["ScheduleDescription"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TransactionDate"].ToString()) == false)
                        //{
                        //    item.TransactionDate = Convert.ToDateTime(sqlDataReader["TransactionDate"].ToString());
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TransactionFromDateTime"].ToString()) == false)
                        //{
                        //    item.TransactionFromDateTime = Convert.ToDateTime(sqlDataReader["TransactionFromDateTime"].ToString());
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["TransactionUpToTime"].ToString()) == false)
                        //{
                        //    item.TransactionUpToTime = Convert.ToDateTime(sqlDataReader["TransactionUpToTime"].ToString());
                        //}


                        //if (DBNull.Value.Equals(sqlDataReader["ScheduleTimeInMin"].ToString()) == false)
                        //{
                        //    item.ScheduleTimeInMin = Convert.ToInt32(sqlDataReader["ScheduleTimeInMin"]);
                        //}

                        //if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 1)
                        //{
                        //    if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 1)
                        //    {
                        //        item.BackgroundColor = "#795548";
                        //    }
                        //    else if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 2)
                        //    {
                        //        item.BackgroundColor = "#009688";
                        //    }
                        //    else if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 3)
                        //    {
                        //        item.BackgroundColor = "#3F51B5";
                        //    }
                        //    else if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 4)
                        //    {
                        //        item.BackgroundColor = "#9C27B0";
                        //    }
                        //}
                        //else if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 2)
                        //{
                        //    item.BackgroundColor = "#03A9F4";
                        //}
                        //else if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 3)
                        //{
                        //    item.BackgroundColor = "#673AB7";
                        //}
                        //else if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 4)
                        //{
                        //    item.BackgroundColor = "#607D8B";
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["InvoiceNumber"].ToString()) == false)
                        //{
                        //    item.InvoiceNumber = sqlDataReader["InvoiceNumber"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["InvoiceDate"].ToString()) == false)
                        //{
                        //    item.InvoiceDate = sqlDataReader["InvoiceDate"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["InvoiceAmount"].ToString()) == false)
                        //{
                        //    item.InvoiceAmount = Convert.ToDecimal(sqlDataReader["InvoiceAmount"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        //{
                        //    item.AccountName = sqlDataReader["AccountName"].ToString();
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseReport_SelectAll' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<PurchaseReport> GetPurchaseOrderConversionReport(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleWicklyStatusDetailsInDateRange_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
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

                    baseEntityCollection.CollectionResponse = new List<PurchaseReport>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReport item = new PurchaseReport();


                        //if (DBNull.Value.Equals(sqlDataReader["ScheduleDescription"].ToString()) == false)
                        //{
                        //    item.ScheduleDescription = Convert.ToString(sqlDataReader["ScheduleDescription"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TransactionDate"].ToString()) == false)
                        //{
                        //    item.TransactionDate = Convert.ToDateTime(sqlDataReader["TransactionDate"].ToString());
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TransactionFromDateTime"].ToString()) == false)
                        //{
                        //    item.TransactionFromDateTime = Convert.ToDateTime(sqlDataReader["TransactionFromDateTime"].ToString());
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["TransactionUpToTime"].ToString()) == false)
                        //{
                        //    item.TransactionUpToTime = Convert.ToDateTime(sqlDataReader["TransactionUpToTime"].ToString());
                        //}


                        //if (DBNull.Value.Equals(sqlDataReader["ScheduleTimeInMin"].ToString()) == false)
                        //{
                        //    item.ScheduleTimeInMin = Convert.ToInt32(sqlDataReader["ScheduleTimeInMin"]);
                        //}

                        //if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 1)
                        //{
                        //    if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 1)
                        //    {
                        //        item.BackgroundColor = "#795548";
                        //    }
                        //    else if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 2)
                        //    {
                        //        item.BackgroundColor = "#009688";
                        //    }
                        //    else if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 3)
                        //    {
                        //        item.BackgroundColor = "#3F51B5";
                        //    }
                        //    else if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 4)
                        //    {
                        //        item.BackgroundColor = "#9C27B0";
                        //    }
                        //}
                        //else if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 2)
                        //{
                        //    item.BackgroundColor = "#03A9F4";
                        //}
                        //else if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 3)
                        //{
                        //    item.BackgroundColor = "#673AB7";
                        //}
                        //else if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 4)
                        //{
                        //    item.BackgroundColor = "#607D8B";
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["InvoiceNumber"].ToString()) == false)
                        //{
                        //    item.InvoiceNumber = sqlDataReader["InvoiceNumber"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["InvoiceDate"].ToString()) == false)
                        //{
                        //    item.InvoiceDate = sqlDataReader["InvoiceDate"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["InvoiceAmount"].ToString()) == false)
                        //{
                        //    item.InvoiceAmount = Convert.ToDecimal(sqlDataReader["InvoiceAmount"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        //{
                        //    item.AccountName = sqlDataReader["AccountName"].ToString();
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<PurchaseReport> PurchaseReportSparkLineChartReportByEmployeeID(PurchaseReport item)
        {
            IBaseEntityResponse<PurchaseReport> response = new BaseEntityResponse<PurchaseReport>();
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
                    if (item.DataFor == "TotalVendor")
                    {
                        cmdToExecute.CommandText = "dbo.USP_PurchaseDashboardSparklineCharts_VendorCount";
                    }
                    else if (item.DataFor == "TotalRequisition")
                    {
                        cmdToExecute.CommandText = "dbo.USP_PurchaseDashboardSparklineCharts_RequisitionCount";
                    }
                    else if (item.DataFor == "TotalPurchaseOrder")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_PurchaseOrderCount";
                    }
                    else if (item.DataFor == "TotalPendingPurchaseOrder")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_PendingPurchaseOrderCount";
                    }
                    else if (item.DataFor == "TotalManualRequisition")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_ManualRequisitionCount";
                    }
                    else if (item.DataFor == "TotalItemBelowSafetyStock")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_ItemBelowSafetyStockCount";
                    }
                    else if (item.DataFor == "TotalItemBelowReorderPoint")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_ItemBelowReorderPointCount";
                    }
                   

                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sDataFor", SqlDbType.VarChar, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.DataFor));

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

                        PurchaseReport _item = new PurchaseReport();
                       // _item.ReportCount = Convert.ToInt32(sqlDataReader["ReportCount"]);
                       // _item.ReportList = Convert.ToString(sqlDataReader["ReportList"]);
                        //if (item.DataFor == "AccountTarget" || item.DataFor == "BillingTarget")
                        //{
                        //    _item.PeriodType = Convert.ToString(sqlDataReader["PeriodType"]);
                        //}
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyMarginDetails(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardTopFiveAccountDetailsByEmployee_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<PurchaseReport>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReport item = new PurchaseReport();


                        //if (DBNull.Value.Equals(sqlDataReader["Months"].ToString()) == false)
                        //{
                        //    item.InvoiceMonth = Convert.ToString(sqlDataReader["Months"]);
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["TotalInvoiceAmountList"].ToString()) == false)
                        //{
                        //    item.TotalInvoiceAmountList = Convert.ToString(sqlDataReader["TotalInvoiceAmountList"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        //{
                        //    item.AccountName = Convert.ToString(sqlDataReader["AccountName"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                        // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyPurchaseOrderDetails(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseDashboardCharts_PurchaseOrderDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.UtcNow));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<PurchaseReport>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseReport item = new PurchaseReport();


                        item.ReportList = sqlDataReader["ReportList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ReportList"]);
                        item.Months = sqlDataReader["Months"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Months"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                        // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
