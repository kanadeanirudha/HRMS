using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryVariationMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryVariationMasterValidate(InventoryVariationMaster item);
        IValidateBusinessRuleResponse UpdateInventoryVariationMasterValidate(InventoryVariationMaster item);
        IValidateBusinessRuleResponse DeleteInventoryVariationMasterValidate(InventoryVariationMaster item);
    }
}
