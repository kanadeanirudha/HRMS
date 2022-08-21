using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IEmpEmployeeMasterBR
    {
        IValidateBusinessRuleResponse InsertEmpEmployeeMasterValidate(EmpEmployeeMaster item);
        IValidateBusinessRuleResponse UpdateEmpEmployeeMasterValidate(EmpEmployeeMaster item);
        IValidateBusinessRuleResponse DeleteEmpEmployeeMasterValidate(EmpEmployeeMaster item);
    }
}
