using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryRecipeMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryRecipeMasterValidate(InventoryRecipeMaster item);
        IValidateBusinessRuleResponse UpdateInventoryRecipeMasterValidate(InventoryRecipeMaster item);
        IValidateBusinessRuleResponse DeleteInventoryRecipeMasterValidate(InventoryRecipeMaster item);
    }
}
