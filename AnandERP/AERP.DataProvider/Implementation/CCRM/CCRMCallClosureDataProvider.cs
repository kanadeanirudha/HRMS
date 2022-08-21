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
  public  class CCRMCallClosureDataProvider :DBInteractionBase,ICCRMCallClosureDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion
        #region Constructor
        public CCRMCallClosureDataProvider()
        {
        }
        public CCRMCallClosureDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion
        public IBaseEntityResponse<CCRMCallClosure> UpdateCCRMCallClosure(CCRMCallClosure item)
        {
            IBaseEntityResponse<CCRMCallClosure> response = new BaseEntityResponse<CCRMCallClosure>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCallClosure_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //cmdToExecute.Parameters.Add(new SqlParameter("@SrNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SrNo));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@SCRNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SCRNo.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsSRDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SRDate.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCallCloseDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallCloseDate.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEngineerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EngineerID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsServEnggName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EnggName.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCallId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallId));
                   cmdToExecute.Parameters.Add(new SqlParameter("@nsCallTktNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallTktNo.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCallDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallDate.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSCRCount", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SCRCount));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFName", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MIFName.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iMIFID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MIFID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsModelNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ModelNo.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SerialNo.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsContractType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractType.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iContractTypeId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractTypeID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsComPlaint", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ComPlaint.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsDispDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DispDate.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsArrvDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ArrivalDate.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCompletionDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CompletionDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mArrivalPeriod", SqlDbType.Money, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ArrivalPeriod));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mCompletionPeriod", SqlDbType.Money, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CompletionPeriod));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCurrentReadA4Mono", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CurrentReadA4Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCurrentReadA4Col", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CurrentReadA4Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCurrentReadA3Mono", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CurrentReadA3Mono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCurrentReadA3Col", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CurrentReadA3Col));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSymptomID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SymptomID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSymptomCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SymptomCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCauseID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CauseID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCauseCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CauseCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iActionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsActionCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActionCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSymptom", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Symptom.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCauseTitle", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CauseTitle.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsActionTitle", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActionTitle.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSignedBy", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SignedBy.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSignPhoneNO", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PhoneNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Remarks.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeedbackID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeedbackID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFeedback", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Feedback.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UserID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bSCN", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SCNSubmitted));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsAllotDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AllotDate.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mAllotPeriod", SqlDbType.Money, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AllotPeriod));
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsJobstartDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobstartDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsJobEndDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobEndDate.Trim()));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@mJobPeriod", SqlDbType.Money, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobPeriod));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iReasonID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ReasonID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@xCCRMSRItemDetailsXML", SqlDbType.Xml, 0,
                    //                     ParameterDirection.Input, false, 10, 0, "",
                    //                     DataRowVersion.Proposed, item.XmlString));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (item.XmlString != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xCCRMSRItemDetailsXML", SqlDbType.Xml, 0,
                                       ParameterDirection.Input, false, 10, 0, "",
                                       DataRowVersion.Proposed, item.XmlString));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xCCRMSRItemDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.ReasonCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsReasonCode ", SqlDbType.NVarChar, 50,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.ReasonCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsReasonCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.SymptomDescrip != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSymptomDescrip", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SymptomDescrip.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSymptomDescrip", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.CauseDescrip != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCauseDescrip", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CauseDescrip.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCauseDescrip", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.ActionDescrip != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsActionDescrip", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActionDescrip.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsActionDescrip", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
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
                    cmdToExecute.CommandTimeout = 0;
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMCallClosure_Insert' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMCallClosure> DeleteCCRMCallClosure(CCRMCallClosure item)
        {
            IBaseEntityResponse<CCRMCallClosure> response = new BaseEntityResponse<CCRMCallClosure>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCallClosure_Delete";
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
                        throw new Exception("Stored Procedure 'USP_CCRMCallClosure_Delete' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMCallClosure> GetCCRMCallClosureByID(CCRMCallClosure item)
        {
            IBaseEntityResponse<CCRMCallClosure> response = new BaseEntityResponse<CCRMCallClosure>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCallClosure_SelectOne";
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
                        CCRMCallClosure _item = new CCRMCallClosure();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.CallTktNo = sqlDataReader["CallTktNo"].ToString();
                        _item.CallDate = sqlDataReader["CallDate"].ToString();
                        _item.MIFID = Convert.ToInt32(sqlDataReader["MIFID"]);
                        _item.MIFName = sqlDataReader["MIFName"].ToString();
                        _item.SerialNo = sqlDataReader["SerialNo"].ToString();
                        _item.ModelNo = sqlDataReader["ModelNo"].ToString();
                        _item.SymptomID = Convert.ToInt32(sqlDataReader["SymptomID"]);
                        //  _item.CallTypeID = sqlDataReader["CallTypeID"].ToString();
                        _item.SymptomTitle = sqlDataReader["SymptomTitle"].ToString();
                        _item.CallerName = sqlDataReader["CallerName"].ToString();
                        //_item.CallerPh = sqlDataReader["CallerPh"].ToString();
                        _item.EngineerID = Convert.ToInt32(sqlDataReader["EngineerID"]);
                        _item.ComPlaint = sqlDataReader["ComPlaint"].ToString();
                        //_item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //_item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        _item.ItemDescription = sqlDataReader["ItemDescription"].ToString();
                      //  _item.RightName = sqlDataReader["RightName"].ToString();
                       // _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        _item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        _item.EmployeeName = sqlDataReader["EmployeeName"].ToString();
                        _item.ContractCode = sqlDataReader["ContractCode"].ToString();
                        _item.AllotDate = sqlDataReader["AllotDate"].ToString();
                        _item.AllotPeriod = Convert.ToDecimal(sqlDataReader["AllotPeriod"]);
                        _item.A4Mono = Convert.ToInt32(sqlDataReader["A4Mono"]);
                        _item.A4Col = Convert.ToInt32(sqlDataReader["A4Col"]);
                        _item.A3Mono = Convert.ToInt32(sqlDataReader["A3Mono"]);
                        _item.A3Col = Convert.ToInt32(sqlDataReader["A3Col"]);
                        _item.ContractTypeID = Convert.ToInt32(sqlDataReader["ContractTypeID"]);
                        _item.ArrivalPeriod = Convert.ToDecimal(sqlDataReader["ArrivalPeriod"]);
                        _item.CompletionPeriod = Convert.ToDecimal(sqlDataReader["CompletionPeriod"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMCallClosure_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMCallClosure> GetCCRMCallClosureBySearch(CCRMCallClosureSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCallClosure> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMCallClosure>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMCallClosure_SelectAll";
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

                    baseEntityCollection.CollectionResponse = new List<CCRMCallClosure>();
                    while (sqlDataReader.Read())
                    {
                        CCRMCallClosure item = new CCRMCallClosure();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CallTktNo = sqlDataReader["CallTktNo"].ToString();
                        item.CallDate = sqlDataReader["CallDate"].ToString();
                        item.SerialNo = sqlDataReader["SerialNo"].ToString();
                        item.ModelNo = sqlDataReader["ModelNo"].ToString();
                        item.MIFName = sqlDataReader["MIFName"].ToString();
                        item.EngineerID = Convert.ToInt32(sqlDataReader["EngineerID"]);
                        item.CallTypeID = Convert.ToInt32(sqlDataReader["CallTypeID"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"].ToString();
                       // item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        item.CallTypeName = sqlDataReader["CallTypeName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CCRMCallClosure_SelectAll' reported the ErrorCode: " + _errorCode);
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
