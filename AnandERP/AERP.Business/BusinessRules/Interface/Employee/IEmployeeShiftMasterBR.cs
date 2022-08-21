using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IEmployeeShiftMasterBR
    {
        IValidateBusinessRuleResponse InsertEmployeeShiftMasterValidate(EmployeeShiftMaster item);
        IValidateBusinessRuleResponse UpdateEmployeeShiftMasterValidate(EmployeeShiftMaster item);
        IValidateBusinessRuleResponse DeleteEmployeeShiftMasterValidate(EmployeeShiftMaster item);
        IValidateBusinessRuleResponse InsertEmployeeShiftMasterDetailsValidate(EmployeeShiftMaster item);
        IValidateBusinessRuleResponse UpdateEmployeeShiftMasterDetailsValidate(EmployeeShiftMaster item);
    }
}
