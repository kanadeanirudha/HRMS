using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralItemCategoryMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralItemCategoryMasterValidate(GeneralItemCategoryMaster item);
        IValidateBusinessRuleResponse UpdateGeneralItemCategoryMasterValidate(GeneralItemCategoryMaster item);
        IValidateBusinessRuleResponse DeleteGeneralItemCategoryMasterValidate(GeneralItemCategoryMaster item);
        IValidateBusinessRuleResponse InsertGeneralItemCategoryMasterExcelValidate(GeneralItemCategoryMaster item);
    }
}
