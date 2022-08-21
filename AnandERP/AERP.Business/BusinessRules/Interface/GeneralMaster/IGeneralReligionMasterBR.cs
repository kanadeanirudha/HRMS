using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business
{
    public interface IGeneralReligionMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralReligionMasterValidate(GeneralReligionMaster item);

        IValidateBusinessRuleResponse UpdateGeneralReligionMasterValidate(GeneralReligionMaster item);

        IValidateBusinessRuleResponse DeleteGeneralReligionMasterValidate(GeneralReligionMaster item);
    }
}
