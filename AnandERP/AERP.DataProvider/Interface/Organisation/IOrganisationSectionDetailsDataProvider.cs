using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationSectionDetailsDataProvider
    {
        IBaseEntityResponse<OrganisationSectionDetails> InsertOrganisationSectionDetails(OrganisationSectionDetails item);
        IBaseEntityResponse<OrganisationSectionDetails> UpdateOrganisationSectionDetails(OrganisationSectionDetails item);
        IBaseEntityResponse<OrganisationSectionDetails> DeleteOrganisationSectionDetails(OrganisationSectionDetails item);
        IBaseEntityCollectionResponse<OrganisationSectionDetails> GetOrganisationSectionDetailsBySearch(OrganisationSectionDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSectionDetails> GetSearchOrganisationSectionDetailsByID(OrganisationSectionDetails item);
        IBaseEntityCollectionResponse<OrganisationSectionDetails> GetOrganisationSectionDetailsByID(OrganisationSectionDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSectionDetails> GetOrganisationSectionDetailsBySearchForSectionDetailsAdd(OrganisationSectionDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSectionDetails> GetSearchOrganisationSectionDetailsByID_OR_CourseYearID(OrganisationSectionDetails item);

        IBaseEntityResponse<OrganisationSectionDetails> UpdateOrganisationSectionDetailsAdd(OrganisationSectionDetails item);

        IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsRoleWise(OrganisationSectionDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsForPromotion(OrganisationSectionDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsRole_CentreCode_UniversityWise(OrganisationSectionDetailsSearchRequest searchRequest);
    }
}
