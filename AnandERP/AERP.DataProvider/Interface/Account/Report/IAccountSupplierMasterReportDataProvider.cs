using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IAccountSupplierMasterReportDataProvider
    {

        IBaseEntityCollectionResponse<AccountSupplierMasterReport> GetAccountSupplierMasterReportBySearch(AccountSupplierMasterReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountSupplierMasterReport> GetAccountSupplierMasterReportByID(AccountSupplierMasterReport item);
    }
}
