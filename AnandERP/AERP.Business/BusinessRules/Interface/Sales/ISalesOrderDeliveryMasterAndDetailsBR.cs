using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface ISalesOrderDeliveryMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertSalesOrderDeliveryMasterAndDetailsValidate(SalesOrderDeliveryMasterAndDetails item);
        IValidateBusinessRuleResponse InsertSalesOrderDeliveryMasterAndDetailsForDirectDMValidate(SalesOrderDeliveryMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateSalesOrderDeliveryMasterAndDetailsValidate(SalesOrderDeliveryMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteSalesOrderDeliveryMasterAndDetailsValidate(SalesOrderDeliveryMasterAndDetails item);
    }
}
