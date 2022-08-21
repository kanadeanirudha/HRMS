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
    public class ESICMonthlyUploadingFileDataProvider : DBInteractionBase, IESICMonthlyUploadingFileDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public ESICMonthlyUploadingFileDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public ESICMonthlyUploadingFileDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        public IBaseEntityCollectionResponse<ESICMonthlyUploadingFile> GetESICMonthlyUploadingFileDataList(ESICMonthlyUploadingFileSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ESICMonthlyUploadingFile> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ESICMonthlyUploadingFile>();
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
                    cmdToExecute.CommandText = "dbo.USP_EmployeesESICReportFormNo7";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMonth", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MonthName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsYear", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Monthyear));
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

                    baseEntityCollection.CollectionResponse = new List<ESICMonthlyUploadingFile>();
                    while (sqlDataReader.Read())
                    {
                        ESICMonthlyUploadingFile item = new ESICMonthlyUploadingFile();

                        item.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        item.ESICNumber = sqlDataReader["ESICNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ESICNumber"]);
                        item.WorkingDays = sqlDataReader["WorkingDays"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["WorkingDays"]);
                        item.TotalAmountofWages= sqlDataReader["TotalAmountOfWages"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAmountOfWages"]);
                        item.Monthyear = searchRequest.Monthyear;
                        item.MonthName = searchRequest.MonthName;
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ESICMonthlyUploadingFile_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<ESICMonthlyUploadingFile> GetESICMonthlyUploadingFileDataListForParticularsMonthWise(ESICMonthlyUploadingFileSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ESICMonthlyUploadingFile> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ESICMonthlyUploadingFile>();
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
                    cmdToExecute.CommandText = "dbo.USP_ESICMonthlyUploadingFileDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@tiMonth", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MonthName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsYear", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MonthYear));
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

                    baseEntityCollection.CollectionResponse = new List<ESICMonthlyUploadingFile>();
                    while (sqlDataReader.Read())
                    {
                        ESICMonthlyUploadingFile item = new ESICMonthlyUploadingFile();

                        //item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);
                        //item.CentreAdress = sqlDataReader["CentreAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreAddress"]);
                        //item.MonthName = searchRequest.MonthName;
                        //item.MonthYear = searchRequest.MonthYear;
                        //item.WorkersShare = sqlDataReader["WorkersShare"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["WorkersShare"]);
                        //item.Acc01 = sqlDataReader["Acc01"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Acc01"]);
                        //item.Acc10 = sqlDataReader["Acc10"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Acc10"]);
                        //item.Acc21 = sqlDataReader["Acc21"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Acc21"]);
                        //item.Acc02 = sqlDataReader["Acc02"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Acc02"]);
                        //item.Acc22 = sqlDataReader["Acc22"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Acc22"]);
                        //item.PaymentMode = sqlDataReader["PayementMode"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["PayementMode"]);
                        //item.ChallanRemmittanceDate = sqlDataReader["ChalanRemitanceDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ChalanRemitanceDate"]);
                        //item.ReferenceNumber = sqlDataReader["ReferenceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ReferenceNumber"]);
                        //item.ID = sqlDataReader["ESICMonthlyUploadingFileID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ESICMonthlyUploadingFileID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ESICMonthlyUploadingFile_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<ESICMonthlyUploadingFile> InsertESICMonthlyUploadingFile(ESICMonthlyUploadingFile item)
        {
            IBaseEntityResponse<ESICMonthlyUploadingFile> response = new BaseEntityResponse<ESICMonthlyUploadingFile>();
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
                    cmdToExecute.CommandText = "dbo.USP_PFChalanRemitance_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //cmdToExecute.Parameters.Add(new SqlParameter("@tiMonth", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MonthName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsYear", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MonthYear));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@tiPayementMode", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PaymentMode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsReferenceNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ReferenceNumber));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mEmployeeShare", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.WorkersShare));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mEmployerAcc01", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Acc01));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mEmployerAcc02", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Acc02));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mEmployerAcc10", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Acc10));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mEmployerAcc21", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Acc21));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mEmployerAcc22", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Acc22));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@mTotalAmountRemited", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalAmountRemited));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtChallanRemmittanceDate", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ChallanRemmittanceDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SaleContractManPowerItem_Insert' reported the ErrorCode: " +
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
