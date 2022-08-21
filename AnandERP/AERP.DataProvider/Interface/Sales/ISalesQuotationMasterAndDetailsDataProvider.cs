using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISalesQuotationMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<SalesQuotationMasterAndDetails> InsertSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item);
        IBaseEntityResponse<SalesQuotationMasterAndDetails> UpdateSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item);
        IBaseEntityResponse<SalesQuotationMasterAndDetails> DeleteSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetSalesQuotationMasterAndDetailsBySearch(SalesQuotationMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetSalesQuotationMasterAndDetailsSearchList(SalesQuotationMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesQuotationMasterAndDetails> GetSalesQuotationMasterAndDetailsByID(SalesQuotationMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetQuotationMasterDetailsByEnquiryMaterID(SalesQuotationMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetUomWiseSalesPrice(SalesQuotationMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetItemNumberSearchListForCustomer(SalesQuotationMasterAndDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetQuotationMasterDetailsListByQuotationMasterID(SalesQuotationMasterAndDetailsSearchRequest searchRequest);

    }
}
