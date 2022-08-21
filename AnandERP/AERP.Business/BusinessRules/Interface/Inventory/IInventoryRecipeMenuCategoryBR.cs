using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IInventoryRecipeMenuCategoryBR
    {
        IValidateBusinessRuleResponse InsertInventoryRecipeMenuCategoryValidate(InventoryRecipeMenuCategory item);
        IValidateBusinessRuleResponse UpdateInventoryRecipeMenuCategoryValidate(InventoryRecipeMenuCategory item);
        IValidateBusinessRuleResponse DeleteInventoryRecipeMenuCategoryValidate(InventoryRecipeMenuCategory item);
    }
}
