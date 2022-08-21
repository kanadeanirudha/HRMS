using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public class UserDetailDataProvider : DBInteractionBase, IUserDetailDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        public UserDetailDataProvider()
        {
        }

        public UserDetailDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        public IBaseEntityCollectionResponse<UserDetail> GetUserDetailBySearch(UserDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserDetail>();
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
                    cmdToExecute.CommandText = "dbo.pr_UserDetail_SelectAll";
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

                    baseEntityCollection.CollectionResponse = new List<UserDetail>();
                    while (sqlDataReader.Read())
                    {
                        UserDetail item = new UserDetail();
                        item.UserTypeID = Convert.ToInt32(sqlDataReader["UserTypeID"]);
                        item.EmailID = sqlDataReader["EmailID"].ToString();
                        item.Password = sqlDataReader["Password"].ToString();
                        item.FirstName = sqlDataReader["FirstName"].ToString();
                        item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        item.LastName = sqlDataReader["LastName"].ToString();
                        item.Gender = sqlDataReader["Gender"].ToString();
                        item.DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]);
                        item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);

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
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'pr_UserDetail_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<UserDetail> GetUserDetailByID(int id)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<UserDetail> InsertUserDetail(UserDetail item)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<UserDetail> UpdateUserDetail(UserDetail item)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<UserDetail> DeleteUserDetail(UserDetail item)
        {
            throw new NotImplementedException();

        }

        #endregion
    }
}
