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
    public class PurchaseRequisitionMasterDataProvider : DBInteractionBase, IPurchaseRequisitionMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public PurchaseRequisitionMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public PurchaseRequisitionMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from PurchaseRequisitionMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterBySearch(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseRequisitionMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPurchaseRequisitionType", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseRequisitionType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransDate", SqlDbType.NVarChar, 25, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TransDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMonthName", SqlDbType.NVarChar, 25, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MonthName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMonthYear", SqlDbType.NVarChar, 25, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MonthYear));

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
                    baseEntityCollection.CollectionResponse = new List<PurchaseRequisitionMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseRequisitionMaster item = new PurchaseRequisitionMaster();
                        item.ID = sqlDataReader["PurchaseRequisitionID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseRequisitionID"]);
                        item.Vendor = sqlDataReader["Vender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
                        item.VendorID = sqlDataReader["VendorID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorID"]);
                        item.PurchaseRequisitionNumber = sqlDataReader["PurchaseRequisitionNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseRequisitionNumber"]);
                        item.PurchaseRequisitionBehaviour = Convert.ToString(sqlDataReader["PurchaseRequisitionBehaviour"]);
                        item.IsOpenForPO = Convert.ToBoolean(sqlDataReader["IsOpenForPO"]);

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
                        throw new Exception("Stored Procedure 'USP_PurchaseRequisitionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterList(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetPurchaseRequirementAndBelowStockSafetyLevelRecordList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiRequisitionBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseRequisitionBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFromDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUptoDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));

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
                    baseEntityCollection.CollectionResponse = new List<PurchaseRequisitionMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseRequisitionMaster item = new PurchaseRequisitionMaster();
                        //item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.PurchaseRequirementMasterID = sqlDataReader["PurchaseRequirementMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseRequirementMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemName = sqlDataReader["ItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        item.ApprovedQuantity = sqlDataReader["ApprovedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ApprovedQuantity"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.PriorityFlag = sqlDataReader["PriorityFlag"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["PriorityFlag"]);
                        if (item.PriorityFlag == 1)
                        {
                            item.Priority = "High";
                        }
                        else if (item.PriorityFlag == 2)
                        {
                            item.Priority = "Medium";
                        }
                        else if (item.PriorityFlag == 3)
                        {
                            item.Priority = "Low";
                        }
                        item.StorageLocationID = sqlDataReader["StorageLocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StorageLocationID"]);

                        item.LocationAddress = sqlDataReader["LocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.ExpectedDeliveryDate = sqlDataReader["ExpectedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExpectedDate"]);
                        item.PurchaseRequirementDetailsID = sqlDataReader["PurchaseRequirementDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseRequirementDetailsID"]);
                        item.PurchaseRequirementNumber = sqlDataReader["PurchaseRequirementNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseRequirementNumber"]);
                        item.DepartmentID = sqlDataReader["DepartmentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxRate"]);

                        var Amount = (item.ApprovedQuantity * item.Rate);
                        var taxamount = ((Amount * item.TaxRate) / 100);
                        var grossAmmount = Amount + taxamount;

                        item.Ammount = Amount;
                        item.TaxAmount = taxamount;
                        item.GrossAmount = grossAmmount;

                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.UnitCode = sqlDataReader["OrderUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        item.IsDefaultVendor = sqlDataReader["IsDefaultVendor"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsDefaultVendor"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);
                        item.CurrentStockQtyWithBaseUOM = sqlDataReader["CurrentStockQtyWithBaseUOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CurrentStockQtyWithBaseUOM"]);
                        item.CustomerBranchName = sqlDataReader["CustomerBranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchName"]);
                        item.SaleUoM = sqlDataReader["SaleUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleUomCode"]);
                        item.SalesOrderQuantity = sqlDataReader["SalesOrderQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SalesOrderQuantity"]);
                        item.RequiredSaleQuantity = sqlDataReader["RequiredSaleQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["RequiredSaleQuantity"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseRequisitionMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// <summary>
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterByID(PurchaseRequisitionMaster item)
        {
            IBaseEntityResponse<PurchaseRequisitionMaster> response = new BaseEntityResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseRequisitionMaster_SelectOne";
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
                        PurchaseRequisitionMaster _item = new PurchaseRequisitionMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        _item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
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
        /// <summary>
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseRequisitionMaster> InsertPurchaseRequisitionMaster(PurchaseRequisitionMaster item)
        {
            IBaseEntityResponse<PurchaseRequisitionMaster> response = new BaseEntityResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseRequisitionMaster_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransDate", SqlDbType.DateTime, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, DateTime.UtcNow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPurchaseRequisitionType", SqlDbType.TinyInt, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PurchaseRequisitionType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsOpenForPO", SqlDbType.Bit, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPRStatus", SqlDbType.TinyInt, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, 3));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPurchaseRequisitionXml", SqlDbType.Xml, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.XMLstring));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPurchaseRequisitionBehaviour", SqlDbType.NVarChar, 10,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PurchaseRequisitionBehaviour));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiRequisitionBy", SqlDbType.TinyInt, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.PurchaseRequisitionBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
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
                    item.ErrorCode = 0;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseRequirementMaster_InsertXML' reported the ErrorCode: " + _errorCode);
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
        /// <summary>
        /// Update a specific record of PurchaseRequisitionMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        public IBaseEntityResponse<PurchaseRequisitionMaster> InsertApprovedPurchaseRequisitionRecord(PurchaseRequisitionMaster item)
        {
            IBaseEntityResponse<PurchaseRequisitionMaster> response = new BaseEntityResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseRequirement_InsertApprovedRecord";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToByte(item.IsLastRecord)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskReportingDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskReportingDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StageSequenceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtApprovedDate", SqlDbType.DateTime, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(DateTime.UtcNow)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xDumpAndShrinkDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTaskCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Status));
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
                        item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryDumpAndShrinkMasterAndDetails_INSERT' reported the ErrorCode: " + _errorCode);
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
                    _onlineDbConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }
        public IBaseEntityResponse<PurchaseRequisitionMaster> UpdatePurchaseRequisitionMaster(PurchaseRequisitionMaster item)
        {
            IBaseEntityResponse<PurchaseRequisitionMaster> response = new BaseEntityResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseRequisitionMaster_UpdateXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPurchaseRequisitionUpdateXml", SqlDbType.Xml, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.XMLstring));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFreight", SqlDbType.Money, 0,
                                       ParameterDirection.Input, false, 10, 0, "",
                                       DataRowVersion.Proposed, item.Freight));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mShippingHandling", SqlDbType.Money, 0,
                                       ParameterDirection.Input, false, 10, 0, "",
                                       DataRowVersion.Proposed, item.ShippingHandling));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 0,
                                       ParameterDirection.Input, false, 10, 0, "",
                                       DataRowVersion.Proposed, item.TaxAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mGrossAmount", SqlDbType.Money, 0,
                                      ParameterDirection.Input, false, 10, 0, "",
                                      DataRowVersion.Proposed, item.AmmountIncludingTax));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mDiscount", SqlDbType.Money, 0,
                                       ParameterDirection.Input, false, 10, 0, "",
                                       DataRowVersion.Proposed, item.Discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsOpenForPO", SqlDbType.Bit, 10,
                                       ParameterDirection.Input, false, 0, 0, "",
                                       DataRowVersion.Proposed, item.IsOpenForPO));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                        ParameterDirection.Output, true, 10, 0, "",
                                        DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sErrorMessage", SqlDbType.NVarChar, 50, 
                                        ParameterDirection.Output, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.errorMessage));
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
                   item.errorMessage = cmdToExecute.Parameters["@sErrorMessage"].Value.ToString();
                   _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                   item.ErrorCode = (Int32)_errorCode;
                   if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseRequisitionMaster_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
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
                _errorCode = 18;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _errorCode = 18;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
                //_logException.Error(ex.Message);
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
        /// <summary>
        /// Delete a specific record of PurchaseRequisitionMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseRequisitionMaster> DeletePurchaseRequisitionMaster(PurchaseRequisitionMaster item)
        {
            IBaseEntityResponse<PurchaseRequisitionMaster> response = new BaseEntityResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseRequisitionMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.errorMessage));
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
                    item.errorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry && _errorCode != 77)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_PurchaseRequisitionMaster_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
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

        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterListForBelowSafetyLevel(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseRequisitionMaster_GetDetailListForBelowStockSafetyLevel";
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseRequisitionMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseRequisitionMaster item = new PurchaseRequisitionMaster();
                        //item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);

                        item.ItemID = sqlDataReader["ItemID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemID"]);
                        item.ItemName = sqlDataReader["ItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        item.LocationName = sqlDataReader["LocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.Quantity = sqlDataReader["CurrentQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["CurrentQuantity"]);
                        item.Rate = sqlDataReader["RetailRate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["RetailRate"]);
                        item.StorageLocationID = sqlDataReader["StoragelocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StoragelocationID"]);
                        item.MinIndentLevel = sqlDataReader["MinIndentLevel"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["MinIndentLevel"]);
                        item.IndendQuantity = sqlDataReader["IndendQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["IndendQuantity"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseRequisitionMaster_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterDetailLists(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseRequisitionMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseRequisitionMaster>();
                    decimal ammount1 = 0;
                    while (sqlDataReader.Read())
                    {
                        PurchaseRequisitionMaster item = new PurchaseRequisitionMaster();
                        item.ID = sqlDataReader["PurchaseRequisationMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseRequisationMasterID"]);
                        item.ItemID = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemName = sqlDataReader["ItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        item.TransDate = sqlDataReader["TransDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransDate"]);
                        item.PriorityFlag = sqlDataReader["PriorityFlag"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["PriorityFlag"]);
                        if (item.PriorityFlag == 1)
                        {
                            item.Priority = "High";
                        }
                        else if (item.PriorityFlag == 2)
                        {
                            item.Priority = "Medium";
                        }
                        else if (item.PriorityFlag == 3)
                        {
                            item.Priority = "Low";
                        }
                        item.PurchaseRequisitionNumber = sqlDataReader["PurchaseRequisitionNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseRequisitionNumber"]);
                        item.PurchaseRequisitionType = Convert.ToInt16(sqlDataReader["PurchaseRequisitionType"]);
                        item.PurchaseRequisitionBehaviour = sqlDataReader["PurchaseRequisitionBehaviour"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseRequisitionBehaviour"]);
                        item.IsOpenForPO = Convert.ToBoolean(sqlDataReader["IsOpenForPO"]);
                        item.PurchaseRequisitionDetailsID = sqlDataReader["PurchaseRequisitionDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseRequisitionDetailsID"]);
                        item.VendorID = sqlDataReader["VendorID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorID"]);
                        item.LocationName = sqlDataReader["LocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.ExpectedDeliveryDate = sqlDataReader["ExpectedDeliveryDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExpectedDeliveryDate"]);
                        item.StorageLocationID = sqlDataReader["StoragelocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StoragelocationID"]);
                        item.Vendor = sqlDataReader["Vender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
                        item.ItemCount = sqlDataReader["ItemCount"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemCount"]);
                        item.PrintingLine1 = sqlDataReader["PrintingLine1"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine1"]);
                        item.PrintingLine2 = sqlDataReader["PrintingLine2"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine2"]);
                        item.PrintingLine3 = sqlDataReader["PrintingLine3"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine3"]);
                        item.PrintingLine4 = sqlDataReader["PrintingLine4"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PrintingLine4"]);
                        item.TaxAmount = sqlDataReader["TotalTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.BaseUOMCode = sqlDataReader["OrderUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);

                        item.VendorName = sqlDataReader["VendorName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorName"]);
                        item.VendorAddress = sqlDataReader["VendorAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorAddress"]);
                        item.VendorPhoneNumber = sqlDataReader["VendorPhoneNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorPhoneNumber"]);
                        item.VendorNumber = sqlDataReader["VendorNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorNumber"]);
                        item.VendorPinCode = sqlDataReader["VendorPinCode"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorPinCode"]);
                        item.Currency = sqlDataReader["Currency"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Currency"]);
                        item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        item.LocationAddress = sqlDataReader["LocationAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationAddress"]);
                        item.City = sqlDataReader["Description"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Description"]);
                        item.Pincode = sqlDataReader["Pincode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Pincode"]);

                        item.FromUnitName = sqlDataReader["FromUnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromUnitName"]);
                        item.FromLocationAddress = sqlDataReader["FromLocationAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromLocationAddress"]);
                        item.FromCity = sqlDataReader["FromCity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromCity"]);
                        item.FromPincode = sqlDataReader["FromPincode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromPincode"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);

                        var qty = Math.Round(item.Quantity, 3);
                        var rate = Math.Round(item.Rate, 2);
                        var amount = qty * rate;
                        ammount1 = ammount1 + amount;
                        item.Ammount = Math.Round(amount, 2);
                        item.GrossAmount = ammount1;

                        //For calculating tax amount for each item
                        var abc1 = (((item.Ammount) * (item.TaxRate)) / 100);
                        item.ItemWiseTaxAmount = abc1;



                        item.AmmountIncludingTax = (Math.Round(item.ItemWiseTaxAmount, 2) + Math.Round(item.Ammount, 2));
                        item.IsOtherState = Convert.ToBoolean(sqlDataReader["IsOtherState"]);


                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseRequisitionMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionForApproval(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseRequisitionMaster_GetRequestForApproval";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskNotificationMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseRequisitionMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseRequisitionMaster item = new PurchaseRequisitionMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseRequisitionNumber"]) == false)
                        {
                            item.PurchaseRequisitionNumber = Convert.ToString(sqlDataReader["PurchaseRequisitionNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransDate"]) == false)
                        {
                            item.TransDate = Convert.ToString(sqlDataReader["TransDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseRequisitionDetailID"]) == false)
                        {
                            item.PurchaseRequisitionDetailsID = Convert.ToInt32(sqlDataReader["PurchaseRequisitionDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExpectedDate"]) == false)
                        {
                            item.ExpectedDeliveryDate = Convert.ToString(sqlDataReader["ExpectedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StorageLocationID"]) == false)
                        {
                            item.StorageLocationID = Convert.ToInt32(sqlDataReader["StorageLocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PriorityFlag"]) == false)
                        {
                            item.PriorityFlag = Convert.ToInt16(sqlDataReader["PriorityFlag"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["Remark"]) == false)
                        //{
                        //    item.Remark = Convert.ToString(sqlDataReader["Remark"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["LocationName"]) == false)
                        {
                            item.LocationName = Convert.ToString(sqlDataReader["LocationName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransDate"]) == false)
                        {
                            item.TransDate = Convert.ToString(sqlDataReader["TransDate"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySale_SelectBillDetails' reported the ErrorCode: " + _errorCode);
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
        //Method For Get UoM details with Its Purchase Price 
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetUomDetailsForSTOWithPurchasePrice(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryUoMMaster_GetDropDownForUomCodeWithPurchasePrice";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseRequisitionMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseRequisitionMaster item = new PurchaseRequisitionMaster();
                        //_item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemcodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemcodeID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.UomPurchasePrice = Math.Round(Convert.ToDouble(sqlDataReader["UomPurchasePrice"]), 2);
                        item.UnitCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.BaseUOMCode = sqlDataReader["LowerLevelUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LowerLevelUomCode"]);
                        item.BaseUOMQuantity = sqlDataReader["ConversionFactor"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ConversionFactor"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySale_SelectBillDetails' reported the ErrorCode: " + _errorCode);
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

        //Method For Get UoMWisePurchasePrice on change of UOM Drop down 
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetUomWisePurchasePrice(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryRequisitionMaster_GetUomWisePurchasePrice";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUoMCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.UnitCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseRequisitionMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseRequisitionMaster item = new PurchaseRequisitionMaster();
                        //_item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.GeneralItemCodeID = sqlDataReader["GeneralItemcodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemcodeID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.UomPurchasePrice = Math.Round(Convert.ToDouble(sqlDataReader["UomPurchasePrice"]), 2);
                        item.UnitCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        item.BaseUOMCode = sqlDataReader["LowerLevelUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LowerLevelUomCode"]);
                        item.BaseUOMQuantity = sqlDataReader["ConversionFactor"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ConversionFactor"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySale_SelectBillDetails' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetItemAndLocationWiseBatchQuantity(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_PurchaseRequisitionMaster_GetItemWiseBatch";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryLocationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.InventoryLocationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseRequisitionMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseRequisitionMaster item = new PurchaseRequisitionMaster();
                        
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.StorageLocationID = sqlDataReader["InventoryLocationMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["InventoryLocationMasterID"]);
                        item.BatchQuantity = sqlDataReader["BatchQuantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BatchQuantity"]);
                      
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySale_SelectBillDetails' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetItemwiseRequirmentForDataList(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetPurchaseRequirmentListForPurchaseRequisition_ItemWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemnumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFromDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUptoDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));

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
                    baseEntityCollection.CollectionResponse = new List<PurchaseRequisitionMaster>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseRequisitionMaster item = new PurchaseRequisitionMaster();
                        //item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.PurchaseRequirementMasterID = sqlDataReader["PurchaseRequirementMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseRequirementMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemName = sqlDataReader["ItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        item.ApprovedQuantity = sqlDataReader["ApprovedQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ApprovedQuantity"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.PriorityFlag = sqlDataReader["PriorityFlag"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["PriorityFlag"]);
                        if (item.PriorityFlag == 1)
                        {
                            item.Priority = "High";
                        }
                        else if (item.PriorityFlag == 2)
                        {
                            item.Priority = "Medium";
                        }
                        else if (item.PriorityFlag == 3)
                        {
                            item.Priority = "Low";
                        }
                        item.StorageLocationID = sqlDataReader["StorageLocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StorageLocationID"]);

                        item.LocationAddress = sqlDataReader["LocationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationName"]);
                        item.ExpectedDeliveryDate = sqlDataReader["ExpectedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExpectedDate"]);
                        item.PurchaseRequirementDetailsID = sqlDataReader["PurchaseRequirementDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PurchaseRequirementDetailsID"]);
                        item.PurchaseRequirementNumber = sqlDataReader["PurchaseRequirementNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseRequirementNumber"]);
                        item.DepartmentID = sqlDataReader["DepartmentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxRate"]);

                        var Amount = (item.ApprovedQuantity * item.Rate);
                        var taxamount = ((Amount * item.TaxRate) / 100);
                        var grossAmmount = Amount + taxamount;

                        item.Ammount = Amount;
                        item.TaxAmount = taxamount;
                        item.GrossAmount = grossAmmount;

                        item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        item.UnitCode = sqlDataReader["OrderUomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUomCode"]);
                        item.BarCode = sqlDataReader["BarCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BarCode"]);
                        item.BaseUOMQuantity = sqlDataReader["BaseUOMQuantity"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        item.BaseUOMCode = sqlDataReader["BaseUOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        item.IsDefaultVendor = sqlDataReader["IsDefaultVendor"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsDefaultVendor"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);
                        item.CurrentStockQtyWithBaseUOM = sqlDataReader["CurrentStockQtyWithBaseUOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CurrentStockQtyWithBaseUOM"]);
                        item.CustomerBranchName = sqlDataReader["CustomerBranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchName"]);


                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_PurchaseRequisitionMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
