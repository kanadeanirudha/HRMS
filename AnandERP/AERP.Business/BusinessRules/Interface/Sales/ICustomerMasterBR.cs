using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ICustomerMasterBR
    {
        IValidateBusinessRuleResponse InsertCustomerMasterValidate(CustomerMaster item);
        IValidateBusinessRuleResponse InsertCustomerMasterContactDetailsValidate(CustomerMaster item);
        IValidateBusinessRuleResponse InsertCustomerMasterBranchDetailsValidate(CustomerMaster item);
        IValidateBusinessRuleResponse UpdateCustomerMasterValidate(CustomerMaster item);
        IValidateBusinessRuleResponse DeleteCustomerMasterValidate(CustomerMaster item);
    }
}
