using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationCourseYearSemesterDataProvider
    {
        IBaseEntityResponse<OrganisationCourseYearSemester> InsertOrganisationCourseYearSemester(OrganisationCourseYearSemester item);
        IBaseEntityResponse<OrganisationCourseYearSemester> UpdateOrganisationCourseYearSemester(OrganisationCourseYearSemester item);
        IBaseEntityResponse<OrganisationCourseYearSemester> DeleteOrganisationCourseYearSemester(OrganisationCourseYearSemester item);
        IBaseEntityCollectionResponse<OrganisationCourseYearSemester> GetOrganisationCourseYearSemesterBySearch(OrganisationCourseYearSemesterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationCourseYearSemester> GetOrganisationCourseYearSemesterByID(OrganisationCourseYearSemester item);
    }
}
