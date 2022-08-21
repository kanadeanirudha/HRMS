using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralLanguageMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralLanguageMasterValidate(GeneralLanguageMaster item);

        IValidateBusinessRuleResponse UpdateGeneralLanguageMasterValidate(GeneralLanguageMaster item);

        IValidateBusinessRuleResponse DeleteGeneralLanguageMasterValidate(GeneralLanguageMaster item);
    }
}
