using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationSubjectGroupDetailsDataProvider
    {
        IBaseEntityResponse<OrganisationSubjectGroupDetails> InsertOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item);
        IBaseEntityResponse<OrganisationSubjectGroupDetails> UpdateOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item);
        IBaseEntityResponse<OrganisationSubjectGroupDetails> DeleteOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetOrganisationSubjectGroupDetailsBySearch(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetOrganisationSubjectTypeMasterBySearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetOrganisationElectiveGroupBySearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetSubOrganisationElectiveGroupBySearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubjectGroupDetails> GetOrganisationSubjectGroupDetailsByID(OrganisationSubjectGroupDetails item);
        //for onlineExam
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetByDescriptionList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
    }

}
