using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISalesQuotationMasterAndDetailsBA
    {
        IBaseEntityResponse<SalesQuotationMasterAndDetails> InsertSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item);
        IBaseEntityResponse<SalesQuotationMasterAndDetails> UpdateSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item);
        IBaseEntityResponse<SalesQuotationMasterAndDetails> DeleteSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetBySearch(SalesQuotationMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetSalesQuotationMasterAndDetailsSearchList(SalesQuotationMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesQuotationMasterAndDetails> SelectByID(SalesQuotationMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetQuotationMasterDetailsByEnquiryMaterID(SalesQuotationMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetUomWiseSalesPrice(SalesQuotationMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetItemNumberSearchListForCustomer(SalesQuotationMasterAndDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetQuotationMasterDetailsListByQuotationMasterID(SalesQuotationMasterAndDetailsSearchRequest searchRequest);

    }
}

