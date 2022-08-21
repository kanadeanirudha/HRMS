using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAddCentreOpeningBalanceForInventoryBR
    {
        IValidateBusinessRuleResponse InsertAddCentreOpeningBalanceForInventoryValidate(AddCentreOpeningBalanceForInventory item);
        IValidateBusinessRuleResponse UpdateAddCentreOpeningBalanceForInventoryValidate(AddCentreOpeningBalanceForInventory item);
        IValidateBusinessRuleResponse DeleteAddCentreOpeningBalanceForInventoryValidate(AddCentreOpeningBalanceForInventory item);
    }
}
