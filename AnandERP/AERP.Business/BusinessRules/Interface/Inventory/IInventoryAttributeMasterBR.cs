using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IInventoryAttributeMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryAttributeMasterValidate(InventoryAttributeMaster item);
        IValidateBusinessRuleResponse UpdateInventoryAttributeMasterValidate(InventoryAttributeMaster item);
        IValidateBusinessRuleResponse DeleteInventoryAttributeMasterValidate(InventoryAttributeMaster item);
    }
}
