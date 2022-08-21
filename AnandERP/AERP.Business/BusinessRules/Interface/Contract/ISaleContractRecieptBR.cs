using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractRecieptBR
    {
        IValidateBusinessRuleResponse InsertSaleContractRecieptValidate(SaleContractReciept item);
        IValidateBusinessRuleResponse UpdateSaleContractRecieptValidate(SaleContractReciept item);
        IValidateBusinessRuleResponse DeleteSaleContractRecieptValidate(SaleContractReciept item);
    }
}
