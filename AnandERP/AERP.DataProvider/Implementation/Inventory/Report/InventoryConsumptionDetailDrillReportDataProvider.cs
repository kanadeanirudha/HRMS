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
    public class InventoryConsumptionDetailDrillReportDataProvider : DBInteractionBase, IInventoryConsumptionDetailDrillReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public InventoryConsumptionDetailDrillReportDataProvider() { }
        public InventoryConsumptionDetailDrillReportDataProvider(ILogger logException)
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


        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_GroupDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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

                    cmdToExecute.CommandText = "dbo.USP_InventoryConsumptionGroupDescription_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();
                        item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                        item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                       
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.ConsumptionQuantity = sqlDataReader["ConsumptionQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionQuantity"]);
                        item.ConsumptionBaseQuantity = sqlDataReader["ConsumptionBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionBaseQuantity"]);
                        item.ConsumptionAmount = sqlDataReader["ConsumptionAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageBaseQuantity = sqlDataReader["WastageBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageBaseQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);

                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseDepartmentNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryConsumptionMerchantiseDepartment_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsGroupDescriptionCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MarchandiseGroupCode));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();

                        item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                      //  item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                        item.MerchantiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                        item.MerchantiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.ConsumptionQuantity = sqlDataReader["ConsumptionQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionQuantity"]);
                        item.ConsumptionBaseQuantity = sqlDataReader["ConsumptionBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionBaseQuantity"]);
                        item.ConsumptionAmount = sqlDataReader["ConsumptionAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageBaseQuantity = sqlDataReader["WastageBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageBaseQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);

                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");

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
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryConsumptionMerchantiseCategory_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMerchantiseDepartmentCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MerchantiseDepartmentCode));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();
           
                        item.MerchantiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                        item.MerchantiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.ConsumptionQuantity = sqlDataReader["ConsumptionQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionQuantity"]);
                        item.ConsumptionBaseQuantity = sqlDataReader["ConsumptionBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionBaseQuantity"]);
                        item.ConsumptionAmount = sqlDataReader["ConsumptionAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageBaseQuantity = sqlDataReader["WastageBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageBaseQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);


                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");

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

        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseSubCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryConsumptionMerchantiseSubCategory_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMerchantiseCategoryCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MerchantiseCategoryCode));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();


                        item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                        item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.ConsumptionQuantity = sqlDataReader["ConsumptionQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionQuantity"]);
                        item.ConsumptionBaseQuantity = sqlDataReader["ConsumptionBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionBaseQuantity"]);
                        item.ConsumptionAmount = sqlDataReader["ConsumptionAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageBaseQuantity = sqlDataReader["WastageBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageBaseQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);

                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");

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
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseBaseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryConsumptionMerchantiseBaseCategory_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMerchantiseSubCategoryCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MarchandiseSubCatgoryCode));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();

                        item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                        item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.ConsumptionQuantity = sqlDataReader["ConsumptionQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionQuantity"]);
                        item.ConsumptionBaseQuantity = sqlDataReader["ConsumptionBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionBaseQuantity"]);
                        item.ConsumptionAmount = sqlDataReader["ConsumptionAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageBaseQuantity = sqlDataReader["WastageBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageBaseQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);

                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");
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
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_DescriptionWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryConsumptionItemDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMerchantiseBaseCategoryCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MarchandiseBaseCatgoryCode));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();

                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32(): Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                         //item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.ConsumptionQuantity = sqlDataReader["ConsumptionQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionQuantity"]);
                        item.ConsumptionBaseQuantity = sqlDataReader["ConsumptionBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionBaseQuantity"]);
                        item.ConsumptionAmount = sqlDataReader["ConsumptionAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ConsumptionAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageBaseQuantity = sqlDataReader["WastageBaseQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageBaseQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);
                        item.ConsumptionUOM = sqlDataReader["ConsumptionUOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ConsumptionUOM"]);
                        item.BaseUOM = sqlDataReader["BaseUOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUOM"]);

                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");
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
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetGeneralUnitsDropdownForProccesingUnit(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralUnits_DropDownForProcessUnit";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    //cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();

                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralUnitsId"]);
                        item.GeneralUnitsName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        item.ProcessUnitID = sqlDataReader["ProcessUnitID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ProcessUnitID"]);

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

        //------------------------------------------------------Sale and Wastage--------------------------------------

        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_GroupDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySaleGroupDescription_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                   

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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();

                        item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                        item.MarchandiseGroupCode = sqlDataReader["MarchandiseGroupCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.SaleQuantity = sqlDataReader["SaleQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleQuantity"]);
                        item.SaleAmount = sqlDataReader["SaleAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);

                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySaleGroupDescription_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseDepartmentNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySaleMerchantiseDepartment_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsGroupDescriptionCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MarchandiseGroupCode));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();

                        item.GroupDescription = sqlDataReader["GroupDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GroupDescription"]);
                        item.MerchandiseDepartmentName = sqlDataReader["MerchantiseDepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentName"]);
                        item.MerchandiseDepartmentCode = sqlDataReader["MerchantiseDepartmentCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseDepartmentCode"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.SaleQuantity = sqlDataReader["SaleQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleQuantity"]);
                        item.SaleAmount = sqlDataReader["SaleAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);

                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySaleMerchantiseDepartment_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySaleMerchantiseCategory_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMerchantiseDepartmentCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MerchandiseDepartmentCode));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();

                        item.MerchandiseCategoryCode = sqlDataReader["MerchantiseCategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryCode"]);
                        item.MerchandiseCategoryName = sqlDataReader["MerchantiseCategoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MerchantiseCategoryName"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.SaleQuantity = sqlDataReader["SaleQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleQuantity"]);
                        item.SaleAmount = sqlDataReader["SaleAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);
                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySaleMerchantiseCategory_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseSubCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySaleMerchantiseSubCategory_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMerchantiseCategoryCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MerchandiseCategoryCode));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();

                        item.MarchandiseSubCatgoryName = sqlDataReader["MarchandiseSubCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryName"]);
                        item.MarchandiseSubCatgoryCode = sqlDataReader["MarchandiseSubCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseSubCatgoryCode"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.SaleQuantity = sqlDataReader["SaleQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleQuantity"]);
                        item.SaleAmount = sqlDataReader["SaleAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);
                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySaleMerchantiseSubCategory_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseBaseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySaleMerchantiseBaseCategory_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMerchantiseSubCategoryCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MarchandiseSubCatgoryCode));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();

                        item.MarchandiseBaseCatgoryCode = sqlDataReader["MarchandiseBaseCatgoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);
                        item.MarchandiseBaseCatgoryName = sqlDataReader["MarchandiseBaseCatgoryName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryName"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.SaleQuantity = sqlDataReader["SaleQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleQuantity"]);
                        item.SaleAmount = sqlDataReader["SaleAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);
                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySaleMerchantiseBaseCategory_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_ItemDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySaleItemDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitsID", SqlDbType.Int, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGranuality", SqlDbType.TinyInt, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Granularity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUpToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DateTo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMerchantiseBaseCategoryCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MarchandiseBaseCatgoryCode));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryConsumptionDetailDrillReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryConsumptionDetailDrillReport item = new InventoryConsumptionDetailDrillReport();

                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.TransactionDateTime = sqlDataReader["TransactionDateTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDateTime"]);
                        item.SaleQuantity = sqlDataReader["SaleQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleQuantity"]);
                        item.SaleAmount = sqlDataReader["SaleAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["SaleAmount"]);
                        item.WastageQuantity = sqlDataReader["WastageQuantity"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageQuantity"]);
                        item.WastageAmount = sqlDataReader["WastageAmount"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["WastageAmount"]);
                        item.GeneralUnitsName = searchRequest.GeneralUnitsName;
                        item.GranularityName = searchRequest.GranularityName;
                        DateTime DateFrom = Convert.ToDateTime(searchRequest.DateFrom);
                        DateTime DateTo = Convert.ToDateTime(searchRequest.DateTo);

                        item.DateFrom = DateFrom.ToString("d MMMM yyyy");
                        item.DateTo = DateTo.ToString("d MMMM yyyy");
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySaleItemDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
