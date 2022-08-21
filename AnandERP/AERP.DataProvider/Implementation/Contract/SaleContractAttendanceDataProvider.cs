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
    public class SaleContractAttendanceDataProvider : DBInteractionBase, ISaleContractAttendanceDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SaleContractAttendanceDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SaleContractAttendanceDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<SaleContractAttendance> GetMonthListBySaleContractMaster(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_SelectMonths";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractAttendance>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractAttendance item = new SaleContractAttendance();

                        item.Months = sqlDataReader["Months"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Months"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractAttendance_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetSaleContractAttendance(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractAttendance_SelectByContractMonth";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMonths", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Months));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractAttendance>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractAttendance item = new SaleContractAttendance();

                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.AttendanceStatusList = sqlDataReader["AttendanceStatusList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AttendanceStatusList"]);
                        item.AttendanceDays = sqlDataReader["AttendanceDays"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AttendanceDays"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractAttendance_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetAttendanceListForAttendanceDate(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractAttendance_SelectByDate";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtAttendanceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AttendanceDate));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractAttendance>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractAttendance item = new SaleContractAttendance();

                        item.ID = sqlDataReader["ID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ID"]);
                        item.AttendanceStatus = sqlDataReader["AttendanceStatus"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["AttendanceStatus"]);
                        item.IsHalfDayLeave = sqlDataReader["IsHalfDayLeave"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsHalfDayLeave"]);
                        item.OvertimeHours = sqlDataReader["OvertimeHours"] is DBNull ? new byte() : Math.Round(Convert.ToDecimal(sqlDataReader["OvertimeHours"]), 2);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractAttendance_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractAttendance> InsertSaleContractAttendance(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> response = new BaseEntityResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractAttendance_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@dtAttendanceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AttendanceDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForAttendance", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForAttendance));
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

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetAttendanceListForMonthWise(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractAttendance_SelectByMonth";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMonths", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Months));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractAttendance>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractAttendance item = new SaleContractAttendance();

                        item.ID = sqlDataReader["ID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ID"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractAttendance_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractAttendance> InsertSaleContractAttendanceMonthWise(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> response = new BaseEntityResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractAttendance_MonthWise_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMonths", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Months));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForAttendance", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForAttendance));
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

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetSaleContractAttendanceMonthWise(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractAttendance_SelectByMonth";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMonths", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Months));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractAttendance>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractAttendance item = new SaleContractAttendance();

                        item.ID = sqlDataReader["ID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ID"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractAttendance_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetSaleContractAttendanceSpanWise(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractAttendance_SelectBySpan";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractBillingSpanID));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractAttendance>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractAttendance item = new SaleContractAttendance();

                        item.ID = sqlDataReader["ID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ID"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.OvertimeHours = sqlDataReader["OvertimeHours"] is DBNull ? new byte() : Convert.ToDecimal(sqlDataReader["OvertimeHours"]);
                        item.IsSalaryDaysOnWeeklyOff = sqlDataReader["IsSalaryDaysOnWeeklyOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsSalaryDaysOnWeeklyOff"]);
                        item.IsBillingDaysOnWeeklyOff = sqlDataReader["IsBillingDaysOnWeeklyOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsBillingDaysOnWeeklyOff"]);
                        item.TotalBillingDays = sqlDataReader["TotalBillingDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalBillingDays"]);
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
                        item.IsOverTimeBillingDaysFix = sqlDataReader["IsOverTimeBillingDaysFix"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOverTimeBillingDaysFix"]);
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
                        throw new Exception("Stored Procedure 'USP_SaleContractAttendance_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetSpanListBySaleContractMaster(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_SelectSpan";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
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

                    baseEntityCollection.CollectionResponse = new List<SaleContractAttendance>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractAttendance item = new SaleContractAttendance();

                        item.SaleContractBillingSpanID = sqlDataReader["SaleContractBillingSpanID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractBillingSpanID"]);
                        item.SaleContractBillingSpanName = sqlDataReader["SaleContractBillingSpanName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractBillingSpanName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractAttendance_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetAttendanceListForSpanWise(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractAttendance_SelectBySpan";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleContractBillingSpanID));

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

                    baseEntityCollection.CollectionResponse = new List<SaleContractAttendance>();
                    while (sqlDataReader.Read())
                    {
                        SaleContractAttendance item = new SaleContractAttendance();

                        item.ID = sqlDataReader["ID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ID"]);
                        item.TotalAttendance = sqlDataReader["TotalAttendance"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAttendance"]);
                        item.SaleContractEmployeeMasterID = sqlDataReader["SaleContractEmployeeMasterID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SaleContractEmployeeMasterID"]);
                        item.SaleContractEmployeeMasterName = sqlDataReader["SaleContractEmployeeMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleContractEmployeeMasterName"]);
                        item.SaleContractManPowerItemID = sqlDataReader["SaleContractManPowerItemID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SaleContractManPowerItemID"]);
                        item.TotalDays = sqlDataReader["TotalDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalDays"]);
                        item.OvertimeHours = sqlDataReader["OvertimeHours"] is DBNull ? new byte() : Convert.ToDecimal(sqlDataReader["OvertimeHours"]);
                        item.IsSalaryDaysOnWeeklyOff = sqlDataReader["IsSalaryDaysOnWeeklyOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsSalaryDaysOnWeeklyOff"]);
                        item.IsBillingDaysOnWeeklyOff = sqlDataReader["IsBillingDaysOnWeeklyOff"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsBillingDaysOnWeeklyOff"]);
                        item.TotalBillingDays = sqlDataReader["TotalBillingDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["TotalBillingDays"]);
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
                        item.IsOverTimeBillingDaysFix = sqlDataReader["IsOverTimeBillingDaysFix"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsOverTimeBillingDaysFix"]);
                        item.SalaryForManPowerItemName= sqlDataReader["SalaryForManPowerItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalaryForManPowerItemName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractAttendance_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractAttendance> InsertSaleContractAttendanceSpanWise(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> response = new BaseEntityResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractAttendance_SpanWise_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@XMLstringForAttendance", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForAttendance));
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

        public IBaseEntityResponse<SaleContractAttendance> InsertSaleContractSplitSalarySpan(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> response = new BaseEntityResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractMaster_SplitSpan";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractBillingSpanID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractBillingSpanID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleContractMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleContractMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtSplitFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SplitFromDate));
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

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != 111 && _errorCode != 112)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractMaster_SplitSpan' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SaleContractAttendance> GetSalaryForManPowerItem(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> response = new BaseEntityResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractAttendance_GetSalaryForManPowerItem";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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

                        SaleContractAttendance _item = new SaleContractAttendance();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        _item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        _item.SalaryForManPowerItemName= sqlDataReader["SalaryForManPowerItemName"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["SalaryForManPowerItemName"]);
                        _item.SalaryForManPowerItemID= sqlDataReader["SalaryForManPowerItemID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["SalaryForManPowerItemID"]);
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

        public IBaseEntityResponse<SaleContractAttendance> InsertSalaryForManPowerItem(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> response = new BaseEntityResponse<SaleContractAttendance>();
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
                    cmdToExecute.CommandText = "dbo.USP_SaleContractAttendance_InsertSalaryForManPowerItem";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalaryForManPowerItemID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalaryForManPowerItemID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
        #endregion
    }
}
