using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IBOMAndRecipeDetailsBR
    {
        IValidateBusinessRuleResponse InsertBOMAndRecipeDetailsValidate(BOMAndRecipeDetails item);
        IValidateBusinessRuleResponse UpdateBOMAndRecipeDetailsValidate(BOMAndRecipeDetails item);
        IValidateBusinessRuleResponse DeleteBOMAndRecipeDetailsValidate(BOMAndRecipeDetails item);
    }
}
