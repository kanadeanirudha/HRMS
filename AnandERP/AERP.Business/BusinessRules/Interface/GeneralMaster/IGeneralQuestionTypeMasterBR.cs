
using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralQuestionTypeMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralQuestionTypeMasterValidate(GeneralQuestionTypeMaster item);
        IValidateBusinessRuleResponse UpdateGeneralQuestionTypeMasterValidate(GeneralQuestionTypeMaster item);
        IValidateBusinessRuleResponse DeleteGeneralQuestionTypeMasterValidate(GeneralQuestionTypeMaster item);
    }
}
