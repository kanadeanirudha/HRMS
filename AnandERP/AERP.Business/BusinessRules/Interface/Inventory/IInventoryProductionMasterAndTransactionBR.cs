using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryProductionMasterAndTransactionBR
    {
        IValidateBusinessRuleResponse InsertInventoryProductionMasterAndTransactionValidate(InventoryProductionMasterAndTransaction item);
        IValidateBusinessRuleResponse UpdateInventoryProductionMasterAndTransactionValidate(InventoryProductionMasterAndTransaction item);
        IValidateBusinessRuleResponse DeleteInventoryProductionMasterAndTransactionValidate(InventoryProductionMasterAndTransaction item);
    }
}
