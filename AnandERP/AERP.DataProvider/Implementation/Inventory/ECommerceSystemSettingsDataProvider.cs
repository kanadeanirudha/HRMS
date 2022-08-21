using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AMS.DataProvider
{
    public class ECommerceSystemSettingsDataProvider : DBInteractionBase, IECommerceSystemSettingsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public ECommerceSystemSettingsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public ECommerceSystemSettingsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from ECommerceSystemSettings table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ECommerceSystemSettings> GetECommerceSystemSettingsBySearch(ECommerceSystemSettingsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ECommerceSystemSettings> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ECommerceSystemSettings>();
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
                    cmdToExecute.CommandText = "dbo.USP_EComSysytemSettings_GetStoreandMenusData";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTaskcode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskCode));
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
                    baseEntityCollection.CollectionResponse = new List<ECommerceSystemSettings>();
                    while (sqlDataReader.Read())
                    {
                        ECommerceSystemSettings item = new ECommerceSystemSettings();
                        if (searchRequest.TaskCode == "GeneralStoreData")
                        {
                            item.EComStoreSettingID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt16(sqlDataReader["ID"]);
                            item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralUnitsID"]);
                        }
                        if (searchRequest.TaskCode == "GeneralMenusData")
                        {
                            item.LevelNumber = sqlDataReader["LevelNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["LevelNumber"]);
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
                       // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ECommerceSystemSettings_SelectAll' reported the ErrorCode: " + _errorCode);
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
       
        public IBaseEntityResponse<ECommerceSystemSettings> InsertECommerceSystemSettings(ECommerceSystemSettings item)
        {
            IBaseEntityResponse<ECommerceSystemSettings> response = new BaseEntityResponse<ECommerceSystemSettings>();
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
                    cmdToExecute.CommandText = "dbo.USP_ECommerceSystemSettings_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siEComStoreSettingID", SqlDbType.Int, 4, 
                                                 ParameterDirection.InputOutput, true, 10, 0, "", 
                                                 DataRowVersion.Proposed, item.EComStoreSettingID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siEComCategorySettingID", SqlDbType.Int, 4,
                                                 ParameterDirection.InputOutput, true, 10, 0, "",
                                                 DataRowVersion.Proposed, item.EComCategorySettingID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@siGeneralUnitsID", SqlDbType.SmallInt, 4,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, item.GeneralUnitsID));
                    
                        if (item.SelectedIDs != null)
                        {
                            cmdToExecute.Parameters.Add(new SqlParameter("@xIDs", SqlDbType.Xml, 0,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, item.SelectedIDs));
                        }
                        else
                        {
                            cmdToExecute.Parameters.Add(new SqlParameter("@xIDs", SqlDbType.Xml, 0,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.TaskCode != null)
                        {
                            cmdToExecute.Parameters.Add(new SqlParameter("@nsTaskcode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TaskCode));
                        }
                        else
                        {
                            cmdToExecute.Parameters.Add(new SqlParameter("@nsTaskcode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                    
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iOnlineExamAllocateSupportStaffID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_ECommerceSystemSettings_Insert' reported the ErrorCode: " +
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
       
        #endregion
    }
}
