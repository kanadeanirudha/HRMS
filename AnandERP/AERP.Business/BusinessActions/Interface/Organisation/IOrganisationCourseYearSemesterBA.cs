using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationCourseYearSemesterBA
    {
        IBaseEntityResponse<OrganisationCourseYearSemester> InsertOrganisationCourseYearSemester(OrganisationCourseYearSemester item);
        IBaseEntityResponse<OrganisationCourseYearSemester> UpdateOrganisationCourseYearSemester(OrganisationCourseYearSemester item);
        IBaseEntityResponse<OrganisationCourseYearSemester> DeleteOrganisationCourseYearSemester(OrganisationCourseYearSemester item);
        IBaseEntityCollectionResponse<OrganisationCourseYearSemester> GetBySearch(OrganisationCourseYearSemesterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationCourseYearSemester> SelectByID(OrganisationCourseYearSemester item);
    }
}
