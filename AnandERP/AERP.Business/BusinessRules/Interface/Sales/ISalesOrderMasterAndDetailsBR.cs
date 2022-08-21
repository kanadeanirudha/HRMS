using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface ISalesOrderMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertSalesOrderMasterAndDetailsValidate(SalesOrderMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateSalesOrderMasterAndDetailsValidate(SalesOrderMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteSalesOrderMasterAndDetailsValidate(SalesOrderMasterAndDetails item);
    }
}
