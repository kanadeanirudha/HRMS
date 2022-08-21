using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralAllocateSaleProcessUnitBR
    {
        IValidateBusinessRuleResponse InsertGeneralAllocateSaleProcessUnitValidate(GeneralAllocateSaleProcessUnit item);
        IValidateBusinessRuleResponse UpdateGeneralAllocateSaleProcessUnitValidate(GeneralAllocateSaleProcessUnit item);
        IValidateBusinessRuleResponse DeleteGeneralAllocateSaleProcessUnitValidate(GeneralAllocateSaleProcessUnit item);
    }
}
