

using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISalesEnquiryMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item);
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetailsContactDetails(SalesEnquiryMasterAndDetails item);
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetailsBranchDetails(SalesEnquiryMasterAndDetails item);
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> UpdateSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item);
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> DeleteSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item);

        IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetSalesEnquiryMasterAndDetailsBySearch(SalesEnquiryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> GetSalesEnquiryMasterAndDetailsByID(SalesEnquiryMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetSalesEnquiryMasterAndDetailsSearchList(SalesEnquiryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetCustomerBranchMasterSearchList(SalesEnquiryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetEnquiryDetailsByID(SalesEnquiryMasterAndDetailsSearchRequest searchRequest);

    }
}
