using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISalesCustomerRecieptBR
    {
        IValidateBusinessRuleResponse InsertSalesCustomerRecieptValidate(SalesCustomerReciept item);
        IValidateBusinessRuleResponse UpdateSalesCustomerRecieptValidate(SalesCustomerReciept item);
        IValidateBusinessRuleResponse DeleteSalesCustomerRecieptValidate(SalesCustomerReciept item);
    }
}
