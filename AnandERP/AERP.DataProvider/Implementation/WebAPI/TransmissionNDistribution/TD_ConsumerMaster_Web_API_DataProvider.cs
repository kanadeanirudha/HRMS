using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public class TD_ConsumerMaster_Web_API_DataProvider : DBInteractionBase, ITD_ConsumerMaster_Web_API_DataProvider
    {
        private readonly ILogger _logException;

        public IBaseEntityCollectionResponse<ConsumerMaster> getConsumers(ConsumerMaster item)
        {
            IBaseEntityCollectionResponse<ConsumerMaster> response = new BaseEntityCollectionResponse<ConsumerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TD_GetConsumers";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nSyncType", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SyncType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLastSyncDate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LastSyncDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEngineerID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EngineerID));

                    if (_mainConnectionIsCreatedLocal)
                    {
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
                    response.CollectionResponse = new List<ConsumerMaster>();
                    while (sqlDataReader.Read())
                    {
                        ConsumerMaster _ConsumerMaster = new ConsumerMaster();

                        _ConsumerMaster.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        _ConsumerMaster.ConsumerNumber = sqlDataReader["ConsumerNumber"] is DBNull ? new long() : Convert.ToInt64(sqlDataReader["ConsumerNumber"]);
                        _ConsumerMaster.ConsumerName = sqlDataReader["ConsumerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ConsumerName"]);
                        _ConsumerMaster.Address = sqlDataReader["Address"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Address"]);
                        _ConsumerMaster.CityID = sqlDataReader["CityID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CityID"]);
                        _ConsumerMaster.SectionID = sqlDataReader["SectionID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SectionID"]);
                        _ConsumerMaster.Phase = sqlDataReader["Phase"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["Phase"]);
                        _ConsumerMaster.Latitude = sqlDataReader["Latitude"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["Latitude"]);
                        _ConsumerMaster.Longitude = sqlDataReader["Longitude"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["Longitude"]);
                        _ConsumerMaster.MobileNumber = sqlDataReader["MobileNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MobileNumber"]);
                        _ConsumerMaster.ActualSurvey_In_Meters = sqlDataReader["ActualSurvey_In_Meters"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["ActualSurvey_In_Meters"]);
                        _ConsumerMaster.DTCNumber = sqlDataReader["DTCNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DTCNumber"]);
                        _ConsumerMaster.Remark = sqlDataReader["Remark"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Remark"]);
                        _ConsumerMaster.City = sqlDataReader["City"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["City"]);
                        _ConsumerMaster.Section = sqlDataReader["Section"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Section"]);
                        _ConsumerMaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        _ConsumerMaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);
                        _ConsumerMaster.ISAdd = sqlDataReader["IsAdded"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["IsAdded"]);
                        _ConsumerMaster.WorkStatus = sqlDataReader["WorkStatus"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["WorkStatus"]);
                        _ConsumerMaster.BillingStatus = sqlDataReader["BillingStatus"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["BillingStatus"]);
                        _ConsumerMaster.ReasonStatus = sqlDataReader["ReasonStatus"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ReasonStatus"]);
                        _ConsumerMaster.IsPreviousDateAllowed = sqlDataReader["IsPreviousDateAllowed"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsPreviousDateAllowed"]);

                        response.CollectionResponse.Add(_ConsumerMaster);
                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        response.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode
                        });
                    }

                    //response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_WEB_API_TD_GetConsumers' reported the ErrorCode: " + _errorCode);
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
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }

        public IBaseEntityResponse<ConsumerMaster> DeleteConsumer(ConsumerMaster item)
        {
            IBaseEntityResponse<ConsumerMaster> response = new BaseEntityResponse<ConsumerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_DeleteConsumer";
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iConsumerID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsReason", SqlDbType.NVarChar, 400,
                                          ParameterDirection.Input, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.Reason));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.DeletedBy));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.VersionNumber));


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


                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.NotExist && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_WEB_API_DeleteConsumer' reported the ErrorCode: " +
                                            _errorCode);
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
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }

        public IBaseEntityResponse<ConsumerMaster> UpdateConsumerLatLong(ConsumerMaster item)
        {
            IBaseEntityResponse<ConsumerMaster> response = new BaseEntityResponse<ConsumerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_ConsumerLatLong";
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iConsumerID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dLatitude", SqlDbType.Decimal, 15,
                                            ParameterDirection.Input, true, 12, 9, "",
                                            DataRowVersion.Proposed, item.Latitude));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLongitude", SqlDbType.Decimal,12,
                                            ParameterDirection.Input, true, 12, 9, "",
                                            DataRowVersion.Proposed, item.Longitude));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.VersionNumber));


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


                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.NotExist && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_WEB_API_ConsumerLatLong' reported the ErrorCode: " +
                                            _errorCode);
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
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }


        public IBaseEntityResponse<ConsumerMaster> UpdateTappingPointLatLong(ConsumerMaster item)
        {
            IBaseEntityResponse<ConsumerMaster> response = new BaseEntityResponse<ConsumerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TappingPointLatLong";
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iConsumerID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dLatitude", SqlDbType.Decimal, 12,
                                            ParameterDirection.Input, true, 12, 9, "",
                                            DataRowVersion.Proposed, item.Latitude));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dLongitude", SqlDbType.Decimal, 12,
                                            ParameterDirection.Input, true, 12, 9, "",
                                            DataRowVersion.Proposed, item.Longitude));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.VersionNumber));


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


                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.NotExist && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_WEB_API_TappingPointLatLong' reported the ErrorCode: " +
                                            _errorCode);
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
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }

        public IBaseEntityResponse<ConsumerMaster> InsertImage(ConsumerMaster item)
        {
            IBaseEntityResponse<ConsumerMaster> response = new BaseEntityResponse<ConsumerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_InsertImage";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFileName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.FileName));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.VersionNumber));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iConsumerID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));

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
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.NotExist && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_WEB_API_InsertImage' reported the ErrorCode: " +
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

        public IBaseEntityResponse<ConsumerMaster> AddConsumerRequirment(ConsumerMaster item)
        {
            IBaseEntityResponse<ConsumerMaster> response = new BaseEntityResponse<ConsumerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_AddRequirement";
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iConsumerID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iStayLine", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.StayLine));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dActualSurvey_In_KM", SqlDbType.Decimal, 5,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ActualSurvey_In_KMeters));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dActualSurvey_In_M", SqlDbType.Decimal, 5,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ActualSurvey_In_Meters));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iNo_Of_Poles", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.No_Of_Poles));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iNo_Of_CutPoints", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.No_Of_CutPoints));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iGaurdingSpanNeeded", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.GaurdingSpanNeeded));
                    if(item.GaurdingNeeded != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGaurdingNeeded", SqlDbType.NVarChar, 250,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.GaurdingNeeded));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGaurdingNeeded", SqlDbType.NVarChar, 250,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iTappingFrom_ActivityID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.TappingFrom_ActivityID));
                    if (item.ConsumersGroup != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsConsumersGroup", SqlDbType.NVarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ConsumersGroup));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsConsumersGroup", SqlDbType.NVarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.AdharCardNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAdharCardNumber", SqlDbType.NVarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.AdharCardNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAdharCardNumber", SqlDbType.NVarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.TappingLocationDetails != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTappingLocationDetails", SqlDbType.NVarChar, 200,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.TappingLocationDetails));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTappingLocationDetails", SqlDbType.NVarChar, 200,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@bServiceConnection", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ServiceConnection));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bExtensionOfServiceConnection", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ExtensionOfServiceConnection));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bisCommunicateWithFarmer", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.isCommunicateWithFarmer));

                    if(item.FarmerCommunication != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFarmerCommunication", SqlDbType.NVarChar, 250,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.FarmerCommunication));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFarmerCommunication", SqlDbType.NVarChar, 250,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    

                    if(item.PresentCrop != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPresentCrop", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.PresentCrop));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPresentCrop", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.FutureCrop != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFutureCrop", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.FutureCrop));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFutureCrop", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.PresentCropCuttingDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtPresentCropCuttingDate", SqlDbType.DateTime, 8,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.PresentCropCuttingDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtPresentCropCuttingDate", SqlDbType.DateTime, 8,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.FutureCropPlantationDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtFutureCropPlantationDate", SqlDbType.DateTime, 8,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.FutureCropPlantationDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtFutureCropPlantationDate", SqlDbType.DateTime, 8,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    


                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.VersionNumber));

                    if(item.OtherIssues != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOtherIssues", SqlDbType.VarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.OtherIssues));
                    }
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOtherIssues", SqlDbType.VarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    if (item.TappingMaterials != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTappingMaterials", SqlDbType.VarChar, 150,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.TappingMaterials));
                    }
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTappingMaterials", SqlDbType.VarChar, 150,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));

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


                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.NotExist && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_WEB_API_AddRequirement' reported the ErrorCode: " +
                                            _errorCode);
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
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }

        public IBaseEntityCollectionResponse<ConsumerMaster> generateGroups(ConsumerMaster item)
        {
            IBaseEntityCollectionResponse<ConsumerMaster> response = new BaseEntityCollectionResponse<ConsumerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TD_GenerateGroups";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));

                    if (_mainConnectionIsCreatedLocal)
                    {
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
                    response.CollectionResponse = new List<ConsumerMaster>();
                    while (sqlDataReader.Read())
                    {
                        ConsumerMaster _ConsumerMaster = new ConsumerMaster();

                        _ConsumerMaster.Source = sqlDataReader["source"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["source"]);
                        _ConsumerMaster.Distance = sqlDataReader["distance"] is DBNull ? new Double() : Convert.ToDouble(sqlDataReader["distance"]);
                        _ConsumerMaster.Destination = sqlDataReader["destination"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["destination"]);
                        _ConsumerMaster.DestinationName = sqlDataReader["DestinationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DestinationName"]);
                        _ConsumerMaster.SourceName = sqlDataReader["SourceName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SourceName"]);

                        response.CollectionResponse.Add(_ConsumerMaster);
                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (System.Data.SqlTypes.SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        response.Message.Add(new MessageDTO()
                        {
                            ErrorID = (int)_errorCode
                        });
                    }

                    //response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_WEB_API_TD_GenerateGroups' reported the ErrorCode: " + _errorCode);
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
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }
    }
}
