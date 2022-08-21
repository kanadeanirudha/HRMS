using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralPriceGroupBR
    {
        IValidateBusinessRuleResponse InsertGeneralPriceGroupValidate(GeneralPriceGroup item);
        IValidateBusinessRuleResponse UpdateGeneralPriceGroupValidate(GeneralPriceGroup item);
        IValidateBusinessRuleResponse DeleteGeneralPriceGroupValidate(GeneralPriceGroup item);
    }
}
