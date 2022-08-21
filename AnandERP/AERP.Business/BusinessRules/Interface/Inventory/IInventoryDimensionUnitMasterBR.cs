using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryDimensionUnitMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryDimensionUnitMasterValidate(InventoryDimensionUnitMaster item);
        IValidateBusinessRuleResponse UpdateInventoryDimensionUnitMasterValidate(InventoryDimensionUnitMaster item);
        IValidateBusinessRuleResponse DeleteInventoryDimensionUnitMasterValidate(InventoryDimensionUnitMaster item);
    }
}
