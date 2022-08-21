using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationCourseYearSemesterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationCourseYearSemesterValidate(OrganisationCourseYearSemester item);
        IValidateBusinessRuleResponse UpdateOrganisationCourseYearSemesterValidate(OrganisationCourseYearSemester item);
        IValidateBusinessRuleResponse DeleteOrganisationCourseYearSemesterValidate(OrganisationCourseYearSemester item);
    }
}
