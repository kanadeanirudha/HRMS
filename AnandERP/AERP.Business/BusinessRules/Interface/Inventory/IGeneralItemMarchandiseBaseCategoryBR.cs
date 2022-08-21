using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralItemMarchandiseBaseCategoryBR
    {
        IValidateBusinessRuleResponse InsertGeneralItemMarchandiseBaseCategoryValidate(GeneralItemMarchandiseBaseCategory item);
        IValidateBusinessRuleResponse UpdateGeneralItemMarchandiseBaseCategoryValidate(GeneralItemMarchandiseBaseCategory item);
        IValidateBusinessRuleResponse DeleteGeneralItemMarchandiseBaseCategoryValidate(GeneralItemMarchandiseBaseCategory item);
    }
}
