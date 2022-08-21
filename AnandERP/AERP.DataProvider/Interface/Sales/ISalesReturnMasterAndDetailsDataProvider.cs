using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISalesReturnMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<SalesReturnMasterAndDetails> InsertSalesReturnMasterAndDetails(SalesReturnMasterAndDetails item);
        IBaseEntityResponse<SalesReturnMasterAndDetails> UpdateSalesReturnMasterAndDetails(SalesReturnMasterAndDetails item);
        IBaseEntityResponse<SalesReturnMasterAndDetails> DeleteSalesReturnMasterAndDetails(SalesReturnMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> GetSalesReturnMasterAndDetailsBySearch(SalesReturnMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> GetSalesReturnMasterAndDetailsSearchList(SalesReturnMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> GetDropDownListforSalesReturnMasterAndDetails(SalesReturnMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesReturnMasterAndDetails> GetSalesReturnMasterAndDetailsByID(SalesReturnMasterAndDetails item);
    }
}
