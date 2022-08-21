using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ISalesEnquiryMasterAndDetailsBA
    {
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item);
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetailsContactDetails(SalesEnquiryMasterAndDetails item);
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetailsBranchDetails(SalesEnquiryMasterAndDetails item);
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> UpdateSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item);
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> DeleteSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetBySearch(SalesEnquiryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetSalesEnquiryMasterAndDetailsSearchList(SalesEnquiryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetCustomerBranchMasterSearchList(SalesEnquiryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetEnquiryDetailsByID(SalesEnquiryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesEnquiryMasterAndDetails> SelectByID(SalesEnquiryMasterAndDetails item);
    }
}
