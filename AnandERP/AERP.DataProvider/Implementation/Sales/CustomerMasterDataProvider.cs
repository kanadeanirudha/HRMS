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
    public class CustomerMasterDataProvider : DBInteractionBase, ICustomerMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public CustomerMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public CustomerMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from CustomerMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CustomerMaster> GetCustomerMasterBySearch(CustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CustomerMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //---------------- INPUT PARAMETER--------------------//
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    //---------------- OUTPUT PARAMETER--------------------//                    
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
                    baseEntityCollection.CollectionResponse = new List<CustomerMaster>();
                    while (sqlDataReader.Read())
                    {
                        CustomerMaster item = new CustomerMaster();
                        item.CustomerMasterID = Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.CustomerMasterName = Convert.ToString(sqlDataReader["CustomerName"]);
                        item.CustomerBranchMasterID = Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        item.CustomerBranchMasterName = Convert.ToString(sqlDataReader["BranchName"]);
                        item.IsMainBranch = Convert.ToBoolean(sqlDataReader["IsMainBranch"]);
                        item.CustomerType = Convert.ToByte(sqlDataReader["CustomerType"]);
                        item.CustomerBranchCode = Convert.ToString(sqlDataReader["CustomerBranchCode"]);
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
                        throw new Exception("Stored Procedure 'USP_CustomerMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CustomerMaster> GetCustomerMasterByID(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> response = new BaseEntityResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerBranchMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerBranchMasterID));
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
                        CustomerMaster _item = new CustomerMaster();
                        _item.CustomerBranchMasterID = Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        _item.CustomerMasterID = Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        _item.IsMainBranch = Convert.ToBoolean(sqlDataReader["IsMainBranch"]);
                        _item.Address1 = sqlDataReader["Address1"].ToString();
                        _item.Address2 = sqlDataReader["Address2"].ToString();
                        _item.Address3 = sqlDataReader["Address3"].ToString();
                        _item.CityID = Convert.ToString(sqlDataReader["CityID"]);
                        _item.StateID = Convert.ToString(sqlDataReader["StateID"]);
                        _item.CountryID = Convert.ToString(sqlDataReader["CountryID"]);
                        _item.GSTNumber = sqlDataReader["GSTNumber"].ToString();
                        _item.IsTaxExempted = Convert.ToBoolean(sqlDataReader["IsTaxExempted"]);
                        _item.ReasonForExemption = Convert.ToByte(sqlDataReader["ReasonForExemption"]);
                        _item.CreditPeriod = Convert.ToString(sqlDataReader["CreditPeriod"]);
                        _item.BankName = sqlDataReader["BankName"].ToString();
                        _item.IFCICODE = sqlDataReader["IFCICODE"].ToString();
                        _item.UnitMasterId = Convert.ToString(sqlDataReader["UnitMasterID"]);
                        _item.BankAccountNumber = sqlDataReader["BankAccountNumber"].ToString();
                        _item.CustomerBranchMasterName = sqlDataReader["BranchName"].ToString();
                        _item.ShortCode = sqlDataReader["ShortCode"].ToString();
                        _item.IsBillToSameAsShipTo = Convert.ToBoolean(sqlDataReader["IsBillToSameAsShipTo"]);
                        _item.PinCode = Convert.ToString(sqlDataReader["PinCode"]);
                        _item.CustomerBranchCode = sqlDataReader["CustomerBranchCode"].ToString();
                        _item.MobileNumber = Convert.ToString(sqlDataReader["MobileNumber"]);
                        _item.TaxExemptionRemark = Convert.ToString(sqlDataReader["TaxExemptionRemark"]);
                        _item.IsCentre = sqlDataReader["IsCentre"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsCentre"]);
                        _item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
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
        public IBaseEntityResponse<CustomerMaster> InsertCustomerMaster(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> response = new BaseEntityResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerMaster_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.CustomerMasterID));


                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCustomerType", SqlDbType.TinyInt, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.CustomerType));
                    if (item.CompanyName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCompanyName", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CompanyName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCompanyName", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.FirstName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 25,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FirstName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.MiddleName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MiddleName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.LastName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.LastName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Address1 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address1));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Address2 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address2));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Address3 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address3));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.CountryID != null || item.CountryID != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.SmallInt, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.CountryID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.SmallInt, 4,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStateID", SqlDbType.SmallInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.StateID));
                    if (item.CityID != "" || item.CityID != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, Convert.ToInt32(item.CityID)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, 0));
                    }
                    if (item.MobileNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 20,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, item.MobileNumber));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 20,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Email != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmail", SqlDbType.NVarChar, 100,
                                                        ParameterDirection.Input, false, 10, 0, "",
                                                        DataRowVersion.Proposed, item.Email));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmail", SqlDbType.NVarChar, 100,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCurrency", SqlDbType.SmallInt, 4,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, item.Currency));
                    if (item.GSTNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGSTNumber", SqlDbType.NVarChar, 50,
                                                       ParameterDirection.Input, true, 10, 0, "",
                                                       DataRowVersion.Proposed, item.GSTNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGSTNumber", SqlDbType.NVarChar, 50,
                                                       ParameterDirection.Input, true, 10, 0, "",
                                                       DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsTaxExempted", SqlDbType.Bit, 0,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, item.IsTaxExempted));
                    if (item.ReasonForExemption != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiReasonForExemption", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.ReasonForExemption));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiReasonForExemption", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BankName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30,
                                                  ParameterDirection.Input, true, 10, 0, "",
                                                  DataRowVersion.Proposed, item.BankName));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.IFCICODE != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFCICODE", SqlDbType.NVarChar, 15,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, item.IFCICODE));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFCICODE", SqlDbType.NVarChar, 15,
                                                  ParameterDirection.Input, true, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BankAccountNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAccountNumber", SqlDbType.NVarChar, 25,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, item.BankAccountNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAccountNumber", SqlDbType.NVarChar, 25,
                                                     ParameterDirection.Input, true, 10, 0, "",
                                                     DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.CreditPeriod != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriod", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.CreditPeriod));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriod", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UnitMasterId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiUnitMasterID", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.UnitMasterId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiUnitMasterID", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Code != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCode", SqlDbType.NVarChar, 25,
                                                     ParameterDirection.Input, false, 10, 0, "",
                                                     DataRowVersion.Proposed, item.Code));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCode", SqlDbType.NVarChar, 25,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CustomerBranchMasterName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerBranchMasterName", SqlDbType.NVarChar, 100,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, item.CustomerBranchMasterName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerBranchMasterName", SqlDbType.NVarChar, 100,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsMainBranch", SqlDbType.Bit, 0,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, item.IsMainBranch));
                    if (item.ShortCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cShortCode", SqlDbType.Char, 5,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, item.ShortCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cShortCode", SqlDbType.Char, 5,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PinCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPinCode", SqlDbType.NVarChar, 20,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, item.PinCode));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPinCode", SqlDbType.NVarChar, 20,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.TaxExemptionRemark != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTaxExemptionRemark", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TaxExemptionRemark));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTaxExemptionRemark", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCentre", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsCentre));
                    if (item.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
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
                    //    item.CustomerMasterID = (Int32)cmdToExecute.Parameters["@iCustomerMasterID"].Value;
                    //}
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CustomerMaster_INSERT' reported the ErrorCode: " +
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
        /// <summary>
        /// Update a specific record of CustomerMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CustomerMaster> UpdateCustomerMaster(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> response = new BaseEntityResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerMasterBranchDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsMainBranch", SqlDbType.Bit, 0,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, item.IsMainBranch));
                    if (item.Address1 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address1));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Address2 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address2));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Address3 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address3));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.SmallInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CountryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStateID", SqlDbType.SmallInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.StateID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CityID));

                    if (item.GSTNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGSTNumber", SqlDbType.NVarChar, 50,
                                                       ParameterDirection.Input, true, 10, 0, "",
                                                       DataRowVersion.Proposed, item.GSTNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGSTNumber", SqlDbType.NVarChar, 50,
                                                       ParameterDirection.Input, true, 10, 0, "",
                                                       DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsTaxExempted", SqlDbType.Bit, 0,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, item.IsTaxExempted));
                    if (item.ReasonForExemption != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiReasonForExemption", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.ReasonForExemption));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiReasonForExemption", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BankName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30,
                                                  ParameterDirection.Input, true, 10, 0, "",
                                                  DataRowVersion.Proposed, item.BankName));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.IFCICODE != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFCICODE", SqlDbType.NVarChar, 15,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, item.IFCICODE));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFCICODE", SqlDbType.NVarChar, 15,
                                                  ParameterDirection.Input, true, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BankAccountNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAccountNumber", SqlDbType.NVarChar, 25,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, item.BankAccountNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAccountNumber", SqlDbType.NVarChar, 25,
                                                     ParameterDirection.Input, true, 10, 0, "",
                                                     DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.CreditPeriod != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriod", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.CreditPeriod));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriod", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UnitMasterId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiUnitMasterID", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.UnitMasterId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiUnitMasterID", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CustomerBranchMasterName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerBranchMasterName", SqlDbType.NVarChar, 100,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, item.CustomerBranchMasterName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerBranchMasterName", SqlDbType.NVarChar, 100,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ShortCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cShortCode", SqlDbType.Char, 5,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, item.ShortCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cShortCode", SqlDbType.Char, 5,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsBillToSameAsShipTo", SqlDbType.Bit, 0,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.IsBillToSameAsShipTo));
                    if (item.PinCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPinCode", SqlDbType.NVarChar, 20,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.PinCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPinCode", SqlDbType.NVarChar,20,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.TaxExemptionRemark != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTaxExemptionRemark", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TaxExemptionRemark));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTaxExemptionRemark", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCentre", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsCentre));
                    if (item.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

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
                    //item.CustomerMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CustomerMaster_Delete' reported the ErrorCode: " +
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
        /// <summary>
        /// Delete a specific record of CustomerMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CustomerMaster> DeleteCustomerMaster(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> response = new BaseEntityResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CustomerMasterID));
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
                    item.CustomerMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CustomerMaster_Delete' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<CustomerMaster> GetCustomerMasterSearchList(CustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CustomerMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerMaster_SearchList";
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
                    baseEntityCollection.CollectionResponse = new List<CustomerMaster>();
                    while (sqlDataReader.Read())
                    {
                        CustomerMaster item = new CustomerMaster();
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.CustomerMasterName = sqlDataReader["CustomerMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerMasterName"]);
                        item.CustomerType = sqlDataReader["CustomerType"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["CustomerType"]);
                        item.CreditAmount = sqlDataReader["CreditAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CreditAmount"]);
                        item.CustomerAddress = sqlDataReader["CustomerAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerAddress"]);
                        item.PinCode = sqlDataReader["PinCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PinCode"]);
                       //item.MobileNumber = sqlDataReader["MobileNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MobileNumber"]);
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CustomerMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CustomerMaster> GetCustomerBranchMasterSearchList(CustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CustomerMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerBranchMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<CustomerMaster>();
                    while (sqlDataReader.Read())
                    {
                        CustomerMaster item = new CustomerMaster();
                        item.CustomerBranchMasterID = sqlDataReader["CustomerBranchMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerBranchMasterID"]);
                        item.CustomerBranchMasterName = sqlDataReader["CustomerBranchMasterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerBranchMasterName"]);
                        item.CreditAmount = sqlDataReader["CreditAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CreditAmount"]);
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CustomerMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CustomerMaster> GetCustomerContactDetilsSearchList(CustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CustomerMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerContactDetails_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerBranchMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<CustomerMaster>();
                    while (sqlDataReader.Read())
                    {
                        CustomerMaster item = new CustomerMaster();
                        item.CustomerContactDetailsID = sqlDataReader["CustomerContactDetailsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerContactDetailsID"]);
                        item.CustomerContactPersonName = sqlDataReader["ContactPersonName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ContactPersonName"]);
                        item.MobileNumber = sqlDataReader["MobileNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MobileNumber"]);
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CustomerMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CustomerMaster> InsertCustomerMasterContactDetails(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> response = new BaseEntityResponse<CustomerMaster>();
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

                    if (item.CustomerBranchMasterID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.CustomerBranchMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@xCustomerContactDetailsXml", SqlDbType.Xml, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.XmlString));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CustomerMasterID));
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
                        item.CustomerMasterID = (Int32)cmdToExecute.Parameters["@iCustomerMasterID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CustomerMaster_INSERT' reported the ErrorCode: " +
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
        public IBaseEntityResponse<CustomerMaster> InsertCustomerMasterBranchDetails(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> response = new BaseEntityResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerMasterBranchDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.CustomerMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsMainBranch", SqlDbType.Bit, 0,
                                              ParameterDirection.Input, false, 10, 0, "",
                                              DataRowVersion.Proposed, item.IsMainBranch));
                    if (item.Address1 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address1));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Address2 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address2));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Address3 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address3));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.SmallInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CountryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStateID", SqlDbType.SmallInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.StateID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CityID));

                    if (item.GSTNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGSTNumber", SqlDbType.NVarChar, 50,
                                                       ParameterDirection.Input, true, 10, 0, "",
                                                       DataRowVersion.Proposed, item.GSTNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGSTNumber", SqlDbType.NVarChar, 50,
                                                       ParameterDirection.Input, true, 10, 0, "",
                                                       DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsTaxExempted", SqlDbType.Bit, 0,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, item.IsTaxExempted));
                    if (item.ReasonForExemption != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiReasonForExemption", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.ReasonForExemption));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiReasonForExemption", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BankName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30,
                                                  ParameterDirection.Input, true, 10, 0, "",
                                                  DataRowVersion.Proposed, item.BankName));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.IFCICODE != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFCICODE", SqlDbType.NVarChar, 15,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, item.IFCICODE));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFCICODE", SqlDbType.NVarChar, 15,
                                                  ParameterDirection.Input, true, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BankAccountNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAccountNumber", SqlDbType.NVarChar, 25,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, item.BankAccountNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAccountNumber", SqlDbType.NVarChar, 25,
                                                     ParameterDirection.Input, true, 10, 0, "",
                                                     DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.CreditPeriod != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriod", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.CreditPeriod));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriod", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UnitMasterId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiUnitMasterID", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.UnitMasterId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiUnitMasterID", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CustomerBranchMasterName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerBranchMasterName", SqlDbType.NVarChar, 100,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, item.CustomerBranchMasterName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerBranchMasterName", SqlDbType.NVarChar, 100,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ShortCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cShortCode", SqlDbType.Char, 5,
                                                 ParameterDirection.Input, false, 10, 0, "",
                                                 DataRowVersion.Proposed, item.ShortCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cShortCode", SqlDbType.Char, 5,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsBillToSameAsShipTo", SqlDbType.Bit, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.IsBillToSameAsShipTo));
                    if (item.PinCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPinCode", SqlDbType.NVarChar, 15,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, item.PinCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPinCode", SqlDbType.NVarChar, 15,
                                                  ParameterDirection.Input, true, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.TaxExemptionRemark != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTaxExemptionRemark", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TaxExemptionRemark));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTaxExemptionRemark", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCentre", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsCentre));
                    if (item.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
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
                    if (_rowsAffected > 0)
                    {
                        item.CustomerMasterID = (Int32)cmdToExecute.Parameters["@iCustomerMasterID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CustomerMaster_INSERT' reported the ErrorCode: " +
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


        public IBaseEntityCollectionResponse<CustomerMaster> GetContactDetailsByCustomerMasterID(CustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CustomerMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerContactDetails_GetDetailsByCustomerID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerMasterID));
                    if (searchRequest.CustomerBranchMasterID != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CustomerBranchMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerBranchMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
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
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    baseEntityCollection.CollectionResponse = new List<CustomerMaster>();
                    while (sqlDataReader.Read())
                    {
                        CustomerMaster item = new CustomerMaster();
                        item.CustomerContactFirstName = sqlDataReader["FirstName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FirstName"]);
                        item.CustomerContactMiddleName = sqlDataReader["MiddleName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MiddleName"]);
                        item.CustomerContactLastName = sqlDataReader["LastName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LastName"]);
                        item.CustomerContactMobileNumber = sqlDataReader["MobileNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MobileNumber"]);
                        item.CustomerContactEmailID = sqlDataReader["Email"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Email"]);
                        item.CustomerContactDesignation = sqlDataReader["Designation"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Designation"]);
                        item.IsPrimaryContact = sqlDataReader["IsPrimaryContact"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsPrimaryContact"]);
                        item.CustomerMasterID = sqlDataReader["CustomerMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerMasterID"]);
                        item.CustomerContactDetailsID = sqlDataReader["CustomerContactDetailsID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CustomerContactDetailsID"]);
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CustomerMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CustomerMaster> GetCustomerMasterDetailsByCustomerMasterID(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> response = new BaseEntityResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerMasterID));
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
                        CustomerMaster _item = new CustomerMaster();
                        _item.CustomerMasterID = Convert.ToInt32(sqlDataReader["CustomerMasterID"]);

                        _item.CompanyName = sqlDataReader["CompanyName"].ToString();
                        _item.CustomerType = Convert.ToByte(sqlDataReader["CustomerType"]);
                        _item.CompanyName = sqlDataReader["CompanyName"].ToString();
                        _item.Email = sqlDataReader["Email"].ToString();
                        _item.FirstName = sqlDataReader["FirstName"].ToString();
                        _item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        _item.LastName = sqlDataReader["LastName"].ToString();
                        _item.Address1 = sqlDataReader["Address1"].ToString();
                        _item.Address2 = sqlDataReader["Address2"].ToString();
                        _item.Address3 = sqlDataReader["Address3"].ToString();
                        _item.CityID = Convert.ToString(sqlDataReader["CityID"]);
                        _item.StateID = Convert.ToString(sqlDataReader["StateID"]);
                        _item.CountryID = Convert.ToString(sqlDataReader["CountryID"]);
                        _item.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                        _item.Currency = Convert.ToInt16(sqlDataReader["Currency"]);
                        _item.CreditPeriod = Convert.ToString(sqlDataReader["CreditPeriod"]);
                        _item.UnitMasterId = Convert.ToString(sqlDataReader["UnitMasterID"]);

                        _item.GSTNumber = sqlDataReader["GSTNumber"].ToString();
                        _item.IsTaxExempted = Convert.ToBoolean(sqlDataReader["IsTaxExempted"]);
                        _item.ReasonForExemption = Convert.ToByte(sqlDataReader["ReasonForExemption"]);

                        _item.BankName = sqlDataReader["BankName"].ToString();
                        _item.IFCICODE = sqlDataReader["IFCICODE"].ToString();
                        _item.PinCode = sqlDataReader["PinCode"].ToString();
                        _item.TaxExemptionRemark = sqlDataReader["TaxExemptionRemark"].ToString();
                        _item.IsCentre = sqlDataReader["IsCentre"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsCentre"]);
                        _item.CentreCode = sqlDataReader["CentreCode"].ToString();

                        _item.BankAccountNumber = sqlDataReader["BankAccountNumber"].ToString();
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
        /// Update a specific record of CustomerMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CustomerMaster> UpdateCustomerMasterByCustomerMasterID(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> response = new BaseEntityResponse<CustomerMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CustomerMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerMasterID", SqlDbType.Int, 4,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.CustomerMasterID));

                    if (item.CompanyName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCompanyName", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CompanyName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCompanyName", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.FirstName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 25,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FirstName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.MiddleName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MiddleName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.LastName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.LastName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Address1 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address1));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Address2 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address2));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Address3 != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address3));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress3", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.CountryID != null || item.CountryID != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.SmallInt, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.CountryID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.SmallInt, 4,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStateID", SqlDbType.SmallInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.StateID));
                    if (item.CityID != "" || item.CityID != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, Convert.ToInt32(item.CityID)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, 0));
                    }
                    if (item.MobileNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 20,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, item.MobileNumber));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 20,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.Email != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmail", SqlDbType.NVarChar, 100,
                                                        ParameterDirection.Input, false, 10, 0, "",
                                                        DataRowVersion.Proposed, item.Email));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmail", SqlDbType.NVarChar, 100,
                                                    ParameterDirection.Input, false, 10, 0, "",
                                                    DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCurrency", SqlDbType.SmallInt, 4,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, item.Currency));
                    if (item.GSTNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGSTNumber", SqlDbType.NVarChar, 50,
                                                       ParameterDirection.Input, true, 10, 0, "",
                                                       DataRowVersion.Proposed, item.GSTNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGSTNumber", SqlDbType.NVarChar, 50,
                                                       ParameterDirection.Input, true, 10, 0, "",
                                                       DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsTaxExempted", SqlDbType.Bit, 0,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, item.IsTaxExempted));
                    if (item.ReasonForExemption != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiReasonForExemption", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.ReasonForExemption));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiReasonForExemption", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BankName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30,
                                                  ParameterDirection.Input, true, 10, 0, "",
                                                  DataRowVersion.Proposed, item.BankName));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.IFCICODE != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFCICODE", SqlDbType.NVarChar, 15,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, item.IFCICODE));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsIFCICODE", SqlDbType.NVarChar, 15,
                                                  ParameterDirection.Input, true, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BankAccountNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAccountNumber", SqlDbType.NVarChar, 25,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, item.BankAccountNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAccountNumber", SqlDbType.NVarChar, 25,
                                                     ParameterDirection.Input, true, 10, 0, "",
                                                     DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.CreditPeriod != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriod", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.CreditPeriod));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCreditPeriod", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.UnitMasterId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiUnitMasterID", SqlDbType.TinyInt, 4,
                                                      ParameterDirection.Input, false, 10, 0, "",
                                                      DataRowVersion.Proposed, item.UnitMasterId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiUnitMasterID", SqlDbType.TinyInt, 4,
                                                  ParameterDirection.Input, false, 10, 0, "",
                                                  DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.PinCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPinCode", SqlDbType.NVarChar, 10,
                                                      ParameterDirection.Input, true, 10, 0, "",
                                                      DataRowVersion.Proposed, item.PinCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPinCode", SqlDbType.NVarChar, 10,
                                                     ParameterDirection.Input, true, 10, 0, "",
                                                     DataRowVersion.Proposed, DBNull.Value));

                    }
                    if (item.TaxExemptionRemark != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTaxExemptionRemark", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TaxExemptionRemark));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTaxExemptionRemark", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCentre", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsCentre));
                    if (item.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

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
                    //item.CustomerMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CustomerMaster_Delete' reported the ErrorCode: " +
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
