using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AERP.DataProvider
{
  public  class CCRMCallAllotmentMasterDataProvider :DBInteractionBase,ICCRMCallAllotmentMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion
        #region Constructor
        public CCRMCallAllotmentMasterDataProvider()
        {
        }
        public CCRMCallAllotmentMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion
        public IBaseEntityResponse<CCRMCallAllotmentMaster> UpdateCCRMCallAllotmentMaster(CCRMCallAllotmentMaster item)
        {
            IBaseEntityResponse<CCRMCallAllotmentMaster> response = new BaseEntityResponse<CCRMCallAllotmentMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCallAllotmentMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAllotDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AllotDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallerName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallerName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallTktNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallTktNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEngineerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EngineerID));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAllotEnggName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AllotEnggName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallStatus));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UserID));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsUserName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UserName.Trim()));

                    cmdToExecute.Parameters.Add(new SqlParameter("@mAllotPeriod", SqlDbType.Money, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AllotPeriod));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bAllotment", SqlDbType.Bit, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Allotment));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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

                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMCallAllotmentMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMCallAllotmentMaster> DeleteCCRMCallAllotmentMaster(CCRMCallAllotmentMaster item)
        {
            IBaseEntityResponse<CCRMCallAllotmentMaster> response = new BaseEntityResponse<CCRMCallAllotmentMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCallAllotmentMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));

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
                        throw new Exception("Stored Procedure 'USP_CCRMCallAllotmentMaster_Delete' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMCallAllotmentMaster> GetCCRMCallAllotmentMasterByID(CCRMCallAllotmentMaster item)
        {
            IBaseEntityResponse<CCRMCallAllotmentMaster> response = new BaseEntityResponse<CCRMCallAllotmentMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCallAllotmentMaster_SelectOne";
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
                        CCRMCallAllotmentMaster _item = new CCRMCallAllotmentMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.CallTktNo = sqlDataReader["CallTktNo"].ToString();
                        _item.CallDate = sqlDataReader["CallDate"].ToString();
                        _item.SerialNo = sqlDataReader["SerialNo"].ToString();
                        _item.ModelNo = sqlDataReader["ModelNo"].ToString();
                        _item.MIFName = sqlDataReader["MIFName"].ToString();
                        _item.EmailID = sqlDataReader["EmailID"].ToString();
                        _item.CallerName = sqlDataReader["CallerName"].ToString();
                        _item.CallerPh = sqlDataReader["CallerPh"].ToString();
                        _item.EngineerID = Convert.ToInt32(sqlDataReader["EngineerID"]);
                        _item.CallTypeID = Convert.ToInt32(sqlDataReader["CallTypeID"]);
                        _item.CallTypeName = sqlDataReader["CallTypeName"].ToString();
                       
                      //  _item.Priority = Convert.ToByte(sqlDataReader["Priority"]);
                        // _item.NotApproved = Convert.ToBoolean(sqlDataReader["NotApproved"]);
                       _item.ComPlaint = sqlDataReader["ComPlaint"].ToString();
                        _item.EnggMobNo = sqlDataReader["EnggMobNo"].ToString();
                       // _item.AreaPatchName = sqlDataReader["AreaPatchName"].ToString();
                        _item.ItemDescription = sqlDataReader["ItemDescription"].ToString();
                       // _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                       // _item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                       // _item.RightName = sqlDataReader["RightName"].ToString();
                       // _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        _item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        _item.EmployeeName = sqlDataReader["EmployeeName"].ToString();
                       // _item.ContractStatus = sqlDataReader["ContractStatus"].ToString();
                        _item.AllotPeriod = Convert.ToDecimal(sqlDataReader["AllotPeriod"]);
                        _item.CallStatus = Convert.ToByte(sqlDataReader["CallStatus"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMCallAllotmentMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> GetCCRMCallAllotmentMasterBySearch(CCRMCallAllotmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMCallAllotmentMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCallAllotmentMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 300, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 300, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
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

                    baseEntityCollection.CollectionResponse = new List<CCRMCallAllotmentMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMCallAllotmentMaster item = new CCRMCallAllotmentMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CallTktNo = sqlDataReader["CallTktNo"].ToString();
                        item.CallDate = sqlDataReader["CallDate"].ToString();
                        item.SerialNo = sqlDataReader["SerialNo"].ToString();
                        item.ModelNo = sqlDataReader["ModelNo"].ToString();
                        item.MIFName = sqlDataReader["MIFName"].ToString();
                        item.EngineerID = Convert.ToInt32(sqlDataReader["EngineerID"]);
                       
                        item.SymptomTitle = sqlDataReader["SymptomTitle"].ToString();
                        item.Priority = Convert.ToByte(sqlDataReader["Priority"]);
                        item.ComPlaint = sqlDataReader["ComPlaint"].ToString();
                       // item.AreaPatchName = sqlDataReader["AreaPatchName"].ToString();
                        item.ItemDescription = sqlDataReader["ItemDescription"].ToString();
                        //item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        //item.RightName = sqlDataReader["RightName"].ToString();
                        //item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        item.EmployeeName = sqlDataReader["EmployeeName"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_CCRMCallAllotmentMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> GetListPendingCallByID(CCRMCallAllotmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMCallAllotmentMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCallAllotmentMaster_GetListPendingCallByID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CCRMCallAllotmentMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<CCRMCallAllotmentMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMCallAllotmentMaster item = new CCRMCallAllotmentMaster();

                        //item.CustomerContactPersonName = sqlDataReader["CustomerContactPersonName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerContactPersonName"]);
                        item.CallTktNo = sqlDataReader["CallTktNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallTktNo"]);
                        item.CallDate = sqlDataReader["CallDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CallDate"]);
                        item.MIFName = sqlDataReader["MIFName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFName"]);
                        
                        item.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMCallAllotmentMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> GetCCRMCallAllotmentMasterList(CCRMCallAllotmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMCallAllotmentMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCallAllotmentMaster_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<CCRMCallAllotmentMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMCallAllotmentMaster item = new CCRMCallAllotmentMaster();
                        item.UserID = Convert.ToInt32(sqlDataReader["UserID"]);
                        item.UserName = sqlDataReader["UserName"].ToString();
                        
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMCallAllotmentMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
    }
}
