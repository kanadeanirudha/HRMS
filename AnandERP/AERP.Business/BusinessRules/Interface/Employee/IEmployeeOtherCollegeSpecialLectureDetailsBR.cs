using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IEmployeeOtherCollegeSpecialLectureDetailsBR
    {
        IValidateBusinessRuleResponse InsertEmployeeOtherCollegeSpecialLectureDetailsValidate(EmployeeOtherCollegeSpecialLectureDetails item);
        IValidateBusinessRuleResponse UpdateEmployeeOtherCollegeSpecialLectureDetailsValidate(EmployeeOtherCollegeSpecialLectureDetails item);
        IValidateBusinessRuleResponse DeleteEmployeeOtherCollegeSpecialLectureDetailsValidate(EmployeeOtherCollegeSpecialLectureDetails item);
    }
}
