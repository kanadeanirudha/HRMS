using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationCourseYearDetailsBR
    {
        IValidateBusinessRuleResponse InsertOrganisationCourseYearDetailsValidate(OrganisationCourseYearDetails item);
        IValidateBusinessRuleResponse UpdateOrganisationCourseYearDetailsValidate(OrganisationCourseYearDetails item);
        IValidateBusinessRuleResponse DeleteOrganisationCourseYearDetailsValidate(OrganisationCourseYearDetails item);
    }
}
