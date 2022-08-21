using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IInventoryUoMGroupAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertInventoryUoMGroupAndDetailsValidate(InventoryUoMGroupAndDetails item);
        IValidateBusinessRuleResponse UpdateInventoryUoMGroupAndDetailsValidate(InventoryUoMGroupAndDetails item);
        IValidateBusinessRuleResponse DeleteInventoryUoMGroupAndDetailsValidate(InventoryUoMGroupAndDetails item);

        //******************************************************************************************************
        IValidateBusinessRuleResponse InsertInventoryUoMGroupValidate(InventoryUoMGroupAndDetails item);
        IValidateBusinessRuleResponse UpdateInventoryUoMGroupValidate(InventoryUoMGroupAndDetails item);
        IValidateBusinessRuleResponse DeleteInventoryUoMGroupValidate(InventoryUoMGroupAndDetails item);
    }
}
