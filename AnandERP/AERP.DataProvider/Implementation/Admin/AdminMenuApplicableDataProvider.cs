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
    public class AdminMenuApplicableDataProvider : DBInteractionBase, IAdminMenuApplicableDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        public AdminMenuApplicableDataProvider()
        {
        }

        public AdminMenuApplicableDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        public IBaseEntityCollectionResponse<AdminMenuApplicable> GetAdminMenuApplicableBySearch(AdminMenuApplicableSearchRequest searchRequest)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<AdminMenuApplicable> GetAdminMenuApplicableByID(int id)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<AdminMenuApplicable> InsertAdminMenuApplicable(AdminMenuApplicable item)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<AdminMenuApplicable> UpdateAdminMenuApplicable(AdminMenuApplicable item)
        {
            throw new NotImplementedException();
        }

        public IBaseEntityResponse<AdminMenuApplicable> DeleteAdminMenuApplicable(AdminMenuApplicable item)
        {
            throw new NotImplementedException();

        }

        #endregion
    }
}
