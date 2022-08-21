using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IEmployeeDocumentRequiredBR
    {
        IValidateBusinessRuleResponse InsertEmployeeDocumentRequiredValidate(EmployeeDocumentRequired item);
        IValidateBusinessRuleResponse UpdateEmployeeDocumentRequiredValidate(EmployeeDocumentRequired item);
        IValidateBusinessRuleResponse DeleteEmployeeDocumentRequiredValidate(EmployeeDocumentRequired item);
    }
}
