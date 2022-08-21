using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public class VendorMasterReportDataProvider : DBInteractionBase, IVendorMasterReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public VendorMasterReportDataProvider() { }
        public VendorMasterReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<VendorMasterReport> GetVendorMasterReportBySearch_AllVendorList(VendorMasterReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<VendorMasterReport> baseEntityCollection = new BaseEntityCollectionResponse<VendorMasterReport>();
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
                    cmdToExecute.CommandText = "dbo.VendorMasterMissingException_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsReportFor", SqlDbType.NVarChar, 25, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ReportFor));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtEndDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionUptoDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstId));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountSessionID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsSubLedger", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.IsSubLedger));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@cAssetLiabilityFlag", SqlDbType.Char, 5, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AssetLiabilityFlag));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
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

                    baseEntityCollection.CollectionResponse = new List<VendorMasterReport>();
                    while (sqlDataReader.Read())
                    {
                        VendorMasterReport item = new VendorMasterReport();
                        //On Selection Of All
                          if (searchRequest.ReportFor == "All")
                            {
                               if (DBNull.Value.Equals(sqlDataReader["VendorID"]) == false)
                                    {
                                      item.VendorID = Convert.ToInt16(sqlDataReader["VendorID"]);
                                    }

                               if (DBNull.Value.Equals(sqlDataReader["Vender"]) == false)
                                    {
                                     item.VendorName = Convert.ToString(sqlDataReader["Vender"]);
                                    }
                               if (DBNull.Value.Equals(sqlDataReader["VendorNumber"]) == false)
                                    {
                                    item.VendorNumber = Convert.ToString(sqlDataReader["VendorNumber"]);
                                    }
                               if (DBNull.Value.Equals(sqlDataReader["ContactPerson"]) == false)
                                    {
                                    item.ContactPerson = Convert.ToString(sqlDataReader["ContactPerson"]);
                                    }
                               if (DBNull.Value.Equals(sqlDataReader["CategoryCode"]) == false)
                                    {
                                  item.MerchandiseCategory = Convert.ToString(sqlDataReader["CategoryCode"]);
                                    }
                               if (DBNull.Value.Equals(sqlDataReader["LeadTime"]) == false)
                                    {
                                 item.LeadTime = Convert.ToString(sqlDataReader["LeadTime"]);
                                    }
                               if (DBNull.Value.Equals(sqlDataReader["VendorRestriction"]) == false)
                                    {
                                item.VendorRestriction = Convert.ToDecimal(sqlDataReader["VendorRestriction"]);
                                    }
                              }
                              //On the Selection Of Vendor Restriction
                       if (searchRequest.ReportFor == "VendorRestriction")
                               {
                                   if (DBNull.Value.Equals(sqlDataReader["VendorNumber"]) == false)
                                    {
                                        item.VendorNumber = Convert.ToString(sqlDataReader["VendorNumber"]);
                                    }

                                   if (DBNull.Value.Equals(sqlDataReader["Vender"]) == false)
                                    {
                                        item.VendorName = Convert.ToString(sqlDataReader["Vender"]);
                                    }
                                   if (DBNull.Value.Equals(sqlDataReader["VendorRestriction"]) == false)
                                    {
                                        item.VendorRestriction = Convert.ToDecimal(sqlDataReader["VendorRestriction"]);
                                    }
                              }

                               
                                //On the Selection Of ReplenishmentCategory
                      if (searchRequest.ReportFor == "ReplenishmentCategory")
                                {
                                    if (DBNull.Value.Equals(sqlDataReader["VendorID"]) == false)
                                    {
                                        item.VendorID = Convert.ToInt16(sqlDataReader["VendorID"]);
                                    }

                                    if (DBNull.Value.Equals(sqlDataReader["Vender"]) == false)
                                    {
                                        item.VendorName = Convert.ToString(sqlDataReader["Vender"]);
                                    }
                                    if (DBNull.Value.Equals(sqlDataReader["VendorNumber"]) == false)
                                    {
                                        item.VendorNumber = Convert.ToString(sqlDataReader["VendorNumber"]);
                                    }
                                    if (DBNull.Value.Equals(sqlDataReader["CategoryCode"]) == false)
                                    {
                                        item.MerchandiseCategory = Convert.ToString(sqlDataReader["CategoryCode"]);
                                    }
                                    if (DBNull.Value.Equals(sqlDataReader["LeadTime"]) == false)
                                   {
                                       item.LeadTime = Convert.ToString(sqlDataReader["LeadTime"]);
                                   }
                              }
                                //On the Selection Of ContactPerson
                     if (searchRequest.ReportFor == "ContactPerson")
                               {
                                   if (DBNull.Value.Equals(sqlDataReader["Vender"]) == false)
                                  {
                                      item.VendorName = Convert.ToString(sqlDataReader["Vender"]);
                                   }
                                  if (DBNull.Value.Equals(sqlDataReader["VendorID"]) == false)
                                  {
                                   item.VendorID = Convert.ToInt16(sqlDataReader["VendorID"]);
                                   }
                                  if (DBNull.Value.Equals(sqlDataReader["VendorNumber"]) == false)
                                  {
                                      item.VendorNumber = Convert.ToString(sqlDataReader["VendorNumber"]);
                                  }

                                  if (DBNull.Value.Equals(sqlDataReader["ContactPersonFirstName"]) == false)
                                  {
                                      item.ContactPersonFirstName = Convert.ToString(sqlDataReader["ContactPersonFirstName"]);
                                      //item.ContactPersonFirstName = Convert.ToString(sqlDataReader["ContactPersonFirstName"]) + " " + Convert.ToString(sqlDataReader["ContactPersonMiddleName"]) + " " + Convert.ToString(sqlDataReader["ContactPersonLastName"]);
                                   }
                                  if (DBNull.Value.Equals(sqlDataReader["ContactPersonMiddleName"]) == false)
                                  {
                                      item.ContactPersonMiddleName = Convert.ToString(sqlDataReader["ContactPersonMiddleName"]);
                                  }
                                  if (DBNull.Value.Equals(sqlDataReader["ContactPersonLastName"]) == false)
                                  {
                                      item.ContactPersonLastName = Convert.ToString(sqlDataReader["ContactPersonLastName"]);
                                  }
                                  if (DBNull.Value.Equals(sqlDataReader["ContactPersonMobNo"]) == false)
                                   {
                                       item.ContactPersonMobNo = Convert.ToString(sqlDataReader["ContactPersonMobNo"]);
                                    }
                                  if (DBNull.Value.Equals(sqlDataReader["ContactPersonEmailID"]) == false)
                                  {
                                      item.ContactPersonEmailID = Convert.ToString(sqlDataReader["ContactPersonEmailID"]);
                                   }
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
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        //Item Master Missing Rxception report
        public IBaseEntityCollectionResponse<VendorMasterReport> GetVendorMasterReportBySearch_ItemList(VendorMasterReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<VendorMasterReport> baseEntityCollection = new BaseEntityCollectionResponse<VendorMasterReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_PriceReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                     //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
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

                    baseEntityCollection.CollectionResponse = new List<VendorMasterReport>();
                    while (sqlDataReader.Read())
                    {
                        VendorMasterReport item = new VendorMasterReport();
                       
                        //item.ItemName = sqlDataReader["ItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        //item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["ItemNumber"]);
                        //item.OrderUoM = sqlDataReader["OrderUoM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUoM"]);
                        //item.BaseUoM = sqlDataReader["BaseUoM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUoM"]);
                        //item.SalesUoM = sqlDataReader["SalesUoM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesUoM"]);
                        //item.Vendor = sqlDataReader["Vendor"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vendor"]);
                        //item.LeadTime = sqlDataReader["LeadTime"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["LeadTime"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
