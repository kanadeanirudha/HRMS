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
    public class SalesQuotationMasterAndDetailsDataProvider : DBInteractionBase, ISalesQuotationMasterAndDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalesQuotationMasterAndDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalesQuotationMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from SalesQuotationMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetSalesQuotationMasterAndDetailsBySearch(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesQuotationMasterAndDetails_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<SalesQuotationMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesQuotationMasterAndDetails item = new SalesQuotationMasterAndDetails();

                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new Int32(): Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        item.ContactPersonID = sqlDataReader["ContactPersonID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ContactPersonID"]);
                        item.EnquiryNumber = sqlDataReader["EnquiryNumber"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["EnquiryNumber"]);
                        item.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        item.SalesQuotationMasterID = sqlDataReader["SalesQuotationMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalesQuotationMasterID"]);
                        item.QuotationNumber = sqlDataReader["QuotationNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["QuotationNumber"]);
                        item.Status = sqlDataReader["Status"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Status"]);
                        item.SalesEnquiryMasterID = sqlDataReader["SalesEnquiryMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalesEnquiryMasterID"]);
                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);


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
                        throw new Exception("Stored Procedure 'USP_SalesQuotationMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetSalesQuotationMasterAndDetailsSearchList(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesQuotationMasterAndDetails_GetListForDropDown";
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
                    baseEntityCollection.CollectionResponse = new List<SalesQuotationMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesQuotationMasterAndDetails item = new SalesQuotationMasterAndDetails();
                    //    item.ID = Convert.ToInt16(sqlDataReader["SalesQuotationMasterAndDetailsID"]);
                        // item.GroupDescription = sqlDataReader["GroupDescription"].ToString();
                        // item.MarchandiseGroupCode = Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesQuotationMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalesQuotationMasterAndDetails> GetSalesQuotationMasterAndDetailsByID(SalesQuotationMasterAndDetails item)
        {
            IBaseEntityResponse<SalesQuotationMasterAndDetails> response = new BaseEntityResponse<SalesQuotationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesQuotationMasterAndDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                  //  cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        SalesQuotationMasterAndDetails _item = new SalesQuotationMasterAndDetails();
                        ////_item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        //_item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        //_item.GeneralUnitTypeID = sqlDataReader["GeneralUnitTypeID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralUnitTypeID"].ToString());
                        //_item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        //_item.DepartmentID = sqlDataReader["DepartmentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        //_item.LocationAddress = sqlDataReader["LocationAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationAddress"]);
                        //_item.CityId = sqlDataReader["CityId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CityId"]);
                        //_item.UnitType = sqlDataReader["UnitType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitType"]);
                        //_item.Relatedwith = sqlDataReader["RelatedWith"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["RelatedWith"]);
                        //if (_item.Relatedwith == 1)
                        //{
                        //    _item.RelatedwithUnitType = "Manufacturing";
                        //}
                        //else if (_item.Relatedwith == 2)
                        //{
                        //    _item.RelatedwithUnitType = "Sales";
                        //}
                        //else if (_item.Relatedwith == 3)
                        //{
                        //    _item.RelatedwithUnitType = "Purchase";
                        //}
                        //else if (_item.Relatedwith == 4)
                        //{
                        //    _item.RelatedwithUnitType = "Warehouse";
                        //}
                        //else if (_item.Relatedwith == 5)
                        //{
                        //    _item.RelatedwithUnitType = "Processing";
                        //}
                        //_item.CentreName = sqlDataReader["CentreName"].ToString();
                        //_item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        //_item.CityName = sqlDataReader["CityName"].ToString();
                        //response.Entity = _item;
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
        public IBaseEntityResponse<SalesQuotationMasterAndDetails> InsertSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item)
        {
            IBaseEntityResponse<SalesQuotationMasterAndDetails> response = new BaseEntityResponse<SalesQuotationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesQuotationMasterAndDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iContactPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ContactPersonID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@siCreditPeriod", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreditPeriod));

                    if (item.UnitMasterId == null || item.UnitMasterId == "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriodUnit", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriodUnit", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.UnitMasterId));
                    }
                        if (item.TitleTo == null || item.TitleTo == "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTitleTo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,DBNull.Value ));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTitleTo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TitleTo));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@dTotalAmount", SqlDbType.Float, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalAmount));

                    if (item.SalesEnquiryMasterID == 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iSalesEnquiryMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iSalesEnquiryMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SalesEnquiryMasterID));
                    }



                    cmdToExecute.Parameters.Add(new SqlParameter("@dTotalBillAmount", SqlDbType.Float, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalBillAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dRoundOffAmount", SqlDbType.Float, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iQuotationmasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SalesQuotationMasterID));
                    if (item.XmlString != "" || item.XmlString != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xQuotationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XmlString));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xQuotationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));

                    //Addition to sales order
                    cmdToExecute.Parameters.Add(new SqlParameter("@dTotalTaxAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalTaxAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFreight", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Freight));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mShippingHandling", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ShippingHandling));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mDiscount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTradeIn", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Tradein));
                    if (item.PurchaseOrderNumberClient != "" || item.PurchaseOrderNumberClient != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumberClient", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PurchaseOrderNumberClient));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPurchaseOrderNumberClient", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Flag != "" || item.Flag != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFlag", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Flag));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFlag", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }


                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                   // item.SalesQuotationMasterID = (Int32)cmdToExecute.Parameters["@iQuotationmasterID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_SalesQuotationMasterAndDetails_Insert' reported the ErrorCode: " +
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
                        throw new Exception("Stored Procedure 'USP_SalesQuotationMasterAndDetails_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of SalesQuotationMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesQuotationMasterAndDetails> UpdateSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item)
        {
            IBaseEntityResponse<SalesQuotationMasterAndDetails> response = new BaseEntityResponse<SalesQuotationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesQuotationMasterAndDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.CustomerMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterName", SqlDbType.NVarChar, 60,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterCode", SqlDbType.NVarChar,20,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterCode));

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
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalesQuotationMasterAndDetails_Delete' reported the ErrorCode: " +
                                        _errorCode);
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
        /// <summary>
        /// Delete a specific record of SalesQuotationMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesQuotationMasterAndDetails> DeleteSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item)
        {
            IBaseEntityResponse<SalesQuotationMasterAndDetails> response = new BaseEntityResponse<SalesQuotationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesQuotationMasterAndDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Input, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.ID));
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesQuotationMasterAndDetails_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetQuotationMasterDetailsByEnquiryMaterID(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesQuotationMaster_GetDetailsByEnquiryMasterID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesEnquiryMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalesEnquiryMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesQuotationMasterAndDetails>();
                    decimal NetAmount = 0, TotalAmount = 0;
                    while (sqlDataReader.Read())
                    {
                        SalesQuotationMasterAndDetails item = new SalesQuotationMasterAndDetails();
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        item.ContactPersonID =sqlDataReader["ContactPersonID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ContactPersonID"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.EnquiryNumber = sqlDataReader["EnquiryNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EnquiryNumber"]);
                        item.SalesEnquiryMasterID = sqlDataReader["SalesEnquiryMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalesEnquiryMasterID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.UOM = sqlDataReader["UOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOM"]);
                        item.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        item.CustomerBranchMasterName = sqlDataReader["BranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchName"]);
                        item.ContactPersonName = sqlDataReader["ContactPersonName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContactPersonName"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Rate"]);
                        NetAmount = Math.Round((item.Quantity * item.Rate),2);
                        item.TaxableAmount = NetAmount;
                        item.TotalAmount = Math.Round(TotalAmount + NetAmount,2);
                        item.TaxRate= sqlDataReader["TaxRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.TaxAmount = sqlDataReader["ItemwiseTaxAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ItemwiseTaxAmount"]);
                        item.GeneralTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterId"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["GenTaxGroupMasterId"]);

                        


                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesQuotationMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetUomWiseSalesPrice(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetSalePriceByUOMCode";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUOM", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.UOM));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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
                    baseEntityCollection.CollectionResponse = new List<SalesQuotationMasterAndDetails>();
                    decimal NetAmount = 0;
                    while (sqlDataReader.Read())
                    {
                        SalesQuotationMasterAndDetails item = new SalesQuotationMasterAndDetails();
                        item.Rate = sqlDataReader["Rate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Rate"]);
                        item.NetAmount = NetAmount;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesQuotationMaster_GetDetailsByEnquiryMasterID' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetItemNumberSearchListForCustomer(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
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
                    if(searchRequest.IsServiceItem==true)
                    { 
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_SearchlistForServiceItemCustomerWithTax";
                    }
                    else
                    {
                        cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_SearchlistForCustomerWithTax";
                    }
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CustomerBranchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.NVarChar, 150, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<SalesQuotationMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesQuotationMasterAndDetails item = new SalesQuotationMasterAndDetails();
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ?string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? new decimal(): Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.GeneralTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterId"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["GenTaxGroupMasterId"]);
                        item.SerialAndBatchManagedBy = sqlDataReader["SerialAndBatchManagedBy"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["SerialAndBatchManagedBy"]);
                        item.TaxRateList = sqlDataReader["TaxRateList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxRateList"]);
                        item.TaxList = sqlDataReader["TaxList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxList"]);
                        item.PurchasePrice = sqlDataReader["PurchasePrice"] is DBNull ?new decimal() : Convert.ToDecimal(sqlDataReader["PurchasePrice"]);
                        item.PurchaseUoMCode = sqlDataReader["PurchaseUoMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PurchaseUoMCode"]);
                        item.ConversionFactor = sqlDataReader["ConversionFactor"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["ConversionFactor"]);
                        item.IsTaxExempted = sqlDataReader["IsTaxExempted"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["IsTaxExempted"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesQuotationMaster_GetDetailsByEnquiryMasterID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetQuotationMasterDetailsListByQuotationMasterID(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalesQuotationMaster_GetDetailsForQuotation";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalesQuotationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SalesQuotationMasterAndDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchaMsterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerBranchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));



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
                    baseEntityCollection.CollectionResponse = new List<SalesQuotationMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        SalesQuotationMasterAndDetails item = new SalesQuotationMasterAndDetails();

                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.ContactPersonID = sqlDataReader["ContactPersonID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ContactPersonID"]);
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        item.CreditPeriod = sqlDataReader["CreditPeriod"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CreditPeriod"]);
                        item.UnitMasterId = sqlDataReader["CreditPeriodUnit"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["CreditPeriodUnit"]);
                        item.SalesEnquiryMasterID = sqlDataReader["SalesEnquiryMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalesEnquiryMasterID"]);
                        item.TotalAmount = sqlDataReader["TotalAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalAmount"]);
                        item.TotalBillAmount = sqlDataReader["TotalBillAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TotalBillAmount"]);

                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.UOM = sqlDataReader["UOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOM"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.CustomerName = sqlDataReader["CustomerName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerName"]);
                        item.CustomerBranchMasterName = sqlDataReader["BranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchName"]);
                        item.ContactPersonName = sqlDataReader["ContactPersonName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContactPersonName"]);
                        item.TaxGroupName = sqlDataReader["TaxGroupName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxGroupName"]);
                        item.TitleTo = sqlDataReader["TitleTo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TitleTo"]);
                        item.Rate = sqlDataReader["Rate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Rate"]);

                        item.TaxableAmount = sqlDataReader["TaxableAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxableAmount"]);
                        item.TaxRate = sqlDataReader["TaxRate"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        item.TaxAmount = sqlDataReader["TaxAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["TaxAmount"]);
                        item.GeneralTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterId"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["GenTaxGroupMasterId"]);






                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalesQuotationMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        #endregion
    }
}
