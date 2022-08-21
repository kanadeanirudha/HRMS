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
   public class CCRMTonerRequestCallDataProvider:DBInteractionBase, ICCRMTonerRequestCallDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;

#endregion
        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public CCRMTonerRequestCallDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public CCRMTonerRequestCallDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion
        public IBaseEntityResponse<CCRMTonerRequestCall> InsertCCRMTonerRequestCall(CCRMTonerRequestCall item)
        {
            IBaseEntityResponse<CCRMTonerRequestCall> response = new BaseEntityResponse<CCRMTonerRequestCall>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMTonerRequestCall_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallDate.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SerialNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iContractID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContractCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ContractCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMIFID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MIFID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFName", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MIFName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModelNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ModelNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMachineFamilyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MachineFamilyID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPartNO", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PartNO.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPartName", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PartName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalanceQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BalanceQuantity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Quantity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bFOC", SqlDbType.Bit, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FOC));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCurrentMeterRead", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CurrentMeterRead));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallerName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallerName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallerPh", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallerPh.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@CallNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallNo));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iLastCallNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastCallNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLastQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastQuantity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLastMtrRead", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastMtrRead));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iConsumption", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Consumption));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardCopy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StandardCopy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (item.CallTktNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCallTktNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallTktNo.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCallTktNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Remarks != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Remarks.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 1000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.LastCallDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastCallDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LastCallDate.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastCallDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
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

                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                    {
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMTonerRequestCall_Insert' reported the ErrorCode: " +
                                            _errorCode);
                    }


                    //        if (_rowsAffected > 0)
                    //        {
                    //            response.Entity = item;
                    //        }
                    //        else
                    //        {
                    //            response.Message.Add(new MessageDTO
                    //            {
                    //                ErrorMessage = "Create failed"
                    //            });
                    //        }
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
        public IBaseEntityResponse<CCRMTonerRequestCall> GetCCRMTonerRequestCallByID(CCRMTonerRequestCall item)
        {
            IBaseEntityResponse<CCRMTonerRequestCall> response = new BaseEntityResponse<CCRMTonerRequestCall>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMTonerRequestCall_SelectOne";
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
                        CCRMTonerRequestCall _item = new CCRMTonerRequestCall();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.LastCallNo = Convert.ToInt32(sqlDataReader["LastCallNo"]);

                         _item.LastCallDate = sqlDataReader["LastCallDate"].ToString();
                        _item.LastQuantity = Convert.ToInt32(sqlDataReader["LastQuantity"]);
                        _item.LastMtrRead = Convert.ToInt32(sqlDataReader["LastMtrRead"]);

                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMTonerRequestCall_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMTonerRequestCall> GetCCRMTonerRequestCallBySearch(CCRMTonerRequestCallSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMTonerRequestCall> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMTonerRequestCall>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMTonerRequestCall_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
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

                    baseEntityCollection.CollectionResponse = new List<CCRMTonerRequestCall>();
                    while (sqlDataReader.Read())
                    {
                        CCRMTonerRequestCall item = new CCRMTonerRequestCall();
                        item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                       // item.BankName = sqlDataReader["BankName"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_CCRMTonerRequestCall_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMTonerRequestCall> GetLastCallByModelNo(CCRMTonerRequestCallSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMTonerRequestCall> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMTonerRequestCall>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMLastCallNo_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModelNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ModelNo));
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
                    baseEntityCollection.CollectionResponse = new List<CCRMTonerRequestCall>();
                    while (sqlDataReader.Read())
                    {
                        CCRMTonerRequestCall item = new CCRMTonerRequestCall();
                        //_item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                  
                        item.PartNO = sqlDataReader["PartNO"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PartNO"]);
                        item.LastCallNo = sqlDataReader["LastCallNo"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["LastCallNo"]);
                        item.LastCallDate = sqlDataReader["LastCallDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LastCallDate"]);
                        item.LastQuantity = sqlDataReader["LastQuantity"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["LastQuantity"]);
                        item.LastMtrRead = sqlDataReader["LastMtrRead"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["LastMtrRead"]);
                       // item.ModelNo = sqlDataReader["ModelNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModelNo"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySale_SelectBillDetails' reported the ErrorCode: " + _errorCode);
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
