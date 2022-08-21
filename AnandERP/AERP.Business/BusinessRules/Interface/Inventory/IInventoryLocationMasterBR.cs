using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IInventoryLocationMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryLocationMasterValidate(InventoryLocationMaster item);
        IValidateBusinessRuleResponse UpdateInventoryLocationMasterValidate(InventoryLocationMaster item);
        IValidateBusinessRuleResponse DeleteInventoryLocationMasterValidate(InventoryLocationMaster item);
    }
}
