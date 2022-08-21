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
    public class SalaryDeductionMasterDataProvider : DBInteractionBase, ISalaryDeductionMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalaryDeductionMasterDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalaryDeductionMasterDataProvider(ILogger logException)
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
        public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetSalaryDeductionMasterBySearch(SalaryDeductionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryDeductionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalaryDeductionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
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

                    baseEntityCollection.CollectionResponse = new List<SalaryDeductionMaster>();
                    while (sqlDataReader.Read())
                    {
                        SalaryDeductionMaster item = new SalaryDeductionMaster();
                        item.ID = sqlDataReader["ID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ID"]);
                        item.DeductionHeadName = sqlDataReader["DeductionHeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeductionHeadName"]);
                        item.DeductionType = sqlDataReader["DeductionType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeductionType"]);
                        item.SalaryDeductionRulesID = sqlDataReader["SalaryDeductionRulesID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SalaryDeductionRulesID"]);
                        item.Gender = sqlDataReader["Gender"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Gender"]);
                        item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FixedAmount"]);
                        item.Percentage = sqlDataReader["Percentage"] is DBNull ? new double() : Convert.ToDouble(sqlDataReader["Percentage"]);
                        item.EffectedDate = sqlDataReader["EffectedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EffectedDate"]);
                        item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);


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
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetSalaryDeductionMasterGetBySearchList(SalaryDeductionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryDeductionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalaryDeductionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));

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

                    baseEntityCollection.CollectionResponse = new List<SalaryDeductionMaster>();
                    while (sqlDataReader.Read())
                    {
                        SalaryDeductionMaster item = new SalaryDeductionMaster();
                        item.ID = sqlDataReader["ID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ID"]);
                        item.DeductionHeadName = sqlDataReader["DeductionHeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeductionHeadName"]);
                        item.DeductionType = sqlDataReader["DeductionType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeductionType"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalaryDeductionMaster> GetSalaryDeductionMasterByID(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> response = new BaseEntityResponse<SalaryDeductionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionMaster_SelectOne";
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

                        SalaryDeductionMaster _item = new SalaryDeductionMaster();
                        _item.ID = sqlDataReader["ID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ID"]);
                        _item.DeductionHeadName = sqlDataReader["DeductionHeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeductionHeadName"]);
                        _item.DeductionType = sqlDataReader["DeductionType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeductionType"]);
                        _item.ComplianceType = sqlDataReader["ComplianceType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ComplianceType"]);
                        _item.DeductionSubType = sqlDataReader["DeductionSubType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeductionSubType"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionMaster(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> response = new BaseEntityResponse<SalaryDeductionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeductionHeadName", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DeductionHeadName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeductionType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DeductionType.Trim()));
                    if (item.DeductionSubType != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sDeductionSubType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DeductionSubType.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sDeductionSubType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiComplianceType", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ComplianceType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiID", SqlDbType.TinyInt, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        item.ID = (Byte)cmdToExecute.Parameters["@tiID"].Value;
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_Insert' reported the ErrorCode: " +
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
        public IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionMaster(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> response = new BaseEntityResponse<SalaryDeductionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiID", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));

                    if (item.DeductionSubType != null && item.DeductionSubType != "")
                        cmdToExecute.Parameters.Add(new SqlParameter("@sDeductionSubType", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.DeductionSubType.Trim()));
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@sDeductionSubType", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiComplianceType", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ComplianceType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeductionHeadName", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.DeductionHeadName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeductionType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DeductionType.Trim()));
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
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionMaster(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> response = new BaseEntityResponse<SalaryDeductionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionMaster_Delete";
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
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionRules(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> response = new BaseEntityResponse<SalaryDeductionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionRules_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@tiID", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsGenderSpecific", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsGenderSpecific));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGender", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Gender));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dFixedAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dPercentage", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Percentage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCalculateOn", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CalculateOn));
                    if (item.EffectedDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtEffectedDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EffectedDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtEffectedDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CloseDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtCloseDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CloseDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtCloseDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCurrent", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsCurrent));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiContributionType", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContributionType));
                    if (item.RangeFrom != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mRangeFrom", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RangeFrom));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mRangeFrom", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.RangeUpto != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mRangeUpto", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RangeUpto));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mRangeUpto", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@mCalculateOnFixedAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CalculateOnFixedAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    if (item.XMLStringForCalculateOn != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringForCalculateOn", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.XMLStringForCalculateOn));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringForCalculateOn", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiSalaryDeductionRulesID", SqlDbType.TinyInt, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.SalaryDeductionRulesID));
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
                        item.ID = (Byte)cmdToExecute.Parameters["@tiSalaryDeductionRulesID"].Value;
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_Insert' reported the ErrorCode: " +
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

        public IBaseEntityResponse<SalaryDeductionMaster> SelectBySalaryDeductionRulesID(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> response = new BaseEntityResponse<SalaryDeductionMaster>();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionRules_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiSalaryDeductionRulesID", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalaryDeductionRulesID));
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
                    // Execute query.
                    while (sqlDataReader.Read())
                    {
                        SalaryDeductionMaster _item = new SalaryDeductionMaster();
                        _item.ID = sqlDataReader["ID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ID"]);
                        _item.SalaryDeductionRulesID = sqlDataReader["SalaryDeductionRulesID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SalaryDeductionRulesID"]);
                        _item.IsGenderSpecific = sqlDataReader["IsGenderSpecific"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsGenderSpecific"]);
                        _item.Gender = sqlDataReader["Gender"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Gender"]);
                        _item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FixedAmount"]);
                        _item.Percentage = sqlDataReader["Percentage"] is DBNull ? new double() : Convert.ToDouble(sqlDataReader["Percentage"]);
                        _item.CalculateOn = sqlDataReader["CalculateOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CalculateOn"]);
                        _item.EffectedDate = sqlDataReader["EffectedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EffectedDate"]);
                        _item.CloseDate = sqlDataReader["CloseDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CloseDate"]);
                        _item.IsCurrent = sqlDataReader["IsCurrent"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsCurrent"]);
                        _item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        _item.RangeFrom = sqlDataReader["RangeFrom"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["RangeFrom"]);
                        _item.RangeUpto = sqlDataReader["RangeUpto"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["RangeUpto"]);
                        _item.CalculateOnFixedAmount = sqlDataReader["CalculateOnFixedAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CalculateOnFixedAmount"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_Insert' reported the ErrorCode: " +
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

        public IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionRules(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> response = new BaseEntityResponse<SalaryDeductionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionRules_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@tiID", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiSalaryDeductionRulesID", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalaryDeductionRulesID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsGenderSpecific", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsGenderSpecific));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGender", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Gender));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dFixedAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FixedAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dPercentage", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Percentage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCalculateOn", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CalculateOn));
                    if (item.EffectedDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtEffectedDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EffectedDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtEffectedDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CloseDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtCloseDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CloseDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtCloseDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCurrent", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsCurrent));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiContributionType", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContributionType));
                    if (item.RangeFrom != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mRangeFrom", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RangeFrom));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mRangeFrom", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.RangeUpto != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mRangeUpto", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RangeUpto));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mRangeUpto", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@mCalculateOnFixedAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CalculateOnFixedAmount));

                    if (item.XMLStringForCalculateOn != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringForCalculateOn", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.XMLStringForCalculateOn));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@XMLStringForCalculateOn", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_Insert' reported the ErrorCode: " +
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

        public IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionRules(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> response = new BaseEntityResponse<SalaryDeductionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionRules_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.DeletedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiSalaryDeductionRulesID", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalaryDeductionRulesID));
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_Insert' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetDeductionRulesByDeductionMaster(SalaryDeductionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryDeductionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalaryDeductionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionRules_ByDeductionMasterID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiID", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));

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

                    baseEntityCollection.CollectionResponse = new List<SalaryDeductionMaster>();
                    while (sqlDataReader.Read())
                    {
                        SalaryDeductionMaster item = new SalaryDeductionMaster();
                        item.ID = sqlDataReader["ID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ID"]);
                        item.SalaryDeductionRulesID = sqlDataReader["SalaryDeductionRulesID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SalaryDeductionRulesID"]);
                        item.IsGenderSpecific = sqlDataReader["IsGenderSpecific"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsGenderSpecific"]);
                        item.Gender = sqlDataReader["Gender"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Gender"]);
                        item.FixedAmount = sqlDataReader["FixedAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["FixedAmount"]);
                        item.Percentage = sqlDataReader["Percentage"] is DBNull ? new double() : Convert.ToDouble(sqlDataReader["Percentage"]);
                        item.CalculateOn = sqlDataReader["CalculateOn"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CalculateOn"]);
                        item.EffectedDate = sqlDataReader["EffectedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EffectedDate"]);
                        item.CloseDate = sqlDataReader["CloseDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CloseDate"]);
                        item.IsCurrent = sqlDataReader["IsCurrent"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsCurrent"]);
                        item.ContributionType = sqlDataReader["ContributionType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ContributionType"]);
                        item.RangeFrom = sqlDataReader["RangeFrom"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["RangeFrom"]);
                        item.RangeUpto = sqlDataReader["RangeUpto"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["RangeUpto"]);
                        item.CalculateOnFixedAmount = sqlDataReader["CalculateOnFixedAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CalculateOnFixedAmount"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetCalculateOnListForRules(SalaryDeductionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryDeductionMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalaryDeductionMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CalculateOnForDeductionRules_SelectList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiSalaryDeductionRulesID", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalaryDeductionRulesID));

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

                    baseEntityCollection.CollectionResponse = new List<SalaryDeductionMaster>();
                    while (sqlDataReader.Read())
                    {
                        SalaryDeductionMaster item = new SalaryDeductionMaster();
                        item.ReferenceID = sqlDataReader["ReferenceID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ReferenceID"]);
                        item.CalculateOnName = sqlDataReader["CalculateOnName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CalculateOnName"]);
                        item.AllowanceOrDeduction = sqlDataReader["AllowanceOrDeduction"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["AllowanceOrDeduction"]);
                        item.SelectedStatusFlag = sqlDataReader["SelectedStatusFlag"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SelectedStatusFlag"]);
                        item.SalaryDeductionSumOfID = sqlDataReader["SalaryDeductionSumOfID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["SalaryDeductionSumOfID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
