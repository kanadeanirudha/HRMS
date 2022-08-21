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
    public class Telematics_WEB_API_DataProvider : DBInteractionBase,ITelematics_WEB_API_DataProvider
    {
        private readonly ILogger _logException;

        public IBaseEntityResponse<SensorData> InsertSensorData(SensorData item)
        {
            IBaseEntityResponse<SensorData> response = new BaseEntityResponse<SensorData>();
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
                    cmdToExecute.CommandText = "dbo.USP_Telematics_Insert";
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsVeh_ID", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.veh_id));

                    cmdToExecute.Parameters.Add(new SqlParameter("@biTS", SqlDbType.BigInt, 8,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.TS));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix1", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.p1));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix2", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.p2));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix3", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.p3));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix4", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.p4));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix5", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.p5));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix6", SqlDbType.Decimal, 4,
                                           ParameterDirection.Input, true, 10, 9, "",
                                           DataRowVersion.Proposed, item.p6));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix7", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.t1));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix8", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.t2));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix9", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.t3));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix10", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.t4));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix11", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.t5));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ix12", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.t6));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iEng", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.Eng));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iPower", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.Power));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iMem", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.Mem));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iBattery", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.Battery));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iLat", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.Lat));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iLon", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.Lon));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iBLE", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.BLE));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iX_axis", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.X_axis));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iY_axis", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.Y_axis));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iZ_axis", SqlDbType.Decimal, 12,
                                           ParameterDirection.Input, true, 12, 9, "",
                                           DataRowVersion.Proposed, item.Z_axis));


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
                        throw new Exception("Stored Procedure 'USP_Telematics_Insert' reported the ErrorCode: " +
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
    }
}
