using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralTimeSlotMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralTimeSlotMasterValidate(GeneralTimeSlotMaster item);
        IValidateBusinessRuleResponse UpdateGeneralTimeSlotMasterValidate(GeneralTimeSlotMaster item);
        IValidateBusinessRuleResponse DeleteGeneralTimeSlotMasterValidate(GeneralTimeSlotMaster item);
    }
}
