using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralMovementTypeBR
    {
        IValidateBusinessRuleResponse InsertGeneralMovementTypeValidate(GeneralMovementType item);
        IValidateBusinessRuleResponse UpdateGeneralMovementTypeValidate(GeneralMovementType item);
        IValidateBusinessRuleResponse DeleteGeneralMovementTypeValidate(GeneralMovementType item);
        IValidateBusinessRuleResponse InsertGeneralMovementTypeRulesValidate(GeneralMovementType item);
      
    }
}
