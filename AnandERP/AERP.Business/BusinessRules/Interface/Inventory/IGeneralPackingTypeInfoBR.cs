using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralPackingTypeInfoBR
    {
        IValidateBusinessRuleResponse InsertGeneralPackingTypeInfoValidate(GeneralPackingTypeInfo item);
        IValidateBusinessRuleResponse UpdateGeneralPackingTypeInfoValidate(GeneralPackingTypeInfo item);
        IValidateBusinessRuleResponse DeleteGeneralPackingTypeInfoValidate(GeneralPackingTypeInfo item);
    }
}
