using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface ISalesReturnMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertSalesReturnMasterAndDetailsValidate(SalesReturnMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateSalesReturnMasterAndDetailsValidate(SalesReturnMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteSalesReturnMasterAndDetailsValidate(SalesReturnMasterAndDetails item);
    }
}
