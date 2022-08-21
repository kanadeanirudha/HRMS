using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISalesInvoiceMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertSalesInvoiceMasterAndDetailsValidate(SalesInvoiceMasterAndDetails item);
        IValidateBusinessRuleResponse InsertDirectSalesInvoiceMasterAndDetailsValidate(SalesInvoiceMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateSalesInvoiceMasterAndDetailsValidate(SalesInvoiceMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteSalesInvoiceMasterAndDetailsValidate(SalesInvoiceMasterAndDetails item);
    }
}
