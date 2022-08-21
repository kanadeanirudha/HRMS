using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AERP.Base.DTO;
using AERP.DTO;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IInventoryStockAdjustmentBR
    {
        IValidateBusinessRuleResponse InsertInventoryStockAdjustmentValidate(InventoryStockAdjustment item);
        IValidateBusinessRuleResponse UpdateInventoryStockAdjustmentValidate(InventoryStockAdjustment item);
        IValidateBusinessRuleResponse DeleteInventoryStockAdjustmentValidate(InventoryStockAdjustment item);
        IValidateBusinessRuleResponse InsertXMLInventoryStockAdjustmentValidate(InventoryStockAdjustment item);
        IValidateBusinessRuleResponse InsertXMLForRecipeInventoryStockAdjustmentValidate(InventoryStockAdjustment item);
    }
}
