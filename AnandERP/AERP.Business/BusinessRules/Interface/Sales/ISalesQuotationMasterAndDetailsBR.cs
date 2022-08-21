using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface ISalesQuotationMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertSalesQuotationMasterAndDetailsValidate(SalesQuotationMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateSalesQuotationMasterAndDetailsValidate(SalesQuotationMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteSalesQuotationMasterAndDetailsValidate(SalesQuotationMasterAndDetails item);
    }
}
