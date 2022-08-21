using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralCounterPOSAndPosOperatorBR
    {
        IValidateBusinessRuleResponse InsertGeneralCounterPOSAndPosOperatorValidate(GeneralCounterPOSAndPosOperator item);
        IValidateBusinessRuleResponse UpdateGeneralCounterPOSAndPosOperatorValidate(GeneralCounterPOSAndPosOperator item);
        IValidateBusinessRuleResponse DeleteGeneralCounterPOSAndPosOperatorValidate(GeneralCounterPOSAndPosOperator item);
    }
}
