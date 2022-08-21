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
    public class GeneralSupplierMasterDataProvider: DBInteractionBase, IGeneralSupplierMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public GeneralSupplierMasterDataProvider(){}
        public GeneralSupplierMasterDataProvider(ILogger logException) 
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        #region Method Implementation
        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralSupplierMaster> GetGeneralSupplierMasterBySearch(GeneralSupplierMasterSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<GeneralSupplierMaster> baseEntityCollection = new BaseEntityCollectionResponse<GeneralSupplierMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralSupplierMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
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
                    baseEntityCollection.CollectionResponse = new List<GeneralSupplierMaster>();

                    while (sqlDataReader.Read())
                    {
                        GeneralSupplierMaster item = new GeneralSupplierMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.Vender = Convert.ToString(sqlDataReader["Vender"]);
                        item.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                        item.MiddleName = Convert.ToString(sqlDataReader["MiddleName"]);
                        item.LastName = Convert.ToString(sqlDataReader["LastName"]);
                        item.FullName = Convert.ToString(sqlDataReader["FullName"]);
                        item.Sex = Convert.ToString(sqlDataReader["Sex"]);
                        item.AddressFirst = Convert.ToString(sqlDataReader["AddressFirst"]);
                        item.AddressSecond = Convert.ToString(sqlDataReader["AddressSecond"]);
                        item.PlotNumber = Convert.ToString(sqlDataReader["PlotNumber"]);
                        item.StreetNumber = Convert.ToString(sqlDataReader["StreetNumber"]);
                        if (DBNull.Value.Equals(sqlDataReader["TahsilID"]) == false)
                        {
                            item.TahsilID = Convert.ToInt32(sqlDataReader["TahsilID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PinCode"]) == false)
                        {
                            item.PinCode = Convert.ToInt32(sqlDataReader["PinCode"]);
                        }
                        item.PhoneNumber = Convert.ToString(sqlDataReader["PhoneNumber"]);
                        item.ResiPhoneNumber = Convert.ToString(sqlDataReader["ResiPhoneNumber"]);
                        item.CellPhoneNumber = Convert.ToString(sqlDataReader["CellPhoneNumber"]);
                        item.FaxNumber = Convert.ToString(sqlDataReader["FaxNumber"]);
                        item.Email = Convert.ToString(sqlDataReader["Email"]);
                        item.WebUrl = Convert.ToString(sqlDataReader["WebUrl"]);
                        item.VenderDescription = Convert.ToString(sqlDataReader["VenderDescription"]);
                        if (DBNull.Value.Equals(sqlDataReader["CategoryId"]) == false)
                        {
                            item.CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountId"]) == false)
                        {
                            item.AccountId = Convert.ToInt32(sqlDataReader["AccountId"]);
                        }
                        item.VAT = Convert.ToString(sqlDataReader["VAT"]);
                        item.CST = Convert.ToString(sqlDataReader["CST"]);
                        item.Excise = Convert.ToString(sqlDataReader["Excise"]);
                        item.StablishmentNumber = Convert.ToString(sqlDataReader["StablishmentNumber"]);
                        item.RefNumber = Convert.ToString(sqlDataReader["RefNumber"]);
                        item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        if (DBNull.Value.Equals(sqlDataReader["CreatedBy"]) == false)
                        {
                            item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
                        {
                            item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedBy"]) == false)
                        {
                            item.DeletedBy = Convert.ToInt32(sqlDataReader["DeletedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedDate"]) == false)
                        {
                            item.DeletedDate = Convert.ToDateTime(sqlDataReader["DeletedDate"]);
                        }
                        item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralSupplierMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from Account Balance Sheet Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> GetGeneralSupplierMasterByID(GeneralSupplierMaster item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<GeneralSupplierMaster> response = new BaseEntityResponse<GeneralSupplierMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralSupplierMaster_SelectOne";
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
                        GeneralSupplierMaster _item = new GeneralSupplierMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.Vender = Convert.ToString(sqlDataReader["Vender"]);
                        _item.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                        _item.MiddleName = Convert.ToString(sqlDataReader["MiddleName"]);
                        _item.LastName = Convert.ToString(sqlDataReader["LastName"]);
                        _item.Sex = Convert.ToString(sqlDataReader["Sex"]);
                        _item.AddressFirst = Convert.ToString(sqlDataReader["AddressFirst"]);
                        _item.AddressSecond = Convert.ToString(sqlDataReader["AddressSecond"]);
                        _item.PlotNumber = Convert.ToString(sqlDataReader["PlotNumber"]);
                        _item.StreetNumber = Convert.ToString(sqlDataReader["StreetNumber"]);
                        if (DBNull.Value.Equals(sqlDataReader["TahsilID"]) == false)
                        {
                            _item.TahsilID = Convert.ToInt32(sqlDataReader["TahsilID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PinCode"]) == false)
                        {
                            _item.PinCode = Convert.ToInt32(sqlDataReader["PinCode"]);
                        }
                        _item.PhoneNumber = Convert.ToString(sqlDataReader["PhoneNumber"]);
                        _item.ResiPhoneNumber = Convert.ToString(sqlDataReader["ResiPhoneNumber"]);
                        _item.CellPhoneNumber = Convert.ToString(sqlDataReader["CellPhoneNumber"]);
                        _item.FaxNumber = Convert.ToString(sqlDataReader["FaxNumber"]);
                        _item.Email = Convert.ToString(sqlDataReader["Email"]);
                        _item.WebUrl = Convert.ToString(sqlDataReader["WebUrl"]);
                        _item.VenderDescription = Convert.ToString(sqlDataReader["VenderDescription"]);
                        if (DBNull.Value.Equals(sqlDataReader["CategoryId"]) == false)
                        {
                            _item.CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountId"]) == false)
                        {
                            _item.AccountId = Convert.ToInt32(sqlDataReader["AccountId"]);
                        }
                        _item.VAT = Convert.ToString(sqlDataReader["VAT"]);
                        _item.CST = Convert.ToString(sqlDataReader["CST"]);
                        _item.Excise = Convert.ToString(sqlDataReader["Excise"]);
                        _item.StablishmentNumber = Convert.ToString(sqlDataReader["StablishmentNumber"]);
                        _item.RefNumber = Convert.ToString(sqlDataReader["RefNumber"]);
                        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        if (DBNull.Value.Equals(sqlDataReader["CreatedBy"]) == false)
                        {
                            _item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            _item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
                        {
                            _item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            _item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedBy"]) == false)
                        {
                            _item.DeletedBy = Convert.ToInt32(sqlDataReader["DeletedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedDate"]) == false)
                        {
                            _item.DeletedDate = Convert.ToDateTime(sqlDataReader["DeletedDate"]);
                        }
                        _item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralSupplierMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of Account Balance Sheet Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> InsertGeneralSupplierMaster(GeneralSupplierMaster item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<GeneralSupplierMaster> response = new BaseEntityResponse<GeneralSupplierMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralSupplierMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsVender", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.Vender));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.FirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MiddleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.LastName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cSex", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.Sex));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddressFirst", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.AddressFirst));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddressSecond", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.AddressSecond));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.PlotNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StreetNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTahsilID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TahsilID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPinCode", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PinCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPhoneNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.PhoneNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sResiPhoneNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ResiPhoneNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sCellPhoneNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CellPhoneNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sFaxNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.FaxNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.Email));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sWebUrl", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.WebUrl));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsVenderDescription", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.VenderDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CategoryId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccountId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsVAT", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.VAT));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCST", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CST));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsExcise", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.Excise));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStablishmentNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StablishmentNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRefNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.RefNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralSupplierMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of Account Balance Sheet Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> UpdateGeneralSupplierMaster(GeneralSupplierMaster item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<GeneralSupplierMaster> response = new BaseEntityResponse<GeneralSupplierMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralSupplierMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsVender", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.Vender));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.FirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MiddleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.LastName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cSex", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.Sex));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddressFirst", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.AddressFirst));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddressSecond", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.AddressSecond));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.PlotNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStreetNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StreetNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTahsilID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TahsilID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPinCode", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PinCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sPhoneNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.PhoneNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sResiPhoneNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.ResiPhoneNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sCellPhoneNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CellPhoneNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sFaxNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.FaxNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.Email));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sWebUrl", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.WebUrl));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsVenderDescription", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.VenderDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CategoryId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccountId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsVAT", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.VAT));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCST", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CST));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsExcise", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.Excise));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStablishmentNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StablishmentNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRefNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.RefNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralSupplierMaster_Update' reported the ErrorCode: " + _errorCode);
                    }

                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Update failed"
                        });
                    }
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

        /// <summary>
        /// Delete a selected record from Account Balance Sheet Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> DeleteGeneralSupplierMaster(GeneralSupplierMaster item)
        {
            //throw new NotImplementedException();
            IBaseEntityResponse<GeneralSupplierMaster> response = new BaseEntityResponse<GeneralSupplierMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralSupplierMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));
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

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralSupplierMaster_Delete' reported the ErrorCode: " + _errorCode);
                    }

                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Delete failed"
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

        public IBaseEntityCollectionResponse<GeneralSupplierMaster> GetGeneralSupplierMasterGetBySearchList(GeneralSupplierMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralSupplierMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralSupplierMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralSupplierMaster_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<GeneralSupplierMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralSupplierMaster item = new GeneralSupplierMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Vender"]) == false)
                        {
                            item.Vender = Convert.ToString(sqlDataReader["Vender"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Country"]) == false)
                        {
                            item.CountryID = Convert.ToInt32(sqlDataReader["Country"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Currency"]) == false)
                        {
                            item.Currency = Convert.ToString(sqlDataReader["Currency"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VendorNumber"]) == false)
                        {
                            item.VendorNumber = Convert.ToInt32(sqlDataReader["VendorNumber"]);
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
                        throw new Exception("Stored Procedure 'USP_GeneralSupplierMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

