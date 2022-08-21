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
   public class CCRMMIFMasterAndDetailsDataProvider : DBInteractionBase, ICCRMMIFMasterAndDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        public CCRMMIFMasterAndDetailsDataProvider()
        {
        }
        public CCRMMIFMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFMasterAndDetailsBySearch(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMIFMasterAndDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //---------------- INPUT PARAMETER--------------------//
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                                     
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
                    baseEntityCollection.CollectionResponse = new List<CCRMMIFMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        CCRMMIFMasterAndDetails item = new CCRMMIFMasterAndDetails();

                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.MIFTitle = sqlDataReader["MIFTitle"].ToString();
                        item.MIFAddress = sqlDataReader["MIFAddress"].ToString();
                        item.MIFType = Convert.ToByte(sqlDataReader["MIFType"]);
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
                        throw new Exception("Stored Procedure 'USP_CCRMMIFMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMMIFMasterAndDetails> GetCCRMMIFMasterAndDetailsByID(CCRMMIFMasterAndDetails item)
        {
            IBaseEntityResponse<CCRMMIFMasterAndDetails> response = new BaseEntityResponse<CCRMMIFMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMIFMasterAndDetails_SelectOne";
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
                        CCRMMIFMasterAndDetails _item = new CCRMMIFMasterAndDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        
                        _item.InstallationDate = Convert.ToString(sqlDataReader["InstallationDate"]);
                        _item.CustomerCode = sqlDataReader["CustomerCode"].ToString();
                        _item.CustomerMasterID = Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        _item.CustomerMasterName = sqlDataReader["CustomerMasterName"].ToString();
                        _item.CustomerAddress = sqlDataReader["CustomerAddress"].ToString();
                        _item.CustomerPinCode = sqlDataReader["CustomerPinCode"].ToString();
                        _item.CutomerSegementMasterID = Convert.ToByte(sqlDataReader["CutomerSegementMasterID"]);
                        _item.MIFTitle = sqlDataReader["MIFTitle"].ToString();
                        _item.MIFAddress = sqlDataReader["MIFAddress"].ToString();
                        _item.MIFPinCode = sqlDataReader["MIFPinCode"].ToString();
                        _item.FolioNo = sqlDataReader["FolioNo"].ToString();
                        _item.BillTitle = sqlDataReader["BillTitle"].ToString();
                        _item.BillAddress = sqlDataReader["BillAddress"].ToString();
                        _item.ModelNo = sqlDataReader["ModelNo"].ToString();
                        _item.SerialNo = sqlDataReader["SerialNo"].ToString();
                        _item.MIFType = Convert.ToByte(sqlDataReader["MIFType"]);
                        _item.MachineFamilyID = Convert.ToInt16(sqlDataReader["MachineFamilyID"]);
                        _item.CCRMEngineersGroupMasterID = Convert.ToInt32(sqlDataReader["CCRMEngineersGroupMasterID"]);
                        _item.CCRMAreaPatchMasterID = Convert.ToInt16(sqlDataReader["CCRMAreaPatchMasterID"]);
                        _item.CountryID = Convert.ToInt16(sqlDataReader["CountryID"]);
                        _item.StateID = Convert.ToInt16(sqlDataReader["StateID"]);
                        _item.CityID = Convert.ToInt16(sqlDataReader["CityID"]);
                        _item.Category = Convert.ToByte(sqlDataReader["Category"]);
                        _item.CCRMLocationTypeID = Convert.ToInt32(sqlDataReader["CCRMLocationTypeID"]);
                        _item.Priority = Convert.ToByte(sqlDataReader["Priority"]);
                        _item.InstalledById = Convert.ToInt32(sqlDataReader["InstalledById"]);
                        _item.ServiceEngID = Convert.ToInt32(sqlDataReader["ServiceEngID"]);
                        _item.CollExecId = Convert.ToInt32(sqlDataReader["CollExecId"]);
                        _item.ISPrinter = Convert.ToByte(sqlDataReader["ISPrinter"]);
                        _item.ISScanner = Convert.ToByte(sqlDataReader["ISScanner"]);
                        _item.ISFax = Convert.ToByte(sqlDataReader["ISFax"]);
                        _item.Others = sqlDataReader["Others"].ToString();
                        _item.WarantyInDays = Convert.ToInt32(sqlDataReader["WarantyInDays"]);
                      //  _item.WarantyExpiryDate = sqlDataReader["WarantyExpiryDate"].ToString();
                        _item.WarantyExpiryDate = Convert.ToString(sqlDataReader["WarantyExpiryDate"]);
                        _item.Status = Convert.ToByte(sqlDataReader["Status"]);
                        _item.InactiveDate = Convert.ToString(sqlDataReader["InactiveDate"]);
                        _item.Remarks = sqlDataReader["Remarks"].ToString();
                        _item.EmailCorporate = sqlDataReader["EmailCorporate"].ToString();
                        _item.EmailAccounts = sqlDataReader["EmailAccounts"].ToString();
                        _item.Emailservices = sqlDataReader["EmailServices"].ToString();
                        _item.KeyOperatorName = sqlDataReader["KeyOperatorName"].ToString();
                        _item.PhoneNo = sqlDataReader["PhoneNo"].ToString();
                        _item.MobileNo = sqlDataReader["MobileNo"].ToString();
                        _item.AreaPatchName = sqlDataReader["AreaPatchName"].ToString();
                        _item.ItemDescription = sqlDataReader["ItemDescription"].ToString();
                        _item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        _item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        _item.RightName = sqlDataReader["RightName"].ToString();
                        _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        _item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        _item.EmployeeName = sqlDataReader["EmployeeName"].ToString();
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
        public IBaseEntityResponse<CCRMMIFMasterAndDetails> InsertCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item)
        {
            IBaseEntityResponse<CCRMMIFMasterAndDetails> response = new BaseEntityResponse<CCRMMIFMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMIFMasterAndDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMMIFMasterAndDetailsID", SqlDbType.Int, 4,
                                           ParameterDirection.Output, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsInstallationDate", SqlDbType.NVarChar, 35,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, item.InstallationDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerCode", SqlDbType.NVarChar, 50,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.CustomerCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.CustomerMasterID));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCutomerSegementMasterID", SqlDbType.TinyInt, 4,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.CutomerSegementMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFTitle", SqlDbType.NVarChar, 100,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.MIFTitle));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFAddress", SqlDbType.NVarChar, 2000,
                                       ParameterDirection.Input, false, 10, 0, "",
                                       DataRowVersion.Proposed, item.MIFAddress));
                  
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBillTitle", SqlDbType.NVarChar, 200,
                                 ParameterDirection.Input, false, 10, 0, "",
                                 DataRowVersion.Proposed, item.BillTitle));
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsModelNo", SqlDbType.NVarChar, 200,
                             ParameterDirection.Input, false, 10, 0, "",
                             DataRowVersion.Proposed, item.ModelNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50,
                           ParameterDirection.Input, false, 10, 0, "",
                           DataRowVersion.Proposed, item.SerialNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMIFType", SqlDbType.TinyInt, 4,
                         ParameterDirection.Input, false, 10, 0, "",
                         DataRowVersion.Proposed, item.MIFType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMachineFamilyID", SqlDbType.SmallInt, 4,
                        ParameterDirection.Input, false, 10, 0, "",
                        DataRowVersion.Proposed, item.MachineFamilyID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMEngineersGroupMasterID", SqlDbType.Int, 4,
                        ParameterDirection.Input, false, 10, 0, "",
                        DataRowVersion.Proposed, item.CCRMEngineersGroupMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCCRMAreaPatchMasterID", SqlDbType.SmallInt, 4,
                      ParameterDirection.Input, false, 10, 0, "",
                      DataRowVersion.Proposed, item.CCRMAreaPatchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCountryID", SqlDbType.SmallInt, 4,
                      ParameterDirection.Input, false, 10, 0, "",
                      DataRowVersion.Proposed, item.CountryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siStateID", SqlDbType.SmallInt, 4,
                      ParameterDirection.Input, false, 10, 0, "",
                      DataRowVersion.Proposed, item.StateID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCityID", SqlDbType.SmallInt, 4,
                      ParameterDirection.Input, false, 10, 0, "",
                      DataRowVersion.Proposed, item.CityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCategory", SqlDbType.TinyInt, 4,
                   ParameterDirection.Input, false, 10, 0, "",
                   DataRowVersion.Proposed, item.Category));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMLocationTypeID", SqlDbType.Int, 4,
                      ParameterDirection.Input, false, 10, 0, "",
                      DataRowVersion.Proposed, item.CCRMLocationTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPriority", SqlDbType.TinyInt, 4,
                    ParameterDirection.Input, false, 10, 0, "",
                    DataRowVersion.Proposed, item.Priority));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInstalledById", SqlDbType.Int, 4,
                    ParameterDirection.Input, false, 10, 0, "",
                    DataRowVersion.Proposed, item.InstalledById));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iServiceEngID", SqlDbType.Int, 4,
                    ParameterDirection.Input, false, 10, 0, "",
                    DataRowVersion.Proposed, item.ServiceEngID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCollExecId ", SqlDbType.Int, 4,
                   ParameterDirection.Input, false, 10, 0, "",
                   DataRowVersion.Proposed, item.CollExecId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiISPrinter ", SqlDbType.TinyInt, 4,
                  ParameterDirection.Input, false, 10, 0, "",
                  DataRowVersion.Proposed, item.ISPrinter));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiISScanner ", SqlDbType.TinyInt, 4,
                 ParameterDirection.Input, false, 10, 0, "",
                 DataRowVersion.Proposed, item.ISScanner));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiISFax ", SqlDbType.TinyInt, 4,
                 ParameterDirection.Input, false, 10, 0, "",
                 DataRowVersion.Proposed, item.ISFax));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@iWarantyInDays ", SqlDbType.Int, 4,
                 ParameterDirection.Input, false, 10, 0, "",
                 DataRowVersion.Proposed, item.WarantyInDays));
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiStatus ", SqlDbType.TinyInt, 4,
                ParameterDirection.Input, false, 10, 0, "",
                DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsKeyOperatorName ", SqlDbType.NVarChar, 100,
                            ParameterDirection.Input, false, 10, 0, "",
                            DataRowVersion.Proposed, item.KeyOperatorName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneNo", SqlDbType.NVarChar, 100,
                          ParameterDirection.Input, false, 10, 0, "",
                          DataRowVersion.Proposed, item.PhoneNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNo", SqlDbType.NVarChar, 100,
                         ParameterDirection.Input, false, 10, 0, "",
                         DataRowVersion.Proposed, item.MobileNo));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                           ParameterDirection.Input, true, 10, 0, "",
                                           DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

                    if (item.CustomerAddress != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerAddress ", SqlDbType.NVarChar, 2000,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.CustomerAddress));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerAddress", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.CustomerPinCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerPinCode", SqlDbType.NVarChar, 10,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.CustomerPinCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerPinCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.FolioNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFolioNo", SqlDbType.NVarChar, 50,
                                  ParameterDirection.Input, false, 10, 0, "",
                                  DataRowVersion.Proposed, item.FolioNo));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFolioNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.MIFPinCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFPinCode", SqlDbType.NVarChar, 10,
                                  ParameterDirection.Input, false, 10, 0, "",
                                  DataRowVersion.Proposed, item.MIFPinCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFPinCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.BillAddress != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBillAddress", SqlDbType.NVarChar, 2000,
                               ParameterDirection.Input, false, 10, 0, "",
                               DataRowVersion.Proposed, item.BillAddress));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBillAddress", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Others != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOthers ", SqlDbType.NVarChar, 100,
                 ParameterDirection.Input, false, 10, 0, "",
                 DataRowVersion.Proposed, item.Others));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOthers", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Remarks != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks ", SqlDbType.NVarChar, 2000,
               ParameterDirection.Input, false, 10, 0, "",
               DataRowVersion.Proposed, item.Remarks));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.EmailCorporate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailCorporate ", SqlDbType.NVarChar, 200,
                ParameterDirection.Input, false, 10, 0, "",
                DataRowVersion.Proposed, item.EmailCorporate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailCorporate", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.EmailAccounts != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailAccounts ", SqlDbType.NVarChar, 200,
              ParameterDirection.Input, false, 10, 0, "",
              DataRowVersion.Proposed, item.EmailAccounts));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailAccounts", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Emailservices != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailServices ", SqlDbType.NVarChar, 200,
             ParameterDirection.Input, false, 10, 0, "",
             DataRowVersion.Proposed, item.Emailservices));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailServices", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.InactiveDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsInactiveDate ", SqlDbType.NVarChar, 35,
               ParameterDirection.Input, false, 10, 0, "",
               DataRowVersion.Proposed, item.InactiveDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsInactiveDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.WarantyExpiryDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsWarantyExpiryDate ", SqlDbType.NVarChar, 35,
               ParameterDirection.Input, false, 10, 0, "",
               DataRowVersion.Proposed, item.WarantyExpiryDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsWarantyExpiryDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CCRMMIFMasterAndDetails_INSERT' reported the ErrorCode: " +
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
        public IBaseEntityResponse<CCRMMIFMasterAndDetails> UpdateCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item)
        {
            IBaseEntityResponse<CCRMMIFMasterAndDetails> response = new BaseEntityResponse<CCRMMIFMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMIFMasterAndDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsInstallationDate", SqlDbType.NVarChar, 35,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.InstallationDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerCode", SqlDbType.NVarChar, 50,
                                         ParameterDirection.Input, false, 10, 0, "",
                                         DataRowVersion.Proposed, item.CustomerCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerAddress", SqlDbType.NVarChar, 2000,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.CustomerAddress.Trim()));
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCutomerSegementMasterID", SqlDbType.TinyInt, 4,
                                      ParameterDirection.Input, false, 10, 0, "",
                                      DataRowVersion.Proposed, item.CutomerSegementMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFTitle", SqlDbType.NVarChar, 100,
                                      ParameterDirection.Input, false, 10, 0, "",
                                      DataRowVersion.Proposed, item.MIFTitle.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFAddress", SqlDbType.NVarChar, 2000,
                                     ParameterDirection.Input, false, 10, 0, "",
                                     DataRowVersion.Proposed, item.MIFAddress.Trim()));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFolioNo", SqlDbType.NVarChar, 50,
                                 ParameterDirection.Input, false, 10, 0, "",
                                 DataRowVersion.Proposed, item.FolioNo.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBillTitle", SqlDbType.NVarChar, 200,
                                 ParameterDirection.Input, false, 10, 0, "",
                                 DataRowVersion.Proposed, item.BillTitle.Trim()));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMIFType", SqlDbType.TinyInt, 4,
                            ParameterDirection.Input, false, 10, 0, "",
                            DataRowVersion.Proposed, item.MIFType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMachineFamilyID", SqlDbType.SmallInt, 4,
                           ParameterDirection.Input, false, 10, 0, "",
                           DataRowVersion.Proposed, item.MachineFamilyID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMEngineersGroupMasterID", SqlDbType.Int, 4,
                           ParameterDirection.Input, false, 10, 0, "",
                           DataRowVersion.Proposed, item.CCRMEngineersGroupMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCCRMAreaPatchMasterID", SqlDbType.SmallInt, 4,
                          ParameterDirection.Input, false, 10, 0, "",
                          DataRowVersion.Proposed, item.CCRMAreaPatchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCountryID", SqlDbType.SmallInt, 4,
                          ParameterDirection.Input, false, 10, 0, "",
                          DataRowVersion.Proposed, item.CountryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siStateID", SqlDbType.SmallInt, 4,
                         ParameterDirection.Input, false, 10, 0, "",
                         DataRowVersion.Proposed, item.StateID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCityID", SqlDbType.SmallInt, 4,
                         ParameterDirection.Input, false, 10, 0, "",
                         DataRowVersion.Proposed, item.CityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCategory", SqlDbType.TinyInt, 4,
                     ParameterDirection.Input, false, 10, 0, "",
                     DataRowVersion.Proposed, item.Category));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMLocationTypeID", SqlDbType.Int, 4,
                        ParameterDirection.Input, false, 10, 0, "",
                        DataRowVersion.Proposed, item.CCRMLocationTypeID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPriority", SqlDbType.TinyInt, 4,
                      ParameterDirection.Input, false, 10, 0, "",
                      DataRowVersion.Proposed, item.Priority));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInstalledById", SqlDbType.Int, 4,
                     ParameterDirection.Input, false, 10, 0, "",
                     DataRowVersion.Proposed, item.InstalledById));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iServiceEngID", SqlDbType.Int, 4,
                    ParameterDirection.Input, false, 10, 0, "",
                    DataRowVersion.Proposed, item.ServiceEngID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCollExecId", SqlDbType.Int, 4,
                   ParameterDirection.Input, false, 10, 0, "",
                   DataRowVersion.Proposed, item.CollExecId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiISPrinter", SqlDbType.TinyInt, 4,
                  ParameterDirection.Input, false, 10, 0, "",
                  DataRowVersion.Proposed, item.ISPrinter));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiISScanner", SqlDbType.TinyInt, 4,
                 ParameterDirection.Input, false, 10, 0, "",
                 DataRowVersion.Proposed, item.ISScanner));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiISFax", SqlDbType.TinyInt, 4,
                ParameterDirection.Input, false, 10, 0, "",
                DataRowVersion.Proposed, item.ISFax));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@iWarantyInDays", SqlDbType.Int, 4,
               ParameterDirection.Input, false, 10, 0, "",
               DataRowVersion.Proposed, item.WarantyInDays));
                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiStatus", SqlDbType.TinyInt, 4,
            ParameterDirection.Input, false, 10, 0, "",
            DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsKeyOperatorName", SqlDbType.NVarChar, 100,
                          ParameterDirection.Input, false, 10, 0, "",
                          DataRowVersion.Proposed, item.KeyOperatorName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneNo", SqlDbType.NVarChar, 100,
                          ParameterDirection.Input, false, 10, 0, "",
                          DataRowVersion.Proposed, item.PhoneNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNo", SqlDbType.NVarChar, 100,
                         ParameterDirection.Input, false, 10, 0, "",
                         DataRowVersion.Proposed, item.MobileNo));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModifiedBy));

                    if (item.InactiveDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsInactiveDate", SqlDbType.NVarChar, 35,
         ParameterDirection.Input, false, 10, 0, "",
         DataRowVersion.Proposed, item.InactiveDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsInactiveDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.ModelNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsModelNo", SqlDbType.NVarChar, 200,
                             ParameterDirection.Input, false, 10, 0, "",
                             DataRowVersion.Proposed, item.ModelNo.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsModelNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }

                    //if (item.SelectedContactDetailsIDs != null)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectedContactDetailsIDs", SqlDbType.Xml, 0,
                    //                                          ParameterDirection.Input, false, 10, 0, "",
                    //                                          DataRowVersion.Proposed, item.SelectedContactDetailsIDs));
                    //}
                    //else
                    //{

                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectedContactDetailsIDs", SqlDbType.Xml, 0,
                    //                                          ParameterDirection.Input, false, 10, 0, "",
                    //                                          DataRowVersion.Proposed, DBNull.Value));

                    //}
                    if (item.EmailCorporate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailCorporate", SqlDbType.NVarChar, 200,
        ParameterDirection.Input, false, 10, 0, "",
        DataRowVersion.Proposed, item.EmailCorporate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailCorporate", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.EmailAccounts != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailAccounts", SqlDbType.NVarChar, 200,
       ParameterDirection.Input, false, 10, 0, "",
       DataRowVersion.Proposed, item.EmailAccounts));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailAccounts", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Emailservices != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailServices", SqlDbType.NVarChar, 200,
      ParameterDirection.Input, false, 10, 0, "",
      DataRowVersion.Proposed, item.Emailservices));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailServices", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Remarks != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 2000,
          ParameterDirection.Input, false, 10, 0, "",
          DataRowVersion.Proposed, item.Remarks));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRemarks", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Others != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOthers", SqlDbType.NVarChar, 100,
               ParameterDirection.Input, false, 10, 0, "",
               DataRowVersion.Proposed, item.Others));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOthers", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.SerialNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50,
                             ParameterDirection.Input, false, 10, 0, "",
                             DataRowVersion.Proposed, item.SerialNo.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSerialNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.BillAddress != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBillAddress", SqlDbType.NVarChar, 2000,
                               ParameterDirection.Input, false, 10, 0, "",
                               DataRowVersion.Proposed, item.BillAddress.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBillAddress", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.CustomerPinCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerPinCode", SqlDbType.NVarChar, 10,
                                      ParameterDirection.Input, false, 10, 0, "",
                                      DataRowVersion.Proposed, item.CustomerPinCode.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerPinCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.MIFPinCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFPinCode", SqlDbType.NVarChar, 10,
                                  ParameterDirection.Input, false, 10, 0, "",
                                  DataRowVersion.Proposed, item.MIFPinCode.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMIFPinCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.WarantyExpiryDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsWarantyExpiryDate", SqlDbType.NVarChar, 35,
           ParameterDirection.Input, false, 10, 0, "",
           DataRowVersion.Proposed, item.WarantyExpiryDate.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsWarantyExpiryDate", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CCRMMIFMasterAndDetails_Delete' reported the ErrorCode: " +
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
        public IBaseEntityResponse<CCRMMIFMasterAndDetails> DeleteCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item)
        {
            IBaseEntityResponse<CCRMMIFMasterAndDetails> response = new BaseEntityResponse<CCRMMIFMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMIFMasterAndDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Input, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.CCRMMIFMasterAndDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 0));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, 1));
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
                    //  item.CCRMMIFMasterAndDetailsID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CCRMMIFMasterAndDetails_Delete' reported the ErrorCode: " +
                                        _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFMasterAndDetailsSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMIFMasterAndDetails_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<CCRMMIFMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        CCRMMIFMasterAndDetails item = new CCRMMIFMasterAndDetails();
                        //item.CCRMMIFMasterAndDetailsID = sqlDataReader["CCRMMIFMasterAndDetailsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CCRMMIFMasterAndDetailsID"]);
                        //item.CCRMMIFMasterAndDetailsName = sqlDataReader["CCRMMIFMasterAndDetailsName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CCRMMIFMasterAndDetailsName"]);
                        //item.CustomerType = sqlDataReader["CustomerType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CustomerType"]);
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMMIFMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CCRMMIFMasterAndDetails> InsertCCRMMIFMasterAndDetailsContactDetails(CCRMMIFMasterAndDetails item)
        {
            IBaseEntityResponse<CCRMMIFMasterAndDetails> response = new BaseEntityResponse<CCRMMIFMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerContactDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //if (item.CustomerBranchMasterID != 0)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4,
                    //                            ParameterDirection.Input, false, 10, 0, "",
                    //                           DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                       DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //cmdToExecute.Parameters.Add(new SqlParameter("@xCustomerContactDetailsXml", SqlDbType.Xml, 0,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.XmlString));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMMIFMasterAndDetailsID", SqlDbType.Int, 4,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.CCRMMIFMasterAndDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ModifiedBy));
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
                        //   item.CCRMMIFMasterAndDetailsID = (Int32)cmdToExecute.Parameters["@iCCRMMIFMasterAndDetailsID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CCRMMIFMasterAndDetails_INSERT' reported the ErrorCode: " +
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
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetListOfOperatorByID(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMIFMasterAndDetails_GetKeyOperatorbyMasterID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCCRMMIFMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CCRMMIFMasterAndDetailsID));
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
                    baseEntityCollection.CollectionResponse = new List<CCRMMIFMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        CCRMMIFMasterAndDetails item = new CCRMMIFMasterAndDetails();

                        //item.CustomerContactPersonName = sqlDataReader["CustomerContactPersonName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerContactPersonName"]);
                        item.KeyOperator = sqlDataReader["KeyOperatorID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["KeyOperatorID"]);
                        item.KeyOperatorName = sqlDataReader["KeyOperatorName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["KeyOperatorName"]);
                        item.Phone = sqlDataReader["PhoneNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PhoneNo"]);

                        item.MobileNumber = sqlDataReader["MobileNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MobileNo"]);

                        item.CCRMMIFCallOperatorDetailsID = sqlDataReader["CCRMMIFCallOperatorDetailsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CCRMMIFCallOperatorDetailsID"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMMIFMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFSerialNoSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMIFSerialNo_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<CCRMMIFMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        CCRMMIFMasterAndDetails item = new CCRMMIFMasterAndDetails();
                        item.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        //item.CustomerType = sqlDataReader["CustomerType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CustomerType"]);
                        item.CustomerAddress = sqlDataReader["CustomerAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerAddress"]);
                        item.MIFTitle = sqlDataReader["MIFTitle"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFTitle"]);
                        item.MIFAddress = sqlDataReader["MIFAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFAddress"]);
                        item.ModelNo = sqlDataReader["ModelNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModelNo"]);
                        item.SerialNo = sqlDataReader["SerialNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SerialNo"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.ColorMono = sqlDataReader["ColorMono"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ColorMono"]);
                        item.PaperSize = sqlDataReader["PaperSize"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PaperSize"]);
                        item.KeyOperatorName = sqlDataReader["KeyOperatorName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["KeyOperatorName"]);
                        item.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        item.Phone = sqlDataReader["PhoneNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PhoneNo"]);

                        item.ContractTypeId = sqlDataReader["ContractTypeId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ContractTypeId"]);
                        item.ContractNo = sqlDataReader["ContractNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNo"]);
                        item.ContractName = sqlDataReader["ContractName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractName"]);
                        item.ContractOpDate = sqlDataReader["ContractOpDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractOpDate"]);
                        item.ContractClosingDate = sqlDataReader["ContractClosingDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractClosingDate"]);
                        item.MobileNo = sqlDataReader["MobileNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MobileNo"]);
                        item.EmailServices = sqlDataReader["EmailServices"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmailServices"]);
                        item.CallCharges = sqlDataReader["CallCharges"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CallCharges"]);
                        item.ContractCode = sqlDataReader["ContractCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractCode"]);
                        item.MachineFamilyID = sqlDataReader["MachineFamilyID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["MachineFamilyID"]);
                        item.MachineFamilyName = sqlDataReader["MachineFamilyName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MachineFamilyName"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMMIFSerialNo_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFCallerNameSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMMIFMasterAndDetailsCallerName_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));

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

                    baseEntityCollection.CollectionResponse = new List<CCRMMIFMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        CCRMMIFMasterAndDetails item = new CCRMMIFMasterAndDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.KeyOperatorName = sqlDataReader["KeyOperatorName"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMMIFMasterAndDetailsCallerName_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMContractMasterSerialNoSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CCRMContractMasterSerialNo_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<CCRMMIFMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        CCRMMIFMasterAndDetails item = new CCRMMIFMasterAndDetails();
                        item.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        //item.CustomerType = sqlDataReader["CustomerType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CustomerType"]);
                        item.CustomerAddress = sqlDataReader["CustomerAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerAddress"]);
                        item.MIFTitle = sqlDataReader["MIFTitle"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFTitle"]);
                        item.MIFAddress = sqlDataReader["MIFAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MIFAddress"]);
                        item.ModelNo = sqlDataReader["ModelNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModelNo"]);
                        item.SerialNo = sqlDataReader["SerialNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SerialNo"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        item.ColorMono = sqlDataReader["ColorMono"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ColorMono"]);
                        item.PaperSize = sqlDataReader["PaperSize"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PaperSize"]);
                        item.KeyOperatorName = sqlDataReader["KeyOperatorName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["KeyOperatorName"]);
                        item.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        item.Phone = sqlDataReader["PhoneNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PhoneNo"]);

                        //item.ContractTypeId = sqlDataReader["ContractTypeId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ContractTypeId"]);
                        //item.ContractNo = sqlDataReader["ContractNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractNo"]);
                        //item.ContractName = sqlDataReader["ContractName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractName"]);
                        //item.ContractOpDate = sqlDataReader["ContractOpDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractOpDate"]);
                        //item.ContractClosingDate = sqlDataReader["ContractClosingDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractClosingDate"]);
                        item.MobileNo = sqlDataReader["MobileNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MobileNo"]);
                        item.EmailServices = sqlDataReader["EmailServices"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmailServices"]);
                        item.CallCharges = sqlDataReader["CallCharges"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CallCharges"]);
                       // item.ContractCode = sqlDataReader["ContractCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContractCode"]);
                        item.MachineFamilyID = sqlDataReader["MachineFamilyID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["MachineFamilyID"]);
                        item.MachineFamilyName = sqlDataReader["MachineFamilyName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MachineFamilyName"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CCRMMIFSerialNo_SearchList' reported the ErrorCode: " + _errorCode);
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
