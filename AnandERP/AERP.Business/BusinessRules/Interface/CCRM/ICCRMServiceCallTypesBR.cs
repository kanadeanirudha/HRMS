using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessRules
{
   public interface ICCRMServiceCallTypesBR
    {
        IValidateBusinessRuleResponse InsertCCRMServiceCallTypesValidate(CCRMServiceCallTypes item);
        IValidateBusinessRuleResponse UpdateCCRMServiceCallTypesValidate(CCRMServiceCallTypes item);
        IValidateBusinessRuleResponse DeleteCCRMServiceCallTypesValidate(CCRMServiceCallTypes item);
    }
}
