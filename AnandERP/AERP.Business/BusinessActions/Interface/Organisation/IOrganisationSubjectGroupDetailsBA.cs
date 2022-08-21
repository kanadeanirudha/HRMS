using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationSubjectGroupDetailsBA
    {
        IBaseEntityResponse<OrganisationSubjectGroupDetails> InsertOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item);
        IBaseEntityResponse<OrganisationSubjectGroupDetails> UpdateOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item);
        IBaseEntityResponse<OrganisationSubjectGroupDetails> DeleteOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySearch(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySubjectTypeMaterList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetByElectiveGroupSearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySubElectiveGroupSearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubjectGroupDetails> SelectByID(OrganisationSubjectGroupDetails item);
        // For OnlineExamSupportStaff
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetByDescriptionList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
    }
}
