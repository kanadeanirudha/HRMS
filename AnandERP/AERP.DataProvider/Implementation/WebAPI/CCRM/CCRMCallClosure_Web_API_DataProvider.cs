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
    public class CCRMCallClosure_Web_API_DataProvider : DBInteractionBase,ICCRMCallClosure_Web_API_DataProvider
    {
        private readonly ILogger _logException;
        public IBaseEntityResponse<CCRMServiceReportMaster> InsertServiceReport(CCRMServiceReportMaster item)
        {
            SqlInt32 _ServiceReportID = 0;

            IBaseEntityResponse<CCRMServiceReportMaster> response = new BaseEntityResponse<CCRMServiceReportMaster>();
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
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_ServiceReportInsert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iMeterReadA4Mono", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CurrentReadA4Mono));

                    cmdToExecute.Parameters.Add(new SqlParameter("iMeterReadA4Col", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CurrentReadA4Col));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iMeterReadA3Mono", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CurrentReadA3Mono));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iMeterReadA3Col", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CurrentReadA3Col));

                    if (item.BrokenReason == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBrokenReason", SqlDbType.NVarChar, 500,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBrokenReason", SqlDbType.NVarChar, 500,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.BrokenReason));
                    }

                    if (item.ReasonCode == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsReasonCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsReasonCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ReasonCode));


                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallTicketNumber", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CallTktNo));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSymtomId", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.SymptomID));

                    if(item.SymptomCode == null)
                         cmdToExecute.Parameters.Add(new SqlParameter("@nsSymtomCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSymtomCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.SymptomCode));

                    if(item.SymptomTitle == null)
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSymtomtitle", SqlDbType.NVarChar, 2000,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSymtomtitle", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.SymptomTitle));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCauseId", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CauseID));

                    if (item.CauseCode == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCauseCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCauseCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CauseCode));

                    if(item.CauseTitle == null)
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCausetitle", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCausetitle", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CauseTitle));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iActionId", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ActionID));

                    if(item.ActionCode == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsActionCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsActionCode", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ActionCode));
                    if (item.ActionTitle == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsActiontitle", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsActiontitle", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ActionTitle));

                    if (item.ActionDescrip == string.Empty || item.ActionDescrip == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsActionDescription", SqlDbType.NVarChar, 2000,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsActionDescription", SqlDbType.NVarChar, 2000,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, item.ActionDescrip));
                    }


                    if (item.CauseDescrip == string.Empty || item.CauseDescrip == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCauseDescription", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCauseDescription", SqlDbType.NVarChar, 2000,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CauseDescrip));
                    }

                    if (item.SymptomDescrip == string.Empty || item.SymptomDescrip == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSymtomDescription", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSymtomDescription", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.SymptomDescrip));
                    }
                    if (item.XmlString == string.Empty || item.XmlString == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsItemXML", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemXML", SqlDbType.NVarChar, 2000,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.XmlString));

                    if (item.Remarks == string.Empty || item.Remarks == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 2000,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 2000,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, item.Remarks));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@bSCN", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.SCNSubmitted));

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallStatus", SqlDbType.TinyInt, 1,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CallStatus));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.VersionNumber));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iServiceReportID", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _ServiceReportID));



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
                    _ServiceReportID = (SqlInt32)cmdToExecute.Parameters["@iServiceReportID"].Value;
                    item.ID = (int)_ServiceReportID;
                    response.Entity = item;


                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.NotExist && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_WEB_API_ServiceReportInsert' reported the ErrorCode: " +
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

        public IBaseEntityResponse<CCRMServiceReportMaster> InsertServiceReportImage(CCRMServiceReportMaster item)
        {
            IBaseEntityResponse<CCRMServiceReportMaster> response = new BaseEntityResponse<CCRMServiceReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_ServiceReportInsertImage";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFileName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.FileName));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.VersionNumber));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iServiceReportID", SqlDbType.Int, 4,
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
                        throw new Exception("Stored Procedure 'USP_WEB_API_ServiceReportInsertImage' reported the ErrorCode: " +
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

        public IBaseEntityResponse<CCRMServiceReportMaster> InsertFeedBackImage(CCRMServiceReportMaster item)
        {
            IBaseEntityResponse<CCRMServiceReportMaster> response = new BaseEntityResponse<CCRMServiceReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_FeedbackInsertImage";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFileName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.FileName));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.VersionNumber));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iServiceReportID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeedbackID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.FeedbackID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 250,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.Remarks));

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
                        throw new Exception("Stored Procedure 'USP_WEB_API_FeedbackImage' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<CCRMServiceReportMaster> itemHistory(CCRMServiceReportMaster item)
        {
            IBaseEntityCollectionResponse<CCRMServiceReportMaster> response = new BaseEntityCollectionResponse<CCRMServiceReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_GetItemHistory";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallTicketNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallTktNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));

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
                    response.CollectionResponse = new List<CCRMServiceReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMServiceReportMaster _CCRMServiceReportMaster = new CCRMServiceReportMaster();
                        _CCRMServiceReportMaster.ItemCategoryCode = sqlDataReader["ItemCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemCode"]);
                        _CCRMServiceReportMaster.Quantity = sqlDataReader["Qty"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["Qty"]);
                        _CCRMServiceReportMaster.ItemName = sqlDataReader["ItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        _CCRMServiceReportMaster.Requierd = sqlDataReader["ReqRepFlag"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ReqRepFlag"]);

                        response.CollectionResponse.Add(_CCRMServiceReportMaster);

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
                        throw new Exception("Stored Procedure 'USP_WEB_API_GetItemHistory' reported the ErrorCode: " + _errorCode);
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
