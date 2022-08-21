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
    public class SaleContractManPowerItemDataProvider : DBInteractionBase, ISaleContractManPowerItemDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SaleContractManPowerItemDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SaleContractManPowerItemDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        /// <summary>
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemBySearch(SaleContractManPowerItemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractManPowerItem> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItem_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerBranchMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractManPowerItem>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractManPowerItem item = new SaleContractManPowerItem();
                        item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        item.DesignationMasterName = sqlDataReader["DesignationMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DesignationMasterName"]);
                        item.BasicSalayAmount = sqlDataReader["BasicSalayAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["BasicSalayAmount"]));
                        item.NetSalaryAmount = sqlDataReader["NetSalaryAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["NetSalaryAmount"]));
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]));
                        item.GrossSalaryAmount = sqlDataReader["GrossAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["GrossAmount"]));
                        item.RuleID = sqlDataReader["RuleID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["RuleID"]);
                        item.RuleType = sqlDataReader["RuleType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RuleType"]);
                        item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FixedAmount"]);
                        item.Percentage = sqlDataReader["Percentage"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Percentage"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.IsApplied = sqlDataReader["IsApplied"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsApplied"]);
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }

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
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemGetBySearchList(SaleContractManPowerItemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractManPowerItem> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItem_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractManPowerItem>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractManPowerItem item = new SaleContractManPowerItem();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from General Region Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractManPowerItem> GetSaleContractManPowerItemByID(SaleContractManPowerItem item)
        {
            IBaseEntityResponse<SaleContractManPowerItem> response = new BaseEntityResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItem_SelectOne";
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

                        SaleContractManPowerItem _item = new SaleContractManPowerItem();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        _item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        _item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        _item.DesignationMasterName = sqlDataReader["DesignationMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DesignationMasterName"]);
                        _item.BasicSalayAmount = sqlDataReader["BasicSalayAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["BasicSalayAmount"]));
                        _item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]));
                        _item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of General Region Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractManPowerItem> InsertSaleContractManPowerItem(SaleContractManPowerItem item)
        {
            IBaseEntityResponse<SaleContractManPowerItem> response = new BaseEntityResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItem_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerMasterID));
                    if (item.CustomerBranchMasterID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iDesignationMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DesignationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBasicSalayAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BasicSalayAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFixedSalaryAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedSalaryAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBillingDisplayName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BillingDisplayName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleID)); 
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    //response.Message.Add(new MessageDTO
                    //    //{
                    //    //    ErrorMessage = "Create failed"
                    //    //});
                    //    response.Entity = item;
                    //}
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

        /// <summary>
        /// Update a specific record of General Region Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractManPowerItem> UpdateSaleContractManPowerItem(SaleContractManPowerItem item)
        {
            IBaseEntityResponse<SaleContractManPowerItem> response = new BaseEntityResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItem_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerMasterID));
                    if (item.CustomerBranchMasterID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iDesignationMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DesignationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBasicSalayAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BasicSalayAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalAmount));
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
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Delete a selected record from General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractManPowerItem> DeleteSaleContractManPowerItem(SaleContractManPowerItem item)
        {
            IBaseEntityResponse<SaleContractManPowerItem> response = new BaseEntityResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItem_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));
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
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractManPowerItem> InsertSaleContractManPowerItemRules(SaleContractManPowerItem item)
        {
            IBaseEntityResponse<SaleContractManPowerItem> response = new BaseEntityResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItemRules_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringManPowerItemRules", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLStringManPowerItemRules));
                    if (item.XMLStringForCalculateOn != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringForCalculateOn", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLStringForCalculateOn));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringForCalculateOn", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mGrossSalaryAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GrossSalaryAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mNetSalaryAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.NetSalaryAmount));
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
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractManPowerItem> ViewSaleContractManPowerItemRules(SaleContractManPowerItem item)
        {
            IBaseEntityResponse<SaleContractManPowerItem> response = new BaseEntityResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItemRules_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRuleID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RuleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRuleType", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RuleType));
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

                        SaleContractManPowerItem _item = new SaleContractManPowerItem();
                        _item.RuleID = Convert.ToInt32(sqlDataReader["RuleID"]);
                        _item.RuleType = sqlDataReader["RuleType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RuleType"]);
                        _item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        _item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FixedAmount"]);
                        _item.Percentage = sqlDataReader["Percentage"] is DBNull ? new decimal() :Convert.ToDecimal(sqlDataReader["Percentage"]);
                        _item.CalculateOn = sqlDataReader["CalculateOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CalculateOn"]);
                        _item.IsGenderSpecific = sqlDataReader["IsGenderSpecific"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsGenderSpecific"]);
                        _item.Gender = sqlDataReader["Gender"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Gender"]);
                        _item.RangeFrom = sqlDataReader["RangeFrom"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeFrom"]));
                        _item.RangeUpto = sqlDataReader["RangeUpto"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeUpto"]));
                        _item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        _item.CalculateOnString = sqlDataReader["CalculateOnString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnString"]);
                        _item.CalculateOnFixedAmount = sqlDataReader["CalculateOnFixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["CalculateOnFixedAmount"]));
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractManPowerItem> DeleteSaleContractManPowerItemRules(SaleContractManPowerItem item)
        {
            IBaseEntityResponse<SaleContractManPowerItem> response = new BaseEntityResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItemRules_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));
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
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractManPowerItem> UpdateSaleContractManPowerItemRules(SaleContractManPowerItem item)
        {
            IBaseEntityResponse<SaleContractManPowerItem> response = new BaseEntityResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItemRules_UpdateXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringManPowerItemRules", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLStringManPowerItemRules));
                    if (item.XMLStringForCalculateOn != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringForCalculateOn", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLStringForCalculateOn));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringForCalculateOn", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mGrossSalaryAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GrossSalaryAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mNetSalaryAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.NetSalaryAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBasicSalayAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BasicSalayAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFixedSalaryAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedSalaryAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bGenerateSeperateInvoice", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GenerateSeperateInvoice));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtWithEffectiveFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.WithEffectiveFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtWithEffectiveUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.WithEffectiveUptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bCalculateArrears", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CalculateArrears)); 
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
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemRules(SaleContractManPowerItemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractManPowerItem> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItemRules_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractManPowerItem>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractManPowerItem item = new SaleContractManPowerItem();
                        item.RuleID = Convert.ToInt32(sqlDataReader["RuleID"]);
                        item.RuleType = sqlDataReader["RuleType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RuleType"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedAmount"]));
                        item.Percentage = sqlDataReader["Percentage"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Percentage"]), 2);
                        item.CalculateOn = sqlDataReader["CalculateOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CalculateOn"]);
                        item.IsGenderSpecific = sqlDataReader["IsGenderSpecific"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsGenderSpecific"]);
                        item.Gender = sqlDataReader["Gender"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Gender"]);
                        item.RangeFrom = sqlDataReader["RangeFrom"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeFrom"]));
                        item.RangeUpto = sqlDataReader["RangeUpto"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["RangeUpto"]));
                        item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        item.CalculateOnString = sqlDataReader["CalculateOnString"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnString"]);
                        item.HeadID = sqlDataReader["HeadID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["HeadID"]);
                        item.HeadType = sqlDataReader["HeadType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadType"]);
                        item.CalculatedAmount = sqlDataReader["CalculatedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["CalculatedAmount"]));
                        item.BasicSalayAmount = sqlDataReader["BasicSalayAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["BasicSalayAmount"]), MidpointRounding.AwayFromZero);
                        item.FixedSalaryAmount = sqlDataReader["FixedSalaryAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixedSalaryAmount"]));
                        item.NetSalaryAmount = sqlDataReader["NetSalaryAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["NetSalaryAmount"]));
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]));
                        item.GrossSalaryAmount = sqlDataReader["GrossAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["GrossAmount"]));
                        item.CalculateOnFixedAmount = sqlDataReader["CalculateOnFixedAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["CalculateOnFixedAmount"])); 

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemBySearchWord(SaleContractManPowerItemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractManPowerItem> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItem_SearchByWord";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerBranchMasterID));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractManPowerItem>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractManPowerItem item = new SaleContractManPowerItem();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.DesignationMasterName = sqlDataReader["DesignationMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DesignationMasterName"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["TotalAmount"]));

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemAllowancesBySearchWord(SaleContractManPowerItemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractManPowerItem> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractManPowerItem>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractManPowerItem_AllowanceSearchByWord";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerBranchMasterID));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractManPowerItem>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractManPowerItem item = new SaleContractManPowerItem();
                        item.HeadID = Convert.ToByte(sqlDataReader["HeadID"]);
                        item.HeadName = sqlDataReader["HeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HeadName"]);
                        item.AllowanceOrDeduction = sqlDataReader["AllowanceOrDeduction"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["AllowanceOrDeduction"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_SearchList' reported the ErrorCode: " + _errorCode);
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
