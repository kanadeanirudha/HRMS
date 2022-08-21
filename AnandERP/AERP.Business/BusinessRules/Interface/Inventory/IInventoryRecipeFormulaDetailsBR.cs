using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryRecipeFormulaDetailsBR
    {
        IValidateBusinessRuleResponse InsertInventoryRecipeFormulaDetailsValidate(InventoryRecipeFormulaDetails item);
        IValidateBusinessRuleResponse UpdateInventoryRecipeFormulaDetailsValidate(InventoryRecipeFormulaDetails item);
        IValidateBusinessRuleResponse DeleteInventoryRecipeFormulaDetailsValidate(InventoryRecipeFormulaDetails item);
    }
}
