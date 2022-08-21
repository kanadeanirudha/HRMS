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
    public class LoginDataProvider : DBInteractionBase, ILoginDataProvider
    {
        #region Login API

        

       public IBaseEntityResponse<UserMaster> ChangePassword(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeeCurrentpassword_Update_Web_API";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNewPassword", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, item.Password));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOldPassword", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.OldPassword));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

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
                    UserMaster userMaster = new UserMaster();

                    if (sqlDataReader.Read())
                    {
                       
                    }
                    sqlDataReader.Close();
                    SqlString _URL = "";
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (cmdToExecute.Parameters["@sURL"].Value != null)
                    {
                        _URL = (SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                    }
                    response.Entity = userMaster;
                    response.Entity.ErrorCode = (int)_errorCode;
                    response.Entity.URL = (string)_URL;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.InvalidCredentials && _errorCode != (int)ErrorEnum.VersionUpgrade && _errorCode != (int)ErrorEnum.NotRegistered && _errorCode != (int)ErrorEnum.OldPasswordNotMatched)
                    {
                        throw new Exception("Stored Procedure 'USP_LoginVerification Procedure' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<UserMaster> UserLoginApi(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_LoginVerification";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 250, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.URL));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sMobileNumber", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, item.EmailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPassword", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, item.Password));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sMachineName", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MachinName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sIP", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.IP));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    if(item.DeviceToken != null)
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDeviceToken", SqlDbType.VarChar, 250, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, item.DeviceToken));
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDeviceToken", SqlDbType.VarChar, 250, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    if (item.IMEI != null)
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIMEI", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, item.IMEI));
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIMEI", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, DBNull.Value));

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
                    UserMaster userMaster = new UserMaster();

                    if (sqlDataReader.Read())
                    {
                        userMaster.exists = sqlDataReader["exist"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["exist"]);
                        if (userMaster.exists.ToUpper() == "EXIST")
                        {
                            userMaster.EmployeeMasterID = sqlDataReader["EmployeeMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeMasterID"]);
                            userMaster.UserID = sqlDataReader["UserID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["UserID"]);
                            userMaster.UserName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                            userMaster.EmailID = sqlDataReader["EmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmailID"]);
                            userMaster.MobileNumber = sqlDataReader["MobileNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MobileNumber"]);
                            userMaster.EmployeeDesignation = sqlDataReader["EmployeeDesignation"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeDesignation"]);
                            userMaster.EmployeeDesignationID = sqlDataReader["EmployeeDesignationID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeDesignationID"]);
                            userMaster.IsServiceEnginner = sqlDataReader["ServiceEnginner"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["ServiceEnginner"]);
                            userMaster.IsServiceManager = sqlDataReader["ServiceManager"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["ServiceManager"]);
                            userMaster.IsCollectionExecutive = sqlDataReader["CollectionExecutive"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["CollectionExecutive"]);
                            userMaster.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                            userMaster.BiomatrixID = sqlDataReader["BioMatrixEmployeeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["BioMatrixEmployeeID"]);
                            userMaster.IsAllowPunchFromOutSide = sqlDataReader["IsAllowPunchFromOutSide"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsAllowPunchFromOutSide"]);
                        }
                    }
                    sqlDataReader.Close();
                    SqlString _URL = "";
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (cmdToExecute.Parameters["@sURL"].Value != null)
                    {
                        _URL = (SqlString)cmdToExecute.Parameters["@sURL"].Value.ToString();
                    }
                    response.Entity = userMaster;
                    response.Entity.ErrorCode = (int)_errorCode;
                    response.Entity.URL = (string)_URL;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.InvalidCredentials && _errorCode != (int)ErrorEnum.VersionUpgrade && _errorCode != (int)ErrorEnum.NotRegistered)
                    {
                        throw new Exception("Stored Procedure 'USP_LoginVerification Procedure' reported the ErrorCode: " + _errorCode);
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
        #endregion

        public IBaseEntityResponse<UserMaster> IsValidate(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_LoginValidate";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, item.EmailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPassword", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, item.Password));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                    UserMaster userMaster = new UserMaster();

                    if (sqlDataReader.Read())
                    {
                        userMaster.exists = sqlDataReader["exist"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["exist"]);
                    }
                    sqlDataReader.Close();
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    response.Entity = userMaster;
                    response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.InvalidCredentials && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_USP_WEB_API_LoginValidate Procedure' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<UserMaster> EngineerList(UserMaster item)
        {
            IBaseEntityCollectionResponse<UserMaster> response = new BaseEntityCollectionResponse<UserMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_EngineersList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nSyncType", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SyncType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dLastSyncDate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LastSyncDate));
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
                    response.CollectionResponse = new List<UserMaster>();
                    while (sqlDataReader.Read())
                    {
                        UserMaster userMaster = new UserMaster();

                        userMaster.EmployeeMasterID = sqlDataReader["EmployeeMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeMasterID"]);
                        userMaster.UserID = sqlDataReader["UserID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["UserID"]);
                        userMaster.UserName = sqlDataReader["EmpName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmpName"]);
                        userMaster.EmailID = sqlDataReader["eMail"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["eMail"]);
                        userMaster.MobileNumber = sqlDataReader["MobileNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MobileNo"]);
                        userMaster.EmployeeDesignation = sqlDataReader["DesigName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DesigName"]);
                        userMaster.LastSyncDate = sqlDataReader["LastSyncDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["LastSyncDate"]);
                        userMaster.Entity = sqlDataReader["Entity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Entity"]);
                        userMaster.EmployeeCode = sqlDataReader["EmpCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmpCode"]);
                        response.CollectionResponse.Add(userMaster);
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
                        throw new Exception("Stored Procedure 'USP_WEB_API_EngineersList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<UserMaster> GetUserMasterByEmailIDPassword(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> response = new BaseEntityResponse<UserMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_LMS_AdminLoginVerification";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPassword", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Password));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sMachinName", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MachinName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sIP", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IP));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bMarkAttendanceCheckInTime", SqlDbType.Bit, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MarkAttendanceCheckInTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sUserType", SqlDbType.VarChar, 1, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLogInsertStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLogInsertError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLockInsertStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserLockInsertError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ""));
                   /* cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VersionNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeviceToken", SqlDbType.VarChar, 250, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, item.DeviceToken));*/


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
                    UserMaster userMaster = new UserMaster();

                    if (sqlDataReader.Read())
                    {
                        var exists = sqlDataReader["exist"].ToString();
                        if (exists == "Exists")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                            {
                                userMaster.ID = Convert.ToInt32(sqlDataReader["ID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UserTypeID"]) == false)
                            {
                                userMaster.UserTypeID = Convert.ToInt32(sqlDataReader["UserTypeID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["UserType"]) == false)
                            {
                                userMaster.UserType = Convert.ToChar(sqlDataReader["UserType"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                            {
                                userMaster.EmailID = sqlDataReader["EmailID"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Password"]) == false)
                            {
                                userMaster.Password = sqlDataReader["Password"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["PersonID"]) == false)
                            {
                                userMaster.PersonID = Convert.ToInt32(sqlDataReader["PersonID"].ToString());
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FirstName"]) == false)
                            {
                                userMaster.FirstName = sqlDataReader["FirstName"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["MiddleName"]) == false)
                            {
                                userMaster.MiddleName = sqlDataReader["MiddleName"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LastName"]) == false)
                            {
                                userMaster.LastName = sqlDataReader["LastName"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Gender"]) == false)
                            {
                                userMaster.Gender = sqlDataReader["Gender"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["DateOfBirth"]) == false)
                            {
                                userMaster.DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                            {
                                userMaster.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ProfilePhoto"]) == false)
                            {
                                userMaster.ProfilePhoto = (byte[])(sqlDataReader["ProfilePhoto"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ProfilePhotoSize"]) == false)
                            {
                                userMaster.ProfilePhotoSize = sqlDataReader["ProfilePhotoSize"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["LastModuleCode"]) == false)
                            {
                                userMaster.LastModuleCode = sqlDataReader["LastModuleCode"].ToString();
                            }
                        }
                    }
                    sqlDataReader.Close();

                    if (cmdToExecute.Parameters["@iPersonID"].Value != null && cmdToExecute.Parameters["@iPersonID"].Value.ToString() != "")
                    {
                        userMaster.PersonID = Convert.ToInt32(cmdToExecute.Parameters["@iPersonID"].Value);
                    }
                    if (cmdToExecute.Parameters["@nsErrorMessage"].Value != null && cmdToExecute.Parameters["@nsErrorMessage"].Value.ToString() != "")
                    {
                        userMaster.ErrorMessage = cmdToExecute.Parameters["@nsErrorMessage"].Value.ToString();
                    }
                    if (cmdToExecute.Parameters["@iStatus"].Value != null && cmdToExecute.Parameters["@iStatus"].Value.ToString() != "")
                    {
                        userMaster.Status = Convert.ToInt32(cmdToExecute.Parameters["@iStatus"].Value);
                    }
                    //if (cmdToExecute.Parameters["@sUserType"].Value.ToString() != "Null")
                    //{
                    //    _item.UserType = Convert.ToChar(cmdToExecute.Parameters["@sUserType"].Value);
                    //}
                    response.Entity = userMaster;
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }

                    response.Entity = userMaster;
                    response.Entity.ErrorCode = (int)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.Success && _errorCode != (int)ErrorEnum.InvalidCredentials && _errorCode != (int)ErrorEnum.VersionUpgrade)
                    {
                        throw new Exception("Stored Procedure 'USP_LoginVerification Procedure' reported the ErrorCode: " + _errorCode);
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
