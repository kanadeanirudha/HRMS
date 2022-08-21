using AERP.Base.DTO;
using AERP.DTO;
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
    public class TD_DailyActivityReport_Web_API_DataProvider : DBInteractionBase,ITD_DailyActivityReport_Web_API_DataProvider
    {

        public IBaseEntityResponse<DailyActivityReport> InsertDailyActivityReport(DailyActivityReport item)
        {
            IBaseEntityResponse<DailyActivityReport> response = new BaseEntityResponse<DailyActivityReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_InsertDailyActivityReport";
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iConsumerID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ConsumerID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CityID));
                    if(item.XML == null)
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsXML", SqlDbType.NVarChar, 4000,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsXML", SqlDbType.NVarChar, 4000,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.XML));

                    if (item.CreatedDate.CompareTo(new DateTime())==0)
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtCreatedDate", SqlDbType.DateTime, 8,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtCreatedDate", SqlDbType.DateTime, 8,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iLabours", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.Labours));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nvIssues", SqlDbType.NVarChar, 150,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.Issues==null? string.Empty :item.Issues));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nvWorkType", SqlDbType.NVarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.WorkType));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4,
                                          ParameterDirection.Input, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.Status));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.VersionNumber));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dLatitude", SqlDbType.Decimal, 12,
                                            ParameterDirection.Input, true, 12, 9, "",
                                            DataRowVersion.Proposed, item.Latitude));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dLongitude", SqlDbType.Decimal, 12,
                                            ParameterDirection.Input, true, 12, 9, "",
                                            DataRowVersion.Proposed, item.Longitude));


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
                        throw new Exception("Stored Procedure 'USP_WEB_API_InsertDailyActivityReport' reported the ErrorCode: " +
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

        public IBaseEntityResponse<DailyActivityReport> InsertScheduleActivity(DailyActivityReport item)
        {
            IBaseEntityResponse<DailyActivityReport> response = new BaseEntityResponse<DailyActivityReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_InsertScheduleActivity";
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if (item.XML == null)
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsXML", SqlDbType.NVarChar, 4000,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsXML", SqlDbType.NVarChar, 4000,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.XML));

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
                        throw new Exception("Stored Procedure 'USP_WEB_API_InsertScheduleActivity' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<DailyActivityReport> GetWorkHistory(DailyActivityReport item)
        {
            IBaseEntityCollectionResponse<DailyActivityReport> response = new BaseEntityCollectionResponse<DailyActivityReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TD_WorkHistory";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
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
                    response.CollectionResponse = new List<DailyActivityReport>();
                    while (sqlDataReader.Read())
                    {
                        DailyActivityReport _DailyActivityReport = new DailyActivityReport();

                        _DailyActivityReport.ConsumerID = sqlDataReader["ConsumerID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ConsumerID"]);
                        _DailyActivityReport.Activity = sqlDataReader["Activity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Activity"]);
                        _DailyActivityReport.SubActivity = sqlDataReader["SubActivity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubActivity"]);
                        _DailyActivityReport.ConsumerName = sqlDataReader["ConsumerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ConsumerName"]);
                        _DailyActivityReport.WorkDone = sqlDataReader["WorkDone"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["WorkDone"]);
                        _DailyActivityReport.ConsumerNumber = sqlDataReader["ConsumerNumber"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ConsumerNumber"]);
                        _DailyActivityReport.ActivityCategory = sqlDataReader["ActivityCategory"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ActivityCategory"]);

                        response.CollectionResponse.Add(_DailyActivityReport);
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
                        throw new Exception("Stored Procedure 'USP_WEB_API_TD_WorkHistory' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<DailyActivityReport> GetWorkDetails(DailyActivityReport item)
        {
            IBaseEntityCollectionResponse<DailyActivityReport> response = new BaseEntityCollectionResponse<DailyActivityReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TD_TodaysWorkDetail";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                   
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
                    response.CollectionResponse = new List<DailyActivityReport>();
                    while (sqlDataReader.Read())
                    {
                        DailyActivityReport _DailyActivityReport = new DailyActivityReport();

                        _DailyActivityReport.ConsumerID = sqlDataReader["ConsumerID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ConsumerID"]);
                        _DailyActivityReport.Status = sqlDataReader["Status"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["Status"]);
                        _DailyActivityReport.BillingStatus = sqlDataReader["BillingStatus"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["BillingStatus"]);
                        _DailyActivityReport.ConsumerName = sqlDataReader["ConsumerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ConsumerName"]);
                        _DailyActivityReport.ReasonStatus = sqlDataReader["ReasonStatus"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ReasonStatus"]);
                        _DailyActivityReport.ConsumerNumber = sqlDataReader["ConsumerNumber"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ConsumerNumber"]);
                        _DailyActivityReport.EngineerName = sqlDataReader["EngineerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EngineerName"]);

                        response.CollectionResponse.Add(_DailyActivityReport);
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
                        throw new Exception("Stored Procedure 'USP_WEB_API_TD_TodaysWorkDetail' reported the ErrorCode: " + _errorCode);
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
