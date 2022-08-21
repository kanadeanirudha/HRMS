using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IRequestApprovalFormFieldNameMasterBR
    {
        IValidateBusinessRuleResponse InsertRequestApprovalFormFieldNameMasterValidate(RequestApprovalFormFieldNameMaster item);
        IValidateBusinessRuleResponse UpdateRequestApprovalFormFieldNameMasterValidate(RequestApprovalFormFieldNameMaster item);
        IValidateBusinessRuleResponse DeleteRequestApprovalFormFieldNameMasterValidate(RequestApprovalFormFieldNameMaster item);
    }
}
