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
    public class InventoryLablePrintingFormatDataProvider : DBInteractionBase, IInventoryLablePrintingFormatDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public InventoryLablePrintingFormatDataProvider() { }
        public InventoryLablePrintingFormatDataProvider(ILogger logException)
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
        public IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetInventoryLablePrintingFormatByGeneralUnitsID(InventoryLablePrintingFormatSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryLablePrintingFormat> baseEntityCollection = new BaseEntityCollectionResponse<InventoryLablePrintingFormat>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetItemDetailsbyUnitsIDForLabelPrinting";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                   //cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
                   cmdToExecute.Parameters.Add(new SqlParameter("@iToItemnumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ToItemNumber));
                   cmdToExecute.Parameters.Add(new SqlParameter("@iFromItemnumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                  //  cmdToExecute.Parameters.Add(new SqlParameter("@nsUomCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SaleUoM));
                   
                    
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

                    baseEntityCollection.CollectionResponse = new List<InventoryLablePrintingFormat>();
                    while (sqlDataReader.Read())
                    {
                        InventoryLablePrintingFormat item = new InventoryLablePrintingFormat();
                        

                            if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                            {
                                item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                            {
                                item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["BarCode"]) == false)
                            {
                                item.BarCode = Convert.ToString(sqlDataReader["BarCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["SaleUomCode"]) == false)
                            {
                                item.SalesUoM = Convert.ToString(sqlDataReader["SaleUomCode"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["SalePrice"]) == false)
                            {
                                item.SalesPrice = Convert.ToDecimal(sqlDataReader["SalePrice"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["Todaysdate"]) == false)
                            {
                                item.TransactionDate = Convert.ToString(sqlDataReader["Todaysdate"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ArabicTransalation"]) == false)
                            {
                                item.ArebicTransalation = Convert.ToString(sqlDataReader["ArabicTransalation"]);
                            }

                            if (DBNull.Value.Equals(sqlDataReader["ShelfNumber"]) == false)
                            {
                                item.ShelfNumber = Convert.ToString(sqlDataReader["ShelfNumber"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["SafetyStockDriven"]) == false)
                            {
                                item.SafetyStockDriven = Convert.ToByte(sqlDataReader["SafetyStockDriven"]);
                            }

                            if (DBNull.Value.Equals(sqlDataReader["ReorderPoint"]) == false)
                            {
                                item.ReorderPoint = Convert.ToByte(sqlDataReader["ReorderPoint"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["CurrencyCode"]) == false)
                            {
                                item.CurrencyCode = Convert.ToString(sqlDataReader["CurrencyCode"]);
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
        public IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetInventoryLablePrintingFormatBySearch_ItemList(InventoryLablePrintingFormatSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryLablePrintingFormat> baseEntityCollection = new BaseEntityCollectionResponse<InventoryLablePrintingFormat>();
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

                    baseEntityCollection.CollectionResponse = new List<InventoryLablePrintingFormat>();
                    while (sqlDataReader.Read())
                    {
                        InventoryLablePrintingFormat item = new InventoryLablePrintingFormat();

                        //item.ItemName = sqlDataReader["ItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        //item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemNumber"]);
                        //item.OrderUoM = sqlDataReader["OrderUoM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUoM"]);
                        //item.SalesPrice = sqlDataReader["SalesPrice"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SalesPrice"]);
                        //item.SalesUoM = sqlDataReader["SalesUoM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesUoM"]);
                        //item.CostperOrderUnit = sqlDataReader["CostPerOrderUnit"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CostPerOrderUnit"]);
                        //item.Site = sqlDataReader["Site"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Site"]);

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
        public IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetItemNumberList(InventoryLablePrintingFormatSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<InventoryLablePrintingFormat> baseEntityCollection = new BaseEntityCollectionResponse<InventoryLablePrintingFormat>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_GetListForItemNumber";
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

                    baseEntityCollection.CollectionResponse = new List<InventoryLablePrintingFormat>();
                    while (sqlDataReader.Read())
                    {
                        InventoryLablePrintingFormat item = new InventoryLablePrintingFormat();
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
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
