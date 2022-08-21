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
    public class AdminSnPostsTransactionDataProvider : DBInteractionBase, IAdminSnPostsTransactionDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        public AdminSnPostsTransactionDataProvider()
        {
        }

        public AdminSnPostsTransactionDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        public IBaseEntityCollectionResponse<AdminSnPostsTransaction> GetAdminSnPostsTransactionBySearch(AdminSnPostsTransactionSearchRequest searchRequest)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<AdminSnPostsTransaction> GetAdminSnPostsTransactionByID(int id)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<AdminSnPostsTransaction> InsertAdminSnPostsTransaction(AdminSnPostsTransaction item)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<AdminSnPostsTransaction> UpdateAdminSnPostsTransaction(AdminSnPostsTransaction item)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<AdminSnPostsTransaction> DeleteAdminSnPostsTransaction(AdminSnPostsTransaction item)
        {
            throw new NotImplementedException();

        }

        #endregion
    }
}
