﻿using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralItemMerchantiseCategoryBR
    {
        IValidateBusinessRuleResponse InsertGeneralItemMerchantiseCategoryValidate(GeneralItemMerchantiseCategory item);
        IValidateBusinessRuleResponse UpdateGeneralItemMerchantiseCategoryValidate(GeneralItemMerchantiseCategory item);
        IValidateBusinessRuleResponse DeleteGeneralItemMerchantiseCategoryValidate(GeneralItemMerchantiseCategory item);
    }
}
