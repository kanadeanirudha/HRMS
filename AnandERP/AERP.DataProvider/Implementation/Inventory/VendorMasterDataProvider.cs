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
    public class VendorMasterDataProvider : DBInteractionBase, IVendorMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public VendorMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public VendorMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from VendorMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<VendorMaster> GetVendorMasterBySearch(VendorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<VendorMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    //   cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));

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
                    baseEntityCollection.CollectionResponse = new List<VendorMaster>();
                    while (sqlDataReader.Read())
                    {
                        VendorMaster item = new VendorMaster();

                        item.ID = sqlDataReader["VendorMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["VendorMasterID"]);
                        //item.MovementType = sqlDataReader["MovementType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MovementType"]);
                        //item.MovementCode = sqlDataReader["MovementCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MovementCode"]);
                        //if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        //{
                        //    item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        //}
                        //item.MovementTypeRulesID = sqlDataReader["MovementTypeRulesID"] is DBNull ? new int() : Convert.ToInt16(sqlDataReader["MovementTypeRulesID"]);
                        //item.MovementTypeID = sqlDataReader["MovementTypeID"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["MovementTypeID"]);
                        //item.TransactionType = sqlDataReader["TransactionType"] is DBNull ? new int() : Convert.ToInt16(sqlDataReader["TransactionType"]);
                        //item.Direction = sqlDataReader["Direction"] is DBNull ? new int() : Convert.ToInt16(sqlDataReader["Direction"]);
                        //item.Behaviour = sqlDataReader["RequisitionBehaviour"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RequisitionBehaviour"]);

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
                        throw new Exception("Stored Procedure 'USP_VendorMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<VendorMaster> GetVendorMasterSearchList(VendorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<VendorMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<VendorMaster>();
                    while (sqlDataReader.Read())
                    {
                        VendorMaster item = new VendorMaster();
                        item.ID = Convert.ToInt16(sqlDataReader["GenSupplierMasterID"]);
                        item.VendorName = sqlDataReader["Vender"].ToString();
                        item.VendorNumber = sqlDataReader["VendorNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorNumber"]);
                        item.Address1 = sqlDataReader["AddressFirst"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AddressFirst"]);
                        item.Address2 = sqlDataReader["AddressSecond"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AddressSecond"]);
                        item.Address3 = sqlDataReader["AddressThird"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AddressThird"]);
                        item.FirstName = sqlDataReader["FirstName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FirstName"]);
                        item.MiddleName = sqlDataReader["MiddleName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MiddleName"]);
                        item.LastName = sqlDataReader["LastName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LastName"]);
                        //item.PinCode = Convert.ToInt16(sqlDataReader["PinCode"]);
                        //item.CityId = Convert.ToInt16(sqlDataReader["CityId"]);
                        item.PinCode = sqlDataReader["PinCode"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PinCode"]);
                        item.CityId = sqlDataReader["CityId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CityId"]);
                        item.City = sqlDataReader["CityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CityName"]);
                        item.MobileNumber = sqlDataReader["CellPhoneNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CellPhoneNumber"]);
                        item.PhoneNumber = sqlDataReader["PhoneNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PhoneNumber"]);
                        item.Country = sqlDataReader["Country"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Country"]);
                        item.Currency = sqlDataReader["Currency"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Currency"]);
                        item.State = sqlDataReader["State"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["State"]);
                        item.VendorCode = sqlDataReader["VendorCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorCode"]);
                        //if (DBNull.Value.Equals(sqlDataReader["ReturnGoods"]) == false)
                        //{
                        //    item.ReturnGoods = Convert.ToBoolean(sqlDataReader["ReturnGoods"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_VendorMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<VendorMaster> GetVendorMasterByID(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> response = new BaseEntityResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_SelectOne";
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
                        VendorMaster _item = new VendorMaster();
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
        public IBaseEntityResponse<VendorMaster> InsertVendorMaster(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> response = new BaseEntityResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGenSupplierMasterID", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, item.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsVendorName", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.VendorName));

                    if (item.FirstName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstname", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FirstName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstname", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MiddleName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MiddleName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.LastName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@csex", SqlDbType.Char, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    if (item.Address1 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address1));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Address2 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address2));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Address3 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address3));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PhoneNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PhoneNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.MobileNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCellPhoneNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MobileNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCellPhoneNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTahsilID", SqlDbType.Int, 5, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsResiPhoneNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bReturnGoods", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ReturnGoods));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFaxNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmail", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsWebUrl", SqlDbType.Int, 5, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsVenderDescription", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCategoryId", SqlDbType.Int, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountId", SqlDbType.Int, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0));
                    if (item.Country != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siCountry", SqlDbType.TinyInt, 5, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Country));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siCountry", SqlDbType.TinyInt, 5, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0));
                    }

                    if (item.Currency != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCurrency", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Currency));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCurrency", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.State != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiState", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.State));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiState", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTaskcode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TaskCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsVAT", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCST", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsExcise", SqlDbType.Int, 5, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStablishmentNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorNumber", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, item.VendorNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPinCode", SqlDbType.Int, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PinCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityId", SqlDbType.Int, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CityId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRefNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    if (item.XMLstring != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xmlstringForGeneralData", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xmlstringForGeneralData", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstring1 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xmlstringForReplenishmentData", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring1));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xmlstringForReplenishmentData", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@mVendorrestriction", SqlDbType.Money, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.VendorRestriction));
                    //****************Finance tab fields******************//
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorFinanceDetailsID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.VendorFinanceDetailsID));
                    if (item.BankAddress != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BankAddress));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.BankName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BankName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.BranchName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BranchName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CreditLimit != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCreditLimit", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreditLimit));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCreditLimit", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Incoterms != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIncoterms", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Incoterms));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIncoterms", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.IFSCCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFSCCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IFSCCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFSCCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.AccountNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAccountNo", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AccountNo));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAccountNo", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@fCashDiscount", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CashDiscount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fRebate", SqlDbType.Float, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Rebate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bCashOnDelivery", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CashOnDelivery));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bCurrentDatedCheque", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CurrentDatedCheque));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bCredit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Credit));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCentre", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsCentre));

                    if (item.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iVendorMasterID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.VendorNumber = Convert.ToInt32(cmdToExecute.Parameters["@iVendorNumber"].Value);
                    item.ID = Convert.ToInt32(cmdToExecute.Parameters["@iGenSupplierMasterID"].Value);

                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_VendorMaster_Insert' reported the ErrorCode: " +
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
                        throw new Exception("Stored Procedure 'USP_VendorMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of VendorMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<VendorMaster> UpdateVendorMaster(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> response = new BaseEntityResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
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
                        throw new Exception("Stored Procedure 'dbo.USP_VendorMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of VendorMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<VendorMaster> DeleteVendorMaster(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> response = new BaseEntityResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralVendorID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.errorMessage));
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
                    item.errorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry && _errorCode != 77)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_VendorMaster_Delete' reported the ErrorCode: " + _errorCode);
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



        public IBaseEntityResponse<VendorMaster> InsertVendorMasterExcel(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> response = new BaseEntityResponse<VendorMaster>();
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
                    cmdToExecute.CommandTimeout = 0;
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iVendorMasterRulesID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Output, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.MovementTypeRulesID));


                    if (item.XMLstring != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.XMLstringForReplenishmentInfo1 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorReplenishmentInfo1XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForReplenishmentInfo1));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorReplenishmentInfo1XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.XMLstringForReplenishmentInfo2 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorReplenishmentInfo2XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForReplenishmentInfo2));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorReplenishmentInfo2XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.XMLstringForReplenishmentInfo3 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorReplenishmentInfo3XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForReplenishmentInfo3));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorReplenishmentInfo3XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.XMLstringForContactPerson1 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorContactPerson1XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForContactPerson1));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorContactPerson1XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForContactPerson2 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorContactPerson2XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForContactPerson2));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorContactPerson2XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.XMLstringForContactPerson3 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorContactPerson3XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstringForContactPerson3));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xVendorContactPerson3XML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.errorMessage));
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
                    item.errorMessage = (string)cmdToExecute.Parameters["@sErrorMessage"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry && _errorCode != 18)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralItemMaster_Delete' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<VendorMaster> GetGeneralDataByVendorNumber(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> response = new BaseEntityResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_GetGeneralDataByVendorNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.VendorID));
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
                        VendorMaster _item = new VendorMaster();
                        // _item.ID = Convert.ToInt16(sqlDataReader["GenSupplierMasterID"]);
                        _item.VendorName = sqlDataReader["Vender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vender"]);
                        _item.VendorID = sqlDataReader["GenSupplierMasterID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["GenSupplierMasterID"]);
                        _item.VendorNumber = sqlDataReader["VendorNumber"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["VendorNumber"]);
                        _item.Address1 = sqlDataReader["AddressFirst"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AddressFirst"]);
                        _item.Address2 = sqlDataReader["AddressSecond"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AddressSecond"]);
                        _item.Address3 = sqlDataReader["AddressThird"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AddressThird"]);
                        _item.PhoneNumber = sqlDataReader["PhoneNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PhoneNumber"]);
                        _item.MobileNumber = sqlDataReader["CellPhoneNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CellPhoneNumber"]);
                        _item.Currency = sqlDataReader["Currency"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Currency"]);
                        _item.Country = sqlDataReader["Country"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Country"]);
                        _item.FirstName = sqlDataReader["FirstName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FirstName"]);
                        _item.MiddleName = sqlDataReader["MiddleName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MiddleName"]);
                        _item.LastName = sqlDataReader["LastName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LastName"]);
                        _item.PinCode = sqlDataReader["PinCode"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["PinCode"]);
                        _item.CityId = sqlDataReader["CityId"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["CityId"]);
                        _item.City = sqlDataReader["CityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CityName"]);
                        _item.State = sqlDataReader["State"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["State"]);
                        _item.VendorCode = sqlDataReader["VendorCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["VendorCode"]);
                        _item.IsCentre = sqlDataReader["IsCentre"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsCentre"]);
                        _item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        //if (DBNull.Value.Equals(sqlDataReader["ReturnGoods"]) == false)
                        //{
                        //    _item.ReturnGoods = Convert.ToBoolean(sqlDataReader["ReturnGoods"]);
                        //}
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


        public IBaseEntityCollectionResponse<VendorMaster> GetContactPersonDetailsForVendorMaster(VendorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<VendorMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_GetContactPersonDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.VendorID));
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
                    baseEntityCollection.CollectionResponse = new List<VendorMaster>();
                    while (sqlDataReader.Read())
                    {
                        VendorMaster item = new VendorMaster();

                        item.VendorContactPersoninfoID = sqlDataReader["VendorID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["VendorContactPersoninfoID"]);
                        item.VendorID = sqlDataReader["VendorID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["VendorID"]);
                        item.CPFirstName = sqlDataReader["ContactPersonFirstName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContactPersonFirstName"]);
                        item.ContactPersonMobNumber = sqlDataReader["ContactPersonMobNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContactPersonMobNo"]);
                        item.EmailID = sqlDataReader["ContactPersonEmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContactPersonEmailID"]);
                        item.PersonDesgDesc = sqlDataReader["Designation"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Designation"]);
                        item.CPMiddleName = sqlDataReader["ContactPersonMiddleName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContactPersonMiddleName"]);
                        item.CPLastName = sqlDataReader["ContactPersonLastName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContactPersonLastName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_VendorMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<VendorMaster> GetReplenishmentDataByVendorNumber(VendorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<VendorMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_GetReplenishmentDataByVendorNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.VendorID));
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
                    baseEntityCollection.CollectionResponse = new List<VendorMaster>();
                    while (sqlDataReader.Read())
                    {
                        VendorMaster item = new VendorMaster();
                        item.VendorReplenishmentInfoID = Convert.ToInt16(sqlDataReader["VendorReplenishmentInfoID"]);
                        item.VendorID = sqlDataReader["VendorID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["VendorID"]);
                        item.MerchandiseCategory = sqlDataReader["CategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CategoryCode"]);
                        item.LeadTime = sqlDataReader["LeadTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LeadTime"]);
                        item.Currency = sqlDataReader["Currency"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Currency"]);
                        item.VendorRestriction = sqlDataReader["VendorRestriction"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["VendorRestriction"]);
                        if (DBNull.Value.Equals(sqlDataReader["ReturnGoods"]) == false)
                        {
                            item.ReturnGoods = Convert.ToBoolean(sqlDataReader["ReturnGoods"]);
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
                        throw new Exception("Stored Procedure 'USP_VendorMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<VendorMaster> GetLeadTimeByVendorID(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> response = new BaseEntityResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemmaster_GetLeadTimeBySupplierID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.VendorID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemNumber));
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
                        VendorMaster _item = new VendorMaster();
                        // _item.ID = Convert.ToInt16(sqlDataReader["GenSupplierMasterID"]);
                        _item.MerchandiseCategory = sqlDataReader["CategoryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CategoryCode"]);
                        _item.LeadTime = sqlDataReader["LeadTime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LeadTime"]);
                        _item.Currency = sqlDataReader["Currency"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Currency"]);
                        _item.VendorNumber = sqlDataReader["VendorNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VendorNumber"]);
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

        public IBaseEntityResponse<VendorMaster> GetFinanceDataByVendorNumber(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> response = new BaseEntityResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_GetFinanceDataByVendorNumber";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.VendorID));
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
                        VendorMaster _item = new VendorMaster();
                        _item.VendorFinanceDetailsID = Convert.ToInt32(sqlDataReader["VendorFinanceDetailsID"]);
                        _item.VendorID = sqlDataReader["VendorID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["VendorID"]);
                        _item.CreditLimit = sqlDataReader["CreditLimit"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CreditLimit"]);
                        _item.BankAddress = sqlDataReader["BankAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankAddress"]);
                        _item.IFSCCode = sqlDataReader["IFSCCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["IFSCCode"]);
                        _item.BranchName = sqlDataReader["BranchName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchName"]);
                        _item.BankName = sqlDataReader["BankName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BankName"]);
                        _item.IFSCCode = sqlDataReader["IFSCCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["IFSCCode"]);
                        _item.Incoterms = sqlDataReader["Incoterms"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Incoterms"]);
                        _item.AccountNo = sqlDataReader["AccountNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AccountNo"]);
                        _item.Rebate = sqlDataReader["RebatePercent"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["RebatePercent"]);
                        _item.CashDiscount = sqlDataReader["CashDiscount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CashDiscount"]);
                        _item.CashOnDelivery = sqlDataReader["CashOnDelivery"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["CashOnDelivery"]);
                        _item.Credit = sqlDataReader["Credit"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["Credit"]);
                        _item.CurrentDatedCheque = sqlDataReader["CurrentDatedCheque"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["CurrentDatedCheque"]);

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

        public IBaseEntityResponse<VendorMaster> GetDataValidationListsForExcel(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> response = new BaseEntityResponse<VendorMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_GetDataValidationListsForExcel";
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
                    while (sqlDataReader.Read())
                    {
                        VendorMaster _item = new VendorMaster();
                        _item.CountryList = sqlDataReader["CountryList"].ToString();
                        _item.CityList = sqlDataReader["CityList"].ToString();
                        _item.CurrencyList = sqlDataReader["CurrencyList"].ToString();
                        _item.CategoryList = sqlDataReader["CategoryList"].ToString();

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


        #endregion
    }
}
