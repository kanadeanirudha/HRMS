using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralCategoryMasterBR
    {
        IValidateBusinessRuleResponse InsertCategoryValidate(GeneralCategoryMaster item);

        IValidateBusinessRuleResponse UpdateCategoryValidate(GeneralCategoryMaster item);

        IValidateBusinessRuleResponse DeleteCategoryValidate(GeneralCategoryMaster item);
    }
}
