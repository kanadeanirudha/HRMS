using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace AERP.DataProvider
{
    public class LocationTrackingDataProvider : DBInteractionBase, ILocationTrackingDataProvider
    {
        public IBaseEntityCollectionResponse<LocationTracking> getCurrentLocation(LocationTracking item)
        {
            IBaseEntityCollectionResponse<LocationTracking> response = new BaseEntityCollectionResponse<LocationTracking>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_TD_GetLocations";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iManagerID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ManagerID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sVersionNumber", SqlDbType.VarChar, 20,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.VersionNumber));

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
                    response.CollectionResponse = new List<LocationTracking>();
                    while (sqlDataReader.Read())
                    {
                        LocationTracking _LocationTracking = new LocationTracking();

                        _LocationTracking.Name = sqlDataReader["Name"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["Name"]);
                        _LocationTracking.Latitude = sqlDataReader["Latitude"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Latitude"]);
                        _LocationTracking.Longitude = sqlDataReader["Longitude"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Longitude"]);
                        _LocationTracking.CreatedBy = sqlDataReader["CreatedBy"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CreatedBy"]);
                       
                        response.CollectionResponse.Add(_LocationTracking);
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
                        throw new Exception("Stored Procedure 'USP_WEB_API_TD_GetLocations' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<LocationTracking> InsertLocations(LocationTracking item)
        {
            IBaseEntityResponse<LocationTracking> response = new BaseEntityResponse<LocationTracking>();
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
                    cmdToExecute.CommandText = "dbo.USP_WEB_API_InsertLocations";
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                  
                    if (item.XML == null)
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsXML", SqlDbType.Xml, 0,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    else
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsXML", SqlDbType.Xml, 0,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.XML));


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
                        throw new Exception("Stored Procedure 'USP_WEB_API_InsertLocations' reported the ErrorCode: " +
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
    }
}
