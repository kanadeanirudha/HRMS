using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralPriceListAndListLineBR
    {
        IValidateBusinessRuleResponse InsertGeneralPriceListAndListLineValidate(GeneralPriceListAndListLine item);
        IValidateBusinessRuleResponse UpdateGeneralPriceListAndListLineValidate(GeneralPriceListAndListLine item);
        IValidateBusinessRuleResponse DeleteGeneralPriceListAndListLineValidate(GeneralPriceListAndListLine item);

        //******************************************************************************************************
        IValidateBusinessRuleResponse InsertGeneralPriceListValidate(GeneralPriceListAndListLine item);
        IValidateBusinessRuleResponse UpdateGeneralPriceListValidate(GeneralPriceListAndListLine item);
        IValidateBusinessRuleResponse DeleteGeneralPriceListValidate(GeneralPriceListAndListLine item);
    }
}
