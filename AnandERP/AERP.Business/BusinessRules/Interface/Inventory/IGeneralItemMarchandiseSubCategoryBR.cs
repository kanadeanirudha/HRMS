using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralItemMarchandiseSubCategoryBR
    {
        IValidateBusinessRuleResponse InsertGeneralItemMarchandiseSubCategoryValidate(GeneralItemMarchandiseSubCategory item);
        IValidateBusinessRuleResponse UpdateGeneralItemMarchandiseSubCategoryValidate(GeneralItemMarchandiseSubCategory item);
        IValidateBusinessRuleResponse DeleteGeneralItemMarchandiseSubCategoryValidate(GeneralItemMarchandiseSubCategory item);
    }
}
