using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralPeriodTypeMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralPeriodTypeMasterValidate(GeneralPeriodTypeMaster item);
        IValidateBusinessRuleResponse UpdateGeneralPeriodTypeMasterValidate(GeneralPeriodTypeMaster item);
        IValidateBusinessRuleResponse DeleteGeneralPeriodTypeMasterValidate(GeneralPeriodTypeMaster item);
    }
}
