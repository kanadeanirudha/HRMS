using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IInventoryUoMMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryUoMMasterValidate(InventoryUoMMaster item);
        IValidateBusinessRuleResponse UpdateInventoryUoMMasterValidate(InventoryUoMMaster item);
        IValidateBusinessRuleResponse DeleteInventoryUoMMasterValidate(InventoryUoMMaster item);
    }
}
