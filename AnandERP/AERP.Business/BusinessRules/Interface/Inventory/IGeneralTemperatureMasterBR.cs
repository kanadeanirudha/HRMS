using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralTemperatureMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralTemperatureMasterValidate(GeneralTemperatureMaster item);
        IValidateBusinessRuleResponse UpdateGeneralTemperatureMasterValidate(GeneralTemperatureMaster item);
        IValidateBusinessRuleResponse DeleteGeneralTemperatureMasterValidate(GeneralTemperatureMaster item);
    }
}
