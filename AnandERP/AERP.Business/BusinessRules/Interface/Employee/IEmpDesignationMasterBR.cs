using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IEmpDesignationMasterBR
    {
        IValidateBusinessRuleResponse InsertEmpDesignationMasterValidate(EmpDesignationMaster item);

        IValidateBusinessRuleResponse UpdateEmpDesignationMasterValidate(EmpDesignationMaster item);

        IValidateBusinessRuleResponse DeleteEmpDesignationMasterValidate(EmpDesignationMaster item);
    }
}
