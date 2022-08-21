using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IInventoryBrandMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryBrandMasterValidate(InventoryBrandMaster item);
        IValidateBusinessRuleResponse UpdateInventoryBrandMasterValidate(InventoryBrandMaster item);
        IValidateBusinessRuleResponse DeleteInventoryBrandMasterValidate(InventoryBrandMaster item);
    }
}
