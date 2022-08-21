using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationCourseYearDetailsDataProvider
    {
        IBaseEntityResponse<OrganisationCourseYearDetails> InsertOrganisationCourseYearDetails(OrganisationCourseYearDetails item);
        IBaseEntityResponse<OrganisationCourseYearDetails> UpdateOrganisationCourseYearDetails(OrganisationCourseYearDetails item);
        IBaseEntityResponse<OrganisationCourseYearDetails> DeleteOrganisationCourseYearDetails(OrganisationCourseYearDetails item);
        IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetOrganisationCourseYearDetailsBySearch(OrganisationCourseYearDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationCourseYearDetails> GetOrganisationCourseYearDetailsByID(OrganisationCourseYearDetails item);
        IBaseEntityResponse<OrganisationCourseYearDetails> GetOrganisationCourseYearDetailsByID_For_CourseDescription(OrganisationCourseYearDetails item);
        IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetSemesterApplicableBySearch(OrganisationCourseYearDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationCourseYearDetails> SelectByBranchDetIDAndStandardNumber(OrganisationCourseYearDetails item);

        IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearListRoleWise(OrganisationCourseYearDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetNextCourseYearForPromotion(OrganisationCourseYearDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearListRole_CentreCode_UniversityWise(OrganisationCourseYearDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailsByCentreCode(OrganisationCourseYearDetailsSearchRequest searchRequest);
        
        IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailSearchList(OrganisationCourseYearDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailDescription(OrganisationCourseYearDetailsSearchRequest searchRequest);
   
    }
}
