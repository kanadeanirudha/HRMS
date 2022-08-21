using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralPurchaseGroupMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralPurchaseGroupMasterValidate(GeneralPurchaseGroupMaster item);
        IValidateBusinessRuleResponse UpdateGeneralPurchaseGroupMasterValidate(GeneralPurchaseGroupMaster item);
        IValidateBusinessRuleResponse DeleteGeneralPurchaseGroupMasterValidate(GeneralPurchaseGroupMaster item);
    }
}
