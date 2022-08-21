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
    public class SalePromotionActivityMasterAndDetailsDataProvider : DBInteractionBase, ISalePromotionActivityMasterAndDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalePromotionActivityMasterAndDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalePromotionActivityMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from SalePromotionActivityMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionActivityMasterAndDetailsBySearch(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityMasterAndDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));


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
                    baseEntityCollection.CollectionResponse = new List<SalePromotionActivityMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionActivityMasterAndDetails item = new SalePromotionActivityMasterAndDetails();

                        //item.SalePromotionPlanID = sqlDataReader["SalePromotionPlanID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["SalePromotionPlanID"]);
                        item.SalePromotionActivityDetailsID = sqlDataReader["SalePromotionActivityDetailsID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["SalePromotionActivityDetailsID"]);
                        item.SalePromotionPlanDetailsID = sqlDataReader["SalePromotionPlanDetailsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalePromotionPlanDetailsID"]);
                        item.SalePromotionActivityMasterID = sqlDataReader["SalePromotionActivityMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalePromotionActivityMasterID"]);
                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        item.Name = sqlDataReader["ActivityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ActivityName"]);
                        item.FromDate = sqlDataReader["FromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromDate"]);
                        item.UptoDate = sqlDataReader["UptoDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UptoDate"]);
                        item.PlanTypeCode = sqlDataReader["PlanTypeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlanTypeCode"]);
                        item.PlanTypeName = sqlDataReader["PlanTypeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlanTypeName"]);
                        item.SubActivityName = sqlDataReader["SubActivityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubActivityName"]);
                        item.IsActivted = sqlDataReader["IsActivted"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsActivted"]);
                        item.ProductConcessionFreeType = sqlDataReader["ProductConcessionFreeType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ProductConcessionFreeType"]);

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
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionActivityMasterAndDetailsSearchList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityMasterAndDetails_GetListForDropDown";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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
                    baseEntityCollection.CollectionResponse = new List<SalePromotionActivityMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionActivityMasterAndDetails item = new SalePromotionActivityMasterAndDetails();
                        item.ID = Convert.ToInt16(sqlDataReader["SalePromotionActivityMasterAndDetailsID"]);
                        //item.GroupDescription = sqlDataReader["GroupDescription"].ToString();
                        //item.MarchandiseGroupCode = Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// <summary>
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionActivityMasterAndDetailsByID(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityMasterAndDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionActivityMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalePromotionActivityMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));
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
                        SalePromotionActivityMasterAndDetails _item = new SalePromotionActivityMasterAndDetails();

                        _item.SalePromotionActivityMasterID = sqlDataReader["SalePromotionActivityMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalePromotionActivityMasterID"]);
                        _item.FromDate = sqlDataReader["FromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromDate"]);
                        _item.UptoDate = sqlDataReader["UptoDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UptoDate"]);
                        _item.Name = sqlDataReader["Name"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Name"]);
                        _item.PlanTypeCode = sqlDataReader["PlanTypeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlanTypeCode"]);
                        _item.IsActivted = sqlDataReader["IsActive"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsActive"]);
                        _item.PromotionFor = sqlDataReader["PromotionalActivityFilter"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PromotionalActivityFilter"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
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
        /// <summary>
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionActivityMasterAndDetailsID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Output, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsName", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Name));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime,0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FromDate));
                    if (item.ProductConcessionFreeType != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiProductConcessionFreeType", SqlDbType.TinyInt, 4,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, item.ProductConcessionFreeType));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiProductConcessionFreeType", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false,10, 0, "",
                                            DataRowVersion.Proposed,0));
                    }
                   if(item.UptoDate != null)
                   {
                       cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.UptoDate));
                   }
                   else
                   {
                       cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.DateTime, 0,
                                          ParameterDirection.Input, false, 0, 0, "",
                                          DataRowVersion.Proposed, DBNull.Value));
                   }
                   if (item.PlanDescription != null)
                   {
                       cmdToExecute.Parameters.Add(new SqlParameter("@nsPlanDescriptionType", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PlanDescription));
                   }
                   else
                   {
                       cmdToExecute.Parameters.Add(new SqlParameter("@nsPlanDescriptionType", SqlDbType.NVarChar, 100,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                   }
                   cmdToExecute.Parameters.Add(new SqlParameter("@tiPromotionFor", SqlDbType.TinyInt, 4,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.PromotionFor));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPlanTypeCode", SqlDbType.NVarChar,50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PlanTypeCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siGeneralUnitsID", SqlDbType.SmallInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.GeneralUnitsID));

                    if (item.XMLstring!=null)
                    { 
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemWiseDiscountXML", SqlDbType.Xml, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.XMLstring));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsItemWiseDiscountXML", SqlDbType.Xml, 0,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, DBNull.Value));

                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionPlanDetailsID", SqlDbType.SmallInt, 4,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.SalePromotionPlanDetailsID));
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iSalePromotionActivityMasterAndDetailsID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_SalePromotionActivityMasterAndDetails_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_Insert' reported the ErrorCode: " +
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
        /// <summary>
        /// Update a specific record of SalePromotionActivityMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> UpdateSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionActivityMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SalePromotionActivityMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siGeneralUnitsID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                   
                    if(item.UptoDate != null)
                    {
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.UptoDate));
                    }
                    else
                    {
                      cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModifiedBy));
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
                    // item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalePromotionActivityMasterAndDetails_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    item.ErrorCode = (int)_errorCode;
                    response.Entity = item;
                    //if (_rowsAffected > 0)
                    //{
                        
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
        /// <summary>
        /// Delete a specific record of SalePromotionActivityMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> DeleteSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityMasterAndDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, 1));
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
                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_Delete' reported the ErrorCode: " + _errorCode);
                    }

                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
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

        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionActivityMasterAndDetailsRules(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityDetails_InsertXMLForFixedAmount";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiExternalFlag", SqlDbType.TinyInt, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ExternalFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCoupanOrGiftVoucherApplicable", SqlDbType.Bit, 0,
                                          ParameterDirection.Input, true, 0, 0, "",
                                          DataRowVersion.Proposed, item.IsCoupanOrGiftVoucherApplicable));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCommon", SqlDbType.Bit, 0,
                                          ParameterDirection.Input, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.IsCommon));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xSalePromotionActivityDetailsForFixedAmountXml", SqlDbType.Xml, 0,
                                          ParameterDirection.Input, false, 0, 0, "",
                                          DataRowVersion.Proposed, item.ParameterXmlForFixedData));
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iSalePromotionActivityMasterAndDetailsID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_SalePromotionActivityMasterAndDetails_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_Insert' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetPlanForFixedAmount(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityMaster_GetPlanForFixedAmount";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionActivityMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalePromotionActivityMasterID));

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
                    baseEntityCollection.CollectionResponse = new List<SalePromotionActivityMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionActivityMasterAndDetails item = new SalePromotionActivityMasterAndDetails();

                        item.SalePromotionPlanDetailsID = sqlDataReader["SalePromotionPlanDetailsID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["SalePromotionPlanDetailsID"]);
                        item.ID = sqlDataReader["SalePromotionPlanID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["SalePromotionPlanID"]);
                        item.SalePromotionActivityDetailsID = sqlDataReader["SalePromotionActivityDetailsID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["SalePromotionActivityDetailsID"]);
                        item.BillAmountRangeFrom = sqlDataReader["BillAmountRangeFrom"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillAmountRangeFrom"]);
                        item.BillAmountRangeUpto = sqlDataReader["BillAmountRangeUpto"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillAmountRangeUpto"]);
                        item.BillDiscountAmount = sqlDataReader["BillDiscountAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillDiscountAmount"]);
                        item.SalePromotionActivityDetailsID = sqlDataReader["SalePromotionActivityDetailsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalePromotionActivityDetailsID"]);

                        if (DBNull.Value.Equals(sqlDataReader["IsPercentage"]) == false)
                        {
                            item.IsPercentage = Convert.ToBoolean(sqlDataReader["IsPercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StatusFlag"]) == false)
                        {
                            item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsItemWiseDiscountExclude"]) == false)
                        {
                            item.IsItemWiseDiscountExclude = Convert.ToBoolean(sqlDataReader["IsItemWiseDiscountExclude"]);
                        }
                        item.PlanTypeName = sqlDataReader["PlanTypeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlanTypeName"]);
                        item.SubActivityName = sqlDataReader["SubActivityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubActivityName"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsCommon"]) == false)
                        {
                            item.IsCommon = Convert.ToBoolean(sqlDataReader["IsCommon"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCoupanOrGiftVoucherApplicable"]) == false)
                        {
                            item.IsCoupanOrGiftVoucherApplicable = Convert.ToBoolean(sqlDataReader["IsCoupanOrGiftVoucherApplicable"]);
                        }
                        item.ExternalFlag = sqlDataReader["ExternalFlag"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ExternalFlag"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                        
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetItemList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityMasterandDetails_GetPriceDiscountOnFixAmount";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionActivityMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));

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
                    baseEntityCollection.CollectionResponse = new List<SalePromotionActivityMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionActivityMasterAndDetails item = new SalePromotionActivityMasterAndDetails();

                        item.SalePromotionActivityDetailsID = sqlDataReader["SalePromotionActivityDetailsID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["SalePromotionActivityDetailsID"]);
                        item.PromotionActivityDiscounteItemListID = sqlDataReader["PromotionActivityDiscounteItemListID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["PromotionActivityDiscounteItemListID"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.InventoryVariationMasterID = sqlDataReader["InventoryVariationMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["InventoryVariationMasterID"]);
                        item.UOMCode = sqlDataReader["UOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOM"]);
                        item.DiscountInPercentage = sqlDataReader["DiscountInPercent"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DiscountInPercent"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.DiscountInPercentageForItemdetails = sqlDataReader["DiscountInPercent"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DiscountInPercent"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }


                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetFixAmountDetails(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityMasterandDetails_GetPriceDiscount";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionActivityMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionActivitydetailsID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalePromotionActivityDetailsID));

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
                    baseEntityCollection.CollectionResponse = new List<SalePromotionActivityMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionActivityMasterAndDetails item = new SalePromotionActivityMasterAndDetails();

                        item.Name = sqlDataReader["Name"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Name"]);
                        item.SalePromotionActivityMasterID = sqlDataReader["SalePromotionActivityMasterID"] is DBNull ? new short() : Convert.ToInt32(sqlDataReader["SalePromotionActivityMasterID"]);
                        item.SalePromotionPlanDetailsID = sqlDataReader["SalePromotionPlanDetailsID"] is DBNull ? new short() : Convert.ToInt32(sqlDataReader["SalePromotionPlanDetailsID"]);
                        item.BillAmountRangeFrom = sqlDataReader["BillAmountRangeFrom"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillAmountRangeFrom"]);
                        item.BillAmountRangeUpto = sqlDataReader["BillAmountRangeUpto"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillAmountRangeUpto"]);
                        item.BillDiscountAmount = sqlDataReader["BillDiscountAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillDiscountAmount"]);
                        item.PlanTypeName = sqlDataReader["PlanTypeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlanTypeName"]);
                        item.SubActivityName = sqlDataReader["SubActivityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubActivityName"]);
                        item.SalePromotionPlanID = sqlDataReader["SalePromotionPlanID"] is DBNull ? new short() : Convert.ToInt32(sqlDataReader["SalePromotionPlanID"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsPercentage"]) == false)
                        {
                            item.IsPercentage = Convert.ToBoolean(sqlDataReader["IsPercentage"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertItemDetails(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_PromotionActivityDiscounteItemList_UpdateXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if(item.ParameterXmlForItemDetails != null)
                    {
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemWiseDiscountDetailsXML", SqlDbType.Xml, 0,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.ParameterXmlForItemDetails));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsItemWiseDiscountDetailsXML", SqlDbType.Xml, 0,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PlanTypeCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsplanTypeCode", SqlDbType.NVarChar, 50,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, item.PlanTypeCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsplanTypeCode", SqlDbType.NVarChar, 50,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiProductConcessionFreeType", SqlDbType.TinyInt, 0,
                                         ParameterDirection.Input, false, 10, 0, "",
                                         DataRowVersion.Proposed, item.ProductConcessionFreeType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionActivityDetailsID", SqlDbType.Int, 4,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.SalePromotionActivityDetailsID));
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iSalePromotionActivityMasterAndDetailsID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_SalePromotionActivityMasterAndDetails_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_Insert' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetConcessionfreeItemsSearchList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_SearchListforConcessionFreeItems";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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
                    baseEntityCollection.CollectionResponse = new List<SalePromotionActivityMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionActivityMasterAndDetails item = new SalePromotionActivityMasterAndDetails();
                        item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.UOMCode = sqlDataReader["BaseUoMcode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUoMcode"]);
                        item.MenuDescription = sqlDataReader["MenuDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MenuDescription"]);
                        item.InventoryVariationMasterID = sqlDataReader["VariationMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["VariationMasterID"]);
                        

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSelectedItemFreeConcessionTypeList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityDetails_GetSelectedItemFreeConcessionTypeList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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
                    baseEntityCollection.CollectionResponse = new List<SalePromotionActivityMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionActivityMasterAndDetails item = new SalePromotionActivityMasterAndDetails();
                        item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.UOMCode = sqlDataReader["BaseUoMcode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUoMcode"]);
                        item.MenuDescription = sqlDataReader["MenuDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MenuDescription"]);
                        item.InventoryVariationMasterID = sqlDataReader["VariationMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["VariationMasterID"]);
                        item.SaleUOMCode = sqlDataReader["SaleUOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleUOMCode"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSelectedItemOfConcessionType(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityDetails_GetUpdatedItemListForFreeConsession";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionActivityDetailsID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SalePromotionActivityDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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
                    baseEntityCollection.CollectionResponse = new List<SalePromotionActivityMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionActivityMasterAndDetails item = new SalePromotionActivityMasterAndDetails();
                        item.GeneralItemMasterID = sqlDataReader["GeneralItemMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.UOMCode = sqlDataReader["BaseUoMcode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUoMcode"]);
                        item.MenuDescription = sqlDataReader["MenuDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MenuDescription"]);
                        item.InventoryVariationMasterID = sqlDataReader["VariationMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["VariationMasterID"]);
                        item.SaleUOMCode = sqlDataReader["SaleUOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SaleUOMCode"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        item.SalePromotionActivityDetailsID = sqlDataReader["SalePromotionActivityDetailsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalePromotionActivityDetailsID"]);
                        item.PromotionActivityDiscounteItemListID = sqlDataReader["PromotionActivityDiscounteItemListID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["PromotionActivityDiscounteItemListID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> UpdateSelectedItemOfConcessionType(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_PromotionActivityDiscounteItemList_UpdateXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //if (item.ParameterXmlForItemDetails != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemWiseDiscountDetailsXML", SqlDbType.Xml, 0,
                    //                          ParameterDirection.Input, false, 10, 0, "",
                    //                          DataRowVersion.Proposed, item.ParameterXmlForItemDetails));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemWiseDiscountDetailsXML", SqlDbType.Xml, 0,
                    //                       ParameterDirection.Input, false, 10, 0, "",
                    //                       DataRowVersion.Proposed, DBNull.Value));
                    //}
                   
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iSalePromotionActivityMasterAndDetailsID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_SalePromotionActivityMasterAndDetails_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_Insert' reported the ErrorCode: " +
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
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionGiftVocherDetails(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityDetails_InsertXMLForGiftVocher";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if (item.ParameterXmlForGiftVouchar != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSalePromotionActivityDetailsForGiftVoucherXml", SqlDbType.Xml, 0,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, item.ParameterXmlForGiftVouchar));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSalePromotionActivityDetailsForGiftVoucherXml", SqlDbType.Xml, 0,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                   
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iSalePromotionActivityMasterAndDetailsID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_SalePromotionActivityMasterAndDetails_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_Insert' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionGiftVocherDetails(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityMasterandDetails_GetGiftVoucherDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionActivityDetailID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalePromotionActivityDetailsID));

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
                    baseEntityCollection.CollectionResponse = new List<SalePromotionActivityMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionActivityMasterAndDetails item = new SalePromotionActivityMasterAndDetails();

                        item.SalePromotionGiftVoucharID = sqlDataReader["SalePromotionGiftVoucharID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["SalePromotionGiftVoucharID"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsPercentage"]) == false)
                        {
                            item.IsPercentage = Convert.ToBoolean(sqlDataReader["IsPercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsBillAmount"]) == false)
                        {
                            item.IsDiscountAmount = Convert.ToBoolean(sqlDataReader["IsBillAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsfreeItem"]) == false)
                        {
                            item.IsFreeItem = Convert.ToBoolean(sqlDataReader["IsfreeItem"]);
                        }
                        item.DiscountInPercentage = sqlDataReader["DiscountPercentage"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DiscountPercentage"]);
                        item.BillDiscountAmount = sqlDataReader["GiftAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["GiftAmount"]);

                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.InventoryVariationMasterID = sqlDataReader["InventoryVariationMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["InventoryVariationMasterID"]);
                        item.UOMCode = sqlDataReader["UomCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UomCode"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        item.BillAmountRangeFrom = sqlDataReader["BillAmountRangeFrom"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillAmountRangeFrom"]);
                        item.BillAmountRangeUpto = sqlDataReader["BillAmountRangeUpto"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillAmountRangeUpto"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Quantity"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalePromotionActivityMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> DeletePromotionActivityDiscounteItemList(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_PromotionActivityDiscounteItemList_DeleteItemWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, 1));
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryStockAdjustment_Delete' reported the ErrorCode: " + _errorCode);
                    }

                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
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
