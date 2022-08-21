using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryPhysicalStockMasterAndTransactionBR
    {
        IValidateBusinessRuleResponse InsertInventoryPhysicalStockMasterAndTransactionValidate(InventoryPhysicalStockMasterAndTransaction item);
        IValidateBusinessRuleResponse UpdateInventoryPhysicalStockMasterAndTransactionValidate(InventoryPhysicalStockMasterAndTransaction item);
        IValidateBusinessRuleResponse DeleteInventoryPhysicalStockMasterAndTransactionValidate(InventoryPhysicalStockMasterAndTransaction item);
    }
}
