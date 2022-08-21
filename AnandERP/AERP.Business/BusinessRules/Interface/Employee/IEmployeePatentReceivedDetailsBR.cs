using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IEmployeePatentReceivedDetailsBR
    {
        IValidateBusinessRuleResponse InsertEmployeePatentReceivedDetailsValidate(EmployeePatentReceivedDetails item);
        IValidateBusinessRuleResponse UpdateEmployeePatentReceivedDetailsValidate(EmployeePatentReceivedDetails item);
        IValidateBusinessRuleResponse DeleteEmployeePatentReceivedDetailsValidate(EmployeePatentReceivedDetails item);
    }
}
