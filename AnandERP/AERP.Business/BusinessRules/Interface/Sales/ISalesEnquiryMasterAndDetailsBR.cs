using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISalesEnquiryMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertSalesEnquiryMasterAndDetailsValidate(SalesEnquiryMasterAndDetails item);
        IValidateBusinessRuleResponse InsertSalesEnquiryMasterAndDetailsContactDetailsValidate(SalesEnquiryMasterAndDetails item);
        IValidateBusinessRuleResponse InsertSalesEnquiryMasterAndDetailsBranchDetailsValidate(SalesEnquiryMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateSalesEnquiryMasterAndDetailsValidate(SalesEnquiryMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteSalesEnquiryMasterAndDetailsValidate(SalesEnquiryMasterAndDetails item);
    }
}
