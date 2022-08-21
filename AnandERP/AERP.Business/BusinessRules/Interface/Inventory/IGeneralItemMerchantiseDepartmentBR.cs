using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralItemMerchantiseDepartmentBR
    {
        IValidateBusinessRuleResponse InsertGeneralItemMerchantiseDepartmentValidate(GeneralItemMerchantiseDepartment item);
        IValidateBusinessRuleResponse UpdateGeneralItemMerchantiseDepartmentValidate(GeneralItemMerchantiseDepartment item);
        IValidateBusinessRuleResponse DeleteGeneralItemMerchantiseDepartmentValidate(GeneralItemMerchantiseDepartment item);
    }
}
