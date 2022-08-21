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
  public  class CCRMMachineMasterDataProvider :DBInteractionBase, ICCRMMachineMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion
        #region Constructor
        public CCRMMachineMasterDataProvider()
        {
        }
        public CCRMMachineMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion
        public IBaseEntityResponse<CCRMMachineMaster> InsertCCRMMachineMaster(CCRMMachineMaster item)
        {
            IBaseEntityResponse<CCRMMachineMaster> response = new BaseEntityResponse<CCRMMachineMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMachineMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMachineFamilyMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MachineFamilyMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMachineType", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MachineType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiColorMono", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ColorMono));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsPaperSize", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PaperSize.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiWarrenty", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Warrenty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fLifeInYears", SqlDbType.Float, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LifeInYears));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@nslifeInCopies", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.lifeInCopies.Trim()));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsPMPeriods", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PMPeriods.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsreturnable", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Isreturnable));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiFrequency", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Frequency));


                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));


                    if (item.PaperSize != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPaperSize", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaperSize.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPaperSize", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }

                    if (item.lifeInCopies != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nslifeInCopies", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.lifeInCopies.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nslifeInCopies", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.PMPeriods != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPMPeriods", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PMPeriods.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPMPeriods", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

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
                        throw new Exception("Stored Procedure 'USP_CCRMMachineMaster_Insert' reported the ErrorCode: " +
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
        public IBaseEntityResponse<CCRMMachineMaster> UpdateCCRMMachineMaster(CCRMMachineMaster item)
        {
            IBaseEntityResponse<CCRMMachineMaster> response = new BaseEntityResponse<CCRMMachineMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMachineMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMachineFamilyMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MachineFamilyMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMachineType", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.MachineType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiColorMono", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ColorMono));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPaperSize", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaperSize.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiWarrenty", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Warrenty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fLifeInYears", SqlDbType.Float, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LifeInYears));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nslifeInCopies", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.lifeInCopies.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPMPeriods", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PMPeriods.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsreturnable", SqlDbType.Bit, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Isreturnable));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiFrequency", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Frequency));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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

                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMMachineMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMMachineMaster> GetCCRMMachineMasterByID(CCRMMachineMaster item)
        {
            IBaseEntityResponse<CCRMMachineMaster> response = new BaseEntityResponse<CCRMMachineMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMachineMaster_SelectOne";
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
                        CCRMMachineMaster _item = new CCRMMachineMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        _item.MachineFamilyMasterID = Convert.ToInt32(sqlDataReader["MachineFamilyMasterID"]);
                        _item.MachineType = Convert.ToByte(sqlDataReader["MachineType"]);
                        _item.ColorMono = Convert.ToByte(sqlDataReader["ColorMono"]);
                        _item.PaperSize = sqlDataReader["PaperSize"].ToString();
                        _item.Warrenty = Convert.ToByte(sqlDataReader["Warrenty"]);
                        _item.LifeInYears = Convert.ToDecimal(sqlDataReader["LifeInYears"]);
                        _item.lifeInCopies = sqlDataReader["lifeInCopies"].ToString();
                        _item.PMPeriods = sqlDataReader["PMPeriods"].ToString();
                        _item.Isreturnable = Convert.ToBoolean(sqlDataReader["Isreturnable"]);
                        _item.Frequency = Convert.ToByte(sqlDataReader["Frequency"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMMachineMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMMachineMaster> GetCCRMMachineMasterBySearch(CCRMMachineMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMachineMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMMachineMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMachineMaster_SelectAll";
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

                    baseEntityCollection.CollectionResponse = new List<CCRMMachineMaster>();
                    while (sqlDataReader.Read())
                    {
                        CCRMMachineMaster item = new CCRMMachineMaster();
                        item.ID = sqlDataReader["ID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["ID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);

                        item.MachineFamilyMasterID = sqlDataReader["MachineFamilyMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["MachineFamilyMasterID"]);
                        item.MachineFamilyName = sqlDataReader["MachineFamilyName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MachineFamilyName"]);
                        item.MachineType = sqlDataReader["MachineType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["MachineType"]);
                        item.ColorMono = sqlDataReader["ColorMono"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ColorMono"]);
                        item.PaperSize = sqlDataReader["PaperSize"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PaperSize"]);
                        item.Warrenty = sqlDataReader["Warrenty"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Warrenty"]);
                        item.LifeInYears = sqlDataReader["LifeInYears"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["LifeInYears"]);
                        item.lifeInCopies = sqlDataReader["lifeInCopies"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["lifeInCopies"]);
                        item.PMPeriods = sqlDataReader["PMPeriods"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PMPeriods"]);
                        item.Isreturnable = sqlDataReader["Isreturnable"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["Isreturnable"]);
                        item.Frequency = sqlDataReader["Frequency"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Frequency"]);

                    
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
                        throw new Exception("Stored Procedure 'USP_CCRMMachineMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
